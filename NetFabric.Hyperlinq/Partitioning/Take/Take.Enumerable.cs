using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static TakeEnumerable<TEnumerable, TEnumerator, TSource> Take<TEnumerable, TEnumerator, TSource>(this TEnumerable source, long count)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator: IEnumerator<TSource>
        {
            return new TakeEnumerable<TEnumerable, TEnumerator, TSource>(in source, count);
        }

        [GenericsTypeMapping("TEnumerable", typeof(TakeEnumerable<,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(TakeEnumerable<,,>.Enumerator))]
        public readonly struct TakeEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, TakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly long count;

            internal TakeEnumerable(in TEnumerable source, long count)
            {
                this.source = source;
                this.count = count;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IValueEnumerator<TSource>
            {
                TEnumerator enumerator;
                long counter;

                internal Enumerator(in TakeEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = (TEnumerator)enumerable.source.GetEnumerator();
                    counter = enumerable.count;
                }

                public TSource Current
                    => enumerator.Current;

                public bool MoveNext()
                {
                    if (counter > 0)
                    {
                        if (enumerator.MoveNext())
                        {
                            counter--;
                            return true;
                        }

                        counter = 0;
                    }
                    return false; 
                }

                public void Dispose() => enumerator.Dispose();
            }

            public TakeEnumerable<TEnumerable, TEnumerator, TSource> Take(long count)
                => Enumerable.Take<TEnumerable, TEnumerator, TSource>(source, Math.Min(this.count, count));
        }
    }
}