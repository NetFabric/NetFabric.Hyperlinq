using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    [GeneratorIgnore]
    public static partial class ImmutableQueueBindings
    {
        
        public static int Count<TSource>(this ImmutableQueue<TSource> source)
            => ValueEnumerableExtensions.Count<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        
        public static ValueEnumerableExtensions.SkipEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource> Skip<TSource>(this ImmutableQueue<TSource> source, int count)
            => ValueEnumerableExtensions.Skip<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        
        public static ValueEnumerableExtensions.TakeEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource> Take<TSource>(this ImmutableQueue<TSource> source, int count)
            => ValueEnumerableExtensions.Take<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        
        public static bool All<TSource>(this ImmutableQueue<TSource> source, Predicate<TSource> predicate)
            => ValueEnumerableExtensions.All<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        
        public static bool All<TSource>(this ImmutableQueue<TSource> source, PredicateAt<TSource> predicate)
            => ValueEnumerableExtensions.All<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        
        public static bool Any<TSource>(this ImmutableQueue<TSource> source)
            => ValueEnumerableExtensions.Any<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        
        public static bool Contains<TSource>(this ImmutableQueue<TSource> source, [AllowNull] TSource value)
            => source.Contains(value);
        
        public static bool Contains<TSource>(this ImmutableQueue<TSource> source, [AllowNull] TSource value, IEqualityComparer<TSource>? comparer)
            => ValueEnumerableExtensions.Contains<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), value, comparer);

        
        public static ValueEnumerableExtensions.SelectEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this ImmutableQueue<TSource> source,
            NullableSelector<TSource, TResult> selector)
            => ValueEnumerableExtensions.Select<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);
        
        public static ValueEnumerableExtensions.SelectAtEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this ImmutableQueue<TSource> source,
            NullableSelectorAt<TSource, TResult> selector)
            => ValueEnumerableExtensions.Select<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);

        
        public static ValueEnumerableExtensions.SelectManyEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this ImmutableQueue<TSource> source,
            Selector<TSource, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueEnumerableExtensions.SelectMany<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TSource>(source), selector);

        
        public static ValueEnumerableExtensions.WhereEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, ValuePredicate<TSource>> Where<TSource>(
            this ImmutableQueue<TSource> source,
            Predicate<TSource> predicate)
            => ValueEnumerableExtensions.Where<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        
        public static ValueEnumerableExtensions.WhereAtEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, ValuePredicateAt<TSource>> Where<TSource>(
            this ImmutableQueue<TSource> source,
            PredicateAt<TSource> predicate)
            => ValueEnumerableExtensions.Where<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        
        public static Option<TSource> ElementAt<TSource>(this ImmutableQueue<TSource> source, int index)
            => ValueEnumerableExtensions.ElementAt<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), index);

        
        public static Option<TSource> First<TSource>(this ImmutableQueue<TSource> source)
            => ValueEnumerableExtensions.First<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        
        public static Option<TSource> Single<TSource>(this ImmutableQueue<TSource> source)
            => ValueEnumerableExtensions.Single<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        
        public static ValueEnumerableExtensions.DistinctEnumerable<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource> Distinct<TSource>(this ImmutableQueue<TSource> source, IEqualityComparer<TSource>? comparer = null)
            => ValueEnumerableExtensions.Distinct<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), comparer);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ImmutableQueue<TSource> AsEnumerable<TSource>(this ImmutableQueue<TSource> source)
            => source;

        
        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this ImmutableQueue<TSource> source)
            => new ValueWrapper<TSource>(source);

        
        public static TSource[] ToArray<TSource>(this ImmutableQueue<TSource> source)
            => ValueEnumerableExtensions.ToArray<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        
        public static List<TSource> ToList<TSource>(this ImmutableQueue<TSource> source)
            => new List<TSource>(source);

        
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this ImmutableQueue<TSource> source, Selector<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => ValueEnumerableExtensions.ToDictionary<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TKey>(new ValueWrapper<TSource>(source), keySelector, comparer);
        
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this ImmutableQueue<TSource> source, Selector<TSource, TKey> keySelector, NullableSelector<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer = default)
            where TKey : notnull
            => ValueEnumerableExtensions.ToDictionary<ValueWrapper<TSource>, ValueWrapper<TSource>.Enumerator, TSource, TKey, TElement>(new ValueWrapper<TSource>(source), keySelector, elementSelector, comparer);

        public readonly partial struct ValueWrapper<TSource>
            : IValueEnumerable<TSource, ValueWrapper<TSource>.Enumerator>
        {
            readonly ImmutableQueue<TSource> source;

            public ValueWrapper(ImmutableQueue<TSource> source) 
                => this.source = source;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(source);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(source);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(source);

            public struct Enumerator
                : IEnumerator<TSource>
            {
                ImmutableQueue<TSource>.Enumerator enumerator;

                internal Enumerator(ImmutableQueue<TSource> enumerable) 
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
    }
}