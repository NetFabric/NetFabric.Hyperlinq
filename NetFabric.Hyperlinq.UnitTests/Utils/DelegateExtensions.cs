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
    }
}