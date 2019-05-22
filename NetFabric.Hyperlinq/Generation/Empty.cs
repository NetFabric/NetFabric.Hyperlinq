using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static EmptyEnumerable<TSource> Empty<TSource>() =>
            new EmptyEnumerable<TSource>();

        [GenericsTypeMapping("TEnumerable", typeof(EmptyEnumerable<>))]
        [GenericsTypeMapping("TEnumerator", typeof(EmptyEnumerable<>.Enumerator))]
        public readonly struct EmptyEnumerable<TSource>
            : IValueReadOnlyList<TSource, EmptyEnumerable<TSource>.Enumerator>
        {
            public Enumerator GetEnumerator() => new Enumerator();

            public long Count => 0;

            public TSource this[long index] { get { ThrowHelper.ThrowIndexOutOfRangeException(); return default; } }

            public readonly struct Enumerator
                : IValueEnumerator<TSource>
            {
                public TSource Current
                    => default;

                public bool MoveNext()
                    => false;

                public void Dispose() { }
            }

            public EmptyEnumerable<TSource> Skip(int count) => this;

            public EmptyEnumerable<TSource> Take(int count) => this;

            public bool All(Func<TSource, bool> predicate) => false;
            public bool All(Func<TSource, long, bool> predicate) => false;

            public bool Any() => false;
            public bool Any(Func<TSource, bool> predicate) => false;
            public bool Any(Func<TSource, long, bool> predicate) => false;

            public bool Contains(TSource value) => false;
            public bool Contains(TSource value, IEqualityComparer<TSource> comparer) => false;

            public EmptyEnumerable<TSource> Select<TResult>(Func<TSource, long, TResult> selector)
                => selector is null ? ThrowHelper.ThrowArgumentNullException<EmptyEnumerable<TSource>>(nameof(selector)) : this;

            public EmptyEnumerable<TSource> SelectMany<TResult>(Func<TSource, IEnumerable<TResult>> selector)
                => selector is null ? ThrowHelper.ThrowArgumentNullException<EmptyEnumerable<TSource>>(nameof(selector)) : this;

            public EmptyEnumerable<TSource> Where(Func<TSource, long, bool> predicate)
                => predicate is null ? ThrowHelper.ThrowArgumentNullException<EmptyEnumerable<TSource>>(nameof(predicate)) : this;

            public TSource First() => ThrowHelper.ThrowEmptySequence<TSource>();
            public TSource First(Func<TSource, bool> predicate) => ThrowHelper.ThrowEmptySequence<TSource>();
            public TSource FirstOrDefault() => default;
            public TSource FirstOrDefault(Func<TSource, bool> predicate) => default;
            public (bool Success, TSource Value) TryFirst() => (false, default);
            public (bool Success, TSource Value) TryFirst(Func<TSource, bool> predicate) 
                => predicate is null ? ThrowHelper.ThrowArgumentNullException<ValueTuple<bool, TSource>>(nameof(predicate)) : (false, default);
            public (long Index, TSource Value) TryFirst(Func<TSource, long, bool> predicate)
                => predicate is null ? ThrowHelper.ThrowArgumentNullException<ValueTuple<long, TSource>>(nameof(predicate)) : (-1L, default);

            public TSource Single() => ThrowHelper.ThrowEmptySequence<TSource>();
            public TSource Single(Func<TSource, long, bool> predicate) => ThrowHelper.ThrowEmptySequence<TSource>();
            public TSource SingleOrDefault() => default;
            public TSource SingleOrDefault(Func<TSource, long, bool> predicate) => default;
            public (bool Success, TSource Value) TrySingle() => (false, default);
            public (bool Success, TSource Value) TrySingle(Func<TSource, bool> predicate) 
                => predicate is null ? ThrowHelper.ThrowArgumentNullException<ValueTuple<bool, TSource>>(nameof(predicate)) : (false, default);
            public (long Index, TSource Value) TrySingle(Func<TSource, long, bool> predicate)
                => predicate is null ? ThrowHelper.ThrowArgumentNullException<ValueTuple<long, TSource>>(nameof(predicate)) : (-1L, default);

            public TSource[] ToArray() => new TSource[0];

            public List<TSource> ToList() => new List<TSource>();
        }

        public static int Count<TSource>(this EmptyEnumerable<TSource> source)
            => 0;
        public static int Count<TSource>(this EmptyEnumerable<TSource> source, Func<TSource, bool> predicate)
            => predicate is null ? ThrowHelper.ThrowArgumentNullException<int>(nameof(predicate)) : 0;
        public static int Count<TSource>(this EmptyEnumerable<TSource> source, Func<TSource, long, bool> predicate)
            => predicate is null ? ThrowHelper.ThrowArgumentNullException<int>(nameof(predicate)) : 0;
    }
}

