using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Auto)]
    public  struct SelectorSelectorCombination<TSelector1, TSelector2, TSource, TMiddle, TResult>
        : IFunction<TSource, TResult>
        where TSelector1 : struct, IFunction<TSource, TMiddle>
        where TSelector2 : struct, IFunction<TMiddle, TResult>
    {
#pragma warning disable IDE0044 // Add readonly modifier
        TSelector1 first;
        TSelector2 second;
#pragma warning restore IDE0044 // Add readonly modifier

        public SelectorSelectorCombination(TSelector1 first, TSelector2 second)
            => (this.first, this.second) = (first, second);

        public readonly TResult Invoke(TSource item)
            => second.Invoke(first.Invoke(item));
    }
    
    [StructLayout(LayoutKind.Auto)]
    public struct SelectorAtSelectorCombination<TSelector1, TSelector2, TSource, TMiddle, TResult>
        : IFunction<TSource, int, TResult>
        where TSelector1 : struct, IFunction<TSource, int, TMiddle>
        where TSelector2 : struct, IFunction<TMiddle, TResult>
    {
#pragma warning disable IDE0044 // Add readonly modifier
        TSelector1 first;
        TSelector2 second;
#pragma warning restore IDE0044 // Add readonly modifier

        public SelectorAtSelectorCombination(TSelector1 first, TSelector2 second)
            => (this.first, this.second) = (first, second);

        public readonly TResult Invoke(TSource item, int index)
            => second.Invoke(first.Invoke(item, index));
    }
    
    [StructLayout(LayoutKind.Auto)]
    public struct SelectorSelectorAtCombination<TSelector1, TSelector2, TSource, TMiddle, TResult>
        : IFunction<TSource, int, TResult>
        where TSelector1 : struct, IFunction<TSource, TMiddle>
        where TSelector2 : struct, IFunction<TMiddle, int, TResult>
    {
#pragma warning disable IDE0044 // Add readonly modifier
        TSelector1 first;
        TSelector2 second;
#pragma warning restore IDE0044 // Add readonly modifier

        public SelectorSelectorAtCombination(TSelector1 first, TSelector2 second)
            => (this.first, this.second) = (first, second);

        public readonly TResult Invoke(TSource item, int index)
            => second.Invoke(first.Invoke(item), index);
    }
    
    
    [StructLayout(LayoutKind.Auto)]
    public struct SelectorAtSelectorAtCombination<TSelector1, TSelector2, TSource, TMiddle, TResult>
        : IFunction<TSource, int, TResult>
        where TSelector1 : struct, IFunction<TSource, int, TMiddle>
        where TSelector2 : struct, IFunction<TMiddle, int, TResult>
    {
#pragma warning disable IDE0044 // Add readonly modifier
        TSelector1 first;
        TSelector2 second;
#pragma warning restore IDE0044 // Add readonly modifier

        public SelectorAtSelectorAtCombination(TSelector1 first, TSelector2 second)
            => (this.first, this.second) = (first, second);

        public readonly TResult Invoke(TSource item, int index)
            => second.Invoke(first.Invoke(item, index), index);
    }
}
