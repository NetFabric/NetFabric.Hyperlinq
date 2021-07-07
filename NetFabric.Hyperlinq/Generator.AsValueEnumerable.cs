using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NetFabric.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    public partial class Generator
    {
        static ValueEnumerableType? GenerateSourceAsValueEnumerable(Compilation compilation, SemanticModel semanticModel, TypeSymbolsCache typeSymbolsCache, MemberAccessExpressionSyntax expressionSyntax, CodeBuilder builder, Dictionary<MethodSignature, ValueEnumerableType> generatedMethods, CancellationToken cancellationToken)
        {
            // Check if the method is already defined in the project source
            if (semanticModel.GetSymbolInfo(expressionSyntax, cancellationToken).Symbol is IMethodSymbol { } methodSymbol)
                return methodSymbol.ReturnType.ToValueEnumerableType(typeSymbolsCache);

            // Get the type this operator is applied to
            var receiverTypeSymbol = semanticModel.GetTypeInfo(expressionSyntax.Expression, cancellationToken).Type;

            // Check if NetFabric.Hyperlinq already contains specific overloads for this type
            // This is required for when the 'using NetFabric.Hyperlinq;' statement is missing
            if (receiverTypeSymbol is null
                or { TypeKind: TypeKind.Array } // is array
                || SymbolEqualityComparer.Default.Equals(receiverTypeSymbol.OriginalDefinition, typeSymbolsCache[typeof(ArraySegment<>)])
                || SymbolEqualityComparer.Default.Equals(receiverTypeSymbol.OriginalDefinition, typeSymbolsCache[typeof(Span<>)])
                || SymbolEqualityComparer.Default.Equals(receiverTypeSymbol.OriginalDefinition, typeSymbolsCache[typeof(ReadOnlySpan<>)])
                || SymbolEqualityComparer.Default.Equals(receiverTypeSymbol.OriginalDefinition, typeSymbolsCache[typeof(Memory<>)])
                || SymbolEqualityComparer.Default.Equals(receiverTypeSymbol.OriginalDefinition, typeSymbolsCache[typeof(ReadOnlyMemory<>)])
                || SymbolEqualityComparer.Default.Equals(receiverTypeSymbol.OriginalDefinition, typeSymbolsCache[typeof(List<>)])
                || SymbolEqualityComparer.Default.Equals(receiverTypeSymbol.OriginalDefinition, typeSymbolsCache[typeof(ImmutableArray<>)])
                )
                return null; // Do generate an implementation. The 'using NetFabric.Hyperlinq;' statement should be added instead.

            // Receiver type implements IValueEnumerable<,>

            var valueEnumerableType = AsValueEnumerable(expressionSyntax, compilation, semanticModel, typeSymbolsCache, expressionSyntax, builder, generatedMethods, cancellationToken);
            if (valueEnumerableType is not null)
            {
                // Check if the method is already defined by this generator
                var methodSignature = new MethodSignature("AsValueEnumerable", valueEnumerableType.Name);
                if (generatedMethods.TryGetValue(methodSignature, out var returnType))
                    return returnType;

                // Receiver instance returns itself
                _ = builder
                    .AppendLine()
                    .AppendGeneratedCodeMethodAttributes()
                    .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                    .AppendLine($"public static {valueEnumerableType.Name} AsValueEnumerable(this {valueEnumerableType.Name} source)")
                    .AppendIndentation().AppendLine($"=> source;");

                // A new AsValueEnumerable() method has been generated
                generatedMethods.Add(methodSignature, valueEnumerableType);
                return valueEnumerableType;
            }

            // Receiver type is an enumerable

            if (receiverTypeSymbol.IsEnumerable(compilation, out var enumerableSymbols))
            {
                var receiverTypeString = receiverTypeSymbol.ToDisplayString();

                // Check if the method is already defined by this generator
                var methodSignature = new MethodSignature("AsValueEnumerable", receiverTypeString);
                if (generatedMethods.TryGetValue(methodSignature, out var returnType))
                    return returnType;

                // Use an unique identifier to avoid name clashing
                var uniqueIdString = builder.IsUnitTest 
                    ? receiverTypeString.Replace('.', '_').Replace(',', '_').Replace('<', '_').Replace('>', '_').Replace('`', '_')
                    : Guid.NewGuid().ToString().Replace('-', '_'); // Use a GUID to avoid naming overflow

                var enumerableTypeString = $"AsValueEnumerable_{uniqueIdString}";
                var itemType = enumerableSymbols.EnumeratorSymbols.Current.Type;
                var itemTypeString = itemType.ToDisplayString();

                // Check if the returned type by GetEnumerator() does not require a wrapper
                var getEnumeratorReturnType = enumerableSymbols.GetEnumerator.ReturnType;
                var getEnumeratorReturnTypeString = getEnumeratorReturnType.ToDisplayString();

                // Check what interfaces the enumerable implements, minimizing the calls to ImplementsInterface()
                var enumerableImplementsIEnumerable = receiverTypeSymbol.ImplementsInterface(SpecialType.System_Collections_Generic_IEnumerable_T, out _);
                var enumerableImplementsICollection = false;
                var enumerableImplementsIReadOnlyCollection = false;
                var enumerableImplementsIList = false;
                var enumerableImplementsIReadOnlyList = false;
                if (enumerableImplementsIEnumerable)
                {
                    enumerableImplementsICollection = receiverTypeSymbol.ImplementsInterface(SpecialType.System_Collections_Generic_ICollection_T, out _);
                    if (enumerableImplementsICollection)
                        enumerableImplementsIList = receiverTypeSymbol.ImplementsInterface(SpecialType.System_Collections_Generic_IList_T, out _);

                    enumerableImplementsIReadOnlyCollection = receiverTypeSymbol.ImplementsInterface(SpecialType.System_Collections_Generic_IReadOnlyCollection_T, out _);
                    if (enumerableImplementsIReadOnlyCollection)
                        enumerableImplementsIReadOnlyList = receiverTypeSymbol.ImplementsInterface(SpecialType.System_Collections_Generic_IReadOnlyList_T, out _);
                }

                // Define what value enumerator type will be used
                var enumeratorImplementsIEnumerator = getEnumeratorReturnType.ImplementsInterface(SpecialType.System_Collections_Generic_IEnumerator_T, out _);
                var useConstraints = enumerableImplementsIEnumerable;

                var enumeratorTypeString = enumeratorImplementsIEnumerator
                    ? getEnumeratorReturnType.IsValueType
                        ? getEnumeratorReturnTypeString
                        : $"ValueEnumerator<{itemTypeString}>"
                    : useConstraints
                        ? $"{enumerableTypeString}<TEnumerable>.Enumerator"
                        : $"{enumerableTypeString}.Enumerator";

                // Generate the method
                _ = useConstraints
                    ? builder
                        .AppendLine()
                        .AppendGeneratedCodeMethodAttributes()
                        .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLine($"public static {enumerableTypeString}<{receiverTypeString}> AsValueEnumerable(this {receiverTypeString} source)")
                        .AppendIndentation().AppendLine($"=> new(source, source);")
                    : builder
                        .AppendLine()
                        .AppendGeneratedCodeMethodAttributes()
                        .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLine($"public static {enumerableTypeString} AsValueEnumerable(this {receiverTypeString} source)")
                        .AppendIndentation().AppendLine($"=> new(source);");

                // Generate the value enumerable wrapper
                string valueEnumerableTypeName;
                valueEnumerableTypeName = useConstraints
                    ? $"{enumerableTypeString}<TEnumerable>"
                    : enumerableTypeString;

                _ = builder
                        .AppendLine()
                        .AppendLine($"public readonly struct {valueEnumerableTypeName}");

                // Define what interfaces the wrapper implements
                if (enumerableImplementsIList || enumerableImplementsIReadOnlyList)
                    _ = builder.AppendIndentation().AppendLine($": IValueReadOnlyList<{itemTypeString}, {enumeratorTypeString}>, IList<{itemTypeString}>");
                else if (enumerableImplementsICollection || enumerableImplementsIReadOnlyCollection)
                    _ = builder.AppendIndentation().AppendLine($": IValueReadOnlyCollection<{itemTypeString}, {enumeratorTypeString}>, ICollection<{itemTypeString}>");
                else
                    _ = builder.AppendIndentation().AppendLine($": IValueEnumerable<{itemTypeString}, {enumeratorTypeString}>");

                if (useConstraints)
                {
                    if (enumerableImplementsIList)
                        _ = builder.AppendIndentation().AppendLine($"where TEnumerable : IList<TestValueType>");
                    else if (enumerableImplementsIReadOnlyList)
                        _ = builder.AppendIndentation().AppendLine($"where TEnumerable : IReadOnlyList<TestValueType>");
                    else if (enumerableImplementsICollection)
                        _ = builder.AppendIndentation().AppendLine($"where TEnumerable : ICollection<TestValueType>");
                    else if (enumerableImplementsIReadOnlyCollection)
                        _ = builder.AppendIndentation().AppendLine($"where TEnumerable : IReadOnlyCollection<TestValueType>");
                    else if (enumerableImplementsIEnumerable)
                        _ = builder.AppendIndentation().AppendLine($"where TEnumerable : IEnumerable<TestValueType>");
                }

                using (builder.AppendBlock())
                {
                    // Define fields
                    _ = builder.AppendLine($"readonly {receiverTypeString} source;");
                    if (useConstraints)
                        _ = builder.AppendLine($"readonly TEnumerable source2;");

                    // Define constructor
                    _ = useConstraints
                        ? builder
                            .AppendLine()
                            .AppendLine($"internal {enumerableTypeString}({receiverTypeString} source, TEnumerable source2)")
                            .AppendIndentation().AppendLine($"=> (this.source, this.source2) = (source, source2);")
                        : builder
                            .AppendLine()
                            .AppendLine($"internal {enumerableTypeString}({receiverTypeString} source)")
                            .AppendIndentation().AppendLine($"=> this.source = source;");

                    // Implement IValueEnumerable<,>

                    _ = builder
                        .AppendLine()
                        .AppendLine($"// Implement IValueEnumerable<{itemTypeString}, {enumeratorTypeString}>")
                        .AppendLine();

                    if (enumeratorImplementsIEnumerator)
                    {
                        if (getEnumeratorReturnType.IsValueType)
                        {
                            // No enumerator wrapper required
                            _ = builder
                                .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                                .AppendLine($"public {enumeratorTypeString} GetEnumerator() => source.GetEnumerator();")
                                .AppendLine()
                                .AppendLine($"IEnumerator<{itemTypeString}> IEnumerable<{itemTypeString}>.GetEnumerator() => source2.GetEnumerator();")
                                .AppendLine()
                                .AppendLine($"IEnumerator IEnumerable.GetEnumerator() => source2.GetEnumerator();");
                        }
                        else if (enumerableSymbols.GetEnumerator.ContainingType.IsInterface())
                        {
                            // Use the ValueEnumerator<> enumerator wrapper
                            _ = builder
                                .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                                .AppendLine($"public ValueEnumerator<{itemTypeString}> GetEnumerator() => new(source2.GetEnumerator());")
                                .AppendLine()
                                .AppendLine($"IEnumerator<{itemTypeString}> IEnumerable<{itemTypeString}>.GetEnumerator() => source2.GetEnumerator();")
                                .AppendLine()
                                .AppendLine($"IEnumerator IEnumerable.GetEnumerator() => source2.GetEnumerator();");
                        }
                        else
                        {
                            // Use the ValueEnumerator<> enumerator wrapper
                            _ = builder
                                .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                                .AppendLine($"public ValueEnumerator<{itemTypeString}> GetEnumerator() => new(source.GetEnumerator());")
                                .AppendLine()
                                .AppendLine($"IEnumerator<{itemTypeString}> IEnumerable<{itemTypeString}>.GetEnumerator() => source2.GetEnumerator();")
                                .AppendLine()
                                .AppendLine($"IEnumerator IEnumerable.GetEnumerator() => source2.GetEnumerator();");
                        }
                    }
                    else
                    {
                        // A custom enumerator wrapper is required

                        _ = builder
                            .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                            .AppendLine($"public Enumerator GetEnumerator() => new(source.GetEnumerator());")
                            .AppendLine()
                            .AppendLine($"IEnumerator<{itemTypeString}> IEnumerable<{itemTypeString}>.GetEnumerator() => new Enumerator(source.GetEnumerator());")
                            .AppendLine()
                            .AppendLine($"IEnumerator IEnumerable.GetEnumerator() => new Enumerator(source.GetEnumerator());")
                            .AppendLine();

                        using (builder.AppendBlock($"public struct Enumerator : IEnumerator<{itemTypeString}>"))
                        {
                            _ = builder
                                .AppendLine($"readonly {getEnumeratorReturnTypeString} source;")
                                .AppendLine()
                                .AppendLine($"internal Enumerator({getEnumeratorReturnTypeString} source)")
                                .AppendIndentation().AppendLine("=> this.source = source;")
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

                            _ = enumerableSymbols.EnumeratorSymbols.Dispose is null
                                ? builder
                                    .AppendLine()
                                    .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                                    .AppendLine("public void Dispose() { }")
                                : builder
                                    .AppendLine()
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
                            .AppendLine("public int Count => source2.Count;")
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
                                .AppendLine($"public bool Contains({itemTypeString} item) => source2.Contains(item);")
                                .AppendLine()
                                .AppendLine("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                                .AppendLine($"public void CopyTo({itemTypeString}[] array, int arrayIndex) => source2.CopyTo(array, arrayIndex);");
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
                                .AppendLine($"public {itemTypeString} this[int index] => source2[index];")
                                .AppendLine();

                            using (builder.AppendBlock($"{itemTypeString} IList<{itemTypeString}>.this[int index]"))
                            {
                                _ = builder
                                    .AppendLine("get => source2[index];")
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
                                    .AppendLine($"public int IndexOf({itemTypeString} item) => source2.IndexOf(item);");
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

                    // A new AsValueEnumerable() method has been generated
                    valueEnumerableType = new ValueEnumerableType(
                        Name: valueEnumerableTypeName,
                        EnumeratorType: enumeratorTypeString,
                        ItemType: itemTypeString,
                        IsCollection: enumerableImplementsICollection || enumerableImplementsIReadOnlyCollection,
                        IsList: enumerableImplementsIList || enumerableImplementsIReadOnlyList);
                    generatedMethods.Add(methodSignature, valueEnumerableType);
                    return valueEnumerableType;
                }
            }

            return null;
        }
    }
}