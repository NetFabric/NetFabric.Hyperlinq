using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return new WhereIndexEnumerable<TEnumerable, TEnumerator, TSource>(in source, predicate, 0, source.Count);
        }

        static WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate, long skipCount, long takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => new WhereIndexEnumerable<TEnumerable, TEnumerator, TSource>(in source, predicate, skipCount, takeCount);

        [GenericsTypeMapping("TEnumerable", typeof(WhereIndexEnumerable<,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(WhereIndexEnumerable<,,>.Enumerator))]
        public readonly struct WhereIndexEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, WhereIndexEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, long, bool> predicate;
            readonly long skipCount;
            readonly long takeCount;

            internal WhereIndexEnumerable(in TEnumerable source, Func<TSource, long, bool> predicate, long skipCount, long takeCount)
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
                readonly Func<TSource, long, bool> predicate;
                readonly long end;
                long index;

                internal Enumerator(in WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
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
                        if (predicate(source[index], index))
                            return true;
                    }
                    return false;
                }

                public void Dispose() { }
            }

            public long Count()
                => ValueReadOnlyList.Count<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount);
            public long Count(Func<TSource, bool> predicate)
                => ValueReadOnlyList.Count<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            public long Count(Func<TSource, long, bool> predicate)
                => ValueReadOnlyList.Count<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            public bool All()
                => ValueReadOnlyList.All<TEnumerable, TEnumerator, TSource>(source, predicate);
            public bool All(Func<TSource, bool> predicate)
                => ValueReadOnlyList.All<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));
            public bool All(Func<TSource, long, bool> predicate)
                => ValueReadOnlyList.All<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public bool Any()
                => ValueReadOnlyList.Any<TEnumerable, TEnumerator, TSource>(source, predicate);
            public bool Any(Func<TSource, bool> predicate)
                => ValueReadOnlyList.Any<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));
            public bool Any(Func<TSource, long, bool> predicate)
                => ValueReadOnlyList.Any<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public ValueReadOnlyList.WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> Where(Func<TSource, long, bool> predicate)
                => ValueReadOnlyList.Where<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public TSource First()
                => ValueReadOnlyList.TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate).ThrowOnEmpty();
            public TSource First(Func<TSource, bool> predicate)
                => ValueReadOnlyList.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate)).ThrowOnEmpty();
            public TSource FirstOrDefault()
                => ValueReadOnlyList.TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate).DefaultOnEmpty();
            public TSource FirstOrDefault(Func<TSource, bool> predicate)
                => ValueReadOnlyList.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate)).DefaultOnEmpty();
            public (long Index, TSource Value) TryFirst()
                => ValueReadOnlyList.TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate);
            public (long Index, TSource Value) TryFirst(Func<TSource, bool> predicate)
                => ValueReadOnlyList.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));
            public (long Index, TSource Value) TryFirst(Func<TSource, long, bool> predicate)
                => ValueReadOnlyList.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public TSource Single()
                => ValueReadOnlyList.TrySingle<TEnumerable, TEnumerator, TSource>(source, predicate).ThrowOnEmpty();
            public TSource Single(Func<TSource, bool> predicate)
                => ValueReadOnlyList.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate)).ThrowOnEmpty();
            public TSource SingleOrDefault()
                => ValueReadOnlyList.TrySingle<TEnumerable, TEnumerator, TSource>(source, predicate).DefaultOnEmpty();
            public TSource SingleOrDefault(Func<TSource, bool> predicate)
                => ValueReadOnlyList.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate)).DefaultOnEmpty();
            public (long Index, TSource Value) TrySingle()
                => ValueReadOnlyList.TrySingle<TEnumerable, TEnumerator, TSource>(source, predicate);
            public (long Index, TSource Value) TrySingle(Func<TSource, bool> predicate)
                => ValueReadOnlyList.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));
            public (long Index, TSource Value) TrySingle(Func<TSource, long, bool> predicate)
                => ValueReadOnlyList.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate));

            public List<TSource> ToList()
                => ValueReadOnlyList.ToList<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount);
        }
    }
}

