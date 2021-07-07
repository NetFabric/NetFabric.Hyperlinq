using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    static class DelegateExtensions
    {
        public static Func<TSource, CancellationToken, ValueTask<bool>> AsAsync<TSource>(this Func<TSource, bool> predicate)
            => (item, _) => new ValueTask<bool>(predicate(item));
            
        public static Func<TSource, int, CancellationToken, ValueTask<bool>> AsAsync<TSource>(this Func<TSource, int, bool> predicate)
            => (item, index, _) => new ValueTask<bool>(predicate(item, index));

        public static Func<TSource, CancellationToken, ValueTask<TResult>> AsAsync<TSource, TResult>(this Func<TSource, TResult> selector)
            => (item, _) => new ValueTask<TResult>(selector(item));
            
        public static Func<TSource, int, CancellationToken, ValueTask<TResult>> AsAsync<TSource, TResult>(this Func<TSource, int, TResult> selector)
            => (item, index, _) => new ValueTask<TResult>(selector(item, index));
    }
}