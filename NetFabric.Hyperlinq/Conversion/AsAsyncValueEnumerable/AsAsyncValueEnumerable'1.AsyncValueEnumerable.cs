using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerableExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncValueEnumerable<TEnumerator, TSource> AsAsyncValueEnumerable<TEnumerator, TSource>(this IAsyncValueEnumerable<TSource, TEnumerator> source)
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => new(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct AsyncValueEnumerable<TEnumerator, TSource>
            : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            readonly IAsyncValueEnumerable<TSource, TEnumerator> source;

            internal AsyncValueEnumerable(IAsyncValueEnumerable<TSource, TEnumerator> source) 
                => this.source = source;

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TEnumerator GetAsyncEnumerator(CancellationToken cancellationToken = default) 
                => source.GetAsyncEnumerator(cancellationToken);
            IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                // ReSharper disable once HeapView.BoxingAllocation
                => source.GetAsyncEnumerator(cancellationToken);
            
            #region Conversion

            public AsyncValueEnumerable<TEnumerator, TSource> AsAsyncValueEnumerable()
                => this;

            public IAsyncEnumerable<TSource> AsAsyncEnumerable()
                => source;

            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<int> SumAsync<TEnumerator>(this AsyncValueEnumerable<TEnumerator, int> source, CancellationToken cancellationToken = default)
            where TEnumerator : struct, IAsyncEnumerator<int>
            => source.SumAsync<AsyncValueEnumerable<TEnumerator, int>, TEnumerator, int, int>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<int> SumAsync<TEnumerator>(this AsyncValueEnumerable<TEnumerator, int?> source, CancellationToken cancellationToken = default)
            where TEnumerator : struct, IAsyncEnumerator<int?>
            => source.SumAsync<AsyncValueEnumerable<TEnumerator, int?>, TEnumerator, int?, int>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<nint> SumAsync<TEnumerator>(this AsyncValueEnumerable<TEnumerator, nint> source, CancellationToken cancellationToken = default)
            where TEnumerator : struct, IAsyncEnumerator<nint>
            => source.SumAsync<AsyncValueEnumerable<TEnumerator, nint>, TEnumerator, nint, nint>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<nint> SumAsync<TEnumerator>(this AsyncValueEnumerable<TEnumerator, nint?> source, CancellationToken cancellationToken = default)
            where TEnumerator : struct, IAsyncEnumerator<nint?>
            => source.SumAsync<AsyncValueEnumerable<TEnumerator, nint?>, TEnumerator, nint?, nint>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<nuint> SumAsync<TEnumerator>(this AsyncValueEnumerable<TEnumerator, nuint> source, CancellationToken cancellationToken = default)
            where TEnumerator : struct, IAsyncEnumerator<nuint>
            => source.SumAsync<AsyncValueEnumerable<TEnumerator, nuint>, TEnumerator, nuint, nuint>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<nuint> SumAsync<TEnumerator>(this AsyncValueEnumerable<TEnumerator, nuint?> source, CancellationToken cancellationToken = default)
            where TEnumerator : struct, IAsyncEnumerator<nuint?>
            => source.SumAsync<AsyncValueEnumerable<TEnumerator, nuint?>, TEnumerator, nuint?, nuint>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<long> SumAsync<TEnumerator>(this AsyncValueEnumerable<TEnumerator, long> source, CancellationToken cancellationToken = default)
            where TEnumerator : struct, IAsyncEnumerator<long>
            => source.SumAsync<AsyncValueEnumerable<TEnumerator, long>, TEnumerator, long, long>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<long> SumAsync<TEnumerator>(this AsyncValueEnumerable<TEnumerator, long?> source, CancellationToken cancellationToken = default)
            where TEnumerator : struct, IAsyncEnumerator<long?>
            => source.SumAsync<AsyncValueEnumerable<TEnumerator, long?>, TEnumerator, long?, long>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<float> SumAsync<TEnumerator>(this AsyncValueEnumerable<TEnumerator, float> source, CancellationToken cancellationToken = default)
            where TEnumerator : struct, IAsyncEnumerator<float>
            => source.SumAsync<AsyncValueEnumerable<TEnumerator, float>, TEnumerator, float, float>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<float> SumAsync<TEnumerator>(this AsyncValueEnumerable<TEnumerator, float?> source, CancellationToken cancellationToken = default)
            where TEnumerator : struct, IAsyncEnumerator<float?>
            => source.SumAsync<AsyncValueEnumerable<TEnumerator, float?>, TEnumerator, float?, float>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<double> SumAsync<TEnumerator>(this AsyncValueEnumerable<TEnumerator, double> source, CancellationToken cancellationToken = default)
            where TEnumerator : struct, IAsyncEnumerator<double>
            => source.SumAsync<AsyncValueEnumerable<TEnumerator, double>, TEnumerator, double, double>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<double> SumAsync<TEnumerator>(this AsyncValueEnumerable<TEnumerator, double?> source, CancellationToken cancellationToken = default)
            where TEnumerator : struct, IAsyncEnumerator<double?>
            => source.SumAsync<AsyncValueEnumerable<TEnumerator, double?>, TEnumerator, double?, double>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<decimal> SumAsync<TEnumerator>(this AsyncValueEnumerable<TEnumerator, decimal> source, CancellationToken cancellationToken = default)
            where TEnumerator : struct, IAsyncEnumerator<decimal>
            => source.SumAsync<AsyncValueEnumerable<TEnumerator, decimal>, TEnumerator, decimal, decimal>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<decimal> SumAsync<TEnumerator>(this AsyncValueEnumerable<TEnumerator, decimal?> source, CancellationToken cancellationToken = default)
            where TEnumerator : struct, IAsyncEnumerator<decimal?>
            => source.SumAsync<AsyncValueEnumerable<TEnumerator, decimal?>, TEnumerator, decimal?, decimal>(cancellationToken);
    }
}