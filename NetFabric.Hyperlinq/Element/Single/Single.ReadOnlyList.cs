using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (source.TrySingle<TEnumerable, TSource>(out var value))
                return value;
                
            return ThrowHelper.ThrowEmptySequence<TSource>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource SingleOrDefault<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (source.TrySingle<TEnumerable, TSource>(out var value))
                return value;
                
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource? SingleOrNull<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
            where TSource : struct
        {
            if (source.TrySingle<TEnumerable, TSource>(out var value))
                return value;
                
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TEnumerable, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
            => Single<TEnumerable, TSource>(source, predicate, out var _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TEnumerable, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate, out int index) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.TrySingle<TEnumerable, TSource>(predicate, out var value, out index))
                return value;
                
            return ThrowHelper.ThrowEmptySequence<TSource>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource SingleOrDefault<TEnumerable, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
            => SingleOrDefault<TEnumerable, TSource>(source, predicate, out var _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource SingleOrDefault<TEnumerable, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate, out int index) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.TrySingle<TEnumerable, TSource>(predicate, out var value, out index))
                return value;
                
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource? SingleOrNull<TEnumerable, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
            where TSource : struct
            => SingleOrNull<TEnumerable, TSource>(source, predicate, out var _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource? SingleOrNull<TEnumerable, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate, out int index) 
            where TEnumerable : IReadOnlyList<TSource>
            where TSource : struct
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.TrySingle<TEnumerable, TSource>(predicate, out var value, out index))
                return value;
                
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool TrySingle<TEnumerable, TSource>(this TEnumerable source, out TSource value) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            var count = source.Count;
            if (count > 1) ThrowHelper.ThrowNotSingleSequence<TSource>();
            if (count != 0) 
            {
                value = source[0];       
                return true;
            }

            value = default;
            return false;
        }

        static bool TrySingle<TEnumerable, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate, out TSource value, out int index) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            var count = source.Count;
            for (index = 0; index < count; index++)
            {
                if (predicate(source[index], index))
                {
                    value = source[index];

                    for (index++; index < count; index++)
                    {
                        if (predicate(source[index], index))
                            ThrowHelper.ThrowNotSingleSequence<TSource>();
                    }

                    return true;
                }
            }

            value = default;
            index = -1;
            return false;
        }    
    }
}
