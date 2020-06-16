using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static EnumerableWrapper<T> AsEnumerable<T>(T[] source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));

            return new EnumerableWrapper<T>(source);
        }

        public class EnumerableWrapper<T> 
            : IEnumerable<T>
        {
            protected readonly T[] source;

            internal EnumerableWrapper(T[] source)
                => this.source = source;

            public Enumerator<T> GetEnumerator() 
                => new Enumerator<T>(source);
            IEnumerator<T> IEnumerable<T>.GetEnumerator() 
                => new Enumerator<T>(source);
            IEnumerator IEnumerable.GetEnumerator() 
                => new Enumerator<T>(source);
        }
    }
}