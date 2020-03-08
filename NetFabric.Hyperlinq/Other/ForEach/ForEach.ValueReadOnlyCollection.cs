using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Action<TSource> action)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (action is null) Throw.ArgumentNullException(nameof(action));

            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                    action(enumerator.Current);
            }
        }
        static void ForEach<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Action<TResult> action, Selector<TSource, TResult> selector)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                    action(selector(enumerator.Current));
            }
        }

        static void ForEach<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Action<TResult> action, SelectorAt<TSource, TResult> selector)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                checked
                {
                    for (var index = 0; enumerator.MoveNext(); index++)
                        action(selector(enumerator.Current, index));
                }
            }
        }

        public static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, ActionAt<TSource> action)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (action is null) Throw.ArgumentNullException(nameof(action));

            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                checked
                {
                    for (var index = 0;  enumerator.MoveNext(); index++)
                        action(enumerator.Current, index);
                }
            }
        }

        static void ForEach<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, ActionAt<TResult> action, Selector<TSource, TResult> selector)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                checked
                {
                    for (var index = 0; enumerator.MoveNext(); index++)
                        action(selector(enumerator.Current), index);
                }
            }
        }

        static void ForEach<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, ActionAt<TResult> action, SelectorAt<TSource, TResult> selector)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                checked
                {
                    for (var index = 0; enumerator.MoveNext(); index++)
                        action(selector(enumerator.Current, index), index);
                }
            }
        }
    }
}

