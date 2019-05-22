using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static RangeEnumerable Range(long start, long count)
        {
            if (count < 0) ThrowHelper.ThrowArgumentOutOfRangeException(nameof(count));

            var end = 0L;
            try
            {
                end = checked(start + count);
            }
            catch(OverflowException)
            {
                ThrowHelper.ThrowArgumentOutOfRangeException(nameof(count));
            }   

            return new RangeEnumerable(start, count, end);
        }

        [GenericsTypeMapping("TEnumerable", typeof(RangeEnumerable))]
        [GenericsTypeMapping("TEnumerator", typeof(RangeEnumerable.Enumerator))]
        [GenericsTypeMapping("TSource", typeof(long))]
        public readonly struct RangeEnumerable
            : IValueReadOnlyList<long, RangeEnumerable.Enumerator>
        {
            readonly long start;
            readonly long count;
            readonly long end;

            internal RangeEnumerable(long start, long count, long end)
            {
                this.start = start;
                this.count = count;
                this.end = end;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public long Count => count;

            public long this[long index]
            {
                get
                {
                    if (index < 0 || index >= count) ThrowHelper.ThrowIndexOutOfRangeException();

                    return index + start;
                }
            }

            public struct Enumerator
                : IValueEnumerator<long>
            {
                readonly long end;
                long current;

                internal Enumerator(in RangeEnumerable enumerable)
                {
                    current = enumerable.start - 1;
                    end = enumerable.end;
                }

                public long Current
                    => current;

                public bool MoveNext()
                    => ++this.current < end;

                public void Dispose() { }
            }

            public RangeEnumerable Skip(long count)
            {
                (var skipCount, var takeCount) = Utils.Skip(this.count, count);
                return Range(start + skipCount, takeCount);
            }

            public RangeEnumerable Take(long count)
                => Range(start, Utils.Take(this.count, count));

            public bool Any()
                => count != 0;

            public bool Contains(long value)
                => value >= start && value < start + count;
                
            public long[] ToArray()
            {
                var array = new long[count];
                for(var index = 0L; index < count; index++)
                    array[index] = start + index;
                return array;
            }

            public List<long> ToList()
                => new List<long>(new ToListCollection(this));

            // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
            struct ToListCollection
                : ICollection<long>
            {
                readonly long start;
                readonly long count;

                public ToListCollection(in RangeEnumerable source)
                {
                    this.start = source.start;
                    this.count = source.count;
                }

                public int Count => (int)count;

                public bool IsReadOnly => true;

                public void CopyTo(long[] array, int _)
                {
                    for(var index = 0L; index < count; index++)
                        array[index] = start + index;
                }

                IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
                IEnumerator<long> IEnumerable<long>.GetEnumerator() => throw new NotSupportedException();
                void ICollection<long>.Add(long item) => throw new NotSupportedException();
                bool ICollection<long>.Remove(long item) => throw new NotSupportedException();
                void ICollection<long>.Clear() => throw new NotSupportedException();
                bool ICollection<long>.Contains(long item) => throw new NotSupportedException();
            }
        }
    }
}

