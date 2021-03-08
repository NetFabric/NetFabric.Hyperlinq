using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NetFabric.Hyperlinq
{
    public interface IValueEnumerable<out T, out TEnumerator>
        : IEnumerable<T>
        where TEnumerator : struct, IEnumerator<T>
    {
        [return: NotNull] new TEnumerator GetEnumerator();
    }

    public interface IValueReadOnlyCollection<out T, out TEnumerator>
        : IReadOnlyCollection<T>
        , IValueEnumerable<T, TEnumerator>
        where TEnumerator : struct, IEnumerator<T>
    {
    }

    public interface IValueReadOnlyList<out T, out TEnumerator>
        : IReadOnlyList<T>
        , IValueReadOnlyCollection<T, TEnumerator>
        where TEnumerator : struct, IEnumerator<T>
    {
    }
}
