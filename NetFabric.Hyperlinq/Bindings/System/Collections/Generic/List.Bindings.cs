using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ListBindings
    {
        #region Aggregation
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this List<TSource> source)
            => source.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this List<int> source)
            => source.AsSpan().Sum();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sum(this List<int?> source)
            => source.AsSpan().Sum();

        #endregion
        #region Partitioning

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegment<TSource> Skip<TSource>(this List<TSource> source, int count)
            => source.AsArraySegment().Skip(count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegment<TSource> Take<TSource>(this List<TSource> source, int count)
            => source.AsArraySegment().Take(count);
            
        #endregion
        #region Quantifier

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
            => source.AsSpan().All(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource, TPredicate>(this List<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, bool>
            => source.AsSpan().All(predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this List<TSource> source, Func<TSource, int, bool> predicate)
            => source.AsSpan().All(predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AllAt<TSource, TPredicate>(this List<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.AsSpan().AllAt(predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this List<TSource> source)
            => source.Count is not 0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
            => source.AsSpan().Any(predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource, TPredicate>(this List<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, bool>
            => source.AsSpan().Any(predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this List<TSource> source, Func<TSource, int, bool> predicate)
            => source.AsSpan().Any(predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AnyAt<TSource, TPredicate>(this List<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.AsSpan().AnyAt(predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TSource>(this List<TSource> source, TSource value, IEqualityComparer<TSource>? comparer = default)
            => source.AsSpan().Contains(value, comparer);
            
        #endregion
        #region Projection

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.ArraySegmentSelectEnumerable<TSource, TResult, FunctionWrapper<TSource, TResult>> Select<TSource, TResult>(this List<TSource> source, Func<TSource, TResult> selector)
            => source.AsArraySegment().Select(selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.ArraySegmentSelectEnumerable<TSource, TResult, TSelector> Select<TSource, TResult, TSelector>(this List<TSource> source, TSelector selector = default)
            where TSelector : struct, IFunction<TSource, TResult>
            => source.AsArraySegment().Select<TSource, TResult, TSelector>(selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.ArraySegmentSelectAtEnumerable<TSource, TResult, FunctionWrapper<TSource, int, TResult>> Select<TSource, TResult>(this List<TSource> source, Func<TSource, int, TResult> selector)
            => source.AsArraySegment().Select(selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.ArraySegmentSelectAtEnumerable<TSource, TResult, TSelector> SelectAt<TSource, TResult, TSelector>(this List<TSource> source, TSelector selector = default)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source.AsArraySegment().SelectAt<TSource, TResult, TSelector>(selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.ArraySegmentSelectRefEnumerable<TSource, TResult, FunctionInWrapper<TSource, TResult>> Select<TSource, TResult>(this List<TSource> source, FunctionIn<TSource, TResult> selector)
            => source.AsArraySegment().Select(selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.ArraySegmentSelectRefEnumerable<TSource, TResult, TSelector> SelectRef<TSource, TResult, TSelector>(this List<TSource> source, TSelector selector = default)
            where TSelector : struct, IFunctionIn<TSource, TResult>
            => source.AsArraySegment().SelectRef<TSource, TResult, TSelector>(selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.ArraySegmentSelectAtRefEnumerable<TSource, TResult, FunctionInWrapper<TSource, int, TResult>> Select<TSource, TResult>(this List<TSource> source, FunctionIn<TSource, int, TResult> selector)
            => source.AsArraySegment().Select(selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.ArraySegmentSelectAtRefEnumerable<TSource, TResult, TSelector> SelectAtRef<TSource, TResult, TSelector>(this List<TSource> source, TSelector selector = default)
            where TSelector : struct, IFunctionIn<TSource, int, TResult>
            => source.AsArraySegment().SelectAtRef<TSource, TResult, TSelector>(selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<TSource, TSubEnumerable>> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this List<TSource> source,
            Func<TSource, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => source.AsArraySegment().SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.ArraySegmentSelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(
            this List<TSource> source,
            TSelector selector = default)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.AsArraySegment().SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(selector);
            
        #endregion
        #region Filtering
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.ArraySegmentWhereEnumerable<TSource, FunctionWrapper<TSource, bool>> Where<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
            => source.AsArraySegment().Where(predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.ArraySegmentWhereEnumerable<TSource, TPredicate> Where<TSource, TPredicate>(this List<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, bool>
            => source.AsArraySegment().Where(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.ArraySegmentWhereAtEnumerable<TSource, FunctionWrapper<TSource, int, bool>> Where<TSource>(this List<TSource> source, Func<TSource, int, bool> predicate)
            => source.AsArraySegment().Where(predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.ArraySegmentWhereAtEnumerable<TSource, TPredicate> WhereAt<TSource, TPredicate>(this List<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.AsArraySegment().WhereAt(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.ArraySegmentWhereRefEnumerable<TSource, FunctionInWrapper<TSource, bool>> Where<TSource>(this List<TSource> source, FunctionIn<TSource, bool> predicate)
            => source.AsArraySegment().Where(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.ArraySegmentWhereRefEnumerable<TSource, TPredicate> WhereRef<TSource, TPredicate>(this List<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            => source.AsArraySegment().WhereRef(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.ArraySegmentWhereAtRefEnumerable<TSource, FunctionInWrapper<TSource, int, bool>> Where<TSource>(this List<TSource> source, FunctionIn<TSource, int, bool> predicate)
            => source.AsArraySegment().Where(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.ArraySegmentWhereAtRefEnumerable<TSource, TPredicate> WhereAtRef<TSource, TPredicate>(this List<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
            => source.AsArraySegment().WhereAtRef(predicate);
            
        #endregion
        #region Element

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> ElementAt<TSource>(this List<TSource> source, int index)
            => source.AsSpan().ElementAt(index);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> First<TSource>(this List<TSource> source)
            => source.AsSpan().First();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> Single<TSource>(this List<TSource> source)
            => source.AsSpan().Single();
            
        #endregion
        #region Set

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.ArraySegmentDistinctEnumerable<TSource> Distinct<TSource>(this List<TSource> source, IEqualityComparer<TSource>? comparer = default)
            => source.AsArraySegment().Distinct(comparer);
            
        #endregion
        #region Conversion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> AsEnumerable<TSource>(this List<TSource> source)
            => source;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this List<TSource> source)
            => new(source);

        public static TSource[] ToArray<TSource>(this List<TSource> source)
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var result = new TSource[source.Count];
            source.AsSpan().CopyTo(result);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TSource>(this List<TSource> source, MemoryPool<TSource> pool)
            => ArrayExtensions.ToArray(source.AsSpan(), pool);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this List<TSource> source)
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            => new(source);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this List<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => source.AsSpan().ToDictionary(keySelector, comparer);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey, TKeySelector>(this List<TSource> source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            => source.AsSpan().ToDictionary(keySelector, comparer);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this List<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => source.AsSpan().ToDictionary(keySelector, elementSelector, comparer);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector>(this List<TSource> source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TElementSelector : struct, IFunction<TSource, TElement>
            => source.AsSpan().ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector>(keySelector, elementSelector, comparer);
            
        #endregion

        public readonly partial struct ValueWrapper<TSource>
            : IValueReadOnlyList<TSource, List<TSource>.Enumerator>
            , IList<TSource>
        {
            readonly List<TSource> source;

            public ValueWrapper(List<TSource> source) 
                => this.source = source;

            public readonly int Count
                => source.Count;

            public readonly TSource this[int index] 
                => source[index];
            TSource IReadOnlyList<TSource>.this[int index]
                => source[index];
            TSource IList<TSource>.this[int index]
            {
                get => source[index];
                
                [ExcludeFromCodeCoverage]
                // ReSharper disable once ValueParameterNotUsed
                set => Throw.NotSupportedException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly List<TSource>.Enumerator GetEnumerator() 
                => source.GetEnumerator();
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => source.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
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