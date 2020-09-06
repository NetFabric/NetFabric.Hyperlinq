using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public readonly struct ValuePredicate<TSource>
        : IPredicate<TSource>
    {
        readonly Predicate<TSource> predicate;

        public ValuePredicate(Predicate<TSource> predicate)
            => this.predicate = predicate;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Invoke([AllowNull] TSource item)
            => predicate(item);
    }

    public readonly struct ValuePredicateAt<TSource>
        : IPredicateAt<TSource>
    {
        readonly PredicateAt<TSource> predicate;

        public ValuePredicateAt(PredicateAt<TSource> predicate)
            => this.predicate = predicate;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Invoke([AllowNull] TSource item, int index)
            => predicate(item, index);
    }

    public readonly struct AsyncValuePredicate<TSource>
        : IAsyncPredicate<TSource>
    {
        readonly AsyncPredicate<TSource> predicate;

        public AsyncValuePredicate(AsyncPredicate<TSource> predicate)
            => this.predicate = predicate;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ValueTask<bool> InvokeAsync([AllowNull] TSource item, CancellationToken cancellationToken)
            => predicate(item, cancellationToken);
    }

    public readonly struct AsyncValuePredicateAt<TSource>
        : IAsyncPredicateAt<TSource>
    {
        readonly AsyncPredicateAt<TSource> predicate;

        public AsyncValuePredicateAt(AsyncPredicateAt<TSource> predicate)
            => this.predicate = predicate;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ValueTask<bool> InvokeAsync([AllowNull] TSource item, int index, CancellationToken cancellationToken)
            => predicate(item, index, cancellationToken);
    }
}