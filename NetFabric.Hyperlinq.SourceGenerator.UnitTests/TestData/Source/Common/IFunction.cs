namespace NetFabric.Hyperlinq
{
    public interface IFunction<in T, out TResult>
    {
        TResult Invoke(T arg);
    }

    public interface IFunction<in T1, in T2, out TResult>
    {
        TResult Invoke(T1 arg1, T2 arg2);
    }

    public interface IFunction<in T1, in T2, in T3, out TResult>
    {
        TResult Invoke(T1 arg1, T2 arg2, T3 arg3);
    }
}
