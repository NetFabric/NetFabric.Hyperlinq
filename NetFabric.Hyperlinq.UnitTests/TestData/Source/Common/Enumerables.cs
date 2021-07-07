using System;
using System.Collections;
using System.Collections.Generic;

public class TestEnumerableWithNoInterfaces<T>
{
    public Enumerator GetEnumerator()
        => new();

    public readonly struct Enumerator
    {
        public T Current
            => default!;

        public bool MoveNext()
            => false;
    }
}

public class TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose<T>
{
    public Enumerator GetEnumerator()
        => new();

    public readonly struct Enumerator
        : IDisposable
    {
        public T Current
            => default!;

        public bool MoveNext()
            => false;

        public void Reset()
        { }

        public void Dispose()
        { }
    }
}

public readonly struct TestEnumerableWithInterfacelessPublicEnumerator<T>
    : IEnumerable<T>
{
    public Enumerator GetEnumerator()
        => new();
    IEnumerator<T> IEnumerable<T>.GetEnumerator()
        => new DisposableEnumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => new DisposableEnumerator();

    public struct Enumerator
    {
        public T Current
            => default!;

        public bool MoveNext()
            => false;
    }

    class DisposableEnumerator
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

public readonly struct TestEnumerableWithValueTypeEnumerator<T>
    : IEnumerable<T>
{
    public Enumerator GetEnumerator()
        => new();
    IEnumerator<T> IEnumerable<T>.GetEnumerator()
        => new Enumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => new Enumerator();

    public readonly struct Enumerator
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


public readonly struct TestEnumerableWithReferenceTypeEnumerator<T>
    : IEnumerable<T>
{
    public IEnumerator<T> GetEnumerator()
        => new Enumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => new Enumerator();

    class Enumerator
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

public readonly struct TestReadOnlyCollection<T>
    : IReadOnlyCollection<T>
{
    public int Count => default;

    public Enumerator GetEnumerator()
        => new();
    IEnumerator<T> IEnumerable<T>.GetEnumerator()
        => new Enumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => new Enumerator();

    public readonly struct Enumerator
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

public readonly struct TestCollection<T>
    : ICollection<T>
{
    public int Count => default;

    public bool IsReadOnly => true;
    public bool Contains(T item) => default;
    public void CopyTo(T[] array, int arrayIndex) { }
    void ICollection<T>.Add(T item) => throw new NotSupportedException();
    bool ICollection<T>.Remove(T item) => throw new NotSupportedException();
    void ICollection<T>.Clear() => throw new NotSupportedException();

    public Enumerator GetEnumerator()
        => new();
    IEnumerator<T> IEnumerable<T>.GetEnumerator()
        => new Enumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => new Enumerator();

    public readonly struct Enumerator
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

public readonly struct TestReadOnlyList<T>
    : IReadOnlyList<T>
{
    public int Count => default;

    public T this[int index] => default!;

    public Enumerator GetEnumerator()
        => new();
    IEnumerator<T> IEnumerable<T>.GetEnumerator()
        => new Enumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => new Enumerator();

    public readonly struct Enumerator
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

public readonly struct TestList<T>
    : IList<T>
{
    public int Count => default;

    public bool IsReadOnly => true;

    public T this[int index] 
    { 
        get => default!; 
        set => throw new NotSupportedException(); 
    }

    public bool Contains(T item) => default;
    public void CopyTo(T[] array, int arrayIndex) { }
    void ICollection<T>.Add(T item) => throw new NotSupportedException();
    bool ICollection<T>.Remove(T item) => throw new NotSupportedException();
    void ICollection<T>.Clear() => throw new NotSupportedException();

    public int IndexOf(T item) => -1;
    void IList<T>.Insert(int index, T item) => throw new NotSupportedException();
    void IList<T>.RemoveAt(int index) => throw new NotSupportedException();

    public Enumerator GetEnumerator()
        => new();
    IEnumerator<T> IEnumerable<T>.GetEnumerator()
        => new Enumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => new Enumerator();

    public readonly struct Enumerator
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


public readonly struct TestListWithExplicitInterfaces<T>
    : IList<T>
{
    int ICollection<T>.Count => default;

    bool ICollection<T>.IsReadOnly => true;

    T IList<T>.this[int index]
    {
        get => default!;
        set => throw new NotSupportedException();
    }

    bool ICollection<T>.Contains(T item) => default;
    void ICollection<T>.CopyTo(T[] array, int arrayIndex) { }
    void ICollection<T>.Add(T item) => throw new NotSupportedException();
    bool ICollection<T>.Remove(T item) => throw new NotSupportedException();
    void ICollection<T>.Clear() => throw new NotSupportedException();

    int IList<T>.IndexOf(T item) => -1;
    void IList<T>.Insert(int index, T item) => throw new NotSupportedException();
    void IList<T>.RemoveAt(int index) => throw new NotSupportedException();

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
        => new Enumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => new Enumerator();

    class Enumerator
        : IEnumerator<T>
    {
        T IEnumerator<T>.Current
            => default!;
        object? IEnumerator.Current
            => default;

        bool IEnumerator.MoveNext()
            => false;

        void IEnumerator.Reset()
        { }
        void IDisposable.Dispose()
        { }
    }
}

