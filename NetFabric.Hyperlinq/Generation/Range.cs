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
        [Pure]
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
            readonly int count;
            readonly int end;

            internal RangeEnumerable(int start, int count, int end)
            {
                this.start = start;
                this.count = count;
                this.end = end;
            }

            public readonly int Count => count;

            public readonly int this[int index]
            {
                get
                {
                    if (index < 0 || index >= count) Throw.IndexOutOfRangeException();

                    return index + start;
                }
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<int, DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<int> IEnumerable<int>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            [MaybeNull]
            int IList<int>.this[int index]
            {
                get => this[index];
                set => throw new NotImplementedException();
            }

            bool ICollection<int>.IsReadOnly  
                => true;

            void ICollection<int>.CopyTo(int[] array, int arrayIndex) 
            {
                if (arrayIndex == 0)
                {
                    for (var index = 0; index < count; index++)
                        array[index] = index + start;
                }
                else
                {
                    for (var index = 0; index < count; index++)
                        array[index + arrayIndex] = index + start;
                } 
            }
            
            void ICollection<int>.Add(int item) 
                => throw new NotImplementedException();
            void ICollection<int>.Clear() 
                => throw new NotImplementedException();
            bool ICollection<int>.Remove(int item) 
                => throw new NotImplementedException();
            int IList<int>.IndexOf(int item)
                => item >= 0 && item < count
                ? item
                : -1;
            void IList<int>.Insert(int index, int item)
                => throw new NotImplementedException();
            void IList<int>.RemoveAt(int index)
                => throw new NotImplementedException();

            public struct Enumerator
            {
                readonly int end;
                int current;

                internal Enumerator(in RangeEnumerable enumerable)
                {
                    current = enumerable.start - 1;
                    end = enumerable.end;
                }

                public readonly int Current
                    => current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++this.current < end;
            }

            public struct DisposableEnumerator
                : IEnumerator<int>
            {
                readonly int end;
                int current;

                internal DisposableEnumerator(in RangeEnumerable enumerable)
                {
                    current = enumerable.start - 1;
                    end = enumerable.end;
                }

                public readonly int Current
                    => current;
                readonly object IEnumerator.Current 
                    => current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => ++this.current < end;

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RangeEnumerable Skip(int count)
            {
                var (skipCount, takeCount) = Utils.Skip(this.count, count);
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
                => value >= start && value < end;
                
            public int[] ToArray()
            {
                var array = new int[count];
                for(var index = 0; index < count; index++)
                    array[index] = start + index;
                return array;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<int> ToList()
                => new List<int>(this);

            public Dictionary<TKey, int> ToDictionary<TKey>(Selector<int, TKey> keySelector)
                => ToDictionary<TKey>(keySelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, int> ToDictionary<TKey>(Selector<int, TKey> keySelector, IEqualityComparer<TKey> comparer)
            {
                var dictionary = new Dictionary<TKey, int>(count, comparer);

                for (var index = start; index < end; index++)
                    dictionary.Add(keySelector(index), index);

                return dictionary;
            }

            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<int, TKey> keySelector, Selector<int, TElement> elementSelector)
                => ToDictionary<TKey, TElement>(keySelector, elementSelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<int, TKey> keySelector, Selector<int, TElement> elementSelector, IEqualityComparer<TKey> comparer)
            {
                var dictionary = new Dictionary<TKey, TElement>(count, comparer);

                for (var index = start; index < end; index++)
                    dictionary.Add(keySelector(index), elementSelector(index));

                return dictionary;
            }

            public void ForEach(Action<int> action)
            {
                for (var index = start; index < end; index++)
                    action(index);
            }
            public void ForEach(ActionAt<int> action)
            {
                for (var index = 0; index < count; index++)
                    action(index + start, index);
            }
        }
    }
}

