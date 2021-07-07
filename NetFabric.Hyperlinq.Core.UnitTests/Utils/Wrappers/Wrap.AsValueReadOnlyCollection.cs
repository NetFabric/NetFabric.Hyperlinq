using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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
        }
    }
}