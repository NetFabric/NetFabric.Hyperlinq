using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class DictionaryValuesExtensions
    {
        public static int Count<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => source.Count;

        public static ReadOnlyCollection.SelectReadOnlyCollection<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, TResult> selector) 
            => ReadOnlyCollection.Select<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Where<TKey, TValue>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, bool> predicate) 
            => Enumerable.Where<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source, predicate);

        public static TValue First<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source) 
            => ReadOnlyCollection.First<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source);

        public static TValue FirstOrDefault<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.FirstOrDefault<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source);

        public static TValue Single<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.Single<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source);

        public static TValue SingleOrDefault<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.SingleOrDefault<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source);
    }
}
