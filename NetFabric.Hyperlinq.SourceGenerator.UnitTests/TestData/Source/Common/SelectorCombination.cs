namespace NetFabric.Hyperlinq
{
    public readonly struct SelectorCombination<TSelector1, TSelector2, TSource, TMiddle, TResult>
        : IFunction<TSource, TResult>
        where TSelector1 : struct, IFunction<TSource, TMiddle>
        where TSelector2 : struct, IFunction<TMiddle, TResult>
    {
        readonly TSelector1 first;
        readonly TSelector2 second;

        public SelectorCombination(TSelector1 first, TSelector2 second)
            => (this.first, this.second) = (first, second);

        public TResult Invoke(TSource item)
            => second.Invoke(first.Invoke(item));
    }
}
