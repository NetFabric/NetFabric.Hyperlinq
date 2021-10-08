using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    class DictionarySet<TKey, TValue>
        where TKey : notnull
    {
        readonly Dictionary<TKey, List<TValue>> dictionary = new();
        
        public int Count { get; private set; }

        public void Add(TKey key, TValue value)
        {
            if (!dictionary.TryGetValue(key, out var list))
            {
                list = new List<TValue>();
                dictionary.Add(key, list);
            }
            list.Add(value);
            Count++;
        }

        public bool TryGetValue(TKey key, [NotNullWhen(true)] out IReadOnlyList<TValue>? values)
        { 
            if (dictionary.TryGetValue(key, out var list))
            {
                values = list;
                return true;
            }

            values = default;
            return false;
        }
    }
}
