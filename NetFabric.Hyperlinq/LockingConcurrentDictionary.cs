// Copyright (c) 2010 Jimmy Bogard

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public struct LockingConcurrentDictionary<TKey, TValue>
    {
        readonly ConcurrentDictionary<TKey, Lazy<TValue>> dictionary;
        readonly Func<TKey, Lazy<TValue>> valueFactory;

        public LockingConcurrentDictionary(Func<TKey, TValue> valueFactory)
        {
            this.dictionary = new ConcurrentDictionary<TKey, Lazy<TValue>>();
            this.valueFactory = key => new Lazy<TValue>(() => valueFactory(key));
        }

        public TValue GetOrAdd(TKey key) => 
            dictionary.GetOrAdd(key, valueFactory).Value;

        public TValue GetOrAdd(TKey key, Func<TKey, Lazy<TValue>> valueFactory) => 
            dictionary.GetOrAdd(key, valueFactory).Value;

        public TValue this[TKey key]
        {
            get => dictionary[key].Value;
            set => dictionary[key] = new Lazy<TValue>(() => value);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (dictionary.TryGetValue(key, out Lazy<TValue> lazy))
            {
                value = lazy.Value;
                return true;
            }
            value = default;
            return false;
        }

        public bool ContainsKey(TKey key) => dictionary.ContainsKey(key);

        public ICollection<TKey> Keys => dictionary.Keys;        
    }
}