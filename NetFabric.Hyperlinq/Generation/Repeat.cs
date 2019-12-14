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
        public static RepeatEnumerable<TSource> Repeat<TSource>(TSource value, int count)
        {
            if (count < 0) ThrowHelper.ThrowArgumentOutOfRangeException(nameof(count));

            return new RepeatEnumerable<TSource>(value, count);
        }

        [GenericsTypeMapping("TEnumerable", typeof(RepeatEnumerable<>))]
        [GenericsTypeMapping("TEnumerator", typeof(RepeatEnumerable<>.DisposableEnumerator))]
        public readonly struct RepeatEnumerable<TSource>
            : IValueReadOnlyList<TSource, RepeatEnumerable<TSource>.DisposableEnumerator>
        {
            internal readonly TSource value;
            internal readonly int count;

            internal RepeatEnumerable(TSource value, int count)
            {
                this.value = value;
                this.count = count;
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly DisposableEnumerator IValueEnumerable<TSource, DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new DisposableEnumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator(in this);

            public readonly int Count => count;

            public readonly TSource this[int index]
            {
                get
                {
                    if (index < 0 || index >= count) ThrowHelper.ThrowIndexOutOfRangeException();

                    return value;
                }
            }

            public struct Enumerator
            {
                readonly TSource value;
                int counter;

                internal Enumerator(in RepeatEnumerable<TSource> enumerable)
                {
                    value = enumerable.value;
                    counter = enumerable.count;
                }

                [MaybeNull]
                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => value;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() => counter-- > 0;
            }

            public struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                readonly TSource value;
                int counter;

                internal DisposableEnumerator(in RepeatEnumerable<TSource> enumerable)
                {
                    value = enumerable.value;
                    counter = enumerable.count;
                }

                [MaybeNull]
                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => value;
                }
                readonly object? IEnumerator.Current => value;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() => counter-- > 0;

                public readonly void Reset() => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RepeatEnumerable<TSource> Skip(int count)
            {
                (_, var takeCount) = Utils.Skip(this.count, count);
                return Repeat(value, takeCount);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RepeatEnumerable<TSource> Take(int count)
                => Repeat(value, Utils.Take(this.count, count));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool All(Func<TSource, bool> predicate)
                => count == 0 ? true : predicate(value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Any()
                => count != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value)
                => count != 0 && EqualityComparer<TSource>.Default.Equals(this.value, value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => count != 0 && comparer.Equals(this.value, value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RepeatEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector) 
                => new RepeatEnumerable<TResult>(selector(value), count);

            public TSource[] ToArray()
            {
                var array = new TSource[count];
                if (value is object)
                {
#if NETCORE    
                    System.Array.Fill<TSource>(array, value);
#else                
                    for (var index = 0; index < count; index++)
                        array[index] = value;
#endif
                }
                return array;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => new List<TSource>(new ToListCollection(this));

            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector)
                => ToDictionary<TKey>(keySelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
            {
                var dictionary = new Dictionary<TKey, TSource>(count, comparer);

                var key = keySelector(value);
                for (var index = 0; index < count; index++)
                    dictionary.Add(key, value);

                return dictionary;
            }

            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
                => ToDictionary<TKey, TElement>(keySelector, elementSelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
            {
                var dictionary = new Dictionary<TKey, TElement>(count, comparer);

                var key = keySelector(value);
                var element = elementSelector(value);
                for (var index = 0; index < count; index++)
                    dictionary.Add(key, element);

                return dictionary;
            }

            public void ForEach(Action<TSource> action)
            {
                for (var index = 0; index < count; index++)
                    action(value);
            }
            public void ForEach(Action<TSource, int> action)
            {
                for (var index = 0; index < count; index++)
                    action(value, index);
            }

            // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
            [Ignore]
            sealed class ToListCollection
                : ICollection<TSource>
            {
                readonly TSource value;
                readonly int count;

                public ToListCollection(in RepeatEnumerable<TSource> source)
                {
                    this.value = source.value;
                    this.count = source.count;
                }

                public int Count => count;

                public bool IsReadOnly => true;

                public void CopyTo(TSource[] array, int _)
                {
                    if (value is null)
                        return; // no need to initialize
                        
                    for (var index = 0; index < count; index++)
                        array[index] = value;
                }

                IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => throw new NotSupportedException();
                IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
                void ICollection<TSource>.Add(TSource item) => throw new NotSupportedException();
                bool ICollection<TSource>.Remove(TSource item) => throw new NotSupportedException();
                void ICollection<TSource>.Clear() => throw new NotSupportedException();
                bool ICollection<TSource>.Contains(TSource item) => throw new NotSupportedException();
            }
        }
    }
}

