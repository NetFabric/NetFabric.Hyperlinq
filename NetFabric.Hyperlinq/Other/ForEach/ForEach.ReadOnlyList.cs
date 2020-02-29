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
            if (skipCount == 0 && takeCount == source.Count)
            {
                for (var index = 0; index < source.Count; index++)
                    action(source[index]);
            }
            else
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                    action(source[index]);
            }
        }

        static void ForEach<TList, TSource>(this TList source, Action<TSource> action, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (skipCount == 0 && takeCount == source.Count)
            {
                for (var index = 0; index < source.Count; index++)
                {
                    var item = source[index];
                    if (predicate(item))
                        action(item);
                }
            }
            else
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    var item = source[index];
                    if (predicate(item))
                        action(item);
                }
            }
        }

        static void ForEach<TList, TSource>(this TList source, Action<TSource> action, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (skipCount == 0 && takeCount == source.Count)
            {
                for (var index = 0; index < source.Count; index++)
                {
                    var item = source[index];
                    if (predicate(item, index))
                        action(item);
                }
            }
            else
            {
                for (var index = 0; index < takeCount; index++)
                {
                    var item = source[index + skipCount];
                    if (predicate(item, index))
                        action(item);
                }
            }
        }

        static void ForEach<TList, TSource, TResult>(this TList source, Action<TResult> action, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (skipCount == 0 && takeCount == source.Count)
            {
                for (var index = 0; index < source.Count; index++)
                    action(selector(source[index]));
            }
            else
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                    action(selector(source[index]));
            }
        }

        static void ForEach<TList, TSource, TResult>(this TList source, Action<TResult> action, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (skipCount == 0 && takeCount == source.Count)
            {
                for (var index = 0; index < source.Count; index++)
                    action(selector(source[index], index));
            }
            else
            {
                for (var index = 0; index < takeCount; index++)
                    action(selector(source[index + skipCount], index));
            }
        }

        static void ForEach<TList, TSource, TResult>(this TList source, Action<TResult> action, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (skipCount == 0 && takeCount == source.Count)
            {
                for (var index = 0; index < source.Count; index++)
                {
                    var item = source[index];
                    if (predicate(item))
                        action(selector(item));
                }
            }
            else
            {
                var end = skipCount + takeCount;
                for (var index = skipCount; index < end; index++)
                {
                    var item = source[index];
                    if (predicate(item))
                        action(selector(item));
                }
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
            if (skipCount == 0 && takeCount == source.Count)
            {
                for (var index = 0; index < source.Count; index++)
                    action(source[index], index);
            }
            else
            {
                for (var index = 0; index < takeCount; index++)
                    action(source[index + skipCount], index);
            }
        }

        static void ForEach<TList, TSource>(this TList source, ActionAt<TSource> action, Predicate<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (skipCount == 0 && takeCount == source.Count)
            {
                for (var index = 0; index < source.Count; index++)
                {
                    var item = source[index];
                    if (predicate(item))
                        action(item, index);
                }
            }
            else
            {
                for (var index = 0; index < takeCount; index++)
                {
                    var item = source[index + skipCount];
                    if (predicate(item))
                        action(item, index);
                }
            }
        }

        static void ForEach<TList, TSource>(this TList source, ActionAt<TSource> action, PredicateAt<TSource> predicate, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (skipCount == 0 && takeCount == source.Count)
            {
                for (var index = 0; index < source.Count; index++)
                {
                    var item = source[index];
                    if (predicate(item, index))
                        action(item, index);
                }
            }
            else
            {
                for (var index = 0; index < takeCount; index++)
                {
                    var item = source[index + skipCount];
                    if (predicate(item, index))
                        action(item, index);
                }
            }
        }

        static void ForEach<TList, TSource, TResult>(this TList source, ActionAt<TResult> action, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (skipCount == 0 && takeCount == source.Count)
            {
                for (var index = 0; index < source.Count; index++)
                    action(selector(source[index]), index);
            }
            else
            {
                for (var index = 0; index < takeCount; index++)
                    action(selector(source[index + skipCount]), index);
            }
        }

        static void ForEach<TList, TSource, TResult>(this TList source, ActionAt<TResult> action, SelectorAt<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (skipCount == 0 && takeCount == source.Count)
            {
                for (var index = 0; index < source.Count; index++)
                    action(selector(source[index], index), index);
            }
            else
            {
                for (var index = 0; index < skipCount; index++)
                    action(selector(source[index + skipCount], index), index);
            }
        }

        static void ForEach<TList, TSource, TResult>(this TList source, ActionAt<TResult> action, Predicate<TSource> predicate, Selector<TSource, TResult> selector, int skipCount, int takeCount)
            where TList : notnull, IReadOnlyList<TSource>
        {
            if (skipCount == 0 && takeCount == source.Count)
            {
                for (var index = 0; index < source.Count; index++)
                {
                    var item = source[index];
                    if (predicate(item))
                        action(selector(item), index);
                }
            }
            else
            {
                for (var index = 0; index < takeCount; index++)
                {
                    var item = source[index + skipCount];
                    if (predicate(item))
                        action(selector(item), index);
                }
            }
        }
    }
}

