using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerableExtensions
    {
        public readonly partial struct DistinctEnumerable<TEnumerable,TEnumerator,TSource> where TEnumerable : notnull,NetFabric.Hyperlinq.IAsyncValueEnumerable<TSource, TEnumerator> where TEnumerator : struct,System.Collections.Generic.IAsyncEnumerator<TSource>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource> AsAsyncEnumerable()
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.AsAsyncEnumerable<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource> AsAsyncValueEnumerable()
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.AsAsyncValueEnumerable<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<System.Collections.Generic.Dictionary<TKey, TSource>> ToDictionaryAsync<TKey>(NetFabric.Hyperlinq.AsyncSelector<TSource, TKey> keySelector,System.Threading.CancellationToken cancellationToken = default)
            where TKey : notnull
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.ToDictionaryAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource,TKey>(this,keySelector,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<System.Collections.Generic.Dictionary<TKey, TSource>> ToDictionaryAsync<TKey>(NetFabric.Hyperlinq.AsyncSelector<TSource, TKey> keySelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer,System.Threading.CancellationToken cancellationToken = default)
            where TKey : notnull
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.ToDictionaryAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource,TKey>(this,keySelector,comparer,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<System.Collections.Generic.Dictionary<TKey, TElement>> ToDictionaryAsync<TKey,TElement>(NetFabric.Hyperlinq.AsyncSelector<TSource, TKey> keySelector,NetFabric.Hyperlinq.AsyncSelector<TSource, TElement> elementSelector,System.Threading.CancellationToken cancellationToken = default)
            where TKey : notnull
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.ToDictionaryAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource,TKey,TElement>(this,keySelector,elementSelector,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<System.Collections.Generic.Dictionary<TKey, TElement>> ToDictionaryAsync<TKey,TElement>(NetFabric.Hyperlinq.AsyncSelector<TSource, TKey> keySelector,NetFabric.Hyperlinq.AsyncSelector<TSource, TElement> elementSelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer,System.Threading.CancellationToken cancellationToken = default)
            where TKey : notnull
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.ToDictionaryAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource,TKey,TElement>(this,keySelector,elementSelector,comparer,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<NetFabric.Hyperlinq.Option<TSource>> ElementAtAsync(int index,System.Threading.CancellationToken cancellationToken = default)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.ElementAtAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,index,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<NetFabric.Hyperlinq.Option<TSource>> FirstAsync(System.Threading.CancellationToken cancellationToken = default)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.FirstAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<NetFabric.Hyperlinq.Option<TResult>> FirstAsync<TResult>(NetFabric.Hyperlinq.AsyncSelector<TSource, TResult> selector,System.Threading.CancellationToken cancellationToken)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.FirstAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource,TResult>(this,selector,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<NetFabric.Hyperlinq.Option<TResult>> FirstAsync<TResult>(NetFabric.Hyperlinq.AsyncSelectorAt<TSource, TResult> selector,System.Threading.CancellationToken cancellationToken)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.FirstAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource,TResult>(this,selector,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<NetFabric.Hyperlinq.Option<TSource>> SingleAsync(System.Threading.CancellationToken cancellationToken = default)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SingleAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.WhereAtEnumerable<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource> Where(NetFabric.Hyperlinq.AsyncPredicateAt<TSource> predicate)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.Where<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.WhereEnumerable<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource> Where(NetFabric.Hyperlinq.AsyncPredicate<TSource> predicate)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.Where<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SkipEnumerable<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource> Skip(int count)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.Skip<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.TakeEnumerable<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource> Take(int count)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.Take<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource,TResult> Select<TResult>(NetFabric.Hyperlinq.AsyncSelectorAt<TSource, TResult> selector)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.Select<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectEnumerable<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource,TResult> Select<TResult>(NetFabric.Hyperlinq.AsyncSelector<TSource, TResult> selector)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.Select<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<bool> AllAsync(NetFabric.Hyperlinq.AsyncPredicate<TSource> predicate,System.Threading.CancellationToken cancellationToken = default)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.AllAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,predicate,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<bool> AllAsync(NetFabric.Hyperlinq.AsyncPredicateAt<TSource> predicate,System.Threading.CancellationToken cancellationToken = default)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.AllAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,predicate,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<bool> AnyAsync(NetFabric.Hyperlinq.AsyncPredicate<TSource> predicate,System.Threading.CancellationToken cancellationToken = default)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.AnyAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,predicate,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<bool> AnyAsync(NetFabric.Hyperlinq.AsyncPredicateAt<TSource> predicate,System.Threading.CancellationToken cancellationToken = default)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.AnyAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,predicate,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<bool> ContainsAsync(TSource value)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.ContainsAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,value);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<bool> ContainsAsync(TSource value,System.Collections.Generic.IEqualityComparer<TSource>? comparer = default,System.Threading.CancellationToken cancellationToken = default)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.ContainsAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,value,comparer,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource> Distinct(System.Collections.Generic.IEqualityComparer<TSource>? comparer = default)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.Distinct<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<TSource[]> ToArrayBuilderAsync(System.Threading.CancellationToken cancellationToken = default)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.ToArrayBuilderAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<System.Buffers.IMemoryOwner<TSource>> ToArrayBuilderAsync(System.Buffers.MemoryPool<TSource> pool,System.Threading.CancellationToken cancellationToken = default)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.ToArrayBuilderAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator,TSource>(this,pool,cancellationToken);

        }

    }
}
