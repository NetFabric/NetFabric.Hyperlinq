using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static ValueListWrapper<T> AsValueList<T>(T[] source)
            => source switch
            {
                null => throw new ArgumentNullException(nameof(source)),
                _ => new ValueListWrapper<T>(source)
            };

        public readonly struct ValueListWrapper<T> 
            : IValueReadOnlyList<T, Enumerator<T>>
            , IList<T>
        {
            readonly T[] source;

            internal ValueListWrapper(T[] source)
                => this.source = source;

            public int Count 
                => source.Length;

            public T this[int index] 
                => source[index];

            T IList<T>.this[int index] 
            { 
                get => source[index]; 
                set => throw new NotSupportedException(); 
            }

            public Enumerator<T> GetEnumerator() 
                => new(source);

            IEnumerator<T> IEnumerable<T>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => GetEnumerator();

            public bool IsReadOnly => true;

            public void CopyTo(T[] array, int arrayIndex) 
                => source.CopyTo(array, arrayIndex);

            public bool Contains(T item)
                => ((IList<T>)source).Contains(item);

            public int IndexOf(T item)
                => ((IList<T>)source).IndexOf(item);

            void ICollection<T>.Add(T item) 
                => throw new NotSupportedException();
            bool ICollection<T>.Remove(T item) 
                => throw new NotSupportedException();
            void ICollection<T>.Clear() 
                => throw new NotSupportedException();

            void IList<T>.Insert(int index, T item) 
                => throw new NotSupportedException();
            void IList<T>.RemoveAt(int index) 
                => throw new NotSupportedException();
        }
    }
}