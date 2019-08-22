using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        [Pure]
        public static RangeEnumerable Range(int start, int count)
        {
            if (count < 0) ThrowHelper.ThrowArgumentOutOfRangeException(nameof(count));

            var end = 0;
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
        [GenericsTypeMapping("TSource", typeof(int))]
        public readonly struct RangeEnumerable
            : IValueReadOnlyList<int, RangeEnumerable.Enumerator>
        {
            readonly int start;
            readonly int count;
            readonly int end;

            internal RangeEnumerable(int start, int count, int end)
            {
                this.start = start;
                this.count = count;
                this.end = end;
            }

            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<int> IEnumerable<int>.GetEnumerator() => ValueEnumerator.ToEnumerator<int, Enumerator>(new Enumerator(in this));
            readonly IEnumerator IEnumerable.GetEnumerator() => ValueEnumerator.ToEnumerator<int, Enumerator>(new Enumerator(in this));

            public readonly int Count => count;

            public readonly int this[int index]
            {
                get
                {
                    if (index < 0 || index >= count) ThrowHelper.ThrowIndexOutOfRangeException();

                    return index + start;
                }
            }

            public struct Enumerator
                : IValueEnumerator<int>
            {
                readonly int end;
                int current;

                internal Enumerator(in RangeEnumerable enumerable)
                {
                    current = enumerable.start - 1;
                    end = enumerable.end;
                }

                public readonly int Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => current;
                }

                public bool MoveNext() => ++this.current < end;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RangeEnumerable Skip(int count)
            {
                (var skipCount, var takeCount) = Utils.Skip(this.count, count);
                return Range(start + skipCount, takeCount);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RangeEnumerable Take(int count)
                => Range(start, Utils.Take(this.count, count));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => count != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(int value)
                => value >= start && value < start + count;
                
            public int[] ToArray()
            {
                var array = new int[count];
                for(var index = 0; index < count; index++)
                    array[index] = start + index;
                return array;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<int> ToList()
                => new List<int>(new ToListCollection(this));

            public Dictionary<TKey, int> ToDictionary<TKey>(Func<int, TKey> keySelector)
                => ToDictionary<TKey>(keySelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, int> ToDictionary<TKey>(Func<int, TKey> keySelector, IEqualityComparer<TKey> comparer)
            {
                var dictionary = new Dictionary<TKey, int>(count, comparer);

                var end = start + count;
                for (var index = start; index < end; index++)
                    dictionary.Add(keySelector(index), index);

                return dictionary;
            }

            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<int, TKey> keySelector, Func<int, TElement> elementSelector)
                => ToDictionary<TKey, TElement>(keySelector, elementSelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<int, TKey> keySelector, Func<int, TElement> elementSelector, IEqualityComparer<TKey> comparer)
            {
                var dictionary = new Dictionary<TKey, TElement>(count, comparer);

                var end = start + count;
                for (var index = start; index < end; index++)
                    dictionary.Add(keySelector(index), elementSelector(index));

                return dictionary;
            }

            // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
            sealed class ToListCollection
                : ICollection<int>
            {
                readonly int start;
                readonly int count;

                public ToListCollection(in RangeEnumerable source)
                {
                    this.start = source.start;
                    this.count = source.count;
                }

                public int Count => count;

                public bool IsReadOnly => true;

                public void CopyTo(int[] array, int _)
                {
                    for(var index = 0; index < count; index++)
                        array[index] = start + index;
                }

                IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
                IEnumerator<int> IEnumerable<int>.GetEnumerator() => throw new NotSupportedException();
                void ICollection<int>.Add(int item) => throw new NotSupportedException();
                bool ICollection<int>.Remove(int item) => throw new NotSupportedException();
                void ICollection<int>.Clear() => throw new NotSupportedException();
                bool ICollection<int>.Contains(int item) => throw new NotSupportedException();
            }
        }
    }
}

