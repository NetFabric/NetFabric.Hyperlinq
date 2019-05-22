using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> Select<TEnumerable, TEnumerator, TSource, TResult>(
            this TEnumerable source, 
            Func<TSource, TResult> selector)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if(selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>(in source, selector);
        }

        [GenericsTypeMapping("TEnumerable", typeof(SelectEnumerable<,,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(SelectEnumerable<,,,>.Enumerator))]
        [GenericsMapping("TSource", "TResult")]
        public readonly struct SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>
            : IValueReadOnlyList<TResult, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator>
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TSource, TResult> selector;

            internal SelectEnumerable(in TEnumerable source, Func<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public long Count => source.Count;

            public TResult this[long index] => selector(source[index]);

            public struct Enumerator
                : IValueEnumerator<TResult>
            {
                readonly TEnumerable source;
                readonly Func<TSource, TResult> selector;
                readonly long count;
                long index;

                internal Enumerator(in SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    count = enumerable.source.Count;
                    index = -1;
                }

                public TResult Current => selector(source[index]);

                public bool MoveNext() => ++index < count;

                public void Dispose() { }
            }

            public bool Any()
                => source.Count != 0;

            public ValueReadOnlyList.SelectEnumerable<TEnumerable, TEnumerator, TSource, TSelectorResult> Select<TSelectorResult>(Func<TResult, TSelectorResult> selector)
                => ValueReadOnlyList.Select<TEnumerable, TEnumerator, TSource, TSelectorResult>(source, Utils.Combine(this.selector, selector));

            public TResult First()
                => selector(ValueReadOnlyList.First<TEnumerable, TEnumerator, TSource>(source));
            public TResult FirstOrDefault()
                => selector(ValueReadOnlyList.FirstOrDefault<TEnumerable, TEnumerator, TSource>(source));

            public TResult Single()
                => selector(ValueReadOnlyList.Single<TEnumerable, TEnumerator, TSource>(source));
            public TResult SingleOrDefault()
                => selector(ValueReadOnlyList.SingleOrDefault<TEnumerable, TEnumerator, TSource>(source));
        }

        public static long Count<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => source.Count;

        public static long Count<TEnumerable, TEnumerator, TSource, TResult>(this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source, Func<TResult, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => ValueReadOnlyList.Count<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator, TResult>(source, predicate);
    }
}

