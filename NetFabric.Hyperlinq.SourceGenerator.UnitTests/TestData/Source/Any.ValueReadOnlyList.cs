using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyListExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TList, TSource>(this TList source)
            where TList : struct, IReadOnlyList<TSource>
            => source.Count is not 0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TList, TSource>(this TList source, Func<TSource, bool> predicate)
            where TList : struct, IReadOnlyList<TSource>
            => source.Any<TList, TSource, FunctionWrapper<TSource, bool>>(new FunctionWrapper<TSource, bool>(predicate));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TList, TSource, TPredicate>(this TList source, TPredicate predicate = default)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            => default;
    }
}

