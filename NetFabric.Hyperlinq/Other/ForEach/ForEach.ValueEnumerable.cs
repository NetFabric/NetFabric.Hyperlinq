using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Action<TSource> action)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (action is null) Throw.ArgumentNullException(nameof(action));

            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
                action(enumerator.Current);
        }

        static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Action<TSource> action, Predicate<TSource> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (predicate(enumerator.Current))
                    action(enumerator.Current);
            }
        }

        static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Action<TSource> action, PredicateAt<TSource> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                {
                    if (predicate(enumerator.Current, index))
                        action(enumerator.Current);
                }
            }
        }

        static void ForEach<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Action<TResult> action, Selector<TSource, TResult> selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
                action(selector(enumerator.Current));
        }

        static void ForEach<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Action<TResult> action, SelectorAt<TSource, TResult> selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                    action(selector(enumerator.Current, index));
            }
        }

        static void ForEach<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Action<TResult> action, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (predicate(enumerator.Current))
                    action(selector(enumerator.Current));
            }
        }

        public static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Action<TSource, int> action)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (action is null) Throw.ArgumentNullException(nameof(action));

            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0;  enumerator.MoveNext(); index++)
                    action(enumerator.Current, index);
            }
        }

        static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Action<TSource, int> action, Predicate<TSource> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0;  enumerator.MoveNext(); index++)
                {
                    if (predicate(enumerator.Current))
                        action(enumerator.Current, index);
                }
            }
        }

        static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Action<TSource, int> action, PredicateAt<TSource> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0;  enumerator.MoveNext(); index++)
                {
                    if (predicate(enumerator.Current, index))
                        action(enumerator.Current, index);
                }
            }
        }

        static void ForEach<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Action<TResult, int> action, Selector<TSource, TResult> selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                    action(selector(enumerator.Current), index);
            }
        }

        static void ForEach<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Action<TResult, int> action, SelectorAt<TSource, TResult> selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                    action(selector(enumerator.Current, index), index);
            }
        }

        static void ForEach<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Action<TResult, int> action, Predicate<TSource> predicate, Selector<TSource, TResult> selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using var enumerator = source.GetEnumerator();
            checked
            {
                for (var index = 0;  enumerator.MoveNext(); index++)
                {
                    if (predicate(enumerator.Current))
                        action(selector(enumerator.Current), index);
                }
            }
        }
    }
}

