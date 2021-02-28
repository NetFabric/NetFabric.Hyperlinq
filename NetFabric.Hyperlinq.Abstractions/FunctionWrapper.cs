﻿using System;

namespace NetFabric.Hyperlinq
{
    public readonly struct FunctionWrapper<TResult>
        : IFunction<TResult>
    {
        readonly Func<TResult> function;

        public FunctionWrapper(Func<TResult> function)
            => this.function = function ?? throw new ArgumentNullException(nameof(function));

        public TResult Invoke()
            => function();
    }

    public readonly struct FunctionWrapper<T, TResult>
        : IFunction<T, TResult>
    {
        readonly Func<T, TResult> function;

        public FunctionWrapper(Func<T, TResult> function)
            => this.function = function ?? throw new ArgumentNullException(nameof(function));

        public TResult Invoke(T arg)
            => function(arg);
    }

    public readonly struct FunctionWrapper<T1, T2, TResult>
        : IFunction<T1, T2, TResult>
    {
        readonly Func<T1, T2, TResult> function;

        public FunctionWrapper(Func<T1, T2, TResult> function)
            => this.function = function ?? throw new ArgumentNullException(nameof(function));

        public TResult Invoke(T1 arg1, T2 arg2)
            => function(arg1, arg2);
    }

    public readonly struct FunctionWrapper<T1, T2, T3, TResult>
        : IFunction<T1, T2, T3, TResult>
    {
        readonly Func<T1, T2, T3, TResult> function;

        public FunctionWrapper(Func<T1, T2, T3, TResult> function)
            => this.function = function ?? throw new ArgumentNullException(nameof(function));

        public TResult Invoke(T1 arg1, T2 arg2, T3 arg3)
            => function(arg1, arg2, arg3);
    }

    public readonly struct FunctionWrapper<T1, T2, T3, T4, TResult>
        : IFunction<T1, T2, T3, T4, TResult>
    {
        readonly Func<T1, T2, T3, T4, TResult> function;

        public FunctionWrapper(Func<T1, T2, T3, T4, TResult> function)
            => this.function = function ?? throw new ArgumentNullException(nameof(function));

        public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            => function(arg1, arg2, arg3, arg4);
    }

    public readonly struct FunctionWrapper<T1, T2, T3, T4, T5, TResult>
        : IFunction<T1, T2, T3, T4, T5, TResult>
    {
        readonly Func<T1, T2, T3, T4, T5, TResult> function;

        public FunctionWrapper(Func<T1, T2, T3, T4, T5, TResult> function)
            => this.function = function ?? throw new ArgumentNullException(nameof(function));

        public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            => function(arg1, arg2, arg3, arg4, arg5);
    }

    public readonly struct FunctionWrapper<T1, T2, T3, T4, T5, T6, TResult>
        : IFunction<T1, T2, T3, T4, T5, T6, TResult>
    {
        readonly Func<T1, T2, T3, T4, T5, T6, TResult> function;

        public FunctionWrapper(Func<T1, T2, T3, T4, T5, T6, TResult> function)
            => this.function = function ?? throw new ArgumentNullException(nameof(function));

        public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            => function(arg1, arg2, arg3, arg4, arg5, arg6);
    }

    public readonly struct FunctionWrapper<T1, T2, T3, T4, T5, T6, T7, TResult>
        : IFunction<T1, T2, T3, T4, T5, T6, T7, TResult>
    {
        readonly Func<T1, T2, T3, T4, T5, T6, T7, TResult> function;

        public FunctionWrapper(Func<T1, T2, T3, T4, T5, T6, T7, TResult> function)
            => this.function = function ?? throw new ArgumentNullException(nameof(function));

        public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            => function(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
    }

    public readonly struct FunctionWrapper<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
        : IFunction<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
    {
        readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> function;

        public FunctionWrapper(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> function)
            => this.function = function ?? throw new ArgumentNullException(nameof(function));

        public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            => function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
    }

    public readonly struct FunctionWrapper<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
        : IFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
    {
        readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> function;

        public FunctionWrapper(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> function)
            => this.function = function ?? throw new ArgumentNullException(nameof(function));

        public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
            => function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
    }
}
