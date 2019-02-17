using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static TSource FirstOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (source.Count == 0) return default;

#if EXPRESSION_TREES
            return Enumerable.FirstOrDefaultMethod<TEnumerable, TSource>.Invoke(source);
#else            
            using (var enumerator = (TEnumerator)source.GetEnumerator())
            {
                enumerator.MoveNext();
                return enumerator.Current;
            }
#endif
        }
    }
}
