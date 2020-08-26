using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        public readonly partial struct SelectEnumerable<TEnumerable,TEnumerator,TSource,TResult> where TEnumerable : notnull,NetFabric.Hyperlinq.IValueEnumerable<TSource, TEnumerator> where TEnumerator : struct,System.Collections.Generic.IEnumerator<TSource>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.AsyncValueEnumerableWrapper<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult> AsAsyncValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsAsyncValueEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> AsEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> AsValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsValueEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.Dictionary<TKey, TResult> ToDictionary<TKey>(NetFabric.Hyperlinq.Selector<TResult, TKey> keySelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.ToDictionary<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TKey>(this,keySelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.Dictionary<TKey, TElement> ToDictionary<TKey,TElement>(NetFabric.Hyperlinq.Selector<TResult, TKey> keySelector,NetFabric.Hyperlinq.NullableSelector<TResult, TElement> elementSelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.ToDictionary<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TKey,TElement>(this,keySelector,elementSelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> ElementAt(int index,NetFabric.Hyperlinq.NullableSelectorAt<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.ElementAt<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TResult>(this,index,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First(NetFabric.Hyperlinq.NullableSelector<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.First<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First(NetFabric.Hyperlinq.NullableSelectorAt<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.First<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereAtEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult> Where(NetFabric.Hyperlinq.PredicateAt<TResult> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult> Where(System.Predicate<TResult> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult> Skip(int count)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Skip<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.TakeEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult> Take(int count)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Take<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectAtEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TResult> Select(NetFabric.Hyperlinq.NullableSelectorAt<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Select<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectManyEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TSubEnumerable,TSubEnumerator,TResult> SelectMany<TSubEnumerable,TSubEnumerator>(NetFabric.Hyperlinq.Selector<TResult, TSubEnumerable> selector)
            where TSubEnumerable : NetFabric.Hyperlinq.IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct,System.Collections.Generic.IEnumerator<TResult>
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectMany<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TSubEnumerable,TSubEnumerator,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TResult> Select(NetFabric.Hyperlinq.NullableSelector<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Select<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(System.Predicate<TResult> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.All<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(NetFabric.Hyperlinq.PredicateAt<TResult> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.All<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any(System.Predicate<TResult> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Any<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any(NetFabric.Hyperlinq.PredicateAt<TResult> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Any<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TResult value)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Contains<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,value);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TResult value,System.Collections.Generic.IEqualityComparer<TResult>? comparer = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Contains<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,value,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult> Distinct(System.Collections.Generic.IEqualityComparer<TResult>? comparer = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Distinct<NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,comparer);

        }

    }
}
