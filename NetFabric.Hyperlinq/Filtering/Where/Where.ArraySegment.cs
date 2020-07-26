using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentWhereEnumerable<TSource> Where<TSource>(this in ArraySegment<TSource> source, Predicate<TSource> predicate)
        {
            if (predicate is null)
                Throw.ArgumentNullException(nameof(predicate));

            return new ArraySegmentWhereEnumerable<TSource>(source, predicate);
        }

        public readonly partial struct ArraySegmentWhereEnumerable<TSource>
            : IValueEnumerable<TSource, ArraySegmentWhereEnumerable<TSource>.DisposableEnumerator>
        {
            internal readonly ArraySegment<TSource> source;
            internal readonly Predicate<TSource> predicate;

            internal ArraySegmentWhereEnumerable(in ArraySegment<TSource> source, Predicate<TSource> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }


            public readonly Enumerator GetEnumerator()
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, ArraySegmentWhereEnumerable<TSource>.DisposableEnumerator>.GetEnumerator()
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator()
                => new DisposableEnumerator(in this);

            public struct Enumerator
            {
                readonly TSource[] source;
                readonly Predicate<TSource> predicate;
                readonly int end;
                int index;

                internal Enumerator(in ArraySegmentWhereEnumerable<TSource> enumerable)
                {
                    source = enumerable.source.Array;
                    predicate = enumerable.predicate;
                    index = enumerable.source.Offset - 1;
                    end = index + enumerable.source.Count;
                }

                public readonly TSource Current
                    => source[index];

                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate(source[index]))
                            return true;
                    }
                    return false;
                }
            }

            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                readonly TSource[] source;
                readonly Predicate<TSource> predicate;
                readonly int end;
                int index;

                internal DisposableEnumerator(in ArraySegmentWhereEnumerable<TSource> enumerable)
                {
                    source = enumerable.source.Array;
                    predicate = enumerable.predicate;
                    index = enumerable.source.Offset - 1;
                    end = index + enumerable.source.Count;
                }

                [MaybeNull]
                public readonly TSource Current
                    => source[index];
                readonly TSource IEnumerator<TSource>.Current
                    => source[index];
                readonly object? IEnumerator.Current
                    => source[index];

                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate(source[index]))
                            return true;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset()
                    => throw new NotSupportedException();

                public void Dispose() { }
            }

            public int Count()
                => ArrayExtensions.Count<TSource>(source, predicate);

            public bool Any()
                => ArrayExtensions.Any<TSource>(source, predicate);

            public ArraySegmentWhereEnumerable<TSource> Where(Predicate<TSource> predicate)
                => ArrayExtensions.Where<TSource>(source, Utils.Combine(this.predicate, predicate));

            public ArraySegmentWhereAtEnumerable<TSource> Where(PredicateAt<TSource> predicate)
                => ArrayExtensions.Where<TSource>(source, Utils.Combine(this.predicate, predicate));

            public ArraySegmentWhereSelectEnumerable<TSource, TResult> Select<TResult>(NullableSelector<TSource, TResult> selector)
            {
                if (selector is null)
                    Throw.ArgumentNullException(nameof(selector));

                return ArrayExtensions.WhereSelect<TSource, TResult>(source, predicate, selector);
            }

            public Option<TSource> ElementAt(int index)
                => ArrayExtensions.ElementAt(source, index, predicate);

            public Option<TSource> First()
                => ArrayExtensions.First(source, predicate);

            public Option<TSource> Single()
#pragma warning disable HLQ005 // Avoid Single() and SingleOrDefault()
                => ArrayExtensions.Single(source, predicate);
#pragma warning restore HLQ005 // Avoid Single() and SingleOrDefault()

            public TSource[] ToArray()
                => ArrayExtensions.ToArray<TSource>(source, predicate);

            public IMemoryOwner<TSource> ToArray(MemoryPool<TSource> memoryPool)
                => ArrayExtensions.ToArray<TSource>(source, predicate, memoryPool);

            public List<TSource> ToList()
                => ArrayExtensions.ToList<TSource>(source, predicate); // memory performs best
        }
    }
}

