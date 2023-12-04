namespace NetFabric.Hyperlinq;

/// <summary>
/// Defines an interface for a generic action that can be invoked with a readonly reference to an argument of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the argument to be passed when invoking the action.</typeparam>
public interface IAction<T>
{
    /// <summary>
    /// Invokes the action with a readonly reference to the specified argument of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="arg">The readonly reference to the argument to be passed to the action.</param>
    void Invoke(ref readonly T arg);
}

/// <summary>
/// Defines an interface for a generic action that can be invoked with readonly references to two arguments of type <typeparamref name="T1"/> and <typeparamref name="T2"/>.
/// </summary>
/// <typeparam name="T1">The type of the first argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T2">The type of the second argument to be passed when invoking the action.</typeparam>
public interface IAction<T1, T2>
{
    /// <summary>
    /// Invokes the action with readonly references to the specified arguments of type <typeparamref name="T1"/> and <typeparamref name="T2"/>.
    /// </summary>
    /// <param name="arg1">The readonly reference to the first argument to be passed to the action.</param>
    /// <param name="arg2">The readonly reference to the second argument to be passed to the action.</param>
    void Invoke(ref readonly T1 arg1, ref readonly T2 arg2);
}

/// <summary>
/// Defines an interface for a generic action that can be invoked with readonly references to three arguments of type <typeparamref name="T1"/>, <typeparamref name="T2"/>, and <typeparamref name="T3"/>.
/// </summary>
/// <typeparam name="T1">The type of the first argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T2">The type of the second argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T3">The type of the third argument to be passed when invoking the action.</typeparam>
public interface IAction<T1, T2, T3>
{
    /// <summary>
    /// Invokes the action with readonly references to the specified arguments of type <typeparamref name="T1"/>, <typeparamref name="T2"/>, and <typeparamref name="T3"/>.
    /// </summary>
    /// <param name="arg1">The readonly reference to the first argument to be passed to the action.</param>
    /// <param name="arg2">The readonly reference to the second argument to be passed to the action.</param>
    /// <param name="arg3">The readonly reference to the third argument to be passed to the action.</param>
    void Invoke(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3);
}

/// <summary>
/// Defines an interface for a generic action that can be invoked with readonly references to nine arguments of types <typeparamref name="T1"/> to <typeparamref name="T9"/>.
/// </summary>
/// <typeparam name="T1">The type of the first argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T2">The type of the second argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T3">The type of the third argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T4">The type of the fourth argument to be passed when invoking the action.</typeparam>
public interface IAction<T1, T2, T3, T4>
{
    /// <summary>
    /// Invokes the action with readonly references to the specified arguments of types <typeparamref name="T1"/> to <typeparamref name="T4"/>.
    /// </summary>
    /// <param name="arg1">The readonly reference to the first argument to be passed to the action.</param>
    /// <param name="arg2">The readonly reference to the second argument to be passed to the action.</param>
    /// <param name="arg3">The readonly reference to the third argument to be passed to the action.</param>
    /// <param name="arg4">The readonly reference to the fourth argument to be passed to the action.</param>
    void Invoke(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, ref readonly T4 arg4);
}

/// <summary>
/// Defines an interface for a generic action that can be invoked with readonly references to nine arguments of types <typeparamref name="T1"/> to <typeparamref name="T5"/>.
/// </summary>
/// <typeparam name="T1">The type of the first argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T2">The type of the second argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T3">The type of the third argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T4">The type of the fourth argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T5">The type of the fifth argument to be passed when invoking the action.</typeparam>
public interface IAction<T1, T2, T3, T4, T5>
{
    /// <summary>
    /// Invokes the action with readonly references to the specified arguments of types <typeparamref name="T1"/> to <typeparamref name="T6"/>.
    /// </summary>
    /// <param name="arg1">The readonly reference to the first argument to be passed to the action.</param>
    /// <param name="arg2">The readonly reference to the second argument to be passed to the action.</param>
    /// <param name="arg3">The readonly reference to the third argument to be passed to the action.</param>
    /// <param name="arg4">The readonly reference to the fourth argument to be passed to the action.</param>
    /// <param name="arg5">The readonly reference to the fifth argument to be passed to the action.</param>
    void Invoke(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, ref readonly T4 arg4, ref readonly T5 arg5);
}

/// <summary>
/// Defines an interface for a generic action that can be invoked with readonly references to nine arguments of types <typeparamref name="T1"/> to <typeparamref name="T7"/>.
/// </summary>
/// <typeparam name="T1">The type of the first argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T2">The type of the second argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T3">The type of the third argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T4">The type of the fourth argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T5">The type of the fifth argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T6">The type of the sixth argument to be passed when invoking the action.</typeparam>
public interface IAction<T1, T2, T3, T4, T5, T6>
{
    /// <summary>
    /// Invokes the action with readonly references to the specified arguments of types <typeparamref name="T1"/> to <typeparamref name="T8"/>.
    /// </summary>
    /// <param name="arg1">The readonly reference to the first argument to be passed to the action.</param>
    /// <param name="arg2">The readonly reference to the second argument to be passed to the action.</param>
    /// <param name="arg3">The readonly reference to the third argument to be passed to the action.</param>
    /// <param name="arg4">The readonly reference to the fourth argument to be passed to the action.</param>
    /// <param name="arg5">The readonly reference to the fifth argument to be passed to the action.</param>
    /// <param name="arg6">The readonly reference to the sixth argument to be passed to the action.</param>
    void Invoke(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, ref readonly T4 arg4, ref readonly T5 arg5, ref readonly T6 arg6);
}

