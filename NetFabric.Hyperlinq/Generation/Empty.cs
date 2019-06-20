using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EmptyEnumerable<TSource> Skip(int count) => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EmptyEnumerable<TSource> Take(int count) => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, bool> predicate) => false;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, long, bool> predicate) => false;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any() => false;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, bool> predicate) => false;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, long, bool> predicate) => false;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value) => false;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource> comparer) => false;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EmptyEnumerable<TSource> Select<TResult>(Func<TSource, long, TResult> selector)
                => selector is null ? ThrowHelper.ThrowArgumentNullException<EmptyEnumerable<TSource>>(nameof(selector)) : this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EmptyEnumerable<TSource> SelectMany<TResult>(Func<TSource, IEnumerable<TResult>> selector)
                => selector is null ? ThrowHelper.ThrowArgumentNullException<EmptyEnumerable<TSource>>(nameof(selector)) : this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EmptyEnumerable<TSource> Where(Func<TSource, long, bool> predicate)
                => predicate is null ? ThrowHelper.ThrowArgumentNullException<EmptyEnumerable<TSource>>(nameof(predicate)) : this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource First() => ThrowHelper.ThrowEmptySequence<TSource>();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource First(Func<TSource, bool> predicate) => ThrowHelper.ThrowEmptySequence<TSource>();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource FirstOrDefault() => default;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource FirstOrDefault(Func<TSource, bool> predicate) => default;
 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public (bool Success, TSource Value) TryFirst() => (false, default);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public (bool Success, TSource Value) TryFirst(Func<TSource, bool> predicate) 
                => predicate is null ? ThrowHelper.ThrowArgumentNullException<ValueTuple<bool, TSource>>(nameof(predicate)) : (false, default);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public (long Index, TSource Value) TryFirst(Func<TSource, long, bool> predicate)
                => predicate is null ? ThrowHelper.ThrowArgumentNullException<ValueTuple<long, TSource>>(nameof(predicate)) : (-1L, default);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource Single() => ThrowHelper.ThrowEmptySequence<TSource>();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource Single(Func<TSource, long, bool> predicate) => ThrowHelper.ThrowEmptySequence<TSource>();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource SingleOrDefault() => default;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource SingleOrDefault(Func<TSource, long, bool> predicate) => default;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public (bool Success, TSource Value) TrySingle() => (false, default);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public (bool Success, TSource Value) TrySingle(Func<TSource, bool> predicate) 
                => predicate is null ? ThrowHelper.ThrowArgumentNullException<ValueTuple<bool, TSource>>(nameof(predicate)) : (false, default);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public (long Index, TSource Value) TrySingle(Func<TSource, long, bool> predicate)
                => predicate is null ? ThrowHelper.ThrowArgumentNullException<ValueTuple<long, TSource>>(nameof(predicate)) : (-1L, default);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray() => new TSource[0];

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList() => new List<TSource>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this EmptyEnumerable<TSource> source)
            => 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this EmptyEnumerable<TSource> source, Func<TSource, bool> predicate)
            => predicate is null ? ThrowHelper.ThrowArgumentNullException<int>(nameof(predicate)) : 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this EmptyEnumerable<TSource> source, Func<TSource, long, bool> predicate)
            => predicate is null ? ThrowHelper.ThrowArgumentNullException<int>(nameof(predicate)) : 0;
    }
}

