using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this TSource[] source, Func<TSource, bool> predicate)
            => source.All(new FunctionWrapper<TSource, bool>(predicate));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource, TPredicate>(this TSource[] source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, bool>
            => new ArraySegment<TSource>(source).All(predicate);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this TSource[] source, Func<TSource, int, bool> predicate)
            => source.AllAt(new FunctionWrapper<TSource, int, bool>(predicate));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AllAt<TSource, TPredicate>(this TSource[] source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, int, bool>
            => new ArraySegment<TSource>(source).AllAt(predicate);
    }
}

