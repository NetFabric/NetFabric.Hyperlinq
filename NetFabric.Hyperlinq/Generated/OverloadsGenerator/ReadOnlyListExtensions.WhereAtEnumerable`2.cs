using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        public readonly partial struct WhereAtEnumerable<TList,TSource> where TList : notnull,System.Collections.Generic.IReadOnlyList<TSource>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.AsyncValueEnumerableWrapper<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>.DisposableEnumerator,TSource> AsAsyncValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsAsyncValueEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>.DisposableEnumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource> AsEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>.DisposableEnumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource> AsValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsValueEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>.DisposableEnumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> ElementAt<TResult>(int index,NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.ElementAt<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>.DisposableEnumerator,TSource,TResult>(this,index,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First<TResult>(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.First<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First<TResult>(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.First<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>.DisposableEnumerator,TSource> Skip(int count)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Skip<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>.DisposableEnumerator,TSource>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.TakeEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>.DisposableEnumerator,TSource> Take(int count)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Take<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>.DisposableEnumerator,TSource>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectAtEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>.DisposableEnumerator,TSource,TResult> Select<TResult>(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Select<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectManyEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>.DisposableEnumerator,TSource,TSubEnumerable,TSubEnumerator,TResult> SelectMany<TSubEnumerable,TResult,TSubEnumerator>(NetFabric.Hyperlinq.Selector<TSource, TSubEnumerable> selector)
            where TSubEnumerable : NetFabric.Hyperlinq.IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct,System.Collections.Generic.IEnumerator<TResult>
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectMany<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>.DisposableEnumerator,TSource,TSubEnumerable,TSubEnumerator,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>.DisposableEnumerator,TSource,TResult> Select<TResult>(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Select<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(System.Predicate<TSource> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.All<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>.DisposableEnumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(NetFabric.Hyperlinq.PredicateAt<TSource> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.All<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>.DisposableEnumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any(System.Predicate<TSource> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Any<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>.DisposableEnumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any(NetFabric.Hyperlinq.PredicateAt<TSource> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Any<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>.DisposableEnumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TSource value)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Contains<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>.DisposableEnumerator,TSource>(this,value);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TSource value,System.Collections.Generic.IEqualityComparer<TSource>? comparer = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Contains<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>.DisposableEnumerator,TSource>(this,value,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>.DisposableEnumerator,TSource> Distinct(System.Collections.Generic.IEqualityComparer<TSource>? comparer = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Distinct<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<TList, TSource>.DisposableEnumerator,TSource>(this,comparer);

        }

    }
}
