using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq;

public interface IAsyncFunction<T, TResult>
{
    ValueTask<TResult> InvokeAsync(ref readonly T arg, CancellationToken cancellationToken);
}

public interface IAsyncFunction<T1, T2, TResult>
{
    ValueTask<TResult> InvokeAsync(ref readonly T1 arg1, ref readonly T2 arg2, CancellationToken cancellationToken);
}

public interface IAsyncFunction<T1, T2, T3, TResult>
{
    ValueTask<TResult> InvokeAsync(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, CancellationToken cancellationToken);
}

public interface IAsyncFunction<T1, T2, T3, T4, TResult>
{
    ValueTask<TResult> InvokeAsync(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, ref readonly T4 arg4, CancellationToken cancellationToken);
}

public interface IAsyncFunction<T1, T2, T3, T4, T5, TResult>
{
    ValueTask<TResult> InvokeAsync(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, ref readonly T4 arg4, ref readonly T5 arg5, CancellationToken cancellationToken);
}

public interface IAsyncFunction<T1, T2, T3, T4, T5, T6, TResult>
{
    ValueTask<TResult> InvokeAsync(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, ref readonly T4 arg4, ref readonly T5 arg5, ref readonly T6 arg6, CancellationToken cancellationToken);
}

public interface IAsyncFunction<T1, T2, T3, T4, T5, T6, T7, TResult>
{
    ValueTask<TResult> InvokeAsync(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, ref readonly T4 arg4, ref readonly T5 arg5, ref readonly T6 arg6, ref readonly T7 arg7, CancellationToken cancellationToken);
}

public interface IAsyncFunction<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
{
    ValueTask<TResult> InvokeAsync(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, ref readonly T4 arg4, ref readonly T5 arg5, ref readonly T6 arg6, ref readonly T7 arg7, ref readonly T8 arg8, CancellationToken cancellationToken);
}

public interface IAsyncFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
{
    ValueTask<TResult> InvokeAsync(ref readonly T1 arg1, ref readonly T2 arg2, ref readonly T3 arg3, ref readonly T4 arg4, ref readonly T5 arg5, ref readonly T6 arg6, ref readonly T7 arg7, ref readonly T8 arg8, ref readonly T9 arg9, CancellationToken cancellationToken);
}