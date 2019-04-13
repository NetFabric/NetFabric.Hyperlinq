using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Utils
    {
        public static Func<TSource, bool> CombinePredicates<TSource>(Func<TSource, bool> predicate1, Func<TSource, bool> predicate2) =>
            item => predicate1(item) && predicate2(item);

        public static Func<TSource, TResult> CombineSelectors<TSource, TMiddle, TResult>(Func<TSource, TMiddle> selector1, Func<TMiddle, TResult> selector2) =>
            item => selector2(selector1(item));    

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (int SkipCount, int TakeCount) Skip(int sourceCount, int skipCount)
        {
            skipCount = Math.Min(sourceCount, Math.Max(0, skipCount));
            return (skipCount, Math.Max(0, sourceCount - skipCount));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Take(int sourceCount, int takeCount)
            => Math.Min(sourceCount, Math.Max(0, takeCount)); 

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (int SkipCount, int TakeCount) SkipTake(int sourceCount, int skipCount, int takeCount)
        {
            skipCount = Math.Min(sourceCount, Math.Max(0, skipCount));
            return (skipCount, Math.Min(sourceCount - skipCount, Math.Max(0, takeCount))); 
        }
    }
}
