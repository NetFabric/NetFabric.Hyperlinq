using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class LinkedListBindings
    {
        public static int Count<TSource>(this LinkedList<TSource> source)
            => source.Count;
        public static int Count<TSource>(this LinkedList<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.Count<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static int Count<TSource>(this LinkedList<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.Count<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource> Skip<TSource>(this LinkedList<TSource> source, int count)
            => ValueReadOnlyCollection.Skip<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource> Take<TSource>(this LinkedList<TSource> source, int count)
            => ValueReadOnlyCollection.Take<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        public static bool All<TSource>(this LinkedList<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static bool Any<TSource>(this LinkedList<TSource> source)
            => source.Count != 0;

        public static bool Any<TSource>(this LinkedList<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static bool Contains<TSource>(this LinkedList<TSource> source, TSource value)
            => source.Contains(value);

        public static bool Contains<TSource>(this LinkedList<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => ValueReadOnlyCollection.Contains<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), value, comparer);

        public static ValueReadOnlyCollection.SelectEnumerable<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this LinkedList<TSource> source,
            Func<TSource, TResult> selector) 
            => ValueReadOnlyCollection.Select<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);
        public static ValueReadOnlyCollection.SelectIndexEnumerable<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this LinkedList<TSource> source,
            Func<TSource, int, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);

        public static ValueEnumerable.SelectManyEnumerable<ValueWrapper<TSource>,  LinkedList<TSource>.Enumerator,  TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this LinkedList<TSource> source,
            Func<TSource, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueEnumerable.SelectMany<ValueWrapper<TSource>,  LinkedList<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TSource>(source), selector);

        public static ValueEnumerable.WhereEnumerable<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource> Where<TSource>(
            this LinkedList<TSource> source,
            Func<TSource, bool> predicate) 
            => ValueEnumerable.Where<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static ValueEnumerable.WhereIndexEnumerable<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource> Where<TSource>(
            this LinkedList<TSource> source,
            Func<TSource, int, bool> predicate)
            => ValueEnumerable.Where<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource First<TSource>(this LinkedList<TSource> source) 
            => ValueReadOnlyCollection.First<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static TSource First<TSource>(this LinkedList<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.First<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static TSource FirstOrDefault<TSource>(this LinkedList<TSource> source)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static TSource FirstOrDefault<TSource>(this LinkedList<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static (ElementResult Success, TSource Value) TryFirst<TSource>(this LinkedList<TSource> source)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static (ElementResult Success, TSource Value) TryFirst<TSource>(this LinkedList<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static (int Index, TSource Value) TryFirst<TSource>(this LinkedList<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource Single<TSource>(this LinkedList<TSource> source) 
            => ValueReadOnlyCollection.Single<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static TSource Single<TSource>(this LinkedList<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.Single<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static TSource SingleOrDefault<TSource>(this LinkedList<TSource> source)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static TSource SingleOrDefault<TSource>(this LinkedList<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static (ElementResult Success, TSource Value) TrySingle<TSource>(this LinkedList<TSource> source)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static (ElementResult Success, TSource Value) TrySingle<TSource>(this LinkedList<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static (int Index, TSource Value) TrySingle<TSource>(this LinkedList<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static ValueWrapper<TSource> AsEnumerable<TSource>(this LinkedList<TSource> source)
            => new ValueWrapper<TSource>(source);

        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this LinkedList<TSource> source)
            => new ValueWrapper<TSource>(source);

        public static TSource[] ToArray<TSource>(this LinkedList<TSource> source)
            => ValueReadOnlyCollection.ToArray<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static List<TSource> ToList<TSource>(this LinkedList<TSource> source)
            => ValueReadOnlyCollection.ToList<ValueWrapper<TSource>, LinkedList<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public readonly struct ValueWrapper<TSource> 
            : IValueReadOnlyCollection<TSource, LinkedList<TSource>.Enumerator>
        {
            readonly LinkedList<TSource> source;

            public ValueWrapper(LinkedList<TSource> source)
            {
                this.source = source;
            }

            public int Count => source.Count;

            public LinkedList<TSource>.Enumerator GetEnumerator() => source.GetEnumerator();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => source.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();
        }    
    }
}