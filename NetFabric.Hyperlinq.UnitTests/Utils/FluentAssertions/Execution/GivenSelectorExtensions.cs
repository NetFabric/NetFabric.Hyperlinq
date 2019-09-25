using System;
using System.Collections;
using System.Collections.Generic;

namespace FluentAssertions.Execution
{
    static class GivenSelectorExtensions
    {
        public static ContinuationOfGiven<IEnumerable> AssertForEachEnumerablesHaveSameItems(
            this GivenSelector<object> givenSelector, IEnumerable expected, Func<object, IEnumerable, int> findIndex)
            => givenSelector
                .Given<IEnumerable>(actual => new ObjectEnumerableWithIndex(actual, findIndex(actual, expected)))
                .ForCondition(diff => diff.As<ObjectEnumerableWithIndex>().Index < 0)
                .FailWith("but {0} differs at index {1} when using 'foreach'.",
                    diff => diff,
                    diff => diff.As<ObjectEnumerableWithIndex>().Index);

        public static ContinuationOfGiven<ICollection<TActual>> AssertCollectionsHaveSameItems<TActual, TExpected>(this GivenSelector<ICollection<TActual>> givenSelector,
            ICollection<TExpected> expected, Func<ICollection<TActual>, ICollection<TExpected>, int> findIndex)
        {
            return givenSelector
                .Given<ICollection<TActual>>(actual => new CollectionWithIndex<TActual>(actual, findIndex(actual, expected)))
                .ForCondition(diff => diff.As<CollectionWithIndex<TActual>>().Index == -1)
                .FailWith("but {0} differs at index {1}.",
                    diff => diff.As<CollectionWithIndex<TActual>>().Items,
                    diff => diff.As<CollectionWithIndex<TActual>>().Index);
        }

        sealed class ObjectEnumerableWithIndex : Primitives.ObjectAssertions2.ObjectEnumerable
        {
            public int Index { get; }

            public ObjectEnumerableWithIndex(object items, int index) : base(items)
            {
                Index = index;
            }
        }

        sealed class CollectionWithIndex<T> : ICollection<T>
        {
            public ICollection<T> Items { get; }

            public int Index { get; }

            public CollectionWithIndex(ICollection<T> items, int index)
            {
                Items = items;
                Index = index;
            }

            public int Count => Items.Count;

            public bool IsReadOnly => Items.IsReadOnly;

            public void Add(T item) => Items.Add(item);

            public void Clear() => Items.Clear();

            public bool Contains(T item) => Items.Contains(item);

            public void CopyTo(T[] array, int arrayIndex) => Items.CopyTo(array, arrayIndex);

            public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();

            public bool Remove(T item) => Items.Remove(item);

            IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();
        }
    }
}
