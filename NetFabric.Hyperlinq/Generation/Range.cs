using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static RangeEnumerable Range(int start, int count)
        {
            var max = ((long)start) + count - 1;
            if (count < 0 || max > int.MaxValue) ThrowHelper.ThrowArgumentOutOfRangeException(nameof(count));

            return new RangeEnumerable(start, count);
        }

        public readonly struct RangeEnumerable
            : IValueReadOnlyList<int, RangeEnumerable.ValueEnumerator>
        {
            readonly int start;
            readonly int count;

            internal RangeEnumerable(int start, int count)
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
                    if (index < 0 || index >= count) ThrowHelper.ThrowIndexOutOfRangeException();

                    return index + start;
                }
            }

            public struct Enumerator 
            {
                readonly int end;
                int current;

                internal Enumerator(in RangeEnumerable enumerable)
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

                internal ValueEnumerator(in RangeEnumerable enumerable)
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

            public int Count(Func<int, bool> predicate)
                => ValueReadOnlyList.Count<RangeEnumerable, ValueEnumerator, int>(this, predicate);

            public ValueReadOnlyList.SelectEnumerable<RangeEnumerable, ValueEnumerator, int, TResult> Select<TResult>(Func<int, TResult> selector) 
                => ValueReadOnlyList.Select<RangeEnumerable, ValueEnumerator, int, TResult>(this, selector);

            public ValueReadOnlyList.WhereEnumerable<RangeEnumerable, ValueEnumerator, int> Where(Func<int, bool> predicate) 
                => ValueReadOnlyList.Where<RangeEnumerable, ValueEnumerator, int>(this, predicate);

            public int First() 
                => (count > 0) ? start : ThrowHelper.ThrowEmptySequence<int>();
            public int First(Func<int, bool> predicate) 
                => ValueReadOnlyList.First<RangeEnumerable, ValueEnumerator, int>(this, predicate);

            public int FirstOrDefault()
                => (count > 0) ? start : default;
            public int FirstOrDefault(Func<int, bool> predicate) 
                => ValueReadOnlyList.FirstOrDefault<RangeEnumerable, ValueEnumerator, int>(this, predicate);

            public int? FirstOrNull()
                => (count > 0) ? start : (int?)null;
            public int? FirstOrNull(Func<int, bool> predicate)
                => ValueReadOnlyList.FirstOrNull<RangeEnumerable, ValueEnumerator, int>(this, predicate);

            public int Single()
                => (count == 0) ? ThrowHelper.ThrowEmptySequence<int>() : ((count == 1) ? start : ThrowHelper.ThrowNotSingleSequence<int>());
            public int Single(Func<int, bool> predicate) 
                => ValueReadOnlyList.Single<RangeEnumerable, ValueEnumerator, int>(this, predicate);

            public int SingleOrDefault()
                => (count == 0) ? default : ((count == 1) ? start : ThrowHelper.ThrowNotSingleSequence<int>());
            public int SingleOrDefault(Func<int, bool> predicate) 
                => ValueReadOnlyList.SingleOrDefault<RangeEnumerable, ValueEnumerator, int>(this, predicate);

            public int? SingleOrNull()
                => (count == 0) ? null : ((count == 1) ? start : ThrowHelper.ThrowNotSingleSequence<int?>());
            public int? SingleOrNull(Func<int, bool> predicate)
                => ValueReadOnlyList.SingleOrNull<RangeEnumerable, ValueEnumerator, int>(this, predicate);

            public IEnumerable<int> AsEnumerable()
                => ValueEnumerable.AsEnumerable<RangeEnumerable, ValueEnumerator, int>(this);

            public IReadOnlyCollection<int> AsReadOnlyCollection()
                => ValueReadOnlyCollection.AsReadOnlyCollection<RangeEnumerable, ValueEnumerator, int>(this);

            public IReadOnlyList<int> AsReadOnlyList()
                => ValueReadOnlyList.AsReadOnlyList<RangeEnumerable, ValueEnumerator, int>(this);

            public int[] ToArray()
            {
                var array = new int[count];
                for (int index = 0, value = start; index < count; index++, value++)
                    array[index] = value;
                return array;
            }

            public List<int> ToList()
            {
                var list = new List<int>(count);
                var end = start + count;
                for (var value = start; value < end; value++)
                    list.Add(value);
                return list;
            }
        }
    }
}

