using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public interface IAsyncValueEnumerable<out T, TEnumerator>
        : IAsyncEnumerable<T>
        where TEnumerator : struct, IAsyncEnumerator<T>
    {
        new TEnumerator GetAsyncEnumerator(CancellationToken cancellationToken = default);
    }

    public interface IAsyncValueReadOnlyCollection<out T, TEnumerator>
        : IAsyncValueEnumerable<T, TEnumerator>
        where TEnumerator : struct, IAsyncEnumerator<T>
    {
        ValueTask<int> GetCountAsync(CancellationToken cancellationToken = default);
    }
}