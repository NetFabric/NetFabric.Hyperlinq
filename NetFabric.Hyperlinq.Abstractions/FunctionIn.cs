namespace NetFabric.Hyperlinq
{
    public delegate TResult FunctionIn<T, out TResult>(in T arg);

    public delegate TResult FunctionIn<T1, in T2, out TResult>(in T1 arg, T2 arg2);
}
