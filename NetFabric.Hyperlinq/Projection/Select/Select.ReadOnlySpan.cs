using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        public static SpanSelectEnumerable<TSource, TResult> Select<TSource, TResult>(
            this ReadOnlySpan<TSource> source, 
            Selector<TSource, TResult> selector)
        {
            if (selector is null) Throw.ArgumentNullException(nameof(selector));

            return new SpanSelectEnumerable<TSource, TResult>(in source, selector);
        }

        [GeneratorMapping("TSource", "TResult")]
        public readonly ref struct SpanSelectEnumerable<TSource, TResult>
        {
            internal readonly ReadOnlySpan<TSource> source;
            internal readonly Selector<TSource, TResult> selector;

            internal SpanSelectEnumerable(in ReadOnlySpan<TSource> source, Selector<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            [Pure]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);

            public readonly int Count => source.Length;

            [MaybeNull]
            public readonly TResult this[int index]
            {
                get
                {
                    if (index < 0 || index >= source.Length)
                        Throw.ArgumentOutOfRangeException(nameof(index));

                    return selector(source[index]);
                }
            }

            public ref struct Enumerator
            {
                readonly ReadOnlySpan<TSource> source;
                readonly Selector<TSource, TResult> selector;
                int index;

                internal Enumerator(in SpanSelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    index = -1;
                }

                public readonly TResult Current 
                    => selector(source[index]);

                public bool MoveNext() 
                    => ++index < source.Length;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult First()
                => selector(source.First());

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TResult FirstOrDefault()
                => selector(source.FirstOrDefault());

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult Single()
                => selector(source.Single());

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TResult SingleOrDefault()
                => selector(source.SingleOrDefault());

            public TResult[] ToArray()
                => Array.ToArray(source, selector);

            public List<TResult> ToList()
                => Array.ToList(source, selector);

            public void ForEach(Action<TResult> action)
                => source.ForEach(action, selector);
            public void ForEach(ActionAt<TResult> action)
                => source.ForEach(action, selector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource, TResult>(this SpanSelectEnumerable<TSource, TResult> source)
            => source.Count;
    }
}

