using System;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        public static void ForEach<TSource>(this ReadOnlySpan<TSource> source, Action<TSource> action)
        {
            for (var index = 0; index < source.Length; index++)
                action(source[index]);
        }

        static void ForEach<TSource>(this ReadOnlySpan<TSource> source, Action<TSource> action, Predicate<TSource> predicate)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    action(source[index]);
            }
        }

        static void ForEach<TSource>(this ReadOnlySpan<TSource> source, Action<TSource> action, PredicateAt<TSource> predicate)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index], index))
                    action(source[index]);
            }
        }

        static void ForEach<TSource, TResult>(this ReadOnlySpan<TSource> source, Action<TResult> action, Selector<TSource, TResult> selector)
        {
            for (var index = 0; index < source.Length; index++)
                action(selector(source[index]));
        }

        static void ForEach<TSource, TResult>(this ReadOnlySpan<TSource> source, Action<TResult> action, SelectorAt<TSource, TResult> selector)
        {
            for (var index = 0; index < source.Length; index++)
                action(selector(source[index], index));
        }

        static void ForEach<TSource, TResult>(this ReadOnlySpan<TSource> source, Action<TResult> action, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    action(selector(source[index]));
            }
        }

        public static void ForEach<TSource>(this ReadOnlySpan<TSource> source, Action<TSource, int> action)
        {
            for (var index = 0; index < source.Length; index++)
                action(source[index], index);
        }

        static void ForEach<TSource>(this ReadOnlySpan<TSource> source, Action<TSource, int> action, Predicate<TSource> predicate)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    action(source[index], index);
            }
        }

        static void ForEach<TSource>(this ReadOnlySpan<TSource> source, Action<TSource, int> action, PredicateAt<TSource> predicate)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index], index))
                    action(source[index], index);
            }
        }

        static void ForEach<TSource, TResult>(this ReadOnlySpan<TSource> source, Action<TResult, int> action, Selector<TSource, TResult> selector)
        {
            for (var index = 0; index < source.Length; index++)
                action(selector(source[index]), index);
        }

        static void ForEach<TSource, TResult>(this ReadOnlySpan<TSource> source, Action<TResult, int> action, SelectorAt<TSource, TResult> selector)
        {
            for (var index = 0; index < source.Length; index++)
                action(selector(source[index], index), index);
        }

        static void ForEach<TSource, TResult>(this ReadOnlySpan<TSource> source, Action<TResult, int> action, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    action(selector(source[index]), index);
            }
        }
    }
}

