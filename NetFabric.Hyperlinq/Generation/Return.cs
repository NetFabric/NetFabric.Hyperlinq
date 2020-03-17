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
        public static ReturnEnumerable<TSource> Return<TSource>(TSource value) =>
            new ReturnEnumerable<TSource>(value);

        public readonly partial struct ReturnEnumerable<TSource>
            : IValueReadOnlyList<TSource, ReturnEnumerable<TSource>.DisposableEnumerator>
            , IList<TSource>
        {
            internal readonly TSource value;

            internal ReturnEnumerable(TSource value)
            {
                this.value = value;
            }

            public readonly int Count => 1;

            [MaybeNull]
            public readonly TSource this[int index]
            {
                get
                {
                    if (index != 0) Throw.IndexOutOfRangeException();

                    return value;
                }
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            [MaybeNull]
            TSource IList<TSource>.this[int index]
            {
                get => this[index];
                set => throw new NotImplementedException();
            }

            bool ICollection<TSource>.IsReadOnly  
                => true;

            void ICollection<TSource>.CopyTo(TSource[] array, int arrayIndex) 
                => array[arrayIndex] = value;
            void ICollection<TSource>.Add(TSource item) 
                => throw new NotImplementedException();
            void ICollection<TSource>.Clear() 
                => throw new NotImplementedException();
            bool ICollection<TSource>.Remove(TSource item) 
                => throw new NotImplementedException();
            int IList<TSource>.IndexOf(TSource item)
                => EqualityComparer<TSource>.Default.Equals(value, item)
                ? 0
                : -1;
            void IList<TSource>.Insert(int index, TSource item)
                => throw new NotImplementedException();
            void IList<TSource>.RemoveAt(int index)
                => throw new NotImplementedException();

            public struct Enumerator
            {
                readonly TSource value;
                bool moveNext;

                internal Enumerator(in ReturnEnumerable<TSource> enumerable)
                {
                    value = enumerable.value;
                    moveNext = true;
                }

                [MaybeNull]
                public readonly TSource Current
                    => value;

                public bool MoveNext()
                {
                    if (moveNext)
                    {
                        moveNext = false;
                        return true;
                    }
                    return false;
                }
            }

            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                readonly TSource value;
                bool moveNext;

                internal DisposableEnumerator(in ReturnEnumerable<TSource> enumerable)
                {
                    value = enumerable.value;
                    moveNext = true;
                }

                [MaybeNull]
                public readonly TSource Current
                    => value;
                readonly object? IEnumerator.Current 
                    => value;

                public bool MoveNext()
                {
                    if (moveNext)
                    {
                        moveNext = false;
                        return true;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => true;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value)
                => EqualityComparer<TSource>.Default.Equals(this.value, value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => comparer.Equals(this.value, value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReturnEnumerable<TResult> Select<TResult>(Selector<TSource, TResult> selector)
                => new ReturnEnumerable<TResult>(selector(value));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> ElementAt(int index)
                => index == 0 ? Option.Some(value) : Option.None;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> First()
                => Option.Some(value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> Single()
                => Option.Some(value);

            public TSource[] ToArray()
                => new TSource[] { value };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => new List<TSource>(1) { value };

            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector)
                => ToDictionary<TKey>(keySelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
                => new Dictionary<TKey, TSource>(1, comparer) { { keySelector(value), value } };

            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector)
                => ToDictionary<TKey, TElement>(keySelector, elementSelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
                => new Dictionary<TKey, TElement>(1, comparer) { { keySelector(value), elementSelector(value) } };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this ReturnEnumerable<TSource> source)
            => 1;
    }
}

