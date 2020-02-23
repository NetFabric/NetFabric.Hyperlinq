using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static ValueCollection<T> AsValueCollection<T>(T[] source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));

            return new ValueCollection<T>(source);
        }

        public readonly struct ValueCollection<T> 
            : IValueReadOnlyList<T, Enumerator<T>>
            , ICollection<T>
        {
            readonly T[] source;

            internal ValueCollection(T[] source)
                => this.source = source;

            public readonly int Count 
                => source.Length;

            readonly IEnumerator<T> IEnumerable<T>.GetEnumerator() 
                => new Enumerator<T>(source);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new Enumerator<T>(source);
            public readonly Enumerator<T> GetEnumerator() 
                => new Enumerator<T>(source);

            public bool IsReadOnly  
                => true;

            public T this[int index] 
                => source[index];

            public void CopyTo(T[] array, int arrayIndex) 
                => source.CopyTo(array, arrayIndex);

            public void Add(T item) 
                => throw new NotImplementedException();
            public void Clear() 
                => throw new NotImplementedException();
            public bool Contains(T item) 
                => throw new NotImplementedException();
            public bool Remove(T item) 
                => throw new NotImplementedException();
        }
    }
}