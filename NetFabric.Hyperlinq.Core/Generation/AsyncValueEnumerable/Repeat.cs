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
            public AsyncEnumerator GetAsyncEnumerator(CancellationToken cancellationToken = default) 
                => new(in this, cancellationToken);

            DisposableAsyncEnumerator IAsyncValueEnumerable<TSource, DisposableAsyncEnumerator>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                => new(in this, cancellationToken);

            IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                // ReSharper disable once HeapView.BoxingAllocation
                => new DisposableAsyncEnumerator(in this, cancellationToken);

            [StructLayout(LayoutKind.Auto)]
            public struct AsyncEnumerator
            {
                readonly CancellationToken cancellationToken;
                readonly int end;
                int counter;

                internal AsyncEnumerator(in RepeatEnumerable<TSource> enumerable, CancellationToken cancellationToken)
                {
                    Current = enumerable.value;
                    counter = -1;
                    end = counter + enumerable.count;
                    this.cancellationToken = cancellationToken;
                }

                public TSource Current { get; }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public ValueTask<bool> MoveNextAsync() 
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    return new ValueTask<bool>(result: ++counter <= end);
                }
            }

            [StructLayout(LayoutKind.Auto)]
            public struct DisposableAsyncEnumerator
                : IAsyncEnumerator<TSource>
            {
                readonly CancellationToken cancellationToken;
                readonly int end;
                int counter;

                internal DisposableAsyncEnumerator(in RepeatEnumerable<TSource> enumerable, CancellationToken cancellationToken)
                {
                    Current = enumerable.value;
                    counter = -1;
                    end = counter + enumerable.count;
                    this.cancellationToken = cancellationToken;
                }
                
                public TSource Current { get; }
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

            [StructLayout(LayoutKind.Auto)]
            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                readonly int end;
                int counter;

                internal DisposableEnumerator(in RepeatEnumerable<TSource> enumerable)
                {
                    Current = enumerable.value;
                    counter = -1;
                    end = counter + enumerable.count;
                }
                
                public TSource Current { get; }
                readonly TSource IEnumerator<TSource>.Current
                    => Current;
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++counter <= end;

                [ExcludeFromCodeCoverage]
                [DoesNotReturn]
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
            public ValueTask<bool> AllAsync(Func<TSource, bool> predicate)
                => new(result: count is 0 || predicate(value));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> AnyAsync()
                => new(result: count is not 0);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueTask<bool> ContainsAsync(TSource value, IEqualityComparer<TSource>? comparer)
                => comparer is null
                    ? new ValueTask<bool>(result: count is not 0 && EqualityComparer<TSource>.Default.Equals(this.value, value))
                    : new ValueTask<bool>(result: count is not 0 && comparer.Equals(this.value, value));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RepeatEnumerable<TResult> Select<TResult, TSelector>(TSelector selector = default) 
                where TSelector : struct, IAsyncFunction<TSource, TResult>
                => new(selector.InvokeAsync(value, CancellationToken.None).GetAwaiter().GetResult(), count);

            public ValueTask<TSource[]> ToArrayAsync(CancellationToken cancellationToken = default)
            {
                if (value is null)
                    return new ValueTask<TSource[]>(result: new TSource[count]);

                var array = Utils.AllocateUninitializedArray<TSource>(count);
                for (var index = 0; index < array.Length; index++)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    array[index] = value;
                }
                return new ValueTask<TSource[]>(result: array);
            }

            public ValueTask<Lease<TSource>> ToArrayAsync(ArrayPool<TSource> pool, CancellationToken cancellationToken = default, bool clearOnDispose = default)
            {
                var result = pool.Lease(count, clearOnDispose);
                var array = result.Memory.Span;
                for (var index = 0; index < array.Length; index++)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    array[index] = value;
                }
                return new ValueTask<Lease<TSource>>(result: result);
            }

            public async ValueTask<List<TSource>> ToListAsync(CancellationToken cancellationToken = default)
                => (await ToArrayAsync(cancellationToken).ConfigureAwait(false)).AsList();
        }
    }
}

