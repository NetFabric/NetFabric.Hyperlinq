using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static ReadOnlyList.EmptyReadOnlyList<TSource> Empty<TSource>() =>
            new ReadOnlyList.EmptyReadOnlyList<TSource>();
    }

    public static partial class ReadOnlyList
    {
        public readonly struct EmptyReadOnlyList<TSource> : IReadOnlyList<TSource>
        {
            public Enumerator GetEnumerator() => new Enumerator();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator();
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator();

            public int Count => 0;

            public TSource this[int index] => throw new IndexOutOfRangeException();

            public readonly struct Enumerator : IEnumerator<TSource>
            {
                public TSource Current => default;
                object IEnumerator.Current => default;

                public bool MoveNext() => false;

                public void Reset() { }

                public void Dispose() { }
            }

            public EmptyReadOnlyList<TSource> Select<TResult>(Func<TSource, TResult> _) => this;

            public EmptyReadOnlyList<TSource> Where<TResult>(Func<TSource, bool> _) => this;

            public TSource First() => throw new InvalidOperationException(Resource.EmptySequence);
            public TSource First(Func<TSource, bool> _) => throw new InvalidOperationException(Resource.EmptySequence);

            public TSource FirstOrDefault() => default;
            public TSource FirstOrDefault(Func<TSource, bool> _) => default;

            public TSource Single() => throw new InvalidOperationException(Resource.EmptySequence);
            public TSource Single(Func<TSource, bool> _) => throw new InvalidOperationException(Resource.EmptySequence);

            public TSource SingleOrDefault() => default;
            public TSource SingleOrDefault(Func<TSource, bool> _) => default;
        }
    }
}

