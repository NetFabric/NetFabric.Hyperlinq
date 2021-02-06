using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this ReadOnlySpan<TSource> source, FunctionIn<TSource, bool> predicate)
            => source.AllRef(new FunctionInWrapper<TSource, bool>(predicate));
        
        public static bool AllRef<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, bool>
        {
            foreach (ref readonly var item in source)
            {
                if (!predicate.Invoke(in item))
                    return false;
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this ReadOnlySpan<TSource> source, FunctionIn<TSource, int, bool> predicate)
            => source.AllAtRef(new FunctionInWrapper<TSource, int, bool>(predicate));
        
        public static bool AllAtRef<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
        {
            for (var index = 0; index < source.Length; index++)
            {
                ref readonly var item = ref source[index];
                if (!predicate.Invoke(in item, index))
                    return false;
            }
            return true;
        }
    }
}

