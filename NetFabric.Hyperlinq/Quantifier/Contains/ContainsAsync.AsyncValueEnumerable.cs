using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerableExtensions
    {
        public static async ValueTask<bool> ContainsAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, [AllowNull] TSource value, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSource : struct
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    if (EqualityComparer<TSource>.Default.Equals(enumerator.Current, value!))
                        return true;
                }
            }
            return false;
        }

        public static ValueTask<bool> ContainsAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, [AllowNull] TSource value, IEqualityComparer<TSource>? comparer = default, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (Utils.UseDefault(comparer))
                return DefaultContainsAsync(source, value, cancellationToken);

            comparer ??= EqualityComparer<TSource>.Default;
            return ComparerContainsAsync(source, value, comparer, cancellationToken);

            static async ValueTask<bool> DefaultContainsAsync(TEnumerable source, [AllowNull] TSource value, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (EqualityComparer<TSource>.Default.Equals(enumerator.Current, value!))
                            return true;
                    }
                }
                return false;
            }

            static async ValueTask<bool> ComparerContainsAsync(TEnumerable source, [AllowNull] TSource value, IEqualityComparer<TSource> comparer, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (comparer.Equals(enumerator.Current, value!))
                            return true;
                    }
                }
                return false;
            }
        }
    }
}
