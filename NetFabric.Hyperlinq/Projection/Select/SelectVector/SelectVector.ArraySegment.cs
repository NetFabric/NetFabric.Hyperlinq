using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static MemorySelectVectorContext<TSource, TResult, FunctionWrapper<Vector<TSource>, Vector<TResult>>, FunctionWrapper<TSource, TResult>> SelectVector<TSource, TResult>(this ArraySegment<TSource> source, Func<Vector<TSource>, Vector<TResult>> vectorSelector, Func<TSource, TResult> selector)
            where TSource : struct
            where TResult : struct
            => source.AsMemory().SelectVector(vectorSelector, selector);

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static MemorySelectVectorContext<TSource, TResult, TSelector, TSelector> SelectVector<TSource, TResult, TSelector>(this ArraySegment<TSource> source, TSelector selector = default)
            where TSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
            => source.AsMemory().SelectVector<TSource, TResult, TSelector>(selector);

        [GeneratorIgnore]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static MemorySelectVectorContext<TSource, TResult, TVectorSelector, TSelector> SelectVector<TSource, TResult, TVectorSelector, TSelector>(this ArraySegment<TSource> source, TVectorSelector vectorSelector = default, TSelector selector = default)
            where TVectorSelector : struct, IFunction<Vector<TSource>, Vector<TResult>>
            where TSelector : struct, IFunction<TSource, TResult>
            where TSource : struct
            where TResult : struct
            => source.AsMemory().SelectVector<TSource, TResult, TVectorSelector, TSelector>(vectorSelector, selector);
    }
}

