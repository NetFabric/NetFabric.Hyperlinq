using System;

namespace NetFabric.Hyperlinq
{
    public interface IValueEnumerator<out T>
        : IDisposable
    {
        T Current { get; }
        bool MoveNext();
    }

    public interface IValueEnumerable<out T, TEnumerator>
        where TEnumerator : struct, IValueEnumerator<T>
    {
        TEnumerator GetEnumerator();
    }

    public interface IValueReadOnlyCollection<out T, TEnumerator> 
        : IValueEnumerable<T, TEnumerator>
        where TEnumerator : struct, IValueEnumerator<T>
    {
        long Count { get; }
    }

    public interface IValueReadOnlyList<out T, TEnumerator> 
        : IValueReadOnlyCollection<T, TEnumerator>
        where TEnumerator : struct, IValueEnumerator<T>
    {
        T this[long index] { get; }
    }
}
