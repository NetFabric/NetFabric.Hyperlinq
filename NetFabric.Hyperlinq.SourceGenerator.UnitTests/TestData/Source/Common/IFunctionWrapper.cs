using System;

namespace NetFabric.Hyperlinq
{
    public readonly struct FunctionWrapper<T, TResult>
        : IFunction<T, TResult>
    {
        readonly Func<T, TResult> function;

        public FunctionWrapper(Func<T, TResult> function)
            => this.function = function;

        public TResult Invoke(T arg)
            => function(arg);
    }

    public readonly struct FunctionWrapper<T1, T2, TResult>
        : IFunction<T1, T2, TResult>
    {
        readonly Func<T1, T2, TResult> function;

        public FunctionWrapper(Func<T1, T2, TResult> function)
            => this.function = function;

        public TResult Invoke(T1 arg1, T2 arg2)
            => function(arg1, arg2);
    }

    public readonly struct FunctionWrapper<T1, T2, T3, TResult>
        : IFunction<T1, T2, T3, TResult>
    {
        readonly Func<T1, T2, T3, TResult> function;

        public FunctionWrapper(Func<T1, T2, T3, TResult> function)
            => this.function = function;

        public TResult Invoke(T1 arg1, T2 arg2, T3 arg3)
            => function(arg1, arg2, arg3);
    }
}
