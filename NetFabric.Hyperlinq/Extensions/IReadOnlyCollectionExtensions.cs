using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class IReadOnlyCollectionExtensions
    {
        public static int Count<TSource>(this IReadOnlyCollection<TSource> source)
            => source.Count;

        public static ReadOnlyCollection.SelectEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource, TResult> Select<TSource, TResult>(
            this IReadOnlyCollection<TSource> source,
            Func<TSource, TResult> selector) 
            => ReadOnlyCollection.Select<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource, TResult>(source, selector);

        public static TSource First<TSource>(this IReadOnlyCollection<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.First<TSource>(array);
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.First<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(list);
                default:
                    return ReadOnlyCollection.First<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource FirstOrDefault<TSource>(this IReadOnlyCollection<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.FirstOrDefault<TSource>(array);
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.FirstOrDefault<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(list);
                default:
                    return ReadOnlyCollection.FirstOrDefault<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource? FirstOrNull<TSource>(this IReadOnlyCollection<TSource> source)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.FirstOrNull<TSource>(array);
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.FirstOrNull<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(list);
                default:
                    return ReadOnlyCollection.FirstOrNull<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource Single<TSource>(this IReadOnlyCollection<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.Single<TSource>(array);
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.Single<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(list);
                default:
                    return ReadOnlyCollection.Single<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource SingleOrDefault<TSource>(this IReadOnlyCollection<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.SingleOrDefault<TSource>(array);
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.SingleOrDefault<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(list);
                default:
                    return ReadOnlyCollection.SingleOrDefault<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource? SingleOrNull<TSource>(this IReadOnlyCollection<TSource> source)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.SingleOrNull<TSource>(array);
                case IReadOnlyList<TSource> list:
                    return ReadOnlyList.SingleOrNull<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(list);
                default:
                    return ReadOnlyCollection.SingleOrNull<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static ReadOnlyCollection.AsValueReadOnlyCollectionEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource> AsValueReadOnlyCollection<TSource>(this IReadOnlyCollection<TSource> source)
            => ReadOnlyCollection.AsValueReadOnlyCollection<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static List<TSource> ToList<TSource>(this IReadOnlyCollection<TSource> source)
            => ReadOnlyCollection.ToList<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);
    }
}
