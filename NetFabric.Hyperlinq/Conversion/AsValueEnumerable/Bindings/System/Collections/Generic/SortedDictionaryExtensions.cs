using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static class SortedDictionaryExtensions
    {
        // SortedDictionary<TKey, TValue> is reference-type that implements IReadOnlyCollection<TKey, TValue> and has a value-type enumerator that implements IEnumerator<TKey, TValue>
        // Same for SortedDictionary<TKey, TValue>.KeyCollection and SortedDictionary<TKey, TValue>.ValueCollection
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyCollectionExtensions.ValueEnumerable<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, GetEnumerator<TKey, TValue>, GetEnumerator<TKey, TValue>> AsValueEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            where TKey : notnull
            => ReadOnlyCollectionExtensions.AsValueEnumerable<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, GetEnumerator<TKey, TValue>>(source);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyCollectionExtensions.ValueEnumerable<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, GetEnumerator<TKey, TValue>, GetEnumerator<TKey, TValue>> AsValueEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue>.KeyCollection source)
            where TKey : notnull
            => ReadOnlyCollectionExtensions.AsValueEnumerable<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, GetEnumerator<TKey, TValue>>(source);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyCollectionExtensions.ValueEnumerable<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, GetEnumerator<TKey, TValue>, GetEnumerator<TKey, TValue>> AsValueEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue>.ValueCollection source)
            where TKey : notnull
            => ReadOnlyCollectionExtensions.AsValueEnumerable<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, GetEnumerator<TKey, TValue>>(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly struct GetEnumerator<TKey, TValue>
            : IFunction<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator> 
            , IFunction<SortedDictionary<TKey, TValue>.KeyCollection, SortedDictionary<TKey, TValue>.KeyCollection.Enumerator>
            , IFunction<SortedDictionary<TKey, TValue>.ValueCollection, SortedDictionary<TKey, TValue>.ValueCollection.Enumerator>
            where TKey : notnull
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SortedDictionary<TKey, TValue>.Enumerator Invoke(SortedDictionary<TKey, TValue> source) 
                => source.GetEnumerator();
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SortedDictionary<TKey, TValue>.KeyCollection.Enumerator Invoke(SortedDictionary<TKey, TValue>.KeyCollection source) 
                => source.GetEnumerator();
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SortedDictionary<TKey, TValue>.ValueCollection.Enumerator Invoke(SortedDictionary<TKey, TValue>.ValueCollection source) 
                => source.GetEnumerator();
        }
    }
}