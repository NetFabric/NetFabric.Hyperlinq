using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public static bool SequenceEqual<TEnumerable, TEnumerator, TSource>(this ReadOnlySpan<TSource> first, TEnumerable second, IEqualityComparer<TSource>? comparer = null)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
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

                if (comparer.Equals(enumerator.Current, enumerator.Current))
                    return false;
            }
        }

        //public static bool SequenceEqual<TEnumerable, TEnumerator, TSource>(this ReadOnlySpan<TSource> first, TEnumerable second, IEqualityComparer<TSource>? comparer = null)
        //    where TEnumerable : notnull, IValueReadOnlyList<TSource, TEnumerator>
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
