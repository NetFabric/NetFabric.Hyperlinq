using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using System.Linq;
using System.Threading.Tasks;

namespace LinqBenchmarks.AsyncEnumerable.FatReferenceType
{
    public class AsyncEnumerableFatReferenceTypeFirstOrDefault: AsyncEnumerableFatReferenceTypeBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public async ValueTask<bool> ForeachLoop()
        {
            await foreach (var _ in source)
            {
                return true;
            }

            return false;
        }
        
        [Benchmark]        
        public async ValueTask<bool> Linq()
            => await source.FirstOrDefaultAsync() is not null;
        
        [Benchmark]
        public async ValueTask<bool> Hyperlinq()
            => (await source
                .AsAsyncValueEnumerable()
                .FirstAsync()).IsSome;
    }
}