/// <summary>
/// Defines an interface for a generic action that can be invoked with readonly references to nine arguments of types <typeparamref name="T1"/> to <typeparamref name="T9"/>.
/// </summary>
/// <typeparam name="T1">The type of the first argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T2">The type of the second argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T3">The type of the third argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T4">The type of the fourth argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T5">The type of the fifth argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T6">The type of the sixth argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T7">The type of the seventh argument to be passed when invoking the action.</typeparam>
public interface IAction<T1, T2, T3, T4, T5, T6, T7>
{
    /// <summary>
    /// Invokes the action with readonly references to the specified arguments of types <typeparamref name="T1"/> to <typeparamref name="T9"/>.
    /// </summary>
    /// <param name="arg1">The readonly reference to the first argument to be passed to the action.</param>
    /// <param name="arg2">The readonly reference to the second argument to be passed to the action.</param>
    /// <param name="arg3">The readonly reference to the third argument to be passed to the action.</param>
    /// <param name="arg4">The readonly reference to the fourth argument to be passed to the action.</param>
    /// <param name="arg5">The readonly reference to the fifth argument to be passed to the action.</param>
    /// <param name="arg6">The readonly reference to the sixth argument to be passed to the action.</param>
    /// <param name="arg7">The readonly reference to the seventh argument to be passed to the action.</param>
    void Invoke(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, ref readonly T4 arg4, ref readonly T5 arg5, ref readonly T6 arg6, ref readonly T7 arg7);
}

/// <summary>
/// Defines an interface for a generic action that can be invoked with readonly references to nine arguments of types <typeparamref name="T1"/> to <typeparamref name="T9"/>.
/// </summary>
/// <typeparam name="T1">The type of the first argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T2">The type of the second argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T3">The type of the third argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T4">The type of the fourth argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T5">The type of the fifth argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T6">The type of the sixth argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T7">The type of the seventh argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T8">The type of the eighth argument to be passed when invoking the action.</typeparam>
public interface IAction<T1, T2, T3, T4, T5, T6, T7, T8>
{
    /// <summary>
    /// Invokes the action with readonly references to the specified arguments of types <typeparamref name="T1"/> to <typeparamref name="T9"/>.
    /// </summary>
    /// <param name="arg1">The readonly reference to the first argument to be passed to the action.</param>
    /// <param name="arg2">The readonly reference to the second argument to be passed to the action.</param>
    /// <param name="arg3">The readonly reference to the third argument to be passed to the action.</param>
    /// <param name="arg4">The readonly reference to the fourth argument to be passed to the action.</param>
    /// <param name="arg5">The readonly reference to the fifth argument to be passed to the action.</param>
    /// <param name="arg6">The readonly reference to the sixth argument to be passed to the action.</param>
    /// <param name="arg7">The readonly reference to the seventh argument to be passed to the action.</param>
    /// <param name="arg8">The readonly reference to the eighth argument to be passed to the action.</param>
    void Invoke(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, ref readonly T4 arg4, ref readonly T5 arg5, ref readonly T6 arg6, ref readonly T7 arg7, ref readonly T8 arg8);
}

/// <summary>
/// Defines an interface for a generic action that can be invoked with readonly references to nine arguments of types <typeparamref name="T1"/> to <typeparamref name="T9"/>.
/// </summary>
/// <typeparam name="T1">The type of the first argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T2">The type of the second argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T3">The type of the third argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T4">The type of the fourth argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T5">The type of the fifth argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T6">The type of the sixth argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T7">The type of the seventh argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T8">The type of the eighth argument to be passed when invoking the action.</typeparam>
/// <typeparam name="T9">The type of the ninth argument to be passed when invoking the action.</typeparam>
public interface IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>
{
    /// <summary>
    /// Invokes the action with readonly references to the specified arguments of types <typeparamref name="T1"/> to <typeparamref name="T9"/>.
    /// </summary>
    /// <param name="arg1">The readonly reference to the first argument to be passed to the action.</param>
    /// <param name="arg2">The readonly reference to the second argument to be passed to the action.</param>
    /// <param name="arg3">The readonly reference to the third argument to be passed to the action.</param>
    /// <param name="arg4">The readonly reference to the fourth argument to be passed to the action.</param>
    /// <param name="arg5">The readonly reference to the fifth argument to be passed to the action.</param>
    /// <param name="arg6">The readonly reference to the sixth argument to be passed to the action.</param>
    /// <param name="arg7">The readonly reference to the seventh argument to be passed to the action.</param>
    /// <param name="arg8">The readonly reference to the eighth argument to be passed to the action.</param>
    /// <param name="arg9">The readonly reference to the ninth argument to be passed to the action.</param>
    void Invoke(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, ref readonly T4 arg4, ref readonly T5 arg5, ref readonly T6 arg6, ref readonly T7 arg7, ref readonly T8 arg8, ref readonly T9 arg9);
}
