using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static ReturnEnumerable<TResult> Return<TResult>(TResult value) =>
            new ReturnEnumerable<TResult>(value);

        public readonly struct ReturnEnumerable<TResult> : IReadOnlyList<TResult>
        {
            readonly TResult value;

            internal ReturnEnumerable(TResult value)
            {
                this.value = value;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public int Count => 1;

            public TResult this[int index]
            {
                get
                {
                    if(index != 0)
                        ThrowIndexOutOfRange();
                    return value;

                    void ThrowIndexOutOfRange() => throw new IndexOutOfRangeException(nameof(index));
                }
            }

            public struct Enumerator : IEnumerator<TResult>
            {
                readonly TResult value;
                bool moveNext;

                internal Enumerator(in ReturnEnumerable<TResult> enumerable)
                {
                    value = enumerable.value;
                    moveNext = true;
                }

                public TResult Current => value;
                object IEnumerator.Current => value;

                public bool MoveNext()
                {
                    if(moveNext)
                    {
                        moveNext = false;
                        return true;
                    }
                    return false;
                }

                public void Reset() => throw new NotSupportedException();

                public void Dispose() { }
            }
        }
    }
}

