using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static RepeatEnumerable<TResult> Repeat<TResult>(TResult value) =>
            new RepeatEnumerable<TResult>(value);

        public static RepeatCountEnumerable<TResult> Repeat<TResult>(TResult value, int count) 
        {
            if(count < 0)
                ThrowCountOutOfRange();

            return new RepeatCountEnumerable<TResult>(value, count);

            void ThrowCountOutOfRange() => throw new ArgumentOutOfRangeException(nameof(count));
        }

        public readonly struct RepeatEnumerable<TResult> : IEnumerable<TResult>
        {
            readonly TResult value;

            internal RepeatEnumerable(TResult value)
            {
                this.value = value;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public TResult this[int index]
            {
                get => value;
            }

            public readonly struct Enumerator : IEnumerator<TResult>
            {
                readonly TResult value;

                internal Enumerator(in RepeatEnumerable<TResult> enumerable)
                {
                    value = enumerable.value;
                }

                public TResult Current => value;
                object IEnumerator.Current => value;

                public bool MoveNext() => true;

                public void Reset() => throw new NotSupportedException();

                public void Dispose() { }
            }
        }

        public readonly struct RepeatCountEnumerable<TResult> : IReadOnlyList<TResult>
        {
            readonly TResult value;
            readonly int count;

            internal RepeatCountEnumerable(TResult value, int count)
            {
                this.value = value;
                this.count = count;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public int Count => count;

            public TResult this[int index]
            {
                get
                {
                    if(index < 0 || index >= count)
                        ThrowIndexOutOfRange();
                    return value;

                    void ThrowIndexOutOfRange() => throw new IndexOutOfRangeException();
                }
            }

            public struct Enumerator : IEnumerator<TResult>
            {
                readonly TResult value;
                int counter;

                internal Enumerator(in RepeatCountEnumerable<TResult> enumerable)
                {
                    value = enumerable.value;
                    counter = enumerable.count + 1;
                }

                public TResult Current => value;
                object IEnumerator.Current => value;

                public bool MoveNext() => --counter > 0;

                public void Reset() => throw new NotSupportedException();

                public void Dispose() { }
            }
        }
    }
}

