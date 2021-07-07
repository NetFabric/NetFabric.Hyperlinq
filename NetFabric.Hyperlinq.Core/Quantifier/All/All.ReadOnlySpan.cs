using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool All<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
            => source.All(new FunctionWrapper<TSource, bool>(predicate));

        static bool All<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, bool>
        {
            foreach (var item in source)
            {
                if (!predicate.Invoke(item))
                    return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool All<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, int, bool> predicate)
            => source.AllAt(new FunctionWrapper<TSource, int, bool>(predicate));

        static bool AllAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                if (!predicate.Invoke(item, index))
                    return false;
            }
            return true;
        }
    }
}

