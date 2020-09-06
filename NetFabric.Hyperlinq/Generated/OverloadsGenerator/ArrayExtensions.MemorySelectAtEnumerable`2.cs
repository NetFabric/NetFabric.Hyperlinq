using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public readonly partial struct MemorySelectAtEnumerable<TSource,TResult>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource> Take(int count)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Take<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TSource value)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Contains<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource>(this,value);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TSource value,System.Collections.Generic.IEqualityComparer<TSource>? comparer = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Contains<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource>(this,value,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.SelectEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource,TResult> Select(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Select<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource,NetFabric.Hyperlinq.ValuePredicateAt<TSource>> Where(NetFabric.Hyperlinq.PredicateAt<TSource> predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Where<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource,TPredicate> WhereAt(TPredicate predicate = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAt<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.SelectAtEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource,TResult> Select(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Select<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Buffers.IMemoryOwner<TSource> ToArray(System.Buffers.MemoryPool<TSource> pool)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.ToArray<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource>(this,pool);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult?> ElementAt(int index,NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector,int offset,int count)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.ElementAt<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource,TResult>(this,index,selector,offset,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.SelectManyEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource,TSubEnumerable,TSubEnumerator,TResult> SelectMany(NetFabric.Hyperlinq.Selector<TSource, TSubEnumerable> selector)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.SelectMany<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource,TSubEnumerable,TSubEnumerator,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource,NetFabric.Hyperlinq.ValuePredicate<TSource>> Where(System.Predicate<TSource> predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Where<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource,TPredicate> Where(TPredicate predicate = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Where<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource> Skip(int count)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Skip<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.Dictionary<TKey, TSource> ToDictionary(NetFabric.Hyperlinq.Selector<TSource, TKey> keySelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.ToDictionary<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource,TKey>(this,keySelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.Dictionary<TKey, TElement> ToDictionary(NetFabric.Hyperlinq.Selector<TSource, TKey> keySelector,NetFabric.Hyperlinq.NullableSelector<TSource, TElement> elementSelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.ToDictionary<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource,TKey,TElement>(this,keySelector,elementSelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.DistinctEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource> Distinct(System.Collections.Generic.IEqualityComparer<TSource>? comparer = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Distinct<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource>(this,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(System.Predicate<TSource> predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.All<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(TPredicate predicate = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.All<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(NetFabric.Hyperlinq.PredicateAt<TSource> predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.All<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool AllAt(TPredicate predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.AllAt<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult?> First(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult?> First(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> Single(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> Single(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult?> ElementAt(int index,NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ElementAt<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>.DisposableEnumerator,TSource,TResult>(this,index,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.List<TResult> ToList(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToList<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.List<TResult> ToList(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToList<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyCollectionExtensions.ValueEnumerableWrapper<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>.DisposableEnumerator,TSource> AsValueEnumerable(System.Func<TEnumerable, TEnumerator> getEnumerator)
            => NetFabric.Hyperlinq.ReadOnlyCollectionExtensions.AsValueEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>.DisposableEnumerator,TSource>(this,getEnumerator);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.AsyncValueEnumerableWrapper<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>.DisposableEnumerator,TSource> AsAsyncValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsAsyncValueEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>.DisposableEnumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool AnyAt(TPredicate predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AnyAt<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>.DisposableEnumerator,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult> AsEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>.DisposableEnumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult> AsValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsValueEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult>.DisposableEnumerator,TSource>(this);

        }

    }
}
