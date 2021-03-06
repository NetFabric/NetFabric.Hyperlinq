using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static class DictionaryExtensions
    {
        // Dictionary<TKey, TValue> is reference-type that implements IReadOnlyCollection<TKey, TValue> and has a value-type enumerator that implements IEnumerator<TKey, TValue>
        // Same for Dictionary<TKey, TValue>.KeyCollection and Dictionary<TKey, TValue>.ValueCollection
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyCollectionExtensions.ValueEnumerable<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, GetEnumerator<TKey, TValue>, GetEnumerator<TKey, TValue>> AsValueEnumerable<TKey, TValue>(this Dictionary<TKey, TValue> source)
            where TKey : notnull
            => ReadOnlyCollectionExtensions.AsValueEnumerable<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, GetEnumerator<TKey, TValue>>(source);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyCollectionExtensions.ValueEnumerable<Dictionary<TKey, TValue>.KeyCollection, Dictionary<TKey, TValue>.KeyCollection.Enumerator, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, GetEnumerator<TKey, TValue>, GetEnumerator<TKey, TValue>> AsValueEnumerable<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection source)
            where TKey : notnull
            => ReadOnlyCollectionExtensions.AsValueEnumerable<Dictionary<TKey, TValue>.KeyCollection, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey, GetEnumerator<TKey, TValue>>(source);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyCollectionExtensions.ValueEnumerable<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, GetEnumerator<TKey, TValue>, GetEnumerator<TKey, TValue>> AsValueEnumerable<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            where TKey : notnull
            => ReadOnlyCollectionExtensions.AsValueEnumerable<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, GetEnumerator<TKey, TValue>>(source);

        [StructLayout(LayoutKind.Auto)]
        public readonly struct GetEnumerator<TKey, TValue>
            : IFunction<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator> 
            , IFunction<Dictionary<TKey, TValue>.KeyCollection, Dictionary<TKey, TValue>.KeyCollection.Enumerator>
            , IFunction<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator>
            where TKey : notnull
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TValue>.Enumerator Invoke(Dictionary<TKey, TValue> source) 
                => source.GetEnumerator();
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TValue>.KeyCollection.Enumerator Invoke(Dictionary<TKey, TValue>.KeyCollection source) 
                => source.GetEnumerator();
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Dictionary<TKey, TValue>.ValueCollection.Enumerator Invoke(Dictionary<TKey, TValue>.ValueCollection source) 
                => source.GetEnumerator();
        }
    }
}