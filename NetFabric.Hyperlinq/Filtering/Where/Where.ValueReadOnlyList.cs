using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static WhereEnumerable<TEnumerable, TEnumerator, TSource> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return new WhereEnumerable<TEnumerable, TEnumerator, TSource>(in source, predicate, 0, source.Count);
        }

        static WhereEnumerable<TEnumerable, TEnumerator, TSource> Where<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new WhereEnumerable<TEnumerable, TEnumerator, TSource>(in source, predicate, skipCount, takeCount);

        [GenericsTypeMapping("TEnumerable", typeof(WhereEnumerable<,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(WhereEnumerable<,,>.Enumerator))]
        public readonly struct WhereEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, WhereEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
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
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IEnumerator<TSource>
            {
                readonly TEnumerable source;
                readonly Func<TSource, bool> predicate;
                readonly int end;
                int index;

                internal Enumerator(in WhereEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public TSource Current
                    => source[index];
                object IEnumerator.Current
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

                void IEnumerator.Reset()
                    => throw new NotSupportedException();

                public void Dispose() { }
            }

            public int Count()
                => ValueReadOnlyList.Count<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount);
            public int Count(Func<TSource, bool> predicate)
                => ValueReadOnlyList.Count<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            public int Count(Func<TSource, int, bool> predicate)
                => ValueReadOnlyList.Count<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            public bool Any()
                => ValueReadOnlyList.Any<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount);
            public bool Any(Func<TSource, bool> predicate)
                => ValueReadOnlyList.Any<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            public bool Any(Func<TSource, int, bool> predicate)
                => ValueReadOnlyList.Any<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            public ValueReadOnlyList.WhereSelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector)
                => ValueReadOnlyList.WhereSelect<TEnumerable, TEnumerator, TSource, TResult>(source, predicate, selector, skipCount, takeCount);

            public ValueReadOnlyList.WhereEnumerable<TEnumerable, TEnumerator, TSource> Where(Func<TSource, bool> predicate)
                => ValueReadOnlyList.Where<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            public ValueReadOnlyList.WhereIndexEnumerable<TEnumerable, TEnumerator, TSource> Where(Func<TSource, int, bool> predicate)
                => ValueReadOnlyList.Where<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            public TSource First()
                => ValueReadOnlyList.TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount).ThrowOnEmpty();
            public TSource First(Func<TSource, bool> predicate)
                => ValueReadOnlyList.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount).ThrowOnEmpty();
            public TSource First(Func<TSource, int, bool> predicate)
                => ValueReadOnlyList.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount).ThrowOnEmpty();

            public TSource FirstOrDefault()
                => ValueReadOnlyList.TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount).DefaultOnEmpty();
            public TSource FirstOrDefault(Func<TSource, bool> predicate)
                => ValueReadOnlyList.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount).DefaultOnEmpty();
            public TSource FirstOrDefault(Func<TSource, int, bool> predicate)
                => ValueReadOnlyList.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount).DefaultOnEmpty();

            public (ElementResult Success, TSource Value) TryFirst()
                => ValueReadOnlyList.TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount);
            public (ElementResult Success, TSource Value) TryFirst(Func<TSource, bool> predicate)
                => ValueReadOnlyList.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            public (int Index, TSource Value) TryFirst(Func<TSource, int, bool> predicate)
                => ValueReadOnlyList.TryFirst<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            public TSource Single()
                => ValueReadOnlyList.TrySingle<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount).ThrowOnEmpty();
            public TSource Single(Func<TSource, bool> predicate)
                => ValueReadOnlyList.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount).ThrowOnEmpty();
            public TSource Single(Func<TSource, int, bool> predicate)
                => ValueReadOnlyList.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount).ThrowOnEmpty();

            public TSource SingleOrDefault()
                => ValueReadOnlyList.TrySingle<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount).DefaultOnEmpty();
            public TSource SingleOrDefault(Func<TSource, bool> predicate)
                => ValueReadOnlyList.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount).DefaultOnEmpty();
            public TSource SingleOrDefault(Func<TSource, int, bool> predicate)
                => ValueReadOnlyList.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount).DefaultOnEmpty();

            public (ElementResult Success, TSource Value) TrySingle()
                => ValueReadOnlyList.TrySingle<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount);
            public (ElementResult Success, TSource Value) TrySingle(Func<TSource, bool> predicate)
                => ValueReadOnlyList.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);
            public (int Index, TSource Value) TrySingle(Func<TSource, int, bool> predicate)
                => ValueReadOnlyList.TrySingle<TEnumerable, TEnumerator, TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            public List<TSource> ToList()
                => ValueReadOnlyList.ToList<TEnumerable, TEnumerator, TSource>(source, predicate, skipCount, takeCount);
        }
    }
}

