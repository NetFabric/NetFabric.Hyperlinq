using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {
        
        public static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var array = new TSource[source.Count];
            if (source.Count != 0)
            {
                switch(source)
                {
                    case ICollection<TSource> collection:
                        collection.CopyTo(array, 0);
                        break;

                    default:
                        {
                            using var enumerator = source.GetEnumerator();
                            for (var index = 0; enumerator.MoveNext(); index++)
                                array[index] = enumerator.Current;
                        }
                        break;
                }
            }
            return array;
        }

        
        static TResult[] ToArray<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Selector<TSource, TResult> selector)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var array = new TResult[source.Count];
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                for (var index = 0; enumerator.MoveNext(); index++)
                    array[index] = selector(enumerator.Current)!;
            }
            return array;
        }

        
        static TResult[] ToArray<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, SelectorAt<TSource, TResult> selector)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            var array = new TResult[source.Count];
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                for (var index = 0; enumerator.MoveNext(); index++)
                    array[index] = selector(enumerator.Current, index)!;
            }
            return array;
        }
    }
}
