using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class ReadOnlyCollection
    {
        static bool Contains<TSource>(this IReadOnlyCollection<TSource> source, TSource value)
        {
            if (source.Count == 0)
                return false;

            if (source is ICollection<TSource> collection)
                return collection.Contains(value);

            return default(TSource) is null
                ? ReferenceContains(source, value) 
                : ValueContains(source, value);

            static bool ValueContains(IReadOnlyCollection<TSource> source, TSource value)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (EqualityComparer<TSource>.Default.Equals(enumerator.Current, value))
                        return true;
                }
                return false;
            }

            static bool ReferenceContains(IReadOnlyCollection<TSource> source, TSource value)
            {
                var defaultComparer = EqualityComparer<TSource>.Default;
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (defaultComparer.Equals(enumerator.Current, value))
                        return true;
                }
                return false;
            }
        }
    }
}
