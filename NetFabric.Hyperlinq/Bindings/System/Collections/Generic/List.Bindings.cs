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
            
        #endregion
        #region Partitioning

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Memory<TSource> Skip<TSource>(this List<TSource> source, int count)
            => source.AsMemory().Skip(count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Memory<TSource> Take<TSource>(this List<TSource> source, int count)
            => source.AsMemory().Take(count);
            
        #endregion
        #region Quantifier

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
            => source.AsMemory().All(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource, TPredicate>(this List<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, bool>
            => source.AsMemory().All(predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this List<TSource> source, Func<TSource, int, bool> predicate)
            => source.AsMemory().All(predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AllAt<TSource, TPredicate>(this List<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.AsMemory().AllAt(predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this List<TSource> source)
            => source.Count is not 0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
            => source.AsMemory().Any(predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource, TPredicate>(this List<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, bool>
            => source.AsMemory().Any(predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this List<TSource> source, Func<TSource, int, bool> predicate)
            => source.AsMemory().Any(predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AnyAt<TSource, TPredicate>(this List<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.AsMemory().AnyAt(predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TSource>(this List<TSource> source, TSource value, IEqualityComparer<TSource>? comparer = default)
            => source.AsMemory().Contains(value, comparer);
            
        #endregion
        #region Projection

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.MemorySelectEnumerable<TSource, TResult, FunctionWrapper<TSource, TResult>> Select<TSource, TResult>(this List<TSource> source, Func<TSource, TResult> selector)
            => source.AsMemory().Select(selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.MemorySelectEnumerable<TSource, TResult, TSelector> Select<TSource, TResult, TSelector>(this List<TSource> source, TSelector selector = default)
            where TSelector : struct, IFunction<TSource, TResult>
            => source.AsMemory().Select<TSource, TResult, TSelector>(selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult, FunctionWrapper<TSource, int, TResult>> Select<TSource, TResult>(this List<TSource> source, Func<TSource, int, TResult> selector)
            => source.AsMemory().Select(selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult, TSelector> SelectAt<TSource, TResult, TSelector>(this List<TSource> source, TSelector selector = default)
            where TSelector : struct, IFunction<TSource, int, TResult>
            => source.AsMemory().SelectAt<TSource, TResult, TSelector>(selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.MemorySelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<TSource, TSubEnumerable>> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this List<TSource> source,
            Func<TSource, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => source.AsMemory().SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(selector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.MemorySelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(
            this List<TSource> source,
            TSelector selector = default)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TSelector : struct, IFunction<TSource, TSubEnumerable>
            => source.AsMemory().SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult, TSelector>(selector);
            
        #endregion
        #region Filtering
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.MemoryWhereEnumerable<TSource, FunctionWrapper<TSource, bool>> Where<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
            => source.AsMemory().Where(predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.MemoryWhereEnumerable<TSource, TPredicate> Where<TSource, TPredicate>(this List<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, bool>
            => source.AsMemory().Where(predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.MemoryWhereAtEnumerable<TSource, FunctionWrapper<TSource, int, bool>> Where<TSource>(this List<TSource> source, Func<TSource, int, bool> predicate)
            => source.AsMemory().Where(predicate);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.MemoryWhereAtEnumerable<TSource, TPredicate> WhereAt<TSource, TPredicate>(this List<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => source.AsMemory().WhereAt(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.MemoryWhereRefEnumerable<TSource, FunctionInWrapper<TSource, bool>> Where<TSource>(this List<TSource> source, FunctionIn<TSource, bool> predicate)
            => source.AsMemory().Where(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.MemoryWhereRefEnumerable<TSource, TPredicate> WhereRef<TSource, TPredicate>(this List<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            => source.AsMemory().WhereRef(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.MemoryWhereAtRefEnumerable<TSource, FunctionInWrapper<TSource, int, bool>> Where<TSource>(this List<TSource> source, FunctionIn<TSource, int, bool> predicate)
            => source.AsMemory().Where(predicate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.MemoryWhereAtRefEnumerable<TSource, TPredicate> WhereAtRef<TSource, TPredicate>(this List<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
            => source.AsMemory().WhereAtRef(predicate);
            
        #endregion
        #region Element

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> ElementAt<TSource>(this List<TSource> source, int index)
            => source.AsMemory().ElementAt(index);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> First<TSource>(this List<TSource> source)
            => source.AsMemory().First();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> Single<TSource>(this List<TSource> source)
            => source.AsMemory().Single();
            
        #endregion
        #region Set

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArrayExtensions.MemoryDistinctEnumerable<TSource> Distinct<TSource>(this List<TSource> source, IEqualityComparer<TSource>? comparer = default)
            => source.AsMemory().Distinct(comparer);
            
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
            source.AsMemory().CopyTo(result);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IMemoryOwner<TSource> ToArray<TSource>(this List<TSource> source, MemoryPool<TSource> pool)
            => ArrayExtensions.ToArray(source.AsMemory(), pool);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> ToList<TSource>(this List<TSource> source)
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            => new(source);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this List<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => source.AsMemory().ToDictionary(keySelector, comparer);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey, TKeySelector>(this List<TSource> source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            => source.AsMemory().ToDictionary(keySelector, comparer);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this List<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => source.AsMemory().ToDictionary(keySelector, elementSelector, comparer);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector>(this List<TSource> source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            where TKeySelector : struct, IFunction<TSource, TKey>
            where TElementSelector : struct, IFunction<TSource, TElement>
            => source.AsMemory().ToDictionary<TSource, TKey, TElement, TKeySelector, TElementSelector>(keySelector, elementSelector, comparer);
            
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