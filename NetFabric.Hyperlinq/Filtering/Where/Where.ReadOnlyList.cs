using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static WhereEnumerable<TEnumerable, TSource> Where<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return new WhereEnumerable<TEnumerable, TSource>(in source, predicate, 0, source.Count);
        }

        static WhereEnumerable<TEnumerable, TSource> Where<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate, int skipCount, int takeCount)
            where TEnumerable : IReadOnlyList<TSource>
            => new WhereEnumerable<TEnumerable, TSource>(in source, predicate, skipCount, takeCount);

        [GenericsTypeMapping("TEnumerable", typeof(WhereEnumerable<,>))]
        [GenericsTypeMapping("TEnumerator", typeof(WhereEnumerable<,>.Enumerator))]
        public readonly struct WhereEnumerable<TEnumerable, TSource>
            : IValueEnumerable<TSource, WhereEnumerable<TEnumerable, TSource>.Enumerator>
            where TEnumerable : IReadOnlyList<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, bool> predicate;
            readonly int skipCount;
            readonly int takeCount;

            internal WhereEnumerable(in TEnumerable source, Func<TSource, bool> predicate, int skipCount, int takeCount)
            {
                this.source = source;
                this.predicate = predicate;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IValueEnumerator<TSource>
            {
                readonly TEnumerable source;
                readonly Func<TSource, bool> predicate;
                readonly int end;
                int index;

                internal Enumerator(in WhereEnumerable<TEnumerable, TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public TSource Current
                    => source[index];

                public bool MoveNext()
                {
                    while (++index < end)
                    {
                        if (predicate(source[index]))
                            return true;
                    }
                    return false;
                }

                public void Dispose() { }
            }

            public long Count()
                => ReadOnlyList.Count<TEnumerable, TSource>(source, predicate, skipCount, takeCount);
            public long Count(Func<TSource, bool> predicate)
                => ReadOnlyList.Count<TEnumerable, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            public bool All()
                => ReadOnlyList.All<TEnumerable, TSource>(source, predicate);
            public bool All(Func<TSource, bool> predicate)
                => ReadOnlyList.All<TEnumerable, TSource>(source, Utils.Combine(this.predicate, predicate));

            public bool Any()
                => ReadOnlyList.Any<TEnumerable, TSource>(source, predicate);
            public bool Any(Func<TSource, bool> predicate)
                => ReadOnlyList.Any<TEnumerable, TSource>(source, Utils.Combine(this.predicate, predicate));

            public ReadOnlyList.WhereSelectEnumerable<TEnumerable, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector)
                => ReadOnlyList.WhereSelect<TEnumerable, TSource, TResult>(source, predicate, selector);

            public ReadOnlyList.WhereEnumerable<TEnumerable, TSource> Where(Func<TSource, bool> predicate)
                => ReadOnlyList.Where<TEnumerable, TSource>(source, Utils.Combine(this.predicate, predicate));

            public TSource First()
                => ReadOnlyList.TryFirst<TEnumerable, TSource>(source, predicate).ThrowOnEmpty();
            public TSource First(Func<TSource, bool> predicate)
                => ReadOnlyList.TryFirst<TEnumerable, TSource>(source, Utils.Combine(this.predicate, predicate)).ThrowOnEmpty();
            public TSource FirstOrDefault()
                => ReadOnlyList.TryFirst<TEnumerable, TSource>(source, predicate).DefaultOnEmpty();
            public TSource FirstOrDefault(Func<TSource, bool> predicate)
                => ReadOnlyList.TryFirst<TEnumerable, TSource>(source, Utils.Combine(this.predicate, predicate)).DefaultOnEmpty();
            public (ElementResult Success, TSource Value) TryFirst()
                => ReadOnlyList.TryFirst<TEnumerable, TSource>(source, predicate);
            public (ElementResult Success, TSource Value) TryFirst(Func<TSource, bool> predicate)
                => ReadOnlyList.TryFirst<TEnumerable, TSource>(source, Utils.Combine(this.predicate, predicate));

            public TSource Single()
                => ReadOnlyList.TrySingle<TEnumerable, TSource>(source, predicate).ThrowOnEmpty();
            public TSource Single(Func<TSource, bool> predicate)
                => ReadOnlyList.TrySingle<TEnumerable, TSource>(source, Utils.Combine(this.predicate, predicate)).ThrowOnEmpty();
            public TSource SingleOrDefault()
                => ReadOnlyList.TrySingle<TEnumerable, TSource>(source, predicate).DefaultOnEmpty();
            public TSource SingleOrDefault(Func<TSource, bool> predicate)
                => ReadOnlyList.TrySingle<TEnumerable, TSource>(source, Utils.Combine(this.predicate, predicate)).DefaultOnEmpty();
            public (ElementResult Success, TSource Value) TrySingle()
                => ReadOnlyList.TrySingle<TEnumerable, TSource>(source, predicate);
            public (ElementResult Success, TSource Value) TrySingle(Func<TSource, bool> predicate)
                => ReadOnlyList.TrySingle<TEnumerable, TSource>(source, Utils.Combine(this.predicate, predicate));

            public List<TSource> ToList()
                => ReadOnlyList.ToList<TEnumerable, TSource>(source, predicate, skipCount, takeCount);
        }
    }
}

