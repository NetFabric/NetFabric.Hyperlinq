using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        
        public static RepeatEnumerable<TSource> Repeat<TSource>([AllowNull] TSource value, int count)
        {
            if (count < 0) Throw.ArgumentOutOfRangeException(nameof(count));

            return new RepeatEnumerable<TSource>(value, count);
        }

        public readonly partial struct RepeatEnumerable<TSource>
            : IValueReadOnlyList<TSource, RepeatEnumerable<TSource>.DisposableEnumerator>
            , IList<TSource>
        {
            [AllowNull, MaybeNull] internal readonly TSource value;
            internal readonly int count;

            internal RepeatEnumerable([AllowNull] TSource value, int count)
            {
                this.value = value;
                this.count = count;
            }

            public readonly int Count => count;

            [MaybeNull]
            public readonly TSource this[int index]
            {
                get
                {
                    if (index < 0 || index >= count) Throw.IndexOutOfRangeException();

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
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            bool ICollection<TSource>.IsReadOnly  
                => true;

            public void CopyTo(TSource[] array, int arrayIndex) 
            {
                var end = arrayIndex + count;
                for (var index = arrayIndex; index < end; index++)
                    array[index] = value;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            bool ICollection<TSource>.Contains(TSource item)
                => count > 0 && EqualityComparer<TSource>.Default.Equals(value, item)
                    ? true
                    : false;

            public int IndexOf(TSource item)
                => count > 0 && EqualityComparer<TSource>.Default.Equals(value, item)
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

            public struct Enumerator
            {
                int counter;

                internal Enumerator(in RepeatEnumerable<TSource> enumerable)
                {
                    Current = enumerable.value;
                    counter = enumerable.count;
                }

                [MaybeNull]
                public readonly TSource Current { get; }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => counter-- > 0;
            }

            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                int counter;

                internal DisposableEnumerator(in RepeatEnumerable<TSource> enumerable)
                {
                    Current = enumerable.value;
                    counter = enumerable.count;
                }

                [MaybeNull]
                public readonly TSource Current { get; }
                readonly TSource IEnumerator<TSource>.Current 
                    => Current!;
                readonly object? IEnumerator.Current 
                    => Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() => counter-- > 0;

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public readonly void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RepeatEnumerable<TSource> Skip(int count)
            {
                var (_, takeCount) = Utils.Skip(this.count, count);
                return Repeat(value, takeCount);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RepeatEnumerable<TSource> Take(int count)
                => Repeat(value, Utils.Take(this.count, count));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Predicate<TSource> predicate)
                => count == 0 
                    ? true 
                    : predicate(value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => count != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource>? comparer = default)
                => comparer is null
                    ? count != 0 && EqualityComparer<TSource>.Default.Equals(this.value, value)
                    : count != 0 && comparer.Equals(this.value, value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RepeatEnumerable<TResult> Select<TResult>(NullableSelector<TSource, TResult> selector) 
                => new RepeatEnumerable<TResult>(selector(value), count);

            public TSource[] ToArray()
            {
                var array = new TSource[count];
                if (value is object)
                {
#if NETSTANDARD2_1
                    Array.Fill<TSource>(array, value);
#else
                    for (var index = 0; index < array.Length; index++)
                        array[index] = value;
#endif
                }
                return array;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => new List<TSource>(new ToListCollection(this));

            public Dictionary<TKey, TSource> ToDictionary<TKey>(NullableSelector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
                => ToDictionary<TKey>(keySelector, comparer);

            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(NullableSelector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
                => ToDictionary<TKey, TElement>(keySelector, elementSelector, comparer);

            // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
            [GeneratorIgnore]
            sealed class ToListCollection
                : ToListCollectionBase<TSource>
            {
                readonly TSource value;

                public ToListCollection(in RepeatEnumerable<TSource> source)
                    : base(source.count)
                    => value = source.value;

                public override void CopyTo(TSource[] array, int _)
                {
                    if (value is object)
                    {
#if NETSTANDARD2_1
                        Array.Fill(array, value);
#else
                        for (var index = 0; index < array.Length; index++)
                            array[index] = value;
#endif
                    }
                }
            }
        }
    }
}

