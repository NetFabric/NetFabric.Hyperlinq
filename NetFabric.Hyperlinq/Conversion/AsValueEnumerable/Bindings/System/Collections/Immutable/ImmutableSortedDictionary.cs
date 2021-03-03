using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static class ImmutableSortedDictionaryExtensions
    {
        // ImmutableSortedDictionary<TKey, TValue> is reference-type that implements IReadOnlyCollection<KeyValuePair<TKey, TValue>> and has a value-type enumerator that implements IEnumerator<TKey, TValue>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyCollectionExtensions.ValueEnumerable<ImmutableSortedDictionary<TKey, TValue>, ImmutableSortedDictionary<TKey, TValue>.Enumerator, ImmutableSortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, GetEnumerator<TKey, TValue>, GetEnumerator<TKey, TValue>> AsValueEnumerable<TKey, TValue>(this ImmutableSortedDictionary<TKey, TValue> source)
            where TKey: notnull
            => ReadOnlyCollectionExtensions.AsValueEnumerable<ImmutableSortedDictionary<TKey, TValue>, ImmutableSortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, GetEnumerator<TKey, TValue>>(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly struct GetEnumerator<TKey, TValue>
            : IFunction<ImmutableSortedDictionary<TKey, TValue>, ImmutableSortedDictionary<TKey, TValue>.Enumerator>
            where TKey: notnull
        {
            public ImmutableSortedDictionary<TKey, TValue>.Enumerator Invoke(ImmutableSortedDictionary<TKey, TValue> source) 
                => source.GetEnumerator();
        }
    }
}