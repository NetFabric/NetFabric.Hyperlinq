using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    sealed class TypeDictionary<TValue>
    {
        readonly Dictionary<Type, TValue> dictionary = new Dictionary<Type, TValue>();

        readonly Func<Type, TValue> valueFactory;

        public TypeDictionary(Func<Type, TValue> valueFactory)
        {
            this.valueFactory = valueFactory;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TValue GetOrAdd(Type type)
        {
            if (dictionary.TryGetValue(type, out var value))
                return value;

            return Add(type);
        }

        TValue Add(Type type)
        {
            var value = valueFactory(type);
            dictionary[type] = value;
            return value;
        }
    }
}