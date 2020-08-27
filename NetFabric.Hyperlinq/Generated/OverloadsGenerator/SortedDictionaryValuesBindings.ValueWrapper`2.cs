using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class SortedDictionaryValuesBindings
    {
        public readonly partial struct ValueWrapper<TKey,TValue>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TValue[] ToArray()
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToArray<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Buffers.IMemoryOwner<TValue> ToArray<TSource>(System.Buffers.MemoryPool<TValue> pool)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToArray<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue>(this,pool);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.Dictionary<TKey, TValue> ToDictionary<TSource>(NetFabric.Hyperlinq.Selector<TValue, TKey> keySelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToDictionary<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue,TKey>(this,keySelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.Dictionary<TKey, TElement> ToDictionary<TSource,TElement>(NetFabric.Hyperlinq.Selector<TValue, TKey> keySelector,NetFabric.Hyperlinq.NullableSelector<TValue, TElement> elementSelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToDictionary<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue,TKey,TElement>(this,keySelector,elementSelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.List<TValue> ToList()
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToList<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.List<TResult> ToList<TSource,TResult>(NetFabric.Hyperlinq.NullableSelector<TValue, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToList<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.List<TResult> ToList<TSource,TResult>(NetFabric.Hyperlinq.NullableSelectorAt<TValue, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToList<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TValue> ElementAt(int index)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ElementAt<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue>(this,index);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> ElementAt<TSource,TResult>(int index,NetFabric.Hyperlinq.NullableSelectorAt<TValue, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ElementAt<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue,TResult>(this,index,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TValue> First()
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First<TSource,TResult>(NetFabric.Hyperlinq.NullableSelector<TValue, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First<TSource,TResult>(NetFabric.Hyperlinq.NullableSelectorAt<TValue, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TValue> Single()
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> Single<TSource,TResult>(NetFabric.Hyperlinq.NullableSelector<TValue, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> Single<TSource,TResult>(NetFabric.Hyperlinq.NullableSelectorAt<TValue, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue> Skip(int count)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Skip<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue> Take(int count)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Take<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectAtEnumerable<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue,TResult> Select<TSource,TResult>(NetFabric.Hyperlinq.NullableSelectorAt<TValue, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Select<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue,TResult> Select<TSource,TResult>(NetFabric.Hyperlinq.NullableSelector<TValue, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Select<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All<TSource>(System.Predicate<TValue> predicate)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.All<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All<TSource>(NetFabric.Hyperlinq.PredicateAt<TValue> predicate)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.All<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any()
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Any<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any<TSource>(System.Predicate<TValue> predicate)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Any<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any<TSource>(NetFabric.Hyperlinq.PredicateAt<TValue> predicate)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Any<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TValue value)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Contains<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue>(this,value);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains<TSource>(TValue value,System.Collections.Generic.IEqualityComparer<TValue>? comparer = default)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Contains<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue>(this,value,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.AsyncValueEnumerableWrapper<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue> AsAsyncValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsAsyncValueEnumerable<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue> AsEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsEnumerable<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue> AsValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsValueEnumerable<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereAtEnumerable<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue> Where<TSource>(NetFabric.Hyperlinq.PredicateAt<TValue> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue> Where<TSource>(System.Predicate<TValue> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectManyEnumerable<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue,TSubEnumerable,TSubEnumerator,TResult> SelectMany<TSource,TSubEnumerable,TResult,TSubEnumerator>(NetFabric.Hyperlinq.Selector<TValue, TSubEnumerable> selector)
            where TSubEnumerable : NetFabric.Hyperlinq.IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct,System.Collections.Generic.IEnumerator<TResult>
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectMany<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue,TSubEnumerable,TSubEnumerator,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue> Distinct<TSource>(System.Collections.Generic.IEqualityComparer<TValue>? comparer = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Distinct<NetFabric.Hyperlinq.SortedDictionaryValuesBindings.ValueWrapper<TKey, TValue>,System.Collections.Generic.SortedDictionary<TKey, TValue>.ValueCollection.Enumerator,TValue>(this,comparer);

        }

    }
}
