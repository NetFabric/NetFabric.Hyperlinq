using System;
using System.Collections;
using System.Collections.Generic;

class TestEnumerableWithNoInterfaces
{
    public Enumerator GetEnumerator()
        => new();

    public readonly struct Enumerator
    {
        public int Current
            => default;

        public bool MoveNext()
            => false;
    }
}

class TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose
{
    public Enumerator GetEnumerator()
        => new();

    public readonly struct Enumerator
        : IDisposable
    {
        public int Current
            => default;

        public bool MoveNext()
            => false;

        public void Reset()
        { }

        public void Dispose()
        { }
    }
}

class TestEnumerableWithInterfacelessPublicEnumerator
    : IEnumerable<int>
{
    public Enumerator GetEnumerator()
        => new();
    IEnumerator<int> IEnumerable<int>.GetEnumerator()
        => new DisposableEnumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => new DisposableEnumerator();

    public readonly ref struct Enumerator
    {
        public int Current
            => default;

        public bool MoveNext()
            => false;
    }

    class DisposableEnumerator
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

public class TestEnumerableWithValueTypeEnumerator
    : IEnumerable<int>
{
    public Enumerator GetEnumerator()
        => new();
    IEnumerator<int> IEnumerable<int>.GetEnumerator()
        => new Enumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => new Enumerator();

    public readonly struct Enumerator
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


class TestEnumerableWithReferenceTypeEnumerator
    : IEnumerable<int>
{
    public IEnumerator<int> GetEnumerator()
        => new Enumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => new Enumerator();

    class Enumerator
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
