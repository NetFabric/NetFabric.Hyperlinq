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

public class TestReadOnlyCollection
    : IReadOnlyCollection<int>
{
    public int Count => default;

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

public class TestCollection
    : ICollection<int>
{
    public int Count => default;

    public bool IsReadOnly => true;
    public bool Contains(int item) => default;
    public void CopyTo(int[] array, int arrayIndex) { }
    void ICollection<int>.Add(int item) => throw new NotSupportedException();
    bool ICollection<int>.Remove(int item) => throw new NotSupportedException();
    void ICollection<int>.Clear() => throw new NotSupportedException();

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

public class TestReadOnlyList
    : IReadOnlyList<int>
{
    public int Count => default;

    public int this[int index] => default;

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

public class TestList
    : IList<int>
{
    public int Count => default;

    public bool IsReadOnly => true;

    public int this[int index] 
    { 
        get => default; 
        set => throw new NotSupportedException(); 
    }

    public bool Contains(int item) => default;
    public void CopyTo(int[] array, int arrayIndex) { }
    void ICollection<int>.Add(int item) => throw new NotSupportedException();
    bool ICollection<int>.Remove(int item) => throw new NotSupportedException();
    void ICollection<int>.Clear() => throw new NotSupportedException();

    public int IndexOf(int item) => -1;
    void IList<int>.Insert(int index, int item) => throw new NotSupportedException();
    void IList<int>.RemoveAt(int index) => throw new NotSupportedException();

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

