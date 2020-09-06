using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        public readonly partial struct ValueEnumerableWrapper<TSource>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource> Take(int count)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Take<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TSource value)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Contains<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource>(this,value);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TSource value,System.Collections.Generic.IEqualityComparer<TSource>? comparer = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Contains<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource>(this,value,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.SelectEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource,TResult> Select(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Select<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource,NetFabric.Hyperlinq.ValuePredicateAt<TSource>> Where(NetFabric.Hyperlinq.PredicateAt<TSource> predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Where<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAtEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource,TPredicate> WhereAt(TPredicate predicate = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereAt<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.SelectAtEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource,TResult> Select(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Select<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TSource> ElementAt(int index)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.ElementAt<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource>(this,index);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult?> ElementAt(int index,NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector,int offset,int count)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.ElementAt<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource,TResult>(this,index,selector,offset,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.SelectManyEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource,TSubEnumerable,TSubEnumerator,TResult> SelectMany(NetFabric.Hyperlinq.Selector<TSource, TSubEnumerable> selector)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.SelectMany<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource,TSubEnumerable,TSubEnumerator,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any()
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Any<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TSource> Single()
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Single<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource,NetFabric.Hyperlinq.ValuePredicate<TSource>> Where(System.Predicate<TSource> predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Where<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource,TPredicate> Where(TPredicate predicate = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Where<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TSource> First()
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.First<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.SkipTakeEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource> Skip(int count)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Skip<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.Dictionary<TKey, TSource> ToDictionary(NetFabric.Hyperlinq.Selector<TSource, TKey> keySelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.ToDictionary<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource,TKey>(this,keySelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.Dictionary<TKey, TElement> ToDictionary(NetFabric.Hyperlinq.Selector<TSource, TKey> keySelector,NetFabric.Hyperlinq.NullableSelector<TSource, TElement> elementSelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.ToDictionary<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource,TKey,TElement>(this,keySelector,elementSelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.DistinctEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource> Distinct(System.Collections.Generic.IEqualityComparer<TSource>? comparer = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.Distinct<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource>(this,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(System.Predicate<TSource> predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.All<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(TPredicate predicate = default)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.All<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(NetFabric.Hyperlinq.PredicateAt<TSource> predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.All<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool AllAt(TPredicate predicate)
            => NetFabric.Hyperlinq.ReadOnlyListExtensions.AllAt<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult?> First(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>.Enumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult?> First(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>.Enumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> Single(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>.Enumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> Single(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>.Enumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult?> ElementAt(int index,NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ElementAt<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>.Enumerator,TSource,TResult>(this,index,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.List<TResult> ToList(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToList<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>.Enumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.List<TResult> ToList(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToList<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>.Enumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyCollectionExtensions.ValueEnumerableWrapper<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>.Enumerator,TSource> AsValueEnumerable(System.Func<TEnumerable, TEnumerator> getEnumerator)
            => NetFabric.Hyperlinq.ReadOnlyCollectionExtensions.AsValueEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>.Enumerator,TSource>(this,getEnumerator);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.AsyncValueEnumerableWrapper<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>.Enumerator,TSource> AsAsyncValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsAsyncValueEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>.Enumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool AnyAt(TPredicate predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AnyAt<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>.Enumerator,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource> AsEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>.Enumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource> AsValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsValueEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>,NetFabric.Hyperlinq.ReadOnlyListExtensions.ValueEnumerableWrapper<TSource>.Enumerator,TSource>(this);

        }

    }
}
