using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
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
#pragma warning disable IDE0032 // Use auto property
        readonly bool hasValue;
        readonly T value;
#pragma warning restore IDE0032 // Use auto property

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
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => !hasValue;
        }

        public bool IsSome
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => hasValue;
        }

        public T Value
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => value;
        }

        public readonly void Deconstruct(out bool hasValue, out T value)
        {
            hasValue = this.hasValue;
            value = this.value;
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Option<T>(NoneOption _) 
            => default;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly TOut Match<TOut>(Func<T, TOut> some, Func<TOut> none) 
            => hasValue 
                ? some(value) 
                : none();

        [Pure]
        public readonly ValueTask<TOut> MatchAsync<TOut>(Func<T, CancellationToken, ValueTask<TOut>> some, Func<CancellationToken, ValueTask<TOut>> none, CancellationToken cancellationToken = default) 
            => hasValue 
                ? some(value, cancellationToken) 
                : none(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly void Match(Action<T> some, Action none)
        {
            if (hasValue)
                some(value);
            else
                none();
        }

        [Pure]
        public readonly ValueTask MatchAsync(Func<T, CancellationToken, ValueTask> some, Func<CancellationToken, ValueTask> none, CancellationToken cancellationToken = default) 
            => hasValue 
                ? some(value, cancellationToken) 
                : none(cancellationToken);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Option<TOut> Bind<TOut>(Func<T, Option<TOut>> bind)
            => hasValue
                ? bind(value)
                : default;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly int Count()
            => hasValue 
                ? 1 
                : 0;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Any()
            => hasValue;

        [Pure]
        public readonly bool Contains(T value, IEqualityComparer<T>? comparer = null) 
            => hasValue 
            && (comparer is null 
                    ? EqualityComparer<T>.Default.Equals(this.value, value) 
                    : comparer.Equals(this.value, value));

        [Pure]
        public readonly Option<T> Where(Predicate<T> predicate) 
            => hasValue && predicate(value) 
                ? this 
                : default;

        [Pure]
        public async readonly ValueTask<Option<T>> WhereAsync(AsyncPredicate<T> predicate, CancellationToken cancellationToken = default) 
            => hasValue && await predicate(value, cancellationToken).ConfigureAwait(false)
                ? this 
                : default;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Option<TOut> Select<TOut>(Selector<T, TOut> selector) 
            => hasValue 
                ? new Option<TOut>(selector(value)) 
                : default;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async readonly ValueTask<Option<TOut>> SelectAsync<TOut>(AsyncSelector<T, TOut> selector, CancellationToken cancellationToken = default) 
            => hasValue 
                ? new Option<TOut>(await selector(value, cancellationToken).ConfigureAwait(false)) 
                : default;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Option<T> ElementAt(int index)
            => index == 0 
                ? this 
                : default;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Option<T> First()
            => this;

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Option<T> Single()
            => this;

        [Pure]
        public readonly T[] ToArray()
            => hasValue 
                ? new T[] { value } 
                : System.Array.Empty<T>();

        [Pure]
        public readonly List<T> ToList()
            => hasValue 
                ? new List<T>(1) { value } 
                : new List<T>(0); 
    }
}