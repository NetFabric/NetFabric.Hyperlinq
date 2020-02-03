using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerable
    {
        [Pure]
        public static async ValueTask<TSource[]> ToArrayAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            cancellationToken.ThrowIfCancellationRequested();
            var (array, length) = await ToArrayWithLengthAsync(source, cancellationToken).ConfigureAwait(false);
            System.Array.Resize(ref array, length);
            return array;

            static async ValueTask<(TSource[]?, int)> ToArrayWithLengthAsync(TEnumerable source, CancellationToken cancellationToken)
            {
                if (source is ICollection<TSource> collection)
                {
                    var count = collection.Count;
                    if (count == 0)
                        return default;

                    var buffer = new TSource[count];
                    collection.CopyTo(buffer, 0);
                    return (buffer, count);
                }

                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    if (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        var array = Utils.ToArrayAllocate<TSource>();
                        array[0] = enumerator.Current;
                        var count = 1;

                        while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                        {
                            if (count == array.Length)
                                Utils.ToArrayResize(ref array, count);

                            array[count] = enumerator.Current;
                            count++;
                        }

                        return (array, count);
                    }

                    return default; // it's empty
                }
            }
        }

        [Pure]
        public static async ValueTask<TSource[]> ToArrayAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            cancellationToken.ThrowIfCancellationRequested();
            var (array, length) = await ToArrayWithLengthAsync(source, predicate, cancellationToken).ConfigureAwait(false);
            System.Array.Resize(ref array, length);
            return array;

            static async ValueTask<(TSource[]?, int)> ToArrayWithLengthAsync(TEnumerable source, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (await predicate(enumerator.Current, cancellationToken).ConfigureAwait(false))
                        {
                            var array = Utils.ToArrayAllocate<TSource>();
                            array[0] = enumerator.Current;
                            var count = 1;

                            while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                            {
                                var item = enumerator.Current;
                                if (await predicate(item, cancellationToken).ConfigureAwait(false))
                                {
                                    if (count == array.Length)
                                        Utils.ToArrayResize(ref array, count);

                                    array[count] = item;
                                    count++;
                                }
                            }

                            return (array, count);
                        }
                    }

                    return default; // it's empty
                }
            }
        }

        [Pure]
        public static async ValueTask<TSource[]> ToArrayAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            cancellationToken.ThrowIfCancellationRequested();
            var (array, length) = await ToArrayWithLengthAsync(source, predicate, cancellationToken).ConfigureAwait(false);
            System.Array.Resize(ref array, length);
            return array;

            static async ValueTask<(TSource[]?, int)> ToArrayWithLengthAsync(TEnumerable source, AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    for (var index = 0;  await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                    {
                        if (await predicate(enumerator.Current, index, cancellationToken).ConfigureAwait(false))
                        {
                            var array = Utils.ToArrayAllocate<TSource>();
                            array[0] = enumerator.Current;
                            var count = 1;

                            for (index++; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                            {
                                var item = enumerator.Current;
                                if (await predicate(item, index, cancellationToken).ConfigureAwait(false))
                                {
                                    if (count == array.Length)
                                        Utils.ToArrayResize(ref array, count);

                                    array[count] = item;
                                    count++;
                                }
                            }

                            return (array, count);
                        }
                    }

                    return default; // it's empty
                }
            }
        }
    }
}