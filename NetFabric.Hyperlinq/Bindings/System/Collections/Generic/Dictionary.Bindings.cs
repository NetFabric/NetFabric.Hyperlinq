using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class DictionaryBindings
    {
        public static int Count<TKey, TValue>(this Dictionary<TKey, TValue> source)
            where TKey : notnull
            => source.Count;

        public static ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Skip<TKey, TValue>(this Dictionary<TKey, TValue> source, int count)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Skip<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), count);

        public static ValueReadOnlyCollectionExtensions.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Take<TKey, TValue>(this Dictionary<TKey, TValue> source, int count)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Take<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), count);

        public static bool All<TKey, TValue>(this Dictionary<TKey, TValue> source, Predicate<KeyValuePair<TKey, TValue>> predicate)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.All<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static bool All<TKey, TValue>(this Dictionary<TKey, TValue> source, PredicateAt<KeyValuePair<TKey, TValue>> predicate)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.All<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue> source)
            where TKey : notnull
            => source.Count != 0;

        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue> source, KeyValuePair<TKey, TValue> value)
            where TKey : notnull
            => source.Contains(value);

        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue> source, KeyValuePair<TKey, TValue> value, IEqualityComparer<KeyValuePair<TKey, TValue>>? comparer)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Contains<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), value, comparer);

        public static ValueReadOnlyCollectionExtensions.SelectEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue> source,
            NullableSelector<KeyValuePair<TKey, TValue>, TResult> selector)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Select<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult>(new ValueWrapper<TKey, TValue>(source), selector);
        public static ValueReadOnlyCollectionExtensions.SelectAtEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue> source,
            NullableSelectorAt<KeyValuePair<TKey, TValue>, TResult> selector)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.Select<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        public static ValueEnumerableExtensions.SelectManyEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TKey, TValue, TSubEnumerable, TSubEnumerator, TResult>(
            this Dictionary<TKey, TValue> source,
            Selector<KeyValuePair<TKey, TValue>, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TKey : notnull
            => ValueEnumerableExtensions.SelectMany<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        public static ValueEnumerableExtensions.WhereEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, ValuePredicate<KeyValuePair<TKey, TValue>>> Where<TKey, TValue>(
            this Dictionary<TKey, TValue> source,
            Predicate<KeyValuePair<TKey, TValue>> predicate)
            where TKey : notnull
            => ValueEnumerableExtensions.Where<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        public static ValueEnumerableExtensions.WhereAtEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, ValuePredicateAt<KeyValuePair<TKey, TValue>>> Where<TKey, TValue>(
            this Dictionary<TKey, TValue> source,
            PredicateAt<KeyValuePair<TKey, TValue>> predicate)
            where TKey : notnull
            => ValueEnumerableExtensions.Where<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        public static Option<KeyValuePair<TKey, TValue>> ElementAt<TKey, TValue>(this Dictionary<TKey, TValue> source, int index)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.ElementAt<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), index);

        public static Option<KeyValuePair<TKey, TValue>> First<TKey, TValue>(this Dictionary<TKey, TValue> source)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.First<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        public static Option<KeyValuePair<TKey, TValue>> Single<TKey, TValue>(this Dictionary<TKey, TValue> source)
            where TKey : notnull
#pragma warning disable HLQ005 // Avoid Single() and SingleOrDefault()
            => ValueReadOnlyCollectionExtensions.Single<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));
#pragma warning restore HLQ005 // Avoid Single() and SingleOrDefault()

        public static ValueEnumerableExtensions.DistinctEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Distinct<TKey, TValue>(this Dictionary<TKey, TValue> source, IEqualityComparer<KeyValuePair<TKey, TValue>>? comparer = default)
            where TKey : notnull
            => ValueEnumerableExtensions.Distinct<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TValue> AsEnumerable<TKey, TValue>(this Dictionary<TKey, TValue> source)
            where TKey : notnull
            => source;

        public static ValueWrapper<TKey, TValue> AsValueEnumerable<TKey, TValue>(this Dictionary<TKey, TValue> source)
            where TKey : notnull
            => new ValueWrapper<TKey, TValue>(source);

        public static KeyValuePair<TKey, TValue>[] ToArray<TKey, TValue>(this Dictionary<TKey, TValue> source)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.ToArray<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        public static List<KeyValuePair<TKey, TValue>> ToList<TKey, TValue>(this Dictionary<TKey, TValue> source)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.ToList<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this Dictionary<TKey, TValue> source, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey, TValue>(new ValueWrapper<TKey, TValue>(source), item => item.Key, item => item.Value, comparer);

        public static Dictionary<TKey2, KeyValuePair<TKey, TValue>> ToDictionary<TKey, TValue, TKey2>(this Dictionary<TKey, TValue> source, Selector<KeyValuePair<TKey, TValue>, TKey2> keySelector, IEqualityComparer<TKey2>? comparer = default)
            where TKey : notnull
            where TKey2 : notnull
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey2>(new ValueWrapper<TKey, TValue>(source), keySelector, comparer);

        public static Dictionary<TKey2, TElement> ToDictionary<TKey, TValue, TKey2, TElement>(this Dictionary<TKey, TValue> source, Selector<KeyValuePair<TKey, TValue>, TKey2> keySelector, NullableSelector<KeyValuePair<TKey, TValue>, TElement> elementSelector, IEqualityComparer<TKey2>? comparer = default)
            where TKey : notnull
            where TKey2 : notnull
            => ValueReadOnlyCollectionExtensions.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey2, TElement>(new ValueWrapper<TKey, TValue>(source), keySelector, elementSelector, comparer);

        [GeneratorMapping("TSource", "System.Collections.Generic.KeyValuePair<TKey, TValue>", true)]
        public readonly partial struct ValueWrapper<TKey, TValue>
            : IValueReadOnlyCollection<KeyValuePair<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator>
            , ICollection<KeyValuePair<TKey, TValue>>
            where TKey : notnull
        {
            readonly Dictionary<TKey, TValue> source;

            public ValueWrapper(Dictionary<TKey, TValue> source) 
                => this.source = source;

            public readonly int Count
                => source.Count;

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Dictionary<TKey, TValue>.Enumerator GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();

            bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly  
                => true;

            void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) 
                => ((ICollection<KeyValuePair<TKey, TValue>>)source).CopyTo(array, arrayIndex);

            [ExcludeFromCodeCoverage]
            void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item) 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<KeyValuePair<TKey, TValue>>.Clear() 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item) 
                => Throw.NotSupportedException<bool>();
            [ExcludeFromCodeCoverage]
            bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item) 
                => Throw.NotSupportedException<bool>();        
        }

        public static int Count<TKey, TValue>(this ValueWrapper<TKey, TValue> source)
            where TKey : notnull
            => source.Count;
    }
}