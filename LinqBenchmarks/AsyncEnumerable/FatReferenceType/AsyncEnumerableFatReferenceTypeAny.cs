using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using System.Linq;
using System.Threading.Tasks;

namespace LinqBenchmarks.AsyncEnumerable.FatReferenceType
{
    public class AsyncEnumerableFatReferenceTypeAny: AsyncEnumerableFatReferenceTypeBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public ValueTask<bool> Linq()
            => source.AnyAsync();
        
        [Benchmark]
        public ValueTask<bool> Hyperlinq()
            => source
                .AsAsyncValueEnumerable()
                .AnyAsync();
    }
}
