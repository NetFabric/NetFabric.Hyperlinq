using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this TEnumerable source, 
            Func<TSource, TSubEnumerable> selector)
            where TEnumerable : IReadOnlyCollection<TSource> 
            where TEnumerator : IEnumerator<TSource> 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
        {
            if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(in source, selector);
        }

        public readonly struct SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>
            : IValueEnumerable<TResult, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>.Enumerator>
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
        {
            readonly TEnumerable source;
            readonly Func<TSource, TSubEnumerable> selector;

            internal SelectManyEnumerable(in TEnumerable source, Func<TSource, TSubEnumerable> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IValueEnumerator<TResult>
            {
                TEnumerator sourceEnumerator;
                readonly Func<TSource, TSubEnumerable> selector;
                TSubEnumerator subEnumerator;
                int state;

                internal Enumerator(in SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> enumerable)
                {
                    sourceEnumerator = (TEnumerator)enumerable.source.GetEnumerator();
                    selector = enumerable.selector;
                    subEnumerator = default;
                    state = 0;
                }

                public TResult Current
                    => subEnumerator.Current;

                public bool MoveNext()
                {
                    switch (state)
                    {
                        case 0:
                            state = 1;
                            goto case 1;

                        case 1:
                            if (!sourceEnumerator.MoveNext())
                                break;

                            var enumerable = selector(sourceEnumerator.Current);
                            subEnumerator = enumerable.GetEnumerator();
                            
                            state = 2;
                            goto case 2;

                        case 2:
                            if (!subEnumerator.MoveNext())
                            {
                                subEnumerator.Dispose();
                                state = 1;
                                goto case 1;
                            }
                            return true;
                    }
                    return false;
                }

                public void Dispose()
                {
                    if (state != 0)
                        subEnumerator.Dispose();
                    sourceEnumerator.Dispose();
                }
            }

            public long Count()
                => ValueEnumerable.Count<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult>(this);
            public long Count(Func<TResult, bool> predicate)
                => ValueEnumerable.Count<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult>(this, predicate);
            public long Count(Func<TResult, long, bool> predicate)
                => ValueEnumerable.Count<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult>(this, predicate);

            public ValueEnumerable.SkipEnumerable<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult> Skip(int count)
                => ValueEnumerable.Skip<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult>(this, count);

            public ValueEnumerable.TakeEnumerable<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult> Take(int count)
                => ValueEnumerable.Take<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult>(this, count);

            public bool All(Func<TResult, long, bool> predicate)
                => ValueEnumerable.All<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult>(this, predicate);

            public bool Any()
                => ValueEnumerable.Any<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult>(this);

            public bool Any(Func<TResult, long, bool> predicate)
                => ValueEnumerable.Any<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult>(this, predicate);

            public bool Contains(TResult value)
                => ValueEnumerable.Contains<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult>(this, value);

            public bool Contains(TResult value, IEqualityComparer<TResult> comparer)
                => ValueEnumerable.Contains<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult>(this, value, comparer);

            public ValueEnumerable.SelectEnumerable<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult, TSelectorResult> Select<TSelectorResult>(Func<TResult, long, TSelectorResult> selector)
                 => ValueEnumerable.Select<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult, TSelectorResult>(this, selector);

            public ValueEnumerable.WhereEnumerable<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult> Where(Func<TResult, long, bool> predicate)
                => ValueEnumerable.Where<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult>(this, predicate);

            public TResult First()
                => ValueEnumerable.First<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult>(this);
            public TResult First(Func<TResult, long, bool> predicate)
                => ValueEnumerable.First<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult>(this, predicate);

            public TResult FirstOrDefault()
                => ValueEnumerable.FirstOrDefault<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult>(this);
            public TResult FirstOrDefault(Func<TResult, long, bool> predicate)
                => ValueEnumerable.FirstOrDefault<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult>(this, predicate);

            public TResult Single()
                => ValueEnumerable.Single<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult>(this);
            public TResult Single(Func<TResult, long, bool> predicate)
                => ValueEnumerable.Single<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult>(this, predicate);

            public TResult SingleOrDefault()
                => ValueEnumerable.SingleOrDefault<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult>(this);
            public TResult SingleOrDefault(Func<TResult, long, bool> predicate)
                => ValueEnumerable.SingleOrDefault<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult>(this, predicate);

            public IEnumerable<TResult> AsEnumerable()
                => ValueEnumerable.AsEnumerable<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult>(this);

            public SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> AsValueEnumerable()
                => this;

            public TResult[] ToArray()
                => ValueEnumerable.ToArray<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult>(this);

            public List<TResult> ToList()
                => ValueEnumerable.ToList<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, Enumerator, TResult>(this);
        }

        public static TResult? FirstOrNull<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(this SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> source)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
            where TResult : struct
            => ValueEnumerable.FirstOrNull<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>.Enumerator, TResult>(source);

        public static TResult? FirstOrNull<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(this SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> source, Func<TResult, long, bool> predicate)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
            where TResult : struct
            => ValueEnumerable.FirstOrNull<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>.Enumerator, TResult>(source, predicate);

        public static TResult? SingleOrNull<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(this SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> source)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
            where TResult : struct
            => ValueEnumerable.SingleOrNull<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>.Enumerator, TResult>(source);

        public static TResult? SingleOrNull<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(this SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> source, Func<TResult, long, bool> predicate)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
            where TResult : struct
            => ValueEnumerable.SingleOrNull<SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>, SelectManyEnumerable<TEnumerable, TEnumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>.Enumerator, TResult>(source, predicate);
    }
}
