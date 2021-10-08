using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerable
    {
        
        public static ReturnEnumerable<TSource> Return<TSource>(TSource value) =>
            new(value);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ReturnEnumerable<TSource>
            : IAsyncValueEnumerable<TSource, ReturnEnumerable<TSource>.DisposableEnumerator>
        {
            readonly TSource value;

            internal ReturnEnumerable(TSource value) 
                => this.value = value;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator GetAsyncEnumerator() 
                => new(in this);

            DisposableEnumerator IAsyncValueEnumerable<TSource, DisposableEnumerator>.GetAsyncEnumerator(CancellationToken _) 
                => new(in this);

            IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken _) 
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this);

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
            {
                bool moveNext;

                internal Enumerator(in ReturnEnumerable<TSource> enumerable)
                {
                    Current = enumerable.value;
                    moveNext = true;
                }

                public TSource Current { get; }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public ValueTask<bool> MoveNextAsync()
                {
                    var previous = moveNext;
                    moveNext = false;
                    return new ValueTask<bool>(previous);
                }
            }

            [StructLayout(LayoutKind.Auto)]
            public struct DisposableEnumerator
                : IAsyncEnumerator<TSource>
            {
                bool moveNext;

                internal DisposableEnumerator(in ReturnEnumerable<TSource> enumerable)
                {
                    Current = enumerable.value;
                    moveNext = true;
                }

                public TSource Current { get; }
                readonly TSource IAsyncEnumerator<TSource>.Current 
                    => Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public ValueTask<bool> MoveNextAsync()
                {
                    var previous = moveNext;
                    moveNext = false;
                    return new ValueTask<bool>(previous);
                }

                public readonly ValueTask DisposeAsync() 
                    => default;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AnyAsync()
                => new(result: true);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> ContainsAsync(TSource value, IEqualityComparer<TSource>? comparer)
                => comparer is null
                    ? new ValueTask<bool>(result: EqualityComparer<TSource>.Default.Equals(this.value, value))
                    : new ValueTask<bool>(result: comparer.Equals(this.value, value));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReturnEnumerable<TResult> Select<TResult, TSelector>(TSelector selector = default) 
                where TSelector : struct, IAsyncFunction<TSource, TResult>
                => new(selector.InvokeAsync(value, CancellationToken.None).GetAwaiter().GetResult());

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Option<TSource>> ElementAtAsync(int index)
                => index switch
                { 
                    0 => new ValueTask<Option<TSource>>(result: Option.Some(value)),
                    _ => default,
                };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Option<TSource>> FirstAsync()
                => new(result: Option.Some(value));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Option<TSource>> SingleAsync()
                => new(result: Option.Some(value));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<TSource[]> ToArrayAsync()
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                => new(result: new TSource[] { value });

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<List<TSource>> ToListAsync()
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                => new(result: new List<TSource>(1) { value });

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public async ValueTask<Dictionary<TKey, TSource>> ToDictionaryAsync<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default, CancellationToken cancellationToken = default)
                where TKey : notnull
                where TKeySelector : struct, IAsyncFunction<TSource, TKey>
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                => new Dictionary<TKey, TSource>(1, comparer) { { await keySelector.InvokeAsync(value, cancellationToken).ConfigureAwait(false), value } };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public async ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default, CancellationToken cancellationToken = default)
                where TKey : notnull
                where TKeySelector : struct, IAsyncFunction<TSource, TKey>
                where TElementSelector : struct, IAsyncFunction<TSource, TElement>
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                => new Dictionary<TKey, TElement>(1, comparer) { { await keySelector.InvokeAsync(value, cancellationToken).ConfigureAwait(false), await elementSelector.InvokeAsync(value, cancellationToken).ConfigureAwait(false) } };
        }

#pragma warning disable IDE0060 // Remove unused parameter
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<int> CountAsync<TSource>(this in ReturnEnumerable<TSource> source)
            => new(result: 1);
#pragma warning restore IDE0060 // Remove unused parameter
    }
}

