using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this in ArraySegment<TSource> source, FunctionIn<TSource, bool> predicate)
            => source.AnyRef(new FunctionInWrapper<TSource, bool>(predicate));
        
        public static bool AnyRef<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, bool>
        {
            if (source.Any())
            {
                var array = source.Array!;
                var start = source.Offset;
                var end = start + source.Count;
                for (var index = start; index < end; index++)
                {
                    ref readonly var item = ref array[index];
                    if (predicate.Invoke(in item))
                        return true;
                }
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this in ArraySegment<TSource> source, FunctionIn<TSource, int, bool> predicate)
            => source.AnyAtRef(new FunctionInWrapper<TSource, int, bool>(predicate));

        public static bool AnyAtRef<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
        {
            if (source.Any())
            {
                var array = source.Array!;
                var start = source.Offset;
                var end = source.Count;
                if (start is 0)
                {
                    for (var index = 0; index < end; index++)
                    {
                        ref readonly var item = ref array[index];
                        if (predicate.Invoke(in item, index))
                            return true;
                    }
                }
                else
                {
                    for (var index = 0; index < end; index++)
                    {
                        ref readonly var item = ref array[index + start];
                        if (predicate.Invoke(in item, index))
                            return true;
                    }
                }
            }
            return false;
        }
    }
}

