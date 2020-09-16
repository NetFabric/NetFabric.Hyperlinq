using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        public static SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, FunctionWrapper<TSource, TResult>> Select<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Func<TSource, TResult> selector)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => Select<TEnumerable, TEnumerator, TSource, TResult, FunctionWrapper<TSource, TResult>>(source, new FunctionWrapper<TSource, TResult>(selector));

        public static SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector> Select<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TSelector selector)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => new SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>(source, selector);

        [GeneratorMapping("TSource", "TResult")]
        [GeneratorMapping("TResult", "TResult2")]
        public readonly partial struct SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>
            : IValueEnumerable<TResult, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>.DisposableEnumerator>
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            readonly TEnumerable source;
            readonly TSelector selector;

            internal SelectEnumerable(TEnumerable source, TSelector selector)
                => (this.source, this.selector) = (source, selector);

            public readonly Enumerator GetEnumerator()
                => new Enumerator();
            readonly DisposableEnumerator IValueEnumerable<TResult, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult, TSelector>.DisposableEnumerator>.GetEnumerator()
                => new DisposableEnumerator();
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator()
                => new DisposableEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator()
                => new DisposableEnumerator();

            public struct Enumerator
            {
            }

            public struct DisposableEnumerator
                : IEnumerator<TResult>
            {
                public readonly TResult Current => default!;
                readonly TResult IEnumerator<TResult>.Current => default!;
                readonly object IEnumerator.Current => default!;

                public bool MoveNext()
                    => false;

                public readonly void Reset()
                    => throw new NotSupportedException();

                public void Dispose() { }
            }

            public int Count()
                => 0;

            public SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult2, SelectorCombination<TSelector, FunctionWrapper<TResult, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, TResult2> selector)
                => Select<FunctionWrapper<TResult, TResult2>, TResult2>(new FunctionWrapper<TResult, TResult2>(selector));

            public SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult2, SelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TSelector2, TResult2>(TSelector2 selector)
                where TSelector2 : struct, IFunction<TResult, TResult2>
                => Select<TEnumerable, TEnumerator, TSource, TResult2, SelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(source, new SelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));
        }
    }
}

