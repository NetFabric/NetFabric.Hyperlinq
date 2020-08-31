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

        [GeneratorMapping("TSource", "int", true)]
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
            public readonly Enumerator GetEnumerator(CancellationToken cancellationToken = default) 
                => new Enumerator(in this, cancellationToken);
            readonly DisposableEnumerator IAsyncValueEnumerable<int, DisposableEnumerator>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                => new DisposableEnumerator(in this, cancellationToken);
            readonly IAsyncEnumerator<int> IAsyncEnumerable<int>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                => new DisposableEnumerator(in this, cancellationToken);

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
            {
#pragma warning disable IDE0032 // Use auto property
                int current;
#pragma warning restore IDE0032 // Use auto property
                readonly int end;
                readonly CancellationToken cancellationToken;

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

            [StructLayout(LayoutKind.Sequential)]
            public struct DisposableEnumerator
                : IAsyncEnumerator<int>
            {
#pragma warning disable IDE0032 // Use auto property
                int current;
#pragma warning restore IDE0032 // Use auto property
                readonly int end;
                readonly CancellationToken cancellationToken;

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
                    => new ValueTask();
            }

#pragma warning disable IDE0060 // Remove unused parameter
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<int> CountAsync(CancellationToken cancellationToken = default)
                => new ValueTask<int>(count);
#pragma warning restore IDE0060 // Remove unused parameter

#pragma warning disable IDE0060 // Remove unused parameter
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AnyAsync(CancellationToken cancellationToken = default)
                => new ValueTask<bool>(count != 0);
#pragma warning restore IDE0060 // Remove unused parameter

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RangeEnumerable Skip(int count)
            {
                var (skipCount, takeCount) = Utils.Skip(this.count, count);
                return Range(start + skipCount, takeCount);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RangeEnumerable Take(int count)
                => Range(start, Utils.Take(this.count, count));

#pragma warning disable IDE0060 // Remove unused parameter
            public ValueTask<bool> ContainsAsync(int value, CancellationToken cancellationToken = default)
                => new ValueTask<bool>(value >= start && value < end);
#pragma warning restore IDE0060 // Remove unused parameter

            public ValueTask<bool> ContainsAsync(int value, IEqualityComparer<int>? comparer, CancellationToken cancellationToken = default)
            {
                if (count == 0)
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
#if NET5_0
                var array = GC.AllocateUninitializedArray<int>(count);
#else
                var array = new int[count];
#endif
                if (start == 0)
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

            public ValueTask<IMemoryOwner<int>> ToArrayAsync(MemoryPool<int> pool, CancellationToken cancellationToken = default)
            {
                if (pool is null)
                    Throw.ArgumentNullException(nameof(pool));

                var result = pool.Rent(count);
                var span = result.Memory.Span;
                if (start == 0)
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
                return new ValueTask<IMemoryOwner<int>>(result);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<List<int>> ToListAsync(CancellationToken cancellationToken = default)
                => new ValueTask<List<int>>(new List<int>(new RangeToListCollection(this, cancellationToken)));

            sealed class RangeToListCollection
                : ToListCollectionBase<int>
            {
                readonly RangeEnumerable source;
                readonly CancellationToken cancellationToken;

                public RangeToListCollection(in RangeEnumerable source, CancellationToken cancellationToken)
                    : base(source.count)
                    => (this.source, this.cancellationToken) = (source, cancellationToken);

                public override void CopyTo(int[] array, int _)
                {
                    var count = source.count;
                    if (source.start == 0)
                    {
                        for (var index = 0; index < count; index++)
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                            array[index] = index;
                        }
                    }
                    else
                    {
                        var start = source.start;
                        for (var index = 0; index < count; index++)
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                            array[index] = index + start;
                        }
                    }
                }
            }
        }
    }
}

