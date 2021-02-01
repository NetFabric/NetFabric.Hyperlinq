using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this in ArraySegment<TSource> source, FunctionIn<TSource, bool> predicate)
            => source.AsSpan().Any(predicate);

        public static bool AnyRef<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            => source.AsSpan().AnyRef(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this in ArraySegment<TSource> source, FunctionIn<TSource, int, bool> predicate)
            => source.AsSpan().Any(predicate);

        public static bool AnyAtRef<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
            => source.AsSpan().AnyAtRef(predicate);
    }
}

