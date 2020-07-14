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

        public static ReadOnlyMemory<TSource> Skip<TSource>(this List<TSource> source, int count)
            => source.Unwrap().Skip(count);

        public static ReadOnlyMemory<TSource> Take<TSource>(this List<TSource> source, int count)
            => source.Unwrap().Take(count);

        public static bool All<TSource>(this List<TSource> source, Predicate<TSource> predicate)
            => source.Unwrap().All(predicate);
        
        public static bool All<TSource>(this List<TSource> source, PredicateAt<TSource> predicate)
            => source.Unwrap().All(predicate);

        
        public static bool Any<TSource>(this List<TSource> source)
            => source.Count != 0;
        
        public static bool Any<TSource>(this List<TSource> source, Predicate<TSource> predicate)
            => source.Unwrap().Any(predicate);
        
        public static bool Any<TSource>(this List<TSource> source, PredicateAt<TSource> predicate)
            => source.Unwrap().Any(predicate);
        
        public static bool Contains<TSource>(this List<TSource> source, [AllowNull] TSource value, IEqualityComparer<TSource>? comparer = default)
            => source.Unwrap().Contains(value, comparer);

        public static ArrayExtensions.MemorySelectEnumerable<TSource, TResult> Select<TSource, TResult>(
            this List<TSource> source,
            NullableSelector<TSource, TResult> selector)
            => source.Unwrap().Select(selector);

        public static ArrayExtensions.MemorySelectAtEnumerable<TSource, TResult> Select<TSource, TResult>(
            this List<TSource> source,
            NullableSelectorAt<TSource, TResult> selector)
            => source.Unwrap().Select(selector);

        public static ArrayExtensions.MemorySelectManyEnumerable<TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this List<TSource> source,
            Selector<TSource, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => source.Unwrap().SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(selector);
        
        public static ArrayExtensions.MemoryWhereEnumerable<TSource> Where<TSource>(
            this List<TSource> source,
            Predicate<TSource> predicate)
            => source.Unwrap().Where(predicate);
        
        public static ArrayExtensions.MemoryWhereAtEnumerable<TSource> Where<TSource>(
            this List<TSource> source,
            PredicateAt<TSource> predicate)
            => source.Unwrap().Where(predicate);
        
        public static ArrayExtensions.MemoryWhereRefEnumerable<TSource> WhereRef<TSource>(
            this List<TSource> source,
            Predicate<TSource> predicate)
            => source.Unwrap().WhereRef(predicate);
        
        public static ArrayExtensions.MemoryWhereRefAtEnumerable<TSource> WhereRef<TSource>(
            this List<TSource> source,
            PredicateAt<TSource> predicate)
            => source.Unwrap().WhereRef(predicate);

        public static Option<TSource> ElementAt<TSource>(this List<TSource> source, int index)
            => source.Unwrap().ElementAt(index);

        
        public static Option<TSource> First<TSource>(this List<TSource> source)
            => source.Unwrap().First();

        
        public static Option<TSource> Single<TSource>(this List<TSource> source)
            => source.Unwrap().Single();

        public static ArrayExtensions.MemoryDistinctEnumerable<TSource> Distinct<TSource>(this List<TSource> source, IEqualityComparer<TSource>? comparer = default)
            => source.Unwrap().Distinct(comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<TSource> AsEnumerable<TSource>(this List<TSource> source)
            => source;

        
        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this List<TSource> source)
            => new ValueWrapper<TSource>(source);


        public static TSource[] ToArray<TSource>(this List<TSource> source)
        {
            var array = new TSource[source.Count];
            Array.Copy(source.GetItems(), 0, array, 0, source.Count);
            return array;
        }

        public static IMemoryOwner<TSource> ToArray<TSource>(this List<TSource> source, MemoryPool<TSource> pool)
        {
            var result = pool.RentSliced(source.Count);
            ArrayExtensions.Copy(source.GetItems(), result.Memory.Span);
            return result;
        }

        public static List<TSource> ToList<TSource>(this List<TSource> source)
            => new List<TSource>(source);

        
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this List<TSource> source, NullableSelector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
            => source.Unwrap().ToDictionary(keySelector, comparer);
        
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this List<TSource> source, NullableSelector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
            => source.Unwrap().ToDictionary(keySelector, elementSelector, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Memory<TSource> Unwrap<TSource>(this List<TSource> source)
            => source.GetItems().AsMemory().Slice(0, source.Count);

        class ListLayout<TSource>
        {
            public TSource[] Items = default!;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TSource[] GetItems<TSource>(this List<TSource> source)
            => Unsafe.As<List<TSource>, ListLayout<TSource>>(ref source).Items;

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