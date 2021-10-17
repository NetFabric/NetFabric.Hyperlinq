using System.Threading.Tasks;

namespace LinqBenchmarks.AsyncEnumerable.FatReferenceType;

public class AsyncEnumerableFatReferenceTypeAnyAsync: AsyncEnumerableFatReferenceTypeBenchmarkBase
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
    public ValueTask<bool> Linq()
        => source.AnyAsync();
        
    [Benchmark]
    public ValueTask<bool> Hyperlinq()
        => source
            .AsAsyncValueEnumerable()
            .AnyAsync();
}