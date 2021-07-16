using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NetFabric.CodeAnalysis;
using System;
using System.Threading;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    public partial class Generator
    {
        static bool HandleAsValueEnumerable(Compilation compilation, TypeSymbolsCache typeSymbolsCache, MemberAccessExpressionSyntax expressionSyntax, CodeBuilder builder, CancellationToken cancellationToken, bool isUnitTest)
        {
            // Get the type this operator is applied to
            var semanticModel = compilation.GetSemanticModel(expressionSyntax.SyntaxTree);
            var receiverTypeSymbol = semanticModel.GetTypeInfo(expressionSyntax.Expression).Type;

            // Check if NetFabric.Hyperlinq already contains specific overloads for this type
            if (receiverTypeSymbol is null 
                or { TypeKind: TypeKind.Array } // is array
                || SymbolEqualityComparer.Default.Equals(receiverTypeSymbol.OriginalDefinition, typeSymbolsCache[typeof(ArraySegment<>)])
                || SymbolEqualityComparer.Default.Equals(receiverTypeSymbol.OriginalDefinition, typeSymbolsCache[typeof(Span<>)])
                || SymbolEqualityComparer.Default.Equals(receiverTypeSymbol.OriginalDefinition, typeSymbolsCache[typeof(ReadOnlySpan<>)])
                || SymbolEqualityComparer.Default.Equals(receiverTypeSymbol.OriginalDefinition, typeSymbolsCache[typeof(Memory<>)])
                || SymbolEqualityComparer.Default.Equals(receiverTypeSymbol.OriginalDefinition, typeSymbolsCache[typeof(ReadOnlyMemory<>)])
                )
                return false; // no need to generate an implementation

            // Generate the method source depending on receiver type characteristics
            var receiverTypeString = receiverTypeSymbol.ToDisplayString();

            // Receiver type implements IValueEnumerable<,>

            if (IsValueEnumerable(receiverTypeSymbol, typeSymbolsCache))
            {
                // Receiver instance returns itself
                _ = builder
                    .AppendLine()
                    .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                    .AppendLine($"public static {receiverTypeString} AsValueEnumerable(this {receiverTypeString} source) => source;");

                return true;
            }


            // Receiver type is an enumerable

            if (receiverTypeSymbol.IsEnumerable(compilation, out var enumerableSymbols))
            {
                // Use an unique identifier to avoid name clashing
                var uniqueIdString = isUnitTest 
                    ? receiverTypeString.Replace('.', '_').Replace(',', '_').Replace('<', '_').Replace('>', '_').Replace('`', '_')
                    : Guid.NewGuid().ToString().Replace('-', '_'); // Use a GUID to avoid naming overflow

                var enumerableTypeString = $"AsValueEnumerable_{uniqueIdString}";
                var itemType = enumerableSymbols.EnumeratorSymbols.Current.Type;
                var itemTypeString = itemType.ToDisplayString();

                // Check if the returned type by GetEnumerator() does not require a wrapper
                var useGetEnumeratorReturnType = false;
                var getEnumeratorReturnType = enumerableSymbols.GetEnumerator.ReturnType;
                var getEnumeratorReturnTypeString = getEnumeratorReturnType.ToDisplayString();

                // Check what interfaces the enumerable implements, minimizing the calls to ImplementsInterface()
                var enumerableImplementsIEnumerable = receiverTypeSymbol.ImplementsInterface(SpecialType.System_Collections_Generic_IEnumerable_T, out var _);
                var enumerableImplementsICollection = false;
                var enumerableImplementsIReadOnlyCollection = false;
                var enumerableImplementsIList = false;
                var enumerableImplementsIReadOnlyList = false;
                if (enumerableImplementsIEnumerable)
                {
                    enumerableImplementsICollection = receiverTypeSymbol.ImplementsInterface(SpecialType.System_Collections_Generic_ICollection_T, out var _);
                    if (enumerableImplementsICollection)
                        enumerableImplementsIList = receiverTypeSymbol.ImplementsInterface(SpecialType.System_Collections_Generic_IList_T, out var _);

                    enumerableImplementsIReadOnlyCollection = receiverTypeSymbol.ImplementsInterface(SpecialType.System_Collections_Generic_IReadOnlyCollection_T, out var _);
                    if (enumerableImplementsIReadOnlyCollection)
                        enumerableImplementsIReadOnlyList = receiverTypeSymbol.ImplementsInterface(SpecialType.System_Collections_Generic_IReadOnlyList_T, out var _);
                }

                // Define what value enumerator type will be used
                string enumeratorTypeString;
                var enumeratorImplementsIEnumerator = getEnumeratorReturnType.ImplementsInterface(SpecialType.System_Collections_Generic_IEnumerator_T, out var _);
                if (enumeratorImplementsIEnumerator)
                {
                    if (getEnumeratorReturnType.IsValueType)
                    {
                        // Enumerator is value type and implements IEnumerator<>
                        useGetEnumeratorReturnType = true;
                        enumeratorTypeString = getEnumeratorReturnTypeString;
                    }
                    else
                    {
                        enumeratorTypeString = $"ValueEnumerator<{itemTypeString}>";
                    }
                }
                else
                {
                    enumeratorTypeString = enumerableImplementsIEnumerable
                        ? $"ValueEnumerator<{itemTypeString}>" 
                        : $"{enumerableTypeString}.Enumerator";
                }

                // Define what interfaces the wrapper should implement
                string baseTypesString;
                if (enumerableImplementsIList || enumerableImplementsIReadOnlyList)
                    baseTypesString = $"IValueReadOnlyList<{itemTypeString}, {enumeratorTypeString}>, IList<{itemTypeString}>";
                else if (enumerableImplementsICollection || enumerableImplementsIReadOnlyCollection)
                    baseTypesString = $"IValueReadOnlyCollection<{itemTypeString}, {enumeratorTypeString}>, ICollection<{itemTypeString}>";
                else
                    baseTypesString = $"IValueEnumerable<{itemTypeString}, {enumeratorTypeString}>";

                // Generate the method
                _ = builder
                    .AppendLine()
                    .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                    .AppendLine($"public static {enumerableTypeString} AsValueEnumerable(this {receiverTypeString} source) => new(source);")
                    .AppendLine();

                // Generate the value enumerable wrapper
                using (builder.AppendBlock($"public readonly struct {enumerableTypeString}: {baseTypesString}"))
                {
                    _ = builder
                        .AppendLine($"readonly {receiverTypeString} source;") // source field
                        .AppendLine()
                        .AppendLine($"public {enumerableTypeString}({receiverTypeString} source) => this.source = source;") // constructor
                        .AppendLine()
                        .AppendLine($"// Implement IValueEnumerable<{itemTypeString}, {enumeratorTypeString}>")
                        .AppendLine();

                    if (useGetEnumeratorReturnType)
                    {
                        // No enumerator wrapper required
                        _ = builder
                            .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                            .AppendLine($"public {enumeratorTypeString} GetEnumerator() => source.GetEnumerator();")
                            .AppendLine()
                            .AppendLine($"IEnumerator<{itemTypeString}> IEnumerable<{itemTypeString}>.GetEnumerator() => source.GetEnumerator();")
                            .AppendLine()
                            .AppendLine($"IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();");
                    }
                    else if (enumeratorImplementsIEnumerator)
                    {
                        // Use the ValueEnumerator<> enumerator wrapper
                        _ = builder
                            .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                            .AppendLine($"public {enumeratorTypeString} GetEnumerator() => new(source.GetEnumerator());")
                            .AppendLine()
                            .AppendLine($"IEnumerator<{itemTypeString}> IEnumerable<{itemTypeString}>.GetEnumerator() => source.GetEnumerator();")
                            .AppendLine()
                            .AppendLine($"IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();");
                    }
                    else if (enumerableImplementsIEnumerable)
                    {
                        // Use the ValueEnumerator<> enumerator wrapper but need to cast to call GetEnumerator()
                        _ = builder
                            .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                            .AppendLine($"public {getEnumeratorReturnTypeString} GetEnumerator() => source.GetEnumerator();")
                            .AppendLine()
                            .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                            .AppendLine($"ValueEnumerator<{itemTypeString}> IValueEnumerable<{itemTypeString}, ValueEnumerator<{itemTypeString}>>.GetEnumerator() => new(((IEnumerable<{itemTypeString}>)source).GetEnumerator());")
                            .AppendLine()
                            .AppendLine($"IEnumerator<{itemTypeString}> IEnumerable<{itemTypeString}>.GetEnumerator() => ((IEnumerable<{itemTypeString}>)source).GetEnumerator();")
                            .AppendLine()
                            .AppendLine($"IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<{itemTypeString}>)source).GetEnumerator();");
                    }
                    else if (!getEnumeratorReturnType.IsRefLikeType)
                    {
                        // A custom enumerator wrapper is required

                        _ = builder
                            .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                            .AppendLine($"public {getEnumeratorReturnTypeString} GetEnumerator() => source.GetEnumerator();")
                            .AppendLine()
                            .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                            .AppendLine($"Enumerator IValueEnumerable<{itemTypeString}, Enumerator>.GetEnumerator() => new(source.GetEnumerator());")
                            .AppendLine()
                            .AppendLine($"IEnumerator<{itemTypeString}> IEnumerable<{itemTypeString}>.GetEnumerator() => new Enumerator(source.GetEnumerator());")
                            .AppendLine()
                            .AppendLine($"IEnumerator IEnumerable.GetEnumerator() => new Enumerator(source.GetEnumerator());")
                            .AppendLine();

                        using (builder.AppendBlock($"public struct Enumerator: IEnumerator<{itemTypeString}>"))
                        {
                            _ = builder
                                .AppendLine($"readonly {getEnumeratorReturnTypeString} source;")
                                .AppendLine()
                                .AppendLine($"public Enumerator({getEnumeratorReturnTypeString} source) => this.source = source;")
                                .AppendLine()
                                .AppendLine($"public {itemTypeString} Current => source.Current;")
                                .AppendLine()
                                .AppendLine("object? IEnumerator.Current => source.Current;")
                                .AppendLine()
                                .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                                .AppendLine("public bool MoveNext() => source.MoveNext();")
                                .AppendLine();

                            _ = enumerableSymbols.EnumeratorSymbols.Reset is null
                                ? builder
                                    .AppendLine("public void Reset() => throw new NotSupportedException();")
                                : builder
                                    .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                                    .AppendLine("public void Reset() => source.Reset();");

                            _ = builder.AppendLine();

                            _ = enumerableSymbols.EnumeratorSymbols.Dispose is null
                                ? builder
                                    .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                                    .AppendLine("public void Dispose() { }")
                                : builder
                                    .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                                    .AppendLine("public void Dispose() => source.Dispose();");
                        }
                    }

                    // Implement ICollection<>

                    if (enumerableImplementsICollection || enumerableImplementsIReadOnlyCollection)
                    {
                        _ = builder
                            .AppendLine()
                            .AppendLine($"// Implement ICollection<{itemTypeString}>")
                            .AppendLine()
                            .AppendLine("public int Count => source.Count;")
                            .AppendLine()
                            .AppendLine("public bool IsReadOnly => true;")
                            .AppendLine()
                            .AppendLine($"void ICollection<{itemTypeString}>.Add({itemTypeString} item) => throw new NotSupportedException();")
                            .AppendLine()
                            .AppendLine($"bool ICollection<{itemTypeString}>.Remove({itemTypeString} item) => throw new NotSupportedException();")
                            .AppendLine()
                            .AppendLine($"void ICollection<{itemTypeString}>.Clear() => throw new NotSupportedException();")
                            .AppendLine();

                        // Add a CopyTo() that takes a Span<> as parameter
                        using (builder.AppendBlock($"public void CopyTo(Span<{itemTypeString}> span)"))
                        {
                            _ = builder
                                .AppendLine("if (Count is 0) return;")
                                .AppendLine("if (span.Length < Count) throw new ArgumentException(\"Destination span was not long enough.\", nameof(span));")
                                .AppendLine();

                            _ = builder.AppendLine("var index = 0;");
                            using (builder.AppendBlock("foreach (var current in this)"))
                            {
                                _ = builder
                                    .AppendLine("span[index] = current;")
                                    .AppendLine("checked { index++; }");
                            }
                        }

                        if (enumerableImplementsICollection)
                        {
                            // Call the methods implemented by the source
                            _ = builder
                                .AppendLine()
                                .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                                .AppendLine($"public bool Contains({itemTypeString} item) => source.Contains(item);")
                                .AppendLine()
                                .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                                .AppendLine($"public void CopyTo({itemTypeString}[] array, int arrayIndex) => source.CopyTo(array, arrayIndex);");
                        }
                        else
                        {
                            // The source does not implement these methods so we have to add an implementation
                            _ = builder.AppendLine();

                            using (builder.AppendBlock($"public bool Contains({itemTypeString} item)"))
                            {
                                using (builder.AppendBlock($"foreach (var current in this)"))
                                {
                                    _ = builder.AppendLine($"if (EqualityComparer<{itemTypeString}>.Default.Equals(current, item)) return true;");
                                }
                                _ = builder.AppendLine("return true;");
                            }

                            _ = builder
                                .AppendLine()
                                .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                                .AppendLine($"public void CopyTo({itemTypeString}[] array, int arrayIndex) => CopyTo(array.AsSpan(arrayIndex));");
                        }

                        // Implement ICollection<>

                        if (enumerableImplementsIList || enumerableImplementsIReadOnlyList)
                        {
                            _ = builder
                                .AppendLine()
                                .AppendLine($"// Implement IList<{itemTypeString}>")
                                .AppendLine()
                                .AppendLine($"public {itemTypeString} this[int index] => source[index];")
                                .AppendLine();

                            using (builder.AppendBlock($"{itemTypeString} IList<{itemTypeString}>.this[int index]"))
                            {
                                _ = builder
                                    .AppendLine("get => source[index];")
                                    .AppendLine("set => throw new NotSupportedException();");
                            }

                            _ = builder
                                .AppendLine()
                                .AppendLine($"void IList<{itemTypeString}>.Insert(int index, {itemTypeString} item) => throw new NotSupportedException();")
                                .AppendLine()
                                .AppendLine($"void IList<{itemTypeString}>.RemoveAt(int index) => throw new NotSupportedException();")
                                .AppendLine();

                            if (enumerableImplementsIList)
                            {
                                // Call the methods implemented by the source
                                _ = builder
                                    .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                                    .AppendLine($"public int IndexOf({itemTypeString} item) => source.IndexOf(item);");
                            }
                            else
                            {
                                // The source does not implement these methods so we have to add an implementation
                                using (builder.AppendBlock($"public int IndexOf({itemTypeString} item)"))
                                {
                                    using (builder.AppendBlock($"if (Count is not 0)"))
                                    {
                                        _ = builder.AppendLine("var index = 0;");
                                        using (builder.AppendBlock($"foreach (var current in this)"))
                                        {
                                            _ = builder
                                                .AppendLine($"if (EqualityComparer<{itemTypeString}>.Default.Equals(current, item)) return index;")
                                                .AppendLine()
                                                .AppendLine("checked { index++; }");
                                        }
                                    }
                                    _ = builder.AppendLine("return -1;");
                                }
                            }
                        }
                    }

                    return true;
                }
            }

            return false;
        }
    }
}