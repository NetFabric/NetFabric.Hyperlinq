using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static RangeReadOnlyList Range(int start, int count)
        {
            var max = ((long)start) + count - 1;
            if (count < 0 || max > int.MaxValue) ThrowCountOutOfRange();

            return new RangeReadOnlyList(start, count);

            void ThrowCountOutOfRange() => throw new ArgumentOutOfRangeException(nameof(count));
        }

        public readonly struct RangeReadOnlyList
            : IValueReadOnlyList<int, RangeReadOnlyList.ValueEnumerator>
        {
            readonly int start;
            readonly int count;

            internal RangeReadOnlyList(int start, int count)
            {
                this.start = start;
                this.count = count;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public int Count() => count;

            public int this[int index]
            {
                get
                {
                    if(index < 0 || index >= count) ThrowIndexOutOfRange();

                    return index + start;

                    void ThrowIndexOutOfRange() => throw new IndexOutOfRangeException();
                }
            }

            public struct Enumerator 
            {
                readonly int end;
                int current;

                internal Enumerator(in RangeReadOnlyList enumerable)
                {
                    current = enumerable.start - 1;
                    end = checked(enumerable.start + enumerable.count);
                }

                public int Current => current;

                public bool MoveNext() => ++current < end;
            }

            public struct ValueEnumerator
                : IValueEnumerator<int>
            {
                readonly int end;
                int current;

                internal ValueEnumerator(in RangeReadOnlyList enumerable)
                {
                    current = enumerable.start - 1;
                    end = checked(enumerable.start + enumerable.count);
                }

                public bool TryMoveNext(out int current)
                {
                    if (++this.current < end)
                    {
                        current = this.current;
                        return true;
                    }
                    current = default;
                    return false;
                }

                public bool TryMoveNext() => ++current < end;

                public void Dispose() { }
            }

            public ValueReadOnlyList.SelectValueReadOnlyList<RangeReadOnlyList, ValueEnumerator, int, TResult> Select<TResult>(Func<int, TResult> selector) 
                => ValueReadOnlyList.Select<RangeReadOnlyList, ValueEnumerator, int, TResult>(this, selector);

            public ValueReadOnlyList.WhereValueReadOnlyList<RangeReadOnlyList, ValueEnumerator, int> Where(Func<int, bool> predicate) 
                => ValueReadOnlyList.Where<RangeReadOnlyList, ValueEnumerator, int>(this, predicate);

            public int First() 
                => ValueReadOnlyList.First<RangeReadOnlyList, ValueEnumerator, int>(this);
            public int First(Func<int, bool> predicate) 
                => ValueReadOnlyList.First<RangeReadOnlyList, ValueEnumerator, int>(this, predicate);

            public int FirstOrDefault() 
                => ValueReadOnlyList.FirstOrDefault<RangeReadOnlyList, ValueEnumerator, int>(this);
            public int FirstOrDefault(Func<int, bool> predicate) 
                => ValueReadOnlyList.FirstOrDefault<RangeReadOnlyList, ValueEnumerator, int>(this, predicate);

            public int Single() 
                => ValueReadOnlyList.Single<RangeReadOnlyList, ValueEnumerator, int>(this);
            public int Single(Func<int, bool> predicate) 
                => ValueReadOnlyList.Single<RangeReadOnlyList, ValueEnumerator, int>(this, predicate);

            public int SingleOrDefault() 
                => ValueReadOnlyList.SingleOrDefault<RangeReadOnlyList, ValueEnumerator, int>(this);
            public int SingleOrDefault(Func<int, bool> predicate) 
                => ValueReadOnlyList.SingleOrDefault<RangeReadOnlyList, ValueEnumerator, int>(this, predicate);

            public IEnumerable<int> AsEnumerable()
                => ValueEnumerable.AsEnumerable<RangeReadOnlyList, ValueEnumerator, int>(this);

            public IReadOnlyCollection<int> AsReadOnlyCollection()
                => ValueReadOnlyCollection.AsReadOnlyCollection<RangeReadOnlyList, ValueEnumerator, int>(this);

            public IReadOnlyList<int> AsReadOnlyList()
                => ValueReadOnlyList.AsReadOnlyList<RangeReadOnlyList, ValueEnumerator, int>(this);

            public int[] ToArray()
                => ValueReadOnlyList.ToArray<RangeReadOnlyList, ValueEnumerator, int>(this);

            public List<int> ToList()
                => ValueReadOnlyCollection.ToList<RangeReadOnlyList, ValueEnumerator, int>(this);
        }
    }
}

