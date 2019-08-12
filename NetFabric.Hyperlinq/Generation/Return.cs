using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        [Pure]
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

            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public int Count => 1;

            public TSource this[int index]
            {
                get
                {
                    if (index != 0) ThrowHelper.ThrowIndexOutOfRangeException();

                    return value;
                }
            }

            public struct Enumerator
                : IEnumerator<TSource>
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
                object IEnumerator.Current
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

                readonly void IEnumerator.Reset()
                    => throw new NotSupportedException();

                public readonly void Dispose() { }
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
                => new TSource[] { value };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => new List<TSource>(1) { value };

            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector)
                => ToDictionary<TKey>(keySelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
                => new Dictionary<TKey, TSource>(1, comparer) { { keySelector(value), value } };

            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
                => ToDictionary<TKey, TElement>(keySelector, elementSelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
                => new Dictionary<TKey, TElement>(1, comparer) { { keySelector(value), elementSelector(value) } };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this ReturnEnumerable<TSource> source)
            => 1;
    }
}

