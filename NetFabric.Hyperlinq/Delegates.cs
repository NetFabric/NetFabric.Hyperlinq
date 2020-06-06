using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public delegate void ActionAt<in T>([AllowNull] T obj, int position);

    public delegate ValueTask AsyncAction<in T>([AllowNull] T obj, CancellationToken cancellationToken);
    public delegate ValueTask AsyncActionAt<in T>([AllowNull] T obj, int position, CancellationToken cancellationToken);

    public delegate bool PredicateAt<in T>([AllowNull] T obj, int position);
    public delegate bool PredicateAtLong<in T>([AllowNull] T obj, long position);

    public delegate ValueTask<bool> AsyncPredicate<in T>([AllowNull] T obj, CancellationToken cancellationToken);
    public delegate ValueTask<bool> AsyncPredicateAt<in T>([AllowNull] T obj, int position, CancellationToken cancellationToken);
    public delegate ValueTask<bool> AsyncPredicateAtLong<in T>([AllowNull] T obj, long position, CancellationToken cancellationToken);

    [return: MaybeNull] public delegate TResult Selector<in TSource, TResult>([AllowNull] TSource obj);
    [return: MaybeNull] public delegate TResult SelectorAt<in TSource, TResult>([AllowNull] TSource obj, int position);
    [return: MaybeNull] public delegate TResult SelectorAtLong<in TSource, TResult>([AllowNull] TSource obj, long position);

    public delegate ValueTask<TResult> AsyncSelector<in TSource, TResult>([AllowNull] TSource obj, CancellationToken cancellationToken);
    public delegate ValueTask<TResult> AsyncSelectorAt<in TSource, TResult>([AllowNull] TSource obj, int position, CancellationToken cancellationToken);
    public delegate ValueTask<TResult> AsyncSelectorAtLong<in TSource, TResult>([AllowNull] TSource obj, long position, CancellationToken cancellationToken);
}