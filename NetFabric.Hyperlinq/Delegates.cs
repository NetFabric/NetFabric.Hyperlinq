using System;

namespace NetFabric.Hyperlinq
{
    public delegate TResult Selector<TSource, TResult>(in TSource item);

    public delegate bool Predicate<TSource>(in TSource item);
}
