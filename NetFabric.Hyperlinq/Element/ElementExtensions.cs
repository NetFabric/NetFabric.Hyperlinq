using System;
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue ThrowOnEmpty<TValue>(this (ElementResult Result, TValue Value) item)
        {
            switch (item.Result)
            {
                case ElementResult.Empty:
                    return ThrowHelper.ThrowEmptySequence<TValue>();
                case ElementResult.NotSingle:
                    return ThrowHelper.ThrowNotSingleSequence<TValue>();
                default:
                    return item.Value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue ThrowOnEmpty<TValue>(this (int Index, TValue Value) item)
        {
            switch (item.Index)
            {
                case (int)ElementResult.Empty:
                    return ThrowHelper.ThrowEmptySequence<TValue>();
                case (int)ElementResult.NotSingle:
                    return ThrowHelper.ThrowNotSingleSequence<TValue>();
                default:
                    return item.Value;
            }
        }

        /////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue DefaultOnEmpty<TValue>(this (ElementResult Result, TValue Value) item)
        {
            switch (item.Result)
            {
                case ElementResult.Empty:
                    return default;
                case ElementResult.NotSingle:
                    return ThrowHelper.ThrowNotSingleSequence<TValue>();
                default:
                    return item.Value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue DefaultOnEmpty<TValue>(this (int Index, TValue Value) item)
        {
            switch (item.Index)
            {
                case (int)ElementResult.Empty:
                    return default;
                case (int)ElementResult.NotSingle:
                    return ThrowHelper.ThrowNotSingleSequence<TValue>();
                default:
                    return item.Value;
            }
        }

        /////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue? NullOnEmpty<TValue>(this (ElementResult Result, TValue Value) item)
            where TValue : struct
        {
            switch (item.Result)
            {
                case ElementResult.Empty:
                    return null;
                case ElementResult.NotSingle:
                    return ThrowHelper.ThrowNotSingleSequence<TValue>();
                default:
                    return item.Value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue? NullOnEmpty<TValue>(this (int Index, TValue Value) item) 
            where TValue : struct
        {
            switch (item.Index)
            {
                case (int)ElementResult.Empty:
                    return null;
                case (int)ElementResult.NotSingle:
                    return ThrowHelper.ThrowNotSingleSequence<TValue>();
                default:
                    return item.Value;
            }
        }
    }
}
