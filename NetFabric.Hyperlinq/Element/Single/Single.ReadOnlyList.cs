using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static TSource Single<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (source.TrySingle<TEnumerable, TSource>(out var value))
                return value;
                
            return ThrowHelper.ThrowEmptySequence<TSource>();
        }

        public static TSource SingleOrDefault<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (source.TrySingle<TEnumerable, TSource>(out var value))
                return value;
                
            return default;
        }

        public static TSource? SingleOrNull<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
            where TSource : struct
        {
            if (source.TrySingle<TEnumerable, TSource>(out var value))
                return value;
                
            return null;
        }

        public static TSource Single<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.TrySingle<TEnumerable, TSource>(predicate, out var value))
                return value;
                
            return ThrowHelper.ThrowEmptySequence<TSource>();
        }

        public static TSource SingleOrDefault<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.TrySingle<TEnumerable, TSource>(predicate, out var value))
                return value;
                
            return default;
        }

        public static TSource? SingleOrNull<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
            where TSource : struct
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.TrySingle<TEnumerable, TSource>(predicate, out var value))
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool TrySingle<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate, out TSource value) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            var count = source.Count;
            for (var index = 0; index < count; index++)
            {
                if (predicate(source[index]))
                {
                    value = source[index];

                    for (index++; index < count; index++)
                    {
                        if (predicate(source[index]))
                            ThrowHelper.ThrowNotSingleSequence<TSource>();
                    }

                    return true;
                }
            }

            value = default;
            return false;
        }    
    }
}
