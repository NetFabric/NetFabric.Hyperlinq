using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static ReadOnlyCollection<T> AsReadOnlyCollection<T>(T[] source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));

            return new ReadOnlyCollection<T>(source);
        }

        public readonly struct ReadOnlyCollection<T> 
            : IReadOnlyCollection<T>
        {
            readonly T[] source;

            public ReadOnlyCollection(T[] source)
            {
                this.source = source;
            }

            public readonly int Count => source.Length;

            public readonly Enumerator<T> GetEnumerator() => new Enumerator<T>(source);
            readonly IEnumerator<T> IEnumerable<T>.GetEnumerator() => new Enumerator<T>(source);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator<T>(source);
        }  
    }
}