using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerableExtensions
    {

        public static async ValueTask<TSum> SumAsync<TEnumerable, TEnumerator, TSource, TSum>(this TEnumerable source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSum : struct
        {
            var sum = default(TSum);
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    sum = Scalar.Add(enumerator.Current, sum);
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
            return sum;
        }


        internal static async ValueTask<TSum> SumAsync<TEnumerable, TEnumerator, TSource, TSum, TPredicate>(this TEnumerable source, CancellationToken cancellationToken, TPredicate predicate)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSum : struct
        {
            var sum = default(TSum);
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    var item = enumerator.Current;
                    if (await predicate.InvokeAsync(item, cancellationToken).ConfigureAwait(false))
                        sum = Scalar.Add(item, sum);
                }
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
            return sum;
        }


        internal static async ValueTask<TSum> SumAtAsync<TEnumerable, TEnumerator, TSource, TSum, TPredicate>(this TEnumerable source, CancellationToken cancellationToken, TPredicate predicate)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, int, bool>
            where TSum : struct
        {
            var sum = default(TSum);
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                {
                    var item = enumerator.Current;
                    if (await predicate.InvokeAsync(item, index, cancellationToken).ConfigureAwait(false))
                        sum = Scalar.Add(item, sum);
                }
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
            return sum;
        }


        internal static async ValueTask<TSum> SumAsync<TEnumerable, TEnumerator, TSource, TResult, TSum, TSelector>(this TEnumerable source, CancellationToken cancellationToken, TSelector selector)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, TResult>
            where TSum : struct
        {
            var sum = default(TSum);
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    var item = enumerator.Current;
                    sum = Scalar.Add(await selector.InvokeAsync(item, cancellationToken).ConfigureAwait(false), sum);
                }
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
            return sum;
        }


        internal static async ValueTask<TSum> SumAtAsync<TEnumerable, TEnumerator, TSource, TResult, TSum, TSelector>(this TEnumerable source, CancellationToken cancellationToken, TSelector selector)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, int, TResult>
            where TSum : struct
        {
            var sum = default(TSum);
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                {
                    var item = enumerator.Current;
                    sum = Scalar.Add(await selector.InvokeAsync(item, index, cancellationToken).ConfigureAwait(false), sum);
                }
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
            return sum;
        }
        

        internal static async ValueTask<TSum> SumAsync<TEnumerable, TEnumerator, TSource, TResult, TSum, TPredicate, TSelector>(this TEnumerable source, CancellationToken cancellationToken, TPredicate predicate, TSelector selector)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, TResult>
            where TSum : struct
        {
            var sum = default(TSum);
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    var item = enumerator.Current;
                    if (await predicate.InvokeAsync(item, cancellationToken).ConfigureAwait(false))
                        sum = Scalar.Add(await selector.InvokeAsync(item, cancellationToken).ConfigureAwait(false), sum);
                }
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
            return sum;
        }
    }
}

