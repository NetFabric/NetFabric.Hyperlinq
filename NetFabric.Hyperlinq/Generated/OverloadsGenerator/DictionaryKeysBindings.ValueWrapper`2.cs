using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class DictionaryKeysBindings
    {
        public readonly partial struct ValueWrapper<TKey,TValue>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TKey[] ToArray()
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToArray<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Buffers.IMemoryOwner<TKey> ToArray<TSource>(System.Buffers.MemoryPool<TKey> pool)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToArray<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey>(this,pool);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.Dictionary<TKey, TKey> ToDictionary<TSource>(NetFabric.Hyperlinq.Selector<TKey, TKey> keySelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToDictionary<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey,TKey>(this,keySelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.Dictionary<TKey, TElement> ToDictionary<TSource,TElement>(NetFabric.Hyperlinq.Selector<TKey, TKey> keySelector,NetFabric.Hyperlinq.NullableSelector<TKey, TElement> elementSelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToDictionary<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey,TKey,TElement>(this,keySelector,elementSelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.List<TKey> ToList()
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToList<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.List<TResult> ToList<TSource,TResult>(NetFabric.Hyperlinq.NullableSelector<TKey, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToList<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.List<TResult> ToList<TSource,TResult>(NetFabric.Hyperlinq.NullableSelectorAt<TKey, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToList<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TKey> ElementAt(int index)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ElementAt<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey>(this,index);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> ElementAt<TSource,TResult>(int index,NetFabric.Hyperlinq.NullableSelectorAt<TKey, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ElementAt<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey,TResult>(this,index,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TKey> First()
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First<TSource,TResult>(NetFabric.Hyperlinq.NullableSelector<TKey, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First<TSource,TResult>(NetFabric.Hyperlinq.NullableSelectorAt<TKey, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TKey> Single()
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> Single<TSource,TResult>(NetFabric.Hyperlinq.NullableSelector<TKey, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> Single<TSource,TResult>(NetFabric.Hyperlinq.NullableSelectorAt<TKey, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey> Skip(int count)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Skip<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey> Take(int count)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Take<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectAtEnumerable<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey,TResult> Select<TSource,TResult>(NetFabric.Hyperlinq.NullableSelectorAt<TKey, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Select<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey,TResult> Select<TSource,TResult>(NetFabric.Hyperlinq.NullableSelector<TKey, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Select<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All<TSource>(System.Predicate<TKey> predicate)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.All<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All<TSource>(NetFabric.Hyperlinq.PredicateAt<TKey> predicate)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.All<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any()
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Any<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any<TSource>(System.Predicate<TKey> predicate)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Any<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any<TSource>(NetFabric.Hyperlinq.PredicateAt<TKey> predicate)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Any<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TKey value)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Contains<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey>(this,value);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains<TSource>(TKey value,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Contains<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey>(this,value,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.AsyncValueEnumerableWrapper<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey> AsAsyncValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsAsyncValueEnumerable<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue> AsEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsEnumerable<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue> AsValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsValueEnumerable<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereAtEnumerable<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey> Where<TSource>(NetFabric.Hyperlinq.PredicateAt<TKey> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey> Where<TSource>(System.Predicate<TKey> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectManyEnumerable<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey,TSubEnumerable,TSubEnumerator,TResult> SelectMany<TSource,TSubEnumerable,TResult,TSubEnumerator>(NetFabric.Hyperlinq.Selector<TKey, TSubEnumerable> selector)
            where TSubEnumerable : NetFabric.Hyperlinq.IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct,System.Collections.Generic.IEnumerator<TResult>
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectMany<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey,TSubEnumerable,TSubEnumerator,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey> Distinct<TSource>(System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Distinct<NetFabric.Hyperlinq.DictionaryKeysBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.KeyCollection.Enumerator,TKey>(this,comparer);

        }

    }
}
