using System;
using System.Collections;
using System.Collections.Generic;

namespace FluentAssertions.Execution
{
    static class GivenSelectorExtensions
    {
        public static ContinuationOfGiven<IEnumerable> AssertNonGenericEnumerablesHaveSameItems(
            this GivenSelector<IEnumerable> givenSelector, IEnumerable expected, Func<IEnumerable, IEnumerable, int> findIndex)
            => givenSelector
                .Given<IEnumerable>(actual => new EnumerableWithIndex(actual, findIndex(actual, expected)))
                .ForCondition(diff => diff.As<EnumerableWithIndex>().Index < 0)
                .FailWith("but {0} differs at index {1} when using IEnumerator.",
                    diff => diff.As<EnumerableWithIndex>().Items,
                    diff => diff.As<EnumerableWithIndex>().Index);

        public static ContinuationOfGiven<IEnumerable<T>> AssertEnumerablesHaveSameItems<T>(this GivenSelector<IEnumerable<T>> givenSelector,
            IEnumerable<T> expected, Func<IEnumerable<T>, IEnumerable<T>, int> findIndex)
            => givenSelector
                .Given<IEnumerable<T>>(actual => new EnumerableWithIndex<T>(actual, findIndex(actual, expected)))
                .ForCondition(diff => diff.As<EnumerableWithIndex<T>>().Index < 0)
                .FailWith("but {0} differs at index {1} when using IEnumerator<>.",
                    diff => diff.As<EnumerableWithIndex<T>>().Items,
                    diff => diff.As<EnumerableWithIndex<T>>().Index);

        public static ContinuationOfGiven<IReadOnlyCollection<T>> AssertCollectionHasCountCorrect<T>(this GivenSelector<IReadOnlyCollection<T>> givenSelector)
            => givenSelector
                .Given<IReadOnlyCollection<T>>(actual => new ReadOnlyCollectionWithEnumerableCount<T>(actual))
                .ForCondition(diff => diff.As<ReadOnlyCollectionWithEnumerableCount<T>>().EnumerableCount == diff.As<ReadOnlyCollectionWithEnumerableCount<T>>().Count)
                .FailWith("but it returns {1} when it has {2} items.",
                    diff => diff.As<ReadOnlyCollectionWithEnumerableCount<T>>().EnumerableCount,
                    diff => diff.As<ReadOnlyCollectionWithEnumerableCount<T>>().Count);

        public static ContinuationOfGiven<IReadOnlyList<T>> AssertListsHaveSameItems<T>(this GivenSelector<IReadOnlyList<T>> givenSelector,
            IEnumerable<T> expected, Func<IReadOnlyList<T>, IEnumerable<T>, int> findIndex)
            => givenSelector
                .Given<IReadOnlyList<T>>(actual => new ReadOnlyListWithIndex<T>(actual, findIndex(actual, expected)))
                .ForCondition(diff => diff.As<ReadOnlyListWithIndex<T>>().Index < 0)
                .FailWith("but {0} differs at index {1} when using the indexer.",
                    diff => diff.As<ReadOnlyListWithIndex<T>>().Items,
                    diff => diff.As<ReadOnlyListWithIndex<T>>().Index);

        sealed class EnumerableWithIndex : IEnumerable
        {
            public IEnumerable Items { get; }

            public int Index { get; }

            public EnumerableWithIndex(IEnumerable items, int index)
            {
                Items = items;
                Index = index;
            }

            public IEnumerator GetEnumerator() => Items.GetEnumerator();
        }

        sealed class EnumerableWithIndex<T> : IEnumerable<T>
        {
            public IEnumerable<T> Items { get; }

            public int Index { get; }

            public EnumerableWithIndex(IEnumerable<T> items, int index)
            {
                Items = items;
                Index = index;
            }

            public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();
        }

        sealed class ReadOnlyCollectionWithEnumerableCount<T> : IReadOnlyCollection<T>
        {
            public IReadOnlyCollection<T> Items { get; }

            public int EnumerableCount { get; }

            public ReadOnlyCollectionWithEnumerableCount(IReadOnlyCollection<T> items)
            {
                Items = items;

                using var enumerator = items.GetEnumerator();
                var count = 0;
                checked
                {
                    while (enumerator.MoveNext())
                        count++;
                }

                EnumerableCount = count;
            }

            public int Count => Items.Count;

            public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();
        }

        sealed class ReadOnlyListWithIndex<T> : IReadOnlyList<T>
        {
            public IReadOnlyList<T> Items { get; }

            public int Index { get; }

            public ReadOnlyListWithIndex(IReadOnlyList<T> items, int index)
            {
                Items = items;
                Index = index;
            }

            public T this[int index] => Items[index];

            public int Count => Items.Count;

            public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();
        }
    }
}
