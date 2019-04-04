using System;

namespace NetFabric.Hyperlinq
{
    public static partial class Utils
    {
        public static Func<TSource, bool> CombinePredicates<TSource>(Func<TSource, bool> predicate1, Func<TSource, bool> predicate2) =>
            item => predicate1(item) && predicate2(item);

        public static Func<TSource, TResult> CombineSelectors<TSource, TMiddle, TResult>(Func<TSource, TMiddle> selector1, Func<TMiddle, TResult> selector2) =>
            item => selector2(selector1(item));        
    }
}
