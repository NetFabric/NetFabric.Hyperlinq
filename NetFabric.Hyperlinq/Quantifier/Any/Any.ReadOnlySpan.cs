using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this ReadOnlySpan<TSource> source)
            => source.Length != 0;

        
        static bool Any<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IPredicate<TSource>
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate.Invoke(source[index]))
                    return true;
            }
            return false;
        }

        
        static bool AnyAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IPredicateAt<TSource>
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (predicate.Invoke(source[index], index))
                    return true;
            }
            return false;
        }
    }
}

