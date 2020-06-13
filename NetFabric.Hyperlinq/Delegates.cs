using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public delegate void ActionAt<in TSource>([AllowNull] TSource obj, int index);

    public delegate ValueTask AsyncAction<in TSource>([AllowNull] TSource obj, CancellationToken cancellationToken);
    public delegate ValueTask AsyncActionAt<in TSource>([AllowNull] TSource obj, int index, CancellationToken cancellationToken);

    public delegate bool PredicateAt<in TSource>([AllowNull] TSource obj, int index);

    public delegate ValueTask<bool> AsyncPredicate<in TSource>([AllowNull] TSource obj, CancellationToken cancellationToken);
    public delegate ValueTask<bool> AsyncPredicateAt<in TSource>([AllowNull] TSource obj, int index, CancellationToken cancellationToken);

    public delegate TResult Selector<in TSource, TResult>([AllowNull] TSource obj);
    public delegate TResult SelectorAt<in TSource, TResult>([AllowNull] TSource obj, int index);

    [return: MaybeNull] public delegate TResult NullableSelector<in TSource, TResult>([AllowNull] TSource obj);
    [return: MaybeNull] public delegate TResult NullableSelectorAt<in TSource, TResult>([AllowNull] TSource obj, int index);

    public delegate ValueTask<TResult> AsyncSelector<in TSource, TResult>([AllowNull] TSource obj, CancellationToken cancellationToken);
    public delegate ValueTask<TResult> AsyncSelectorAt<in TSource, TResult>([AllowNull] TSource obj, int index, CancellationToken cancellationToken);
}