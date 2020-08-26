using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        public readonly partial struct SkipEnumerable<TEnumerable,TEnumerator,TSource> where TEnumerable : notnull,NetFabric.Hyperlinq.IValueEnumerable<TSource, TEnumerator> where TEnumerator : struct,System.Collections.Generic.IEnumerator<TSource>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly int Count()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Count<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.AsyncValueEnumerableWrapper<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource> AsAsyncValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsAsyncValueEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource> AsEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource> AsValueEnumerable()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.AsValueEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TSource[] ToArray()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.ToArray<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Buffers.IMemoryOwner<TSource> ToArray(System.Buffers.MemoryPool<TSource> pool)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.ToArray<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,pool);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.Dictionary<TKey, TSource> ToDictionary<TKey>(NetFabric.Hyperlinq.Selector<TSource, TKey> keySelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.ToDictionary<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource,TKey>(this,keySelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.Dictionary<TKey, TElement> ToDictionary<TKey,TElement>(NetFabric.Hyperlinq.Selector<TSource, TKey> keySelector,NetFabric.Hyperlinq.NullableSelector<TSource, TElement> elementSelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.ToDictionary<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource,TKey,TElement>(this,keySelector,elementSelector,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Collections.Generic.List<TSource> ToList()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.ToList<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TSource> ElementAt(int index)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.ElementAt<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,index);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> ElementAt<TResult>(int index,NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.ElementAt<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource,TResult>(this,index,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TSource> First()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.First<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First<TResult>(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.First<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TResult> First<TResult>(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.First<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.Option<TSource> Single()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Single<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereAtEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource> Where(NetFabric.Hyperlinq.PredicateAt<TSource> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.WhereEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource> Where(System.Predicate<TSource> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Where<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectAtEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource,TResult> Select<TResult>(NetFabric.Hyperlinq.NullableSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Select<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectManyEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource,TSubEnumerable,TSubEnumerator,TResult> SelectMany<TSubEnumerable,TResult,TSubEnumerator>(NetFabric.Hyperlinq.Selector<TSource, TSubEnumerable> selector)
            where TSubEnumerable : NetFabric.Hyperlinq.IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct,System.Collections.Generic.IEnumerator<TResult>
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectMany<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource,TSubEnumerable,TSubEnumerator,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource,TResult> Select<TResult>(NetFabric.Hyperlinq.NullableSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Select<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(System.Predicate<TSource> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.All<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool All(NetFabric.Hyperlinq.PredicateAt<TSource> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.All<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any()
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Any<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any(System.Predicate<TSource> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Any<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any(NetFabric.Hyperlinq.PredicateAt<TSource> predicate)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Any<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TSource value)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Contains<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,value);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Contains(TSource value,System.Collections.Generic.IEqualityComparer<TSource>? comparer = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Contains<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,value,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.DistinctEnumerable<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource> Distinct(System.Collections.Generic.IEqualityComparer<TSource>? comparer = default)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Distinct<NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.ValueEnumerableExtensions.SkipEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,comparer);

        }

    }
}
