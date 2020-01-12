using System;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static void ForEach<TSource>(this TSource[] source, Action<TSource> action)
        {
            if (action is null) Throw.ArgumentNullException(nameof(action));

            for (var index = 0; index < source.Length; index++)
                action(source[index]);
        }

        static void ForEach<TSource>(this TSource[] source, Action<TSource> action, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                action(source[index]);
        }

        static void ForEach<TSource>(this TSource[] source, Action<TSource> action, Predicate<TSource> predicate, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    action(source[index]);
            }
        }

        static void ForEach<TSource>(this TSource[] source, Action<TSource> action, PredicateAt<TSource> predicate, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index - skipCount))
                    action(source[index]);
            }
        }

        static void ForEach<TSource, TResult>(this TSource[] source, Action<TResult> action, Selector<TSource, TResult> selector, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                action(selector(source[index]));
        }

        static void ForEach<TSource, TResult>(this TSource[] source, Action<TResult> action, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                action(selector(source[index], index - skipCount));
        }

        static void ForEach<TSource, TResult>(this TSource[] source, Action<TResult> action, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    action(selector(source[index]));
            }
        }

        public static void ForEach<TSource>(this TSource[] source, Action<TSource, int> action)
        {
            if (action is null) Throw.ArgumentNullException(nameof(action));

            for (var index = 0; index < source.Length; index++)
                action(source[index], index);
        }

        static void ForEach<TSource>(this TSource[] source, Action<TSource, int> action, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                action(source[index], index - skipCount);
        }

        static void ForEach<TSource>(this TSource[] source, Action<TSource, int> action, Predicate<TSource> predicate, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    action(source[index], index - skipCount);
            }
        }

        static void ForEach<TSource>(this TSource[] source, Action<TSource, int> action, PredicateAt<TSource> predicate, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index - skipCount))
                    action(source[index], index - skipCount);
            }
        }

        static void ForEach<TSource, TResult>(this TSource[] source, Action<TResult, int> action, Selector<TSource, TResult> selector, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                action(selector(source[index]), index - skipCount);
        }

        static void ForEach<TSource, TResult>(this TSource[] source, Action<TResult, int> action, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                var baseIndex = index - skipCount;
                action(selector(source[index], baseIndex), baseIndex);
            }
        }

        static void ForEach<TSource, TResult>(this TSource[] source, Action<TResult, int> action, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    action(selector(source[index]), index - skipCount);
            }
        }
    }
}

