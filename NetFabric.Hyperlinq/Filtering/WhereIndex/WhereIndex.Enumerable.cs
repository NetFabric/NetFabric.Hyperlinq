using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return new WhereIndexEnumerable<TEnumerable, TEnumerator, TSource>(in source, predicate);
        }

        [GenericsTypeMapping("TEnumerable", typeof(WhereIndexEnumerable<,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(WhereIndexEnumerable<,,>.Enumerator))]
        public readonly struct WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> 
            : IValueEnumerable<TSource, WhereIndexEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            internal readonly TEnumerable source;
            internal readonly Func<TSource, long, bool> predicate;

            internal WhereIndexEnumerable(in TEnumerable source, Func<TSource, long, bool> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IValueEnumerator<TSource>
            {
                TEnumerator enumerator;
                readonly Func<TSource, long, bool> predicate;
                long index;

                internal Enumerator(in WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = (TEnumerator)enumerable.source.GetEnumerator();
                    predicate = enumerable.predicate;
                    index = 0;
                }

                public TSource Current => enumerator.Current;

                public bool MoveNext()
                {
                    checked
                    {
                        while (enumerator.MoveNext())
                        {
                            if (predicate(enumerator.Current, index))
                                return true;

                            index++;
                        }
                    }
                    return false;
                }

                public void Dispose() => enumerator.Dispose(); 
            }

            public long Count()
                => Enumerable.Count<TEnumerable, TEnumerator, TSource>(source, predicate);
            public long Count(Func<TSource, bool> predicate)
                => Enumerable.Count<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));
            public long Count(Func<TSource, long, bool> predicate)
                => Enumerable.Count<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public bool All()
                => Enumerable.All<TEnumerable, TEnumerator, TSource>(source, predicate);
            public bool All(Func<TSource, bool> predicate)
                => Enumerable.All<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));
            public bool All(Func<TSource, long, bool> predicate)
                => Enumerable.All<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public bool Any()
                => Enumerable.Any<TEnumerable, TEnumerator, TSource>(source, predicate);
            public bool Any(Func<TSource, bool> predicate)
                => Enumerable.Any<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));
            public bool Any(Func<TSource, long, bool> predicate)
                => Enumerable.Any<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public Enumerable.WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> Where(Func<TSource, long, bool> predicate)
                => Enumerable.Where<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public TSource First()
                => Enumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate).ThrowOnEmpty();
            public TSource First(Func<TSource, bool> predicate)
                => Enumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate)).ThrowOnEmpty();
            public TSource FirstOrDefault()
                => Enumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate).DefaultOnEmpty();
            public TSource FirstOrDefault(Func<TSource, bool> predicate)
                => Enumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate)).DefaultOnEmpty();
            public (long Index, TSource Value) TryFirst()
                => Enumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate);
            public (long Index, TSource Value) TryFirst(Func<TSource, bool> predicate)
                => Enumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));
            public (long Index, TSource Value) TryFirst(Func<TSource, long, bool> predicate)
                => Enumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public TSource Single()
                => Enumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, predicate).ThrowOnEmpty();
            public TSource Single(Func<TSource, bool> predicate)
                => Enumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate)).ThrowOnEmpty();
            public TSource SingleOrDefault()
                => Enumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, predicate).DefaultOnEmpty();
            public TSource SingleOrDefault(Func<TSource, bool> predicate)
                => Enumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate)).DefaultOnEmpty();
            public (long Index, TSource Value) TrySingle()
                => Enumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, predicate);
            public (long Index, TSource Value) TrySingle(Func<TSource, bool> predicate)
                => Enumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));
            public (long Index, TSource Value) TrySingle(Func<TSource, long, bool> predicate)
                => Enumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public List<TSource> ToList()
                => Enumerable.ToList<TEnumerable, TEnumerator, TSource>(source, predicate);
        }
    }
}
