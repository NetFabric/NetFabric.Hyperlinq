using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq;

/// <summary>
/// Represents a read-only struct that wraps an <see cref="Action{T}"/> delegate
/// and implements the <see cref="IAction{T}"/> interface to provide a way to invoke the action.
/// </summary>
/// <typeparam name="T">The type of the argument to be passed to the action when invoked.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="ActionWrapperValueAction{T}"/> struct with the specified action.
/// </remarks>
/// <param name="action">The <see cref="Action{T}"/> delegate to be wrapped.</param>
/// <exception cref="ArgumentNullException">Thrown if <paramref name="action"/> is null.</exception>
[StructLayout(LayoutKind.Auto)]
public readonly struct ActionWrapper<T>(Action<T> action) 
    : IAction<T>
{
    readonly Action<T> action = action ?? Throw.ArgumentNullException<Action<T>>(nameof(action));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    void IAction<T>.Invoke(ref readonly T arg)
        => action(arg);

    public static implicit operator ActionWrapper<T>(Action<T> action)
        => new(action);
}

/// <summary>
/// Represents a read-only struct that wraps an <see cref="Action{T1, T2}"/> delegate
/// and implements the <see cref="IAction{T1, T2}"/> interface to provide a way to invoke the action.
/// </summary>
/// <typeparam name="T1">The type of the first argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T2">The type of the second argument to be passed to the action when invoked.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="ActionWrapperValueAction{T1, T2}"/> struct with the specified action.
/// </remarks>
/// <param name="action">The <see cref="Action{T1, T2}"/> delegate to be wrapped.</param>
/// <exception cref="ArgumentNullException">Thrown if <paramref name="action"/> is null.</exception>
[StructLayout(LayoutKind.Auto)]
public readonly struct ActionWrapper<T1, T2>(Action<T1, T2> action) 
    : IAction<T1, T2>
{
    readonly Action<T1, T2> action = action ?? Throw.ArgumentNullException<Action<T1, T2>>(nameof(action));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    void IAction<T1, T2>.Invoke(ref readonly T1 arg1, ref readonly T2 arg2)
        => action(arg1, arg2);

    public static implicit operator ActionWrapper<T1, T2>(Action<T1, T2> action)
        => new(action);
}

/// <summary>
/// Represents a read-only struct that wraps an <see cref="Action{T1, T2, T3}"/> delegate
/// and implements the <see cref="IAction{T1, T2, T3}"/> interface to provide a way to invoke the action.
/// </summary>
/// <typeparam name="T1">The type of the first argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T2">The type of the second argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T3">The type of the third argument to be passed to the action when invoked.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="ActionWrapperValueAction{T1, T2, T3}"/> struct with the specified action.
/// </remarks>
/// <param name="action">The <see cref="Action{T1, T2, T3}"/> delegate to be wrapped.</param>
/// <exception cref="ArgumentNullException">Thrown if <paramref name="action"/> is null.</exception>
[StructLayout(LayoutKind.Auto)]
public readonly struct ActionWrapper<T1, T2, T3>(Action<T1, T2, T3> action) 
    : IAction<T1, T2, T3>
{
    readonly Action<T1, T2, T3> action = action ?? Throw.ArgumentNullException<Action<T1, T2, T3>>(nameof(action));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    void IAction<T1, T2, T3>.Invoke(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3)
        => action(arg1, arg2, arg3);

    public static implicit operator ActionWrapper<T1, T2, T3>(Action<T1, T2, T3> action)
        => new(action);
}

/// <summary>
/// Represents a read-only struct that wraps an <see cref="Action{T1, T2, T3, T4}"/> delegate
/// and implements the <see cref="IAction{T1, T2, T3, T4}"/> interface to provide a way to invoke the action.
/// </summary>
/// <typeparam name="T1">The type of the first argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T2">The type of the second argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T3">The type of the third argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T4">The type of the fourth argument to be passed to the action when invoked.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="ActionWrapperValueAction{T1, T2, T3, T4}"/> struct with the specified action.
/// </remarks>
/// <param name="action">The <see cref="Action{T1, T2, T3, T4}"/> delegate to be wrapped.</param>
/// <exception cref="ArgumentNullException">Thrown if <paramref name="action"/> is null.</exception>
[StructLayout(LayoutKind.Auto)]
public readonly struct ActionWrapper<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action) 
    : IAction<T1, T2, T3, T4>
{
    readonly Action<T1, T2, T3, T4> action = action ?? Throw.ArgumentNullException<Action<T1, T2, T3, T4>>(nameof(action));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    void IAction<T1, T2, T3, T4>.Invoke(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, ref readonly T4 arg4)
        => action(arg1, arg2, arg3, arg4);

    public static implicit operator ActionWrapper<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action)
        => new(action);
}

