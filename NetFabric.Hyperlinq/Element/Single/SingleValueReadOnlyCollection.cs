using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source.TrySingle<TEnumerable, TEnumerator, TSource>(out var value))
                return value;
                
            return ThrowHelper.ThrowEmptySequence<TSource>();
        }

        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source.TrySingle<TEnumerable, TEnumerator, TSource>(out var value))
                return value;
                
            return default;
        }

        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
        {
            if (source.TrySingle<TEnumerable, TEnumerator, TSource>(out var value))
                return value;
                
            return null;
        }

        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.TrySingle<TEnumerable, TEnumerator, TSource>(predicate, out var value))
                return value;
                
            return ThrowHelper.ThrowEmptySequence<TSource>();
        }

        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.TrySingle<TEnumerable, TEnumerator, TSource>(predicate, out var value))
                return value;
                
            return default;
        }

        public static TSource? SingleOrNull<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.TrySingle<TEnumerable, TEnumerator, TSource>(predicate, out var value))
                return value;
                
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool TrySingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source, out TSource value) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source.Count() != 0)
            {
                using (var enumerator = source.GetValueEnumerator())
                {
                    if (enumerator.TryMoveNext(out value))
                    {
                        if (enumerator.TryMoveNext())
                            ThrowHelper.ThrowNotSingleSequence<TSource>();

                        return true;
                    }
                }
            }

            value = default;
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool TrySingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate, out TSource value) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source.Count() != 0)
            {
                using (var enumerator = source.GetValueEnumerator())
                {
                    while (enumerator.TryMoveNext(out value))
                    {
                        if (predicate(value))
                        {
                            // found first, keep going until end or find second
                            TSource other;
                            while (enumerator.TryMoveNext(out other))
                            {
                                if (predicate(other))
                                    ThrowHelper.ThrowNotSingleSequence<TSource>();
                            }
                            return true;
                        }
                    }
                }     
            } 

            value = default;
            return false;
        }    
    }
}
