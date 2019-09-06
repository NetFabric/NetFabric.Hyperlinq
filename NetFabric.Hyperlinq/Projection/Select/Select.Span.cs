using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        [Pure]
        public static SelectEnumerable<TSource, TResult> Select<TSource, TResult>(
            this Span<TSource> source, 
            Func<TSource, TResult> selector)
        {
            if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

            return new SelectEnumerable<TSource, TResult>(in source, selector);
        }

        public readonly ref struct SelectEnumerable<TSource, TResult>
        {
            internal readonly Span<TSource> source;
            internal readonly Func<TSource, TResult> selector;

            internal SelectEnumerable(in Span<TSource> source, Func<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public ref struct Enumerator
            {
                readonly Span<TSource> source;
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

                public TResult Current 
                    => selector(source[index]);

                public bool MoveNext() 
                    => ++index < count;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Count()
                => source.Length;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult First()
                => selector(source.First());

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult FirstOrDefault()
                => selector(source.FirstOrDefault());

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult Single()
                => selector(source.Single());

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult SingleOrDefault()
                => selector(source.SingleOrDefault());

            public void ForEach(Action<TResult> action)
            {
                for (var index = 0; index < source.Length; index++)
                    action(selector(source[index]));
            }
            public void ForEach(Action<TResult, int> action)
            {
                for (var index = 0; index < source.Length; index++)
                    action(selector(source[index]), index);
            }
        }
    }
}

