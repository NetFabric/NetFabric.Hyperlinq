namespace NetFabric.Hyperlinq
{
    public interface IFunction<in T, out TResult>
    {
        TResult Invoke(T arg);
    }
}
