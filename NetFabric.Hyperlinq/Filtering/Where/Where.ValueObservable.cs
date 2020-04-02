using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueObservable
    {
        [Pure]
        public static WhereObservable<TObservable, TDisposable, TSource> Where<TObservable, TDisposable, TSource>(this TObservable source, Predicate<TSource> predicate)
            where TObservable : notnull, IValueObservable<TSource, TDisposable>
            where TDisposable : struct, IDisposable
        {
            if (predicate is null) Throw.ArgumentNullException(nameof(predicate));

            return new WhereObservable<TObservable, TDisposable, TSource>(source, predicate);
        }

        public readonly partial struct WhereObservable<TObservable, TDisposable, TSource>
            : IValueObservable<TSource, TDisposable>
            where TObservable : notnull, IValueObservable<TSource, TDisposable>
            where TDisposable : struct, IDisposable
        {
            readonly TObservable source;
            readonly Predicate<TSource> predicate;

            internal WhereObservable(TObservable source, Predicate<TSource> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TDisposable Subscribe<TObserver>(TObserver observer)
                where TObserver : struct, IObserver<TSource>
                => source.Subscribe(new Observer<TObserver>(observer, predicate));

            IDisposable IObservable<TSource>.Subscribe(IObserver<TSource> observer)
                => source.Subscribe(new Observer<IObserver<TSource>>(observer, predicate));

            struct Observer<TObserver>
                : IObserver<TSource>
                where TObserver : IObserver<TSource>
            {
                readonly TObserver observer;
                readonly Predicate<TSource> predicate;

                public Observer(TObserver observer, Predicate<TSource> predicate)
                {
                    this.observer = observer;
                    this.predicate = predicate;
                }

                public void OnNext(TSource value)
                {
                    if (predicate(value))
                        observer.OnNext(value);
                }

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
