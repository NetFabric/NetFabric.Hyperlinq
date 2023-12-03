using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq;

[StructLayout(LayoutKind.Auto)]
public readonly struct AsyncFunctionWrapper<T, TResult>
    : IAsyncFunction<T, TResult>
{
    readonly Func<T, CancellationToken, ValueTask<TResult>> function;

    public AsyncFunctionWrapper(Func<T, CancellationToken, ValueTask<TResult>> function)
        => this.function = function ?? throw new ArgumentNullException(nameof(function));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueTask<TResult> InvokeAsync(ref readonly T arg, CancellationToken cancellationToken)
        => function(arg, cancellationToken);

    public static implicit operator AsyncFunctionWrapper<T, TResult>(Func<T, CancellationToken, ValueTask<TResult>> func)
        => new(func);
}

[StructLayout(LayoutKind.Auto)]
public readonly struct AsyncFunctionWrapper<T1, T2, TResult>
    : IAsyncFunction<T1, T2, TResult>
{
    readonly Func<T1, T2, CancellationToken, ValueTask<TResult>> function;

    public AsyncFunctionWrapper(Func<T1, T2, CancellationToken, ValueTask<TResult>> function)
        => this.function = function ?? throw new ArgumentNullException(nameof(function));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueTask<TResult> InvokeAsync(ref readonly T1 arg1, ref readonly T2 arg2, CancellationToken cancellationToken)
        => function(arg1, arg2, cancellationToken);

    public static implicit operator AsyncFunctionWrapper<T1, T2, TResult>(Func<T1, T2, CancellationToken, ValueTask<TResult>> func)
        => new(func);
}

[StructLayout(LayoutKind.Auto)]
public readonly struct AsyncFunctionWrapper<T1, T2, T3, TResult>
    : IAsyncFunction<T1, T2, T3, TResult>
{
    readonly Func<T1, T2, T3, CancellationToken, ValueTask<TResult>> function;

    public AsyncFunctionWrapper(Func<T1, T2, T3, CancellationToken, ValueTask<TResult>> function)
        => this.function = function ?? throw new ArgumentNullException(nameof(function));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueTask<TResult> InvokeAsync(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, CancellationToken cancellationToken)
        => function(arg1, arg2, arg3, cancellationToken);

    public static implicit operator AsyncFunctionWrapper<T1, T2, T3, TResult>(Func<T1, T2, T3, CancellationToken, ValueTask<TResult>> func)
        => new(func);
}

[StructLayout(LayoutKind.Auto)]
public readonly struct AsyncFunctionWrapper<T1, T2, T3, T4, TResult>
    : IAsyncFunction<T1, T2, T3, T4, TResult>
{
    readonly Func<T1, T2, T3, T4, CancellationToken, ValueTask<TResult>> function;

    public AsyncFunctionWrapper(Func<T1, T2, T3, T4, CancellationToken, ValueTask<TResult>> function)
        => this.function = function ?? throw new ArgumentNullException(nameof(function));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueTask<TResult> InvokeAsync(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, ref readonly T4 arg4, CancellationToken cancellationToken)
        => function(arg1, arg2, arg3, arg4, cancellationToken);

    public static implicit operator AsyncFunctionWrapper<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, CancellationToken, ValueTask<TResult>> func)
        => new(func);
}

[StructLayout(LayoutKind.Auto)]
public readonly struct AsyncFunctionWrapper<T1, T2, T3, T4, T5, TResult>
    : IAsyncFunction<T1, T2, T3, T4, T5, TResult>
{
    readonly Func<T1, T2, T3, T4, T5, CancellationToken, ValueTask<TResult>> function;

    public AsyncFunctionWrapper(Func<T1, T2, T3, T4, T5, CancellationToken, ValueTask<TResult>> function)
        => this.function = function ?? throw new ArgumentNullException(nameof(function));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueTask<TResult> InvokeAsync(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, ref readonly T4 arg4, ref readonly T5 arg5, CancellationToken cancellationToken)
        => function(arg1, arg2, arg3, arg4, arg5, cancellationToken);

    public static implicit operator AsyncFunctionWrapper<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, CancellationToken, ValueTask<TResult>> func)
        => new(func);
}

