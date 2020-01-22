using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Action<TSource> action)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (action is null) Throw.ArgumentNullException(nameof(action));

            for (var index = 0; index < source.Count; index++)
                action(source[index]);
        }

        static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Action<TSource> action, int skipCount, int takeCount)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                action(source[index]);
        }

        static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Action<TSource> action, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    action(source[index]);
            }
        }

        static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Action<TSource> action, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index - skipCount))
                    action(source[index]);
            }
        }

        static void ForEach<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Action<TResult> action, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                action(selector(source[index]));
        }

        static void ForEach<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Action<TResult> action, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                action(selector(source[index], index - skipCount));
        }

        static void ForEach<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Action<TResult> action, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    action(selector(source[index]));
            }
        }

        public static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, ActionAt<TSource> action)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (action is null) Throw.ArgumentNullException(nameof(action));

            for (var index = 0; index < source.Count; index++)
                action(source[index], index);
        }

        static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, ActionAt<TSource> action, int skipCount, int takeCount)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                action(source[index], index - skipCount);
        }

        static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, ActionAt<TSource> action, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    action(source[index], index - skipCount);
            }
        }

        static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, ActionAt<TSource> action, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index - skipCount))
                    action(source[index], index - skipCount);
            }
        }

        static void ForEach<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, ActionAt<TResult> action, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                action(selector(source[index]), index - skipCount);
        }

        static void ForEach<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, ActionAt<TResult> action, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                var baseIndex = index - skipCount;
                action(selector(source[index], baseIndex), baseIndex);
            }
        }

        static void ForEach<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, ActionAt<TResult> action, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
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

