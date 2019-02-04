using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static CreateEnumerable<TEnumerator, TResult> Create<TEnumerator, TResult>(
            Func<TEnumerator> getEnumerator) 
            where TEnumerator : IEnumerator<TResult>
        {
            if(getEnumerator is null) ThrowGetEnumeratorNull();

            return new CreateEnumerable<TEnumerator, TResult>(getEnumerator);

            void ThrowGetEnumeratorNull() => throw new ArgumentNullException(nameof(getEnumerator));
        }

        public static CreateReadonlyCollection<TEnumerator, TResult> Create<TEnumerator, TResult>(
            Func<TEnumerator> getEnumerator, 
            int count) 
            where TEnumerator : IEnumerator<TResult>
        {
            if(getEnumerator is null) ThrowGetEnumeratorNull();
            if(count < 0) ThrowCountOutOfRange();

            return new CreateReadonlyCollection<TEnumerator, TResult>(getEnumerator, count);

            void ThrowGetEnumeratorNull() => throw new ArgumentNullException(nameof(getEnumerator));
            void ThrowCountOutOfRange() => throw new ArgumentOutOfRangeException(nameof(count));
        }

        public static CreateReadonlyList<TEnumerator, TResult> Create<TEnumerator, TResult>(
            Func<TEnumerator> getEnumerator, 
            int count,
            Func<int, TResult> getItem) 
            where TEnumerator : IEnumerator<TResult>
        {
            if(getEnumerator is null) ThrowGetEnumeratorNull();
            if(count < 0) ThrowCountOutOfRange();

            if(getItem is null)
                ThrowGetItemNull();

            return new CreateReadonlyList<TEnumerator, TResult>(getEnumerator, count, getItem);

            void ThrowGetEnumeratorNull() => throw new ArgumentNullException(nameof(getEnumerator));
            void ThrowCountOutOfRange() => throw new ArgumentOutOfRangeException(nameof(count));
            void ThrowGetItemNull() => throw new ArgumentNullException(nameof(getItem));
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

        public readonly struct CreateReadonlyCollection<TEnumerator, TResult> : IReadOnlyCollection<TResult>
            where TEnumerator : IEnumerator<TResult>
        {
            readonly Func<TEnumerator> getEnumerator;
            readonly int count;

            internal CreateReadonlyCollection(Func<TEnumerator> getEnumerator, int count)
            {
                this.getEnumerator = getEnumerator;
                this.count = count;
            }

            public int Count => count;

            public TEnumerator GetEnumerator() => getEnumerator();
            IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => getEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => getEnumerator();
        }

        public readonly struct CreateReadonlyList<TEnumerator, TResult> : IReadOnlyList<TResult>
            where TEnumerator : IEnumerator<TResult>
        {
            readonly Func<TEnumerator> getEnumerator;
            readonly int count;
            readonly Func<int, TResult> getItem;

            internal CreateReadonlyList(Func<TEnumerator> getEnumerator, int count, Func<int, TResult> getItem)
            {
                this.getEnumerator = getEnumerator;
                this.count = count;
                this.getItem = getItem;
            }

            public int Count => count;

            public TResult this[int index]
            {
                get
                {
                    if(index < 0 || index >= Count) ThrowIndexOutOfRange();

                    return getItem(index);
                    
                    void ThrowIndexOutOfRange() => throw new IndexOutOfRangeException();
                } 
            }

            public TEnumerator GetEnumerator() => getEnumerator();
            IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => getEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => getEnumerator();
        }
    }
}

