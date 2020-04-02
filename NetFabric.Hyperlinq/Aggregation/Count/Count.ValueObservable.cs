using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueObservable
    {
        [Pure]
        public static CountObservable<TObservable, TDisposable, TSource> Count<TObservable, TDisposable, TSource>(this TObservable source)
            where TObservable : notnull, IValueObservable<TSource, TDisposable>
            where TDisposable : struct, IDisposable
            => new CountObservable<TObservable, TDisposable, TSource>(source);

        public readonly partial struct CountObservable<TObservable, TDisposable, TSource>
            : IValueObservable<int, TDisposable>
            where TObservable : notnull, IValueObservable<TSource, TDisposable>
            where TDisposable : struct, IDisposable
        {
            readonly TObservable source;

            internal CountObservable(TObservable source)
                => this.source = source;

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TDisposable Subscribe<TObserver>(TObserver observer)
                where TObserver : struct, IObserver<int>
                => source.Subscribe(new Observer<TObserver>(observer));

            IDisposable IObservable<int>.Subscribe(IObserver<int> observer)
                => source.Subscribe(new Observer<IObserver<int>>(observer));

            struct Observer<TObserver>
                : IObserver<TSource>
                where TObserver : IObserver<int>
            {
                readonly TObserver observer;
                int count;

                public Observer(TObserver observer)
                {
                    this.observer = observer;
                    count = 0;
                }

                public void OnNext(TSource value)
                {
                    try
                    {
                        checked
                        {
                            count++;
                        }
                    }
                    catch (Exception error)
                    {
                        observer.OnError(error);
                    }
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly void OnCompleted()
                {
                    observer.OnNext(count);
                    observer.OnCompleted();
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly void OnError(Exception error) 
                    => observer.OnError(error);
            }
        }
    }
}
