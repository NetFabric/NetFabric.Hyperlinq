using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncEnumerableExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncValueEnumerable<TSource> AsAsyncValueEnumerable<TSource>(this IAsyncEnumerable<TSource> source)
            => new(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct AsyncValueEnumerable<TSource>
            : IAsyncValueEnumerable<TSource, AsyncValueEnumerable<TSource>.AsyncEnumerator>
        {
            readonly IAsyncEnumerable<TSource> source;

            internal AsyncValueEnumerable(IAsyncEnumerable<TSource> source) 
                => this.source = source;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public AsyncEnumerator GetAsyncEnumerator(CancellationToken cancellationToken = default) 
                => new(source, cancellationToken);

            IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                // ReSharper disable once HeapView.BoxingAllocation
                => new AsyncEnumerator(source, cancellationToken);

            public readonly struct AsyncEnumerator
                : IAsyncEnumerator<TSource>
            {
                readonly IAsyncEnumerator<TSource> enumerator;

                internal AsyncEnumerator(IAsyncEnumerable<TSource> enumerable, CancellationToken cancellationToken)
                    => enumerator = enumerable.GetAsyncEnumerator(cancellationToken);

                public TSource Current 
                    => enumerator.Current;

                TSource IAsyncEnumerator<TSource>.Current
                    => enumerator.Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public ValueTask<bool> MoveNextAsync()
                    => enumerator.MoveNextAsync();


                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public ValueTask DisposeAsync()
                    => enumerator.DisposeAsync();
            }
            
            #region Conversion

            public AsyncValueEnumerable<TSource> AsAsyncValueEnumerable()
                => this;

            public IAsyncEnumerable<TSource> AsAsyncEnumerable()
                => source;

            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<int> SumAsync(this AsyncValueEnumerable<int> source, CancellationToken cancellationToken = default)
            => source.SumAsync<AsyncValueEnumerable<int>, AsyncValueEnumerable<int>.AsyncEnumerator, int, int>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<int> SumAsync(this AsyncValueEnumerable<int?> source, CancellationToken cancellationToken = default)
            => source.SumAsync<AsyncValueEnumerable<int?>, AsyncValueEnumerable<int?>.AsyncEnumerator, int?, int>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<long> SumAsync(this AsyncValueEnumerable<long> source, CancellationToken cancellationToken = default)
            => source.SumAsync<AsyncValueEnumerable<long>, AsyncValueEnumerable<long>.AsyncEnumerator, long, long>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<long> SumAsync(this AsyncValueEnumerable<long?> source, CancellationToken cancellationToken = default)
            => source.SumAsync<AsyncValueEnumerable<long?>, AsyncValueEnumerable<long?>.AsyncEnumerator, long?, long>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<float> SumAsync(this AsyncValueEnumerable<float> source, CancellationToken cancellationToken = default)
            => source.SumAsync<AsyncValueEnumerable<float>, AsyncValueEnumerable<float>.AsyncEnumerator, float, float>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<float> SumAsync(this AsyncValueEnumerable<float?> source, CancellationToken cancellationToken = default)
            => source.SumAsync<AsyncValueEnumerable<float?>, AsyncValueEnumerable<float?>.AsyncEnumerator, float?, float>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<double> SumAsync(this AsyncValueEnumerable<double> source, CancellationToken cancellationToken = default)
            => source.SumAsync<AsyncValueEnumerable<double>, AsyncValueEnumerable<double>.AsyncEnumerator, double, double>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<double> SumAsync(this AsyncValueEnumerable<double?> source, CancellationToken cancellationToken = default)
            => source.SumAsync<AsyncValueEnumerable<double?>, AsyncValueEnumerable<double?>.AsyncEnumerator, double?, double>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<decimal> SumAsync(this AsyncValueEnumerable<decimal> source, CancellationToken cancellationToken = default)
            => source.SumAsync<AsyncValueEnumerable<decimal>, AsyncValueEnumerable<decimal>.AsyncEnumerator, decimal, decimal>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<decimal> SumAsync(this AsyncValueEnumerable<decimal?> source, CancellationToken cancellationToken = default)
            => source.SumAsync<AsyncValueEnumerable<decimal?>, AsyncValueEnumerable<decimal?>.AsyncEnumerator, decimal?, decimal>(cancellationToken);
    }
}