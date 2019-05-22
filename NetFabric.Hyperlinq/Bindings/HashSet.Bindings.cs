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
        public static int Count<TSource>(this HashSet<TSource> source, Func<TSource, long, bool> predicate)
            => ReadOnlyCollection.Count<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static ReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource> Skip<TSource>(this HashSet<TSource> source, int count)
            => ReadOnlyCollection.Skip<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        public static ReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource> Take<TSource>(this HashSet<TSource> source, int count)
            => ReadOnlyCollection.Take<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        public static bool All<TSource>(this HashSet<TSource> source, Func<TSource, long, bool> predicate)
            => ReadOnlyCollection.All<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static bool Any<TSource>(this HashSet<TSource> source)
            => source.Count != 0;

        public static bool Any<TSource>(this HashSet<TSource> source, Func<TSource, long, bool> predicate)
            => ReadOnlyCollection.Any<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static bool Contains<TSource>(this HashSet<TSource> source, TSource value)
            => source.Contains(value);

        public static bool Contains<TSource>(this HashSet<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => ReadOnlyCollection.Contains<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), value, comparer);

        public static ReadOnlyCollection.SelectEnumerable<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this HashSet<TSource> source,
            Func<TSource, TResult> selector) 
            => ReadOnlyCollection.Select<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);
        public static ReadOnlyCollection.SelectIndexEnumerable<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this HashSet<TSource> source,
            Func<TSource, long, TResult> selector)
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
        public static Enumerable.WhereIndexEnumerable<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource> Where<TSource>(
            this HashSet<TSource> source,
            Func<TSource, long, bool> predicate)
            => Enumerable.Where<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource First<TSource>(this HashSet<TSource> source) 
            => ReadOnlyCollection.First<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static TSource First<TSource>(this HashSet<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.First<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static TSource FirstOrDefault<TSource>(this HashSet<TSource> source)
            => ReadOnlyCollection.FirstOrDefault<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static TSource FirstOrDefault<TSource>(this HashSet<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.FirstOrDefault<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static (ElementResult Success, TSource Value) TryFirst<TSource>(this HashSet<TSource> source)
            => ReadOnlyCollection.TryFirst<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static (ElementResult Success, TSource Value) TryFirst<TSource>(this HashSet<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.TryFirst<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static (int Index, TSource Value) TryFirst<TSource>(this HashSet<TSource> source, Func<TSource, long, bool> predicate)
            => ReadOnlyCollection.TryFirst<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource Single<TSource>(this HashSet<TSource> source) 
            => ReadOnlyCollection.Single<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static TSource Single<TSource>(this HashSet<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.Single<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static TSource SingleOrDefault<TSource>(this HashSet<TSource> source)
            => ReadOnlyCollection.SingleOrDefault<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static TSource SingleOrDefault<TSource>(this HashSet<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.SingleOrDefault<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static (ElementResult Success, TSource Value) TrySingle<TSource>(this HashSet<TSource> source)
            => ReadOnlyCollection.TrySingle<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static (ElementResult Success, TSource Value) TrySingle<TSource>(this HashSet<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.TrySingle<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static (int Index, TSource Value) TrySingle<TSource>(this HashSet<TSource> source, Func<TSource, long, bool> predicate)
            => ReadOnlyCollection.TrySingle<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static IReadOnlyCollection<TSource> AsEnumerable<TSource>(this HashSet<TSource> source)
            => source;

        public static ReadOnlyCollection.AsValueEnumerableEnumerable<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource> AsValueEnumerable<TSource>(this HashSet<TSource> source)
            => ReadOnlyCollection.AsValueEnumerable<ValueWrapper<TSource>, HashSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

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