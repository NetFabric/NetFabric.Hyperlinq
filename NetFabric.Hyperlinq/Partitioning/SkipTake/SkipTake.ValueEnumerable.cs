using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> SkipTake<TEnumerable, TEnumerator, TSource>(this TEnumerable source, long skipCount, long takeCount)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => new SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>(in source, skipCount, takeCount);

        [GenericsTypeMapping("TEnumerable", typeof(SkipTakeEnumerable<,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(SkipTakeEnumerable<,,>.Enumerator))]
        public readonly struct SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly long skipCount;
            readonly long takeCount;

            internal SkipTakeEnumerable(in TEnumerable source, long skipCount, long takeCount)
            {
                this.source = source;
                this.skipCount = skipCount;
                this.takeCount = takeCount;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IValueEnumerator<TSource>
            {
                TEnumerator enumerator;
                long skipCounter;
                long takeCounter;

                internal Enumerator(in SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = (TEnumerator)enumerable.source.GetEnumerator();
                    skipCounter = enumerable.skipCount;
                    takeCounter = enumerable.takeCount;
                }

                public TSource Current
                    => enumerator.Current;

                public bool MoveNext()
                {
                    while (skipCounter > 0)
                    {
                        if(!enumerator.MoveNext())
                        {
                            skipCounter = 0;
                            return false;
                        }

                        skipCounter--;
                    }

                    if (takeCounter > 0)
                    {
                        if (enumerator.MoveNext())
                        {
                            takeCounter--;
                            return true;
                        }

                        takeCounter = 0;
                    }

                    return false; 
                }

                public void Dispose() => enumerator.Dispose();
            }

            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Take(long count)
                => ValueEnumerable.SkipTake<TEnumerable, TEnumerator, TSource>(source, skipCount, Math.Min(takeCount, count));
        }
    }
}