[StructLayout(LayoutKind.Auto)]
public readonly struct AsyncFunctionWrapper<T1, T2, T3, T4, T5, T6, TResult>
    : IAsyncFunction<T1, T2, T3, T4, T5, T6, TResult>
{
    readonly Func<T1, T2, T3, T4, T5, T6, CancellationToken, ValueTask<TResult>> function;

    public AsyncFunctionWrapper(Func<T1, T2, T3, T4, T5, T6, CancellationToken, ValueTask<TResult>> function)
        => this.function = function ?? throw new ArgumentNullException(nameof(function));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueTask<TResult> InvokeAsync(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, ref readonly T4 arg4, ref readonly T5 arg5, ref readonly T6 arg6, CancellationToken cancellationToken)
        => function(arg1, arg2, arg3, arg4, arg5, arg6, cancellationToken);

    public static implicit operator AsyncFunctionWrapper<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, CancellationToken, ValueTask<TResult>> func)
        => new(func);
}

[StructLayout(LayoutKind.Auto)]
public readonly struct AsyncFunctionWrapper<T1, T2, T3, T4, T5, T6, T7, TResult>
    : IAsyncFunction<T1, T2, T3, T4, T5, T6, T7, TResult>
{
    readonly Func<T1, T2, T3, T4, T5, T6, T7, CancellationToken, ValueTask<TResult>> function;

    public AsyncFunctionWrapper(Func<T1, T2, T3, T4, T5, T6, T7, CancellationToken, ValueTask<TResult>> function)
        => this.function = function ?? throw new ArgumentNullException(nameof(function));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueTask<TResult> InvokeAsync(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, ref readonly T4 arg4, ref readonly T5 arg5, ref readonly T6 arg6, ref readonly T7 arg7, CancellationToken cancellationToken)
        => function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, cancellationToken);

    public static implicit operator AsyncFunctionWrapper<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, CancellationToken, ValueTask<TResult>> func)
        => new(func);
}

[StructLayout(LayoutKind.Auto)]
public readonly struct AsyncFunctionWrapper<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
    : IAsyncFunction<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
{
    readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, CancellationToken, ValueTask<TResult>> function;

    public AsyncFunctionWrapper(Func<T1, T2, T3, T4, T5, T6, T7, T8, CancellationToken, ValueTask<TResult>> function)
        => this.function = function ?? throw new ArgumentNullException(nameof(function));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueTask<TResult> InvokeAsync(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, ref readonly T4 arg4, ref readonly T5 arg5, ref readonly T6 arg6, ref readonly T7 arg7, ref readonly T8 arg8, CancellationToken cancellationToken)
        => function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, cancellationToken);

    public static implicit operator AsyncFunctionWrapper<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, CancellationToken, ValueTask<TResult>> func)
        => new(func);
}

[StructLayout(LayoutKind.Auto)]
public readonly struct AsyncFunctionWrapper<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
    : IAsyncFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
{
    readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, CancellationToken, ValueTask<TResult>> function;

    public AsyncFunctionWrapper(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, CancellationToken, ValueTask<TResult>> function)
        => this.function = function ?? throw new ArgumentNullException(nameof(function));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueTask<TResult> InvokeAsync(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, ref readonly T4 arg4, ref readonly T5 arg5, ref readonly T6 arg6, ref readonly T7 arg7, ref readonly T8 arg8, ref readonly T9 arg9, CancellationToken cancellationToken)
        => function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, cancellationToken);

    public static implicit operator AsyncFunctionWrapper<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, CancellationToken, ValueTask<TResult>> func)
        => new(func);
}