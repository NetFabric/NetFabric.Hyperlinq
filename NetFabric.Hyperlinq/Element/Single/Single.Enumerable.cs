using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source.TrySingle<TEnumerable, TEnumerator, TSource>(out var value))
                return value;
                
            return ThrowHelper.ThrowEmptySequence<TSource>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source.TrySingle<TEnumerable, TEnumerator, TSource>(out var value))
                return value;
                
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSource : struct
        {
            if (source.TrySingle<TEnumerable, TEnumerator, TSource>(out var value))
                return value;
                
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
            => Single<TEnumerable, TEnumerator, TSource>(source, predicate, out var _); 

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate, out long index) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.TrySingle<TEnumerable, TEnumerator, TSource>(predicate, out var value, out index))
                return value;
                
            return ThrowHelper.ThrowEmptySequence<TSource>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
            => SingleOrDefault<TEnumerable, TEnumerator, TSource>(source, predicate, out var _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate, out long index) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.TrySingle<TEnumerable, TEnumerator, TSource>(predicate, out var value, out index))
                return value;
                
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSource : struct
            => SingleOrNull<TEnumerable, TEnumerator, TSource>(source, predicate, out var _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate, out long index) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
            where TSource : struct
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.TrySingle<TEnumerable, TEnumerator, TSource>(predicate, out var value, out index))
                return value;
                
            return null;
        }
        
        static bool TrySingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source, out TSource value) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            using (var enumerator = (TEnumerator)source.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    value = enumerator.Current;

                    if (enumerator.MoveNext())
                        ThrowHelper.ThrowNotSingleSequence<TSource>();

                    return true;
                }
            }

            value = default;
            return false;
        }

        static bool TrySingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate, out TSource value, out long index) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            using (var enumerator = (TEnumerator)source.GetEnumerator())
            {
                checked
                {
                    for (index = 0; enumerator.MoveNext(); index++)
                    {
                        value = enumerator.Current;
                        if (predicate(value, index))
                        {
                            // found first, keep going until end or find second
                            for (index++; enumerator.MoveNext(); index++)
                            {
                                if (predicate(enumerator.Current, index))
                                    ThrowHelper.ThrowNotSingleSequence<TSource>();
                            }
                            return true;
                        }
                    }
                }
            }      

            value = default;
            index = -1;
            return false;
        }
    }
}