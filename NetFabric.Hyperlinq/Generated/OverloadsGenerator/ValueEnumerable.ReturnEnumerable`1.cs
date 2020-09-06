using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public readonly partial struct ReturnEnumerable<TSource>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,TSource> Take(int count)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Take<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,TSource>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,TSource,NetFabric.Hyperlinq.ValuePredicateAt<TSource>> Where(NetFabric.Hyperlinq.PredicateAt<TSource> predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Where<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,TSource,TPredicate> WhereAt(TPredicate predicate = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAt<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.SelectAtEnumerable<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,TSource,TResult> Select(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Select<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Buffers.IMemoryOwner<TSource> ToArray(System.Buffers.MemoryPool<TSource> pool)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.ToArray<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,TSource>(this,pool);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult?> ElementAt(int index,NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector,int offset,int count)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.ElementAt<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,TSource,TResult>(this,index,selector,offset,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.SelectManyEnumerable<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,TSource,TSubEnumerable,TSubEnumerator,TResult> SelectMany(NetFabric.Hyperlinq.Selector<TSource, TSubEnumerable> selector)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.SelectMany<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,TSource,TSubEnumerable,TSubEnumerator,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,TSource,NetFabric.Hyperlinq.ValuePredicate<TSource>> Where(System.Predicate<TSource> predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Where<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,TSource,TPredicate> Where(TPredicate predicate = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Where<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,TSource> Skip(int count)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Skip<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,TSource>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.DistinctEnumerable<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,TSource> Distinct(System.Collections.Generic.IEqualityComparer<TSource>? comparer = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Distinct<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,TSource>(this,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(System.Predicate<TSource> predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.All<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(TPredicate predicate = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.All<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(NetFabric.Hyperlinq.PredicateAt<TSource> predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.All<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool AllAt(TPredicate predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.AllAt<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult?> First(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult?> First(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> Single(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> Single(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult?> ElementAt(int index,NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ElementAt<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>.DisposableEnumerator,TSource,TResult>(this,index,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.List<TResult> ToList(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToList<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.List<TResult> ToList(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToList<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyCollectionExtensions.ValueEnumerableWrapper<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>.DisposableEnumerator,TSource> AsValueEnumerable(System.Func<TEnumerable, TEnumerator> getEnumerator)
            => NetFabric.Hyperlinq.ReadOnlyCollectionExtensions.AsValueEnumerable<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>.DisposableEnumerator,TSource>(this,getEnumerator);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.AsyncValueEnumerableWrapper<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>.DisposableEnumerator,TSource> AsAsyncValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsAsyncValueEnumerable<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>.DisposableEnumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool AnyAt(TPredicate predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AnyAt<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>.DisposableEnumerator,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource> AsEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsEnumerable<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>.DisposableEnumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource> AsValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsValueEnumerable<NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.ReturnEnumerable<TSource>.DisposableEnumerator,TSource>(this);

        }

    }
}
