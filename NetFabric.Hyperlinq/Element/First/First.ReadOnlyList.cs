using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static TSource First<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (source.TryFirst<TEnumerable, TSource>(out var value))
                return value;
                
            return ThrowHelper.ThrowEmptySequence<TSource>();
        }

        public static TSource FirstOrDefault<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (source.TryFirst<TEnumerable, TSource>(out var value))
                return value;
                
            return default;
        }

        public static TSource? FirstOrNull<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
            where TSource : struct
        {
            if (source.TryFirst<TEnumerable, TSource>(out var value))
                return value;
                
            return null;
        }

        public static TSource First<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.TryFirst<TEnumerable, TSource>(predicate, out var value))
                return value;
                
            return ThrowHelper.ThrowEmptySequence<TSource>();
        }

        public static TSource FirstOrDefault<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.TryFirst<TEnumerable, TSource>(predicate, out var value))
                return value;
                
            return default;
        }

        public static TSource? FirstOrNull<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
            where TSource : struct
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.TryFirst<TEnumerable, TSource>(predicate, out var value))
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool TryFirst<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate, out TSource value) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            var count = source.Count;
            for (var index = 0; index < count; index++)
            {
                if (predicate(source[index]))
                {
                    value = source[index];
                    return true;
                }
            }

            value = default;
            return false;
        }
    }
}
