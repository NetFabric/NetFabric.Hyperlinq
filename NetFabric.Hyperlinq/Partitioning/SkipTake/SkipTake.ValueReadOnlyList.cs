using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> SkipTake<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => new SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>(in source, skipCount, takeCount);

        public readonly struct SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueReadOnlyList<TSource, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator>
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
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

            public TSource this[int index]
            {
                get
                {
                    if (index < 0 || index >= takeCount) 
                        ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));

                    return source[index + skipCount];
                }
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public struct Enumerator
            {
                readonly TEnumerable source;
                readonly int end;
                int index;

                internal Enumerator(in SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
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

                internal ValueEnumerator(in SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
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

            public ValueReadOnlyList.SkipTakeEnumerable<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource> Skip(int count)
                => ValueReadOnlyList.Skip<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, count);

            public ValueReadOnlyList.SkipTakeEnumerable<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource> Take(int count)
                => ValueReadOnlyList.Take<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, count);

            public bool All(Func<TSource, int, bool> predicate)
                => ValueReadOnlyList.All<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public bool Any()
                => ValueReadOnlyList.Any<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);

            public bool Any(Func<TSource, int, bool> predicate)
                => ValueReadOnlyList.Any<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public bool Contains(TSource value)
                => ValueReadOnlyList.Contains<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, value);

            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => ValueReadOnlyList.Contains<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, value, comparer);

            public ValueReadOnlyList.SelectEnumerable<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource, TResult> Select<TResult>(Func<TSource, int, TResult> selector)
                 => ValueReadOnlyList.Select<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource, TResult>(this, selector);

            public ValueEnumerable.WhereEnumerable<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource> Where(Func<TSource, int, bool> predicate)
                => ValueEnumerable.Where<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource First()
                => ValueReadOnlyList.First<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
            public TSource First(Func<TSource, int, bool> predicate)
                => ValueReadOnlyList.First<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource FirstOrDefault()
                => ValueReadOnlyList.FirstOrDefault<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
            public TSource FirstOrDefault(Func<TSource, int, bool> predicate)
                => ValueReadOnlyList.FirstOrDefault<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource Single()
                => ValueReadOnlyList.Single<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
            public TSource Single(Func<TSource, int, bool> predicate)
                => ValueReadOnlyList.Single<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource SingleOrDefault()
                => ValueReadOnlyList.SingleOrDefault<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
            public TSource SingleOrDefault(Func<TSource, int, bool> predicate)
                => ValueReadOnlyList.SingleOrDefault<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this, predicate);

            public IReadOnlyList<TSource> AsEnumerable()
                => ValueReadOnlyList.AsEnumerable<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);

            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> AsValueEnumerable()
                => this;

            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> AsValueReadOnlyList()
                => this;

            public TSource[] ToArray()
                => ValueReadOnlyList.ToArray<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);

            public List<TSource> ToList()
                => ValueEnumerable.ToList<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, ValueEnumerator, TSource>(this);
        }

        public static int Count<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => source.Count;

        public static int Count<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, int, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => ValueReadOnlyList.Count<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator, TSource>(source, predicate);

        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
            => ValueReadOnlyList.FirstOrNull<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator, TSource>(source);

        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, int, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
            => ValueReadOnlyList.FirstOrNull<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator, TSource>(source, predicate);

        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
            => ValueReadOnlyList.SingleOrNull<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator, TSource>(source);

        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source, Func<TSource, int, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
            => ValueReadOnlyList.SingleOrNull<SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.ValueEnumerator, TSource>(source, predicate);
    }
}