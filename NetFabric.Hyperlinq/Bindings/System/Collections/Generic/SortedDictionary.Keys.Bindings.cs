using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static class SortedDictionaryKeysBindings
    {
        [Pure]
        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => source.Count;
        [Pure]
        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => ValueReadOnlyCollection.Count<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, int, bool> predicate)
            => ValueReadOnlyCollection.Count<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);

        [Pure]
        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey> Skip<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, int count)
            => ValueReadOnlyCollection.Skip<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), count);

        [Pure]
        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey> Take<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, int count)
            => ValueReadOnlyCollection.Take<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), count);

        [Pure]
        public static bool All<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static bool All<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, int, bool> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);

        [Pure]
        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => source.Count != 0;
        [Pure]
        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, int, bool> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);

        [Pure]
        public static bool Contains<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, TKey value)
            => source.Contains(value);

        [Pure]
        public static bool Contains<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, TKey value, IEqualityComparer<TKey> comparer)
            => ValueReadOnlyCollection.Contains<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), value, comparer);

        [Pure]
        public static ValueReadOnlyCollection.SelectEnumerable<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey, TResult> Select<TKey, TValue, TResult>(
            this SortedDictionary<TKey, TValue>.KeyCollection source,
            Func<TKey, TResult> selector) 
            => ValueReadOnlyCollection.Select<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey, TResult>(new ValueWrapper<TKey, TValue>(source), selector);
        [Pure]
        public static ValueReadOnlyCollection.SelectIndexEnumerable<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey, TResult> Select<TKey, TValue, TResult>(
            this SortedDictionary<TKey, TValue>.KeyCollection source,
            Func<TKey, int, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        [Pure]
        public static ValueEnumerable.SelectManyEnumerable<ValueWrapper<TKey, TValue>,  ValueWrapper<TKey, TValue>.Enumerator, TKey, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TKey, TValue, TSubEnumerable, TSubEnumerator, TResult>(
            this SortedDictionary<TKey, TValue>.KeyCollection source,
            Func<TKey, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
            => ValueEnumerable.SelectMany<ValueWrapper<TKey, TValue>,  ValueWrapper<TKey, TValue>.Enumerator, TKey, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        [Pure]
        public static ValueEnumerable.WhereEnumerable<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey> Where<TKey, TValue>(
            this SortedDictionary<TKey, TValue>.KeyCollection source,
            Func<TKey, bool> predicate) 
            => ValueEnumerable.Where<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static ValueEnumerable.WhereIndexEnumerable<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey> Where<TKey, TValue>(
            this SortedDictionary<TKey, TValue>.KeyCollection source,
            Func<TKey, int, bool> predicate)
            => ValueEnumerable.Where<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);

        [Pure]
        public static TKey First<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source) 
            => ValueReadOnlyCollection.First<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));
        [Pure]
        public static TKey First<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => ValueReadOnlyCollection.First<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static TKey FirstOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));
        [Pure]
        public static TKey FirstOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static (ElementResult Success, TKey Value) TryFirst<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));
        [Pure]
        public static (ElementResult Success, TKey Value) TryFirst<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static (int Index, TKey Value) TryFirst<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, int, bool> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);

        [Pure]
        public static TKey Single<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source) 
            => ValueReadOnlyCollection.Single<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));
        [Pure]
        public static TKey Single<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => ValueReadOnlyCollection.Single<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static TKey SingleOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));
        [Pure]
        public static TKey SingleOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static (ElementResult Success, TKey Value) TrySingle<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));
        [Pure]
        public static (ElementResult Success, TKey Value) TrySingle<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static (int Index, TKey Value) TrySingle<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, int, bool> predicate)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);

        [Pure]
        public static ValueEnumerable.DistinctEnumerable<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey> Distinct<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source, IEqualityComparer<TKey> comparer = null)
            => ValueEnumerable.Distinct<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), comparer);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SortedDictionary<TKey, TValue>.KeyCollection AsEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => source;

        [Pure]
        public static ValueWrapper<TKey, TValue> AsValueEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => new ValueWrapper<TKey, TValue>(source);

        [Pure]
        public static TKey[] ToArray<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => ValueReadOnlyCollection.ToArray<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));

        [Pure]
        public static List<TKey> ToList<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            => ValueReadOnlyCollection.ToList<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));

        [Pure]
        public static Dictionary<TKey2, TKey> ToDictionary<TKey, TValue, TKey2>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, TKey2> keySelector)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey, TKey2>(new ValueWrapper<TKey, TValue>(source), keySelector);
        [Pure]
        public static Dictionary<TKey2, TKey> ToDictionary<TKey, TValue, TKey2>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, TKey2> keySelector, IEqualityComparer<TKey2> comparer)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey, TKey2>(new ValueWrapper<TKey, TValue>(source), keySelector, comparer);
        [Pure]
        public static Dictionary<TKey2, TElement> ToDictionary<TKey, TValue, TKey2, TElement>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, TKey2> keySelector, Func<TKey, TElement> elementSelector)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey, TKey2, TElement>(new ValueWrapper<TKey, TValue>(source), keySelector, elementSelector);
        [Pure]
        public static Dictionary<TKey2, TElement> ToDictionary<TKey, TValue, TKey2, TElement>(this SortedDictionary<TKey, TValue>.KeyCollection source, Func<TKey, TKey2> keySelector, Func<TKey, TElement> elementSelector, IEqualityComparer<TKey2> comparer)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, ValueWrapper<TKey, TValue>.Enumerator, TKey, TKey2, TElement>(new ValueWrapper<TKey, TValue>(source), keySelector, elementSelector, comparer);

        public readonly struct ValueWrapper<TKey, TValue> 
            : IValueReadOnlyCollection<TKey, ValueWrapper<TKey, TValue>.Enumerator>
        {
            readonly SortedDictionary<TKey, TValue>.KeyCollection source;

            public ValueWrapper(SortedDictionary<TKey, TValue>.KeyCollection source)
            {
                this.source = source;
            }

            public readonly int Count => source.Count;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly ValueWrapper<TKey, TValue>.Enumerator GetEnumerator() => new Enumerator(source);
            readonly IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();

            public struct Enumerator
                : IValueEnumerator<TKey>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                SortedDictionary<TKey, TValue>.KeyCollection.Enumerator enumerator;

                internal Enumerator(SortedDictionary<TKey, TValue>.KeyCollection enumerable)
                {
                    enumerator = enumerable.GetEnumerator();
                }

                public readonly TKey Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => enumerator.Current;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() => enumerator.MoveNext();
            }
        }
    }
}