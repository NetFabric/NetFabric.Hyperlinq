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
            => ValueReadOnlyCollection.Count<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static int Count<TSource>(this Queue<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.Count<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource> Skip<TSource>(this Queue<TSource> source, int count)
            => ValueReadOnlyCollection.Skip<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource> Take<TSource>(this Queue<TSource> source, int count)
            => ValueReadOnlyCollection.Take<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        public static bool All<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static bool All<TSource>(this Queue<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static bool Any<TSource>(this Queue<TSource> source)
            => source.Count != 0;
        public static bool Any<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static bool Any<TSource>(this Queue<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static bool Contains<TSource>(this Queue<TSource> source, TSource value)
            => source.Contains(value);

        public static bool Contains<TSource>(this Queue<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => ValueReadOnlyCollection.Contains<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), value, comparer);

        public static ValueReadOnlyCollection.SelectEnumerable<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this Queue<TSource> source,
            Func<TSource, TResult> selector) 
            => ValueReadOnlyCollection.Select<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);
        public static ValueReadOnlyCollection.SelectIndexEnumerable<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this Queue<TSource> source,
            Func<TSource, int, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);

        public static ValueEnumerable.SelectManyEnumerable<ValueWrapper<TSource>,  Queue<TSource>.Enumerator,  TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this Queue<TSource> source,
            Func<TSource, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueEnumerable.SelectMany<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TSource>(source), selector);

        public static ValueEnumerable.WhereEnumerable<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource> Where<TSource>(
            this Queue<TSource> source,
            Func<TSource, bool> predicate) 
            => ValueEnumerable.Where<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static ValueEnumerable.WhereIndexEnumerable<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource> Where<TSource>(
            this Queue<TSource> source,
            Func<TSource, int, bool> predicate)
            => ValueEnumerable.Where<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource First<TSource>(this Queue<TSource> source) 
            => ValueReadOnlyCollection.First<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static TSource First<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.First<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static TSource FirstOrDefault<TSource>(this Queue<TSource> source)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static TSource FirstOrDefault<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static (ElementResult Success, TSource Value) TryFirst<TSource>(this Queue<TSource> source)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static (ElementResult Success, TSource Value) TryFirst<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static (int Index, TSource Value) TryFirst<TSource>(this Queue<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource Single<TSource>(this Queue<TSource> source) 
            => ValueReadOnlyCollection.Single<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static TSource Single<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.Single<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static TSource SingleOrDefault<TSource>(this Queue<TSource> source)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static TSource SingleOrDefault<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static (ElementResult Success, TSource Value) TrySingle<TSource>(this Queue<TSource> source)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static (ElementResult Success, TSource Value) TrySingle<TSource>(this Queue<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static (int Index, TSource Value) TrySingle<TSource>(this Queue<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static ValueWrapper<TSource> AsEnumerable<TSource>(this Queue<TSource> source)
            => new ValueWrapper<TSource>(source);

        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this Queue<TSource> source)
            => new ValueWrapper<TSource>(source);

        public static TSource[] ToArray<TSource>(this Queue<TSource> source)
            => ValueReadOnlyCollection.ToArray<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static List<TSource> ToList<TSource>(this Queue<TSource> source)
            => ValueReadOnlyCollection.ToList<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this Queue<TSource> source, Func<TSource, TKey> keySelector)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource, TKey>(new ValueWrapper<TSource>(source), keySelector);
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this Queue<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource, TKey>(new ValueWrapper<TSource>(source), keySelector, comparer);
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this Queue<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource, TKey, TElement>(new ValueWrapper<TSource>(source), keySelector, elementSelector);
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this Queue<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TSource>, Queue<TSource>.Enumerator, TSource, TKey, TElement>(new ValueWrapper<TSource>(source), keySelector, elementSelector, comparer);

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