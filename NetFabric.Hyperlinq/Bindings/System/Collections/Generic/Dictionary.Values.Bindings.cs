using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class DictionaryValuesBindings
    {
        
        public static int Count<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => source.Count;

        
        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Skip<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, int count)
            => ValueReadOnlyCollection.Skip<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), count);

        
        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Take<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, int count)
            => ValueReadOnlyCollection.Take<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), count);

        
        public static bool All<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Predicate<TValue> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);
        
        public static bool All<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, PredicateAt<TValue> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        
        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => source.Count != 0;
        
        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Predicate<TValue> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);
        
        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, PredicateAt<TValue> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        
        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, TValue value)
            => source.Contains(value);

        
        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, TValue value, IEqualityComparer<TValue>? comparer)
            => ValueReadOnlyCollection.Contains<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), value, comparer);

        
        public static ValueReadOnlyCollection.SelectEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            Selector<TValue, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult>(new ValueWrapper<TKey, TValue>(source), selector);
        
        public static ValueReadOnlyCollection.SelectAtEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            SelectorAt<TValue, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        
        public static ValueEnumerable.SelectManyEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TKey, TValue, TSubEnumerable, TSubEnumerator, TResult>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            Selector<TValue, TSubEnumerable> selector)
            where TSubEnumerable : notnull, IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueEnumerable.SelectMany<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        
        public static ValueEnumerable.WhereEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Where<TKey, TValue>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            Predicate<TValue> predicate)
            => ValueEnumerable.Where<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);
        
        public static ValueEnumerable.WhereAtEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Where<TKey, TValue>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            PredicateAt<TValue> predicate)
            => ValueEnumerable.Where<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), predicate);

        
        public static Option<TValue> ElementAt<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, int index)
            => ValueReadOnlyCollection.ElementAt<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), index);

        
        public static Option<TValue> First<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => ValueReadOnlyCollection.First<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        
        public static Option<TValue> Single<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => ValueReadOnlyCollection.Single<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        
        public static ValueEnumerable.DistinctEnumerable<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Distinct<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, IEqualityComparer<TValue>? comparer = null)
            => ValueEnumerable.Distinct<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source), comparer);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TValue>.ValueCollection AsEnumerable<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => source;

        
        public static ValueWrapper<TKey, TValue> AsValueEnumerable<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => new ValueWrapper<TKey, TValue>(source);

        
        public static TValue[] ToArray<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => ValueReadOnlyCollection.ToArray<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        
        public static List<TValue> ToList<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => ValueReadOnlyCollection.ToList<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(new ValueWrapper<TKey, TValue>(source));

        
        public static Dictionary<TKey2, TValue> ToDictionary<TKey, TValue, TKey2>(this Dictionary<TKey, TValue>.ValueCollection source, Selector<TValue, TKey2> keySelector, IEqualityComparer<TKey2>? comparer = null)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TKey2>(new ValueWrapper<TKey, TValue>(source), keySelector, comparer);
        
        public static Dictionary<TKey2, TElement> ToDictionary<TKey, TValue, TKey2, TElement>(this Dictionary<TKey, TValue>.ValueCollection source, Selector<TValue, TKey2> keySelector, Selector<TValue, TElement> elementSelector, IEqualityComparer<TKey2>? comparer = null)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TKey2, TElement>(new ValueWrapper<TKey, TValue>(source), keySelector, elementSelector, comparer);

        [GeneratorMapping("TSource", "TValue")]
        public readonly partial struct ValueWrapper<TKey, TValue>
            : IValueReadOnlyCollection<TValue, Dictionary<TKey, TValue>.ValueCollection.Enumerator>
            , ICollection<TValue>
        {
            readonly Dictionary<TKey, TValue>.ValueCollection source;

            public ValueWrapper(Dictionary<TKey, TValue>.ValueCollection source) 
                => this.source = source;

            public readonly int Count
                => source.Count;

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Dictionary<TKey, TValue>.ValueCollection.Enumerator GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();

            bool ICollection<TValue>.IsReadOnly  
                => true;

            void ICollection<TValue>.CopyTo(TValue[] array, int arrayIndex) 
                => ((ICollection<TValue>)source).CopyTo(array, arrayIndex);

            void ICollection<TValue>.Add(TValue item) 
                => Throw.NotSupportedException();
            void ICollection<TValue>.Clear() 
                => Throw.NotSupportedException();
            bool ICollection<TValue>.Contains(TValue item) 
                => Throw.NotSupportedException<bool>();
            bool ICollection<TValue>.Remove(TValue item) 
                => Throw.NotSupportedException<bool>();
        }

        public static int Count<TKey, TValue>(this ValueWrapper<TKey, TValue> source)
            => source.Count;
    }
}