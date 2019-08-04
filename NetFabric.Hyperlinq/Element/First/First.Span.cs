using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class SpanExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref TSource First<TSource>(this Span<TSource> source)
        {
            if (source.Length == 0) ThrowHelper.ThrowEmptySequence<TSource>();

            return ref source[0];
        }

        public static ref TSource First<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
        {
            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            ThrowHelper.ThrowEmptySequence<TSource>();
            return ref source[0];
        }

        public static ref TSource First<TSource>(this Span<TSource> source, Func<TSource, long, bool> predicate)
        {
            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index], index))
                    return ref source[index];
            }
            ThrowHelper.ThrowEmptySequence<TSource>();
            return ref source[0];
        }

        public static ref TSource First<TSource>(this Span<TSource> source, Func<TSource, long, bool> predicate, out int index)
        {
            var length = source.Length;
            for (index = 0; index < length; index++)
            {
                if (predicate(source[index], index))
                    return ref source[index];
            }
            ThrowHelper.ThrowEmptySequence<TSource>();
            return ref source[0];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TSource FirstOrDefault<TSource>(this Span<TSource> source)
        {
            if (source.Length == 0) return ref Default<TSource>.Value;

            return ref source[0];
        }

        public static ref readonly TSource FirstOrDefault<TSource>(this Span<TSource> source, Func<TSource, bool> predicate)
        {
            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            return ref Default<TSource>.Value;
        }

        public static ref readonly TSource FirstOrDefault<TSource>(this Span<TSource> source, Func<TSource, long, bool> predicate)
        {
            var length = source.Length;
            for (var index = 0; index < length; index++)
            {
                if (predicate(source[index], index))
                    return ref source[index];
            }
            return ref Default<TSource>.Value;
        }

        public static ref readonly TSource FirstOrDefault<TSource>(this Span<TSource> source, Func<TSource, long, bool> predicate, out int index)
        {
            var length = source.Length;
            for (index = 0; index < length; index++)
            {
                if (predicate(source[index], index))
                    return ref source[index];
            }
            index = -1;
            return ref Default<TSource>.Value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource? FirstOrNull<TSource>(this Span<TSource> source)
            where TSource : struct
        {
            if (source.Length == 0) return null;

            return source[0];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource? FirstOrNull<TSource>(this Span<TSource> source, Func<TSource, long, bool> predicate)
            where TSource : struct
            => FirstOrNull<TSource>(source, predicate, out var _);

        public static TSource? FirstOrNull<TSource>(this Span<TSource> source, Func<TSource, long, bool> predicate, out int index)
            where TSource : struct
        {
            var length = source.Length;
            for (index = 0; index < length; index++)
            {
                if (predicate(source[index], index))
                    return source[index];
            }
            index = -1;
            return null;
        }
    }
}
