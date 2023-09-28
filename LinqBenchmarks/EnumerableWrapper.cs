using System.Collections;
using System.Runtime.CompilerServices;

namespace LinqBenchmarks;

public class EnumerableWrapper<T>
    : IEnumerable<T>
{
    readonly T[] array;

    public EnumerableWrapper(T[] array)
        => this.array = array;

    public T this[int index]
        => array[index];

    public int Count
        => array.Length;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IEnumerator<T> GetEnumerator()
        => new Enumerator(array);

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();

    class Enumerator : IEnumerator<T>
    {
        readonly T[] array;
        int index;

        internal Enumerator(T[] array)
        {
            this.array = array;
            index = -1;
        }

        public T Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => array[index];
        }
        T IEnumerator<T>.Current
            => Current;
        object? IEnumerator.Current
            => Current;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
            => ++index < array.Length;

        bool IEnumerator.MoveNext()
            => MoveNext();

        public void Reset()
            => index = -1;

        public void Dispose() { }
    }
}