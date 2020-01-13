using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this TSource[] source, Predicate<TSource> predicate) 
            => predicate is null 
                ? Throw.ArgumentNullException<bool>(nameof(predicate)) 
                : All<TSource>(source, predicate, 0, source.Length);

        [Pure]
        static bool All<TSource>(this TSource[] source, Predicate<TSource> predicate, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (!predicate(source[index]))
                    return false;
            }
            return true;
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this TSource[] source, PredicateAt<TSource> predicate) 
            => predicate is null 
                ? Throw.ArgumentNullException<bool>(nameof(predicate)) 
                : All<TSource>(source, predicate, 0, source.Length);

        [Pure]
        static bool All<TSource>(this TSource[] source, PredicateAt<TSource> predicate, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (!predicate(source[index], index))
                    return false;
            }
            return true;
        }
    }
}

