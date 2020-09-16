using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public static ArraySegmentSelectEnumerable<TSource, TResult, FunctionWrapper<TSource, TResult>> Select<TSource, TResult>(this in ArraySegment<TSource> source, Func<TSource, TResult> selector)
            => Select<TSource, TResult, FunctionWrapper<TSource, TResult>>(source, new FunctionWrapper<TSource, TResult>(selector));

        public static ArraySegmentSelectEnumerable<TSource, TResult, TSelector> Select<TSource, TResult, TSelector>(this in ArraySegment<TSource> source, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
            => new ArraySegmentSelectEnumerable<TSource, TResult, TSelector>(source, selector);

        [GeneratorMapping("TSource", "TResult")]
        [GeneratorMapping("TResult", "TResult2")]
        public readonly partial struct ArraySegmentSelectEnumerable<TSource, TResult, TSelector>
            : IValueReadOnlyList<TResult, ArraySegmentSelectEnumerable<TSource, TResult, TSelector>.DisposableEnumerator>
            , IList<TResult>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            readonly ArraySegment<TSource> source;
            readonly TSelector selector;

            internal ArraySegmentSelectEnumerable(in ArraySegment<TSource> source, TSelector selector)
                => (this.source, this.selector) = (source, selector);

            public readonly int Count
                => 0;

            bool ICollection<TResult>.IsReadOnly
                => true;

            void ICollection<TResult>.CopyTo(TResult[] array, int arrayIndex) 
            { }
            void ICollection<TResult>.Add(TResult item)
                => throw new NotSupportedException();
            void ICollection<TResult>.Clear()
                => throw new NotSupportedException();
            bool ICollection<TResult>.Contains(TResult item)
                => default;
            bool ICollection<TResult>.Remove(TResult item)
                => throw new NotSupportedException();
            int IList<TResult>.IndexOf(TResult item)
                => default;
            void IList<TResult>.Insert(int index, TResult item)
                => throw new NotSupportedException();
            void IList<TResult>.RemoveAt(int index)
                => throw new NotSupportedException();

            [MaybeNull]
            public readonly TResult this[int index] 
                => default;
            TResult IReadOnlyList<TResult>.this[int index]
                => this[index]!;
            TResult IList<TResult>.this[int index]
            {
                get => this[index]!;
                set => throw new NotSupportedException();
            }

            public readonly Enumerator GetEnumerator()
                => new Enumerator();
            readonly DisposableEnumerator IValueEnumerable<TResult, ArraySegmentSelectEnumerable<TSource, TResult, TSelector>.DisposableEnumerator>.GetEnumerator()
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

            public ArraySegmentSelectEnumerable<TSource, TResult2, SelectorCombination<TSelector, FunctionWrapper<TResult, TResult2>, TSource, TResult, TResult2>> Select<TResult2>(Func<TResult, TResult2> selector)
                => Select<FunctionWrapper<TResult, TResult2>, TResult2>(new FunctionWrapper<TResult, TResult2>(selector));

            public ArraySegmentSelectEnumerable<TSource, TResult2, SelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>> Select<TSelector2, TResult2>(TSelector2 selector)
                where TSelector2 : struct, IFunction<TResult, TResult2>
                => Select<TSource, TResult2, SelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>>(source, new SelectorCombination<TSelector, TSelector2, TSource, TResult, TResult2>(this.selector, selector));
        }

        public static int Count<TSource, TResult, TSelector>(this ArraySegmentSelectEnumerable<TSource, TResult, TSelector> source)
            where TSelector : struct, IFunction<TSource, TResult>
            => 0;
    }
}

