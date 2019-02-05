using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static TSource SingleOrDefault<TSource>(this IReadOnlyCollection<TSource> source) =>
            SingleOrDefault<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static KeyValuePair<TKey, TValue> SingleOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> source) =>
                SingleOrDefault<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static TKey SingleOrDefault<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source) =>
                SingleOrDefault<Dictionary<TKey, TValue>.KeyCollection, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source);

        public static TValue SingleOrDefault<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source) =>
                SingleOrDefault<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source);

        public static TSource SingleOrDefault<TSource>(this HashSet<TSource> source) =>
                SingleOrDefault<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource>(source);

        public static TSource SingleOrDefault<TSource>(this LinkedList<TSource> source) =>
                SingleOrDefault<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource>(source);

        public static TSource SingleOrDefault<TSource>(this Queue<TSource> source) =>
                SingleOrDefault<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source);

        public static KeyValuePair<TKey, TValue> SingleOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue> source) =>
                SingleOrDefault<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static TKey SingleOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source) =>
                SingleOrDefault<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source);

        public static TValue SingleOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source) =>
                SingleOrDefault<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source);

        public static TSource SingleOrDefault<TSource>(this SortedSet<TSource> source) =>
                SingleOrDefault<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource>(source);

        public static TSource SingleOrDefault<TSource>(this Stack<TSource> source) =>
                SingleOrDefault<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source);

        public static TSource SingleOrDefault<TReadOnlyCollection, TEnumerator, TSource>(this TReadOnlyCollection source) 
            where TReadOnlyCollection : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();
            if (source.Count == 0) return default;
            if (source.Count > 1) ThrowNotSingleSequence();

            using (var enumerator = (TEnumerator)source.GetEnumerator())
            {
                enumerator.MoveNext();
                return enumerator.Current;
            }

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowNotSingleSequence() => throw new InvalidOperationException(Resource.NotSingleSequence);
        }
    }
}
