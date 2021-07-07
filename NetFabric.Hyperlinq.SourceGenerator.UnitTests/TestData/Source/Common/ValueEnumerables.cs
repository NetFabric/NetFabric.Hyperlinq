using NetFabric.Hyperlinq;
using System.Collections;
using System.Collections.Generic;

class TestValueEnumerable
    : IValueEnumerable<int, TestValueEnumerable.DisposableEnumerator>
{
    public Enumerator GetEnumerator()
        => new();

    DisposableEnumerator IValueEnumerable<int, DisposableEnumerator>.GetEnumerator()
        => new();

    IEnumerator<int> IEnumerable<int>.GetEnumerator()
        => new DisposableEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => new DisposableEnumerator();

    public readonly struct Enumerator
    {
        public int Current
            => default;

        public bool MoveNext()
            => false;
    }

    public readonly struct DisposableEnumerator
        : IEnumerator<int>
    {
        public int Current
            => default;
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
