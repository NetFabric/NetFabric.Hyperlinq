using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq.Benchmarks
{
    public static class TestList
    {
        public static Enumerable ValueType(int[] array) 
            => new(array);

        public static IReadOnlyList<int> ReferenceType(int[] array)
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            => new EnumerableReferenceType(array);

        public class Enumerable : IReadOnlyList<int>, IList<int>
        {
            readonly int[] array;

            public Enumerable(int[] array) 
                => this.array = array;

            public int Count => array.Length;

            public int this[int index] => array[index];

            int IList<int>.this[int index] 
            { 
                get => array[index]; 
                set => throw new NotSupportedException(); 
            }

            public bool IsReadOnly => true;

            public void Add(int item) => throw new NotSupportedException();
            public bool Remove(int item) => throw new NotSupportedException();
            public void Clear() => throw new NotSupportedException();
            public int IndexOf(int item) => throw new NotSupportedException();
            public void Insert(int index, int item) => throw new NotSupportedException();
            public void RemoveAt(int index) => throw new NotSupportedException();

            public bool Contains(int item)
                => ((IList<int>)array).Contains(item);

            public void CopyTo(int[] array, int arrayIndex)
                => this.array.CopyTo(array, arrayIndex);

            public Enumerator GetEnumerator() 
                => new(array);
            IEnumerator<int> IEnumerable<int>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(array);
            IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(array);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlyListExtensions.ValueEnumerable<Enumerable, int> AsValueEnumerable()
                => this.AsValueEnumerable<Enumerable, int>();

            public struct Enumerator : IEnumerator<int>
            {
                readonly int[] array;
                int index;

                public Enumerator(int[] array)
                {
                    this.array = array;
                    index = -1;
                }

                public int Current 
                    => array[index];
                object IEnumerator.Current 
                    // ReSharper disable once HeapView.BoxingAllocation
                    => array[index];

                public bool MoveNext() => ++index < array.Length;

                public void Reset() => throw new NotSupportedException();

                public void Dispose() { }
            }
        }

#pragma warning disable HLQ006 // GetEnumerator() or GetAsyncEnumerator() should return a value type.

        class EnumerableReferenceType : IReadOnlyList<int>, IList<int>
        {
            readonly int[] array;
            
            public EnumerableReferenceType(int[] array) 
                => this.array = array;

            public int Count => array.Length;

            public int this[int index] => array[index];

            int IList<int>.this[int index]
            {
                get => array[index];
                set => throw new NotSupportedException();
            }

            public bool IsReadOnly => true;

            public void Add(int item) => throw new NotSupportedException();
            public bool Remove(int item) => throw new NotSupportedException();
            public void Clear() => throw new NotSupportedException();
            public int IndexOf(int item) => throw new NotSupportedException();
            public void Insert(int index, int item) => throw new NotSupportedException();
            public void RemoveAt(int index) => throw new NotSupportedException();

            public bool Contains(int item)
                => ((IList<int>)array).Contains(item);

            public void CopyTo(int[] array, int arrayIndex)
                => this.array.CopyTo(array, arrayIndex);

            public IEnumerator<int> GetEnumerator() 
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                => new Enumerator(array);
            IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                => new Enumerator(array);

            class Enumerator : IEnumerator<int>
            {
                readonly int[] array;
                int index = -1;

                public Enumerator(int[] array) => this.array = array;

                public int Current 
                    => array[index];
                object? IEnumerator.Current 
                    // ReSharper disable once HeapView.BoxingAllocation
                    => array[index];

                public bool MoveNext() 
                    => ++index < array.Length;

                public void Reset() 
                    => throw new NotSupportedException();

                public void Dispose() { }
            }
        }

#pragma warning restore HLQ006 // GetEnumerator() or GetAsyncEnumerator() should return a value type.

    }
}