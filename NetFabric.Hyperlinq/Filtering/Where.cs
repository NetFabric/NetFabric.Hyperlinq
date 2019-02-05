using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static WhereEnumerable<TSource> Where<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IEnumerable<TSource> 
        {
            if(source == null)
                ThrowSourceNull();

            if(predicate == null)
                ThrowPredicateNull();

            return new WhereEnumerable<TSource>(source, predicate);

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowPredicateNull() => throw new ArgumentNullException(nameof(predicate));
        }

        public static IndexWhereEnumerable<TSource> Where<TEnumerable, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate) 
            where TEnumerable : IEnumerable<TSource>
        {
            if(source == null)
                ThrowSourceNull();

            if(predicate == null)
                ThrowPredicateNull();

            return new IndexWhereEnumerable<TSource>(source, predicate);

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowPredicateNull() => throw new ArgumentNullException(nameof(predicate));
        }

        public readonly struct WhereEnumerable<TSource> : IEnumerable<TSource>
        {
            readonly IEnumerable<TSource> source;
            readonly Func<TSource, bool> predicate;

            internal WhereEnumerable(IEnumerable<TSource> source, Func<TSource, bool> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public readonly struct Enumerator : IEnumerator<TSource>
            {
                readonly IEnumerator<TSource> enumerator;
                readonly Func<TSource, bool> predicate;

                internal Enumerator(in WhereEnumerable<TSource> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
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

        public readonly struct IndexWhereEnumerable<TSource> : IEnumerable<TSource>
        {
            readonly IEnumerable<TSource> source;
            readonly Func<TSource, int, bool> predicate;

            internal IndexWhereEnumerable(IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator : IEnumerator<TSource>
            {
                readonly IEnumerator<TSource> enumerator;
                readonly Func<TSource, int, bool> predicate;
                int index;

                internal Enumerator(in IndexWhereEnumerable<TSource> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    predicate = enumerable.predicate;
                    index = -1;
                }

                public TSource Current => enumerator.Current;
                object IEnumerator.Current => enumerator.Current;

                public bool MoveNext()
                {
                    while (enumerator.MoveNext())
                    {
                        index++;
                        if (predicate(enumerator.Current, index))
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

