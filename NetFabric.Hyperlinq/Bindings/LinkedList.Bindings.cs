using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class LinkedListBindings
    {
        public static int Count<TSource>(this LinkedList<TSource> source)
            => source.Count;

        public static int Count<TSource>(this LinkedList<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyCollection.Count<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static ReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource> Skip<TSource>(this LinkedList<TSource> source, int count)
            => ReadOnlyCollection.Skip<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        public static ReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource> Take<TSource>(this LinkedList<TSource> source, int count)
            => ReadOnlyCollection.Take<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        public static bool All<TSource>(this LinkedList<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyCollection.All<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static bool Any<TSource>(this LinkedList<TSource> source)
            => source.Count != 0;

        public static bool Any<TSource>(this LinkedList<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyCollection.Any<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static bool Contains<TSource>(this LinkedList<TSource> source, TSource value)
            => source.Contains(value);

        public static bool Contains<TSource>(this LinkedList<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => ReadOnlyCollection.Contains<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), value, comparer);

        public static ReadOnlyCollection.SelectEnumerable<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this LinkedList<TSource> source,
            Func<TSource, int, TResult> selector) 
            => ReadOnlyCollection.Select<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);

        public static Enumerable.SelectManyEnumerable<ValueWrapper<TSource>,  LinkedList<TSource>.Enumerator,  TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this LinkedList<TSource> source,
            Func<TSource, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IValueEnumerator<TResult>
            => Enumerable.SelectMany<ValueWrapper<TSource>,  LinkedList<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TSource>(source), selector);

        public static Enumerable.WhereEnumerable<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource> Where<TSource>(
            this LinkedList<TSource> source,
            Func<TSource, int, bool> predicate) 
            => Enumerable.Where<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource First<TSource, TValue>(this LinkedList<TSource> source)
            => ReadOnlyCollection.First<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static TSource First<TSource, TValue>(this LinkedList<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyCollection.First<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource FirstOrDefault<TSource, TValue>(this LinkedList<TSource> source)
            => ReadOnlyCollection.FirstOrDefault<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static TSource FirstOrDefault<TSource, TValue>(this LinkedList<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyCollection.FirstOrDefault<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource? FirstOrNull<TSource, TValue>(this LinkedList<TSource> source)
            where TSource : struct
            => ReadOnlyCollection.FirstOrNull<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static TSource? FirstOrNull<TSource, TValue>(this LinkedList<TSource> source, Func<TSource, int, bool> predicate)
            where TSource : struct
            => ReadOnlyCollection.FirstOrNull<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource Single<TSource, TValue>(this LinkedList<TSource> source)
            => ReadOnlyCollection.Single<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static TSource Single<TSource, TValue>(this LinkedList<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyCollection.Single<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource SingleOrDefault<TSource, TValue>(this LinkedList<TSource> source)
            => ReadOnlyCollection.SingleOrDefault<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static TSource SingleOrDefault<TSource, TValue>(this LinkedList<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyCollection.SingleOrDefault<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource? SingleOrNull<TSource, TValue>(this LinkedList<TSource> source)
            where TSource : struct
            => ReadOnlyCollection.SingleOrNull<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static TSource? SingleOrNull<TSource, TValue>(this LinkedList<TSource> source, Func<TSource, int, bool> predicate)
            where TSource : struct
            => ReadOnlyCollection.SingleOrNull<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static IReadOnlyCollection<TSource> AsEnumerable<TSource>(this LinkedList<TSource> source)
            => source;

        public static ReadOnlyCollection.AsValueEnumerableEnumerable<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource> AsValueEnumerable<TSource>(this LinkedList<TSource> source)
            => ReadOnlyCollection.AsValueEnumerable<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static TSource[] ToArray<TSource>(this LinkedList<TSource> source)
            => ReadOnlyCollection.ToArray<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static List<TSource> ToList<TSource>(this LinkedList<TSource> source)
            => ReadOnlyCollection.ToList<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public readonly struct ValueWrapper<TSource> : IReadOnlyCollection<TSource>
        {
            readonly LinkedList<TSource> source;

            public ValueWrapper(LinkedList<TSource> source)
            {
                this.source = source;
            }

            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => source.GetEnumerator();
            int IReadOnlyCollection<TSource>.Count => source.Count;
        }    
    }
}