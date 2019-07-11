using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate) 
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
            internal readonly Func<TSource, int, bool> predicate;

            internal WhereIndexEnumerable(in TEnumerable source, Func<TSource, int, bool> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IEnumerator<TSource>
            {
                TEnumerator enumerator;
                readonly Func<TSource, int, bool> predicate;
                int index;

                internal Enumerator(in WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = (TEnumerator)enumerable.source.GetEnumerator();
                    predicate = enumerable.predicate;
                    index = 0;
                }

                public TSource Current => enumerator.Current;
                object IEnumerator.Current => enumerator.Current;

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

                void IEnumerator.Reset() => throw new NotSupportedException();

                public void Dispose() => enumerator.Dispose(); 
            }

            public int Count()
                => Enumerable.Count<TEnumerable, TEnumerator, TSource>(source, predicate);
            public int Count(Func<TSource, bool> predicate)
                => Enumerable.Count<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));
            public int Count(Func<TSource, int, bool> predicate)
                => Enumerable.Count<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public bool All()
                => Enumerable.All<TEnumerable, TEnumerator, TSource>(source, predicate);
            public bool All(Func<TSource, bool> predicate)
                => Enumerable.All<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));
            public bool All(Func<TSource, int, bool> predicate)
                => Enumerable.All<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public bool Any()
                => Enumerable.Any<TEnumerable, TEnumerator, TSource>(source, predicate);
            public bool Any(Func<TSource, bool> predicate)
                => Enumerable.Any<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));
            public bool Any(Func<TSource, int, bool> predicate)
                => Enumerable.Any<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public Enumerable.WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> Where(Func<TSource, int, bool> predicate)
                => Enumerable.Where<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public TSource First()
                => Enumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate).ThrowOnEmpty();
            public TSource First(Func<TSource, bool> predicate)
                => Enumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate)).ThrowOnEmpty();
            public TSource FirstOrDefault()
                => Enumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate).DefaultOnEmpty();
            public TSource FirstOrDefault(Func<TSource, bool> predicate)
                => Enumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate)).DefaultOnEmpty();
            public (int Index, TSource Value) TryFirst()
                => Enumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate);
            public (int Index, TSource Value) TryFirst(Func<TSource, bool> predicate)
                => Enumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));
            public (int Index, TSource Value) TryFirst(Func<TSource, int, bool> predicate)
                => Enumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public TSource Single()
                => Enumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, predicate).ThrowOnEmpty();
            public TSource Single(Func<TSource, bool> predicate)
                => Enumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate)).ThrowOnEmpty();
            public TSource SingleOrDefault()
                => Enumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, predicate).DefaultOnEmpty();
            public TSource SingleOrDefault(Func<TSource, bool> predicate)
                => Enumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate)).DefaultOnEmpty();
            public (int Index, TSource Value) TrySingle()
                => Enumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, predicate);
            public (int Index, TSource Value) TrySingle(Func<TSource, bool> predicate)
                => Enumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));
            public (int Index, TSource Value) TrySingle(Func<TSource, int, bool> predicate)
                => Enumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public List<TSource> ToList()
                => Enumerable.ToList<TEnumerable, TEnumerator, TSource>(source, predicate);
        }
    }
}
