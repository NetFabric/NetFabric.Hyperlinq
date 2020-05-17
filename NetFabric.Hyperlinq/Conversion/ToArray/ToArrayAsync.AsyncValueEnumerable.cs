using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;
using NetFabric.Hyperlinq;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerable
    {
        
        public static async ValueTask<TSource[]> ToArrayAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var builder = new LargeArrayBuilder<TSource>(initialize: true);
            await builder.AddRangeAsync<TEnumerable, TEnumerator>(source, cancellationToken);
            return builder.ToArray();
        }

        static async ValueTask<TSource[]> ToArrayAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicate<TSource> predicate, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var builder = new LargeArrayBuilder<TSource>(initialize: true);
            await builder.AddRangeAsync<TEnumerable, TEnumerator>(source, predicate, cancellationToken);
            return builder.ToArray();
        }

        static async ValueTask<TSource[]> ToArrayAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, AsyncPredicateAt<TSource> predicate, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var builder = new LargeArrayBuilder<TSource>(initialize: true);
            await builder.AddRangeAsync<TEnumerable, TEnumerator>(source, predicate, cancellationToken);
            return builder.ToArray();
        }


        static async ValueTask<TResult[]> ToArrayAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var builder = new LargeArrayBuilder<TResult>(initialize: true);
            await builder.AddRangeAsync<TEnumerable, TEnumerator, TSource>(source, selector, cancellationToken);
            return builder.ToArray();
        }

        static async ValueTask<TResult[]> ToArrayAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncSelectorAt<TSource, TResult> selector, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var builder = new LargeArrayBuilder<TResult>(initialize: true);
            await builder.AddRangeAsync<TEnumerable, TEnumerator, TSource>(source, selector, cancellationToken);
            return builder.ToArray();
        }

        static async ValueTask<TResult[]> ToArrayAsync<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, AsyncPredicate<TSource> predicate, AsyncSelector<TSource, TResult> selector, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var builder = new LargeArrayBuilder<TResult>(initialize: true);
            await builder.AddRangeAsync<TEnumerable, TEnumerator, TSource>(source, predicate, selector, cancellationToken);
            return builder.ToArray();
        }
    }
}

namespace System.Collections.Generic
{
    internal partial struct LargeArrayBuilder<T>
    {
        public async ValueTask AddRangeAsync<TEnumerable, TEnumerator>(TEnumerable items, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<T, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<T>
        {
            Debug.Assert(items is object);

            var enumerator = items.GetAsyncEnumerator();
            await using (enumerator.ConfigureAwait(false))
            {
                var destination = _current;
                var index = _index;

                // Continuously read in items from the enumerator, updating _count
                // and _index when we run out of space.

                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var item = enumerator.Current;

                    if ((uint)index >= (uint)destination.Length)
                        AddWithBufferAllocation(item, ref destination, ref index);
                    else
                        destination[index] = item;

                    index++;
                }

                // Final update to _count and _index.
                _count += index - _index;
                _index = index;
            }
        }

        public async ValueTask AddRangeAsync<TEnumerable, TEnumerator>(TEnumerable items, AsyncPredicate<T> predicate, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<T, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<T>
        {
            Debug.Assert(items is object);

            var enumerator = items.GetAsyncEnumerator();
            await using (enumerator.ConfigureAwait(false))
            {
                var destination = _current;
                var index = _index;

                // Continuously read in items from the enumerator, updating _count
                // and _index when we run out of space.

                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var item = enumerator.Current;
                    if (await predicate(item, cancellationToken).ConfigureAwait(false))
                    {
                        if ((uint)index >= (uint)destination.Length)
                            AddWithBufferAllocation(item, ref destination, ref index);
                        else
                            destination[index] = item;

                        index++;
                    }
                }

                // Final update to _count and _index.
                _count += index - _index;
                _index = index;
            }
        }

        public async ValueTask AddRangeAsync<TEnumerable, TEnumerator>(TEnumerable items, AsyncPredicateAt<T> predicate, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<T, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<T>
        {
            Debug.Assert(items is object);

            var enumerator = items.GetAsyncEnumerator();
            await using (enumerator.ConfigureAwait(false))
            {
                var destination = _current;
                var index = _index;

                // Continuously read in items from the enumerator, updating _count
                // and _index when we run out of space.

                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var item = enumerator.Current;
                    if (await predicate(item, index, cancellationToken).ConfigureAwait(false))
                    {
                        if ((uint)index >= (uint)destination.Length)
                            AddWithBufferAllocation(item, ref destination, ref index);
                        else
                            destination[index] = item;

                        index++;
                    }
                }

                // Final update to _count and _index.
                _count += index - _index;
                _index = index;
            }
        }

        public async ValueTask AddRangeAsync<TEnumerable, TEnumerator, U>(TEnumerable items, AsyncSelector<U, T> selector, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<U, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<U>
        {
            Debug.Assert(items is object);

            var enumerator = items.GetAsyncEnumerator();
            await using (enumerator.ConfigureAwait(false))
            {
                var destination = _current;
                var index = _index;

                // Continuously read in items from the enumerator, updating _count
                // and _index when we run out of space.

                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var item = enumerator.Current;

                    if ((uint)index >= (uint)destination.Length)
                        AddWithBufferAllocation(await selector(item, cancellationToken).ConfigureAwait(false), ref destination, ref index);
                    else
                        destination[index] = await selector(item, cancellationToken).ConfigureAwait(false);

                    index++;
                }

                // Final update to _count and _index.
                _count += index - _index;
                _index = index;
            }
        }

        public async ValueTask AddRangeAsync<TEnumerable, TEnumerator, U>(TEnumerable items, AsyncSelectorAt<U, T> selector, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<U, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<U>
        {
            Debug.Assert(items is object);

            var enumerator = items.GetAsyncEnumerator();
            await using (enumerator.ConfigureAwait(false))
            {
                var destination = _current;
                var index = _index;

                // Continuously read in items from the enumerator, updating _count
                // and _index when we run out of space.

                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var item = enumerator.Current;

                    if ((uint)index >= (uint)destination.Length)
                        AddWithBufferAllocation(await selector(item, index, cancellationToken).ConfigureAwait(false), ref destination, ref index);
                    else
                        destination[index] = await selector(item, index, cancellationToken).ConfigureAwait(false);

                    index++;
                }

                // Final update to _count and _index.
                _count += index - _index;
                _index = index;
            }
        }

        public async ValueTask AddRangeAsync<TEnumerable, TEnumerator, U>(TEnumerable items, AsyncPredicate<U> predicate, AsyncSelector<U, T> selector, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<U, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<U>
        {
            Debug.Assert(items is object);

            var enumerator = items.GetAsyncEnumerator();
            await using (enumerator.ConfigureAwait(false))
            {
                var destination = _current;
                var index = _index;

                // Continuously read in items from the enumerator, updating _count
                // and _index when we run out of space.

                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var item = enumerator.Current;
                    if (await predicate(item, cancellationToken).ConfigureAwait(false))
                    {
                        if ((uint)index >= (uint)destination.Length)
                            AddWithBufferAllocation(await selector(item, cancellationToken).ConfigureAwait(false), ref destination, ref index);
                        else
                            destination[index] = await selector(item, cancellationToken).ConfigureAwait(false);

                        index++;
                    }
                }

                // Final update to _count and _index.
                _count += index - _index;
                _index = index;
            }
        }
    }
}