using System;
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
                ElementResult.Empty => ThrowHelper.ThrowEmptySequence<TValue>(),
                ElementResult.NotSingle => ThrowHelper.ThrowNotSingleSequence<TValue>(),
                _ => item.Value,
            };

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue ThrowOnEmpty<TValue>(this (int Index, TValue Value) item)
            => item.Index switch
            {
                (int)ElementResult.Empty => ThrowHelper.ThrowEmptySequence<TValue>(),
                (int)ElementResult.NotSingle => ThrowHelper.ThrowNotSingleSequence<TValue>(),
                _ => item.Value,
            };

        /////////////////////////////////////////////////////

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue DefaultOnEmpty<TValue>(this (ElementResult Result, TValue Value) item)
            => item.Result switch
            {
                ElementResult.Empty => default,
                ElementResult.NotSingle => ThrowHelper.ThrowNotSingleSequence<TValue>(),
                _ => item.Value,
            };

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue DefaultOnEmpty<TValue>(this (int Index, TValue Value) item)
            => item.Index switch
            {
                (int)ElementResult.Empty => default,
                (int)ElementResult.NotSingle => ThrowHelper.ThrowNotSingleSequence<TValue>(),
                _ => item.Value,
            };

        /////////////////////////////////////////////////////

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Maybe<TValue> AsMaybe<TValue>(this (ElementResult Result, TValue Value) item)
            => item.Result switch
            {
                ElementResult.Success => new Maybe<TValue>(item.Value),
                _ => default,
            };

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MaybeAt<TValue> AsMaybe<TValue>(this (int Index, TValue Value) item) 
            => item.Index < 0 ? default : new MaybeAt<TValue>(item.Value, item.Index);
    }
}
