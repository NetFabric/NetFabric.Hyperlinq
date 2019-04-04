using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class HashSetBindings
    {
        public static int Count<TSource>(this HashSet<TSource> source)
            => source.Count;

        public static int Count<TSource>(this HashSet<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.Count<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static bool All<TSource>(this HashSet<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.All<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static bool Any<TSource>(this HashSet<TSource> source)
            => source.Count != 0;

        public static bool Any<TSource>(this HashSet<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.Any<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static bool Contains<TSource>(this HashSet<TSource> source, TSource value)
            => source.Contains(value);

        public static bool Contains<TSource>(this HashSet<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => ReadOnlyCollection.Contains<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), value, comparer);

        public static ReadOnlyCollection.SelectEnumerable<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this HashSet<TSource> source,
            Func<TSource, TResult> selector) 
            => ReadOnlyCollection.Select<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);

        public static Enumerable.SelectManyEnumerable<ValueWrapper<TSource>,  HashSet<TSource>.Enumerator,  TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this HashSet<TSource> source,
            Func<TSource, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
            => Enumerable.SelectMany<ValueWrapper<TSource>,  HashSet<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TSource>(source), selector);

        public static Enumerable.WhereEnumerable<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource> Where<TSource>(
            this HashSet<TSource> source,
            Func<TSource, bool> predicate) 
            => Enumerable.Where<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource First<TSource, TValue>(this HashSet<TSource> source)
            => ReadOnlyCollection.First<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static TSource First<TSource, TValue>(this HashSet<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.First<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource FirstOrDefault<TSource, TValue>(this HashSet<TSource> source)
            => ReadOnlyCollection.FirstOrDefault<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static TSource FirstOrDefault<TSource, TValue>(this HashSet<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.FirstOrDefault<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource? FirstOrNull<TSource, TValue>(this HashSet<TSource> source)
            where TSource : struct
            => ReadOnlyCollection.FirstOrNull<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static TSource? FirstOrNull<TSource, TValue>(this HashSet<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
            => Enumerable.FirstOrNull<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource Single<TSource, TValue>(this HashSet<TSource> source)
            => ReadOnlyCollection.Single<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static TSource Single<TSource, TValue>(this HashSet<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.Single<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource SingleOrDefault<TSource, TValue>(this HashSet<TSource> source)
            => ReadOnlyCollection.SingleOrDefault<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static TSource SingleOrDefault<TSource, TValue>(this HashSet<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.SingleOrDefault<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource? SingleOrNull<TSource, TValue>(this HashSet<TSource> source)
            where TSource : struct
            => ReadOnlyCollection.SingleOrNull<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static TSource? SingleOrNull<TSource, TValue>(this HashSet<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
            => Enumerable.SingleOrNull<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static IEnumerable<TSource> AsEnumerable<TSource>(this HashSet<TSource> source)
            => source;

        public static IReadOnlyCollection<TSource> AsReadOnlyCollection<TSource>(this HashSet<TSource> source)
            => source;

        public static Enumerable.AsValueEnumerableEnumerable<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource> AsValueEnumerable<TSource>(this HashSet<TSource> source)
            => Enumerable.AsValueEnumerable<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static ReadOnlyCollection.AsValueReadOnlyCollectionEnumerable<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource> AsValueReadOnlyCollection<TSource>(this HashSet<TSource> source)
            => ReadOnlyCollection.AsValueReadOnlyCollection<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static TSource[] ToArray<TSource>(this HashSet<TSource> source)
            => ReadOnlyCollection.ToArray<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static List<TSource> ToList<TSource>(this HashSet<TSource> source)
            => ReadOnlyCollection.ToList<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public readonly struct ValueWrapper<TSource> : IReadOnlyCollection<TSource>
        {
            readonly HashSet<TSource> source;

            public ValueWrapper(HashSet<TSource> source)
            {
                this.source = source;
            }

            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => source.GetEnumerator();
            int IReadOnlyCollection<TSource>.Count => source.Count;
        }    
    }
}