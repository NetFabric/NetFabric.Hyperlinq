using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static Enumerable<T> AsEnumerable<T>(T[] source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));

            return new Enumerable<T>(source);
        }

        public readonly struct Enumerable<T> 
            : IEnumerable<T>
        {
            readonly T[] source;

            internal Enumerable(T[] source)
                => this.source = source;

            public readonly Enumerator<T> GetEnumerator() 
                => new Enumerator<T>(source);
            readonly IEnumerator<T> IEnumerable<T>.GetEnumerator() 
                => new Enumerator<T>(source);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new Enumerator<T>(source);
        }
    }
}