using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        [Pure]
        public static EmptyEnumerable<TSource> Empty<TSource>() =>
            new EmptyEnumerable<TSource>();

        [GenerateExtensions]
        [GenericsTypeMapping("TEnumerable", typeof(EmptyEnumerable<>))]
        [GenericsTypeMapping("TEnumerator", typeof(EmptyEnumerable<>.DisposableEnumerator))]
        public readonly partial struct EmptyEnumerable<TSource>
            : IValueReadOnlyList<TSource, EmptyEnumerable<TSource>.DisposableEnumerator>
        {
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator();
            readonly DisposableEnumerator IValueEnumerable<TSource, DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator();
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new DisposableEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator();

            public readonly int Count => 0;

            public readonly TSource this[int index] => ThrowHelper.ThrowIndexOutOfRangeException<TSource>(); 

            public readonly struct Enumerator
            {
                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => default;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly bool MoveNext() => false;
            }

            public readonly struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => default;
                }
                readonly object IEnumerator.Current => default;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly bool MoveNext()
                    => false;

                public readonly void Reset() => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EmptyEnumerable<TSource> Skip(int count) => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EmptyEnumerable<TSource> Take(int count) => this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, bool> predicate) => false;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, int, bool> predicate) => false;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any() => false;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, bool> predicate) => false;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Func<TSource, int, bool> predicate) => false;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value) => false;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource> comparer) => false;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EmptyEnumerable<TSource> Select<TResult>(Func<TSource, TResult> selector)
                => selector is null ? ThrowHelper.ThrowArgumentNullException<EmptyEnumerable<TSource>>(nameof(selector)) : this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EmptyEnumerable<TSource> Select<TResult>(Func<TSource, int, TResult> selector)
                => selector is null ? ThrowHelper.ThrowArgumentNullException<EmptyEnumerable<TSource>>(nameof(selector)) : this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EmptyEnumerable<TSource> SelectMany<TResult>(Func<TSource, IEnumerable<TResult>> selector)
                => selector is null ? ThrowHelper.ThrowArgumentNullException<EmptyEnumerable<TSource>>(nameof(selector)) : this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EmptyEnumerable<TSource> Where(Func<TSource, bool> predicate)
                => predicate is null ? ThrowHelper.ThrowArgumentNullException<EmptyEnumerable<TSource>>(nameof(predicate)) : this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EmptyEnumerable<TSource> Where(Func<TSource, int, bool> predicate)
                => predicate is null ? ThrowHelper.ThrowArgumentNullException<EmptyEnumerable<TSource>>(nameof(predicate)) : this;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource ElementAt(int index) => ThrowHelper.ThrowArgumentOutOfRangeException<TSource>(nameof(index));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource ElementAtOrDefault(int index) => default;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Maybe<TSource> TryElementAt(int index) => default;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource First() => ThrowHelper.ThrowEmptySequence<TSource>();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource First(Func<TSource, bool> predicate) => ThrowHelper.ThrowEmptySequence<TSource>();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource First(Func<TSource, int, bool> predicate) => ThrowHelper.ThrowEmptySequence<TSource>();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource FirstOrDefault() => default;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource FirstOrDefault(Func<TSource, bool> predicate) => default;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource FirstOrDefault(Func<TSource, int, bool> predicate) => default;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public (bool Success, TSource Value) TryFirst() => (false, default);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public (bool Success, TSource Value) TryFirst(Func<TSource, bool> predicate) 
                => predicate is null ? ThrowHelper.ThrowArgumentNullException<ValueTuple<bool, TSource>>(nameof(predicate)) : (false, default);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public (int Index, TSource Value) TryFirst(Func<TSource, int, bool> predicate)
                => predicate is null ? ThrowHelper.ThrowArgumentNullException<ValueTuple<int, TSource>>(nameof(predicate)) : (-1, default);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource Single() => ThrowHelper.ThrowEmptySequence<TSource>();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource Single(Func<TSource, bool> predicate) => ThrowHelper.ThrowEmptySequence<TSource>();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource Single(Func<TSource, int, bool> predicate) => ThrowHelper.ThrowEmptySequence<TSource>();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource SingleOrDefault() => default;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource SingleOrDefault(Func<TSource, int, bool> predicate) => default;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource SingleOrDefault(Func<TSource, bool> predicate) => default;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray() => new TSource[0];

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList() => new List<TSource>(0);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector) 
                => new Dictionary<TKey, TSource>(0);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) 
                => new Dictionary<TKey, TSource>(0, comparer);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) 
                => new Dictionary<TKey, TElement>(0);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer) 
                => new Dictionary<TKey, TElement>(0, comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void ForEach(Action<TSource> action) 
            {
                // do nothing
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void ForEach(Action<TSource, int> action)
            {
                // do nothing
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this EmptyEnumerable<TSource> source)
            => 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this EmptyEnumerable<TSource> source, Func<TSource, bool> predicate)
            => predicate is null ? ThrowHelper.ThrowArgumentNullException<int>(nameof(predicate)) : 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this EmptyEnumerable<TSource> source, Func<TSource, int, bool> predicate)
            => predicate is null ? ThrowHelper.ThrowArgumentNullException<int>(nameof(predicate)) : 0;
    }
}

