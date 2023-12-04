using System.Numerics;

namespace NetFabric.Hyperlinq;

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP1_0_OR_GREATER

/// <summary>
/// Represents an interface for a generic action that can be invoked with a readonly reference to a <see cref="Vector{T}"/> argument of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the elements in the <see cref="Vector{T}"/> argument.</typeparam>
/// <remarks>
/// This interface extends the <see cref="IAction{T}"/> interface to support vectorized operations. It allows actions to be invoked
/// with a readonly reference to a <see cref="Vector{T}"/> argument, making it suitable for scenarios where vectorization can be applied
/// for improved performance in numerical or computational tasks.
/// </remarks>
/// <remarks>
/// The <see cref="IAction{T}.Invoke(T)"/> method is used instead in scenarios where vectorization is not available or on elements
/// that don't fit in a <see cref="Vector{T}"/>. 
/// </remarks>
public interface IVectorAction<T> 
    : IAction<T>
    where T : struct
{
    /// <summary>
    /// Invokes the action with a readonly reference to the specified <see cref="Vector{T}"/> argument of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="arg">The readonly reference to the <see cref="Vector{T}"/> argument to be passed to the action.</param>
    void Invoke(ref readonly Vector<T> arg);
}

/// <summary>
/// Represents an interface for a generic 2D action that can be invoked with a readonly reference to a <see cref="Vector{T}"/> argument of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the elements in the <see cref="Vector{T}"/> argument.</typeparam>
/// <remarks>
/// This interface extends the <see cref="IAction{T1, T2}"/> interface to support 2D vectorized operations. It allows actions to be invoked
/// with a readonly reference to a <see cref="Vector{T}"/> argument, making it suitable for scenarios where 2D vectorization can be applied
/// for improved performance in numerical or computational tasks.
/// </remarks>
// <remarks>
/// The <see cref="IAction{T1, T2}.Invoke(T1, T2)"/> method is used instead in scenarios where vectorization is not available or on elements
/// that don't fit in a <see cref="Vector{T}"/>. 
/// </remarks>
public interface IVectorAction2D<T> : IAction<T, T>
    where T : struct
{
    /// <summary>
    /// Invokes the action with a readonly reference to the specified <see cref="Vector{T}"/> argument of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="arg">The readonly reference to the <see cref="Vector{T}"/> argument to be passed to the 2D action.</param>
    void Invoke(ref readonly Vector<T> arg);
}

// <summary>
/// Represents an interface for a generic 3D action that can be invoked with a readonly reference to a <see cref="Vector{T}"/> argument of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the elements in the <see cref="Vector{T}"/> argument.</typeparam>
/// <remarks>
/// This interface extends the <see cref="IAction{T1, T2, T3}"/> interface to support 2D vectorized operations. It allows actions to be invoked
/// with a readonly reference to a <see cref="Vector{T}"/> argument, making it suitable for scenarios where 2D vectorization can be applied
/// for improved performance in numerical or computational tasks.
/// </remarks>
// <remarks>
/// The <see cref="IAction{T1, T2, T3}.Invoke(T1, T2, T3)"/> method is used instead in scenarios where vectorization is not available or on elements
/// that don't fit in a <see cref="Vector{T}"/>. 
/// </remarks>
public interface IVectorAction3D<T> 
    : IAction<T, T, T>
    where T : struct
{
    /// <summary>
    /// Invokes the action with a readonly reference to the specified <see cref="Vector{T}"/> argument of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="arg">The readonly reference to the <see cref="Vector{T}"/> argument to be passed to the 2D action.</param>
    void Invoke(ref readonly Vector<T> arg);
}

// <summary>
/// Represents an interface for a generic 4D action that can be invoked with a readonly reference to a <see cref="Vector{T}"/> argument of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the elements in the <see cref="Vector{T}"/> argument.</typeparam>
/// <remarks>
/// This interface extends the <see cref="IAction{T1, T2, T3, T4}"/> interface to support 2D vectorized operations. It allows actions to be invoked
/// with a readonly reference to a <see cref="Vector{T}"/> argument, making it suitable for scenarios where 2D vectorization can be applied
/// for improved performance in numerical or computational tasks.
/// </remarks>
// <remarks>
/// The <see cref="IAction{T1, T2, T3, T4}.Invoke(T1, T2, T3, T4)"/> method is used instead in scenarios where vectorization is not available or on elements
/// that don't fit in a <see cref="Vector{T}"/>. 
/// </remarks>
public interface IVectorAction4D<T> 
    : IAction<T, T, T, T>
    where T : struct
{
    /// <summary>
    /// Invokes the action with a readonly reference to the specified <see cref="Vector{T}"/> argument of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="arg">The readonly reference to the <see cref="Vector{T}"/> argument to be passed to the 2D action.</param>
    void Invoke(ref readonly Vector<T> arg);
}

// <summary>
/// Represents an interface for a generic 5D action that can be invoked with a readonly reference to a <see cref="Vector{T}"/> argument of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the elements in the <see cref="Vector{T}"/> argument.</typeparam>
/// <remarks>
/// This interface extends the <see cref="IAction{T1, T2, T3, T4, T5}"/> interface to support 2D vectorized operations. It allows actions to be invoked
/// with a readonly reference to a <see cref="Vector{T}"/> argument, making it suitable for scenarios where 2D vectorization can be applied
/// for improved performance in numerical or computational tasks.
/// </remarks>
/// <remarks>
/// The <see cref="IAction{T1, T2, T3, T4, T5}.Invoke(T1, T2, T3, T4, T5)"/> method is used instead in scenarios where vectorization is not available or on elements
/// that don't fit in a <see cref="Vector{T}"/>.
/// </remarks>
public interface IVectorAction5D<T> : IAction<T, T, T, T, T> where T : struct
{
    /// <summary>
    /// Invokes the action with a readonly reference to the specified <see cref="Vector{T}"/> argument of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="arg">The readonly reference to the <see cref="Vector{T}"/> argument.</param>
    void Invoke(in Vector<T> arg);
}

// <summary>
/// Represents an interface for a generic 6D action that can be invoked with a readonly reference to a <see cref="Vector{T}"/> argument of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the elements in the <see cref="Vector{T}"/> argument.</typeparam>
/// <remarks>
/// This interface extends the <see cref="IAction{T1, T2, T3, T4, T5, T6}"/> interface to support 2D vectorized operations. It allows actions to be invoked
/// with a readonly reference to a <see cref="Vector{T}"/> argument, making it suitable for scenarios where 2D vectorization can be applied
/// for improved performance in numerical or computational tasks.
/// </remarks>
/// <remarks>
/// The <see cref="IAction{T1, T2, T3, T4, T5, T6}.Invoke(T1, T2, T3, T4, T5, T6)"/> method is used instead in scenarios where vectorization is not available or on elements
/// that don't fit in a <see cref="Vector{T}"/>.
/// </remarks>
public interface IVectorAction6D<T> : IAction<T, T, T, T, T, T> where T : struct
{
    /// <summary>
    /// Invokes the action with a readonly reference to the specified <see cref="Vector{T}"/> argument of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="arg">The readonly reference to the <see cref="Vector{T}"/> argument.</param>
    void Invoke(in Vector<T> arg);
}


#endif
