using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> SkipTake<TEnumerable, TEnumerator, TSource>(this TEnumerable source, long skipCount, long takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => new SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>(in source, skipCount, takeCount);

        [GenericsTypeMapping("TEnumerable", typeof(SkipTakeEnumerable<,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(SkipTakeEnumerable<,,>.Enumerator))]
        public readonly struct SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueReadOnlyList<TSource, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly long skipCount;
            readonly long takeCount;

            internal SkipTakeEnumerable(in TEnumerable source, long skipCount, long takeCount)
            {
                this.source = source;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            public long Count => takeCount;

            public TSource this[long index]
            {
                get
                {
                    if (index < 0 || index >= takeCount) 
                        ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));

                    return source[index + skipCount];
                }
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IValueEnumerator<TSource>
            {
                readonly TEnumerable source;
                readonly long end;
                long index;

                internal Enumerator(in SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
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
            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Take(long count)
                => ValueReadOnlyList.SkipTake<TEnumerable, TEnumerator, TSource>(source, skipCount, Math.Min(takeCount, count));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Count<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => source.Count;
    }
}