using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static class Option
    {
        
        public static NoneOption None { get; } = new NoneOption();

        
        public static Option<T> Some<T>([AllowNull] T value) 
            => new Option<T>(value);
    }

    public readonly struct Option<T>
    {
        Option(bool hasValue, [AllowNull] T value)
        {
            IsSome = hasValue;
            Value = value;
        }

        internal Option([AllowNull] T value)
            : this (true, value)
        {
        }

        public bool IsNone
            => !IsSome;

        public bool IsSome { get; }

        [MaybeNull, AllowNull]
        public T Value { get; }

        public readonly void Deconstruct(out bool hasValue, [MaybeNull] out T value)
        {
            hasValue = IsSome;
            value = Value;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Option<T>(NoneOption _) 
            => default;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly TOut Match<TOut>(Func<T, TOut> some, Func<TOut> none) 
            => IsSome
                ? some(Value!) 
                : none();

        
        public readonly ValueTask<TOut> MatchAsync<TOut>(Func<T, CancellationToken, ValueTask<TOut>> some, Func<CancellationToken, ValueTask<TOut>> none, CancellationToken cancellationToken = default) 
            => IsSome
                ? some(Value!, cancellationToken) 
                : none(cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly void Match(Action<T> some, Action none)
        {
            if (IsSome)
                some(Value!);
            else
                none();
        }

        
        public readonly ValueTask MatchAsync(Func<T, CancellationToken, ValueTask> some, Func<CancellationToken, ValueTask> none, CancellationToken cancellationToken = default) 
            => IsSome
                ? some(Value!, cancellationToken) 
                : none(cancellationToken);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Option<TOut> Bind<TOut>(Func<T, Option<TOut>> bind)
            => IsSome
                ? bind(Value!)
                : default;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly int Count()
            => IsSome
                ? 1 
                : 0;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Any()
            => IsSome;

        
        public readonly bool Contains(T value, IEqualityComparer<T>? comparer = default) 
            => IsSome && (comparer is null 
                ? EqualityComparer<T>.Default.Equals(Value!, value) 
                : comparer.Equals(Value!, value));

        
        public readonly Option<T> Where(Predicate<T> predicate) 
            => IsSome && predicate(Value!) 
                ? this 
                : default;

        
        public async readonly ValueTask<Option<T>> WhereAsync(AsyncPredicate<T> predicate, CancellationToken cancellationToken = default) 
            => IsSome && await predicate(Value, cancellationToken).ConfigureAwait(false)
                ? this 
                : default;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Option<TOut> Select<TOut>(NullableSelector<T, TOut> selector) 
            => IsSome
                ? new Option<TOut>(selector(Value)) 
                : default;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async readonly ValueTask<Option<TOut>> SelectAsync<TOut>(AsyncSelector<T, TOut> selector, CancellationToken cancellationToken = default) 
            => IsSome
                ? new Option<TOut>(await selector(Value, cancellationToken).ConfigureAwait(false)) 
                : default;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly SelectManyEnumerable<TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSubEnumerable, TSubEnumerator, TResult>(Selector<T, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => new SelectManyEnumerable<TSubEnumerable, TSubEnumerator, TResult>(in this, selector);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Option<T> ElementAt(int index)
            => index == 0 
                ? this 
                : default;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Option<T> First()
            => this;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Option<T> Single()
            => this;

        
        public readonly T[] ToArray()
            => IsSome
                ? new T[] { Value! } 
                : Array.Empty<T>();

        
        public readonly List<T> ToList()
            => IsSome
                ? new List<T>(1) { Value! } 
                : new List<T>(0); 


        [GeneratorMapping("TSource", "TResult")]
        public readonly partial struct SelectManyEnumerable<TSubEnumerable, TSubEnumerator, TResult>
            : IValueEnumerable<TResult, SelectManyEnumerable<TSubEnumerable, TSubEnumerator, TResult>.Enumerator>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
        {
            readonly Option<T> source;
            readonly Selector<T, TSubEnumerable> selector;

            internal SelectManyEnumerable(in Option<T> source, Selector<T, TSubEnumerable> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IEnumerator<TResult>
            {
                readonly Option<T> source; 
                readonly Selector<T, TSubEnumerable> selector;
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TSubEnumerator subEnumerator; // do not make readonly
                int state;

                internal Enumerator(in SelectManyEnumerable<TSubEnumerable, TSubEnumerator, TResult> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    subEnumerator = default;
                    state = 0;
                    Current = default!;
                }

                [MaybeNull, AllowNull]
                public TResult Current { get; private set; }
                readonly TResult IEnumerator<TResult>.Current 
                    => Current!;
                readonly object? IEnumerator.Current
                    => Current;

                public bool MoveNext()
                {
                    switch (state)
                    {
                        case 0:
                            if (source.IsSome)
                            {
                                subEnumerator = selector(source.Value).GetEnumerator();
                                state = 1;
                                goto case 1;
                            }
                            state = 2;
                            goto case 2;

                        case 1:
                            if (subEnumerator.MoveNext())
                            {
                                Current = subEnumerator.Current;
                                return true;
                            }
                            Current = default!;
                            Dispose();
                            state = 2;
                            goto case 2;

                        case 2:
                            return false;
                    }
                    return false;
                }

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public void Dispose() 
                    => subEnumerator.Dispose();
            }
        }
    }
}