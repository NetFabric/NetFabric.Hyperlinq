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
        static bool HandleAsValueEnumerable(Compilation compilation, TypeSymbolsCache typeSymbolsCache, MemberAccessExpressionSyntax expressionSyntax, CodeBuilder builder, CancellationToken cancellationToken)
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
                var enumerableTypeString = $"{receiverTypeString}AsValueEnumerable";
                var itemType = enumerableSymbols.EnumeratorSymbols.Current.Type;
                var itemTypeString = itemType.ToDisplayString();

                // Check if the returned type by GetEnumerator() does not require a wrapper
                var useGetEnumeratorReturnType = false;
                var getEnumeratorReturnType = enumerableSymbols.GetEnumerator.ReturnType;
                var getEnumeratorReturnTypeString = getEnumeratorReturnType.ToDisplayString();

                // Check what interfaces the enumerable implements, minimizing the calls to ImplementsInterface()
                string enumeratorTypeString;
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

                // Generate the method
                _ = builder
                    .AppendLine()
                    .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                    .AppendLine($"public static {enumerableTypeString} AsValueEnumerable(this {receiverTypeString} source) => new(source);")
                    .AppendLine();

                // Generate the value enumerable wrapper
                using (builder.AppendBlock($"public readonly struct {enumerableTypeString}: IValueEnumerable<{itemType.ToDisplayString()}, {enumeratorTypeString}>"))
                {
                    _ = builder
                        .AppendLine($"readonly {receiverTypeString} source;") // source field
                        .AppendLine()
                        .AppendLine($"public {enumerableTypeString}({receiverTypeString} source) => this.source = source;"); // constructor

                    if (useGetEnumeratorReturnType)
                    {
                        // No wrapper required
                        _ = builder
                            .AppendLine()
                            .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                            .AppendLine($"public {enumeratorTypeString} GetEnumerator() => source.GetEnumerator();")
                            .AppendLine()
                            .AppendLine($"IEnumerator<{itemTypeString}> IEnumerable<{itemTypeString}>.GetEnumerator() => source.GetEnumerator();")
                            .AppendLine()
                            .AppendLine($"IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();");
                    }
                    else if (enumeratorImplementsIEnumerator)
                    {
                        // Use the ValueEnumerator<> wrapper
                        _ = builder
                            .AppendLine()
                            .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                            .AppendLine($"public {enumeratorTypeString} GetEnumerator() => new(source.GetEnumerator());")
                            .AppendLine()
                            .AppendLine($"IEnumerator<{itemTypeString}> IEnumerable<{itemTypeString}>.GetEnumerator() => source.GetEnumerator();")
                            .AppendLine()
                            .AppendLine($"IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();");
                    }
                    else if (enumerableImplementsIEnumerable)
                    {
                        // Use the ValueEnumerator<> wrapper but need to cast to call GetEnumerator()
                        _ = builder
                            .AppendLine()
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
                    else
                    {
                        // A custom wrapper is required

                        _ = builder
                            .AppendLine()
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
                                .AppendLine("public bool MoveNext() => source.MoveNext();")
                                .AppendLine();

                            _ = enumerableSymbols.EnumeratorSymbols.Reset is null
                                ? builder.AppendLine("public void Reset() => throw new NotSupportedException();")
                                : builder.AppendLine("public void Reset() => source.Reset();");

                            _ = builder.AppendLine();

                            _ = enumerableSymbols.EnumeratorSymbols.Dispose is null
                                ? builder.AppendLine("public void Dispose() { }")
                                : builder.AppendLine("public void Dispose() => source.Dispose();");
                        }
                    }

                    if (enumerableImplementsICollection || enumerableImplementsIReadOnlyCollection)
                    {
                        _ = builder
                            .AppendLine()
                            .AppendLine("public int Count => source.Count;")
                            .AppendLine()
                            .AppendLine("public bool IsReadOnly => true;")
                            .AppendLine()
                            .AppendLine($"void ICollection<{itemTypeString}>.Add({itemTypeString} item) => throw new NotSupportedException();")
                            .AppendLine()
                            .AppendLine($"bool ICollection<{itemTypeString}>.Remove({itemTypeString} item) => throw new NotSupportedException();")
                            .AppendLine()
                            .AppendLine($"void ICollection<{itemTypeString}>.Clear() => throw new NotSupportedException();");

                        _ = enumerableImplementsICollection
                            ? builder
                                .AppendLine()
                                .AppendLine($"public bool Contains({itemTypeString} item) => source.Contains(item);")
                                .AppendLine()
                                .AppendLine($"public void CopyTo({itemTypeString}[] array, int arrayIndex) => source.CopyTo(array, arrayIndex);")
                            : builder
                                .AppendLine()
                                .AppendLine($"public bool Contains({itemTypeString} item) => source.Contains(item);")
                                .AppendLine()
                                .AppendLine($"public void CopyTo({itemTypeString}[] array, int arrayIndex) => source.CopyTo(array, arrayIndex);");

                        if (enumerableImplementsIList || enumerableImplementsIReadOnlyList)
                        {
                            _ = builder
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
                                .AppendLine($"void IList<{itemTypeString}>.RemoveAt(int index) => throw new NotSupportedException();");

                            _ = enumerableImplementsIList
                                ? builder
                                    .AppendLine()
                                    .AppendLine($"public int IndexOf({itemTypeString} item) => source.IndexOf(item);")
                                : builder
                                    .AppendLine()
                                    .AppendLine($"public int IndexOf({itemTypeString} item) => source.IndexOf(item);");
                        }
                    }

                    return true;
                }
            }

            return false;
        }
    }
}