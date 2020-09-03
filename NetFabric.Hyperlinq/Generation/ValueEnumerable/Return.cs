using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        
        public static ReturnEnumerable<TSource> Return<TSource>([AllowNull] TSource value) =>
            new ReturnEnumerable<TSource>(value);

        [StructLayout(LayoutKind.Auto)]
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
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
                [ExcludeFromCodeCoverage]
                set => Throw.NotSupportedException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, DisposableEnumerator>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => new DisposableEnumerator(in this);

            bool ICollection<TSource>.IsReadOnly  
                => true;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TSource[] array, int arrayIndex) 
                => array[arrayIndex] = value;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource item)
                => EqualityComparer<TSource>.Default.Equals(value, item);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            int IList<TSource>.IndexOf(TSource item)
                => EqualityComparer<TSource>.Default.Equals(value, item)
                    ? 0
                    : -1;

            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Add(TSource item) 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Clear() 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<TSource>.Remove(TSource item) 
                => Throw.NotSupportedException<bool>();

            [ExcludeFromCodeCoverage]
            void IList<TSource>.Insert(int index, TSource item)
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void IList<TSource>.RemoveAt(int index)
                => Throw.NotSupportedException();

            [StructLayout(LayoutKind.Auto)]
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

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    var previous = moveNext;
                    moveNext = false;
                    return previous;
                }
            }

            [StructLayout(LayoutKind.Auto)]
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

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext()
                {
                    var previous = moveNext;
                    moveNext = false;
                    return previous;
                }

                [ExcludeFromCodeCoverage]
                public void Reset() 
                    => moveNext = true;

                public readonly void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => true;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer)
                => comparer is null
                    ? EqualityComparer<TSource>.Default.Equals(this.value, value)
                    : comparer.Equals(this.value, value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReturnEnumerable<TResult> Select<TResult>(NullableSelector<TSource, TResult> selector)
                => new ReturnEnumerable<TResult>(selector(value));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> ElementAt(int index)
                => index switch
                { 
                    0 => Option.Some(value),
                    _ => Option.None,
                };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> First()
                => Option.Some(value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Option<TSource> Single()
                => Option.Some(value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => new TSource[] { value };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => new List<TSource>(1) { value };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => new Dictionary<TKey, TSource>(1, comparer) { { keySelector(value), value } };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                where TKey : notnull
                => new Dictionary<TKey, TElement>(1, comparer) { { keySelector(value), elementSelector(value)! } };
        }

#pragma warning disable IDE0060 // Remove unused parameter
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this in ReturnEnumerable<TSource> source)
            => 1;
#pragma warning restore IDE0060 // Remove unused parameter
    }
}

