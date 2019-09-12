using FluentAssertions.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace FluentAssertions.Execution
{
    static class GivenSelectorExtensions
    {
        public static ContinuationOfGiven<IEnumerable> AssertForEachEnumerablesHaveSameItems(
            this GivenSelector<object> givenSelector, IEnumerable expected, Func<object, IEnumerable, int> findIndex)
            => givenSelector
                .Given<IEnumerable>(actual => new ForEachEnumerableWithIndex(actual, findIndex(actual, expected)))
                .ForCondition(diff => diff.As<ForEachEnumerableWithIndex>().Index < 0)
                .FailWith("but {0} differs at index {1} when using 'foreach'.",
                    diff => diff,
                    diff => diff.As<ForEachEnumerableWithIndex>().Index);

        public static ContinuationOfGiven<IEnumerable> AssertNonGenericEnumerablesHaveSameItems(
            this GivenSelector<IEnumerable> givenSelector, IEnumerable expected, Func<IEnumerable, IEnumerable, int> findIndex)
            => givenSelector
                .Given<IEnumerable>(actual => new NonGenericEnumerableWithIndex(actual, findIndex(actual, expected)))
                .ForCondition(diff => diff.As<NonGenericEnumerableWithIndex>().Index < 0)
                .FailWith("but {0} differs at index {1} when using 'IEnumerable'.",
                    diff => diff,
                    diff => diff.As<NonGenericEnumerableWithIndex>().Index);

        public static ContinuationOfGiven<IEnumerable<T>> AssertGenericEnumerablesHaveSameItems<T>(this GivenSelector<IEnumerable<T>> givenSelector,
            IEnumerable<T> expected, Func<IEnumerable<T>, IEnumerable<T>, int> findIndex)
            => givenSelector
                .Given<IEnumerable<T>>(actual => new GenericEnumerableWithIndex<T>(actual, findIndex(actual, expected)))
                .ForCondition(diff => diff.As<GenericEnumerableWithIndex<T>>().Index < 0)
                .FailWith("but {0} differs at index {1} when using 'IEnumerable<>'.",
                    diff => diff,
                    diff => diff.As<GenericEnumerableWithIndex<T>>().Index);

        public static ContinuationOfGiven<IReadOnlyCollection<T>> AssertCollectionHasCountCorrect<T>(this GivenSelector<IReadOnlyCollection<T>> givenSelector)
            => givenSelector
                .Given<IReadOnlyCollection<T>>(actual => new ReadOnlyCollectionWithEnumerableCount<T>(actual))
                .ForCondition(diff => diff.As<ReadOnlyCollectionWithEnumerableCount<T>>().EnumerableCount == diff.As<ReadOnlyCollectionWithEnumerableCount<T>>().Count)
                .FailWith("but it returns {0} when it has {1} items.",
                    diff => diff.As<ReadOnlyCollectionWithEnumerableCount<T>>().Count,
                    diff => diff.As<ReadOnlyCollectionWithEnumerableCount<T>>().EnumerableCount);

        public static ContinuationOfGiven<IReadOnlyList<T>> AssertListsHaveSameItems<T>(this GivenSelector<IReadOnlyList<T>> givenSelector,
            IEnumerable<T> expected, Func<IReadOnlyList<T>, IEnumerable<T>, int> findIndex)
            => givenSelector
                .Given<IReadOnlyList<T>>(actual => new ReadOnlyListWithIndex<T>(actual, findIndex(actual, expected)))
                .ForCondition(diff => diff.As<ReadOnlyListWithIndex<T>>().Index < 0)
                .FailWith("but {0} differs at index {1} when using the indexer.",
                    diff => diff,
                    diff => diff.As<ReadOnlyListWithIndex<T>>().Index);

        sealed class ForEachEnumerableWithIndex : IEnumerable
        {
            readonly object items;
            MethodInfo methodGetEnumerator;

            public int Index { get; }

            public ForEachEnumerableWithIndex(object items, int index)
            {
                this.items = items;
                Index = index;
            }

            public IEnumerator GetEnumerator() => new Enumerator(this);

            class Enumerator : IEnumerator, IDisposable
            {
                readonly object enumerator;
                readonly PropertyInfo propertyCurrent;
                readonly MethodInfo methodMoveNext;
                MethodInfo methodReset;
                MethodInfo methodDispose;
                bool methodResetInitialized;
                bool methodDisposeInitialized;
                object methodResetSync;
                object methodDisposeSync;

                public Enumerator(ForEachEnumerableWithIndex enumerable)
                {
                    LazyInitializer.EnsureInitialized(ref enumerable.methodGetEnumerator, () => enumerable.items.GetType().GetMethodGetEnumerator());
                    enumerator = enumerable.methodGetEnumerator.Invoke(enumerable.items, Array.Empty<object>());

                    var enumeratorType = enumerator.GetType();
                    propertyCurrent = enumeratorType.GetPropertyCurrent();
                    methodMoveNext = enumeratorType.GetMethodMoveNext();
                }

                public object Current => propertyCurrent.GetValue(enumerator);

                public bool MoveNext() => (bool)methodMoveNext.Invoke(enumerator, Array.Empty<object>());

                public void Reset()
                {
                    LazyInitializer.EnsureInitialized(ref methodReset, ref methodResetInitialized, ref methodResetSync, () => enumerator.GetType().GetMethodReset());
                    methodReset?.Invoke(enumerator, Array.Empty<object>());
                }

                public void Dispose()
                {
                    LazyInitializer.EnsureInitialized(ref methodDispose, ref methodDisposeInitialized, ref methodDisposeSync, () => enumerator.GetType().GetMethodDispose());
                    methodDispose?.Invoke(enumerator, Array.Empty<object>());
                }
            }
        }

        sealed class NonGenericEnumerableWithIndex : IEnumerable
        {
            readonly IEnumerable items;

            public int Index { get; }

            public NonGenericEnumerableWithIndex(IEnumerable items, int index)
            {
                this.items = items;
                Index = index;
            }

            public IEnumerator GetEnumerator() => items.GetEnumerator();
        }

        sealed class GenericEnumerableWithIndex<T> : IEnumerable<T>
        {
            readonly IEnumerable<T> items;

            public int Index { get; }

            public GenericEnumerableWithIndex(IEnumerable<T> items, int index)
            {
                this.items = items;
                Index = index;
            }

            public IEnumerator<T> GetEnumerator() => items.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();
        }

        sealed class ReadOnlyCollectionWithEnumerableCount<T> : IReadOnlyCollection<T> 
        {
            readonly IReadOnlyCollection<T> items;

            public int EnumerableCount { get; }

            public ReadOnlyCollectionWithEnumerableCount(IReadOnlyCollection<T> items)
            {
                this.items = items;
                EnumerableCount = 0;

                using var enumerator = items.GetEnumerator();
                checked
                {
                    while (enumerator.MoveNext())
                        EnumerableCount++;
                }
            }

            public int Count => items.Count;

            public IEnumerator<T> GetEnumerator() => items.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();
        }

        sealed class ReadOnlyListWithIndex<T> : IReadOnlyList<T>
        {
            readonly IReadOnlyList<T> items;

            public int Index { get; }
            public int EnumerableCount { get; }

            public ReadOnlyListWithIndex(IReadOnlyList<T> items, int index)
            {
                this.items = items;
                Index = index;

                using var enumerator = items.GetEnumerator();
                checked
                {
                    while (enumerator.MoveNext())
                        EnumerableCount++;
                }
            }

            public T this[int index] => items[index];

            public int Count => items.Count;

            public IEnumerator<T> GetEnumerator() => items.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();
        }
    }
}
