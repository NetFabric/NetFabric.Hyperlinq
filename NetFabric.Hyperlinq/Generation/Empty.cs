using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static EmptyEnumerable<TSource> Empty<TSource>() =>
            new EmptyEnumerable<TSource>();

        public readonly struct EmptyEnumerable<TSource>
            : IValueReadOnlyList<TSource, EmptyEnumerable<TSource>.ValueEnumerator>
        {
            public Enumerator GetEnumerator() => new Enumerator();
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator();

            public long Count => 0;

            public TSource this[long index] { get { ThrowHelper.ThrowIndexOutOfRangeException(); return default; } }

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

            public EmptyEnumerable<TSource> Skip(int count)
                => this;

            public EmptyEnumerable<TSource> Take(int count)
                => this;

            public bool All(Func<TSource, long, bool> predicate)
                => false;

            public bool Any()
                => false;

            public bool Any(Func<TSource, long, bool> predicate)
                => false;

            public bool Contains(TSource value)
                => false;

            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => false;

            public EmptyEnumerable<TSource> Select<TResult>(Func<TSource, long, TResult> selector)
            {
                if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

                return this;
            }

            public EmptyEnumerable<TSource> SelectMany<TResult>(Func<TSource, IEnumerable<TResult>> selector)
            {
                if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

                return this;
            }

            public EmptyEnumerable<TSource> Where(Func<TSource, long, bool> predicate)
            {
                if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

                return this;
            }

            public TSource First() => ThrowHelper.ThrowEmptySequence<TSource>();
            public TSource First(Func<TSource, long, bool> _) => ThrowHelper.ThrowEmptySequence<TSource>();

            public TSource FirstOrDefault() => default;
            public TSource FirstOrDefault(Func<TSource, long, bool> _) => default;

            public TSource Single() => ThrowHelper.ThrowEmptySequence<TSource>();
            public TSource Single(Func<TSource, long, bool> _) => ThrowHelper.ThrowEmptySequence<TSource>();

            public TSource SingleOrDefault() => default;
            public TSource SingleOrDefault(Func<TSource, long, bool> _) => default;

            public IReadOnlyList<TSource> AsEnumerable()
                => ValueReadOnlyList.AsEnumerable<EmptyEnumerable<TSource>, ValueEnumerator, TSource>(this);

            public EmptyEnumerable<TSource> AsValueEnumerable()
                => this;

            public TSource[] ToArray()
                => new TSource[0];

            public List<TSource> ToList()
                => new List<TSource>();
        }

        public static int Count<TSource>(this EmptyEnumerable<TSource> _)
            => 0;

        public static int Count<TSource>(this EmptyEnumerable<TSource> _, Func<TSource, long, bool> predicate)
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return 0;
        }

        public static TSource? FirstOrNull<TSource>(this EmptyEnumerable<TSource> _)
            where TSource : struct
            => null;

        public static TSource? FirstOrNull<TSource>(this EmptyEnumerable<TSource> _, Func<TSource, long, bool> predicate)
            where TSource : struct
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return null;
        }

        public static TSource? SingleOrNull<TSource>(this EmptyEnumerable<TSource> _)
            where TSource : struct
            => null;

        public static TSource? SingleOrNull<TSource>(this EmptyEnumerable<TSource> _, Func<TSource, long, bool> predicate)
            where TSource : struct
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return null;
        }
    }
}

