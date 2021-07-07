using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static ValueEnumerableWrapper<T> AsValueEnumerable<T>(T[] source)
            => source switch
            {
                null => throw new ArgumentNullException(nameof(source)),
                _ => new ValueEnumerableWrapper<T>(source)
            };
        
        public readonly struct ValueEnumerableWrapper<T> 
            : IValueEnumerable<T, Enumerator<T>>
        {
            readonly T[] source;

            internal ValueEnumerableWrapper(T[] source)
                => this.source = source;

            public Enumerator<T> GetEnumerator() 
                => new(source);

            IEnumerator<T> IEnumerable<T>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => GetEnumerator();
            
            public readonly struct GetEnumeratorFunction
                : IFunction<ValueEnumerableWrapper<T>, Enumerator<T>>
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public Enumerator<T> Invoke(ValueEnumerableWrapper<T> enumerable) 
                    => enumerable.GetEnumerator();
            }
        }
    }
}