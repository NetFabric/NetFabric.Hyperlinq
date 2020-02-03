using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static void ForEach<TList, TSource>(this TList source, Action<TSource> action)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (action is null) Throw.ArgumentNullException(nameof(action));

            ForEach<TList, TSource>(source, action, 0, source.Count);
        }

        static void ForEach<TList, TSource>(this TList source, Action<TSource> action, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                action(source[index]);
        }

        static void ForEach<TList, TSource>(this TList source, Action<TSource> action, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    action(source[index]);
            }
        }

        static void ForEach<TList, TSource>(this TList source, Action<TSource> action, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index - skipCount))
                    action(source[index]);
            }
        }

        static void ForEach<TList, TSource, TResult>(this TList source, Action<TResult> action, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                action(selector(source[index]));
        }

        static void ForEach<TList, TSource, TResult>(this TList source, Action<TResult> action, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                action(selector(source[index], index - skipCount));
        }

        static void ForEach<TList, TSource, TResult>(this TList source, Action<TResult> action, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    action(selector(source[index]));
            }
        }

        public static void ForEach<TList, TSource>(this TList source, ActionAt<TSource> action)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (action is null) Throw.ArgumentNullException(nameof(action));

            ForEach<TList, TSource>(source, action, 0, source.Count);
        }

        static void ForEach<TList, TSource>(this TList source, ActionAt<TSource> action, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                action(source[index], index - skipCount);
        }

        static void ForEach<TList, TSource>(this TList source, ActionAt<TSource> action, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    action(source[index], index - skipCount);
            }
        }

        static void ForEach<TList, TSource>(this TList source, ActionAt<TSource> action, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index - skipCount))
                    action(source[index], index - skipCount);
            }
        }

        static void ForEach<TList, TSource, TResult>(this TList source, ActionAt<TResult> action, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                action(selector(source[index]), index - skipCount);
        }

        static void ForEach<TList, TSource, TResult>(this TList source, ActionAt<TResult> action, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                var baseIndex = index - skipCount;
                action(selector(source[index], baseIndex), baseIndex);
            }
        }

        static void ForEach<TList, TSource, TResult>(this TList source, ActionAt<TResult> action, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
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

