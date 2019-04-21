using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static bool All<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.Count == 0) return false;

            using (var enumerator = source.GetValueEnumerator())
            {
                var index = 0;
                while (enumerator.TryMoveNext(out var current))
                {
                    unchecked // always less than source.Count
                    {
                        if (!predicate(current, index))
                            return false;
                            
                        index++;
                    }
                }
            }
            return true;
        }
    }
}

