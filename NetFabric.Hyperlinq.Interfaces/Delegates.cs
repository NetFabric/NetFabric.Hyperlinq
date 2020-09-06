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

    public delegate TResult Selector<in TSource, TResult>([AllowNull] TSource obj) where TResult : notnull;
    public delegate TResult SelectorAt<in TSource, TResult>([AllowNull] TSource obj, int index) where TResult : notnull;

    [return: MaybeNull] public delegate TResult NullableSelector<in TSource, TResult>([AllowNull] TSource obj);
    [return: MaybeNull] public delegate TResult NullableSelectorAt<in TSource, TResult>([AllowNull] TSource obj, int index);

    public delegate ValueTask<TResult> AsyncSelector<in TSource, TResult>([AllowNull] TSource obj, CancellationToken cancellationToken);
    public delegate ValueTask<TResult> AsyncSelectorAt<in TSource, TResult>([AllowNull] TSource obj, int index, CancellationToken cancellationToken);

    public interface IPredicate<TSource>
    {
        bool Invoke([AllowNull] TSource item);
    } 

    public interface IPredicateAt<TSource>
    {
        bool Invoke([AllowNull] TSource item, int index);
    } 

    public interface IAsyncPredicate<TSource>
    {
        ValueTask<bool> InvokeAsync([AllowNull] TSource item, CancellationToken cancellationToken);
    } 

    public interface IAsyncPredicateAt<TSource>
    {
        ValueTask<bool> InvokeAsync([AllowNull] TSource item, int index, CancellationToken cancellationToken);
    } 

    public interface ISelector<TSource, TResult>
    {
        TResult Invoke([AllowNull] TSource item);
    } 

    public interface ISelectorAt<TSource, TResult>
    {
        TResult Invoke([AllowNull] TSource item, int index);
    } 

    public interface INullableSelector<TSource, TResult>
    {
        [return: MaybeNull] TResult Invoke([AllowNull] TSource item);
    } 

    public interface INullableSelectorAt<TSource, TResult>
    {
        [return: MaybeNull] TResult Invoke([AllowNull] TSource item, int index);
    }

    public interface IAsyncSelector<TSource, TResult>
    {
        ValueTask<TResult> InvokeAsync([AllowNull] TSource item, CancellationToken cancellationToken);
    } 

    public interface IAsyncSelectorAt<TSource, TResult>
    {
        ValueTask<TResult> InvokeAsync([AllowNull] TSource item, int index, CancellationToken cancellationToken);
    } 
}