using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        [Pure]
        public static EmptyEnumerable<TSource> Empty<TSource>() =>
            new EmptyEnumerable<TSource>();

        [GenericsTypeMapping("TEnumerable", typeof(EmptyEnumerable<>))]
        [GenericsTypeMapping("TEnumerator", typeof(EmptyEnumerable<>.DisposableEnumerator))]
        public readonly struct EmptyEnumerable<TSource>
            : IValueReadOnlyList<TSource, EmptyEnumerable<TSource>.DisposableEnumerator>
        {
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator();
            readonly DisposableEnumerator IValueEnumerable<TSource, DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator();
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new DisposableEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator();

            public readonly int Count => 0;

            public readonly TSource this[int index] => Throw.IndexOutOfRangeException<TSource>(); 

            public readonly struct Enumerator
            {
                [MaybeNull]
                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => default!;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly bool MoveNext() => false;
            }

            public readonly struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                [MaybeNull]
                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => default!;
                }
                readonly object? IEnumerator.Current => default!;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly bool MoveNext()
                    => false;

                public readonly void Reset() => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EmptyEnumerable<TSource> Skip(int count) => this;

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EmptyEnumerable<TSource> Take(int count) => this;

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Predicate<TSource> predicate) => false;

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(PredicateAt<TSource> predicate) => false;

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any() => false;

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(Predicate<TSource> predicate) => false;

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any(PredicateAt<TSource> predicate) => false;

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value) => false;

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource> comparer) => false;

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EmptyEnumerable<TSource> Select<TResult>(Selector<TSource, TResult> selector)
                => selector is null 
                    ? Throw.ArgumentNullException<EmptyEnumerable<TSource>>(nameof(selector)) 
                    : this;

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EmptyEnumerable<TSource> Select<TResult>(SelectorAt<TSource, TResult> selector)
                => selector is null 
                    ? Throw.ArgumentNullException<EmptyEnumerable<TSource>>(nameof(selector)) 
                    : this;

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EmptyEnumerable<TSource> SelectMany<TResult>(Selector<TSource, IEnumerable<TResult>> selector)
                => selector is null 
                    ? Throw.ArgumentNullException<EmptyEnumerable<TSource>>(nameof(selector)) 
                    : this;

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EmptyEnumerable<TSource> Where(Predicate<TSource> predicate)
                => predicate is null 
                    ? Throw.ArgumentNullException<EmptyEnumerable<TSource>>(nameof(predicate)) 
                    : this;

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public EmptyEnumerable<TSource> Where(PredicateAt<TSource> predicate)
                => predicate is null 
                    ? Throw.ArgumentNullException<EmptyEnumerable<TSource>>(nameof(predicate)) 
                    : this;

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource ElementAt(int index) 
                => Throw.ArgumentOutOfRangeException<TSource>(nameof(index));

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TSource ElementAtOrDefault(int index) 
                => default!;

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Maybe<TSource> TryElementAt(int index) 
                => default!;

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource First() 
                => Throw.EmptySequence<TSource>();

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource First(Predicate<TSource> predicate) 
                => Throw.EmptySequence<TSource>();

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource First(PredicateAt<TSource> predicate) 
                => Throw.EmptySequence<TSource>();

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TSource FirstOrDefault() 
                => default!;

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TSource FirstOrDefault(Predicate<TSource> predicate) 
                => default!;

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TSource FirstOrDefault(PredicateAt<TSource> predicate) 
                => default!;

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public (bool Success, TSource Value) TryFirst() 
                => (false, default!);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public (bool Success, TSource Value) TryFirst(Predicate<TSource> predicate) 
                => predicate is null 
                    ? Throw.ArgumentNullException<ValueTuple<bool, TSource>>(nameof(predicate)) 
                    : (false, default!);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public (int Index, TSource Value) TryFirst(PredicateAt<TSource> predicate)
                => predicate is null 
                    ? Throw.ArgumentNullException<ValueTuple<int, TSource>>(nameof(predicate)) 
                    : (-1, default!);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource Single() 
                => Throw.EmptySequence<TSource>();

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource Single(Predicate<TSource> predicate) 
                => Throw.EmptySequence<TSource>();

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource Single(PredicateAt<TSource> predicate) 
                => Throw.EmptySequence<TSource>();

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TSource SingleOrDefault() 
                => default!;

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TSource SingleOrDefault(PredicateAt<TSource> predicate) 
                => default!;

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [return: MaybeNull]
            public TSource SingleOrDefault(Predicate<TSource> predicate) 
                => default!;

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray() 
                => new TSource[0];

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList() 
                => new List<TSource>(0);

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector) 
                => new Dictionary<TKey, TSource>(0);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) 
                => new Dictionary<TKey, TSource>(0, comparer);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector) 
                => new Dictionary<TKey, TElement>(0);
            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer) 
                => new Dictionary<TKey, TElement>(0, comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void ForEach(Action<TSource> action) 
            {
                // do nothing
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void ForEach(ActionAt<TSource> action)
            {
                // do nothing
            }
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this EmptyEnumerable<TSource> source)
            => 0;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this EmptyEnumerable<TSource> source, Predicate<TSource> predicate)
            => predicate is null 
                ? Throw.ArgumentNullException<int>(nameof(predicate)) 
                : 0;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this EmptyEnumerable<TSource> source, PredicateAt<TSource> predicate)
            => predicate is null 
                ? Throw.ArgumentNullException<int>(nameof(predicate)) 
                : 0;
    }
}

