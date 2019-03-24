using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class IReadOnlyListExtensions
    {
        public static int Count<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.Count<TSource>(array, predicate);
                default:
                    return ReadOnlyList.Count<IReadOnlyList<TSource>, TSource>(source, predicate);
            }
        }

        public static bool All<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.All<TSource>(array, predicate);
                default:
                    return ReadOnlyList.All<IReadOnlyList<TSource>, TSource>(source, predicate);
            }
        }

        public static bool Any<TSource>(this IReadOnlyList<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.Any<TSource>(array);
                default:
                    return ReadOnlyList.Any<IReadOnlyList<TSource>, TSource>(source);
            }
        }

        public static bool Any<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.Any<TSource>(array, predicate);
                default:
                    return ReadOnlyList.Any<IReadOnlyList<TSource>, TSource>(source, predicate);
            }
        }

        public static bool Contains<TSource>(this IReadOnlyList<TSource> source, TSource value)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.Contains<TSource>(array, value);
                case ICollection<TSource> collection:
                    return collection.Contains(value);
                default:
                    return ReadOnlyList.Contains<IReadOnlyList<TSource>, TSource>(source, value);
            }
        }

        public static bool Contains<TSource>(this IReadOnlyList<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.Contains<TSource>(array, value, comparer);
                default:
                    return ReadOnlyList.Contains<IReadOnlyList<TSource>, TSource>(source, value, comparer);
            }
        }

        public static ReadOnlyList.SelectEnumerable<IReadOnlyList<TSource>, TSource, TResult> Select<TSource, TResult>(
            this IReadOnlyList<TSource> source,
            Func<TSource, TResult> selector) 
            => ReadOnlyList.Select<IReadOnlyList<TSource>, TSource, TResult>(source, selector);

        public static ReadOnlyList.WhereEnumerable<IReadOnlyList<TSource>, TSource> Where<TSource>(
            this IReadOnlyList<TSource> source,
            Func<TSource, bool> predicate) 
            => ReadOnlyList.Where<IReadOnlyList<TSource>, TSource>(source, predicate);

        public static TSource First<TSource>(this IReadOnlyList<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.First<TSource>(array);
                default:
                    return ReadOnlyList.First<IReadOnlyList<TSource>, TSource>(source);
            }
        }

        public static TSource First<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.First<TSource>(array, predicate);
                default:
                    return ReadOnlyList.First<IReadOnlyList<TSource>, TSource>(source, predicate);
            }
        }

        public static TSource FirstOrDefault<TSource>(this IReadOnlyList<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.FirstOrDefault<TSource>(array);
                default:
                    return ReadOnlyList.FirstOrDefault<IReadOnlyList<TSource>, TSource>(source);
            }
        }

        public static TSource FirstOrDefault<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.FirstOrDefault<TSource>(array, predicate);
                default:
                    return ReadOnlyList.FirstOrDefault<IReadOnlyList<TSource>, TSource>(source, predicate);
            }
        }

        public static TSource? FirstOrNull<TSource>(this IReadOnlyList<TSource> source)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.FirstOrNull<TSource>(array);
                default:
                    return ReadOnlyList.FirstOrNull<IReadOnlyList<TSource>, TSource>(source);
            }
        }

        public static TSource? FirstOrNull<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.FirstOrNull<TSource>(array, predicate);
                default:
                    return ReadOnlyList.FirstOrNull<IReadOnlyList<TSource>, TSource>(source, predicate);
            }
        }

        public static TSource Single<TSource>(this IReadOnlyList<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.Single<TSource>(array);
                default:
                    return ReadOnlyList.Single<IReadOnlyList<TSource>, TSource>(source);
            }
        }

        public static TSource Single<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.Single<TSource>(array, predicate);
                default:
                    return ReadOnlyList.Single<IReadOnlyList<TSource>, TSource>(source, predicate);
            }
        }

        public static TSource SingleOrDefault<TSource>(this IReadOnlyList<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.SingleOrDefault<TSource>(array);
                default:
                    return ReadOnlyList.SingleOrDefault<IReadOnlyList<TSource>, TSource>(source);
            }
        }

        public static TSource SingleOrDefault<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.SingleOrDefault<TSource>(array, predicate);
                default:
                    return ReadOnlyList.SingleOrDefault<IReadOnlyList<TSource>, TSource>(source, predicate);
            }
        }

        public static TSource? SingleOrNull<TSource>(this IReadOnlyList<TSource> source)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.SingleOrNull<TSource>(array);
                default:
                    return ReadOnlyList.SingleOrNull<IReadOnlyList<TSource>, TSource>(source);
            }
        }

        public static TSource? SingleOrNull<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return Array.SingleOrNull<TSource>(array, predicate);
                default:
                    return ReadOnlyList.SingleOrNull<IReadOnlyList<TSource>, TSource>(source, predicate);
            }
        }

        public static ReadOnlyList.AsValueReadOnlyListEnumerable<IReadOnlyList<TSource>, TSource> AsValueReadOnlyList<TSource>(this IReadOnlyList<TSource> source)
            => ReadOnlyList.AsValueReadOnlyList<IReadOnlyList<TSource>, TSource>(source);

        public static TSource[] ToArray<TSource>(this IReadOnlyList<TSource> source)
            => ReadOnlyList.ToArray<IReadOnlyList<TSource>, TSource>(source);
    }
}
