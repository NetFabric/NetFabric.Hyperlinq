using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollectionExtensions
    {
        
        public static Option<TSource> First<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                if (enumerator.MoveNext())
                    return Option.Some(enumerator.Current);
            }
            return Option.None;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TResult?> First<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, NullableSelector<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                if (enumerator.MoveNext())
                    return Option.Some(selector(enumerator.Current));
            }
            return Option.None;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TResult?> First<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, NullableSelectorAt<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                if (enumerator.MoveNext())
                    return Option.Some(selector(enumerator.Current, 0));
            }
            return Option.None;
        }
    }
}
