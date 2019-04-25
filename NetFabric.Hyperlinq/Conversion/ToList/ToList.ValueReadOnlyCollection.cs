using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source.Count > int.MaxValue) 
                ThrowHelper.ThrowArgumentTooLargeException(nameof(source), source.Count);
                
            return new List<TSource>(ValueReadOnlyCollection.AsEnumerable<TEnumerable, TEnumerator, TSource>(source));
        }
    }
}
