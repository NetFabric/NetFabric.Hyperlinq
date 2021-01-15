using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerable
    {
        
        public static RepeatEnumerable<TSource> Repeat<TSource>(TSource value, int count)
        {
            if (count < 0) Throw.ArgumentOutOfRangeException(nameof(count));

            return new RepeatEnumerable<TSource>(value, count);
        }

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct RepeatEnumerable<TSource>
            : IAsyncValueEnumerable<TSource, RepeatEnumerable<TSource>.DisposableAsyncEnumerator>
        {
            readonly TSource value;
            readonly int count;

            internal RepeatEnumerable(TSource value, int count)
                => (this.value, this.count) = (value, count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly AsyncEnumerator GetAsyncEnumerator(CancellationToken cancellationToken = default) 
                => new(in this, cancellationToken);
            readonly DisposableAsyncEnumerator IAsyncValueEnumerable<TSource, DisposableAsyncEnumerator>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                => new(in this, cancellationToken);
            readonly IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableAsyncEnumerator(in this, cancellationToken);

            [StructLayout(LayoutKind.Sequential)]
            public struct AsyncEnumerator
            {
                int counter;
                readonly int end;
                readonly CancellationToken cancellationToken;

                internal AsyncEnumerator(in RepeatEnumerable<TSource> enumerable, CancellationToken cancellationToken)
                {
                    Current = enumerable.value;
                    counter = -1;
                    end = counter + enumerable.count;
                    this.cancellationToken = cancellationToken;
                }

                public readonly TSource Current { get; }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public ValueTask<bool> MoveNextAsync() 
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    return new ValueTask<bool>(result: ++counter <= end);
                }
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct DisposableAsyncEnumerator
                : IAsyncEnumerator<TSource>
            {
                int counter;
                readonly int end;
                readonly CancellationToken cancellationToken;

                internal DisposableAsyncEnumerator(in RepeatEnumerable<TSource> enumerable, CancellationToken cancellationToken)
                {
                    Current = enumerable.value;
                    counter = -1;
                    end = counter + enumerable.count;
                    this.cancellationToken = cancellationToken;
                }
                
                public readonly TSource Current { get; }
                readonly TSource IAsyncEnumerator<TSource>.Current
                    => Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public ValueTask<bool> MoveNextAsync() 
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    return new ValueTask<bool>(result: ++counter <= end);
                }

                public readonly ValueTask DisposeAsync()
                    => default;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                int counter;
                readonly int end;

                internal DisposableEnumerator(in RepeatEnumerable<TSource> enumerable)
                {
                    Current = enumerable.value;
                    counter = -1;
                    end = counter + enumerable.count;
                }
                
                public readonly TSource Current { get; }
                readonly TSource IEnumerator<TSource>.Current
                    => Current;
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++counter <= end;

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public readonly void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RepeatEnumerable<TSource> Skip(int count)
            {
                var (_, takeCount) = Utils.Skip(this.count, count);
                return Repeat(value, takeCount);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RepeatEnumerable<TSource> Take(int count)
                => Repeat(value, Utils.Take(this.count, count));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AllAsync(Predicate<TSource> predicate)
                => new(result: count == 0 || predicate(value));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AnyAsync()
                => new(result: count != 0);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> ContainsAsync(TSource value, IEqualityComparer<TSource>? comparer)
                => comparer is null
                    ? new ValueTask<bool>(result: count != 0 && EqualityComparer<TSource>.Default.Equals(this.value, value))
                    : new ValueTask<bool>(result: count != 0 && comparer.Equals(this.value, value));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RepeatEnumerable<TResult> Select<TResult>(Func<TSource, CancellationToken, ValueTask<TResult>> selector) 
                => Select<TResult, AsyncFunctionWrapper<TSource, TResult>>(new AsyncFunctionWrapper<TSource, TResult>(selector));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RepeatEnumerable<TResult> Select<TResult, TSelector>(TSelector selector = default) 
                where TSelector : struct, IAsyncFunction<TSource, TResult>
                => new(selector.InvokeAsync(value, CancellationToken.None).GetAwaiter().GetResult(), count);

            public ValueTask<TSource[]> ToArrayAsync(CancellationToken cancellationToken = default)
            {
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                var array = new TSource[count];
                if (value is object)
                {
                    var end = count - 1;
                    for (var index = 0; index <= end; index++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        array[index] = value;
                    }
                }
                return new ValueTask<TSource[]>(result: array);
            }

            public ValueTask<IMemoryOwner<TSource>> ToArrayAsync(MemoryPool<TSource> pool, CancellationToken cancellationToken = default)
            {
                var result = pool.RentSliced(count);
                var array = result.Memory.Span;
                var end = count - 1;
                for (var index = 0; index <= end; index++)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    array[index] = value;
                }
                return new ValueTask<IMemoryOwner<TSource>>(result: result);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<List<TSource>> ToListAsync(CancellationToken cancellationToken = default)
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                => new(result: new List<TSource>(collection: new RangeToListCollection(value, count, cancellationToken)));

            sealed class RangeToListCollection
                : ToListCollectionBase<TSource>
            {
                readonly TSource value;
                readonly CancellationToken cancellationToken;

                public RangeToListCollection(TSource value, int count, CancellationToken cancellationToken)
                    : base(count)
                    => (this.value, this.cancellationToken) = (value, cancellationToken);

                public override void CopyTo(TSource[] array, int _)
                {
                    if (value is object)
                    {
                        var end = Count - 1;
                        for (var index = 0; index <= end; index++)
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                            array[index] = value;
                        }
                    }
                }
            }
        }
    }
}

