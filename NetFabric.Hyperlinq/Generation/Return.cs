using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => true;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value)
                => EqualityComparer<TSource>.Default.Equals(this.value, value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => comparer.Equals(this.value, value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReturnEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector) 
                => new ReturnEnumerable<TResult>(selector(value));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource First() 
                => value;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource FirstOrDefault() 
                => value;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource Single() 
                => value;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource SingleOrDefault() 
                => value;

            public TSource[] ToArray()
            {
                var array = new TSource[1];
                array[0] = value;
                return array;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => new List<TSource>(1) { value };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Count<TSource>(this ReturnEnumerable<TSource> source)
            => 1;
    }
}

