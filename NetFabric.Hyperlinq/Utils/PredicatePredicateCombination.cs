using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq
{
    [StructLayout(LayoutKind.Auto)]
    public struct PredicatePredicateCombination<TPredicate1, TPredicate2, TSource>
        : IFunction<TSource, bool>
        where TPredicate1 : struct, IFunction<TSource, bool>
        where TPredicate2 : struct, IFunction<TSource, bool>
    {
        TPredicate1 first;
        TPredicate2 second;

        public PredicatePredicateCombination(TPredicate1 first, TPredicate2 second)
            => (this.first, this.second) = (first, second);

        public bool Invoke(TSource item)
            => first.Invoke(item) && second.Invoke(item);
    }
    
    [StructLayout(LayoutKind.Auto)]
    public struct PredicatePredicateAtCombination<TPredicate1, TPredicate2, TSource>
        : IFunction<TSource, int, bool>
        where TPredicate1 : struct, IFunction<TSource, bool>
        where TPredicate2 : struct, IFunction<TSource, int, bool>
    {
        TPredicate1 first;
        TPredicate2 second;

        public PredicatePredicateAtCombination(TPredicate1 first, TPredicate2 second)
            => (this.first, this.second) = (first, second);

        public bool Invoke(TSource item, int index)
            => first.Invoke(item) && second.Invoke(item, index);
    }
    
    [StructLayout(LayoutKind.Auto)]
    public struct PredicateAtPredicateAtCombination<TPredicate1, TPredicate2, TSource>
        : IFunction<TSource, int, bool>
        where TPredicate1 : struct, IFunction<TSource, int, bool>
        where TPredicate2 : struct, IFunction<TSource, int, bool>
    {
        TPredicate1 first;
        TPredicate2 second;

        public PredicateAtPredicateAtCombination(TPredicate1 first, TPredicate2 second)
            => (this.first, this.second) = (first, second);

        public bool Invoke(TSource item, int index)
            => first.Invoke(item, index) && second.Invoke(item, index);
    }
}
