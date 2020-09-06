using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ListBindings
    {
        public static int Count<TSource>(this List<TSource> source)
            => source.Count;

        public static ArraySegment<TSource> Skip<TSource>(this List<TSource> source, int count)
            => source.AsArraySegment().Skip(count);

        public static ArraySegment<TSource> Take<TSource>(this List<TSource> source, int count)
            => source.AsArraySegment().Take(count);

        public static bool All<TSource>(this List<TSource> source, Predicate<TSource> predicate)
            => source.AsArraySegment().All(predicate);
        
        public static bool All<TSource>(this List<TSource> source, PredicateAt<TSource> predicate)
            => source.AsArraySegment().All(predicate);

        
        public static bool Any<TSource>(this List<TSource> source)
            => source.Count != 0;
        
        public static bool Contains<TSource>(this List<TSource> source, [AllowNull] TSource value, IEqualityComparer<TSource>? comparer = default)
            => source.AsArraySegment().Contains(value, comparer);

        public static ArrayExtensions.ArraySegmentSelectEnumerable<TSource, TResult> Select<TSource, TResult>(
            this List<TSource> source,
            NullableSelector<TSource, TResult> selector)
            => source.AsArraySegment().Select(selector);

        public static ArrayExtensions.ArraySegmentSelectAtEnumerable<TSource, TResult> Select<TSource, TResult>(
            this List<TSource> source,
            NullableSelectorAt<TSource, TResult> selector)
            => source.AsArraySegment().Select(selector);

        public static ArrayExtensions.ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this List<TSource> source,
            Selector<TSource, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => source.AsArraySegment().SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(selector);
        
        public static ArrayExtensions.ArraySegmentWhereEnumerable<TSource, ValuePredicate<TSource>> Where<TSource>(
            this List<TSource> source,
            Predicate<TSource> predicate)
            => source.AsArraySegment().Where(predicate);
        
        public static ArrayExtensions.ArraySegmentWhereAtEnumerable<TSource, ValuePredicateAt<TSource>> Where<TSource>(
            this List<TSource> source,
            PredicateAt<TSource> predicate)
            => source.AsArraySegment().Where(predicate);
        
        public static ArrayExtensions.ArraySegmentWhereRefEnumerable<TSource, ValuePredicate<TSource>> WhereRef<TSource>(
            this List<TSource> source,
            Predicate<TSource> predicate)
            => source.AsArraySegment().WhereRef(predicate);
        
        public static ArrayExtensions.ArraySegmentWhereRefAtEnumerable<TSource, ValuePredicateAt<TSource>> WhereRef<TSource>(
            this List<TSource> source,
            PredicateAt<TSource> predicate)
            => source.AsArraySegment().WhereRef(predicate);

        public static Option<TSource> ElementAt<TSource>(this List<TSource> source, int index)
            => source.AsArraySegment().ElementAt(index);

        
        public static Option<TSource> First<TSource>(this List<TSource> source)
            => source.AsArraySegment().First();

        
        public static Option<TSource> Single<TSource>(this List<TSource> source)
            => source.AsArraySegment().Single();

        public static ArrayExtensions.ArraySegmentDistinctEnumerable<TSource> Distinct<TSource>(this List<TSource> source, IEqualityComparer<TSource>? comparer = default)
            => source.AsArraySegment().Distinct(comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> AsEnumerable<TSource>(this List<TSource> source)
            => source;

        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this List<TSource> source)
            => new ValueWrapper<TSource>(source);

        public static TSource[] ToArray<TSource>(this List<TSource> source)
        {
            var result = new TSource[source.Count];
            source.AsSpan().CopyTo(result);
            return result;
        }

        public static IMemoryOwner<TSource> ToArray<TSource>(this List<TSource> source, MemoryPool<TSource> pool)
            => ArrayExtensions.ToArray<TSource>(source.AsSpan(), pool);

        public static List<TSource> ToList<TSource>(this List<TSource> source)
            => new List<TSource>(source);

        
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this List<TSource> source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => source.AsArraySegment().ToDictionary(keySelector, comparer);
        
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this List<TSource> source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => source.AsArraySegment().ToDictionary(keySelector, elementSelector, comparer);

        public readonly partial struct ValueWrapper<TSource>
            : IValueReadOnlyList<TSource, List<TSource>.Enumerator>
            , IList<TSource>
        {
            readonly List<TSource> source;

            public ValueWrapper(List<TSource> source) 
                => this.source = source;

            public readonly int Count
                => source.Count;

            [MaybeNull]
            public readonly TSource this[int index] 
                => source[index];
            TSource IReadOnlyList<TSource>.this[int index]
                => source[index];
            TSource IList<TSource>.this[int index]
            {
                get => source[index];
                [ExcludeFromCodeCoverage]
                set => Throw.NotSupportedException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly List<TSource>.Enumerator GetEnumerator() 
                => source.GetEnumerator();
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                => source.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() 
                => source.GetEnumerator();

            bool ICollection<TSource>.IsReadOnly  
                => true;

            void ICollection<TSource>.CopyTo(TSource[] array, int arrayIndex) 
                => source.CopyTo(array, arrayIndex);

            bool ICollection<TSource>.Contains(TSource item)
                => source.Contains(item);

            int IList<TSource>.IndexOf(TSource item)
                => source.IndexOf(item);

            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Add(TSource item) 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void ICollection<TSource>.Clear() 
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            bool ICollection<TSource>.Remove(TSource item) 
                => Throw.NotSupportedException<bool>();

            [ExcludeFromCodeCoverage]
            void IList<TSource>.Insert(int index, TSource item)
                => Throw.NotSupportedException();
            [ExcludeFromCodeCoverage]
            void IList<TSource>.RemoveAt(int index)
                => Throw.NotSupportedException();
        }    
    }
}