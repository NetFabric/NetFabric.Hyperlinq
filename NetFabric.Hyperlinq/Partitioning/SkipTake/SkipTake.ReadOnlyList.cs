using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static SkipTakeEnumerable<TEnumerable, TSource> SkipTake<TEnumerable, TSource>(this TEnumerable source, int skipCount, int takeCount)
            where TEnumerable : IReadOnlyList<TSource>
            => new SkipTakeEnumerable<TEnumerable, TSource>(in source, skipCount, takeCount);

        [GenericsTypeMapping("TEnumerable", typeof(SkipTakeEnumerable<,>))]
        [GenericsTypeMapping("TEnumerator", typeof(SkipTakeEnumerable<,>.Enumerator))]
        public readonly struct SkipTakeEnumerable<TEnumerable, TSource>
            : IValueReadOnlyList<TSource, SkipTakeEnumerable<TEnumerable, TSource>.Enumerator>
            where TEnumerable : IReadOnlyList<TSource>
        {
            readonly TEnumerable source;
            readonly int skipCount;
            readonly int takeCount;

            internal SkipTakeEnumerable(in TEnumerable source, int skipCount, int takeCount)
            {
                this.source = source;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            public int Count => takeCount;
            long IValueReadOnlyCollection<TSource, Enumerator>.Count => takeCount;

            public TSource this[int index]
            {
                get
                {
                    if (index < 0 || index >= takeCount) 
                        ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));

                    return source[index + skipCount];
                }
            }

            TSource IValueReadOnlyList<TSource, Enumerator>.this[long index]
            {
                get
                {
                    if (index > int.MaxValue) 
                        ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));

                    return this[(int)index];
                }
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IValueEnumerator<TSource>
            {
                readonly TEnumerable source;
                readonly int end;
                int index;

                internal Enumerator(in SkipTakeEnumerable<TEnumerable, TSource> enumerable)
                {
                    source = enumerable.source;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public TSource Current
                    => source[index];

                public bool MoveNext()
                    => ++index < end;

                public void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TEnumerable, TSource> Take(long count)
                => ReadOnlyList.SkipTake<TEnumerable, TSource>(source, skipCount, (int)Math.Min(takeCount, count));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Count<TEnumerable, TSource>(this SkipTakeEnumerable<TEnumerable, TSource> source)
            where TEnumerable : IReadOnlyList<TSource>
            => source.Count;
    }
}