using System;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    static class DelegateExtensions
    {
        public static Func<T, bool> AsFunc<T>(this Predicate<T> predicate)
            => new Func<T, bool>(predicate);

        public static Func<T, int, bool> AsFunc<T>(this PredicateAt<T> predicate)
            => new Func<T, int, bool>(predicate);

        public static AsyncPredicate<T> AsAsync<T>(this Predicate<T> predicate)
            => new AsyncPredicate<T>((item, _) => new ValueTask<bool>(predicate(item)));
            
        public static AsyncPredicateAt<T> AsAsync<T>(this PredicateAt<T> predicate)
            => new AsyncPredicateAt<T>((item, position, _) => new ValueTask<bool>(predicate(item, position)));

        public static Func<TSource, TResult> AsFunc<TSource, TResult>(this Selector<TSource, TResult> selector)
            => new Func<TSource, TResult>(selector);

        public static Func<TSource, int, TResult> AsFunc<TSource, TResult>(this SelectorAt<TSource, TResult> selector)
            => new Func<TSource, int, TResult>(selector);

        public static AsyncSelector<TSource, TResult> AsAsync<TSource, TResult>(this Selector<TSource, TResult> selector)
            => new AsyncSelector<TSource, TResult>((item, _) => new ValueTask<TResult>(selector(item)));
            
        public static AsyncSelectorAt<TSource, TResult> AsAsync<TSource, TResult>(this SelectorAt<TSource, TResult> selector)
            => new AsyncSelectorAt<TSource, TResult>((item, position, _) => new ValueTask<TResult>(selector(item, position)));
    }
}