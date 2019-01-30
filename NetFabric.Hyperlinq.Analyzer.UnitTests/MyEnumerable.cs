using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.Analyzer.UnitTests
{
    public interface IMyEnumerable<out T>
    {
        IMyEnumerator<T> GetEnumerator();
    }

    public interface IMyEnumerator<out T>
    {
        T Current { get; }
        bool MoveNext();
    }

    public interface IMyReadOnlyCollection<out T> : IMyEnumerable<T>
    {
        int Count { get; }
    }

    public interface IMyReadOnlyList<out T> : IMyReadOnlyCollection<T>
    {
        T this[int index] { get; }
    }

    public static class MyEnumerable
    {
        public static MyRangeEnumerable RangeValueType(int start, int count)
        {
            var max = ((long)start) + count - 1;
            if (count < 0 || max > int.MaxValue)
                ThrowCountOutOfRange();

            return new MyRangeEnumerable(start, count);

            void ThrowCountOutOfRange() => throw new ArgumentOutOfRangeException(nameof(count));
        }

        public static IEnumerable<int> RangeReferenceType(int start, int count)
        {
            var max = ((long)start) + count - 1;
            if (count < 0 || max > int.MaxValue)
                ThrowCountOutOfRange();

            for (var value = start; value < max; value++)
                yield return value;

            void ThrowCountOutOfRange() => throw new ArgumentOutOfRangeException(nameof(count));
        }

        public readonly struct MyRangeEnumerable : IMyReadOnlyList<int>
        {
            readonly int start;
            readonly int count;

            internal MyRangeEnumerable(int start, int count)
            {
                this.start = start;
                this.count = count;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IMyEnumerator<int> IMyEnumerable<int>.GetEnumerator() => new Enumerator(in this);

            public int Count => count;

            public int this[int index]
            {
                get
                {
                    if (index < 0 || index >= count)
                        ThrowIndexOutOfRange();
                    return index + start;

                    void ThrowIndexOutOfRange() => throw new IndexOutOfRangeException();
                }
            }

            public struct Enumerator : IMyEnumerator<int>
            {
                int current;
                readonly int end;

                internal Enumerator(in MyRangeEnumerable enumerable)
                {
                    current = enumerable.start - 1;
                    end = checked(enumerable.start + enumerable.count);
                }

                public int Current => current;

                public bool MoveNext() => ++current < end;
            }
        }
    }
}
