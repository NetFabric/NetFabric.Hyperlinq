using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        
        public static ReturnEnumerable<TSource> Return<TSource>([AllowNull] TSource value) =>
            new ReturnEnumerable<TSource>(value);

        public readonly partial struct ReturnEnumerable<TSource>
            : IValueReadOnlyList<TSource, ReturnEnumerable<TSource>.DisposableEnumerator>
            , IList<TSource>
        {
            [AllowNull, MaybeNull] internal readonly TSource value;

            internal ReturnEnumerable([AllowNull] TSource value) 
                => this.value = value;

            public readonly int Count 
                => 1;

            [MaybeNull]
            public readonly TSource this[int index]
            {
                get
                {
                    if (index != 0) Throw.IndexOutOfRangeException();

                    return value;
                }
            }
            TSource IReadOnlyList<TSource>.this[int index]
                => this[index]!;
            TSource IList<TSource>.this[int index]
            {
                get => this[index]!;
                set => Throw.NotSupportedException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            bool ICollection<TSource>.IsReadOnly  
                => true;

            void ICollection<TSource>.CopyTo(TSource[] array, int arrayIndex) 
                => array[arrayIndex] = value;
            bool ICollection<TSource>.Contains(TSource item)
                => Contains(item);
            void ICollection<TSource>.Add(TSource item) 
                => Throw.NotSupportedException();
            void ICollection<TSource>.Clear() 
                => Throw.NotSupportedException();
            bool ICollection<TSource>.Remove(TSource item) 
                => Throw.NotSupportedException<bool>();
            int IList<TSource>.IndexOf(TSource item)
                => EqualityComparer<TSource>.Default.Equals(value, item)
                    ? 0
                    : -1;
            void IList<TSource>.Insert(int index, TSource item)
                => Throw.NotSupportedException();
            void IList<TSource>.RemoveAt(int index)
                => Throw.NotSupportedException();

            public struct Enumerator
            {
                bool moveNext;

                internal Enumerator(in ReturnEnumerable<TSource> enumerable)
                {
                    Current = enumerable.value;
                    moveNext = true;
                }

                [MaybeNull]
                public readonly TSource Current { get; }

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
                bool moveNext;

                internal DisposableEnumerator(in ReturnEnumerable<TSource> enumerable)
                {
                    Current = enumerable.value;
                    moveNext = true;
                }

                [MaybeNull]
                public readonly TSource Current { get; }
                readonly TSource IEnumerator<TSource>.Current 
                    => Current!;
                readonly object? IEnumerator.Current
                    => Current;

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
                    => Throw.NotSupportedException();

                public readonly void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => true;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer = default)
                => comparer is null
                    ? EqualityComparer<TSource>.Default.Equals(this.value, value)
                    : comparer.Equals(this.value, value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReturnEnumerable<TResult> Select<TResult>(NullableSelector<TSource, TResult> selector)
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

            public Dictionary<TKey, TSource> ToDictionary<TKey>(NullableSelector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                => new Dictionary<TKey, TSource>(1, comparer) { { keySelector(value), value } };

            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(NullableSelector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                => new Dictionary<TKey, TElement>(1, comparer) { { keySelector(value), elementSelector(value) } };
        }

#pragma warning disable IDE0060 // Remove unused parameter
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this ReturnEnumerable<TSource> source)
            => 1;
#pragma warning restore IDE0060 // Remove unused parameter
    }
}

