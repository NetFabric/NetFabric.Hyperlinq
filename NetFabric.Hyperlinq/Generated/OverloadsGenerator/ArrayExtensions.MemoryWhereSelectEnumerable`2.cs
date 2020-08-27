using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public readonly partial struct MemoryWhereSelectEnumerable<TSource,TResult>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.AsyncValueEnumerableWrapper<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult> AsAsyncValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsAsyncValueEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult> AsEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult> AsValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsValueEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.Dictionary<TKey, TResult> ToDictionary<TKey>(NetFabric.Hyperlinq.Selector<TResult, TKey> keySelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.ToDictionary<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult,TKey>(this,keySelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.Dictionary<TKey, TElement> ToDictionary<TKey,TElement>(NetFabric.Hyperlinq.Selector<TResult, TKey> keySelector,NetFabric.Hyperlinq.NullableSelector<TResult, TElement> elementSelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.ToDictionary<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult,TKey,TElement>(this,keySelector,elementSelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> ElementAt(int index,NetFabric.Hyperlinq.NullableSelectorAt<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.ElementAt<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult,TResult>(this,index,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First(NetFabric.Hyperlinq.NullableSelector<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.First<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First(NetFabric.Hyperlinq.NullableSelectorAt<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.First<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereAtEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult> Where(NetFabric.Hyperlinq.PredicateAt<TResult> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult> Where(System.Predicate<TResult> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult> Skip(int count)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Skip<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.TakeEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult> Take(int count)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Take<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectAtEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult,TResult> Select(NetFabric.Hyperlinq.NullableSelectorAt<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Select<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectManyEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult,TSubEnumerable,TSubEnumerator,TResult> SelectMany<TSubEnumerable,TSubEnumerator>(NetFabric.Hyperlinq.Selector<TResult, TSubEnumerable> selector)
            where TSubEnumerable : NetFabric.Hyperlinq.IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct,System.Collections.Generic.IEnumerator<TResult>
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectMany<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult,TSubEnumerable,TSubEnumerator,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult,TResult> Select(NetFabric.Hyperlinq.NullableSelector<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Select<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(System.Predicate<TResult> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.All<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(NetFabric.Hyperlinq.PredicateAt<TResult> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.All<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any(System.Predicate<TResult> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Any<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any(NetFabric.Hyperlinq.PredicateAt<TResult> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Any<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TResult value)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Contains<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult>(this,value);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TResult value,System.Collections.Generic.IEqualityComparer<TResult>? comparer = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Contains<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult>(this,value,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult> Distinct(System.Collections.Generic.IEqualityComparer<TResult>? comparer = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Distinct<NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>,NetFabric.Hyperlinq.ArrayExtensions.MemoryWhereSelectEnumerable<TSource, TResult>.DisposableEnumerator,TResult>(this,comparer);

        }

    }
}
