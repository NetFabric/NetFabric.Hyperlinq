using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Auto)]
    public struct AsyncSelectorSelectorCombination<TSelector1, TSelector2, TSource, TMiddle, TResult>
        : IAsyncFunction<TSource, TResult>
        where TSelector1 : struct, IAsyncFunction<TSource, TMiddle>
        where TSelector2 : struct, IAsyncFunction<TMiddle, TResult>
    {
        TSelector1 first;
        TSelector2 second;

        public AsyncSelectorSelectorCombination(TSelector1 first, TSelector2 second)
            => (this.first, this.second) = (first, second);

        public async ValueTask<TResult> InvokeAsync(TSource item, CancellationToken cancellationToken)
            => await second.InvokeAsync(
                await first.InvokeAsync(item, cancellationToken).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
    }
    
    [StructLayout(LayoutKind.Auto)]
    public struct AsyncSelectorAtSelectorCombination<TSelector1, TSelector2, TSource, TMiddle, TResult>
        : IAsyncFunction<TSource, int, TResult>
        where TSelector1 : struct, IAsyncFunction<TSource, int, TMiddle>
        where TSelector2 : struct, IAsyncFunction<TMiddle, TResult>
    {
        TSelector1 first;
        TSelector2 second;

        public AsyncSelectorAtSelectorCombination(TSelector1 first, TSelector2 second)
            => (this.first, this.second) = (first, second);

        public async ValueTask<TResult> InvokeAsync(TSource item, int index, CancellationToken cancellationToken)
            => await second.InvokeAsync(
                await first.InvokeAsync(item, index, cancellationToken).ConfigureAwait(false), 
                cancellationToken).ConfigureAwait(false);
    }
    
    [StructLayout(LayoutKind.Auto)]
    public struct AsyncSelectorSelectorAtCombination<TSelector1, TSelector2, TSource, TMiddle, TResult>
        : IAsyncFunction<TSource, int, TResult>
        where TSelector1 : struct, IAsyncFunction<TSource, TMiddle>
        where TSelector2 : struct, IAsyncFunction<TMiddle, int, TResult>
    {
        TSelector1 first;
        TSelector2 second;

        public AsyncSelectorSelectorAtCombination(TSelector1 first, TSelector2 second)
            => (this.first, this.second) = (first, second);

        public async ValueTask<TResult> InvokeAsync(TSource item, int index, CancellationToken cancellationToken)
            => await second.InvokeAsync(
                await first.InvokeAsync(item, cancellationToken).ConfigureAwait(false), 
                index, cancellationToken).ConfigureAwait(false);
    }
    
    
    [StructLayout(LayoutKind.Auto)]
    public struct AsyncSelectorAtSelectorAtCombination<TSelector1, TSelector2, TSource, TMiddle, TResult>
        : IAsyncFunction<TSource, int, TResult>
        where TSelector1 : struct, IAsyncFunction<TSource, int, TMiddle>
        where TSelector2 : struct, IAsyncFunction<TMiddle, int, TResult>
    {
        TSelector1 first;
        TSelector2 second;

        public AsyncSelectorAtSelectorAtCombination(TSelector1 first, TSelector2 second)
            => (this.first, this.second) = (first, second);

        public async ValueTask<TResult> InvokeAsync(TSource item, int index, CancellationToken cancellationToken)
            => await second.InvokeAsync(
                await first.InvokeAsync(item, index, cancellationToken).ConfigureAwait(false), 
                index, cancellationToken).ConfigureAwait(false);
    }
}
