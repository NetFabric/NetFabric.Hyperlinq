using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Auto)]
    public struct AsyncPredicatePredicateCombination<TPredicate1, TPredicate2, TSource>
        : IAsyncFunction<TSource, bool>
        where TPredicate1 : struct, IAsyncFunction<TSource, bool>
        where TPredicate2 : struct, IAsyncFunction<TSource, bool>
    {
        TPredicate1 first;
        TPredicate2 second;

        public AsyncPredicatePredicateCombination(TPredicate1 first, TPredicate2 second)
            => (this.first, this.second) = (first, second);

        public async ValueTask<bool> InvokeAsync(TSource item, CancellationToken cancellationToken)
            => await first.InvokeAsync(item, cancellationToken).ConfigureAwait(false) 
               && await second.InvokeAsync(item, cancellationToken).ConfigureAwait(false);
    }
    
    [StructLayout(LayoutKind.Auto)]
    public struct AsyncPredicatePredicateAtCombination<TPredicate1, TPredicate2, TSource>
        : IAsyncFunction<TSource, int, bool>
        where TPredicate1 : struct, IAsyncFunction<TSource, bool>
        where TPredicate2 : struct, IAsyncFunction<TSource, int, bool>
    {
        TPredicate1 first;
        TPredicate2 second;

        public AsyncPredicatePredicateAtCombination(TPredicate1 first, TPredicate2 second)
            => (this.first, this.second) = (first, second);

        public async ValueTask<bool> InvokeAsync(TSource item, int index, CancellationToken cancellationToken)
            => await first.InvokeAsync(item, cancellationToken).ConfigureAwait(false)
               && await second.InvokeAsync(item, index, cancellationToken).ConfigureAwait(false);
    }
    
    [StructLayout(LayoutKind.Auto)]
    public struct AsyncPredicateAtPredicateAtCombination<TPredicate1, TPredicate2, TSource>
        : IAsyncFunction<TSource, int, bool>
        where TPredicate1 : struct, IAsyncFunction<TSource, int, bool>
        where TPredicate2 : struct, IAsyncFunction<TSource, int, bool>
    {
        TPredicate1 first;
        TPredicate2 second;

        public AsyncPredicateAtPredicateAtCombination(TPredicate1 first, TPredicate2 second)
            => (this.first, this.second) = (first, second);

        public async ValueTask<bool> InvokeAsync(TSource item, int index, CancellationToken cancellationToken)
            => await first.InvokeAsync(item, index, cancellationToken).ConfigureAwait(false) 
               && await second.InvokeAsync(item, index, cancellationToken).ConfigureAwait(false);
    }
}
