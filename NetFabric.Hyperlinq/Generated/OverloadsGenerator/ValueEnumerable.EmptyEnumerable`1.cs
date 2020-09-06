using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public partial class EmptyEnumerable<TSource>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource> Take(int count)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Take<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  bool Contains(TSource value,System.Collections.Generic.IEqualityComparer<TSource>? comparer = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Contains<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource>(this,value,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  NetFabric.Hyperlinq.ReadOnlyListExtensions.SelectEnumerable<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource,TResult> Select(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Select<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource,NetFabric.Hyperlinq.ValuePredicateAt<TSource>> Where(NetFabric.Hyperlinq.PredicateAt<TSource> predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Where<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource,TPredicate> WhereAt(TPredicate predicate = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAt<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  NetFabric.Hyperlinq.ReadOnlyListExtensions.SelectAtEnumerable<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource,TResult> Select(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Select<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  TSource[] ToArray()
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.ToArray<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  System.Buffers.IMemoryOwner<TSource> ToArray(System.Buffers.MemoryPool<TSource> pool)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.ToArray<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource>(this,pool);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  NetFabric.Hyperlinq.Option<TSource> ElementAt(int index)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.ElementAt<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource>(this,index);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  NetFabric.Hyperlinq.Option<TResult?> ElementAt(int index,NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector,int offset,int count)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.ElementAt<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource,TResult>(this,index,selector,offset,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  NetFabric.Hyperlinq.ReadOnlyListExtensions.SelectManyEnumerable<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource,TSubEnumerable,TSubEnumerator,TResult> SelectMany(NetFabric.Hyperlinq.Selector<TSource, TSubEnumerable> selector)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.SelectMany<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource,TSubEnumerable,TSubEnumerator,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  bool Any()
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Any<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  NetFabric.Hyperlinq.Option<TSource> Single()
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Single<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  System.Collections.Generic.List<TSource> ToList()
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.ToList<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource,NetFabric.Hyperlinq.ValuePredicate<TSource>> Where(System.Predicate<TSource> predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Where<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource,TPredicate> Where(TPredicate predicate = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Where<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  NetFabric.Hyperlinq.Option<TSource> First()
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.First<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource> Skip(int count)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Skip<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  System.Collections.Generic.Dictionary<TKey, TSource> ToDictionary(NetFabric.Hyperlinq.Selector<TSource, TKey> keySelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.ToDictionary<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource,TKey>(this,keySelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  System.Collections.Generic.Dictionary<TKey, TElement> ToDictionary(NetFabric.Hyperlinq.Selector<TSource, TKey> keySelector,NetFabric.Hyperlinq.NullableSelector<TSource, TElement> elementSelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.ToDictionary<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource,TKey,TElement>(this,keySelector,elementSelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  NetFabric.Hyperlinq.ReadOnlyListExtensions.DistinctEnumerable<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource> Distinct(System.Collections.Generic.IEqualityComparer<TSource>? comparer = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Distinct<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource>(this,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  bool All(System.Predicate<TSource> predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.All<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  bool All(TPredicate predicate = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.All<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  bool All(NetFabric.Hyperlinq.PredicateAt<TSource> predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.All<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  bool AllAt(TPredicate predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.AllAt<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  NetFabric.Hyperlinq.Option<TResult?> First(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  NetFabric.Hyperlinq.Option<TResult?> First(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  NetFabric.Hyperlinq.Option<TResult> Single(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  NetFabric.Hyperlinq.Option<TResult> Single(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  NetFabric.Hyperlinq.Option<TResult?> ElementAt(int index,NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ElementAt<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>.DisposableEnumerator,TSource,TResult>(this,index,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  System.Collections.Generic.List<TResult> ToList(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToList<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  System.Collections.Generic.List<TResult> ToList(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToList<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  NetFabric.Hyperlinq.ReadOnlyCollectionExtensions.ValueEnumerableWrapper<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>.DisposableEnumerator,TSource> AsValueEnumerable(System.Func<TEnumerable, TEnumerator> getEnumerator)
            => NetFabric.Hyperlinq.ReadOnlyCollectionExtensions.AsValueEnumerable<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>.DisposableEnumerator,TSource>(this,getEnumerator);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  NetFabric.Hyperlinq.ValueEnumerableExtensions.AsyncValueEnumerableWrapper<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>.DisposableEnumerator,TSource> AsAsyncValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsAsyncValueEnumerable<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>.DisposableEnumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  bool AnyAt(TPredicate predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AnyAt<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>.DisposableEnumerator,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource> AsEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsEnumerable<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>.DisposableEnumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public  NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource> AsValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsValueEnumerable<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>.DisposableEnumerator,TSource>(this);

        }

        [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
        [DebuggerNonUserCode]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource> source)
        => NetFabric.Hyperlinq.ReadOnlyListExtensions.Count<NetFabric.Hyperlinq.ValueEnumerable.EmptyEnumerable<TSource>,TSource>(source);

    }
}
