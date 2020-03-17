using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static class Option
    {
        [Pure]
        public static NoneOption None { get; } = new NoneOption();

        [Pure]
        public static Option<T> Some<T>(T value) 
            => new Option<T>(value);
    }

    public readonly struct Option<T>
    {
        readonly bool hasValue;
        readonly T value;

        Option(bool hasValue, T value)
        {
            this.hasValue = hasValue;
            this.value = value;
        }

        internal Option(T value)
            : this (true, value)
        {
        }

        public bool IsNone 
            => !hasValue;

        public bool IsSome 
            => hasValue;

        public static implicit operator Option<T>(NoneOption _) 
            => default;

        [Pure]
        public TOut Match<TOut>(Func<T, TOut> some, Func<TOut> none) 
            => hasValue 
                ? some(value) 
                : none();

        [Pure]
        public ValueTask<TOut> MatchAsync<TOut>(Func<T, CancellationToken, ValueTask<TOut>> some, Func<CancellationToken, ValueTask<TOut>> none, CancellationToken cancellationToken = default) 
            => hasValue 
                ? some(value, cancellationToken) 
                : none(cancellationToken);

        public void Match(Action<T> some, Action none)
        {
            if (hasValue)
                some(value);
            else
                none();
        }

        [Pure]
        public ValueTask MatchAsync(Func<T, CancellationToken, ValueTask> some, Func<CancellationToken, ValueTask> none, CancellationToken cancellationToken = default) 
            => hasValue 
                ? some(value, cancellationToken) 
                : none(cancellationToken);

        [Pure]
        public Option<T> Where(Predicate<T> predicate) 
            => hasValue && predicate(value) 
                ? this 
                : default;

        [Pure]
        public async ValueTask<Option<T>> WhereAsync(AsyncPredicate<T> predicate, CancellationToken cancellationToken = default) 
            => hasValue && await predicate(value, cancellationToken).ConfigureAwait(false)
                ? this 
                : default;

        [Pure]
        public Option<TOut> Select<TOut>(Selector<T, TOut> selector) 
            => hasValue 
                ? new Option<TOut>(selector(value)) 
                : default;

        [Pure]
        public async ValueTask<Option<TOut>> SelectAsync<TOut>(AsyncSelector<T, TOut> selector, CancellationToken cancellationToken = default) 
            => hasValue 
                ? new Option<TOut>(await selector(value, cancellationToken).ConfigureAwait(false)) 
                : default;

        [Pure]
        public Option<TOut> Bind<TOut>(Func<T, Option<TOut>> bind) 
            => hasValue 
                ? bind(value) 
                : default;

        public T[] ToArray()
            => hasValue 
                ? new T[] { value } 
                : new T[0]; 

        public List<T> ToList()
            => hasValue 
                ? new List<T>(1) { value } 
                : new List<T>(0); 
    }
}