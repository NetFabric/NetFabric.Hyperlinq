using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static ValueCollectionWrapper<T> AsValueCollection<T>(T[] source)
            => source is null
                ? throw new ArgumentNullException(nameof(source))
                : new(source);

        public readonly struct ValueCollectionWrapper<T> 
            : IValueReadOnlyCollection<T, Enumerator<T>>
            , ICollection<T>
        {
            readonly T[] source;

            internal ValueCollectionWrapper(T[] source)
                => this.source = source;

            public readonly int Count 
                => source.Length;

            public readonly Enumerator<T> GetEnumerator() 
                => new Enumerator<T>(source);
            readonly IEnumerator<T> IEnumerable<T>.GetEnumerator() 
                => new Enumerator<T>(source);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new Enumerator<T>(source);

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