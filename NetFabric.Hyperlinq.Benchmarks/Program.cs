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
                typeof(IndexerBenchmarks),
                typeof(VirtualCallBenchmarks),
                typeof(CastBenchmarks),
                typeof(LambdaBenchmarks),
                //typeof(GenerationOperationsBenchmarks),
                typeof(EmptyBenchmarks),
                typeof(CountBenchmarks),
                typeof(CountPredicateBenchmarks),
                typeof(LongCountBenchmarks),
                typeof(LongCountPredicateBenchmarks),
                typeof(AllBenchmarks),
                typeof(AnyBenchmarks),
                typeof(AnyPredicateBenchmarks),
                typeof(ContainsBenchmarks),
                typeof(ContainsComparerBenchmarks),
                typeof(DistinctBenchmarks),
                typeof(DistinctComparerBenchmarks),
                typeof(ElementAtBenchmarks),
                typeof(FirstBenchmarks),
                typeof(FirstPredicateBenchmarks),
                typeof(FirstOrDefaultBenchmarks),
                typeof(FirstOrDefaultPredicateBenchmarks),
                typeof(SingleBenchmarks),
                typeof(SinglePredicateBenchmarks),
                typeof(SingleOrDefaultBenchmarks),
                typeof(ToArrayBenchmarks),
                typeof(ToListBenchmarks),
                typeof(SelectBenchmarks),
                typeof(SelectManyBenchmarks),
                typeof(SelectCountBenchmarks),
                typeof(SelectToArrayBenchmarks),
                typeof(SelectToListBenchmarks),
                typeof(WhereBenchmarks),
                typeof(WhereCountBenchmarks),
                typeof(WhereFirstBenchmarks),
                typeof(WhereFirstOrDefaultBenchmarks),
                typeof(WhereSingleBenchmarks),
                typeof(WhereSingleOrDefaultBenchmarks),
                typeof(WhereBenchmarks),
                typeof(WhereWhereBenchmarks),
                typeof(WhereToListBenchmarks),
                typeof(WhereSelectBenchmarks),
                typeof(WhereSelectCountBenchmarks),
                typeof(ImmutableArrayBenchmarks),
                typeof(LinkedListBenchmarks),
            });
            switcher.Run(args);        
        }
    }
}
