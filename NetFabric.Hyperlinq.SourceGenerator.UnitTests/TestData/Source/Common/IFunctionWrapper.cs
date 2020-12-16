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
}
