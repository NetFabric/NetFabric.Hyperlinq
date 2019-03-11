using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public static int Count<TSource>(this TSource[] source)
            => source.Length;

        public static int Count<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            if (length == 0) return 0;

            var count = 0;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    count++;
            }
            return count;
        }

        public static bool All<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            if (length == 0) return false;

            for (var index = 0; index < length; index++)
            {
                if (!predicate(source[index]))
                    return false;
            }
            return true;
        }

        public static bool Any<TSource>(this TSource[] source)
            => source.Length != 0;

        public static bool Any<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            if (length == 0) return false;

            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    return true;
            }
            return false;
        }

        public static bool Contains<TSource>(this TSource[] source, TSource value, IEqualityComparer<TSource> comparer = null)
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            var length = source.Length;
            if (length == 0) return false;

            if(comparer is null)
            {
                for (var index = 0; index < length; index++)
                {
                    if (EqualityComparer<TSource>.Default.Equals(value, source[index]))
                        return true;
                }
            }
            else
            {
                for (var index = 0; index < length; index++)
                {
                    if (comparer.Equals(value, source[index]))
                        return true;
                }
            }

            return false;
        }

        public static ref readonly TSource First<TSource>(this TSource[] source)
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (source.Length == 0) ThrowHelper.ThrowEmptySequence<TSource>();

            return ref source[0];
        }

        public static ref readonly TSource FirstOrDefault<TSource>(this TSource[] source)
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (source.Length == 0) return ref Default<TSource>.Value;

            return ref source[0];
        }

        public static TSource? FirstOrNull<TSource>(this TSource[] source)
            where TSource : struct
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (source.Length == 0) return null;

            return source[0];
        }

        public static ref readonly TSource First<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            ThrowHelper.ThrowEmptySequence<TSource>();
            return ref source[0];
        }

        public static ref readonly TSource FirstOrDefault<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            return ref Default<TSource>.Value;
        }

        public static TSource? FirstOrNull<TSource>(this TSource[] source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    return source[index];
            }
            return null;
        }

        public static ref readonly TSource Single<TSource>(this TSource[] source)
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            var length = source.Length;
            if (length == 0) ThrowHelper.ThrowEmptySequence<TSource>();
            if (length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            return ref source[0];
        }

        public static ref readonly TSource SingleOrDefault<TSource>(this TSource[] source)
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            var length = source.Length;
            if (length == 0) return ref Default<TSource>.Value;
            if (length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            return ref source[0];
        }

        public static TSource? SingleOrNull<TSource>(this TSource[] source)
            where TSource : struct
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            var length = source.Length;
            if (length == 0) return null;
            if (length > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();

            return source[0];
        }

        public static ref readonly TSource Single<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                {
                    ref readonly TSource first = ref source[index];

                    for (index++; index < length; index++)
                    {
                        if (predicate(source[index]))
                            ThrowHelper.ThrowNotSingleSequence<TSource>();
                    }

                    return ref first;
                }
            }
            ThrowHelper.ThrowEmptySequence<TSource>();
            return ref source[0];
        }

        public static ref readonly TSource SingleOrDefault<TSource>(this TSource[] source, Func<TSource, bool> predicate)
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                {
                    ref readonly TSource first = ref source[index];

                    for (index ++; index < length; index++)
                    {
                        if (predicate(source[index]))
                            ThrowHelper.ThrowNotSingleSequence<TSource>();
                    }

                    return ref first;
                }
            }
            return ref Default<TSource>.Value;
        }

        public static TSource? SingleOrNull<TSource>(this TSource[] source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            if (source is null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                {
                    var first = source[index];

                    for (index++; index < length; index++)
                    {
                        if (predicate(source[index]))
                            ThrowHelper.ThrowNotSingleSequence<TSource>();
                    }

                    return first;
                }
            }
            return null;
        }

        public static IEnumerable<TSource> AsEnumerable<TSource>(this TSource[] source)
            => source;

        public static IReadOnlyCollection<TSource> AsReadOnlyCollection<TSource>(this TSource[] source)
            => source;

        public static IReadOnlyList<TSource> AsReadOnlyList<TSource>(this TSource[] source)
            => source;

        public static Enumerable.AsValueEnumerableEnumerable<IEnumerable<TSource>, IEnumerator<TSource>, TSource> AsValueEnumerable<TSource>(this TSource[] source)
            => Enumerable.AsValueEnumerable<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);

        public static ReadOnlyCollection.AsValueReadOnlyCollectionEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource> AsValueReadOnlyCollection<TSource>(this TSource[] source)
            => ReadOnlyCollection.AsValueReadOnlyCollection<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static ReadOnlyList.AsValueReadOnlyListEnumerable<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource> AsValueReadOnlyList<TSource>(this TSource[] source)
            => ReadOnlyList.AsValueReadOnlyList<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource[] ToArray<TSource>(this TSource[] source)
            => source;

        public static List<TSource> ToList<TSource>(this TSource[] source)
            => new List<TSource>(source);
    }
}
