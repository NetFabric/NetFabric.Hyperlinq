using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public readonly partial struct RangeEnumerable
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.Dictionary<TKey, int> ToDictionary<TKey>(NetFabric.Hyperlinq.Selector<int, TKey> keySelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToDictionary<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int,TKey>(this,keySelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.Dictionary<TKey, TElement> ToDictionary<TKey,TElement>(NetFabric.Hyperlinq.Selector<int, TKey> keySelector,NetFabric.Hyperlinq.NullableSelector<int, TElement> elementSelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToDictionary<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int,TKey,TElement>(this,keySelector,elementSelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.List<TResult> ToList<TResult>(NetFabric.Hyperlinq.NullableSelector<int, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToList<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.List<TResult> ToList<TResult>(NetFabric.Hyperlinq.NullableSelectorAt<int, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToList<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<int> ElementAt(int index)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ElementAt<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int>(this,index);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> ElementAt<TResult>(int index,NetFabric.Hyperlinq.NullableSelectorAt<int, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ElementAt<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int,TResult>(this,index,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<int> First()
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First<TResult>(NetFabric.Hyperlinq.NullableSelector<int, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First<TResult>(NetFabric.Hyperlinq.NullableSelectorAt<int, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<int> Single()
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> Single<TResult>(NetFabric.Hyperlinq.NullableSelector<int, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> Single<TResult>(NetFabric.Hyperlinq.NullableSelectorAt<int, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectAtEnumerable<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int,TResult> Select<TResult>(NetFabric.Hyperlinq.NullableSelectorAt<int, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Select<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int,TResult> Select<TResult>(NetFabric.Hyperlinq.NullableSelector<int, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Select<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(System.Predicate<int> predicate)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.All<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(NetFabric.Hyperlinq.PredicateAt<int> predicate)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.All<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any(System.Predicate<int> predicate)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Any<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any(NetFabric.Hyperlinq.PredicateAt<int> predicate)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Any<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.AsyncValueEnumerableWrapper<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int> AsAsyncValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsAsyncValueEnumerable<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable AsEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsEnumerable<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable AsValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsValueEnumerable<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereAtEnumerable<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int> Where(NetFabric.Hyperlinq.PredicateAt<int> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int> Where(System.Predicate<int> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectManyEnumerable<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int,TSubEnumerable,TSubEnumerator,TResult> SelectMany<TSubEnumerable,TResult,TSubEnumerator>(NetFabric.Hyperlinq.Selector<int, TSubEnumerable> selector)
            where TSubEnumerable : NetFabric.Hyperlinq.IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct,System.Collections.Generic.IEnumerator<TResult>
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectMany<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int,TSubEnumerable,TSubEnumerator,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int> Distinct(System.Collections.Generic.IEqualityComparer<int>? comparer = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Distinct<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int>(this,comparer);

        }

        [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
        [DebuggerNonUserCode]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count(this NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable source)
        => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Count<NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable,NetFabric.Hyperlinq.ValueEnumerable.RangeEnumerable.DisposableEnumerator,int>(source);

    }
}
