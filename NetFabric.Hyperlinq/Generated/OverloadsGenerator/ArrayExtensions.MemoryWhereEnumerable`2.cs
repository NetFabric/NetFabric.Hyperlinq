using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public readonly partial struct MemoryWhereEnumerable<TSource,TPredicate> where TPredicate : struct,NetFabric.Hyperlinq.IPredicate<TSource>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource,TPredicate> Where(TPredicate predicate = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.AsyncValueEnumerableWrapper<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource> AsAsyncValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsAsyncValueEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult?> ElementAt(int index,NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.ElementAt<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource,TResult>(this,index,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TSource value)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Contains<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource>(this,value);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TSource value,System.Collections.Generic.IEqualityComparer<TSource>? comparer = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Contains<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource>(this,value,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectManyEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource,TSubEnumerable,TSubEnumerator,TResult> SelectMany(NetFabric.Hyperlinq.Selector<TSource, TSubEnumerable> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectMany<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource,TSubEnumerable,TSubEnumerator,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource> Skip(int count)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Skip<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool AnyAt(TPredicate predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AnyAt<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(System.Predicate<TSource> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.All<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(TPredicate predicate = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.All<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(NetFabric.Hyperlinq.PredicateAt<TSource> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.All<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool AllAt(TPredicate predicate = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AllAt<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectAtEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource,TResult> Select(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Select<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.First<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.First<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate> AsEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereAtEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource,TPredicate> WhereAt(TPredicate predicate = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereAt<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource,TPredicate>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource> Distinct(System.Collections.Generic.IEqualityComparer<TSource>? comparer = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Distinct<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource>(this,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate> AsValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsValueEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.TakeEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource> Take(int count)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Take<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.EnumerableExtensions.ValueEnumerableWrapper<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource> AsValueEnumerable(System.Func<TEnumerable, TEnumerator> getEnumerator)
            => NetFabric.Hyperlinq.EnumerableExtensions.AsValueEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate>.DisposableEnumerator,TSource>(this,getEnumerator);

        }

    }
}
