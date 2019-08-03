using System;

namespace NetFabric.Hyperlinq
{
    static partial class Utils
    {
        public static Func<TSource, bool> CombinePredicates<TSource>(Func<TSource, bool> first, Func<TSource, bool> second) => 
            item => first(item) && second(item);

        public static Func<TSource, int, bool> CombinePredicates<TSource>(Func<TSource, int, bool> first, Func<TSource, bool> second) => 
            (item, index) => first(item, index) && second(item);

        public static Func<TSource, int, bool> CombinePredicates<TSource>(Func<TSource, bool> first, Func<TSource, int, bool> second) => 
            (item, index) => first(item) && second(item, index);

        public static Func<TSource, int, bool> CombinePredicates<TSource>(Func<TSource, int, bool> first, Func<TSource, int, bool> second) => 
            (item, index) => first(item, index) && second(item, index);

        public static Func<TSource, TTarget> CombineSelectors<TSource, TMiddle, TTarget>(Func<TSource, TMiddle> first, Func<TMiddle, TTarget> second) => 
            item => second(first(item));

        public static Func<TSource, int, TTarget> CombineSelectors<TSource, TMiddle, TTarget>(Func<TSource, int, TMiddle> first, Func<TMiddle, TTarget> second) => 
            (item, index) => second(first(item, index));

        public static Func<TSource, int, TTarget> CombineSelectors<TSource, TMiddle, TTarget>(Func<TSource, TMiddle> first, Func<TMiddle, int, TTarget> second) => 
            (item, index) => second(first(item), index);

        public static Func<TSource, int, TTarget> CombineSelectors<TSource, TMiddle, TTarget>(Func<TSource, int, TMiddle> first, Func<TMiddle, int, TTarget> second) => 
            (item, index) => second(first(item, index), index);
    }
}