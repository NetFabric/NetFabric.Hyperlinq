using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public interface IFunction<out TResult>
    {
        [Pure]
        TResult Invoke();
    }

    public interface IFunction<in T, out TResult>
    {
        [Pure]
        TResult Invoke(T arg);
    }

    public interface IFunction<in T1, in T2, out TResult>
    {
        [Pure]
        TResult Invoke(T1 arg1, T2 arg2);
    }

    public interface IFunction<in T1, in T2, in T3, out TResult>
    {
        [Pure]
        TResult Invoke(T1 arg1, T2 arg2, T3 arg3);
    }

    public interface IFunction<in T1, in T2, in T3, in T4, out TResult>
    {
        [Pure]
        TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4);
    }

    public interface IFunction<in T1, in T2, in T3, in T4, in T5, out TResult>
    {
        [Pure]
        TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
    }

    public interface IFunction<in T1, in T2, in T3, in T4, in T5, in T6, out TResult>
    {
        [Pure]
        TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);
    }

    public interface IFunction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, out TResult>
    {
        [Pure]
        TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7);
    }

    public interface IFunction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, out TResult>
    {
        [Pure]
        TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8);
    }

    public interface IFunction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, out TResult>
    {
        [Pure]
        TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9);
    }
}
