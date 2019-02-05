using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static TSource FirstOrDefault<TSource>(this IReadOnlyCollection<TSource> source) =>
            FirstOrDefault<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static KeyValuePair<TKey, TValue> FirstOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> source) =>
                FirstOrDefault<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static TKey FirstOrDefault<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source) =>
                FirstOrDefault<Dictionary<TKey, TValue>.KeyCollection, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source);

        public static TValue FirstOrDefault<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source) =>
                FirstOrDefault<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source);

        public static TSource FirstOrDefault<TSource>(this HashSet<TSource> source) =>
                FirstOrDefault<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource>(source);

        public static TSource FirstOrDefault<TSource>(this LinkedList<TSource> source) =>
                FirstOrDefault<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource>(source);

        public static TSource FirstOrDefault<TSource>(this Queue<TSource> source) =>
                FirstOrDefault<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source);

        public static KeyValuePair<TKey, TValue> FirstOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue> source) =>
                FirstOrDefault<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static TKey FirstOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source) =>
                FirstOrDefault<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source);

        public static TValue FirstOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source) =>
                FirstOrDefault<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source);

        public static TSource FirstOrDefault<TSource>(this SortedSet<TSource> source) =>
                FirstOrDefault<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource>(source);

        public static TSource FirstOrDefault<TSource>(this Stack<TSource> source) =>
                FirstOrDefault<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source);

        public static TSource FirstOrDefault<TReadOnlyCollection, TEnumerator, TSource>(this TReadOnlyCollection source) 
            where TReadOnlyCollection : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();
            if (source.Count == 0) return default;

            using (var enumerator = (TEnumerator)source.GetEnumerator())
            {
                enumerator.MoveNext();
                return enumerator.Current;
            }

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }
    }
}
