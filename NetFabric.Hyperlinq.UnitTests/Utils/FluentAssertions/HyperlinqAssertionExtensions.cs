using FluentAssertions.Collections;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace FluentAssertions
{
    [DebuggerNonUserCode]
    public static class HyperlinqAssertionExtensions
    {
        public static ObjectAssertions Must(this object actualValue)
            => new ObjectAssertions(actualValue);

        public static NonGenericEnumerableAssertions Must(this IEnumerable actualValue)
            => new NonGenericEnumerableAssertions(actualValue);

        public static GenericEnumerableAssertions<T> Must<T>(this IEnumerable<T> actualValue)
            => new GenericEnumerableAssertions<T>(actualValue);

        public static ReadOnlyCollectionAssertions<T> Must<T>(this IReadOnlyCollection<T> actualValue)
            => new ReadOnlyCollectionAssertions<T>(actualValue);

        public static ReadOnlyListAssertions<T> Must<T>(this IReadOnlyList<T> actualValue)
            => new ReadOnlyListAssertions<T>(actualValue);
    }
}
