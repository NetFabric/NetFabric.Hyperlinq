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
                    .Line()
                    .GeneratedCodeMethodAttributes()
                    .AggressiveInliningAttribute()
                    .Line($"public static {valueEnumerableType.Name} AsValueEnumerable(this {valueEnumerableType.Name} source)")
                    .Indent().Line($"=> source;");

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
                var enumerableIsIEnumerable = receiverTypeSymbol.ImplementsInterface(SpecialType.System_Collections_Generic_IEnumerable_T, out _);
                var enumerableIsICollection = false;
                var enumerableIsIReadOnlyCollection = false;
                var enumerableIsIList = false;
                var enumerableIsIReadOnlyList = false;
                if (enumerableIsIEnumerable)
                {
                    enumerableIsICollection = receiverTypeSymbol.ImplementsInterface(SpecialType.System_Collections_Generic_ICollection_T, out _);
                    if (enumerableIsICollection)
                        enumerableIsIList = receiverTypeSymbol.ImplementsInterface(SpecialType.System_Collections_Generic_IList_T, out _);

                    enumerableIsIReadOnlyCollection = receiverTypeSymbol.ImplementsInterface(SpecialType.System_Collections_Generic_IReadOnlyCollection_T, out _);
                    if (enumerableIsIReadOnlyCollection)
                        enumerableIsIReadOnlyList = receiverTypeSymbol.ImplementsInterface(SpecialType.System_Collections_Generic_IReadOnlyList_T, out _);
                }

                // Define what value enumerator type will be used
                var enumeratorIsIEnumerator = getEnumeratorReturnType.ImplementsInterface(SpecialType.System_Collections_Generic_IEnumerator_T, out _);

                var enumeratorTypeString = enumeratorIsIEnumerator
                    ? getEnumeratorReturnType.IsValueType
                        ? getEnumeratorReturnTypeString
                        : $"ValueEnumerator<{itemTypeString}>"
                    : $"{enumerableTypeString}.Enumerator";

                // Generate the method
                _ = builder
                        .Line()
                        .GeneratedCodeMethodAttributes()
                        .AggressiveInliningAttribute()
                        .Line($"public static {enumerableTypeString} AsValueEnumerable(this {receiverTypeString} source)")
                        .Indent().Line($"=> new(source);");

                // Generate the value enumerable wrapper
                _ = builder
                        .Line()
                        .Line($"public readonly struct {enumerableTypeString}");

                // Define what interfaces the wrapper implements
                if (enumerableIsIList || enumerableIsIReadOnlyList)
                    _ = builder.Indent().Line($": IValueReadOnlyList<{itemTypeString}, {enumeratorTypeString}>, IList<{itemTypeString}>");
                else if (enumerableIsICollection || enumerableIsIReadOnlyCollection)
                    _ = builder.Indent().Line($": IValueReadOnlyCollection<{itemTypeString}, {enumeratorTypeString}>, ICollection<{itemTypeString}>");
                else
                    _ = builder.Indent().Line($": IValueEnumerable<{itemTypeString}, {enumeratorTypeString}>");

                using (builder.Block())
                {
                    // Define field and constructor
                    _ = builder
                            .Line($"readonly {receiverTypeString} source;")
                            .Line()
                            .Line($"internal {enumerableTypeString}({receiverTypeString} source)")
                            .Indent().Line($"=> this.source = source;");

                    // Implement interfaces
                    ImplementIValueEnumerable(builder, enumerableSymbols, enumeratorTypeString, itemTypeString, enumeratorIsIEnumerator);
                    if (enumerableIsICollection || enumerableIsIReadOnlyCollection)
                    {
                        var sourceIsReferenceType = receiverTypeSymbol.IsReferenceType;
                        var itemIsReferenceType = itemType.IsReferenceType;
                        ImplementICollection(builder, itemTypeString, sourceIsReferenceType, itemIsReferenceType, enumerableIsICollection);

                        if (enumerableIsIList || enumerableIsIReadOnlyList)
                            ImplementIList(builder, itemTypeString, sourceIsReferenceType, itemIsReferenceType, enumerableIsIList);
                    }

                    // A new AsValueEnumerable() method has been generated
                    valueEnumerableType = new ValueEnumerableType(
                        Name: enumerableTypeString,
                        EnumeratorType: enumeratorTypeString,
                        ItemType: itemTypeString,
                        IsCollection: enumerableIsICollection || enumerableIsIReadOnlyCollection,
                        IsList: enumerableIsIList || enumerableIsIReadOnlyList);
                    generatedMethods.Add(methodSignature, valueEnumerableType);
                    return valueEnumerableType;
                }
            }

            return null;
        }

        static void ImplementIValueEnumerable(CodeBuilder builder, EnumerableSymbols enumerableSymbols, string enumeratorTypeString, string itemTypeString, bool enumeratorIsIEnumerator)
        {
            var getEnumeratorReturnType = enumerableSymbols.GetEnumerator.ReturnType;
            var getEnumeratorReturnTypeString = getEnumeratorReturnType.ToDisplayString();

            _ = builder
                .Line()
                .Line($"// Implement IValueEnumerable<{itemTypeString}, {enumeratorTypeString}>")
                .Line();

            if (enumeratorIsIEnumerator)
            {
                if (getEnumeratorReturnType.IsValueType)
                {
                    // No enumerator wrapper required
                    _ = builder
                        .AggressiveInliningAttribute()
                        .Line($"public {enumeratorTypeString} GetEnumerator() => source.GetEnumerator();")
                        .Line()
                        .Line($"IEnumerator<{itemTypeString}> IEnumerable<{itemTypeString}>.GetEnumerator() => GetEnumerator();")
                        .Line()
                        .Line($"IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();");
                }
                else if (enumerableSymbols.GetEnumerator.ContainingType.IsInterface())
                {
                    // Use the ValueEnumerator<> enumerator wrapper
                    _ = builder
                        .AggressiveInliningAttribute()
                        .Line($"public ValueEnumerator<{itemTypeString}> GetEnumerator() => new(source.GetEnumerator());")
                        .Line()
                        .Line($"IEnumerator<{itemTypeString}> IEnumerable<{itemTypeString}>.GetEnumerator() => source.GetEnumerator();")
                        .Line()
                        .Line($"IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();");
                }
                else
                {
                    // Use the ValueEnumerator<> enumerator wrapper
                    _ = builder
                        .AggressiveInliningAttribute()
                        .Line($"public ValueEnumerator<{itemTypeString}> GetEnumerator() => new(source.GetEnumerator());")
                        .Line()
                        .Line($"IEnumerator<{itemTypeString}> IEnumerable<{itemTypeString}>.GetEnumerator() => source.GetEnumerator();")
                        .Line()
                        .Line($"IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();");
                }
            }
            else
            {
                // A custom enumerator wrapper is required

                _ = builder
                    .AggressiveInliningAttribute()
                    .Line($"public Enumerator GetEnumerator() => new(source.GetEnumerator());")
                    .Line()
                    .Line($"IEnumerator<{itemTypeString}> IEnumerable<{itemTypeString}>.GetEnumerator() => GetEnumerator();")
                    .Line()
                    .Line($"IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();")
                    .Line();

                // define a value type enumerator wrapper
                using (builder.Block($"public struct Enumerator : IEnumerator<{itemTypeString}>"))
                {
                    _ = builder
                        .Line($"readonly {getEnumeratorReturnTypeString} source;")
                        .Line()
                        .Line($"internal Enumerator({getEnumeratorReturnTypeString} source)")
                        .Indent().Line("=> this.source = source;")
                        .Line()
                        .Line($"public {itemTypeString} Current")
                        .Line("{")
                        .Indent().AggressiveInliningAttribute()
                        .Indent().Line($"get => source.Current;")
                        .Line("}")
                        .Line()
                        .Line("object? IEnumerator.Current => source.Current;")
                        .Line()
                        .AggressiveInliningAttribute()
                        .Line("public bool MoveNext() => source.MoveNext();")
                        .Line();

                    _ = enumerableSymbols.EnumeratorSymbols.Reset is null
                        ? builder
                            .Line("public void Reset() => throw new NotSupportedException();")
                        : builder
                            .AggressiveInliningAttribute()
                            .Line("public void Reset() => source.Reset();");

                    _ = enumerableSymbols.EnumeratorSymbols.Dispose is null
                        ? builder
                            .Line()
                            .AggressiveInliningAttribute()
                            .Line("public void Dispose() { }")
                        : builder
                            .Line()
                            .AggressiveInliningAttribute()
                            .Line("public void Dispose() => source.Dispose();");
                }
            }
        }

        static void ImplementICollection(CodeBuilder builder, string itemTypeString, bool sourceIsReferenceType, bool itemIsReferenceType, bool sourceIsICollection)
        {
            _ = builder
                .Line()
                .Line($"// Implement ICollection<{itemTypeString}>")
                .Line()
                .Line("public int Count => source.Count;")
                .Line()
                .Line("public bool IsReadOnly => true;")
                .Line()
                .Line($"void ICollection<{itemTypeString}>.Add({itemTypeString} item) => throw new NotSupportedException();")
                .Line()
                .Line($"bool ICollection<{itemTypeString}>.Remove({itemTypeString} item) => throw new NotSupportedException();")
                .Line()
                .Line($"void ICollection<{itemTypeString}>.Clear() => throw new NotSupportedException();");

            if (sourceIsICollection)
            {
                // Call the methods implemented by the source
                _ = builder
                    .Line()
                    .AggressiveInliningAttribute()
                    .Line($"public bool Contains({itemTypeString} item) => source.Contains(item);")
                    .Line()
                    .AggressiveInliningAttribute()
                    .Line($"public void CopyTo({itemTypeString}[] array, int arrayIndex) => source.CopyTo(array, arrayIndex);");

                return; // nothing else to do
            }

            // The source does not implement these methods so we have to add an implementation
            _ = builder
                .Line()
                .MethodBlock($"public bool Contains({itemTypeString} item)",
                    codeBuilder =>
                        {
                            _ = codeBuilder
                                .Line("if (Count is 0)")
                                .Indent().Line("return false;");

                            if (sourceIsReferenceType)
                            {
                                _ = codeBuilder
                                    .Line()
                                    .Line($"if (source is ICollection<{itemTypeString}> collection)")
                                    .Indent().Line("return collection.Contains(item);");
                            }

                            if (itemIsReferenceType) 
                            {
                                _ = codeBuilder
                                    .Line()
                                    .Line($"var comparer = EqualityComparer<{itemTypeString}>.Default;")
                                    .Line("using var enumerator = GetEnumerator();")
                                    .WhileBlock("enumerator.MoveNext()",
                                        codeBuilder => _ = codeBuilder
                                            .Line("if (comparer.Equals(enumerator.Current, item))")
                                            .Indent().Line("return true;")
                                    );
                            }
                            else // devirtualize the comparer
                            {
                                _ = codeBuilder
                                    .Line()
                                    .Line("using var enumerator = GetEnumerator();")
                                    .WhileBlock("enumerator.MoveNext()",
                                        codeBuilder => _ = codeBuilder
                                            .Line($"if (EqualityComparer<{itemTypeString}>.Default.Equals(enumerator.Current, item))")
                                            .Indent().Line("return true;")
                                    );
                            }

                            _ = codeBuilder
                                .Line("return false;");
                        });

            _ = builder
                .Line()
                .MethodBlock($"public void CopyTo({itemTypeString}[] array, int arrayIndex)",
                    codeBuilder =>
                    {
                        _ = codeBuilder
                            .Line("if (Count is 0)")
                            .Indent().Line("return;")
                            .Line()
                            .Line("if (array.Length - arrayIndex < Count)")
                            .Indent().Line($"throw new ArgumentException(\"{Resource.DestinationNotLongEnough}\", nameof(array));");

                        if (sourceIsReferenceType)
                        {
                            codeBuilder
                                .Line()
                                .IfBlock($"source is ICollection<{itemTypeString}> collection",
                                    codeBuilder => _ = codeBuilder
                                        .Line("collection.CopyTo(array, arrayIndex);")
                                        .Line("return;"));
                        }
                            
                        _ = codeBuilder
                            .Line()
                            .Line("using var enumerator = GetEnumerator();")
                            .IfBlock(
                                "arrayIndex is 0 && array.Length == Count", // to enable range check elimination
                                codeBuilder => _ = codeBuilder
                                    .Line(
                                        "for (var index = 0; index < array.Length && enumerator.MoveNext(); index++)")
                                    .Indent().Line("array[index] = enumerator.Current;"),
                                codeBuilder => _ = codeBuilder
                                    .CheckedBlock(
                                        codeBuilder => _ = codeBuilder
                                            .Line(
                                                "for (var index = arrayIndex; enumerator.MoveNext(); index++)")
                                            .Indent().Line("array[index] = enumerator.Current;")
                                    )
                            );
                    });
        }

        static void ImplementIList(CodeBuilder builder, string itemTypeString, bool sourceIsReferenceType, bool itemIsReferenceType, bool sourceIsIList)
        {
            _ = builder
                .Line()
                .Line($"// Implement IList<{itemTypeString}>")
                .Line()
                .Line($"public {itemTypeString} this[int index] => source[index];")
                .Line();

            using (builder.Block($"{itemTypeString} IList<{itemTypeString}>.this[int index]"))
            {
                _ = builder
                    .Line("get => source[index];")
                    .Line("set => throw new NotSupportedException();");
            }

            _ = builder
                .Line()
                .Line($"void IList<{itemTypeString}>.Insert(int index, {itemTypeString} item) => throw new NotSupportedException();")
                .Line()
                .Line($"void IList<{itemTypeString}>.RemoveAt(int index) => throw new NotSupportedException();")
                .Line();

            if (sourceIsIList)
            {
                // Call the methods implemented by the source
                _ = builder
                    .AggressiveInliningAttribute()
                    .Line($"public int IndexOf({itemTypeString} item) => source.IndexOf(item);");

                return;
            }

            // The source does not implement these methods so we have to add an implementation
            builder
                .MethodBlock($"public int IndexOf({itemTypeString} item)",
                    codeBuilder => codeBuilder
                        .IfBlock("Count is not 0",
                            codeBuilder =>
                            {
                                if (sourceIsReferenceType)
                                {
                                    codeBuilder
                                        .Line($"if (source is IList<{itemTypeString}> list)")
                                        .Indent().Line("return list.IndexOf(item);")
                                        .Line();
                                }

                                codeBuilder
                                    .CheckedBlock(
                                        codeBuilder =>
                                        {
                                            if (itemIsReferenceType) 
                                            {
                                                codeBuilder
                                                    .Line($"var comparer = EqualityComparer<{itemTypeString}>.Default;")
                                                    .Line("var index = 0;")
                                                    .ForEachBlock("var current in source",
                                                        codeBuilder => codeBuilder
                                                            .Line($"if (comparer.Equals(current, item))")
                                                            .Indent().Line("return index;")
                                                            .Line()
                                                            .Line("index++;")
                                                    );
                                            }
                                            else // devirtualize the comparer
                                            {
                                                codeBuilder
                                                    .Line("var index = 0;")
                                                    .ForEachBlock("var current in source",
                                                        codeBuilder => codeBuilder
                                                            .Line(
                                                                $"if (EqualityComparer<{itemTypeString}>.Default.Equals(current, item))")
                                                            .Indent().Line("return index;")
                                                            .Line()
                                                            .Line("index++;")
                                                    );
                                            }
                                        });
                            })
                        .Line("return -1;")
                );
        }

    }
}