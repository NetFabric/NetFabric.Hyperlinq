using System;

namespace NetFabric.Hyperlinq
{
    public interface IValueObservable<out T, TDisposable>
        : IObservable<T>
        where TDisposable : struct, IDisposable
    {
        TDisposable Subscribe<TObserver>(TObserver observer)
            where TObserver : struct, IObserver<T>;
    }
}
