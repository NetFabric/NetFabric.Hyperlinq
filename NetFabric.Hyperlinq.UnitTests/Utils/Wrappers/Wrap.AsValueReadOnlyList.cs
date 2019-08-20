using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static ValueReadOnlyList<T> AsValueReadOnlyList<T>(T[] source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));

            return new ValueReadOnlyList<T>(source);
        }

        public readonly struct ValueReadOnlyList<T> 
            : IValueReadOnlyList<T, Enumerator<T>>
        {
            readonly T[] source;

            internal ValueReadOnlyList(T[] source)
            {
                this.source = source;
            }

            public readonly int Count => source.Length;

            public readonly T this[int index] => source[index];

            public readonly Enumerator<T> GetEnumerator() => new Enumerator<T>(source);
            readonly IEnumerator<T> IEnumerable<T>.GetEnumerator() => new Enumerator<T>(source);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator<T>(source);
        }
    }
}