using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerable
    {
        // Based on https://github.com/dotnet/reactive/blob/34ea00d1b724d4c8d67947f500400876655f6feb/Ix.NET/Source/System.Linq.Async/System/Linq/AsyncEnumerableHelpers.cs
        [Pure]
        public static async ValueTask<TSource[]> ToArrayAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            cancellationToken.ThrowIfCancellationRequested();
            var (array, length) = await ToArrayWithLengthAsync(source, cancellationToken).ConfigureAwait(false);
            System.Array.Resize(ref array, length);
            return array;

            static async ValueTask<(TSource[], int)> ToArrayWithLengthAsync(TEnumerable source, CancellationToken cancellationToken)
            {
                // Check for short circuit optimizations. This one is very unlikely
                // but could be here as a group
                if (source is ICollection<TSource> collection)
                {
                    var count = collection.Count;
                    if (count == 0)
                        return default;

                    // Allocate an array of the desired size, then copy the elements into it. Note that this has the same 
                    // issue regarding concurrency as other existing collections like List<TSource>. If the collection size 
                    // concurrently changes between the array allocation and the CopyTo, we could end up either getting an 
                    // exception from overrunning the array (if the size went up) or we could end up not filling as many 
                    // items as 'count' suggests (if the size went down).  This is only an issue for concurrent collections 
                    // that implement ICollection<TSource>, which as of .NET 4.6 is just ConcurrentDictionary<TKey, TValue>.
                    var buffer = new TSource[count];
                    collection.CopyTo(buffer, 0);
                    return (buffer, count);
                }

                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    if (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        const int DefaultCapacity = 4;
                        var array = new TSource[DefaultCapacity];
                        array[0] = enumerator.Current;
                        var count = 1;

                        while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                        {
                            if (count == array.Length)
                            {
                                // MaxArrayLength is defined in Array.MaxArrayLength and in gchelpers in CoreCLR.
                                // It represents the maximum number of elements that can be in an array where
                                // the size of the element is greater than one byte; a separate, slightly larger constant,
                                // is used when the size of the element is one.
                                const int MaxArrayLength = 0x7FEFFFFF;

                                // This is the same growth logic as in List<TSource>:
                                // If the array is currently empty, we make it a default size.  Otherwise, we attempt to 
                                // double the size of the array.  Doubling will overflow once the size of the array reaches
                                // 2^30, since doubling to 2^31 is 1 larger than Int32.MaxValue.  In that case, we instead 
                                // constrain the length to be MaxArrayLength (this overflow check works because of the 
                                // cast to uint).  Because a slightly larger constant is used when TSource is one byte in size, we 
                                // could then end up in a situation where arr.Length is MaxArrayLength or slightly larger, such 
                                // that we constrain newLength to be MaxArrayLength but the needed number of elements is actually 
                                // larger than that.  For that case, we then ensure that the newLength is large enough to hold 
                                // the desired capacity.  This does mean that in the very rare case where we've grown to such a 
                                // large size, each new element added after MaxArrayLength will end up doing a resize.
                                var newLength = count << 1;
                                if ((uint)newLength > MaxArrayLength)
                                    newLength = MaxArrayLength <= count ? count + 1 : MaxArrayLength;

                                System.Array.Resize(ref array, newLength);
                            }

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