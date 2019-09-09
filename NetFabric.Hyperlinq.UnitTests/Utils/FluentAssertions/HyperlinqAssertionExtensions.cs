using FluentAssertions.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace FluentAssertions
{
    [DebuggerNonUserCode]
    public static class HyperlinqAssertionExtensions
    {
        public static EnumerableAssertions<T> Must<T>(this IEnumerable<T> actualValue)
            => new EnumerableAssertions<T>(actualValue);

        public static ReadOnlyCollectionAssertions<T> Must<T>(this IReadOnlyCollection<T> actualValue)
            => new ReadOnlyCollectionAssertions<T>(actualValue);

        public static ReadOnlyListAssertions<T> Must<T>(this IReadOnlyList<T> actualValue)
            => new ReadOnlyListAssertions<T>(actualValue);
    }
}
