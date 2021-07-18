using NetFabric.Hyperlinq;
using System.Collections;
using System.Collections.Generic;

public class TestValueEnumerable<T>
    : IValueEnumerable<T, TestValueEnumerable<T>.DisposableEnumerator>
{
    public Enumerator GetEnumerator()
        => new();

    DisposableEnumerator IValueEnumerable<T, DisposableEnumerator>.GetEnumerator()
        => new();

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
        => new DisposableEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => new DisposableEnumerator();

    public readonly struct Enumerator
    {
        public T Current
            => default!;

        public bool MoveNext()
            => false;
    }

    public readonly struct DisposableEnumerator
        : IEnumerator<T>
    {
        public T Current
            => default!;
        object? IEnumerator.Current
            => default;

        public bool MoveNext()
            => false;

        public void Reset()
        { }
        public void Dispose()
        { }
    }
}
