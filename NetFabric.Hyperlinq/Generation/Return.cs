using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static ReturnEnumerable<TSource> Return<TSource>(TSource value) =>
            new ReturnEnumerable<TSource>(value);

        [GenericsTypeMapping("TEnumerable", typeof(ReturnEnumerable<>))]
        [GenericsTypeMapping("TEnumerator", typeof(ReturnEnumerable<>.Enumerator))]
        public readonly struct ReturnEnumerable<TSource>
            : IValueReadOnlyList<TSource, ReturnEnumerable<TSource>.Enumerator>
        {
            internal readonly TSource value;

            internal ReturnEnumerable(TSource value)
            {
                this.value = value;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public long Count => 1;

            public TSource this[long index]
            {
                get
                {
                    if(index != 0) ThrowHelper.ThrowIndexOutOfRangeException();
                    
                    return value;
                }
            }

            public struct Enumerator
                : IValueEnumerator<TSource>
            {
                readonly TSource value;
                bool moveNext;

                internal Enumerator(in ReturnEnumerable<TSource> enumerable)
                {
                    value = enumerable.value;
                    moveNext = true;
                }

                public TSource Current
                    => value;

                public bool MoveNext()
                {
                    if (moveNext)
                    {
                        moveNext = false;
                        return true;
                    }
                    return false;
                }

                public void Dispose() { }
            }

            public bool Any()
                => true;

            public bool Contains(TSource value)
                => EqualityComparer<TSource>.Default.Equals(this.value, value);

            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => comparer.Equals(this.value, value);

            public ReturnEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector) 
                => new ReturnEnumerable<TResult>(selector(value));

            public TSource First() 
                => value;
            public TSource FirstOrDefault() 
                => value;

            public TSource Single() 
                => value;
            public TSource SingleOrDefault() 
                => value;

            public TSource[] ToArray()
            {
                var array = new TSource[1];
                array[0] = value;
                return array;
            }

            public List<TSource> ToList()
                => new List<TSource> { value };
        }

        public static long Count<TSource>(this ReturnEnumerable<TSource> source)
            => 1;
    }
}

