using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TSource> First<TList, TSource>(this TList source) 
            where TList : struct, IReadOnlyList<TSource>
            => source switch
            {
                { Count: 0 } => Option.None,
                _ => Option.Some(source[0])
            };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Option<TResult> First<TList, TSource, TResult, TSelector>(this TList source, TSelector selector)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => source switch
            {
                { Count: 0 } => Option.None,
                _ => Option.Some(selector.Invoke(source[0])),
            };



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Option<TResult> FirstAt<TList, TSource, TResult, TSelector>(this TList source, TSelector selector)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source switch
            {
                { Count: 0 } => Option.None,
                _ => Option.Some(selector.Invoke(source[0], 0)),
            };
    }
}
