namespace NetFabric.Hyperlinq
{
    public interface IFunctionIn<T, out TResult>
    {
        TResult Invoke(in T arg);
    }

    public interface IFunctionIn<T1, in T2, out TResult>
    {
        TResult Invoke(in T1 arg1, T2 arg2);
    }
}
