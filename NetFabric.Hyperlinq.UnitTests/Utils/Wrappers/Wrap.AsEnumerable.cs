using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static EnumerableWrapper<T> AsEnumerable<T>(T[] source)
            => source switch
            {
                null => throw new ArgumentNullException(nameof(source)),
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                _ => new EnumerableWrapper<T>(source)
            };

        public class EnumerableWrapper<T> 
            : IEnumerable<T>
        {
            protected readonly T[] source;

            internal EnumerableWrapper(T[] source)
                => this.source = source;

            public Enumerator<T> GetEnumerator() 
                => new(source);
            IEnumerator<T> IEnumerable<T>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator<T>(source);
            IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator<T>(source);

            public EnumerableExtensions.ValueEnumerable<EnumerableWrapper<T>, Enumerator<T>, Enumerator<T>, T, GetEnumeratorFunction, GetEnumeratorFunction> AsValueEnumerable()
                => this.AsValueEnumerable<EnumerableWrapper<T>, Enumerator<T>, T, GetEnumeratorFunction>();
            
            public readonly struct GetEnumeratorFunction
                : IFunction<EnumerableWrapper<T>, Enumerator<T>>
            {
                public Enumerator<T> Invoke(EnumerableWrapper<T> enumerable) 
                    => enumerable.GetEnumerator();
            }
        }
    }
}