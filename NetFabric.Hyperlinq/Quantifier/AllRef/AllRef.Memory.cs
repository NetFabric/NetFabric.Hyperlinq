using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this Memory<TSource> source, FunctionIn<TSource, bool> predicate)
            => source.AllRef(new FunctionInWrapper<TSource, bool>(predicate));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AllRef<TSource, TPredicate>(this Memory<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, bool>
            => ((ReadOnlyMemory<TSource>)source).AllRef(predicate);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All<TSource>(this Memory<TSource> source, FunctionIn<TSource, int, bool> predicate)
            => source.AllAtRef(new FunctionInWrapper<TSource, int, bool>(predicate));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AllAtRef<TSource, TPredicate>(this Memory<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
            => ((ReadOnlyMemory<TSource>)source).AllAtRef(predicate);
    }
}

