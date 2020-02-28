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
        public static RepeatEnumerable<TSource> Repeat<TSource>([AllowNull] TSource value, int count)
        {
            if (count < 0) Throw.ArgumentOutOfRangeException(nameof(count));

            return new RepeatEnumerable<TSource>(value, count);
        }

        public readonly partial struct RepeatEnumerable<TSource>
            : IValueReadOnlyList<TSource, RepeatEnumerable<TSource>.DisposableEnumerator>
            , IList<TSource>
        {
            internal readonly TSource value;
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
            {
                var end = arrayIndex + count;
                for (var index = arrayIndex; index < end; index++)
                    array[index] = value;
            }
            void ICollection<TSource>.Add(TSource item) 
                => throw new NotImplementedException();
            void ICollection<TSource>.Clear() 
                => throw new NotImplementedException();
            bool ICollection<TSource>.Remove(TSource item) 
                => throw new NotImplementedException();
            int IList<TSource>.IndexOf(TSource item)
                => count > 0 && EqualityComparer<TSource>.Default.Equals(value, item)
                ? 0
                : -1;
            void IList<TSource>.Insert(int index, TSource item)
                => throw new NotImplementedException();
            void IList<TSource>.RemoveAt(int index)
                => throw new NotImplementedException();

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
                    => value;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() 
                    => counter-- > 0;
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
                    => value;
                readonly object? IEnumerator.Current 
                    => value;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() => counter-- > 0;

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => throw new NotSupportedException();

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
            public bool Contains(TSource value)
                => count != 0 && EqualityComparer<TSource>.Default.Equals(this.value, value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => count != 0 && comparer.Equals(this.value, value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RepeatEnumerable<TResult> Select<TResult>(Selector<TSource, TResult> selector) 
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

            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector)
                => ToDictionary<TKey>(keySelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TSource> ToDictionary<TKey>(Selector<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
            {
                var dictionary = new Dictionary<TKey, TSource>(count, comparer);

                var key = keySelector(value);
                for (var index = 0; index < count; index++)
                    dictionary.Add(key, value);

                return dictionary;
            }

            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector)
                => ToDictionary<TKey, TElement>(keySelector, elementSelector, EqualityComparer<TKey>.Default);
            public Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(Selector<TSource, TKey> keySelector, Selector<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
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
            public void ForEach(ActionAt<TSource> action)
            {
                for (var index = 0; index < count; index++)
                    action(value, index);
            }

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
#if NETCORE    
                        System.Array.Fill<TSource>(array, value);
#else                
                        for (var index = 0; index < Count; index++)
                            array[index] = value;
#endif
                    }
                }
            }
        }
    }
}

