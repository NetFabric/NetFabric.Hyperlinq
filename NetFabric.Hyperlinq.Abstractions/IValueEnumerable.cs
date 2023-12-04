using System.Diagnostics.CodeAnalysis;

namespace NetFabric.Hyperlinq;

/// <summary>
/// Represents a read-only collection of values with a non-boxing enumerator,
/// providing an alternative to <see cref="IEnumerable{T}"/> for improved performance.
/// </summary>
/// <typeparam name="T">The type of elements in the collection.</typeparam>
/// <typeparam name="TEnumerator">The type of the enumerator.</typeparam>
/// <remarks>
/// This interface is designed to offer improved performance over <see cref="IEnumerable{T}"/>
/// by avoiding the boxing of the enumerator. It maintains backward compatibility by deriving from
/// <see cref="IEnumerable{T}"/>.
/// </remarks>
public interface IValueEnumerable<out T, out TEnumerator> 
    : IEnumerable<T>
    where TEnumerator : struct, IEnumerator<T>
{
    /// <summary>
    /// Returns an enumerator instance.
    /// </summary>
    /// <returns>An enumerator instance.</returns>
    [return: NotNull] 
    new TEnumerator GetEnumerator();
}
