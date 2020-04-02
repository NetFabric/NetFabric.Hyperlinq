using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Observable
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueObservableWrapper<TSource> AsValueObservable<TSource>(this IObservable<TSource> source)
            => new ValueObservableWrapper<TSource>(source);

        public readonly partial struct ValueObservableWrapper<TSource>
            : IValueObservable<TSource, AnonymousValueDisposable<IObservable<TSource>>>
        {
            readonly IObservable<TSource> source;

            internal ValueObservableWrapper(IObservable<TSource> source)
                => this.source = source;

            public AnonymousValueDisposable<IObservable<TSource>> Subscribe<TObserver>(TObserver observer)
                where TObserver : struct, IObserver<TSource>
                => ValueDisposable.Create(source, source => source.Subscribe(observer));

            IDisposable IObservable<TSource>.Subscribe(IObserver<TSource> observer)
                => source.Subscribe(observer);
        }
    }
}
