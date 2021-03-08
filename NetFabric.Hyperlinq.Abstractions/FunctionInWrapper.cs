using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public readonly struct FunctionInWrapper<T, TResult>
        : IFunctionIn<T, TResult>
    {
        readonly FunctionIn<T, TResult> function;

        public FunctionInWrapper(FunctionIn<T, TResult> function)
            => this.function = function ?? throw new ArgumentNullException(nameof(function));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TResult Invoke(in T arg)
            => function(arg);
    }

    public readonly struct FunctionInWrapper<T1, T2, TResult>
        : IFunctionIn<T1, T2, TResult>
    {
        readonly FunctionIn<T1, T2, TResult> function;

        public FunctionInWrapper(FunctionIn<T1, T2, TResult> function)
            => this.function = function ?? throw new ArgumentNullException(nameof(function));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TResult Invoke(in T1 arg1, T2 arg2)
            => function(arg1, arg2);
    }
}
