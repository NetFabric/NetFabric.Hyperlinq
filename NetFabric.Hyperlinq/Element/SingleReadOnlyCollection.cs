using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static TSource Single<TSource>(this IReadOnlyCollection<TSource> source) =>
            Single<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static KeyValuePair<TKey, TValue> Single<TKey, TValue>(this Dictionary<TKey, TValue> source) =>
                Single<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static TKey Single<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source) =>
                Single<Dictionary<TKey, TValue>.KeyCollection, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source);

        public static TValue Single<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source) =>
                Single<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source);

        public static TSource Single<TSource>(this HashSet<TSource> source) =>
                Single<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource>(source);

        public static TSource Single<TSource>(this LinkedList<TSource> source) =>
                Single<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource>(source);

        public static TSource Single<TSource>(this Queue<TSource> source) =>
                Single<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source);

        public static KeyValuePair<TKey, TValue> Single<TKey, TValue>(this SortedDictionary<TKey, TValue> source) =>
                Single<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static TKey Single<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source) =>
                Single<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source);

        public static TValue Single<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source) =>
                Single<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source);

        public static TSource Single<TSource>(this SortedSet<TSource> source) =>
                Single<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource>(source);

        public static TSource Single<TSource>(this Stack<TSource> source) =>
                Single<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source);

        public static TSource Single<TReadOnlyCollection, TEnumerator, TSource>(this TReadOnlyCollection source) 
            where TReadOnlyCollection : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();
            if (source.Count == 0) ThrowEmptySequence();
            if (source.Count > 1) ThrowNotSingleSequence();

            using (var enumerator = (TEnumerator)source.GetEnumerator())
            {
                enumerator.MoveNext();
                return enumerator.Current;
            }

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowEmptySequence() => throw new InvalidOperationException(Resource.EmptySequence);
            void ThrowNotSingleSequence() => throw new InvalidOperationException(Resource.NotSingleSequence);
        }
    }
}
