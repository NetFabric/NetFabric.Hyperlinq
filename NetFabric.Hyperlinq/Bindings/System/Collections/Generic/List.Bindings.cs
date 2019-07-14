using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class ListBindings
    {
        public static int Count<TSource>(this List<TSource> source)
            => source.Count;
        public static int Count<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyList.Count<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static int Count<TSource>(this List<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyList.Count<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static ValueReadOnlyList.SkipTakeEnumerable<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource> Skip<TSource>(this List<TSource> source, int count)
            => ValueReadOnlyList.Skip<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        public static ValueReadOnlyList.SkipTakeEnumerable<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource> Take<TSource>(this List<TSource> source, int count)
            => ValueReadOnlyList.Take<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        public static bool All<TSource>(this List<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyList.All<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static bool Any<TSource>(this List<TSource> source)
            => source.Count != 0;

        public static bool Any<TSource>(this List<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyList.Any<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static bool Contains<TSource>(this List<TSource> source, TSource value)
            => source.Contains(value);

        public static bool Contains<TSource>(this List<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => ValueReadOnlyList.Contains<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), value, comparer);

        public static ValueReadOnlyList.SelectEnumerable<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this List<TSource> source,
            Func<TSource, TResult> selector) 
            => ValueReadOnlyList.Select<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);
        public static ValueReadOnlyList.SelectIndexEnumerable<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this List<TSource> source,
            Func<TSource, int, TResult> selector)
            => ValueReadOnlyList.Select<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);

        public static ValueReadOnlyList.SelectManyEnumerable<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this List<TSource> source,
            Func<TSource, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueReadOnlyList.SelectMany<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TSource>(source), selector);

        public static ValueReadOnlyList.WhereEnumerable<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource> Where<TSource>(
            this List<TSource> source, 
            Func<TSource, bool> predicate) 
            => ValueReadOnlyList.Where<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static ValueReadOnlyList.WhereIndexEnumerable<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource> Where<TSource>(
            this List<TSource> source,
            Func<TSource, int, bool> predicate)
            => ValueReadOnlyList.Where<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource First<TSource>(this List<TSource> source) 
            => ValueReadOnlyList.First<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static TSource First<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyList.First<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static TSource FirstOrDefault<TSource>(this List<TSource> source)
            => ValueReadOnlyList.FirstOrDefault<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static TSource FirstOrDefault<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyList.FirstOrDefault<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static (ElementResult Success, TSource Value) TryFirst<TSource>(this List<TSource> source)
            => ValueReadOnlyList.TryFirst<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static (ElementResult Success, TSource Value) TryFirst<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyList.TryFirst<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static (int Index, TSource Value) TryFirst<TSource>(this List<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyList.TryFirst<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource Single<TSource>(this List<TSource> source) 
            => ValueReadOnlyList.Single<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static TSource Single<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyList.Single<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static TSource SingleOrDefault<TSource>(this List<TSource> source)
            => ValueReadOnlyList.SingleOrDefault<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static TSource SingleOrDefault<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyList.SingleOrDefault<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static (ElementResult Success, TSource Value) TrySingle<TSource>(this List<TSource> source)
            => ValueReadOnlyList.TrySingle<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static (ElementResult Success, TSource Value) TrySingle<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyList.TrySingle<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static (int Index, TSource Value) TrySingle<TSource>(this List<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyList.TrySingle<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static ValueWrapper<TSource> AsEnumerable<TSource>(this List<TSource> source)
            => new ValueWrapper<TSource>(source);

        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this List<TSource> source)
            => new ValueWrapper<TSource>(source);

        public static TSource[] ToArray<TSource>(this List<TSource> source)
            => ValueReadOnlyList.ToArray<ValueWrapper<TSource>, List<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static List<TSource> ToList<TSource>(this List<TSource> source)
            => new List<TSource>(source);

        public readonly struct ValueWrapper<TSource> 
            : IValueReadOnlyList<TSource, List<TSource>.Enumerator>
        {
            readonly List<TSource> source;

            public ValueWrapper(List<TSource> source)
            {
                this.source = source;
            }

            public int Count => source.Count;
            public TSource this[int index] => source[index];

            public List<TSource>.Enumerator GetEnumerator() => source.GetEnumerator();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => source.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();
        }
    }
}