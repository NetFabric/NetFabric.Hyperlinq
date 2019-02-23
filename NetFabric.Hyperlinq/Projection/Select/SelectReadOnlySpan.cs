using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlySpan
    {
        public static SelectEnumerable<TSource, TResult> Select<TSource, TResult>(
            this ReadOnlySpan<TSource> source, 
            Func<TSource, TResult> selector)
        {
            if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectEnumerable<TSource, TResult>(in source, selector);
        }

        public readonly ref struct SelectEnumerable<TSource, TResult>
        {
            readonly ReadOnlySpan<TSource> source;
            readonly Func<TSource, TResult> selector;

            internal SelectEnumerable(in ReadOnlySpan<TSource> source, Func<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public ref struct Enumerator
            {
                ReadOnlySpan<TSource> source;
                readonly Func<TSource, TResult> selector;
                readonly int count;
                int index;

                internal Enumerator(in SelectEnumerable<TSource, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    count = enumerable.source.Length;
                    index = -1;
                }

                public TResult Current => selector(source[index]);

                public bool MoveNext() => ++index < count;
            }

            public int Count()
                => source.Length;
        }
    }
}

