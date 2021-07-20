using System;
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
        public static AsyncValueEnumerable<TEnumerable, TEnumerator, TEnumerator, TSource, FunctionWrapper<TEnumerable, CancellationToken, TEnumerator>, FunctionWrapper<TEnumerable, CancellationToken, TEnumerator>> AsAsyncValueEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TEnumerable, CancellationToken, TEnumerator> getAsyncEnumerator)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => AsAsyncValueEnumerable<TEnumerable, TEnumerator, TSource, FunctionWrapper<TEnumerable, CancellationToken, TEnumerator>>(source, new FunctionWrapper<TEnumerable, CancellationToken, TEnumerator>(getAsyncEnumerator));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncValueEnumerable<TEnumerable, TEnumerator, TEnumerator, TSource, TGetAsyncEnumerator, TGetAsyncEnumerator> AsAsyncValueEnumerable<TEnumerable, TEnumerator, TSource, TGetAsyncEnumerator>(this TEnumerable source, TGetAsyncEnumerator getAsyncEnumerator = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TGetAsyncEnumerator : struct, IFunction<TEnumerable, CancellationToken, TEnumerator>
            => new(source, getAsyncEnumerator, getAsyncEnumerator);
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, FunctionWrapper<TEnumerable, CancellationToken, TEnumerator>, FunctionWrapper<TEnumerable, CancellationToken, TEnumerator2>> AsAsyncValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource>(this TEnumerable source, Func<TEnumerable, CancellationToken, TEnumerator> getAsyncEnumerator, Func<TEnumerable, CancellationToken, TEnumerator2> getAsyncEnumerator2)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TEnumerator2 : struct
            => AsAsyncValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, FunctionWrapper<TEnumerable, CancellationToken, TEnumerator>, FunctionWrapper<TEnumerable, CancellationToken, TEnumerator2>>(source, new FunctionWrapper<TEnumerable, CancellationToken, TEnumerator>(getAsyncEnumerator), new FunctionWrapper<TEnumerable, CancellationToken, TEnumerator2>(getAsyncEnumerator2));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetAsyncEnumerator, TGetAsyncEnumerator2> AsAsyncValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetAsyncEnumerator, TGetAsyncEnumerator2>(this TEnumerable source, TGetAsyncEnumerator getAsyncEnumerator = default, TGetAsyncEnumerator2 getAsyncEnumerator2 = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TEnumerator2 : struct
            where TGetAsyncEnumerator : struct, IFunction<TEnumerable, CancellationToken, TEnumerator>
            where TGetAsyncEnumerator2 : struct, IFunction<TEnumerable, CancellationToken, TEnumerator2>
            => new(source, getAsyncEnumerator, getAsyncEnumerator2);

        [StructLayout(LayoutKind.Auto)]
        public partial struct AsyncValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetAsyncEnumerator, TGetAsyncEnumerator2>
            : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TEnumerator2 : struct
            where TGetAsyncEnumerator : struct, IFunction<TEnumerable, CancellationToken, TEnumerator>
            where TGetAsyncEnumerator2 : struct, IFunction<TEnumerable, CancellationToken, TEnumerator2>
        {
            internal readonly TEnumerable source;
            internal TGetAsyncEnumerator getAsyncEnumerator;
            internal TGetAsyncEnumerator2 getAsyncEnumerator2;

            internal AsyncValueEnumerable(TEnumerable source, TGetAsyncEnumerator getAsyncEnumerator, TGetAsyncEnumerator2 getAsyncEnumerator2)
                => (this.source, this.getAsyncEnumerator, this.getAsyncEnumerator2) = (source, getAsyncEnumerator, getAsyncEnumerator2);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TEnumerator2 GetAsyncEnumerator(CancellationToken cancellationToken = default) 
                => getAsyncEnumerator2.Invoke(source, cancellationToken);
            TEnumerator IAsyncValueEnumerable<TSource, TEnumerator>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                => getAsyncEnumerator.Invoke(source, cancellationToken);
            IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                // ReSharper disable once HeapView.PossibleBoxingAllocation
                => source.GetAsyncEnumerator(cancellationToken);

            #region Conversion

            public AsyncValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, TSource, TGetAsyncEnumerator, TGetAsyncEnumerator2> AsAsyncValueEnumerable()
                => this;

            public TEnumerable AsAsyncEnumerable()
                => source;

            #endregion
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<int> SumAsync<TEnumerable, TEnumerator, TEnumerator2, TGetAsyncEnumerator, TGetAsyncEnumerator2>(this AsyncValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, int, TGetAsyncEnumerator, TGetAsyncEnumerator2> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<int, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<int>
            where TEnumerator2 : struct
            where TGetAsyncEnumerator : struct, IFunction<TEnumerable, CancellationToken, TEnumerator>
            where TGetAsyncEnumerator2 : struct, IFunction<TEnumerable, CancellationToken, TEnumerator2>
            => source.source.SumAsync<TEnumerable, TEnumerator, int, int>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<int> SumAsync<TEnumerable, TEnumerator, TEnumerator2, TGetAsyncEnumerator, TGetAsyncEnumerator2>(this AsyncValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, int?, TGetAsyncEnumerator, TGetAsyncEnumerator2> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<int?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<int?>
            where TEnumerator2 : struct
            where TGetAsyncEnumerator : struct, IFunction<TEnumerable, CancellationToken, TEnumerator>
            where TGetAsyncEnumerator2 : struct, IFunction<TEnumerable, CancellationToken, TEnumerator2>
            => source.source.SumAsync<TEnumerable, TEnumerator, int?, int>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<nint> SumAsync<TEnumerable, TEnumerator, TEnumerator2, TGetAsyncEnumerator, TGetAsyncEnumerator2>(this AsyncValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, nint, TGetAsyncEnumerator, TGetAsyncEnumerator2> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<nint, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<nint>
            where TEnumerator2 : struct
            where TGetAsyncEnumerator : struct, IFunction<TEnumerable, CancellationToken, TEnumerator>
            where TGetAsyncEnumerator2 : struct, IFunction<TEnumerable, CancellationToken, TEnumerator2>
            => source.source.SumAsync<TEnumerable, TEnumerator, nint, nint>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<nint> SumAsync<TEnumerable, TEnumerator, TEnumerator2, TGetAsyncEnumerator, TGetAsyncEnumerator2>(this AsyncValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, nint?, TGetAsyncEnumerator, TGetAsyncEnumerator2> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<nint?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<nint?>
            where TEnumerator2 : struct
            where TGetAsyncEnumerator : struct, IFunction<TEnumerable, CancellationToken, TEnumerator>
            where TGetAsyncEnumerator2 : struct, IFunction<TEnumerable, CancellationToken, TEnumerator2>
            => source.source.SumAsync<TEnumerable, TEnumerator, nint?, nint>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<nuint> SumAsync<TEnumerable, TEnumerator, TEnumerator2, TGetAsyncEnumerator, TGetAsyncEnumerator2>(this AsyncValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, nuint, TGetAsyncEnumerator, TGetAsyncEnumerator2> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<nuint, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<nuint>
            where TEnumerator2 : struct
            where TGetAsyncEnumerator : struct, IFunction<TEnumerable, CancellationToken, TEnumerator>
            where TGetAsyncEnumerator2 : struct, IFunction<TEnumerable, CancellationToken, TEnumerator2>
            => source.source.SumAsync<TEnumerable, TEnumerator, nuint, nuint>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<nuint> SumAsync<TEnumerable, TEnumerator, TEnumerator2, TGetAsyncEnumerator, TGetAsyncEnumerator2>(this AsyncValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, nuint?, TGetAsyncEnumerator, TGetAsyncEnumerator2> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<nuint?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<nuint?>
            where TEnumerator2 : struct
            where TGetAsyncEnumerator : struct, IFunction<TEnumerable, CancellationToken, TEnumerator>
            where TGetAsyncEnumerator2 : struct, IFunction<TEnumerable, CancellationToken, TEnumerator2>
            => source.source.SumAsync<TEnumerable, TEnumerator, nuint?, nuint>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<long> SumAsync<TEnumerable, TEnumerator, TEnumerator2, TGetAsyncEnumerator, TGetAsyncEnumerator2>(this AsyncValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, long, TGetAsyncEnumerator, TGetAsyncEnumerator2> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<long, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<long>
            where TEnumerator2 : struct
            where TGetAsyncEnumerator : struct, IFunction<TEnumerable, CancellationToken, TEnumerator>
            where TGetAsyncEnumerator2 : struct, IFunction<TEnumerable, CancellationToken, TEnumerator2>
            => source.source.SumAsync<TEnumerable, TEnumerator, long, long>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<long> SumAsync<TEnumerable, TEnumerator, TEnumerator2, TGetAsyncEnumerator, TGetAsyncEnumerator2>(this AsyncValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, long?, TGetAsyncEnumerator, TGetAsyncEnumerator2> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<long?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<long?>
            where TEnumerator2 : struct
            where TGetAsyncEnumerator : struct, IFunction<TEnumerable, CancellationToken, TEnumerator>
            where TGetAsyncEnumerator2 : struct, IFunction<TEnumerable, CancellationToken, TEnumerator2>
            => source.source.SumAsync<TEnumerable, TEnumerator, long?, long>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<float> SumAsync<TEnumerable, TEnumerator, TEnumerator2, TGetAsyncEnumerator, TGetAsyncEnumerator2>(this AsyncValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, float, TGetAsyncEnumerator, TGetAsyncEnumerator2> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<float, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<float>
            where TEnumerator2 : struct
            where TGetAsyncEnumerator : struct, IFunction<TEnumerable, CancellationToken, TEnumerator>
            where TGetAsyncEnumerator2 : struct, IFunction<TEnumerable, CancellationToken, TEnumerator2>
            => source.source.SumAsync<TEnumerable, TEnumerator, float, float>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<float> SumAsync<TEnumerable, TEnumerator, TEnumerator2, TGetAsyncEnumerator, TGetAsyncEnumerator2>(this AsyncValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, float?, TGetAsyncEnumerator, TGetAsyncEnumerator2> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<float?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<float?>
            where TEnumerator2 : struct
            where TGetAsyncEnumerator : struct, IFunction<TEnumerable, CancellationToken, TEnumerator>
            where TGetAsyncEnumerator2 : struct, IFunction<TEnumerable, CancellationToken, TEnumerator2>
            => source.source.SumAsync<TEnumerable, TEnumerator, float?, float>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<double> SumAsync<TEnumerable, TEnumerator, TEnumerator2, TGetAsyncEnumerator, TGetAsyncEnumerator2>(this AsyncValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, double, TGetAsyncEnumerator, TGetAsyncEnumerator2> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<double, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<double>
            where TEnumerator2 : struct
            where TGetAsyncEnumerator : struct, IFunction<TEnumerable, CancellationToken, TEnumerator>
            where TGetAsyncEnumerator2 : struct, IFunction<TEnumerable, CancellationToken, TEnumerator2>
            => source.source.SumAsync<TEnumerable, TEnumerator, double, double>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<double> SumAsync<TEnumerable, TEnumerator, TEnumerator2, TGetAsyncEnumerator, TGetAsyncEnumerator2>(this AsyncValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, double?, TGetAsyncEnumerator, TGetAsyncEnumerator2> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<double?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<double?>
            where TEnumerator2 : struct
            where TGetAsyncEnumerator : struct, IFunction<TEnumerable, CancellationToken, TEnumerator>
            where TGetAsyncEnumerator2 : struct, IFunction<TEnumerable, CancellationToken, TEnumerator2>
            => source.source.SumAsync<TEnumerable, TEnumerator, double?, double>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<decimal> SumAsync<TEnumerable, TEnumerator, TEnumerator2, TGetAsyncEnumerator, TGetAsyncEnumerator2>(this AsyncValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, decimal, TGetAsyncEnumerator, TGetAsyncEnumerator2> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<decimal, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<decimal>
            where TEnumerator2 : struct
            where TGetAsyncEnumerator : struct, IFunction<TEnumerable, CancellationToken, TEnumerator>
            where TGetAsyncEnumerator2 : struct, IFunction<TEnumerable, CancellationToken, TEnumerator2>
            => source.source.SumAsync<TEnumerable, TEnumerator, decimal, decimal>(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<decimal> SumAsync<TEnumerable, TEnumerator, TEnumerator2, TGetAsyncEnumerator, TGetAsyncEnumerator2>(this AsyncValueEnumerable<TEnumerable, TEnumerator, TEnumerator2, decimal?, TGetAsyncEnumerator, TGetAsyncEnumerator2> source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<decimal?, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<decimal?>
            where TEnumerator2 : struct
            where TGetAsyncEnumerator : struct, IFunction<TEnumerable, CancellationToken, TEnumerator>
            where TGetAsyncEnumerator2 : struct, IFunction<TEnumerable, CancellationToken, TEnumerator2>
            => source.source.SumAsync<TEnumerable, TEnumerator, decimal?, decimal>(cancellationToken);
    }
}
