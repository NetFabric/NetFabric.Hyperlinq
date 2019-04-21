using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource First<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (source.TryFirst<TEnumerable, TSource>(out var value))
                return value;
                
            return ThrowHelper.ThrowEmptySequence<TSource>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource FirstOrDefault<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (source.TryFirst<TEnumerable, TSource>(out var value))
                return value;
                
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource? FirstOrNull<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
            where TSource : struct
        {
            if (source.TryFirst<TEnumerable, TSource>(out var value))
                return value;
                
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource First<TEnumerable, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
            => First<TEnumerable, TSource>(source, predicate, out var _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource First<TEnumerable, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate, out int index) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.TryFirst<TEnumerable, TSource>(predicate, out var value, out index))
                return value;
                
            return ThrowHelper.ThrowEmptySequence<TSource>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource FirstOrDefault<TEnumerable, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
            => FirstOrDefault<TEnumerable, TSource>(source, predicate, out var _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource FirstOrDefault<TEnumerable, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate, out int index) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.TryFirst<TEnumerable, TSource>(predicate, out var value, out index))
                return value;
                
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource? FirstOrNull<TEnumerable, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
            where TSource : struct
            => FirstOrNull<TEnumerable, TSource>(source, predicate, out var _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource? FirstOrNull<TEnumerable, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate, out int index) 
            where TEnumerable : IReadOnlyList<TSource>
            where TSource : struct
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.TryFirst<TEnumerable, TSource>(predicate, out var value, out index))
                return value;
                
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool TryFirst<TEnumerable, TSource>(this TEnumerable source, out TSource value) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (source.Count != 0) 
            {
                value = source[0];       
                return true;
            }

            value = default;
            return false;
        }

        static bool TryFirst<TEnumerable, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate, out TSource value, out int index) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            var count = source.Count;
            for (index = 0; index < count; index++)
            {
                if (predicate(source[index], index))
                {
                    value = source[index];
                    return true;
                }
            }

            value = default;
            index = -1;
            return false;
        }
    }
}
