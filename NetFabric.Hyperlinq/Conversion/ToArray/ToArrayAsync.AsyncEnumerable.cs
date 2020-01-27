using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncEnumerable
    {
        [Pure]
        static async ValueTask<TSource[]> ToArrayAsync<TSource>(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var (array, length) = await ToArrayWithLengthAsync(source, cancellationToken).ConfigureAwait(false);
            System.Array.Resize(ref array, length);
            return array;

            static async ValueTask<(TSource[]?, int)> ToArrayWithLengthAsync(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
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
    }
}