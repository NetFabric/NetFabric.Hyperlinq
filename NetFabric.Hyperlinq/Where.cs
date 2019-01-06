using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static WhereEnumerable<TSource> Where<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate) where TEnumerable : IEnumerable<TSource> =>
            new WhereEnumerable<TSource>(source, predicate);

        public struct WhereEnumerable<TSource> : IEnumerable<TSource>
        {
            readonly IEnumerable<TSource> source;
            readonly Func<TSource, bool> predicate;

            public WhereEnumerable(IEnumerable<TSource> source, Func<TSource, bool> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public Enumerator GetEnumerator() => new Enumerator(ref this);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(ref this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(ref this);

            public struct Enumerator : IEnumerator<TSource>
            {
                readonly IEnumerator<TSource> enumerator;
                readonly Func<TSource, bool> predicate;

                public Enumerator(ref WhereEnumerable<TSource> enumerable)
                {
                    enumerator = enumerable.GetEnumerator();
                    predicate = enumerable.predicate;
                }

                public TSource Current => enumerator.Current;
                object IEnumerator.Current => enumerator.Current;

                public bool MoveNext()
                {
                    while (enumerator.MoveNext())
                    {
                        if (predicate(enumerator.Current))
                            return true;
                    }
                    return false;
                }

                public void Reset() => throw new NotSupportedException();

                public void Dispose() => enumerator.Dispose();
            }
        }
    }
}

