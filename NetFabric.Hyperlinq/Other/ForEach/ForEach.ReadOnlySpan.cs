using System;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
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
                var item = source[index];
                if (predicate(item))
                    action(item);
            }
        }

        static void ForEach<TSource>(this ReadOnlySpan<TSource> source, Action<TSource> action, PredicateAt<TSource> predicate)
        {
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (predicate(item, index))
                    action(item);
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
                var item = source[index];
                if (predicate(item))
                    action(selector(item));
            }
        }

        public static void ForEach<TSource>(this ReadOnlySpan<TSource> source, ActionAt<TSource> action)
        {
            for (var index = 0; index < source.Length; index++)
                action(source[index], index);
        }

        static void ForEach<TSource>(this ReadOnlySpan<TSource> source, ActionAt<TSource> action, Predicate<TSource> predicate)
        {
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (predicate(item))
                    action(item, index);
            }
        }

        static void ForEach<TSource>(this ReadOnlySpan<TSource> source, ActionAt<TSource> action, PredicateAt<TSource> predicate)
        {
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (predicate(item, index))
                    action(item, index);
            }
        }

        static void ForEach<TSource, TResult>(this ReadOnlySpan<TSource> source, ActionAt<TResult> action, Selector<TSource, TResult> selector)
        {
            for (var index = 0; index < source.Length; index++)
                action(selector(source[index]), index);
        }

        static void ForEach<TSource, TResult>(this ReadOnlySpan<TSource> source, ActionAt<TResult> action, SelectorAt<TSource, TResult> selector)
        {
            for (var index = 0; index < source.Length; index++)
                action(selector(source[index], index), index);
        }

        static void ForEach<TSource, TResult>(this ReadOnlySpan<TSource> source, ActionAt<TResult> action, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
        {
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (predicate(item))
                    action(selector(item), index);
            }
        }
    }
}

