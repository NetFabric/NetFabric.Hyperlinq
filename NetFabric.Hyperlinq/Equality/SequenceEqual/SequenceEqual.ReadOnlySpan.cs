using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        static bool SequenceEqual<TEnumerable, TEnumerator, TSource>(this ReadOnlySpan<TSource> first, TEnumerable second, IEqualityComparer<TSource>? comparer = default)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            comparer ??= EqualityComparer<TSource>.Default;

            using var enumerator = second.GetEnumerator();
            for (var index = 0; true; index++)
            {
                var firstEnded = index == first.Length;
                var secondEnded = !enumerator.MoveNext();

                if (firstEnded != secondEnded)
                    return false;

                if (firstEnded)
                    return true;

                if (comparer.Equals(first[index], enumerator.Current))
                    return false;
            }
        }

        //public static bool SequenceEqual<TEnumerable, TEnumerator, TSource>(this ReadOnlySpan<TSource> first, TEnumerable second, IEqualityComparer<TSource>? comparer = default)
        //    where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
        //    where TEnumerator : struct, IEnumerator<TSource>
        //{
        //    comparer ??= EqualityComparer<TSource>.Default;

        //    if (first.Length != second.Count)
        //        return false;

        //    using var enumerator = second.GetEnumerator();
        //    for (var index = 0; index < first; index++)
        //    {
        //        var firstEnded = index == first.Length;
        //        var secondEnded = !enumerator.MoveNext();

        //        if (firstEnded != secondEnded)
        //            return false;

        //        if (firstEnded)
        //            return true;

        //        if (comparer.Equals(enumerator.Current, enumerator.Current))
        //            return false;
        //    }
        //}
    }
}
