using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

sealed class DictionarySet<TKey, TValue> 
{
    readonly Dictionary<TKey, HashSet<TValue>> dictionary = new Dictionary<TKey, HashSet<TValue>>();

    public IEnumerable<TKey> Keys 
        => dictionary.Keys;

    public IEnumerable<IReadOnlyCollection<TValue>> Sets 
        => dictionary.Values.Cast<IReadOnlyCollection<TValue>>();

    public bool TryAdd(TKey key, TValue value)
    {
        if (!dictionary.TryGetValue(key, out var set))
        {
            set = new HashSet<TValue>();
            dictionary.Add(key, set);
        }

        return set.Add(value);
    }

    public bool TryGetValue(TKey key, out IReadOnlyCollection<TValue> values)
    {
        if (dictionary.TryGetValue(key, out var set))
        {
            values = set;
            return true;
        }

        values = default;
        return false;
    }
}