using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    [GeneratorIgnore]
    public static partial class ImmutableArrayBindings
    {
        
        public static int Count<TSource>(this ImmutableArray<TSource> source)
            => source.Length;

        
        public static ReadOnlyListExtensions.SkipTakeEnumerable<ImmutableArray<TSource>, TSource> Skip<TSource>(this ImmutableArray<TSource> source, int count)
            => ReadOnlyListExtensions.Skip<ImmutableArray<TSource>, TSource>(source, count);

        
        public static ReadOnlyListExtensions.SkipTakeEnumerable<ImmutableArray<TSource>, TSource> Take<TSource>(this ImmutableArray<TSource> source, int count)
            => ReadOnlyListExtensions.Take<ImmutableArray<TSource>, TSource>(source, count);

        
        public static bool All<TSource>(this ImmutableArray<TSource> source, PredicateAt<TSource> predicate)
            => ReadOnlyListExtensions.All<ImmutableArray<TSource>, TSource>(source, predicate);

        
        public static bool Any<TSource>(this ImmutableArray<TSource> source)
            => ReadOnlyListExtensions.Any<ImmutableArray<TSource>, TSource>(source);

        
        public static bool Contains<TSource>(this ImmutableArray<TSource> source, [AllowNull] TSource value)
            => source.Contains(value);
        
        public static bool Contains<TSource>(this ImmutableArray<TSource> source, [AllowNull] TSource value, IEqualityComparer<TSource>? comparer)
            => ReadOnlyListExtensions.Contains<ImmutableArray<TSource>, TSource>(source, value, comparer);

        
        public static ReadOnlyListExtensions.SelectEnumerable<ImmutableArray<TSource>, TSource, TResult> SelectHyper<TSource, TResult>(
            this ImmutableArray<TSource> source,
            NullableSelector<TSource, TResult> selector)
            => ReadOnlyListExtensions.Select<ImmutableArray<TSource>, TSource, TResult>(source, selector);
        
        public static ReadOnlyListExtensions.SelectAtEnumerable<ImmutableArray<TSource>, TSource, TResult> SelectHyper<TSource, TResult>(
            this ImmutableArray<TSource> source,
            NullableSelectorAt<TSource, TResult> selector)
            => ReadOnlyListExtensions.Select<ImmutableArray<TSource>, TSource, TResult>(source, selector);

        
        public static ReadOnlyListExtensions.SelectManyEnumerable<ImmutableArray<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this ImmutableArray<TSource> source,
            Selector<TSource, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ReadOnlyListExtensions.SelectMany<ImmutableArray<TSource>, TSource, TSubEnumerable, TSubEnumerator, TResult>(source, selector);

        
        public static ReadOnlyListExtensions.WhereEnumerable<ImmutableArray<TSource>, TSource, ValuePredicate<TSource>> WhereHyper<TSource>(
            this ImmutableArray<TSource> source,
            Predicate<TSource> predicate)
            => ReadOnlyListExtensions.Where<ImmutableArray<TSource>, TSource>(source, predicate);
        
        public static ReadOnlyListExtensions.WhereAtEnumerable<ImmutableArray<TSource>, TSource, ValuePredicateAt<TSource>> WhereHyper<TSource>(
            this ImmutableArray<TSource> source,
            PredicateAt<TSource> predicate)
            => ReadOnlyListExtensions.Where<ImmutableArray<TSource>, TSource>(source, predicate);

        
        public static Option<TSource> ElementAt<TSource>(this ImmutableArray<TSource> source, int index)
            => ReadOnlyListExtensions.ElementAt<ImmutableArray<TSource>, TSource>(source, index);

        
        public static Option<TSource> First<TSource>(this ImmutableArray<TSource> source)
            => ReadOnlyListExtensions.First<ImmutableArray<TSource>, TSource>(source);

        
        public static Option<TSource> Single<TSource>(this ImmutableArray<TSource> source)
            => ReadOnlyListExtensions.Single<ImmutableArray<TSource>, TSource>(source);

        
        public static ReadOnlyListExtensions.DistinctEnumerable<ImmutableArray<TSource>, TSource> Distinct<TSource>(this ImmutableArray<TSource> source, IEqualityComparer<TSource>? comparer = null)
            => ReadOnlyListExtensions.Distinct<ImmutableArray<TSource>, TSource>(source, comparer);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ImmutableArray<TSource> AsEnumerable<TSource>(this ImmutableArray<TSource> source)
            => source;

        
        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this ImmutableArray<TSource> source)
            => new ValueWrapper<TSource>(source);

        public readonly partial struct ValueWrapper<TSource>
            : IValueReadOnlyList<TSource, ValueWrapper<TSource>.Enumerator>
            , IList<TSource>
        {
            readonly ImmutableArray<TSource> source;

            public ValueWrapper(ImmutableArray<TSource> source) 
                => this.source = source;

            public int Count
                => source.Length;

            [MaybeNull]
            public TSource this[int index]
                => source[index];
            TSource IReadOnlyList<TSource>.this[int index]
                => source[index];
            TSource IList<TSource>.this[int index]
            {
                get => source[index];
                set => throw new NotSupportedException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(source);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(source);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(source);

            bool ICollection<TSource>.IsReadOnly  
                => true;

            void ICollection<TSource>.CopyTo(TSource[] array, int arrayIndex) 
                => source.CopyTo(array, arrayIndex);
            void ICollection<TSource>.Add(TSource item) 
                => throw new NotSupportedException();
            void ICollection<TSource>.Clear() 
                => throw new NotSupportedException();
            bool ICollection<TSource>.Contains(TSource item) 
                => source.Contains(item);
            bool ICollection<TSource>.Remove(TSource item) 
                => throw new NotSupportedException();
            int IList<TSource>.IndexOf(TSource item)
                => source.IndexOf(item);
            void IList<TSource>.Insert(int index, TSource item)
                => throw new NotSupportedException();
            void IList<TSource>.RemoveAt(int index)
                => throw new NotSupportedException();

            public struct Enumerator
                : IEnumerator<TSource>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                ImmutableArray<TSource>.Enumerator enumerator; // do not make readonly

                internal Enumerator(ImmutableArray<TSource> enumerable) 
                    => enumerator = enumerable.GetEnumerator();

                [MaybeNull]
                public readonly TSource Current 
                    => enumerator.Current;
                readonly TSource IEnumerator<TSource>.Current 
                    => enumerator.Current;
                readonly object? IEnumerator.Current
                    => enumerator.Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly bool MoveNext() 
                    => enumerator.MoveNext();

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => throw new NotSupportedException();

                public readonly void Dispose() { }
            }
        }

        public static int Count<TSource>(this ValueWrapper<TSource> source)
            => source.Count;
    }
}