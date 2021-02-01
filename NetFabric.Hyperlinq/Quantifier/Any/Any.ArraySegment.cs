using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this in ArraySegment<TSource> source)
            => source.Count is not 0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this in ArraySegment<TSource> source, Func<TSource, bool> predicate)
            => source.AsSpan().Any(predicate);

        public static bool Any<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, bool>
            => source.AsSpan().Any(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this in ArraySegment<TSource> source, Func<TSource, int, bool> predicate)
            => source.AsSpan().Any(predicate);

        public static bool AnyAt<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.AsSpan().AnyAt(predicate);
    }
}

