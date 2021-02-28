using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static ValueReadOnlyCollectionWrapper<T> AsValueReadOnlyCollection<T>(T[] source)
            => source switch
            {
                null => throw new ArgumentNullException(nameof(source)),
                _ => new ValueReadOnlyCollectionWrapper<T>(source)
            };

        public readonly struct ValueReadOnlyCollectionWrapper<T> 
            : IValueReadOnlyCollection<T, Enumerator<T>>
        {
            readonly T[] source;

            internal ValueReadOnlyCollectionWrapper(T[] source)
                => this.source = source;

            public readonly int Count 
                => source.Length;

            public readonly Enumerator<T> GetEnumerator() 
                => new(source);
            readonly IEnumerator<T> IEnumerable<T>.GetEnumerator() 
                => new Enumerator<T>(source);
            readonly IEnumerator IEnumerable.GetEnumerator()
                => new Enumerator<T>(source);
        }
    }
}