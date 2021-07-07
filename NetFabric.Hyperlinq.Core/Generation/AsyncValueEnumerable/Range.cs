using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerable
    {
        
        public static RangeEnumerable Range(int start, int count)
        {
            if (count < 0)
                Throw.ArgumentOutOfRangeException(nameof(count));

            var end = 0;
            try
            {
                end = checked(start + count);
            }
            catch (OverflowException)
            {
                Throw.ArgumentOutOfRangeException(nameof(count));
            }

            return new RangeEnumerable(start, count, end);
        }

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct RangeEnumerable
            : IAsyncValueEnumerable<int, RangeEnumerable.DisposableEnumerator>
        {
            readonly int start;
            readonly int count;
            readonly int end;

            internal RangeEnumerable(int start, int count, int end)
            {
                this.start = start;
                this.count = count;
                this.end = end;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator GetEnumerator(CancellationToken cancellationToken = default) 
                => new(in this, cancellationToken);

            DisposableEnumerator IAsyncValueEnumerable<int, DisposableEnumerator>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                => new(in this, cancellationToken);

            IAsyncEnumerator<int> IAsyncEnumerable<int>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableEnumerator(in this, cancellationToken);

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
            {
                readonly CancellationToken cancellationToken;
                readonly int end;
#pragma warning disable IDE0032 // Use auto property
                int current;
#pragma warning restore IDE0032 // Use auto property

                internal Enumerator(in RangeEnumerable enumerable, CancellationToken cancellationToken)
                {
                    current = enumerable.start - 1;
                    end = current + enumerable.count;
                    this.cancellationToken = cancellationToken;
                }

                public int Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => current;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public ValueTask<bool> MoveNextAsync()
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    return new ValueTask<bool>(++current <= end);
                }
            }

            [StructLayout(LayoutKind.Auto)]
            public struct DisposableEnumerator
                : IAsyncEnumerator<int>
            {
                readonly CancellationToken cancellationToken;
                readonly int end;
#pragma warning disable IDE0032 // Use auto property
                int current;
#pragma warning restore IDE0032 // Use auto property

                internal DisposableEnumerator(in RangeEnumerable enumerable, CancellationToken cancellationToken)
                {
                    current = enumerable.start - 1;
                    end = current + enumerable.count;
                    this.cancellationToken = cancellationToken;
                }

                public int Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => current;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public ValueTask<bool> MoveNextAsync()
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    return new ValueTask<bool>(++current <= end);
                }

                public readonly ValueTask DisposeAsync()
                    => new();
            }

#pragma warning disable IDE0060 // Remove unused parameter
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
                => new(count);
#pragma warning restore IDE0060 // Remove unused parameter

#pragma warning disable IDE0060 // Remove unused parameter
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AnyAsync(CancellationToken cancellationToken = default)
                => new(count is not 0);
#pragma warning restore IDE0060 // Remove unused parameter

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RangeEnumerable Skip(int count)
            {
                var (newOffset, newCount) = Utils.Skip(this.count, count);
                return Range(start + newOffset, newCount);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RangeEnumerable Take(int count)
                => Range(start, Utils.Take(this.count, count));

#pragma warning disable IDE0060 // Remove unused parameter
            public ValueTask<bool> ContainsAsync(int value, CancellationToken cancellationToken)
                => new(value >= start && value < end);
#pragma warning restore IDE0060 // Remove unused parameter

            public ValueTask<bool> ContainsAsync(int value, IEqualityComparer<int>? comparer, CancellationToken cancellationToken = default)
            {
                if (count is 0)
                    return new ValueTask<bool>(false);

                if (comparer is null || ReferenceEquals(comparer, EqualityComparer<int>.Default))
                    return new ValueTask<bool>(value >= start && value < end);

                for (var item = start; item < end; item++)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    if (comparer.Equals(item, value))
                        return new ValueTask<bool>(true);
                }
                return new ValueTask<bool>(false);
            }

            public ValueTask<int[]> ToArrayAsync(CancellationToken cancellationToken = default)
            {
                var array = Utils.AllocateUninitializedArray<int>(count);
                if (start is 0)
                {
                    for (var index = 0; index < count; index++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        array[index] = index;
                    }
                }
                else
                {
                    for (var index = 0; index < count; index++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        array[index] = index + start;
                    }
                }
                return new ValueTask<int[]>(array);
            }

            public ValueTask<Lease<int>> ToArrayAsync(ArrayPool<int> pool, CancellationToken cancellationToken = default, bool clearOnDispose = default)
            {
                var result = pool.Lease(count, clearOnDispose);
                var span = result.Memory.Span;
                if (start is 0)
                {
                    for (var index = 0; index < count; index++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        span[index] = index;
                    }
                }
                else
                {
                    for (var index = 0; index < count; index++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        span[index] = index + start;
                    }
                }
                return new ValueTask<Lease<int>>(result);
            }

            public async ValueTask<List<int>> ToListAsync(CancellationToken cancellationToken = default)
                => (await ToArrayAsync(cancellationToken).ConfigureAwait(false)).AsList();
        }
    }
}

