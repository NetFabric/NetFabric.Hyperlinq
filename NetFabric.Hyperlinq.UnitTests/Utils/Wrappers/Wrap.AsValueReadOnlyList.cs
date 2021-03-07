using System;
using System.Collections;
using System.Collections.Generic;

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

            public readonly int Count 
                => source.Length;

            public readonly T this[int index] 
                => source[index];

            public readonly Enumerator<T> GetEnumerator() 
                => new(source);
            readonly IEnumerator<T> IEnumerable<T>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator<T>(source);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator<T>(source);

            public ValueReadOnlyListExtensions.ValueEnumerable<ValueReadOnlyListWrapper<T>, Enumerator<T>, T> AsValueEnumerable()
                => this.AsValueEnumerable<ValueReadOnlyListWrapper<T>, Enumerator<T>, T>();
        }
    }
}