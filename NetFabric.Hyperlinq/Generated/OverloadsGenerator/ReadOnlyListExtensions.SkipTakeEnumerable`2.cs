using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        public readonly partial struct SkipTakeEnumerable<TList,TSource> where TList : notnull,System.Collections.Generic.IReadOnlyList<TSource>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TSource value)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Contains<NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>,TSource>(this,value);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult?> ElementAt(int index,NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector,int offset,int count)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.ElementAt<NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>,TSource,TResult>(this,index,selector,offset,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.SelectManyEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>,TSource,TSubEnumerable,TSubEnumerator,TResult> SelectMany(NetFabric.Hyperlinq.Selector<TSource, TSubEnumerable> selector)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.SelectMany<NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>,TSource,TSubEnumerable,TSubEnumerator,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.DistinctEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>,TSource> Distinct(System.Collections.Generic.IEqualityComparer<TSource>? comparer = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Distinct<NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>,TSource>(this,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult?> First(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult?> First(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> Single(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> Single(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult?> ElementAt(int index,NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ElementAt<NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>.DisposableEnumerator,TSource,TResult>(this,index,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.List<TResult> ToList(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToList<NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.List<TResult> ToList(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToList<NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyCollectionExtensions.ValueEnumerableWrapper<NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>.DisposableEnumerator,TSource> AsValueEnumerable(System.Func<TEnumerable, TEnumerator> getEnumerator)
            => NetFabric.Hyperlinq.ReadOnlyCollectionExtensions.AsValueEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>.DisposableEnumerator,TSource>(this,getEnumerator);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.AsyncValueEnumerableWrapper<NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>.DisposableEnumerator,TSource> AsAsyncValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsAsyncValueEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>.DisposableEnumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool AnyAt(TPredicate predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AnyAt<NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>.DisposableEnumerator,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource> AsEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>.DisposableEnumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource> AsValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsValueEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<TList, TSource>.DisposableEnumerator,TSource>(this);

        }

    }
}
