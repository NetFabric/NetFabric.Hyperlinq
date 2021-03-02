using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static ValueEnumerableWrapper<T> AsValueEnumerable<T>(T[] source)
            => source switch
            {
                null => throw new ArgumentNullException(nameof(source)),
                _ => new ValueEnumerableWrapper<T>(source)
            };
        
        public readonly struct ValueEnumerableWrapper<T> 
            : IValueEnumerable<T, Enumerator<T>>
        {
            readonly T[] source;

            internal ValueEnumerableWrapper(T[] source)
                => this.source = source;

            public readonly Enumerator<T> GetEnumerator() 
                => new(source);
            readonly IEnumerator<T> IEnumerable<T>.GetEnumerator() 
                => new Enumerator<T>(source);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new Enumerator<T>(source);

            public ValueEnumerableWrapper<T> AsValueEnumerable()
                => this.AsValueEnumerable<ValueEnumerableWrapper<T>, Enumerator<T>, T>();
        }
    }
}