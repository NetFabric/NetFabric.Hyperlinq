using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource First<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source.TryFirst<TEnumerable, TEnumerator, TSource>(out var value))
                return value;
                
            return ThrowHelper.ThrowEmptySequence<TSource>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource FirstOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source.TryFirst<TEnumerable, TEnumerator, TSource>(out var value))
                return value;
                
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
        {
            if (source.TryFirst<TEnumerable, TEnumerator, TSource>(out var value))
                return value;
                
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource First<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => First<TEnumerable, TEnumerator, TSource>(source, predicate, out var _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource First<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate, out long index) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.TryFirst<TEnumerable, TEnumerator, TSource>(predicate, out var value, out index))
                return value;
                
            return ThrowHelper.ThrowEmptySequence<TSource>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource FirstOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => FirstOrDefault<TEnumerable, TEnumerator, TSource>(source, predicate, out var _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource FirstOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate, out long index) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.TryFirst<TEnumerable, TEnumerator, TSource>(predicate, out var value, out index))
                return value;
                
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
            => FirstOrNull<TEnumerable, TEnumerator, TSource>(source, predicate, out var _);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource? FirstOrNull<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate, out long index) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            where TSource : struct
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            if (source.TryFirst<TEnumerable, TEnumerator, TSource>(predicate, out var value, out index))
                return value;
                
            return null;
        }

        static bool TryFirst<TEnumerable, TEnumerator, TSource>(this TEnumerable source, out TSource value) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source.Count != 0) 
            {
                using (var enumerator = (TEnumerator)source.GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        value = enumerator.Current;
                        return true;
                    }
                }    
            } 

            value = default;
            return false;            
        }

        static bool TryFirst<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate, out TSource value, out long index) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source.Count != 0) 
            {
                index = 0;
                using (var enumerator = (TEnumerator)source.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        value = enumerator.Current;
                        if (predicate(value, index))
                            return true;

                        index++;
                    }
                }
            }        

            value = default;
            index = -1;
            return false;
        }    
    }
}