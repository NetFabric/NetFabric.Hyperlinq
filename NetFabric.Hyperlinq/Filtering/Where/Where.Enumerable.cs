using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static WhereEnumerable<TEnumerable, TEnumerator, TSource> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return new WhereEnumerable<TEnumerable, TEnumerator, TSource>(in source, predicate);
        }

        [GenericsTypeMapping("TEnumerable", typeof(WhereEnumerable<,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(WhereEnumerable<,,>.Enumerator))]
        public readonly struct WhereEnumerable<TEnumerable, TEnumerator, TSource> 
            : IValueEnumerable<TSource, WhereEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            internal readonly TEnumerable source;
            internal readonly Func<TSource, bool> predicate;

            internal WhereEnumerable(in TEnumerable source, Func<TSource, bool> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IValueEnumerator<TSource>
            {
                TEnumerator enumerator;
                readonly Func<TSource, bool> predicate;

                internal Enumerator(in WhereEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = (TEnumerator)enumerable.source.GetEnumerator();
                    predicate = enumerable.predicate;
                }

                public TSource Current => enumerator.Current;

                public bool MoveNext()
                {
                    while (enumerator.MoveNext())
                    {
                        if (predicate(enumerator.Current))
                            return true;
                    }
                    return false;
                }

                public void Dispose() => enumerator.Dispose(); 
            }

            public long Count()
                => Enumerable.Count<TEnumerable, TEnumerator, TSource>(source, predicate);
            public long Count(Func<TSource, bool> predicate)
                => Enumerable.Count<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public bool All()
                => Enumerable.All<TEnumerable, TEnumerator, TSource>(source, predicate);
            public bool All(Func<TSource, bool> predicate)
                => Enumerable.All<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public bool Any()
                => Enumerable.Any<TEnumerable, TEnumerator, TSource>(source, predicate);
            public bool Any(Func<TSource, bool> predicate)
                => Enumerable.Any<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public Enumerable.WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector)
                => Enumerable.WhereSelect<TEnumerable, TEnumerator, TSource, TResult>(source, predicate, selector);

            public Enumerable.WhereEnumerable<TEnumerable, TEnumerator, TSource> Where(Func<TSource, bool> predicate)
                => Enumerable.Where<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public TSource First()
                => Enumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate).ThrowOnEmpty();
            public TSource First(Func<TSource, bool> predicate)
                => Enumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate)).ThrowOnEmpty();
            public TSource FirstOrDefault()
                => Enumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate).DefaultOnEmpty();
            public TSource FirstOrDefault(Func<TSource, bool> predicate)
                => Enumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate)).DefaultOnEmpty();
            public (ElementResult Success, TSource Value) TryFirst()
                => Enumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate);
            public (ElementResult Success, TSource Value) TryFirst(Func<TSource, bool> predicate)
                => Enumerable.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public TSource Single()
                => Enumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, predicate).ThrowOnEmpty();
            public TSource Single(Func<TSource, bool> predicate)
                => Enumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate)).ThrowOnEmpty();
            public TSource SingleOrDefault()
                => Enumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, predicate).DefaultOnEmpty();
            public TSource SingleOrDefault(Func<TSource, bool> predicate)
                => Enumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate)).DefaultOnEmpty();
            public (ElementResult Success, TSource Value) TrySingle()
                => Enumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, predicate);
            public (ElementResult Success, TSource Value) TrySingle(Func<TSource, bool> predicate)
                => Enumerable.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));
        }
    }
}
