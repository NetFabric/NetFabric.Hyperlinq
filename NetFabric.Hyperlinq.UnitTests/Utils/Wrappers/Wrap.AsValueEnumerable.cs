using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static ValueEnumerable<T> AsValueEnumerable<T>(T[] source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));

            return new ValueEnumerable<T>(source);
        }

        public readonly struct ValueEnumerable<T> 
            : IValueEnumerable<T, ValueEnumerator<T>>
        {
            readonly T[] source;

            internal ValueEnumerable(T[] source)
            {
                this.source = source;
            }

            public readonly ValueEnumerator<T> GetEnumerator() => new ValueEnumerator<T>(source);
            readonly IEnumerator<T> IEnumerable<T>.GetEnumerator() => new Enumerator<T>(source);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator<T>(source);
        }
    }
}