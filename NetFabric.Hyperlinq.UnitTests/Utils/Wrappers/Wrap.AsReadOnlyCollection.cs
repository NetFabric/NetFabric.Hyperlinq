using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static ReadOnlyCollectionWrapper<T> AsReadOnlyCollection<T>(T[] source)
            => source switch
            {
                null => throw new ArgumentNullException(nameof(source)),
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                _ => new ReadOnlyCollectionWrapper<T>(source)
            };

        public class ReadOnlyCollectionWrapper<T> 
            : EnumerableWrapper<T>
            , IReadOnlyCollection<T>
        {
            public ReadOnlyCollectionWrapper(T[] source)
                : base(source)
            { }

            public int Count 
                => source.Length;

            public new ReadOnlyCollectionExtensions.ValueEnumerable<ReadOnlyCollectionWrapper<T>, Enumerator<T>, Enumerator<T>, T, GetEnumeratorFunction, GetEnumeratorFunction> AsValueEnumerable()
                => ReadOnlyCollectionExtensions.AsValueEnumerable<ReadOnlyCollectionWrapper<T>, Enumerator<T>, T, GetEnumeratorFunction>(this);
            
            public new readonly struct GetEnumeratorFunction
                : IFunction<ReadOnlyCollectionWrapper<T>, Enumerator<T>>
            {
                public Enumerator<T> Invoke(ReadOnlyCollectionWrapper<T> enumerable) 
                    => enumerable.GetEnumerator();
            }
        }  
    }
}