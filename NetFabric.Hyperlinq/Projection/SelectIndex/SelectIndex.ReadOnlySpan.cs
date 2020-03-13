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
        public static SpanSelectIndexEnumerable<TSource, TResult> Select<TSource, TResult>(
            this ReadOnlySpan<TSource> source, 
            SelectorAt<TSource, TResult> selector)
        {
            if (selector is null) Throw.ArgumentNullException(nameof(selector));

            return new SpanSelectIndexEnumerable<TSource, TResult>(in source, selector);
        }

        [GeneratorMapping("TSource", "TResult")]
        public readonly ref struct SpanSelectIndexEnumerable<TSource, TResult>
        {
            internal readonly ReadOnlySpan<TSource> source;
            internal readonly SelectorAt<TSource, TResult> selector;

            internal SpanSelectIndexEnumerable(in ReadOnlySpan<TSource> source, SelectorAt<TSource, TResult> selector)
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

                    return selector(source[index], index);
                }
            }

            public ref struct Enumerator
            {
                readonly ReadOnlySpan<TSource> source;
                readonly SelectorAt<TSource, TResult> selector;
                int index;

                internal Enumerator(in SpanSelectIndexEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    index = -1;
                }

                public readonly TResult Current 
                    => selector(source[index], index);

                public bool MoveNext() 
                    => ++index < source.Length;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => source.Length != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TResult value, IEqualityComparer<TResult>? comparer = null)
                => Array.Contains(source, value, comparer, selector);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult ElementAt(int index)
                => Array.ElementAt<TSource, TResult>(source, index, selector);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TResult ElementAtOrDefault(int index)
                => Array.ElementAtOrDefault<TSource, TResult>(source, index, selector);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult First()
                => Array.First<TSource, TResult>(source, selector);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TResult FirstOrDefault()
                => Array.FirstOrDefault<TSource, TResult>(source, selector);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult Single()
                => Array.Single<TSource, TResult>(source, selector);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TResult SingleOrDefault()
                => Array.SingleOrDefault<TSource, TResult>(source, selector);

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
        public static int Count<TSource, TResult>(this SpanSelectIndexEnumerable<TSource, TResult> source)
            => source.Count;
    }
}

