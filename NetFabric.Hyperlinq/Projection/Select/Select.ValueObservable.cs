using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueObservable
    {
        [Pure]
        public static SelectObservable<TObservable, TDisposable, TSource, TResult> Select<TObservable, TDisposable, TSource, TResult>(this TObservable source, Selector<TSource, TResult> selector)
            where TObservable : notnull, IValueObservable<TSource, TDisposable>
            where TDisposable : struct, IDisposable
        {
            if (selector is null) Throw.ArgumentNullException(nameof(selector));

            return new SelectObservable<TObservable, TDisposable, TSource, TResult>(source, selector);
        }

        public readonly partial struct SelectObservable<TObservable, TDisposable, TSource, TResult>
            : IValueObservable<TResult, TDisposable>
            where TObservable : notnull, IValueObservable<TSource, TDisposable>
            where TDisposable : struct, IDisposable
        {
            readonly TObservable source;
            readonly Selector<TSource, TResult> selector;

            internal SelectObservable(TObservable source, Selector<TSource, TResult> selector)
            {
                this.source = source;
                this.selector = selector;
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TDisposable Subscribe<TObserver>(TObserver observer)
                where TObserver : struct, IObserver<TResult>
                => source.Subscribe(new Observer<TObserver>(observer, selector));

            IDisposable IObservable<TResult>.Subscribe(IObserver<TResult> observer)
                => source.Subscribe(new Observer<IObserver<TResult>>(observer, selector));

            struct Observer<TObserver>
                : IObserver<TSource>
                where TObserver : IObserver<TResult>
            {
                readonly TObserver observer;
                readonly Selector<TSource, TResult> selector;

                public Observer(TObserver observer, Selector<TSource, TResult> selector)
                {
                    this.observer = observer;
                    this.selector = selector;
                }

                public void OnNext(TSource value)
                    => observer.OnNext(selector(value));

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly void OnCompleted() 
                    => observer.OnCompleted();

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly void OnError(Exception error) 
                    => observer.OnError(error);
            }
        }
    }
}
