using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static class ImmutableDictionaryExtensions
    {
        // ImmutableDictionary<TKey, TValue> implements IReadOnlyCollection<KeyValuePair<TKey, TValue>> and has a value-type enumerator that implements IEnumerator<TKey, TValue>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyCollectionExtensions.ValueEnumerable<ImmutableDictionary<TKey, TValue>, ImmutableDictionary<TKey, TValue>.Enumerator, ImmutableDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, GetEnumerator<TKey, TValue>, GetEnumerator<TKey, TValue>> AsValueEnumerable<TKey, TValue>(this ImmutableDictionary<TKey, TValue> source)
            where TKey: notnull
            => ReadOnlyCollectionExtensions.AsValueEnumerable<ImmutableDictionary<TKey, TValue>, ImmutableDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, GetEnumerator<TKey, TValue>>(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly struct GetEnumerator<TKey, TValue>
            : IFunction<ImmutableDictionary<TKey, TValue>, ImmutableDictionary<TKey, TValue>.Enumerator>
            where TKey: notnull
        {
            public ImmutableDictionary<TKey, TValue>.Enumerator Invoke(ImmutableDictionary<TKey, TValue> source) 
                => source.GetEnumerator();
        }
    }
}