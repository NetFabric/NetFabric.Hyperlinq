using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static CreateEnumerable<TEnumerator, TResult> Create<TEnumerator, TResult>(Func<TEnumerator> getEnumerator) 
            where TEnumerator : IEnumerator<TResult>
        {
            if(getEnumerator is null)
                ThrowGetEnumeratorNull();

            return new CreateEnumerable<TEnumerator, TResult>(getEnumerator);

            void ThrowGetEnumeratorNull() => throw new ArgumentNullException(nameof(getEnumerator));
        }

        public readonly struct CreateEnumerable<TEnumerator, TResult> : IEnumerable<TResult>
            where TEnumerator : IEnumerator<TResult>
        {
            readonly Func<TEnumerator> getEnumerator;

            internal CreateEnumerable(Func<TEnumerator> getEnumerator)
            {
                this.getEnumerator = getEnumerator;
            }

            public TEnumerator GetEnumerator() => getEnumerator();
            IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => getEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => getEnumerator();
        }
    }
}

