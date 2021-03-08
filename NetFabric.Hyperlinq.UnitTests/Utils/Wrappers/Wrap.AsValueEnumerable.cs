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

            public readonly Enumerator<T> GetEnumerator() 
                => new(source);
            readonly IEnumerator<T> IEnumerable<T>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator<T>(source);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator<T>(source);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerableExtensions.ValueEnumerable<ValueEnumerableWrapper<T>, Enumerator<T>, Enumerator<T>, T, GetEnumeratorFunction, GetEnumeratorFunction> AsValueEnumerable()
                => ValueEnumerableExtensions.AsValueEnumerable<ValueEnumerableWrapper<T>, Enumerator<T>, T, GetEnumeratorFunction>(this);
            
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