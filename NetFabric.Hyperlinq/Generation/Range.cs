using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        
        public static RangeEnumerable Range(int start, int count)
        {
            if (count < 0) Throw.ArgumentOutOfRangeException(nameof(count));

            var end = 0;
            try
            {
                end = checked(start + count);
            }
            catch(OverflowException)
            {
                Throw.ArgumentOutOfRangeException(nameof(count));
            }   

            return new RangeEnumerable(start, count, end);
        }

        [GeneratorMapping("TSource", "int", true)]
        public readonly partial struct RangeEnumerable
            : IValueReadOnlyList<int, RangeEnumerable.DisposableEnumerator>
            , IList<int>
        {
            readonly int start;
            readonly int end;

            internal RangeEnumerable(int start, int count, int end)
            {
                this.start = start;
                Count = count;
                this.end = end;
            }

            public readonly int Count { get; }

            public readonly int this[int index]
            {
                get
                {
                    if (index < 0 || index >= Count) Throw.IndexOutOfRangeException();

                    return index + start;
                }
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<int, DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<int> IEnumerable<int>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            [MaybeNull]
            int IList<int>.this[int index]
            {
                get => this[index];
                set => throw new NotSupportedException();
            }

            bool ICollection<int>.IsReadOnly  
                => true;

            void ICollection<int>.CopyTo(int[] array, int arrayIndex) 
            {
                if (arrayIndex == 0)
                {
                    for (var index = 0; index < Count; index++)
                        array[index] = index + start;
                }
                else
                {
                    for (var index = 0; index < Count; index++)
                        array[index + arrayIndex] = index + start;
                } 
            }
            
            void ICollection<int>.Add(int item) 
                => throw new NotSupportedException();
            void ICollection<int>.Clear() 
                => throw new NotSupportedException();
            bool ICollection<int>.Remove(int item) 
                => throw new NotSupportedException();
            int IList<int>.IndexOf(int item)
                => item >= 0 && item < Count
                ? item
                : -1;
            void IList<int>.Insert(int index, int item)
                => throw new NotSupportedException();
            void IList<int>.RemoveAt(int index)
                => throw new NotSupportedException();

            public struct Enumerator
            {
                readonly int end;

                internal Enumerator(in RangeEnumerable enumerable)
                {
                    Current = enumerable.start - 1;
                    end = enumerable.end;
                }

                public int Current { get; private set; }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++Current < end;
            }

            public struct DisposableEnumerator
                : IEnumerator<int>
            {
                readonly int end;

                internal DisposableEnumerator(in RangeEnumerable enumerable)
                {
                    Current = enumerable.start - 1;
                    end = enumerable.end;
                }

                public int Current { get; private set; }
                readonly object IEnumerator.Current 
                    => Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++this.Current < end;

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RangeEnumerable Skip(int count)
            {
                var (skipCount, takeCount) = Utils.Skip(this.Count, count);
                return Range(start + skipCount, takeCount);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RangeEnumerable Take(int count)
                => Range(start, Utils.Take(this.Count, count));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => Count != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(int value)
                => value >= start && value < end;
                
            public int[] ToArray()
            {
                var array = new int[Count];
                if (start == 0)
                {
                    for (var index = 0; index < array.Length; index++)
                        array[index] = index;
                }
                else
                {
                    for (var index = 0; index < array.Length; index++)
                        array[index] = index + start;
                } 
                return array;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<int> ToList()
                => new List<int>(this);

            public Dictionary<TKey, int> ToDictionary<TKey>(Selector<int, TKey> keySelector)
                => ToDictionary<TKey>(keySelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, int> ToDictionary<TKey>(Selector<int, TKey> keySelector, IEqualityComparer<TKey>? comparer)
            {
                var dictionary = new Dictionary<TKey, int>(Count, comparer);

                for (var index = start; index < end; index++)
                    dictionary.Add(keySelector(index), index);

                return dictionary;
            }

            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<int, TKey> keySelector, Selector<int, TElement> elementSelector)
                => ToDictionary<TKey, TElement>(keySelector, elementSelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<int, TKey> keySelector, Selector<int, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
            {
                var dictionary = new Dictionary<TKey, TElement>(Count, comparer);

                for (var index = start; index < end; index++)
                    dictionary.Add(keySelector(index), elementSelector(index));

                return dictionary;
            }
        }
    }
}

