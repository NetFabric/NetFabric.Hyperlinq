using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static ReadOnlyList<T> AsReadOnlyList<T>(T[] source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));

            return new ReadOnlyList<T>(source);
        }

        public readonly struct ReadOnlyList<T> 
            : IReadOnlyList<T>
        {
            readonly T[] source;

            internal ReadOnlyList(T[] source)
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