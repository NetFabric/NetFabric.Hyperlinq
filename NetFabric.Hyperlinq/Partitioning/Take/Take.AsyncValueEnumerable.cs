using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerable
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TakeEnumerable<TEnumerable, TEnumerator, TSource> Take<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int count)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            => new TakeEnumerable<TEnumerable, TEnumerator, TSource>(in source, count);

        public readonly partial struct TakeEnumerable<TEnumerable, TEnumerator, TSource>
            : IAsyncValueEnumerable<TSource, TakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly int count;

            internal TakeEnumerable(in TEnumerable source, int count)
            {
                this.source = source;
                this.count = count;
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetAsyncEnumerator(CancellationToken cancellationToken = default) 
                => new Enumerator(in this, cancellationToken);
            readonly IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken) 
                => new Enumerator(in this, cancellationToken);

            public struct Enumerator
                : IAsyncEnumerator<TSource>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                int counter;

                internal Enumerator(in TakeEnumerable<TEnumerable, TEnumerator, TSource> enumerable, CancellationToken cancellationToken)
                {
                    enumerator = enumerable.source.GetAsyncEnumerator(cancellationToken);
                    counter = enumerable.count;
                }

                [MaybeNull]
                public readonly TSource Current
                    => enumerator.Current;

                public async ValueTask<bool> MoveNextAsync()
                {
                    if (counter > 0)
                    {
                        if (await enumerator.MoveNextAsync().ConfigureAwait(false))
                        {
                            counter--;
                            return true;
                        }

                        counter = 0;
                    }
                    await DisposeAsync();
                    return false; 
                }

                public ValueTask DisposeAsync() 
                    => enumerator.DisposeAsync();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TakeEnumerable<TEnumerable, TEnumerator, TSource> Take(int count)
                => AsyncValueEnumerable.Take<TEnumerable, TEnumerator, TSource>(source, Math.Min(this.count, count));
        }
    }
}