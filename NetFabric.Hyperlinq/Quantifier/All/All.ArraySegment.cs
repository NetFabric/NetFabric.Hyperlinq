using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this in ArraySegment<TSource> source, Func<TSource, bool> predicate)
            => source.AsSpan().All(predicate);

        public static bool All<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, bool>
            => source.AsSpan().All(predicate);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this in ArraySegment<TSource> source, Func<TSource, int, bool> predicate)
            => source.AsSpan().All(predicate);

        public static bool AllAt<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.AsSpan().AllAt(predicate);
    }
}

