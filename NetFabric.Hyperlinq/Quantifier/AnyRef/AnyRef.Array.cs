using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this TSource[] source, FunctionIn<TSource, bool> predicate)
            => source.AnyRef(new FunctionInWrapper<TSource, bool>(predicate));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AnyRef<TSource, TPredicate>(this TSource[] source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            => source.AsSpan().AnyRef(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this TSource[] source, FunctionIn<TSource, int, bool> predicate)
            => source.AnyAtRef(new FunctionInWrapper<TSource, int, bool>(predicate));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AnyAtRef<TSource, TPredicate>(this TSource[] source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
            => source.AsSpan().AnyAtRef(predicate);
    }
}

