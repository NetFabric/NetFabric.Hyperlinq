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
    }
}