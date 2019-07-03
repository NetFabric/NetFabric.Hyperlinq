using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
{
        public static CreateValueEnumerable<TEnumerator, TSource> Create<TEnumerator, TSource>(Func<TEnumerator> getEnumerator) 
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if(getEnumerator is null) ThrowHelper.ThrowArgumentNullException(nameof(getEnumerator));

            return new CreateValueEnumerable<TEnumerator, TSource>(getEnumerator);
        }

        [GenericsTypeMapping("TEnumerable", typeof(CreateValueEnumerable<,>))]
        public readonly struct CreateValueEnumerable<TEnumerator, TSource> 
            : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly Func<TEnumerator> getEnumerator;

            internal CreateValueEnumerable(Func<TEnumerator> getEnumerator)
            {
                this.getEnumerator = getEnumerator;
            }

            public TEnumerator GetEnumerator() => getEnumerator();
        }
    }
}
