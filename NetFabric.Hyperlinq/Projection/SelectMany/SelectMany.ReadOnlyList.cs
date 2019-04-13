using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this TEnumerable source, 
            Func<TSource, TSubEnumerable> selector)
            where TEnumerable : IReadOnlyList<TSource>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
        {
            if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>(source, selector);
        }

        public readonly struct SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>
            : IValueEnumerable<TResult, SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>.ValueEnumerator>
            where TEnumerable : IReadOnlyList<TSource>
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
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public struct Enumerator
                : IDisposable
            {
                readonly TEnumerable source;
                readonly Func<TSource, TSubEnumerable> selector;
                readonly int sourceCount;
                int sourceIndex;
                TSubEnumerator subEnumerator;
                TResult current;
                int state;

                internal Enumerator(in SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    sourceCount = source.Count;
                    sourceIndex = -1;
                    subEnumerator = default;
                    current = default;
                    state = 0;
                }

                public TResult Current => current;

                public bool MoveNext() 
                {
                    switch (state)
                    {
                        case 0:
                            state = 1;
                            goto case 1;

                        case 1:
                            if (++sourceIndex >= sourceCount)
                                break;

                            var enumerable = selector(source[sourceIndex]);
                            subEnumerator = enumerable.GetValueEnumerator();
                            
                            state = 2;
                            goto case 2;

                        case 2:
                            if (!subEnumerator.TryMoveNext(out var subCurrent))
                            {
                                subEnumerator.Dispose();
                                state = 1;
                                goto case 1;
                            }

                            current = subCurrent;
                            return true;
                    }

                    current = default;
                    return false;
                }

                public void Dispose()
                {
                    if (state != 0)
                        subEnumerator.Dispose();
                }
            }

            public struct ValueEnumerator
                : IValueEnumerator<TResult>
            {
                readonly TEnumerable source;
                readonly Func<TSource, TSubEnumerable> selector;
                readonly int sourceCount;
                int sourceIndex;
                TSubEnumerator subEnumerator;
                int state;

                internal ValueEnumerator(in SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    sourceCount = source.Count;
                    sourceIndex = -1;
                    subEnumerator = default;
                    state = 0;
                }

                public bool TryMoveNext(out TResult current)
                {
                    switch (state)
                    {
                        case 0:
                            state = 1;
                            goto case 1;

                        case 1:
                            if (++sourceIndex >= sourceCount)
                                break;

                            var enumerable = selector(source[sourceIndex]);
                            subEnumerator = enumerable.GetValueEnumerator();
                            
                            state = 2;
                            goto case 2;

                        case 2:
                            if (!subEnumerator.TryMoveNext(out var subCurrent))
                            {
                                subEnumerator.Dispose();
                                state = 1;
                                goto case 1;
                            }

                            current = subCurrent;
                            return true;
                    }

                    current = default;
                    return false;
                }

                public bool TryMoveNext() 
                {
                    switch (state)
                    {
                        case 0:
                            state = 1;
                            goto case 1;

                        case 1:
                            if (++sourceIndex >= sourceCount)
                                break;

                            var enumerable = selector(source[sourceIndex]);
                            subEnumerator = enumerable.GetValueEnumerator();
                            
                            state = 2;
                            goto case 2;

                        case 2:
                            if (!subEnumerator.TryMoveNext())
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
                }
            }

            public int Count()
                => ValueEnumerable.Count<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult>(this);

            public int Count(Func<TResult, bool> predicate)
                => ValueEnumerable.Count<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult>(this, predicate);

            public ValueEnumerable.SkipEnumerable<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult> Skip(int count)
                => ValueEnumerable.Skip<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult>(this, count);

            public ValueEnumerable.TakeEnumerable<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult> Take(int count)
                => ValueEnumerable.Take<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult>(this, count);

            public bool All(Func<TResult, bool> predicate)
                => ValueEnumerable.All<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool Any()
                => ValueEnumerable.Any<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult>(this);

            public bool Any(Func<TResult, bool> predicate)
                => ValueEnumerable.Any<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult>(this, predicate);

            public bool Contains(TResult value)
                => ValueEnumerable.Contains<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult>(this, value);

            public bool Contains(TResult value, IEqualityComparer<TResult> comparer)
                => ValueEnumerable.Contains<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult>(this, value, comparer);

            public ValueEnumerable.SelectEnumerable<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult, TSelectorResult> Select<TSelectorResult>(Func<TResult, TSelectorResult> selector)
                 => ValueEnumerable.Select<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult, TSelectorResult>(this, selector);

            public ValueEnumerable.WhereEnumerable<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult> Where(Func<TResult, bool> predicate)
                => ValueEnumerable.Where<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult First()
                => ValueEnumerable.First<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult>(this);
            public TResult First(Func<TResult, bool> predicate)
                => ValueEnumerable.First<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult FirstOrDefault()
                => ValueEnumerable.FirstOrDefault<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult>(this);
            public TResult FirstOrDefault(Func<TResult, bool> predicate)
                => ValueEnumerable.FirstOrDefault<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult Single()
                => ValueEnumerable.Single<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult>(this);
            public TResult Single(Func<TResult, bool> predicate)
                => ValueEnumerable.Single<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult>(this, predicate);

            public TResult SingleOrDefault()
                => ValueEnumerable.SingleOrDefault<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult>(this);
            public TResult SingleOrDefault(Func<TResult, bool> predicate)
                => ValueEnumerable.SingleOrDefault<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult>(this, predicate);

            public IEnumerable<TResult> AsEnumerable()
                => ValueEnumerable.AsEnumerable<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult>(this);

            public SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult> AsValueEnumerable()
                => this;

            public TResult[] ToArray()
                => ValueEnumerable.ToArray<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult>(this);

            public List<TResult> ToList()
                => ValueEnumerable.ToList<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, ValueEnumerator, TResult>(this);
        }

        public static TResult? FirstOrNull<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>(this SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult> source)
            where TEnumerable : IReadOnlyList<TSource>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
            where TResult : struct
            => ValueEnumerable.FirstOrNull<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>.ValueEnumerator, TResult>(source);

        public static TResult? FirstOrNull<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>(this SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult> source, Func<TResult, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
            where TResult : struct
            => ValueEnumerable.FirstOrNull<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>.ValueEnumerator, TResult>(source, predicate);

        public static TResult? SingleOrNull<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>(this SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult> source)
            where TEnumerable : IReadOnlyList<TSource>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
            where TResult : struct
            => ValueEnumerable.SingleOrNull<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>.ValueEnumerator, TResult>(source);

        public static TResult? SingleOrNull<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>(this SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult> source, Func<TResult, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
            where TResult : struct
            => ValueEnumerable.SingleOrNull<SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>, SelectManyEnumerable<TEnumerable, TSource, TSubEnumerable, TSubEnumerator, TResult>.ValueEnumerator, TResult>(source, predicate);
    }
}

