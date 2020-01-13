using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public delegate void ActionAt<in T>(T obj, int position);

    public delegate ValueTask AsyncAction<in T>(T obj, CancellationToken cancellationToken);
    public delegate ValueTask AsyncActionAt<in T>(T obj, int position, CancellationToken cancellationToken);

    public delegate bool PredicateAt<in T>(T obj, int position);
    public delegate bool PredicateAtLong<in T>(T obj, long position);

    public delegate ValueTask<bool> AsyncPredicate<in T>(T obj, CancellationToken cancellationToken);
    public delegate ValueTask<bool> AsyncPredicateAt<in T>(T obj, int position, CancellationToken cancellationToken);
    public delegate ValueTask<bool> AsyncPredicateAtLong<in T>(T obj, long position, CancellationToken cancellationToken);

    public delegate TResult Selector<in TSource, TResult>(TSource obj);
    public delegate TResult SelectorAt<in TSource, TResult>(TSource obj, int position);
    public delegate TResult SelectorAtLong<in TSource, TResult>(TSource obj, long position);

    public delegate ValueTask<TResult> AsyncSelector<in TSource, TResult>(TSource obj, CancellationToken cancellationToken);
    public delegate ValueTask<TResult> AsyncSelectorAt<in TSource, TResult>(TSource obj, int position, CancellationToken cancellationToken);
    public delegate ValueTask<TResult> AsyncSelectorAtLong<in TSource, TResult>(TSource obj, long position, CancellationToken cancellationToken);
}