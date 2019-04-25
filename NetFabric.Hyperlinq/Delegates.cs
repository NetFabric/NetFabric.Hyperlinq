using System;

namespace NetFabric.Hyperlinq
{
    public delegate bool Predicate<TSource>(in TSource item, long index);

    public delegate TResult Selector<TSource, TResult>(in TSource item, long index);
}
