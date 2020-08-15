using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegmentWhereAtEnumerable<TSource> Where<TSource>(this in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
        {
            if (predicate is null)
                Throw.ArgumentNullException(nameof(predicate));

            return new ArraySegmentWhereAtEnumerable<TSource>(source, predicate);
        }

        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct ArraySegmentWhereAtEnumerable<TSource>
            : IValueEnumerable<TSource, ArraySegmentWhereAtEnumerable<TSource>.DisposableEnumerator>
        {
            internal readonly ArraySegment<TSource> source;
            internal readonly PredicateAt<TSource> predicate;

            internal ArraySegmentWhereAtEnumerable(in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }


            public readonly Enumerator GetEnumerator()
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, ArraySegmentWhereAtEnumerable<TSource>.DisposableEnumerator>.GetEnumerator()
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator()
                => new DisposableEnumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
            {
                int index;
                readonly int end;
                readonly int offset;
                readonly TSource[]? source;
                readonly PredicateAt<TSource> predicate;

                internal Enumerator(in ArraySegmentWhereAtEnumerable<TSource> enumerable)
                {
                    source = enumerable.source.Array;
                    predicate = enumerable.predicate;
                    offset = enumerable.source.Offset;
                    index = -1;
                    end = index + enumerable.source.Count;
                }

                public readonly TSource Current
                    => source![index + offset];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate(source![index + offset], index))
                            return true;
                    }
                    return false;
                }
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                int index;
                readonly int end;
                readonly int offset;
                readonly TSource[]? source;
                readonly PredicateAt<TSource> predicate;

                internal DisposableEnumerator(in ArraySegmentWhereAtEnumerable<TSource> enumerable)
                {
                    source = enumerable.source.Array;
                    predicate = enumerable.predicate;
                    offset = enumerable.source.Offset;
                    index = -1;
                    end = index + enumerable.source.Count;
                }

                [MaybeNull]
                public readonly TSource Current
                    => source![index + offset];
                readonly TSource IEnumerator<TSource>.Current
                    => source![index + offset];
                readonly object? IEnumerator.Current
                    => source![index + offset];

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    while (++index <= end)
                    {
                        if (predicate(source![index + offset], index))
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

            public ArraySegmentWhereAtEnumerable<TSource> Where(Predicate<TSource> predicate)
                => ArrayExtensions.Where<TSource>(source, Utils.Combine(this.predicate, predicate));

            public ArraySegmentWhereAtEnumerable<TSource> Where(PredicateAt<TSource> predicate)
                => ArrayExtensions.Where<TSource>(source, Utils.Combine(this.predicate, predicate));

            public Option<TSource> ElementAt(int index)
                => ArrayExtensions.ElementAt(source, index, predicate);

            public Option<TSource> First()
                => ArrayExtensions.First(source, predicate);

#pragma warning disable HLQ005 // Avoid Single() and SingleOrDefault()
            public Option<TSource> Single()
                => ArrayExtensions.Single(source, predicate);
#pragma warning restore HLQ005 // Avoid Single() and SingleOrDefault()

            public TSource[] ToArray()
                => ArrayExtensions.ToArray<TSource>(source, predicate);

            public IMemoryOwner<TSource> ToArray(MemoryPool<TSource> memoryPool)
                => ArrayExtensions.ToArray<TSource>(source, predicate, memoryPool);

            public List<TSource> ToList()
                => ArrayExtensions.ToList<TSource>(source, predicate);
        }
    }
}

