using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        public readonly partial struct WhereEnumerable<TList,TSource,TPredicate> where TList : notnull,System.Collections.Generic.IReadOnlyList<TSource> where TPredicate : struct,NetFabric.Hyperlinq.IPredicate<TSource>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource,TPredicate> Where(TPredicate predicate = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.AsyncValueEnumerableWrapper<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource> AsAsyncValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsAsyncValueEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult?> ElementAt(int index,NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.ElementAt<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource,TResult>(this,index,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TSource value)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Contains<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource>(this,value);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TSource value,System.Collections.Generic.IEqualityComparer<TSource>? comparer = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Contains<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource>(this,value,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectManyEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource,TSubEnumerable,TSubEnumerator,TResult> SelectMany(NetFabric.Hyperlinq.Selector<TSource, TSubEnumerable> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectMany<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource,TSubEnumerable,TSubEnumerator,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource> Skip(int count)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Skip<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool AnyAt(TPredicate predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AnyAt<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(System.Predicate<TSource> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.All<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(TPredicate predicate = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.All<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(NetFabric.Hyperlinq.PredicateAt<TSource> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.All<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool AllAt(TPredicate predicate = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AllAt<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectAtEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource,TResult> Select(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Select<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.First<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.First<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate> AsEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereAtEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource,TPredicate> WhereAt(TPredicate predicate = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereAt<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource> Distinct(System.Collections.Generic.IEqualityComparer<TSource>? comparer = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Distinct<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource>(this,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate> AsValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsValueEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.TakeEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource> Take(int count)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Take<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.EnumerableExtensions.ValueEnumerableWrapper<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource> AsValueEnumerable(System.Func<TEnumerable, TEnumerator> getEnumerator)
            => NetFabric.Hyperlinq.EnumerableExtensions.AsValueEnumerable<NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>,NetFabric.Hyperlinq.ReadOnlyListExtensions.WhereEnumerable<TList, TSource, TPredicate>.DisposableEnumerator,TSource>(this,getEnumerator);

        }

    }
}
