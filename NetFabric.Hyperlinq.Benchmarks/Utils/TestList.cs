using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.Benchmarks
{
    public static class TestList
    {
        public static IReadOnlyList<int> ReferenceType(int count)
            => new EnumerableReferenceType(count);

        public static Enumerable ValueType(int count) 
            => new Enumerable(count);

        public readonly struct Enumerable : IReadOnlyList<int>, IList<int>
        {
            public Enumerable(int count) 
                => Count = count;

            public readonly int Count { get; }

            public readonly int this[int index] => index;

            int IList<int>.this[int index] 
            { 
                get => index; 
                set => throw new NotImplementedException(); 
            }

            public readonly bool IsReadOnly => true;

            public void Add(int item) => throw new NotImplementedException();
            public bool Remove(int item) => throw new NotImplementedException();
            public void Clear() => throw new NotImplementedException();
            public int IndexOf(int item) => throw new NotImplementedException();
            public void Insert(int index, int item) => throw new NotImplementedException();
            public void RemoveAt(int index) => throw new NotImplementedException();

            public readonly bool Contains(int item)
                => item >= 0 && item < Count;

            public readonly void CopyTo(int[] array, int arrayIndex)
            {
                for (var item = 0; item < Count; item++)
                    array[arrayIndex + item] = item;
            }

            public readonly Enumerator GetEnumerator() => new Enumerator(Count);
            readonly IEnumerator<int> IEnumerable<int>.GetEnumerator() => new Enumerator(Count);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(Count);

            public struct Enumerator : IEnumerator<int>
            {
                readonly int count;

                public Enumerator(int count)
                {
                    this.count = count;
                    Current = -1;
                }

                public int Current { get; private set; }
                object IEnumerator.Current => Current;

                public bool MoveNext() => ++Current < count;

                public void Reset() => throw new NotSupportedException();

                public void Dispose() { }
            }
        }

#pragma warning disable HLQ006 // GetEnumerator() or GetAsyncEnumerator() should return a value type.

        class EnumerableReferenceType : IReadOnlyList<int>, IList<int>
        {
            public EnumerableReferenceType(int count) 
                => Count = count;

            public int Count { get; }

            public int this[int index] => index;

            int IList<int>.this[int index]
            {
                get => index;
                set => throw new NotImplementedException();
            }

            public bool IsReadOnly => true;

            public void Add(int item) => throw new NotImplementedException();
            public bool Remove(int item) => throw new NotImplementedException();
            public void Clear() => throw new NotImplementedException();
            public int IndexOf(int item) => throw new NotImplementedException();
            public void Insert(int index, int item) => throw new NotImplementedException();
            public void RemoveAt(int index) => throw new NotImplementedException();

            public bool Contains(int item)
                => item >= 0 && item < Count;

            public void CopyTo(int[] array, int arrayIndex)
            {
                for (var item = 0; item < Count; item++)
                    array[arrayIndex + item] = item;
            }

            public IEnumerator<int> GetEnumerator() => new Enumerator(Count);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(Count);

            class Enumerator : IEnumerator<int>
            {
                readonly int count;

                public Enumerator(int count)
                {
                    this.count = count;
                    Current = -1;
                }

                public int Current { get; private set; }
                object IEnumerator.Current => Current;

                public bool MoveNext() => ++Current < count;

                public void Reset() => throw new NotSupportedException();

                public void Dispose() { }
            }
        }

#pragma warning restore HLQ006 // GetEnumerator() or GetAsyncEnumerator() should return a value type.

    }
}