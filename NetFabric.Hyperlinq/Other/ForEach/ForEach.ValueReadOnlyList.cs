using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Action<TSource> action)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (action is null) Throw.ArgumentNullException(nameof(action));

            ForEach<TEnumerable, TEnumerator, TSource>(source, action, 0, source.Count);
        }

        static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Action<TSource> action, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
                action(source[index]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Action<TSource, int> action)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (action is null) Throw.ArgumentNullException(nameof(action));

            ForEach<TEnumerable, TEnumerator, TSource>(source, action, 0, source.Count);
        }

        static void ForEach<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Action<TSource, int> action, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            for (var index = 0; index < takeCount; index++)
                action(source[index + skipCount], index);
        }
    }
}

