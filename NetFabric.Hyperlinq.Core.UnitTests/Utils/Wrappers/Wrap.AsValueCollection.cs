using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static ValueCollectionWrapper<T> AsValueCollection<T>(T[] source)
            => source switch
            {
                null => throw new ArgumentNullException(nameof(source)),
                _ => new ValueCollectionWrapper<T>(source)
            };

        public readonly struct ValueCollectionWrapper<T> 
            : IValueReadOnlyCollection<T, Enumerator<T>>
            , ICollection<T>
        {
            readonly T[] source;

            internal ValueCollectionWrapper(T[] source)
                => this.source = source;

            public int Count 
                => source.Length;

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
                => ((ICollection<T>)source).Contains(item);

            void ICollection<T>.Add(T item) 
                => throw new NotSupportedException();
            bool ICollection<T>.Remove(T item) 
                => throw new NotSupportedException();
            void ICollection<T>.Clear() 
                => throw new NotSupportedException();
        }
    }
}