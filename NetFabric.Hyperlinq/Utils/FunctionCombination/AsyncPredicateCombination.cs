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
#pragma warning disable IDE0044 // Add readonly modifier
        TPredicate1 first;
        TPredicate2 second;
#pragma warning restore IDE0044 // Add readonly modifier

        public AsyncPredicatePredicateCombination(TPredicate1 first, TPredicate2 second)
            => (this.first, this.second) = (first, second);

        public readonly async ValueTask<bool> InvokeAsync(TSource item, CancellationToken cancellationToken)
            => await first.InvokeAsync(item, cancellationToken).ConfigureAwait(false) 
               && await second.InvokeAsync(item, cancellationToken).ConfigureAwait(false);
    }
    
    [StructLayout(LayoutKind.Auto)]
    public struct AsyncPredicatePredicateAtCombination<TPredicate1, TPredicate2, TSource>
        : IAsyncFunction<TSource, int, bool>
        where TPredicate1 : struct, IAsyncFunction<TSource, bool>
        where TPredicate2 : struct, IAsyncFunction<TSource, int, bool>
    {
#pragma warning disable IDE0044 // Add readonly modifier
        TPredicate1 first;
        TPredicate2 second;
#pragma warning restore IDE0044 // Add readonly modifier

        public AsyncPredicatePredicateAtCombination(TPredicate1 first, TPredicate2 second)
            => (this.first, this.second) = (first, second);

        public readonly async ValueTask<bool> InvokeAsync(TSource item, int index, CancellationToken cancellationToken)
            => await first.InvokeAsync(item, cancellationToken).ConfigureAwait(false)
               && await second.InvokeAsync(item, index, cancellationToken).ConfigureAwait(false);
    }
    
    [StructLayout(LayoutKind.Auto)]
    public struct AsyncPredicateAtPredicateAtCombination<TPredicate1, TPredicate2, TSource>
        : IAsyncFunction<TSource, int, bool>
        where TPredicate1 : struct, IAsyncFunction<TSource, int, bool>
        where TPredicate2 : struct, IAsyncFunction<TSource, int, bool>
    {
#pragma warning disable IDE0044 // Add readonly modifier
        TPredicate1 first;
        TPredicate2 second;
#pragma warning restore IDE0044 // Add readonly modifier

        public AsyncPredicateAtPredicateAtCombination(TPredicate1 first, TPredicate2 second)
            => (this.first, this.second) = (first, second);

        public readonly async ValueTask<bool> InvokeAsync(TSource item, int index, CancellationToken cancellationToken)
            => await first.InvokeAsync(item, index, cancellationToken).ConfigureAwait(false) 
               && await second.InvokeAsync(item, index, cancellationToken).ConfigureAwait(false);
    }
}