/// <summary>
/// Represents a read-only struct that wraps an <see cref="Action{T1, T2, T3, T4, T5}"/> delegate
/// and implements the <see cref="IAction{T1, T2, T3, T4, T5}"/> interface to provide a way to invoke the action.
/// </summary>
/// <typeparam name="T1">The type of the first argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T2">The type of the second argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T3">The type of the third argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T4">The type of the fourth argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T5">The type of the fifth argument to be passed to the action when invoked.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="ActionWrapperValueAction{T1, T2, T3, T4, T5}"/> struct with the specified action.
/// </remarks>
/// <param name="action">The <see cref="Action{T1, T2, T3, T4, T5}"/> delegate to be wrapped.</param>
/// <exception cref="ArgumentNullException">Thrown if <paramref name="action"/> is null.</exception>
[StructLayout(LayoutKind.Auto)]
public readonly struct ActionWrapper<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action) 
    : IAction<T1, T2, T3, T4, T5>
{
    readonly Action<T1, T2, T3, T4, T5> action = action ?? Throw.ArgumentNullException<Action<T1, T2, T3, T4, T5>>(nameof(action));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    void IAction<T1, T2, T3, T4, T5>.Invoke(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, ref readonly T4 arg4, ref readonly T5 arg5)
        => action(arg1, arg2, arg3, arg4, arg5);

    public static implicit operator ActionWrapper<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action)
        => new(action);
}

/// <summary>
/// Represents a read-only struct that wraps an <see cref="Action{T1, T2, T3, T4, T5, T6}"/> delegate
/// and implements the <see cref="IAction{T1, T2, T3, T4, T5, T6}"/> interface to provide a way to invoke the action.
/// </summary>
/// <typeparam name="T1">The type of the first argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T2">The type of the second argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T3">The type of the third argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T4">The type of the fourth argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T5">The type of the fifth argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T6">The type of the sixth argument to be passed to the action when invoked.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="ActionWrapperValueAction{T1, T2, T3, T4, T5, T6}"/> struct with the specified action.
/// </remarks>
/// <param name="action">The <see cref="Action{T1, T2, T3, T4, T5, T6}"/> delegate to be wrapped.</param>
/// <exception cref="ArgumentNullException">Thrown if <paramref name="action"/> is null.</exception>
[StructLayout(LayoutKind.Auto)]
public readonly struct ActionWrapper<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action) 
    : IAction<T1, T2, T3, T4, T5, T6>
{
    readonly Action<T1, T2, T3, T4, T5, T6> action = action ?? Throw.ArgumentNullException<Action<T1, T2, T3, T4, T5, T6>>(nameof(action));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    void IAction<T1, T2, T3, T4, T5, T6>.Invoke(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, ref readonly T4 arg4, ref readonly T5 arg5, ref readonly T6 arg6)
        => action(arg1, arg2, arg3, arg4, arg5, arg6);

    public static implicit operator ActionWrapper<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action)
        => new(action);
}

