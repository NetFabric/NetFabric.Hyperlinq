using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static TSource First<TSource>(this IReadOnlyCollection<TSource> source) =>
            First<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static KeyValuePair<TKey, TValue> First<TKey, TValue>(this Dictionary<TKey, TValue> source) =>
                First<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static TKey First<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source) =>
                First<Dictionary<TKey, TValue>.KeyCollection, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source);

        public static TValue First<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source) =>
                First<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source);

        public static TSource First<TSource>(this HashSet<TSource> source) =>
                First<HashSet<TSource>, HashSet<TSource>.Enumerator, TSource>(source);

        public static TSource First<TSource>(this LinkedList<TSource> source) =>
                First<LinkedList<TSource>, LinkedList<TSource>.Enumerator, TSource>(source);

        public static TSource First<TSource>(this Queue<TSource> source) =>
                First<Queue<TSource>, Queue<TSource>.Enumerator, TSource>(source);

        public static KeyValuePair<TKey, TValue> First<TKey, TValue>(this SortedDictionary<TKey, TValue> source) =>
                First<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static TKey First<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source) =>
                First<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source);

        public static TValue First<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source) =>
                First<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source);

        public static TSource First<TSource>(this SortedSet<TSource> source) =>
                First<SortedSet<TSource>, SortedSet<TSource>.Enumerator, TSource>(source);

        public static TSource First<TSource>(this Stack<TSource> source) =>
                First<Stack<TSource>, Stack<TSource>.Enumerator, TSource>(source);

        public static TSource First<TReadOnlyCollection, TEnumerator, TSource>(this TReadOnlyCollection source) 
            where TReadOnlyCollection : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();
            if (source.Count == 0) ThrowEmptySequence();

            using (var enumerator = (TEnumerator)source.GetEnumerator())
            {
                enumerator.MoveNext();
                return enumerator.Current;
            }

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowEmptySequence() => throw new InvalidOperationException(Resource.EmptySequence);
        }
    }
}
