using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static ValueReadOnlyCollection<T> AsValueReadOnlyCollection<T>(T[] source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));

            return new ValueReadOnlyCollection<T>(source);
        }

        public readonly struct ValueReadOnlyCollection<T> 
            : IValueReadOnlyCollection<T, ValueEnumerator<T>>
        {
            readonly T[] source;

            internal ValueReadOnlyCollection(T[] source)
            {
                this.source = source;
            }

            public readonly int Count => source.Length;

            public readonly ValueEnumerator<T> GetEnumerator() => new ValueEnumerator<T>(source);
            readonly IEnumerator<T> IEnumerable<T>.GetEnumerator() => new Enumerator<T>(source);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator<T>(source);
        }
    }
}