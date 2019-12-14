using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncValueEnumerableWrapper<TSource> AsAsyncValueEnumerable<TSource>(this IReadOnlyCollection<TSource> source)
            => new AsyncValueEnumerableWrapper<TSource>(source);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncValueEnumerableWrapper<TEnumerable, TEnumerator, TSource> AsAsyncValueEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TEnumerable, CancellationToken, TEnumerator> getAsyncEnumerator)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => new AsyncValueEnumerableWrapper<TEnumerable, TEnumerator, TSource>(source, getAsyncEnumerator);

        [GenericsTypeMapping("TEnumerable", typeof(AsyncValueEnumerableWrapper<,,>))]
        public readonly struct AsyncValueEnumerableWrapper<TEnumerable, TEnumerator, TSource>
            : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TEnumerable, CancellationToken, TEnumerator> getAsyncEnumerator;

            internal AsyncValueEnumerableWrapper(TEnumerable source, Func<TEnumerable, CancellationToken, TEnumerator> getAsyncEnumerator)
            {
                this.source = source;
                this.getAsyncEnumerator = getAsyncEnumerator;
            }

            public readonly int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Count;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TEnumerator GetAsyncEnumerator(CancellationToken cancellationToken = default) 
                => getAsyncEnumerator(source, cancellationToken);
            readonly IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                => getAsyncEnumerator(source, cancellationToken);

            public TSource[] ToArray()
            {
                var array = new TSource[source.Count];
                if (source.Count != 0)
                {
                    if (source is ICollection<TSource> collection)
                    {
                        collection.CopyTo(array, 0);
                    }
                    else
                    {
                        using var enumerator = source.GetEnumerator();
                        checked
                        {
                            for (var index = 0; enumerator.MoveNext(); index++)
                            {
                                array[index] = enumerator.Current;
                            }
                        }
                    }
                }
                return array;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => source switch
                {
                    ICollection<TSource> collection => new List<TSource>(collection), // no need to allocate helper class

                    _ => new List<TSource>(new ReadOnlyCollection.ToListCollection<TEnumerable, TSource>(source)),
                };
        }

        [GenericsTypeMapping("TEnumerable", typeof(AsyncValueEnumerableWrapper<>))]
        [GenericsTypeMapping("TEnumerator", typeof(AsyncValueEnumerableWrapper<>.AsyncEnumerator))]
        public readonly struct AsyncValueEnumerableWrapper<TSource>
            : IAsyncValueEnumerable<TSource, AsyncValueEnumerableWrapper<TSource>.AsyncEnumerator>
        {
            readonly IReadOnlyCollection<TSource> source;

            internal AsyncValueEnumerableWrapper(IReadOnlyCollection<TSource> source)
            {
                this.source = source;
            }

            public readonly int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Count;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly AsyncEnumerator GetAsyncEnumerator(CancellationToken cancellationToken = default) 
            {
                cancellationToken.ThrowIfCancellationRequested();
                return new AsyncEnumerator(source);
            }
            readonly IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken) 
            {
                cancellationToken.ThrowIfCancellationRequested();
                return new AsyncEnumerator(source);
            }

            public readonly struct AsyncEnumerator
                : IAsyncEnumerator<TSource>
            {
                readonly IEnumerator<TSource> enumerator;

                internal AsyncEnumerator(IReadOnlyCollection<TSource> enumerable)
                {
                    enumerator = enumerable.GetEnumerator();
                }

                [MaybeNull]
                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => enumerator.Current;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public ValueTask<bool> MoveNextAsync() 
                    => new ValueTask<bool>(enumerator.MoveNext());

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public ValueTask DisposeAsync() 
                {
                    enumerator.Dispose();
                    return new ValueTask();
                }
            }

            public TSource[] ToArray()
            {
                var array = new TSource[source.Count];
                if (source.Count != 0)
                {
                    if (source is ICollection<TSource> collection)
                    {
                        collection.CopyTo(array, 0);
                    }
                    else
                    {
                        using var enumerator = source.GetEnumerator();
                        checked
                        {
                            for (var index = 0; enumerator.MoveNext(); index++)
                            {
                                array[index] = enumerator.Current;
                            }
                        }
                    }
                }
                return array;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]

            public List<TSource> ToList()
                => source switch
                {
                    ICollection<TSource> collection => new List<TSource>(collection), // no need to allocate helper class

                    _ => new List<TSource>(new ReadOnlyCollection.ToListCollection<IReadOnlyCollection<TSource>, TSource>(source)),
                };
        }
    }
}