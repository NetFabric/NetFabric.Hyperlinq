using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static ValueReadOnlyListWrapper<T> AsValueReadOnlyList<T>(T[] source)
            => source switch
            {
                null => throw new ArgumentNullException(nameof(source)),
                _ => new ValueReadOnlyListWrapper<T>(source)
            };

        public readonly struct ValueReadOnlyListWrapper<T> 
            : IValueReadOnlyList<T, Enumerator<T>>
        {
            readonly T[] source;

            internal ValueReadOnlyListWrapper(T[] source)
                => this.source = source;

            public int Count 
                => source.Length;

            public T this[int index] 
                => source[index];

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