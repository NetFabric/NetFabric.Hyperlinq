using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public delegate bool PredicateAt<in T>(T obj, int position);
public delegate ValueTask<bool> AsyncPredicate<in T>(T obj, CancellationToken cancellationToken);
    public delegate ValueTask<bool> AsyncPredicateAt<in T>(T obj, int position, CancellationToken cancellationToken);

    public delegate TTo Selector<in TFrom, out TTo>(TFrom obj);
    public delegate TTo SelectorAt<in TFrom, out TTo>(TFrom obj, int position);
    public delegate TTo AsyncSelector<in TFrom, out TTo>(TFrom obj, CancellationToken cancellationToken);
    public delegate TTo AsyncSelectorAt<in TFrom, out TTo>(TFrom obj, int position, CancellationToken cancellationToken);
}