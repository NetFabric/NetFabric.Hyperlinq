using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static class DictionaryKeysBindings
    {
        [Pure]
        public static int Count<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            => source.Count;
        [Pure]
        public static int Count<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => ValueReadOnlyCollection.Count<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static int Count<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, int, bool> predicate)
            => ValueReadOnlyCollection.Count<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);

        [Pure]
        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> Skip<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, int count)
            => ValueReadOnlyCollection.Skip<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), count);

        [Pure]
        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> Take<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, int count)
            => ValueReadOnlyCollection.Take<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), count);

        [Pure]
        public static bool All<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static bool All<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, int, bool> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);

        [Pure]
        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            => source.Count != 0;
        [Pure]
        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, int, bool> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);

        [Pure]
        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, TKey value)
            => source.Contains(value);

        [Pure]
        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, TKey value, IEqualityComparer<TKey> comparer)
            => ValueReadOnlyCollection.Contains<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), value, comparer);

        [Pure]
        public static ValueReadOnlyCollection.SelectEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            Func<TKey, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult>(new ValueWrapper<TKey, TValue>(source), selector);
        [Pure]
        public static ValueReadOnlyCollection.SelectIndexEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            Func<TKey, int, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        [Pure]
        public static ValueEnumerable.SelectManyEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TKey, TValue, TSubEnumerable, TSubEnumerator, TResult>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            Func<TKey, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueEnumerable.SelectMany<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        [Pure]
        public static ValueEnumerable.WhereEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> Where<TKey, TValue>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            Func<TKey, bool> predicate)
            => ValueEnumerable.Where<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static ValueEnumerable.WhereIndexEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> Where<TKey, TValue>(
            this Dictionary<TKey, TValue>.KeyCollection source,
            Func<TKey, int, bool> predicate)
            => ValueEnumerable.Where<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);

        [Pure]
        public static TKey First<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            => ValueReadOnlyCollection.First<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));
        [Pure]
        public static TKey First<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => ValueReadOnlyCollection.First<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static TKey FirstOrDefault<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));
        [Pure]
        public static TKey FirstOrDefault<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static (ElementResult Success, TKey Value) TryFirst<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));
        [Pure]
        public static (ElementResult Success, TKey Value) TryFirst<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static (int Index, TKey Value) TryFirst<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, int, bool> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);

        [Pure]
        public static TKey Single<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            => ValueReadOnlyCollection.Single<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));
        [Pure]
        public static TKey Single<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => ValueReadOnlyCollection.Single<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static TKey SingleOrDefault<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));
        [Pure]
        public static TKey SingleOrDefault<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static (ElementResult Success, TKey Value) TrySingle<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));
        [Pure]
        public static (ElementResult Success, TKey Value) TrySingle<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, bool> predicate)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static (int Index, TKey Value) TrySingle<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, int, bool> predicate)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), predicate);

        [Pure]
        public static ValueEnumerable.DistinctEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> Distinct<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source, IEqualityComparer<TKey> comparer = null)
            => ValueEnumerable.Distinct<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source), comparer);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TValue>.KeyCollection AsEnumerable<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            => source;

        [Pure]
        public static ValueWrapper<TKey, TValue> AsValueEnumerable<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            => new ValueWrapper<TKey, TValue>(source);

        [Pure]
        public static TKey[] ToArray<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            => ValueReadOnlyCollection.ToArray<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));

        [Pure]
        public static List<TKey> ToList<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            => ValueReadOnlyCollection.ToList<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(new ValueWrapper<TKey, TValue>(source));

        [Pure]
        public static Dictionary<TKey2, TKey> ToDictionary<TKey, TValue, TKey2>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, TKey2> keySelector)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TKey2>(new ValueWrapper<TKey, TValue>(source), keySelector);
        [Pure]
        public static Dictionary<TKey2, TKey> ToDictionary<TKey, TValue, TKey2>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, TKey2> keySelector, IEqualityComparer<TKey2> comparer)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TKey2>(new ValueWrapper<TKey, TValue>(source), keySelector, comparer);
        [Pure]
        public static Dictionary<TKey2, TElement> ToDictionary<TKey, TValue, TKey2, TElement>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, TKey2> keySelector, Func<TKey, TElement> elementSelector)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TKey2, TElement>(new ValueWrapper<TKey, TValue>(source), keySelector, elementSelector);
        [Pure]
        public static Dictionary<TKey2, TElement> ToDictionary<TKey, TValue, TKey2, TElement>(this Dictionary<TKey, TValue>.KeyCollection source, Func<TKey, TKey2> keySelector, Func<TKey, TElement> elementSelector, IEqualityComparer<TKey2> comparer)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, TKey2, TElement>(new ValueWrapper<TKey, TValue>(source), keySelector, elementSelector, comparer);

        public readonly struct ValueWrapper<TKey, TValue>
            : IValueReadOnlyCollection<TKey, Dictionary<TKey, TValue>.KeyCollection.Enumerator>
        {
            readonly Dictionary<TKey, TValue>.KeyCollection source;

            public ValueWrapper(Dictionary<TKey, TValue>.KeyCollection source)
            {
                this.source = source;
            }

            public readonly int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Count;
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Dictionary<TKey, TValue>.KeyCollection.Enumerator GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();
        }
    }
}