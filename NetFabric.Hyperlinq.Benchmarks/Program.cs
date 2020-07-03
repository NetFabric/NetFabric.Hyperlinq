using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace NetFabric.Hyperlinq.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var switcher = new BenchmarkSwitcher(new[] {
                typeof(ValueEnumerableBenchmarks),
                typeof(AsyncEnumerableBenchmarks),
                typeof(BoundsBenchmarks),
                typeof(IndexerBenchmarks),
                typeof(VirtualCallBenchmarks),
                typeof(CastBenchmarks),
                typeof(LambdaBenchmarks),
                //typeof(GenerationOperationsBenchmarks),
                typeof(EmptyBenchmarks),
                typeof(CountBenchmarks),
                typeof(AllBenchmarks),
                typeof(AnyBenchmarks),
                typeof(AnyPredicateBenchmarks),
                typeof(ContainsBenchmarks),
                typeof(ContainsDefaultComparerBenchmarks),
                typeof(ContainsComparerBenchmarks),
                typeof(DistinctBenchmarks),
                typeof(ElementAtBenchmarks),
                typeof(FirstBenchmarks),
                typeof(SingleBenchmarks),
                typeof(ToArrayBenchmarks),
                typeof(ToArrayMemoryPoolBenchmarks),
                typeof(ToListBenchmarks),
                typeof(ToArrayVsToListBenchmarks),
                typeof(SelectBenchmarks),
                typeof(SelectManyBenchmarks),
                typeof(SelectCountBenchmarks),
                typeof(SelectToArrayBenchmarks),
                typeof(SelectToListBenchmarks),
                typeof(WhereBenchmarks),
                typeof(WhereCountBenchmarks),
                typeof(WhereFirstBenchmarks),
                typeof(WhereSingleBenchmarks),
                typeof(WhereBenchmarks),
                typeof(WhereWhereBenchmarks),
                typeof(WhereToArrayBenchmarks),
                typeof(WhereToArrayArrayPoolBenchmarks),
                typeof(WhereToListBenchmarks),
                typeof(WhereSelectBenchmarks),
                typeof(WhereSelectCountBenchmarks),
                typeof(ImmutableArrayBenchmarks),
                typeof(LinkedListBenchmarks),
                typeof(RangeWhereSelectToArrayBenchmarks),
                typeof(RangeSelectDistinctToListBenchmarks),
                typeof(RangeSelectDistinctToArrayBenchmarks),
                typeof(ArraySkipTakeWhereSelectBenchmarks),
                typeof(ListWhereBenchmarks),
                typeof(ListSelectBenchmarks),
            });
            _ = switcher.Run(args);        
        }
    }
}
