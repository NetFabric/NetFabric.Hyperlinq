using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static ListWrapper<T> AsList<T>(T[] source)
            => source switch
            {
                null => throw new ArgumentNullException(nameof(source)),
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                _ => new ListWrapper<T>(source)
            };

        public class ListWrapper<T> 
            : ReadOnlyListWrapper<T>
            , IList<T>
        {
            internal ListWrapper(T[] source)
                : base(source)
            { }

            T IList<T>.this[int index] 
            { 
                get => source[index]; 
                set => throw new NotSupportedException(); 
            }

            public bool IsReadOnly => true;

            public void CopyTo(T[] array, int arrayIndex) 
                => source.CopyTo(array, arrayIndex);

            public bool Contains(T item)
                => ((ICollection<T>)source).Contains(item);

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