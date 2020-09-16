using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public interface IValueEnumerable<out T, TEnumerator>
        : IEnumerable<T>
        where TEnumerator
            : struct
            , IEnumerator<T>
    {
        new TEnumerator GetEnumerator();
    }

    public interface IValueReadOnlyCollection<out T, TEnumerator>
        : IReadOnlyCollection<T>
        , IValueEnumerable<T, TEnumerator>
        where TEnumerator
            : struct
            , IEnumerator<T>
    {
    }

    public interface IValueReadOnlyList<out T, TEnumerator>
        : IReadOnlyList<T>
        , IValueReadOnlyCollection<T, TEnumerator>
        where TEnumerator
            : struct
            , IEnumerator<T>
    {
    }
}
