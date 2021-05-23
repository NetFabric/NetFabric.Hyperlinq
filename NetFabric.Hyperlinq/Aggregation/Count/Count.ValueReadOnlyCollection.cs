using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {
        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count;
        
        [GeneratorIgnore]
        static int Count<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate: struct, IFunction<TSource, bool>
            => source switch
            {
                {Count: 0} => 0,
                _ => ValueEnumerableExtensions.Count<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate)
            };
        
        [GeneratorIgnore]
        static int CountAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate: struct, IFunction<TSource, int, bool>
            => source switch
            {
                {Count: 0} => 0,
                _ => ValueEnumerableExtensions.CountAt<TEnumerable, TEnumerator, TSource, TPredicate>(source, predicate)
            };

    }
}

