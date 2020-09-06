using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        public readonly partial struct WhereSelecEnumerable<TList,TSource,TResult,TPredicate> where TList : notnull,System.Collections.Generic.IReadOnlyList<TSource> where TPredicate : struct,NetFabric.Hyperlinq.IPredicate<TSource>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource,NetFabric.Hyperlinq.ValuePredicate<TSource>> Where(System.Predicate<TSource> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource,TPredicate> Where(TPredicate predicate = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.Dictionary<TKey, TSource> ToDictionary(NetFabric.Hyperlinq.Selector<TSource, TKey> keySelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.ToDictionary<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource,TKey>(this,keySelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.Dictionary<TKey, TElement> ToDictionary(NetFabric.Hyperlinq.Selector<TSource, TKey> keySelector,NetFabric.Hyperlinq.NullableSelector<TSource, TElement> elementSelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.ToDictionary<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource,TKey,TElement>(this,keySelector,elementSelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.AsyncValueEnumerableWrapper<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource> AsAsyncValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsAsyncValueEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult?> ElementAt(int index,NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.ElementAt<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource,TResult>(this,index,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TSource value)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Contains<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource>(this,value);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TSource value,System.Collections.Generic.IEqualityComparer<TSource>? comparer = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Contains<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource>(this,value,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectManyEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource,TSubEnumerable,TSubEnumerator,TResult> SelectMany(NetFabric.Hyperlinq.Selector<TSource, TSubEnumerable> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectMany<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource,TSubEnumerable,TSubEnumerator,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource> Skip(int count)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Skip<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Buffers.IMemoryOwner<TSource> ToArray(System.Buffers.MemoryPool<TSource> pool)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.ToArray<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource>(this,pool);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool AnyAt(TPredicate predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AnyAt<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(System.Predicate<TSource> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.All<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(TPredicate predicate = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.All<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(NetFabric.Hyperlinq.PredicateAt<TSource> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.All<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool AllAt(TPredicate predicate = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AllAt<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectAtEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource,TResult> Select(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Select<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.First<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.First<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate> AsEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereAtEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource,NetFabric.Hyperlinq.ValuePredicateAt<TSource>> Where(NetFabric.Hyperlinq.PredicateAt<TSource> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereAtEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource,TPredicate> WhereAt(TPredicate predicate = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereAt<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource> Distinct(System.Collections.Generic.IEqualityComparer<TSource>? comparer = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Distinct<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource>(this,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate> AsValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsValueEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.TakeEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource> Take(int count)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Take<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource,TResult> Select(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Select<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.EnumerableExtensions.ValueEnumerableWrapper<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource> AsValueEnumerable(System.Func<TEnumerable, TEnumerator> getEnumerator)
            => NetFabric.Hyperlinq.EnumerableExtensions.AsValueEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereSelecEnumerable<TList, TSource, TResult, TPredicate>.DisposableEnumerator,TSource>(this,getEnumerator);

        }

    }
}
