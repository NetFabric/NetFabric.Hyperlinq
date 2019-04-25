// Based on implementation by Ben Adams
// https://gist.github.com/benaadams/294cbd41ec1179638cb4b5495a15accf

using System;

namespace NetFabric.Hyperlinq
{
    public interface IValueEnumerator : IDisposable
    {
        bool TryMoveNext();
    }

    public interface IValueEnumerator<T> : IValueEnumerator
    {
        bool TryMoveNext(out T current);
    }

    public interface IValueEnumerable<TEnumerator>
        where TEnumerator : struct, IValueEnumerator
    {
        TEnumerator GetValueEnumerator();
    }

    public interface IValueEnumerable<T, TEnumerator>
        where TEnumerator : struct, IValueEnumerator<T>
    {
        TEnumerator GetValueEnumerator();
    }

    public interface IValueReadOnlyCollection<TEnumerator> : IValueEnumerable<TEnumerator>
        where TEnumerator : struct, IValueEnumerator
    {
        long Count { get; }
    }

    public interface IValueReadOnlyCollection<T, TEnumerator> : IValueEnumerable<T, TEnumerator>
        where TEnumerator : struct, IValueEnumerator<T>
    {
        long Count { get; }
    }

    public interface IValueReadOnlyList<T, TEnumerator> : IValueReadOnlyCollection<T, TEnumerator>
        where TEnumerator : struct, IValueEnumerator<T>
    {
        T this[long index] { get; }
    }
}
