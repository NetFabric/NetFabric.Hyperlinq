using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public enum ElementResult
    {
        Success = 0,
        Empty = -1,
        NotSingle = -2,
    }

    /////////////////////////////////////////////////////

    public static partial class ElementExtensions
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue ThrowOnEmpty<TValue>(this (ElementResult Result, TValue Value) item)
            => item.Result switch
            {
                ElementResult.Empty => Throw.EmptySequence<TValue>(),
                ElementResult.NotSingle => Throw.NotSingleSequence<TValue>(),
                _ => item.Value,
            };

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue ThrowOnEmpty<TValue>(this (ElementResult Result, TValue Value, int Index) item)
            => item.Result switch
            {
                ElementResult.Empty => Throw.EmptySequence<TValue>(),
                ElementResult.NotSingle => Throw.NotSingleSequence<TValue>(),
                _ => item.Value,
            };

        /////////////////////////////////////////////////////

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return:MaybeNull]
        public static TValue DefaultOnEmpty<TValue>(this (ElementResult Result, TValue Value) item)
            => item.Result switch
            {
                ElementResult.Empty => default!,
                ElementResult.NotSingle => Throw.NotSingleSequence<TValue>(),
                _ => item.Value,
            };

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return:MaybeNull]
        public static TValue DefaultOnEmpty<TValue>(this (ElementResult Result, TValue Value, int Index) item)
            => item.Result switch
            {
                ElementResult.Empty => default!,
                ElementResult.NotSingle => Throw.NotSingleSequence<TValue>(),
                _ => item.Value,
            };
    }
}
