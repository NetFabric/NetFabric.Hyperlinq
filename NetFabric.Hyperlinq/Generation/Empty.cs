using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static EmptyReadOnlyList<TSource> Empty<TSource>() =>
            new EmptyReadOnlyList<TSource>();

        public readonly struct EmptyReadOnlyList<TSource>
            : IValueReadOnlyList<TSource, EmptyReadOnlyList<TSource>.ValueEnumerator>
        {
            public Enumerator GetEnumerator() => new Enumerator();
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator();

            public int Count() => 0;

            public TSource this[int index] => throw new IndexOutOfRangeException();

            public readonly struct Enumerator 
            {
                public TSource Current => default;

                public bool MoveNext() => false;
            }

            public readonly struct ValueEnumerator 
                : IValueEnumerator<TSource>
            {
                public bool TryMoveNext(out TSource current)
                {
                    current = default;
                    return false;
                }

                public bool TryMoveNext() => false;

                public void Dispose() { }
            }

            public EmptyReadOnlyList<TSource> Select<TResult>(Func<TSource, TResult> selector)
            {
                if (selector is null) ThrowSelectorNull();

                return this;

                void ThrowSelectorNull() => throw new ArgumentNullException(nameof(selector));
            }

            public EmptyReadOnlyList<TSource> Where(Func<TSource, bool> predicate)
            {
                if (predicate is null) ThrowPredicateNull();

                return this;

                void ThrowPredicateNull() => throw new ArgumentNullException(nameof(predicate));
            }

            public TSource First() => throw new InvalidOperationException(Resource.EmptySequence);
            public TSource First(Func<TSource, bool> _) => throw new InvalidOperationException(Resource.EmptySequence);

            public TSource FirstOrDefault() => default;
            public TSource FirstOrDefault(Func<TSource, bool> _) => default;

            public TSource Single() => throw new InvalidOperationException(Resource.EmptySequence);
            public TSource Single(Func<TSource, bool> _) => throw new InvalidOperationException(Resource.EmptySequence);

            public TSource SingleOrDefault() => default;
            public TSource SingleOrDefault(Func<TSource, bool> _) => default;

            public IEnumerable<TSource> AsEnumerable()
                => System.Linq.Enumerable.Empty<TSource>();

            public IReadOnlyCollection<TSource> AsReadOnlyCollection()
                => ValueReadOnlyCollection.AsReadOnlyCollection<EmptyReadOnlyList<TSource>, ValueEnumerator, TSource>(this);

            public IReadOnlyList<TSource> AsReadOnlyList()
                => ValueReadOnlyList.AsReadOnlyList<EmptyReadOnlyList<TSource>, ValueEnumerator, TSource>(this);

            public TSource[] ToArray()
                => new TSource[0];

            public List<TSource> ToList()
                => new List<TSource>();
        }
    }
}

