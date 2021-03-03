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
            public readonly Enumerator GetAsyncEnumerator() 
                => new(in this);
            readonly DisposableEnumerator IAsyncValueEnumerable<TSource, DisposableEnumerator>.GetAsyncEnumerator(CancellationToken _) 
                => new(in this);
            readonly IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken _) 
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

                public readonly TSource Current { get; }

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

                public readonly TSource Current { get; }
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
            public ReturnEnumerable<TResult> Select<TResult>(Func<TSource, CancellationToken, ValueTask<TResult>> selector) 
                => Select<TResult, AsyncFunctionWrapper<TSource, TResult>>(new AsyncFunctionWrapper<TSource, TResult>(selector));

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
            public ValueTask<Dictionary<TKey, TSource>> ToDictionaryAsync<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionaryAsync(new FunctionWrapper<TSource, TKey>(keySelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Dictionary<TKey, TSource>> ToDictionaryAsync<TKey, TKeySelector>(TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                => new(result: new Dictionary<TKey, TSource>(1, comparer) { { keySelector.Invoke(value), value } });

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => ToDictionaryAsync<TKey, TElement, FunctionWrapper<TSource, TKey>, FunctionWrapper<TSource, TElement>>(new FunctionWrapper<TSource, TKey>(keySelector), new FunctionWrapper<TSource, TElement>(elementSelector), comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TKey, TElement, TKeySelector, TElementSelector>(TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                where TKeySelector : struct, IFunction<TSource, TKey>
                where TElementSelector : struct, IFunction<TSource, TElement>
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                => new(result: new Dictionary<TKey, TElement>(1, comparer) { { keySelector.Invoke(value), elementSelector.Invoke(value) } });
        }

#pragma warning disable IDE0060 // Remove unused parameter
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<int> CountAsync<TSource>(this in ReturnEnumerable<TSource> source)
            => new(result: 1);
#pragma warning restore IDE0060 // Remove unused parameter
    }
}

