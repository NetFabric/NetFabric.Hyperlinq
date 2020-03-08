using System;
using System.Diagnostics.Contracts;

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

        public Option(T value)
            : this (true, value)
        {
        }

        public static implicit operator Option<T>(NoneOption none) 
            => default;

        public void Deconstruct(out bool hasValue, out T value)
        {
            hasValue = this.hasValue;
            value = this.value;
        }

        [Pure]
        public TOut Match<TOut>(Func<T, TOut> some, Func<TOut> none) 
            => hasValue ? some(value) : none();

        public void Match(Action<T> some, Action none)
        {
            if (hasValue)
                some(value);
            else
                none();
        }

        [Pure]
        public Option<TOut> Select<TOut>(Selector<T, TOut> map) 
            => hasValue ? new Option<TOut>(map(value)) : default;

        [Pure]
        public Option<TOut> Bind<TOut>(Func<T, Option<TOut>> bind) 
            => hasValue ? bind(value) : default;
    }

    public readonly struct NoneOption
    {
    }
}