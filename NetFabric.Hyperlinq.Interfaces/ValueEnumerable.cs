using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public interface IValueEnumerator<out T>
    {
        T Current { get; }
        bool MoveNext();
    }

    public interface IValueEnumerable<out T, TEnumerator>
        : IEnumerable<T>
        where TEnumerator 
        : struct
        , IValueEnumerator<T>
    {
        new TEnumerator GetEnumerator();
    }

    public interface IValueReadOnlyCollection<out T, TEnumerator>
        : IReadOnlyCollection<T>
        , IValueEnumerable<T, TEnumerator>
        where TEnumerator 
        : struct
        , IValueEnumerator<T>
    {
    }

    public interface IValueReadOnlyList<out T, TEnumerator>
        : IReadOnlyList<T>
        , IValueReadOnlyCollection<T, TEnumerator>
        where TEnumerator 
        : struct
        , IValueEnumerator<T>
    {
    }
}
