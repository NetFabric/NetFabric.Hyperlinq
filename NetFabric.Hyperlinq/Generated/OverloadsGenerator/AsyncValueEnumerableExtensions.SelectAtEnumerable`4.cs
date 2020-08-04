using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerableExtensions
    {
        public readonly partial struct SelectAtEnumerable<TEnumerable,TEnumerator,TSource,TResult> where TEnumerable : notnull,NetFabric.Hyperlinq.IAsyncValueEnumerable<TSource, TEnumerator> where TEnumerator : struct,System.Collections.Generic.IAsyncEnumerator<TSource>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult> AsAsyncEnumerable()
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.AsAsyncEnumerable<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult> AsAsyncValueEnumerable()
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.AsAsyncValueEnumerable<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<System.Collections.Generic.Dictionary<TKey, TResult>> ToDictionaryAsync<TKey>(NetFabric.Hyperlinq.AsyncSelector<TResult, TKey> keySelector,System.Threading.CancellationToken cancellationToken = default)
            where TKey : notnull
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.ToDictionaryAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TKey>(this,keySelector,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<System.Collections.Generic.Dictionary<TKey, TResult>> ToDictionaryAsync<TKey>(NetFabric.Hyperlinq.AsyncSelector<TResult, TKey> keySelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer,System.Threading.CancellationToken cancellationToken = default)
            where TKey : notnull
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.ToDictionaryAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TKey>(this,keySelector,comparer,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<System.Collections.Generic.Dictionary<TKey, TElement>> ToDictionaryAsync<TKey,TElement>(NetFabric.Hyperlinq.AsyncSelector<TResult, TKey> keySelector,NetFabric.Hyperlinq.AsyncSelector<TResult, TElement> elementSelector,System.Threading.CancellationToken cancellationToken = default)
            where TKey : notnull
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.ToDictionaryAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TKey,TElement>(this,keySelector,elementSelector,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<System.Collections.Generic.Dictionary<TKey, TElement>> ToDictionaryAsync<TKey,TElement>(NetFabric.Hyperlinq.AsyncSelector<TResult, TKey> keySelector,NetFabric.Hyperlinq.AsyncSelector<TResult, TElement> elementSelector,System.Collections.Generic.IEqualityComparer<TKey>? comparer,System.Threading.CancellationToken cancellationToken = default)
            where TKey : notnull
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.ToDictionaryAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TKey,TElement>(this,keySelector,elementSelector,comparer,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<NetFabric.Hyperlinq.Option<TResult>> FirstAsync(NetFabric.Hyperlinq.AsyncSelector<TResult, TResult> selector,System.Threading.CancellationToken cancellationToken)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.FirstAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TResult>(this,selector,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<NetFabric.Hyperlinq.Option<TResult>> FirstAsync(NetFabric.Hyperlinq.AsyncSelectorAt<TResult, TResult> selector,System.Threading.CancellationToken cancellationToken)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.FirstAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TResult>(this,selector,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.WhereAtEnumerable<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult> Where(NetFabric.Hyperlinq.AsyncPredicateAt<TResult> predicate)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.Where<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.WhereEnumerable<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult> Where(NetFabric.Hyperlinq.AsyncPredicate<TResult> predicate)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.Where<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,predicate);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SkipEnumerable<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult> Skip(int count)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.Skip<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.TakeEnumerable<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult> Take(int count)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.Take<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,count);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TResult> Select(NetFabric.Hyperlinq.AsyncSelectorAt<TResult, TResult> selector)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.Select<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectEnumerable<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TResult> Select(NetFabric.Hyperlinq.AsyncSelector<TResult, TResult> selector)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.Select<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult,TResult>(this,selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<bool> AllAsync(NetFabric.Hyperlinq.AsyncPredicate<TResult> predicate,System.Threading.CancellationToken cancellationToken = default)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.AllAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,predicate,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<bool> AllAsync(NetFabric.Hyperlinq.AsyncPredicateAt<TResult> predicate,System.Threading.CancellationToken cancellationToken = default)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.AllAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,predicate,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<bool> AnyAsync(NetFabric.Hyperlinq.AsyncPredicate<TResult> predicate,System.Threading.CancellationToken cancellationToken = default)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.AnyAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,predicate,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<bool> AnyAsync(NetFabric.Hyperlinq.AsyncPredicateAt<TResult> predicate,System.Threading.CancellationToken cancellationToken = default)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.AnyAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,predicate,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<bool> ContainsAsync(TResult value)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.ContainsAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,value);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<bool> ContainsAsync(TResult value,System.Collections.Generic.IEqualityComparer<TResult>? comparer = default,System.Threading.CancellationToken cancellationToken = default)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.ContainsAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,value,comparer,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.DistinctEnumerable<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult> Distinct(System.Collections.Generic.IEqualityComparer<TResult>? comparer = default)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.Distinct<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,comparer);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<TResult[]> ToArrayBuilderAsync(System.Threading.CancellationToken cancellationToken = default)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.ToArrayBuilderAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,cancellationToken);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly System.Threading.Tasks.ValueTask<System.Buffers.IMemoryOwner<TResult>> ToArrayBuilderAsync(System.Buffers.MemoryPool<TResult> pool,System.Threading.CancellationToken cancellationToken = default)
            => NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.ToArrayBuilderAsync<NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>,NetFabric.Hyperlinq.AsyncValueEnumerableExtensions.SelectAtEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator,TResult>(this,pool,cancellationToken);

        }

    }
}
