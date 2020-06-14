using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace NetFabric.Hyperlinq
{
    public interface IAsyncValueEnumerable<out T, TEnumerator>
        : IAsyncEnumerable<T>
        where TEnumerator : struct, IAsyncEnumerator<T>
    {
        [return: NotNull] new TEnumerator GetAsyncEnumerator(CancellationToken cancellationToken = default);
    }
}