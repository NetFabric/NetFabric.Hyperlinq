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
            readonly int count;

            public Enumerable(int count)
            {
                this.count = count;
            }

            public readonly int Count => count;

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
                => item >= 0 && item < count;

            public readonly void CopyTo(int[] array, int arrayIndex)
            {
                for (var item = 0; item < count; item++)
                    array[arrayIndex + item] = item;
            }

            public readonly Enumerator GetEnumerator() => new Enumerator(count);
            readonly IEnumerator<int> IEnumerable<int>.GetEnumerator() => new Enumerator(count);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(count);

            public struct Enumerator : IEnumerator<int>
            {
                readonly int count;
                int current;

                public Enumerator(int count)
                {
                    this.count = count;
                    current = -1;
                }

                public int Current => current;
                object IEnumerator.Current => current;

                public bool MoveNext() => ++current < count;

                public void Reset() => throw new NotSupportedException();

                public void Dispose() { }
            }
        }

        class EnumerableReferenceType : IReadOnlyList<int>, IList<int>
        {
            readonly int count;

            public EnumerableReferenceType(int count)
            {
                this.count = count;
            }

            public int Count => count;

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
                => item >= 0 && item < count;

            public void CopyTo(int[] array, int arrayIndex)
            {
                for (var item = 0; item < count; item++)
                    array[arrayIndex + item] = item;
            }

            public IEnumerator<int> GetEnumerator() => new Enumerator(count);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(count);

            class Enumerator : IEnumerator<int>
            {
                readonly int count;
                int current;

                public Enumerator(int count)
                {
                    this.count = count;
                    current = -1;
                }

                public int Current => current;
                object IEnumerator.Current => current;

                public bool MoveNext() => ++current < count;

                public void Reset() => throw new NotSupportedException();

                public void Dispose() { }
            }
        }
    }
}