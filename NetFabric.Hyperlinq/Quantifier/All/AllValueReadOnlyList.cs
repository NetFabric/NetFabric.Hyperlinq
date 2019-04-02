using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        public static bool All<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            var count = source.Count();
            if (count == 0) return false;

            for (var index = 0; index < count; index++)
            {
                if (!predicate(source[index]))
                    return false;
            }
            return true;
        }
    }
}

