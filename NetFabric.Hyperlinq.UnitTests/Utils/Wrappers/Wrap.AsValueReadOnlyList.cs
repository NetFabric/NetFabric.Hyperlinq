using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static ValueReadOnlyListWrapper<T> AsValueReadOnlyList<T>(T[] source)
            => source is null
                ? throw new ArgumentNullException(nameof(source))
                : new(source);

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
                => new Enumerator<T>(source);
            readonly IEnumerator<T> IEnumerable<T>.GetEnumerator() 
                => new Enumerator<T>(source);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new Enumerator<T>(source);
        }
    }
}