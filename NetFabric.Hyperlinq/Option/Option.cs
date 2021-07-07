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

        
        public static Option<TSource> Some<TSource>(TSource value) 
            => new(value);
    }

    [StructLayout(LayoutKind.Auto)]
    public readonly struct Option<TValue>
    {
        Option(bool hasValue, TValue value)
        {
            IsSome = hasValue;
            Value = value;
        }

        internal Option(TValue value)
            : this (hasValue: true, value)
        {
        }

        public bool IsNone
            => !IsSome;

        public bool IsSome { get; }

        public TValue Value { get; }

        public void Deconstruct(out bool hasValue, out TValue value)
        {
            hasValue = IsSome;
            value = Value;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Option<TValue>(NoneOption _) 
            => default;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TOut Match<TOut>(Func<TValue, TOut> some, Func<TOut> none) 
            => IsSome switch
            {
                true => some(Value),
                _ => none()
            };

        
        public ValueTask<TOut> MatchAsync<TOut>(Func<TValue, CancellationToken, ValueTask<TOut>> some, Func<CancellationToken, ValueTask<TOut>> none, CancellationToken cancellationToken = default) 
            => IsSome switch
            {
                true => some(Value, cancellationToken),
                _ => none(cancellationToken)
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Match(Action<TValue> some, Action none)
        {
            if (IsSome)
                some(Value);
            else
                none();
        }

        
        public ValueTask MatchAsync(Func<TValue, CancellationToken, ValueTask> some, Func<CancellationToken, ValueTask> none, CancellationToken cancellationToken = default) 
            => IsSome switch
            {
                true => some(Value, cancellationToken),
                _ => none(cancellationToken)
            };

        
        public Option<TOut> Bind<TOut>(Func<TValue, Option<TOut>> bind)
            => IsSome switch
            {
                true => bind(Value),
                _ => default
            };

        
        public int Count()
            => IsSome switch
            {
                true => 1,
                _ => 0
            };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Any()
            => IsSome;

        
        public bool Contains(TValue value, IEqualityComparer<TValue>? comparer = default) 
            => IsSome 
               && (comparer?.Equals(Value, value) 
                   ?? EqualityComparer<TValue>.Default.Equals(Value, value));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Option<TValue> Where(Func<TValue, bool> predicate)
            => Where(new FunctionWrapper<TValue, bool>(predicate));

        public Option<TValue> Where<TPredicate>(TPredicate predicate = default) 
            where TPredicate : struct, IFunction<TValue, bool>
            => IsSome && predicate.Invoke(Value) 
                ? this 
                : default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ValueTask<Option<TValue>> WhereAsync(Func<TValue, CancellationToken, ValueTask<bool>> predicate, CancellationToken cancellationToken = default)
            => WhereAsync(new AsyncFunctionWrapper<TValue, bool>(predicate), cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ValueTask<Option<TValue>> WhereAsync<TPredicate>(CancellationToken cancellationToken = default)
            where TPredicate : struct, IAsyncFunction<TValue, bool>
            => WhereAsync<TPredicate>(default, cancellationToken);

        public async ValueTask<Option<TValue>> WhereAsync<TPredicate>(TPredicate predicate, CancellationToken cancellationToken = default) 
            where TPredicate : struct, IAsyncFunction<TValue, bool>
            => IsSome && await predicate.InvokeAsync(Value, cancellationToken).ConfigureAwait(false)
                ? this 
                : default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Option<TOut> Select<TOut>(Func<TValue, TOut> selector)
            => Select<TOut, FunctionWrapper<TValue, TOut>>(new FunctionWrapper<TValue, TOut>(selector));
        
        public Option<TOut> Select<TOut, TSelector>(TSelector selector = default) 
            where TSelector : struct, IFunction<TValue, TOut>
            => IsSome switch
            {
                true => new Option<TOut>(selector.Invoke(Value)),
                _ => default
            };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ValueTask<Option<TOut>> SelectAsync<TOut>(Func<TValue, CancellationToken, ValueTask<TOut>> selector, CancellationToken cancellationToken = default)
            => SelectAsync<TOut, AsyncFunctionWrapper<TValue, TOut>>(new AsyncFunctionWrapper<TValue, TOut>(selector), cancellationToken);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ValueTask<Option<TOut>> SelectAsync<TOut, TSelector>(CancellationToken cancellationToken = default)
            where TSelector : struct, IAsyncFunction<TValue, TOut>
            => SelectAsync<TOut, TSelector>(default, cancellationToken);

        public async ValueTask<Option<TOut>> SelectAsync<TOut, TSelector>(TSelector selector, CancellationToken cancellationToken = default) 
            where TSelector : struct, IAsyncFunction<TValue, TOut>
            => IsSome switch
            {
                true => new Option<TOut>(await selector.InvokeAsync(Value, cancellationToken).ConfigureAwait(false)),
                _ => default
            };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SelectManyEnumerable<TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<TValue, TSubEnumerable>> SelectMany<TSubEnumerable, TSubEnumerator, TResult>(Func<TValue, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => SelectMany<TSubEnumerable, TSubEnumerator, TResult, FunctionWrapper<TValue, TSubEnumerable>>(new FunctionWrapper<TValue, TSubEnumerable>(selector));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SelectManyEnumerable<TSubEnumerable, TSubEnumerator, TResult, TSelector> SelectMany<TSubEnumerable, TSubEnumerator, TResult, TSelector>(TSelector selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TSelector : struct, IFunction<TValue, TSubEnumerable>
            => new(in this, selector);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Option<TValue> ElementAt(int index)
            => index switch
            {
                0 => this,
                _ => default,
            };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Option<TValue> First()
            => this;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Option<TValue> Single()
            => this;

        
        public TValue[] ToArray()
            => IsSome switch
            {
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                true => new[] { Value },
                _ => Array.Empty<TValue>()
            };

        
        public List<TValue> ToList()
            => IsSome switch
            {
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                true => new List<TValue>(1) { Value },
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                _ => new List<TValue>(0)
            }; 


        [StructLayout(LayoutKind.Auto)]
        public readonly partial struct SelectManyEnumerable<TSubEnumerable, TSubEnumerator, TResult, TSelector>
            : IValueEnumerable<TResult, SelectManyEnumerable<TSubEnumerable, TSubEnumerator, TResult, TSelector>.Enumerator>
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            where TSelector : struct, IFunction<TValue, TSubEnumerable>
        {
            readonly Option<TValue> source;
            readonly TSelector selector;

            internal SelectManyEnumerable(in Option<TValue> source, TSelector selector)
                => (this.source, this.selector) = (source, selector);
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator GetEnumerator() 
                => new(in this);

            IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);

            IEnumerator IEnumerable.GetEnumerator() 
                // ReSharper disable once HeapView.BoxingAllocation
                => new Enumerator(in this);

            [StructLayout(LayoutKind.Auto)]
            public struct Enumerator
                : IEnumerator<TResult>
            {
                readonly Option<TValue> source;
#pragma warning disable IDE0044 // Add readonly modifier
                TSelector selector;
                TSubEnumerator subEnumerator;
#pragma warning restore IDE0044 // Add readonly modifier
                int state;

                internal Enumerator(in SelectManyEnumerable<TSubEnumerable, TSubEnumerator, TResult, TSelector> enumerable)
                {
                    source = enumerable.source;
                    selector = enumerable.selector;
                    subEnumerator = default;
                    state = 0;
                    Current = default!;
                }

                public TResult Current { get; private set; }
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
                [DoesNotReturn]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public void Dispose() 
                    => subEnumerator.Dispose();
            }
        }
    }
}