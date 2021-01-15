using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    public static class Option
    {
        
        public static NoneOption None { get; } = new();

        
        public static Option<T> Some<T>(T value) 
            => new(value);
    }

    [StructLayout(LayoutKind.Auto)]
    public readonly struct Option<T>
    {
        Option(bool hasValue, T value)
        {
            IsSome = hasValue;
            Value = value;
        }

        internal Option(T value)
            : this (hasValue: true, value)
        {
        }

        public bool IsNone
            => !IsSome;

        public bool IsSome { get; }

        public T Value { get; }

        public readonly void Deconstruct(out bool hasValue, out T value)
        {
            hasValue = IsSome;
            value = Value;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Option<T>(NoneOption _) 
            => default;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly TOut Match<TOut>(Func<T, TOut> some, Func<TOut> none) 
            => IsSome switch
            {
                true => some(Value),
                _ => none()
            };

        
        public readonly ValueTask<TOut> MatchAsync<TOut>(Func<T, CancellationToken, ValueTask<TOut>> some, Func<CancellationToken, ValueTask<TOut>> none, CancellationToken cancellationToken = default) 
            => IsSome switch
            {
                true => some(Value, cancellationToken),
                _ => none(cancellationToken)
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly void Match(Action<T> some, Action none)
        {
            if (IsSome)
                some(Value);
            else
                none();
        }

        
        public readonly ValueTask MatchAsync(Func<T, CancellationToken, ValueTask> some, Func<CancellationToken, ValueTask> none, CancellationToken cancellationToken = default) 
            => IsSome switch
            {
                true => some(Value, cancellationToken),
                _ => none(cancellationToken)
            };

        
        public readonly Option<TOut> Bind<TOut>(Func<T, Option<TOut>> bind)
            => IsSome switch
            {
                true => bind(Value),
                _ => default
            };

        
        public readonly int Count()
            => IsSome switch
            {
                true => 1,
                _ => 0
            };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Any()
            => IsSome;

        
        public readonly bool Contains(T value, IEqualityComparer<T>? comparer = default) 
            => IsSome 
               && (comparer?.Equals(Value, value) ?? EqualityComparer<T>.Default.Equals(Value, value));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Option<T> Where(Func<T, bool> predicate)
            => Where(new FunctionWrapper<T, bool>(predicate));

        public readonly Option<T> Where<TPredicate>(TPredicate predicate = default) 
            where TPredicate : struct, IFunction<T, bool>
            => IsSome && predicate.Invoke(Value) 
                ? this 
                : default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly ValueTask<Option<T>> WhereAsync(Func<T, CancellationToken, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
            => WhereAsync(new AsyncFunctionWrapper<T, bool>(predicate), cancellationToken);
        
        public async readonly ValueTask<Option<T>> WhereAsync<TPredicate>(TPredicate predicate, CancellationToken cancellationToken = default) 
            where TPredicate : struct, IAsyncFunction<T, bool>
            => IsSome && await predicate.InvokeAsync(Value, cancellationToken).ConfigureAwait(false)
                ? this 
                : default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Option<TOut> Select<TOut>(Func<T, TOut> selector)
            => Select<TOut, FunctionWrapper<T, TOut>>(new FunctionWrapper<T, TOut>(selector));
        
        public readonly Option<TOut> Select<TOut, TSelector>(TSelector selector) 
            where TSelector : struct, IFunction<T, TOut>
            => IsSome switch
            {
                true => new Option<TOut>(selector.Invoke(Value)),
                _ => default
            };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly ValueTask<Option<TOut>> SelectAsync<TOut>(Func<T, CancellationToken, ValueTask<TOut>> selector, CancellationToken cancellationToken = default)
            => SelectAsync<TOut, AsyncFunctionWrapper<T, TOut>>(new AsyncFunctionWrapper<T, TOut>(selector), cancellationToken);
        
        public async readonly ValueTask<Option<TOut>> SelectAsync<TOut, TSelector>(TSelector selector, CancellationToken cancellationToken = default) 
            where TSelector : struct, IAsyncFunction<T, TOut>
            => IsSome switch
            {
                true => new Option<TOut>(await selector.InvokeAsync(Value, cancellationToken).ConfigureAwait(false)),
                _ => default
            };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly SelectManyEnumerable<TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<T, TSubEnumerable>> SelectMany<TSubEnumerable, TSubEnumerator, TResult>(Func<T, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => SelectMany<TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<T, TSubEnumerable>>(new FunctionWrapper<T, TSubEnumerable>(selector));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly SelectManyEnumerable<TSubEnumerable, TSubEnumerator, TResult, TSelector> SelectMany<TSubEnumerable, TSubEnumerator, TResult, TSelector>(TSelector selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TSelector : struct, IFunction<T, TSubEnumerable>
            => new(in this, selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Option<T> ElementAt(int index)
            => index switch
            {
                0 => this,
                _ => default,
            };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Option<T> First()
            => this;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Option<T> Single()
            => this;

        
        public readonly T[] ToArray()
            => IsSome switch
            {
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                true => new T[] { Value },
                _ => Array.Empty<T>()
            };

        
        public readonly List<T> ToList()
            => IsSome switch
            {
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                true => new List<T>(1) { Value },
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                _ => new List<T>(0)
            }; 


        [GeneratorMapping("TSource", "TResult")]
        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct SelectManyEnumerable<TSubEnumerable, TSubEnumerator, TResult, TSelector>
            : IValueEnumerable<TResult, SelectManyEnumerable<TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TSelector : struct, IFunction<T, TSubEnumerable>
        {
            readonly Option<T> source;
            readonly TSelector selector;

            internal SelectManyEnumerable(in Option<T> source, TSelector selector)
                => (this.source, this.selector) = (source, selector);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() 
                => new(in this);
            readonly IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);

            [StructLayout(LayoutKind.Sequential)]
            public struct Enumerator
                : IEnumerator<TResult>
            {
                int state;
                readonly Option<T> source; 
                TSelector selector;
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TSubEnumerator subEnumerator; // do not make readonly

                internal Enumerator(in SelectManyEnumerable<TSubEnumerable, TSubEnumerator, TResult, TSelector> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    subEnumerator = default;
                    state = 0;
                    Current = default!;
                }

                public TResult Current { get; private set; }
                readonly TResult IEnumerator<TResult>.Current 
                    => Current;
                readonly object? IEnumerator.Current
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    => Current;

                public bool MoveNext()
                {
                    switch (state)
                    {
                        case 0:
                            if (source.IsSome)
                            {
                                subEnumerator = selector.Invoke(source.Value).GetEnumerator();
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