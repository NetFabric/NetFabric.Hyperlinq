using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {
        public readonly partial struct SelectEnumerable<TEnumerable,TEnumerator,TSource,TResult> where TEnumerable : notnull,NetFabric.Hyperlinq.IValueReadOnlyCollection<TSource, TEnumerator> where TEnumerator : struct,System.Collections.Generic.IEnumerator<TSource>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.List<TResult> ToList(NetFabric.Hyperlinq.NullableSelector<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToList<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.List<TResult> ToList(NetFabric.Hyperlinq.NullableSelectorAt<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ToList<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> ElementAt(int index,NetFabric.Hyperlinq.NullableSelectorAt<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.ElementAt<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TResult>(this,index,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First(NetFabric.Hyperlinq.NullableSelector<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First(NetFabric.Hyperlinq.NullableSelectorAt<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.First<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> Single(NetFabric.Hyperlinq.NullableSelector<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> Single(NetFabric.Hyperlinq.NullableSelectorAt<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Single<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult> Skip(int count)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Skip<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult> Take(int count)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Take<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectAtEnumerable<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TResult> Select(NetFabric.Hyperlinq.NullableSelectorAt<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Select<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TResult> Select(NetFabric.Hyperlinq.NullableSelector<TResult, TResult> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Select<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(System.Predicate<TResult> predicate)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.All<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(NetFabric.Hyperlinq.PredicateAt<TResult> predicate)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.All<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any(System.Predicate<TResult> predicate)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Any<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any(NetFabric.Hyperlinq.PredicateAt<TResult> predicate)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Any<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TResult value,System.Collections.Generic.IEqualityComparer<TResult>? comparer = default)
            => NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.Contains<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,value,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.AsyncValueEnumerableWrapper<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult> AsAsyncValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsAsyncValueEnumerable<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> AsEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsEnumerable<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> AsValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsValueEnumerable<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereAtEnumerable<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult> Where(NetFabric.Hyperlinq.PredicateAt<TResult> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult> Where(System.Predicate<TResult> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectManyEnumerable<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TSubEnumerable,TSubEnumerator,TResult> SelectMany<TSubEnumerable,TSubEnumerator>(NetFabric.Hyperlinq.Selector<TResult, TSubEnumerable> selector)
            where TSubEnumerable : NetFabric.Hyperlinq.IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct,System.Collections.Generic.IEnumerator<TResult>
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectMany<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TSubEnumerable,TSubEnumerator,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult> Distinct(System.Collections.Generic.IEqualityComparer<TResult>? comparer = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Distinct<NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,comparer);

        }

    }
}
