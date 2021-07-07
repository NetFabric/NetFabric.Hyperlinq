using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {


        static Option<TSource> Single<TList, TSource>(this TList source) 
            where TList : struct, IReadOnlyList<TSource>
            => source switch
            {
                { Count: 1 } => Option.Some(source[0]),
                _ => Option.None,
            };
        

        internal static Option<TResult> Single<TList, TSource, TResult, TSelector>(this TList source, TSelector selector)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => source switch
            {
                { Count: 1 } => Option.Some(selector.Invoke(source[0])),
                _ => Option.None,
            };

        

        internal static Option<TResult> SingleAt<TList, TSource, TResult, TSelector>(this TList source, TSelector selector)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source switch
            {
                { Count: 1 } => Option.Some(selector.Invoke(source[0], 0)),
                _ => Option.None,
            };
    }
}
