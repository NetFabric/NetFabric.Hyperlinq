using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static SelectIndexEnumerable<TSource, TResult> Select<TSource, TResult>(
            this TSource[] source, 
            Func<TSource, long, TResult> selector)
        {
            if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectIndexEnumerable<TSource, TResult>(source, selector);
        }

        [GenericsTypeMapping("TEnumerable", typeof(SelectIndexEnumerable<,>))]
        [GenericsTypeMapping("TEnumerator", typeof(SelectIndexEnumerable<,>.Enumerator))]
        public readonly struct SelectIndexEnumerable<TSource, TResult>
            : IValueReadOnlyList<TResult, SelectIndexEnumerable<TSource, TResult>.Enumerator>
        {
            readonly TSource[] source;
            readonly Func<TSource, long, TResult> selector;

            internal SelectIndexEnumerable(TSource[] source, Func<TSource, long, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public int Count => source.Length;
            long IValueReadOnlyCollection<TResult, Enumerator>.Count => source.Length;

            public TResult this[int index]
            {
                get
                {
                    if (index < 0 || index >= source.Length)
                        ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));

                    return selector(source[index], index);
                }
            }

            TResult IValueReadOnlyList<TResult, Enumerator>.this[long index]
            {
                get
                {
                    if (index > int.MaxValue)
                        ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));

                    return this[(int)index];
                }
            }

            public struct Enumerator
                : IValueEnumerator<TResult>
            {
                readonly TSource[] source;
                readonly Func<TSource, long, TResult> selector;
                readonly int count;
                int index;

                internal Enumerator(in SelectIndexEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    count = enumerable.source.Length;
                    index = -1;
                }

                public TResult Current
                    => selector(source[index], index);

                public bool MoveNext()
                    => ++index < count;

                public void Dispose() { }
            }

            public bool Any()
                => source.Length != 0;

            public Array.SelectIndexEnumerable<TSource, TSelectorResult> Select<TSelectorResult>(Func<TResult, long, TSelectorResult> selector)
                => Array.Select<TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector));

            public TResult First()
                => selector(Array.First<TSource>(source), 0);
            public TResult FirstOrDefault()
                => selector(Array.FirstOrDefault<TSource>(source), 0);

            public TResult Single()
                => selector(Array.Single<TSource>(source), 0);
            public TResult SingleOrDefault()
                => selector(Array.SingleOrDefault<TSource>(source), 0);
        }
    }
}

