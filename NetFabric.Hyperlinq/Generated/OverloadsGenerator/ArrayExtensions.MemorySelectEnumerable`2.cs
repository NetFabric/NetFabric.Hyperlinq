using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public readonly partial struct MemorySelectEnumerable<TSource,TResult>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.Dictionary<TKey, TResult> ToDictionary<TKey>(NetFabric.Hyperlinq.Selector<TResult, TKey> keySelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.ToDictionary<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,TResult,TKey>(this,keySelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.Dictionary<TKey, TElement> ToDictionary<TKey,TElement>(NetFabric.Hyperlinq.Selector<TResult, TKey> keySelector,NetFabric.Hyperlinq.NullableSelector<TResult, TElement> elementSelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.ToDictionary<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,TResult,TKey,TElement>(this,keySelector,elementSelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> ElementAt(int index,NetFabric.Hyperlinq.NullableSelectorAt<TResult, TResult> selector,int offset,int count)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.ElementAt<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,TResult,TResult>(this,index,selector,offset,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,TResult> Where(NetFabric.Hyperlinq.PredicateAt<TResult> predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Where<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,TResult> Where(System.Predicate<TResult> predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Where<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,TResult> Skip(int count)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Skip<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,TResult>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,TResult> Take(int count)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Take<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,TResult>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.SelectAtEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,TResult,TResult> Select(NetFabric.Hyperlinq.NullableSelectorAt<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Select<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.SelectManyEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,TResult,TSubEnumerable,TSubEnumerator,TResult> SelectMany<TSubEnumerable,TSubEnumerator>(NetFabric.Hyperlinq.Selector<TResult, TSubEnumerable> selector)
            where TSubEnumerable : NetFabric.Hyperlinq.IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct,System.Collections.Generic.IEnumerator<TResult>
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.SelectMany<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,TResult,TSubEnumerable,TSubEnumerator,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.SelectEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,TResult,TResult> Select(NetFabric.Hyperlinq.NullableSelector<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Select<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(System.Predicate<TResult> predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.All<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(NetFabric.Hyperlinq.PredicateAt<TResult> predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.All<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any(System.Predicate<TResult> predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Any<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any(NetFabric.Hyperlinq.PredicateAt<TResult> predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Any<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TResult value)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Contains<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,TResult>(this,value);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TResult value,System.Collections.Generic.IEqualityComparer<TResult>? comparer = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Contains<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,TResult>(this,value,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.DistinctEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,TResult> Distinct(System.Collections.Generic.IEqualityComparer<TResult>? comparer = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Distinct<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,TResult>(this,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.List<TResult> ToList(NetFabric.Hyperlinq.NullableSelector<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToList<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.List<TResult> ToList(NetFabric.Hyperlinq.NullableSelectorAt<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToList<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> ElementAt(int index,NetFabric.Hyperlinq.NullableSelectorAt<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ElementAt<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult,TResult>(this,index,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First(NetFabric.Hyperlinq.NullableSelector<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First(NetFabric.Hyperlinq.NullableSelectorAt<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> Single(NetFabric.Hyperlinq.NullableSelector<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> Single(NetFabric.Hyperlinq.NullableSelectorAt<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.AsyncValueEnumerableWrapper<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult> AsAsyncValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsAsyncValueEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult> AsEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult> AsValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsValueEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemorySelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult>(this);

        }

    }
}
