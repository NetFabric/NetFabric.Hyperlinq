using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class QueueBindings
    {
        public static int Count<TSource>(this Queue<TSource> source)
            => source.Count;
        public static int Count<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.Count<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static int Count<TSource>(this Queue<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyCollection.Count<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static ReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource> Skip<TSource>(this Queue<TSource> source, int count)
            => ReadOnlyCollection.Skip<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        public static ReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource> Take<TSource>(this Queue<TSource> source, int count)
            => ReadOnlyCollection.Take<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        public static bool All<TSource>(this Queue<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyCollection.All<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static bool Any<TSource>(this Queue<TSource> source)
            => source.Count != 0;

        public static bool Any<TSource>(this Queue<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyCollection.Any<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static bool Contains<TSource>(this Queue<TSource> source, TSource value)
            => source.Contains(value);

        public static bool Contains<TSource>(this Queue<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => ReadOnlyCollection.Contains<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), value, comparer);

        public static ReadOnlyCollection.SelectEnumerable<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this Queue<TSource> source,
            Func<TSource, TResult> selector) 
            => ReadOnlyCollection.Select<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);
        public static ReadOnlyCollection.SelectIndexEnumerable<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this Queue<TSource> source,
            Func<TSource, int, TResult> selector)
            => ReadOnlyCollection.Select<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);

        public static Enumerable.SelectManyEnumerable<ValueWrapper<TSource>,  Queue<TSource>.Enumerator,  TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this Queue<TSource> source,
            Func<TSource, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => Enumerable.SelectMany<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TSource>(source), selector);

        public static Enumerable.WhereEnumerable<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource> Where<TSource>(
            this Queue<TSource> source,
            Func<TSource, bool> predicate) 
            => Enumerable.Where<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static Enumerable.WhereIndexEnumerable<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource> Where<TSource>(
            this Queue<TSource> source,
            Func<TSource, int, bool> predicate)
            => Enumerable.Where<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource First<TSource>(this Queue<TSource> source) 
            => ReadOnlyCollection.First<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static TSource First<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.First<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static TSource FirstOrDefault<TSource>(this Queue<TSource> source)
            => ReadOnlyCollection.FirstOrDefault<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static TSource FirstOrDefault<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.FirstOrDefault<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static (ElementResult Success, TSource Value) TryFirst<TSource>(this Queue<TSource> source)
            => ReadOnlyCollection.TryFirst<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static (ElementResult Success, TSource Value) TryFirst<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.TryFirst<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static (int Index, TSource Value) TryFirst<TSource>(this Queue<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyCollection.TryFirst<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource Single<TSource>(this Queue<TSource> source) 
            => ReadOnlyCollection.Single<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static TSource Single<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.Single<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static TSource SingleOrDefault<TSource>(this Queue<TSource> source)
            => ReadOnlyCollection.SingleOrDefault<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static TSource SingleOrDefault<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.SingleOrDefault<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static (ElementResult Success, TSource Value) TrySingle<TSource>(this Queue<TSource> source)
            => ReadOnlyCollection.TrySingle<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static (ElementResult Success, TSource Value) TrySingle<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ReadOnlyCollection.TrySingle<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static (int Index, TSource Value) TrySingle<TSource>(this Queue<TSource> source, Func<TSource, int, bool> predicate)
            => ReadOnlyCollection.TrySingle<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static IReadOnlyCollection<TSource> AsEnumerable<TSource>(this Queue<TSource> source)
            => source;

        public static ReadOnlyCollection.AsValueEnumerableEnumerable<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource> AsValueEnumerable<TSource>(this Queue<TSource> source)
            => ReadOnlyCollection.AsValueEnumerable<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static TSource[] ToArray<TSource>(this Queue<TSource> source)
            => ReadOnlyCollection.ToArray<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static List<TSource> ToList<TSource>(this Queue<TSource> source)
            => ReadOnlyCollection.ToList<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
            
        public readonly struct ValueWrapper<TSource> 
            : IValueReadOnlyCollection<TSource, Queue<TSource>.Enumerator>
        {
            readonly Queue<TSource> source;

            public ValueWrapper(Queue<TSource> source)
            {
                this.source = source;
            }

            public int Count => source.Count;

            public Queue<TSource>.Enumerator GetEnumerator() => source.GetEnumerator();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => source.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();
        }    
    }
}