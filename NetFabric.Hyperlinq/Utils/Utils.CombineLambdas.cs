using System;
using System.Threading;

namespace NetFabric.Hyperlinq
{
    static partial class Utils
    {
        public static Predicate<TSource> Combine<TSource>(Predicate<TSource> first, Predicate<TSource> second) => 
            item => first(item) && second(item);

        public static PredicateAt<TSource> Combine<TSource>(PredicateAt<TSource> first, Predicate<TSource> second) => 
            (item, index) => first(item, index) && second(item);

        public static PredicateAt<TSource> Combine<TSource>(Predicate<TSource> first, PredicateAt<TSource> second) => 
            (item, index) => first(item) && second(item, index);

        public static PredicateAt<TSource> Combine<TSource>(PredicateAt<TSource> first, PredicateAt<TSource> second) => 
            (item, index) => first(item, index) && second(item, index);

        public static Selector<TSource, TTarget> Combine<TSource, TMiddle, TTarget>(Selector<TSource, TMiddle> first, Selector<TMiddle, TTarget> second) => 
            item => second(first(item));

        public static SelectorAt<TSource, TTarget> Combine<TSource, TMiddle, TTarget>(SelectorAt<TSource, TMiddle> first, Selector<TMiddle, TTarget> second) => 
            (item, index) => second(first(item, index));

        public static SelectorAt<TSource, TTarget> Combine<TSource, TMiddle, TTarget>(Selector<TSource, TMiddle> first, SelectorAt<TMiddle, TTarget> second) => 
            (item, index) => second(first(item), index);

        public static SelectorAt<TSource, TTarget> Combine<TSource, TMiddle, TTarget>(SelectorAt<TSource, TMiddle> first, SelectorAt<TMiddle, TTarget> second) => 
            (item, index) => second(first(item, index), index);

        public static AsyncPredicate<TSource> Combine<TSource>(AsyncPredicate<TSource> first, AsyncPredicate<TSource> second) =>
            async (item, cancellation) => await first(item, cancellation) && await second(item, cancellation);

        public static AsyncPredicateAt<TSource> Combine<TSource>(AsyncPredicateAt<TSource> first, AsyncPredicate<TSource> second) =>
            async (item, index, cancellation) => 
                await first(item, index, cancellation).ConfigureAwait(false) && 
                await second(item, cancellation).ConfigureAwait(false);

        public static AsyncPredicateAt<TSource> Combine<TSource>(AsyncPredicate<TSource> first, AsyncPredicateAt<TSource> second) =>
            async (item, index, cancellation) => 
                await first(item, cancellation).ConfigureAwait(false) && 
                await second(item, index, cancellation).ConfigureAwait(false);

        public static AsyncPredicateAt<TSource> Combine<TSource>(AsyncPredicateAt<TSource> first, AsyncPredicateAt<TSource> second) =>
            async (item, index, cancellation) => 
                await first(item, index, cancellation).ConfigureAwait(false) && 
                await second(item, index, cancellation).ConfigureAwait(false);
    }
}