/// <summary>
/// Represents a read-only struct that wraps an <see cref="Action{T1, T2, T3, T4, T5, T6, T7}"/> delegate
/// and implements the <see cref="IAction{T1, T2, T3, T4, T5, T6, T7}"/> interface to provide a way to invoke the action.
/// </summary>
/// <typeparam name="T1">The type of the first argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T2">The type of the second argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T3">The type of the third argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T4">The type of the fourth argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T5">The type of the fifth argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T6">The type of the sixth argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T7">The type of the seventh argument to be passed to the action when invoked.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="ActionWrapperValueAction{T1, T2, T3, T4, T5, T6, T7}"/> struct with the specified action.
/// </remarks>
/// <param name="action">The <see cref="Action{T1, T2, T3, T4, T5, T6, T7}"/> delegate to be wrapped.</param>
/// <exception cref="ArgumentNullException">Thrown if <paramref name="action"/> is null.</exception>
[StructLayout(LayoutKind.Auto)]
public readonly struct ActionWrapper<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> action) 
    : IAction<T1, T2, T3, T4, T5, T6, T7>
{
    readonly Action<T1, T2, T3, T4, T5, T6, T7> action = action ?? Throw.ArgumentNullException<Action<T1, T2, T3, T4, T5, T6, T7>>(nameof(action));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    void IAction<T1, T2, T3, T4, T5, T6, T7>.Invoke(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, ref readonly T4 arg4, ref readonly T5 arg5, ref readonly T6 arg6, ref readonly T7 arg7)
        => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7);

    public static implicit operator ActionWrapper<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> action)
        => new(action);
}

/// <summary>
/// Represents a read-only struct that wraps an <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8}"/> delegate
/// and implements the <see cref="IAction{T1, T2, T3, T4, T5, T6, T7, T8}"/> interface to provide a way to invoke the action.
/// </summary>
/// <typeparam name="T1">The type of the first argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T2">The type of the second argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T3">The type of the third argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T4">The type of the fourth argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T5">The type of the fifth argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T6">The type of the sixth argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T7">The type of the seventh argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T8">The type of the eighth argument to be passed to the action when invoked.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="ActionWrapperValueAction{T1, T2, T3, T4, T5, T6, T7, T8}"/> struct with the specified action.
/// </remarks>
/// <param name="action">The <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8}"/> delegate to be wrapped.</param>
/// <exception cref="ArgumentNullException">Thrown if <paramref name="action"/> is null.</exception>
[StructLayout(LayoutKind.Auto)]
public readonly struct ActionWrapper<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> action) 
    : IAction<T1, T2, T3, T4, T5, T6, T7, T8>
{
    readonly Action<T1, T2, T3, T4, T5, T6, T7, T8> action = action ?? Throw.ArgumentNullException<Action<T1, T2, T3, T4, T5, T6, T7, T8>>(nameof(action));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    void IAction<T1, T2, T3, T4, T5, T6, T7, T8>.Invoke(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, ref readonly T4 arg4, ref readonly T5 arg5, ref readonly T6 arg6, ref readonly T7 arg7, ref readonly T8 arg8)
        => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);

    public static implicit operator ActionWrapper<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
        => new(action);
}

/// <summary>
/// Represents a read-only struct that wraps an <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9}"/> delegate
/// and implements the <see cref="IAction{T1, T2, T3, T4, T5, T6, T7, T8, T9}"/> interface to provide a way to invoke the action.
/// </summary>
/// <typeparam name="T1">The type of the first argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T2">The type of the second argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T3">The type of the third argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T4">The type of the fourth argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T5">The type of the fifth argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T6">The type of the sixth argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T7">The type of the seventh argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T8">The type of the eighth argument to be passed to the action when invoked.</typeparam>
/// <typeparam name="T9">The type of the ninth argument to be passed to the action when invoked.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="ActionWrapperValueAction{T1, T2, T3, T4, T5, T6, T7, T8, T9}"/> struct with the specified action.
/// </remarks>
/// <param name="action">The <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9}"/> delegate to be wrapped.</param>
/// <exception cref="ArgumentNullException">Thrown if <paramref name="action"/> is null.</exception>
[StructLayout(LayoutKind.Auto)]
public readonly struct ActionWrapper<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) 
    : IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>
{
    readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action = action ?? Throw.ArgumentNullException<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>>(nameof(action));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    void IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>.Invoke(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, ref readonly T4 arg4, ref readonly T5 arg5, ref readonly T6 arg6, ref readonly T7 arg7, ref readonly T8 arg8, ref readonly T9 arg9)
        => action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);

    public static implicit operator ActionWrapper<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
        => new(action);
}


