using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public readonly partial struct ArraySegmentDistinctEnumerable<TSource>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.AsyncValueEnumerableWrapper<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource> AsAsyncValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsAsyncValueEnumerable<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource> AsEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsEnumerable<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource> AsValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsValueEnumerable<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.Dictionary<TKey, TSource> ToDictionary<TKey>(NetFabric.Hyperlinq.Selector<TSource, TKey> keySelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.ToDictionary<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource,TKey>(this,keySelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.Dictionary<TKey, TElement> ToDictionary<TKey,TElement>(NetFabric.Hyperlinq.Selector<TSource, TKey> keySelector,NetFabric.Hyperlinq.NullableSelector<TSource, TElement> elementSelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.ToDictionary<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource,TKey,TElement>(this,keySelector,elementSelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TSource> ElementAt(int index)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.ElementAt<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource>(this,index);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> ElementAt<TResult>(int index,NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.ElementAt<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource,TResult>(this,index,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TSource> First()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.First<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First<TResult>(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.First<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First<TResult>(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.First<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TSource> Single()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Single<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereAtEnumerable<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource> Where(NetFabric.Hyperlinq.PredicateAt<TSource> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource> Where(System.Predicate<TSource> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource> Skip(int count)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Skip<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.TakeEnumerable<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource> Take(int count)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Take<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectAtEnumerable<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource,TResult> Select<TResult>(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Select<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectManyEnumerable<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource,TSubEnumerable,TSubEnumerator,TResult> SelectMany<TSubEnumerable,TResult,TSubEnumerator>(NetFabric.Hyperlinq.Selector<TSource, TSubEnumerable> selector)
            where TSubEnumerable : NetFabric.Hyperlinq.IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct,System.Collections.Generic.IEnumerator<TResult>
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectMany<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource,TSubEnumerable,TSubEnumerator,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource,TResult> Select<TResult>(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Select<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(System.Predicate<TSource> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.All<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(NetFabric.Hyperlinq.PredicateAt<TSource> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.All<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any(System.Predicate<TSource> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Any<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any(NetFabric.Hyperlinq.PredicateAt<TSource> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Any<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TSource value)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Contains<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource>(this,value);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TSource value,System.Collections.Generic.IEqualityComparer<TSource>? comparer = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Contains<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource>(this,value,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource> Distinct(System.Collections.Generic.IEqualityComparer<TSource>? comparer = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Distinct<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>,NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentDistinctEnumerable<TSource>.Enumerator,TSource>(this,comparer);

        }

    }
}
