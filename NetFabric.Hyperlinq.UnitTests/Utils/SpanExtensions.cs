using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.UnitTests
{
    static class SpanExtensions
    {
        public static bool SequenceEqual<T>(this Span<T> first, IEnumerable<T> second)
            => SequenceEqual((ReadOnlySpan<T>)first, second);

        public static bool SequenceEqual<T>(this ReadOnlySpan<T> first, IEnumerable<T> second, IEqualityComparer<T> comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;

            using var enumerator = second.GetEnumerator();
            for (var index = 0; true; index++)
            {
                var resultEnded = index == first.Length;
                var expectedEnded = !enumerator.MoveNext();

                if (resultEnded != expectedEnded)
                    return false;

                if (resultEnded)
                    return true;

                if (!comparer.Equals(first[index], enumerator.Current))
                    return false;
            }
        }
    }
}
