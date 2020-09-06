using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Auto)]
    public readonly struct PredicatePredicateCombination<TFirstPredicate, TSecondPredicate, TSource> 
        : IPredicate<TSource>
        where TFirstPredicate : struct, IPredicate<TSource>
        where TSecondPredicate : struct, IPredicate<TSource>
    {
        readonly TFirstPredicate first;
        readonly TSecondPredicate second;

        public PredicatePredicateCombination(TFirstPredicate first, TSecondPredicate second)
            => (this.first, this.second) = (first, second);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Invoke([AllowNull] TSource item)
            => first.Invoke(item) 
            && second.Invoke(item);
    }

    [StructLayout(LayoutKind.Auto)]
    public readonly struct PredicatePredicateAtCombination<TFirstPredicate, TSecondPredicate, TSource> 
        : IPredicateAt<TSource>
        where TFirstPredicate : struct, IPredicate<TSource>
        where TSecondPredicate : struct, IPredicateAt<TSource>
    {
        readonly TFirstPredicate first;
        readonly TSecondPredicate second;

        public PredicatePredicateAtCombination(TFirstPredicate first, TSecondPredicate second)
            => (this.first, this.second) = (first, second);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Invoke([AllowNull] TSource item, int index)
            => first.Invoke(item) 
            && second.Invoke(item, index);
    }

    [StructLayout(LayoutKind.Auto)]
    public readonly struct PredicateAtPredicateAtCombination<TFirstPredicate, TSecondPredicate, TSource> 
        : IPredicateAt<TSource>
        where TFirstPredicate : struct, IPredicateAt<TSource>
        where TSecondPredicate : struct, IPredicateAt<TSource>
    {
        readonly TFirstPredicate first;
        readonly TSecondPredicate second;

        public PredicateAtPredicateAtCombination(TFirstPredicate first, TSecondPredicate second)
            => (this.first, this.second) = (first, second);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Invoke([AllowNull] TSource item, int index)
            => first.Invoke(item, index) 
            && second.Invoke(item, index);
    }

    [StructLayout(LayoutKind.Auto)]
    public readonly struct AsyncPredicateAsyncPredicateCombination<TFirstPredicate, TSecondPredicate, TSource>
        : IAsyncPredicate<TSource>
        where TFirstPredicate : struct, IAsyncPredicate<TSource>
        where TSecondPredicate : struct, IAsyncPredicate<TSource>
    {
        readonly TFirstPredicate first;
        readonly TSecondPredicate second;

        public AsyncPredicateAsyncPredicateCombination(TFirstPredicate first, TSecondPredicate second)
            => (this.first, this.second) = (first, second);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async ValueTask<bool> InvokeAsync([AllowNull] TSource item, CancellationToken cancellationToken)
            => await first.InvokeAsync(item, cancellationToken).ConfigureAwait(false)
            && await second.InvokeAsync(item, cancellationToken).ConfigureAwait(false);
    }

    [StructLayout(LayoutKind.Auto)]
    public readonly struct AsyncPredicateAsyncPredicateAtCombination<TFirstPredicate, TSecondPredicate, TSource>
        : IAsyncPredicateAt<TSource>
        where TFirstPredicate : struct, IAsyncPredicate<TSource>
        where TSecondPredicate : struct, IAsyncPredicateAt<TSource>
    {
        readonly TFirstPredicate first;
        readonly TSecondPredicate second;

        public AsyncPredicateAsyncPredicateAtCombination(TFirstPredicate first, TSecondPredicate second)
            => (this.first, this.second) = (first, second);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async ValueTask<bool> InvokeAsync([AllowNull] TSource item, int index, CancellationToken cancellationToken)
            => await first.InvokeAsync(item, cancellationToken).ConfigureAwait(false)
            && await second.InvokeAsync(item, index, cancellationToken).ConfigureAwait(false);
    }

    [StructLayout(LayoutKind.Auto)]
    public readonly struct AsyncPredicateAtAsyncPredicateAtCombination<TFirstPredicate, TSecondPredicate, TSource>
        : IAsyncPredicateAt<TSource>
        where TFirstPredicate : struct, IAsyncPredicateAt<TSource>
        where TSecondPredicate : struct, IAsyncPredicateAt<TSource>
    {
        readonly TFirstPredicate first;
        readonly TSecondPredicate second;

        public AsyncPredicateAtAsyncPredicateAtCombination(TFirstPredicate first, TSecondPredicate second)
            => (this.first, this.second) = (first, second);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async ValueTask<bool> InvokeAsync([AllowNull] TSource item, int index, CancellationToken cancellationToken)
            => await first.InvokeAsync(item, index, cancellationToken).ConfigureAwait(false)
            && await second.InvokeAsync(item, index, cancellationToken).ConfigureAwait(false);
    }

    static partial class Utils
    {
        public static NullableSelector<TSource, TTarget> Combine<TSource, TMiddle, TTarget>(NullableSelector<TSource, TMiddle> first, NullableSelector<TMiddle, TTarget> second) => 
            item => second(first(item));

        public static NullableSelectorAt<TSource, TTarget> Combine<TSource, TMiddle, TTarget>(NullableSelectorAt<TSource, TMiddle> first, NullableSelector<TMiddle, TTarget> second) => 
            (item, index) => second(first(item, index));

        public static NullableSelectorAt<TSource, TTarget> Combine<TSource, TMiddle, TTarget>(NullableSelector<TSource, TMiddle> first, NullableSelectorAt<TMiddle, TTarget> second) => 
            (item, index) => second(first(item), index);

        public static NullableSelectorAt<TSource, TTarget> Combine<TSource, TMiddle, TTarget>(NullableSelectorAt<TSource, TMiddle> first, NullableSelectorAt<TMiddle, TTarget> second) => 
            (item, index) => second(first(item, index), index);

        public static AsyncSelector<TSource, TTarget> Combine<TSource, TMiddle, TTarget>(AsyncSelector<TSource, TMiddle> first, AsyncSelector<TMiddle, TTarget> second) => 
            async (item, cancellation) => 
                await second(await first(item, cancellation).ConfigureAwait(false), cancellation).ConfigureAwait(false);

        public static AsyncSelectorAt<TSource, TTarget> Combine<TSource, TMiddle, TTarget>(AsyncSelectorAt<TSource, TMiddle> first, AsyncSelector<TMiddle, TTarget> second) => 
            async (item, index, cancellation) => 
                await second(await first(item, index, cancellation).ConfigureAwait(false), cancellation).ConfigureAwait(false);

        public static AsyncSelectorAt<TSource, TTarget> Combine<TSource, TMiddle, TTarget>(AsyncSelector<TSource, TMiddle> first, AsyncSelectorAt<TMiddle, TTarget> second) => 
            async (item, index, cancellation) => 
                await second(await first(item, cancellation).ConfigureAwait(false), index, cancellation).ConfigureAwait(false);

        public static AsyncSelectorAt<TSource, TTarget> Combine<TSource, TMiddle, TTarget>(AsyncSelectorAt<TSource, TMiddle> first, AsyncSelectorAt<TMiddle, TTarget> second) => 
            async (item, index, cancellation) => 
                await second(await first(item, index, cancellation).ConfigureAwait(false), index, cancellation).ConfigureAwait(false);
    }
}