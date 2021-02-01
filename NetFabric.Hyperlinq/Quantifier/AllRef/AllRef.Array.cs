using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AllRef<TSource>(this TSource[] source, FunctionIn<TSource, bool> predicate)
            => source.AllRef(new FunctionInWrapper<TSource, bool>(predicate));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AllRef<TSource, TPredicate>(this TSource[] source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            => source.AsSpan().AllRef(predicate);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AllRef<TSource>(this TSource[] source, FunctionIn<TSource, int, bool> predicate)
            => source.AllAtRef(new FunctionInWrapper<TSource, int, bool>(predicate));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AllAtRef<TSource, TPredicate>(this TSource[] source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
            => source.AsSpan().AllAtRef(predicate);
    }
}

