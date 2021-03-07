using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static ValueCollectionWrapper<T> AsValueCollection<T>(T[] source)
            => source switch
            {
                null => throw new ArgumentNullException(nameof(source)),
                _ => new ValueCollectionWrapper<T>(source)
            };

        public readonly struct ValueCollectionWrapper<T> 
            : IValueReadOnlyCollection<T, Enumerator<T>>
            , ICollection<T>
        {
            readonly T[] source;

            internal ValueCollectionWrapper(T[] source)
                => this.source = source;

            public readonly int Count 
                => source.Length;

            public readonly Enumerator<T> GetEnumerator() 
                => new(source);
            readonly IEnumerator<T> IEnumerable<T>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator<T>(source);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator<T>(source);

            public bool IsReadOnly => true;

            public void CopyTo(T[] array, int arrayIndex) 
                => source.CopyTo(array, arrayIndex);

            public bool Contains(T item)
                => ((ICollection<T>)source).Contains(item);

            void ICollection<T>.Add(T item) 
                => throw new NotSupportedException();
            bool ICollection<T>.Remove(T item) 
                => throw new NotSupportedException();
            void ICollection<T>.Clear() 
                => throw new NotSupportedException();

            public ValueReadOnlyCollectionExtensions.ValueEnumerable<ValueCollectionWrapper<T>, Enumerator<T>, Enumerator<T>, T, GetEnumeratorFunction, GetEnumeratorFunction> AsValueEnumerable()
                => ValueReadOnlyCollectionExtensions.AsValueEnumerable<ValueCollectionWrapper<T>, Enumerator<T>, T, GetEnumeratorFunction>(this);
            
            public readonly struct GetEnumeratorFunction
                : IFunction<ValueCollectionWrapper<T>, Enumerator<T>>
            {
                public Enumerator<T> Invoke(ValueCollectionWrapper<T> enumerable) 
                    => enumerable.GetEnumerator();
            }
        }
    }
}