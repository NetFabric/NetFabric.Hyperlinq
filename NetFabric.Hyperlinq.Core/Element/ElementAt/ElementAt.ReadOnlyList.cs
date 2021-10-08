using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TSource> ElementAt<TList, TSource>(this TList source, int index) 
            where TList : struct, IReadOnlyList<TSource>
            => index < 0 || index >= source.Count 
                ? Option.None 
                : Option.Some(source[index]);

        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Option<TResult> ElementAt<TList, TSource, TResult, TSelector>(this TList source, int index, TSelector selector) 
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => index < 0 || index >= source.Count 
                ? Option.None 
                : Option.Some(selector.Invoke(source[index]));

        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Option<TResult> ElementAtAt<TList, TSource, TResult, TSelector>(this TList source, int index, TSelector selector) 
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            => index < 0 || index >= source.Count 
                ? Option.None 
                : Option.Some(selector.Invoke(source[index], index));
    }
}
