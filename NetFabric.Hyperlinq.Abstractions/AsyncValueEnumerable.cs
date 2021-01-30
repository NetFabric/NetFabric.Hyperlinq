using System.Collections.Generic;
using System.Threading;

namespace NetFabric.Hyperlinq
{
    public interface IAsyncValueEnumerable<out T, out TEnumerator>
        : IAsyncEnumerable<T>
        where TEnumerator : struct, IAsyncEnumerator<T>
    {
        new TEnumerator GetAsyncEnumerator(CancellationToken cancellationToken = default);
    }
}