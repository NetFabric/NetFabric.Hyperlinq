using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public interface IAsyncFunction<in T, TResult>
    {
        ValueTask<TResult> InvokeAsync(T arg, CancellationToken cancellationToken);
    }

    public interface IAsyncFunction<in T1, in T2, TResult>
    {
        ValueTask<TResult> InvokeAsync(T1 arg1, T2 arg2, CancellationToken cancellationToken);
    }

    public interface IAsyncFunction<in T1, in T2, in T3, TResult>
    {
        ValueTask<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, CancellationToken cancellationToken);
    }

    public interface IAsyncFunction<in T1, in T2, in T3, in T4, TResult>
    {
        ValueTask<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, CancellationToken cancellationToken);
    }

    public interface IAsyncFunction<in T1, in T2, in T3, in T4, in T5, TResult>
    {
        ValueTask<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, CancellationToken cancellationToken);
    }

    public interface IAsyncFunction<in T1, in T2, in T3, in T4, in T5, in T6, TResult>
    {
        ValueTask<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, CancellationToken cancellationToken);
    }

    public interface IAsyncFunction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, TResult>
    {
        ValueTask<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, CancellationToken cancellationToken);
    }

    public interface IAsyncFunction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, TResult>
    {
        ValueTask<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, CancellationToken cancellationToken);
    }

    public interface IAsyncFunction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, TResult>
    {
        ValueTask<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, CancellationToken cancellationToken);
    }
}
