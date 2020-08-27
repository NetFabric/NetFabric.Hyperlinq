using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class DictionaryBindings
    {
        public readonly partial struct ValueWrapper<TKey,TValue>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.KeyValuePair<TKey, TValue>[] ToArray()
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToArray<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Buffers.IMemoryOwner<System.Collections.Generic.KeyValuePair<TKey, TValue>> ToArray(System.Buffers.MemoryPool<System.Collections.Generic.KeyValuePair<TKey, TValue>> pool)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToArray<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>>(this,pool);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.Dictionary<TKey, System.Collections.Generic.KeyValuePair<TKey, TValue>> ToDictionary(NetFabric.Hyperlinq.Selector<System.Collections.Generic.KeyValuePair<TKey, TValue>, TKey> keySelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToDictionary<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>,TKey>(this,keySelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.Dictionary<TKey, TElement> ToDictionary<TElement>(NetFabric.Hyperlinq.Selector<System.Collections.Generic.KeyValuePair<TKey, TValue>, TKey> keySelector,NetFabric.Hyperlinq.NullableSelector<System.Collections.Generic.KeyValuePair<TKey, TValue>, TElement> elementSelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToDictionary<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>,TKey,TElement>(this,keySelector,elementSelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<TKey, TValue>> ToList()
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToList<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.List<TResult> ToList<TResult>(NetFabric.Hyperlinq.NullableSelector<System.Collections.Generic.KeyValuePair<TKey, TValue>, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToList<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.List<TResult> ToList<TResult>(NetFabric.Hyperlinq.NullableSelectorAt<System.Collections.Generic.KeyValuePair<TKey, TValue>, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToList<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<System.Collections.Generic.KeyValuePair<TKey, TValue>> ElementAt(int index)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ElementAt<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>>(this,index);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> ElementAt<TResult>(int index,NetFabric.Hyperlinq.NullableSelectorAt<System.Collections.Generic.KeyValuePair<TKey, TValue>, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ElementAt<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>,TResult>(this,index,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<System.Collections.Generic.KeyValuePair<TKey, TValue>> First()
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First<TResult>(NetFabric.Hyperlinq.NullableSelector<System.Collections.Generic.KeyValuePair<TKey, TValue>, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First<TResult>(NetFabric.Hyperlinq.NullableSelectorAt<System.Collections.Generic.KeyValuePair<TKey, TValue>, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<System.Collections.Generic.KeyValuePair<TKey, TValue>> Single()
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> Single<TResult>(NetFabric.Hyperlinq.NullableSelector<System.Collections.Generic.KeyValuePair<TKey, TValue>, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> Single<TResult>(NetFabric.Hyperlinq.NullableSelectorAt<System.Collections.Generic.KeyValuePair<TKey, TValue>, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>> Skip(int count)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Skip<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>> Take(int count)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Take<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectAtEnumerable<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>,TResult> Select<TResult>(NetFabric.Hyperlinq.NullableSelectorAt<System.Collections.Generic.KeyValuePair<TKey, TValue>, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Select<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>,TResult> Select<TResult>(NetFabric.Hyperlinq.NullableSelector<System.Collections.Generic.KeyValuePair<TKey, TValue>, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Select<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(System.Predicate<System.Collections.Generic.KeyValuePair<TKey, TValue>> predicate)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.All<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(NetFabric.Hyperlinq.PredicateAt<System.Collections.Generic.KeyValuePair<TKey, TValue>> predicate)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.All<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any()
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Any<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any(System.Predicate<System.Collections.Generic.KeyValuePair<TKey, TValue>> predicate)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Any<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any(NetFabric.Hyperlinq.PredicateAt<System.Collections.Generic.KeyValuePair<TKey, TValue>> predicate)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Any<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(System.Collections.Generic.KeyValuePair<TKey, TValue> value)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Contains<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>>(this,value);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(System.Collections.Generic.KeyValuePair<TKey, TValue> value,System.Collections.Generic.IEqualityComparer<System.Collections.Generic.KeyValuePair<TKey, TValue>>? comparer = default)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Contains<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>>(this,value,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.AsyncValueEnumerableWrapper<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>> AsAsyncValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsAsyncValueEnumerable<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue> AsEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsEnumerable<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue> AsValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsValueEnumerable<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereAtEnumerable<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>> Where(NetFabric.Hyperlinq.PredicateAt<System.Collections.Generic.KeyValuePair<TKey, TValue>> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>> Where(System.Predicate<System.Collections.Generic.KeyValuePair<TKey, TValue>> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectManyEnumerable<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>,TSubEnumerable,TSubEnumerator,TResult> SelectMany<TSubEnumerable,TResult,TSubEnumerator>(NetFabric.Hyperlinq.Selector<System.Collections.Generic.KeyValuePair<TKey, TValue>, TSubEnumerable> selector)
            where TSubEnumerable : NetFabric.Hyperlinq.IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct,System.Collections.Generic.IEnumerator<TResult>
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectMany<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>,TSubEnumerable,TSubEnumerator,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>> Distinct(System.Collections.Generic.IEqualityComparer<System.Collections.Generic.KeyValuePair<TKey, TValue>>? comparer = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Distinct<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator,System.Collections.Generic.KeyValuePair<TKey, TValue>>(this,comparer);

        }

    }
}
