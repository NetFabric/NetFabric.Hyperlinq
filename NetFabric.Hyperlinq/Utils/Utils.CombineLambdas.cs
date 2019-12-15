using System;

namespace NetFabric.Hyperlinq
{
    static partial class Utils
    {
        public static Predicate<TSource> CombinePredicates<TSource>(Predicate<TSource> first, Predicate<TSource> second) => 
            item => first(item) && second(item);

        public static PredicateAt<TSource> CombinePredicates<TSource>(PredicateAt<TSource> first, Predicate<TSource> second) => 
            (item, index) => first(item, index) && second(item);

        public static PredicateAt<TSource> CombinePredicates<TSource>(Predicate<TSource> first, PredicateAt<TSource> second) => 
            (item, index) => first(item) && second(item, index);

        public static PredicateAt<TSource> CombinePredicates<TSource>(PredicateAt<TSource> first, PredicateAt<TSource> second) => 
            (item, index) => first(item, index) && second(item, index);

        public static Selector<TSource, TTarget> CombineSelectors<TSource, TMiddle, TTarget>(Selector<TSource, TMiddle> first, Selector<TMiddle, TTarget> second) => 
            item => second(first(item));

        public static SelectorAt<TSource, TTarget> CombineSelectors<TSource, TMiddle, TTarget>(SelectorAt<TSource, TMiddle> first, Selector<TMiddle, TTarget> second) => 
            (item, index) => second(first(item, index));

        public static SelectorAt<TSource, TTarget> CombineSelectors<TSource, TMiddle, TTarget>(Selector<TSource, TMiddle> first, SelectorAt<TMiddle, TTarget> second) => 
            (item, index) => second(first(item), index);

        public static SelectorAt<TSource, TTarget> CombineSelectors<TSource, TMiddle, TTarget>(SelectorAt<TSource, TMiddle> first, SelectorAt<TMiddle, TTarget> second) => 
            (item, index) => second(first(item, index), index);
    }
}