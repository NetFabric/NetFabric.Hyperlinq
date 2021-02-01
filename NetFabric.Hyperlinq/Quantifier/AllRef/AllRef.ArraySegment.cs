using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this in ArraySegment<TSource> source, FunctionIn<TSource, bool> predicate)
            => source.AsSpan().All(predicate);
        
        public static bool AllRef<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            => source.AsSpan().AllRef(predicate);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this in ArraySegment<TSource> source, FunctionIn<TSource, int, bool> predicate)
            => source.AsSpan().All(predicate);
        
        public static bool AllAtRef<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
            => source.AsSpan().AllAtRef(predicate);
    }
}

