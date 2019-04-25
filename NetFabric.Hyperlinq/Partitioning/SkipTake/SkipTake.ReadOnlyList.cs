using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static SkipTakeEnumerable<TEnumerable, TSource> SkipTake<TEnumerable, TSource>(this TEnumerable source, int skipCount, int takeCount)
            where TEnumerable : IReadOnlyList<TSource>
            => new SkipTakeEnumerable<TEnumerable, TSource>(in source, skipCount, takeCount);

        public readonly struct SkipTakeEnumerable<TEnumerable, TSource>
            : IValueReadOnlyList<TSource, SkipTakeEnumerable<TEnumerable, TSource>.ValueEnumerator>
            where TEnumerable : IReadOnlyList<TSource>
        {
            readonly TEnumerable source;
            readonly int skipCount;
            readonly int takeCount;

            internal SkipTakeEnumerable(in TEnumerable source, int skipCount, int takeCount)
            {
                this.source = source;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            public int Count => takeCount;
            long IValueReadOnlyCollection<TSource, ValueEnumerator>.Count => takeCount;

            public TSource this[int index]
            {
                get
                {
                    if (index < 0 || index >= takeCount) 
                        ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));

                    return source[index + skipCount];
                }
            }

            TSource IValueReadOnlyList<TSource, ValueEnumerator>.this[long index]
            {
                get
                {
                    if (index > int.MaxValue) 
                        ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));

                    return this[(int)index];
                }
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public struct Enumerator
            {
                readonly TEnumerable source;
                readonly int end;
                int index;

                internal Enumerator(in SkipTakeEnumerable<TEnumerable, TSource> enumerable)
                {
                    source = enumerable.source;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public TSource Current => source[index];

                public bool MoveNext() => ++index < end;
            }

            public struct ValueEnumerator
                : IValueEnumerator<TSource>
            {
                readonly TEnumerable source;
                readonly int end;
                int index;

                internal ValueEnumerator(in SkipTakeEnumerable<TEnumerable, TSource> enumerable)
                {
                    source = enumerable.source;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public bool TryMoveNext(out TSource current)
                {
                    index++;
                    if (index < end)
                    {
                        current = source[index];
                        return true;
                    }
                    current = default;
                    return false;
                }

                public bool TryMoveNext() => ++index < end;

                public void Dispose() { }
            }

            public ValueReadOnlyList.SkipTakeEnumerable<SkipTakeEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource> Skip(int count)
                => ValueReadOnlyList.Skip<SkipTakeEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this, count);

            public ValueReadOnlyList.SkipTakeEnumerable<SkipTakeEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource> Take(int count)
                => ValueReadOnlyList.Take<SkipTakeEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this, count);

            public bool All(Func<TSource, long, bool> predicate)
                => ValueReadOnlyList.All<SkipTakeEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this, predicate);

            public bool Any()
                => ValueReadOnlyList.Any<SkipTakeEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this);

            public bool Any(Func<TSource, long, bool> predicate)
                => ValueReadOnlyList.Any<SkipTakeEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this, predicate);

            public bool Contains(TSource value)
                => ValueReadOnlyList.Contains<SkipTakeEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this, value);

            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => ValueReadOnlyList.Contains<SkipTakeEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this, value, comparer);

            public ValueReadOnlyList.SelectEnumerable<SkipTakeEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource, TResult> Select<TResult>(Func<TSource, long, TResult> selector)
                 => ValueReadOnlyList.Select<SkipTakeEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource, TResult>(this, selector);

            public ValueEnumerable.WhereEnumerable<SkipTakeEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource> Where(Func<TSource, long, bool> predicate)
                => ValueEnumerable.Where<SkipTakeEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource First()
                => ValueReadOnlyList.First<SkipTakeEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this);
            public TSource First(Func<TSource, long, bool> predicate)
                => ValueEnumerable.First<SkipTakeEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource FirstOrDefault()
                => ValueReadOnlyList.FirstOrDefault<SkipTakeEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this);
            public TSource FirstOrDefault(Func<TSource, long, bool> predicate)
                => ValueEnumerable.FirstOrDefault<SkipTakeEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource Single()
                => ValueReadOnlyList.Single<SkipTakeEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this);
            public TSource Single(Func<TSource, long, bool> predicate)
                => ValueReadOnlyList.Single<SkipTakeEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource SingleOrDefault()
                => ValueReadOnlyList.SingleOrDefault<SkipTakeEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this);
            public TSource SingleOrDefault(Func<TSource, long, bool> predicate)
                => ValueReadOnlyList.SingleOrDefault<SkipTakeEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this, predicate);

            public IReadOnlyList<TSource> AsEnumerable()
                => ValueReadOnlyList.AsEnumerable<SkipTakeEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this);

            public SkipTakeEnumerable<TEnumerable, TSource> AsValueEnumerable()
                => this;

            public SkipTakeEnumerable<TEnumerable, TSource> AsValueReadOnlyList()
                => this;

            public TSource[] ToArray()
                => ValueReadOnlyList.ToArray<SkipTakeEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this);

            public List<TSource> ToList()
                => ValueEnumerable.ToList<SkipTakeEnumerable<TEnumerable, TSource>, ValueEnumerator, TSource>(this);
        }

        public static int Count<TEnumerable, TSource>(this SkipTakeEnumerable<TEnumerable, TSource> source)
            where TEnumerable : IReadOnlyList<TSource>
            => (int)source.Count;

        public static int Count<TEnumerable, TSource>(this SkipTakeEnumerable<TEnumerable, TSource> source, Func<TSource, long, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
            => (int)ValueReadOnlyList.Count<SkipTakeEnumerable<TEnumerable, TSource>, SkipTakeEnumerable<TEnumerable, TSource>.ValueEnumerator, TSource>(source, predicate);

        public static TSource? FirstOrNull<TEnumerable, TSource>(this SkipTakeEnumerable<TEnumerable, TSource> source)
            where TEnumerable : IReadOnlyList<TSource>
            where TSource : struct
            => ValueReadOnlyList.FirstOrNull<SkipTakeEnumerable<TEnumerable, TSource>, SkipTakeEnumerable<TEnumerable, TSource>.ValueEnumerator, TSource>(source);

        public static TSource? FirstOrNull<TEnumerable, TSource>(this SkipTakeEnumerable<TEnumerable, TSource> source, Func<TSource, long, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
            where TSource : struct
            => ValueEnumerable.FirstOrNull<SkipTakeEnumerable<TEnumerable, TSource>, SkipTakeEnumerable<TEnumerable, TSource>.ValueEnumerator, TSource>(source, predicate);

        public static TSource? SingleOrNull<TEnumerable, TSource>(this SkipTakeEnumerable<TEnumerable, TSource> source)
            where TEnumerable : IReadOnlyList<TSource>
            where TSource : struct
            => ValueReadOnlyList.SingleOrNull<SkipTakeEnumerable<TEnumerable, TSource>, SkipTakeEnumerable<TEnumerable, TSource>.ValueEnumerator, TSource>(source);

        public static TSource? SingleOrNull<TEnumerable, TSource>(this SkipTakeEnumerable<TEnumerable, TSource> source, Func<TSource, long, bool> predicate)
            where TEnumerable : IReadOnlyList<TSource>
            where TSource : struct
            => ValueReadOnlyList.SingleOrNull<SkipTakeEnumerable<TEnumerable, TSource>, SkipTakeEnumerable<TEnumerable, TSource>.ValueEnumerator, TSource>(source, predicate);
    }
}