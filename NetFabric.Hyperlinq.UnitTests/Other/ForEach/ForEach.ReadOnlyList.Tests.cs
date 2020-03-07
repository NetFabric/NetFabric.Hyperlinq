using NetFabric.Assertive;
using System;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Other.ForEach
{
    public class ReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ForEach_Action_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var result = new List<int>();
            var expected = new List<int>();
            System.Linq.EnumerableEx.ForEach(source, item => expected.Add(item));

            // Act
            ReadOnlyList
                .ForEach<Wrap.ReadOnlyList<int>, int>(wrapped, item => result.Add(item));

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void ForEach_Action_Predicate_With_ValidData_Must_Succeed(int[] source, int skipTake, int takeCount, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var result = new List<int>();
            var expected = new List<int>();
            System.Linq.EnumerableEx.ForEach(
                System.Linq.Enumerable.Where(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(source, skipTake), takeCount), predicate.AsFunc()), item => expected.Add(item));

            // Act
            ReadOnlyList
                .Skip<Wrap.ReadOnlyList<int>, int>(wrapped, skipTake)
                .Take(takeCount)
                .Where(predicate)
                .ForEach(item => result.Add(item));

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtMultiple), MemberType = typeof(TestData))]
        public void ForEach_Action_PredicateAt_With_ValidData_Must_Succeed(int[] source, int skipTake, int takeCount, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var result = new List<int>();
            var expected = new List<int>();
            System.Linq.EnumerableEx.ForEach(
                System.Linq.Enumerable.Where(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(source, skipTake), takeCount), predicate.AsFunc()), item => expected.Add(item));

            // Act
            ReadOnlyList
                .Skip<Wrap.ReadOnlyList<int>, int>(wrapped, skipTake)
                .Take(takeCount)
                .Where(predicate)
                .ForEach(item => result.Add(item));

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorMultiple), MemberType = typeof(TestData))]
        public void ForEach_Action_Selector_With_ValidData_Must_Succeed(int[] source, int skipTake, int takeCount, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var result = new List<string>();
            var expected = new List<string>();
            System.Linq.EnumerableEx.ForEach(
                System.Linq.Enumerable.Select(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(source, skipTake), takeCount), selector.AsFunc()), item => expected.Add(item));

            // Act
            ReadOnlyList
                .Skip<Wrap.ReadOnlyList<int>, int>(wrapped, skipTake)
                .Take(takeCount)
                .Select(selector)
                .ForEach(item => result.Add(item));

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorAtMultiple), MemberType = typeof(TestData))]
        public void ForEach_Action_SelectorAt_With_ValidData_Must_Succeed(int[] source, int skipTake, int takeCount, SelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var result = new List<string>();
            var expected = new List<string>();
            System.Linq.EnumerableEx.ForEach(
                System.Linq.Enumerable.Select(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(source, skipTake), takeCount), selector.AsFunc()), item => expected.Add(item));

            // Act
            ReadOnlyList
                .Skip<Wrap.ReadOnlyList<int>, int>(wrapped, skipTake)
                .Take(takeCount)
                .Select(selector)
                .ForEach(item => result.Add(item));

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void ForEach_Action_Predicate_Selector_With_ValidData_Must_Succeed(int[] source, int skipTake, int takeCount, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var result = new List<string>();
            var expected = new List<string>();
            System.Linq.EnumerableEx.ForEach(
                System.Linq.Enumerable.Select(
                    System.Linq.Enumerable.Where(
                        System.Linq.Enumerable.Take(
                            System.Linq.Enumerable.Skip(source, skipTake), takeCount), predicate.AsFunc()), selector.AsFunc()), item => expected.Add(item));

            // Act
            ReadOnlyList
                .Skip<Wrap.ReadOnlyList<int>, int>(wrapped, skipTake)
                .Take(takeCount)
                .Where(predicate)
                .Select(selector)
                .ForEach(item => result.Add(item));

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }

        /////////////////////////////
        // ActionAt

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ForEach_ActionAt_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var result = new List<(int, int)>();
            var expected = new List<(int, int)>();
            System.Linq.EnumerableEx.ForEach(source, (item, index) => expected.Add((item, index)));

            // Act
            ReadOnlyList
                .ForEach<Wrap.ReadOnlyList<int>, int>(wrapped, (item, index) => result.Add((item, index)));

            // Assert
            _ = result.Must()
                .BeEnumerableOf<(int, int)>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void ForEach_ActionAt_Predicate_With_ValidData_Must_Succeed(int[] source, int skipTake, int takeCount, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var result = new List<(int, int)>();
            var expected = new List<(int, int)>();
            System.Linq.EnumerableEx.ForEach(
                System.Linq.Enumerable.Where(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(source, skipTake), takeCount), predicate.AsFunc()), (item, index) => expected.Add((item, index)));

            // Act
            ReadOnlyList
                .Skip<Wrap.ReadOnlyList<int>, int>(wrapped, skipTake)
                .Take(takeCount)
                .Where(predicate)
                .ForEach((item, index) => result.Add((item, index)));

            // Assert
            _ = result.Must()
                .BeEnumerableOf<(int, int)>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtMultiple), MemberType = typeof(TestData))]
        public void ForEach_ActionAt_PredicateAt_With_ValidData_Must_Succeed(int[] source, int skipTake, int takeCount, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var result = new List<(int, int)>();
            var expected = new List<(int, int)>();
            System.Linq.EnumerableEx.ForEach(
                System.Linq.Enumerable.Where(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(source, skipTake), takeCount), predicate.AsFunc()), (item, index) => expected.Add((item, index)));

            // Act
            ReadOnlyList
                .Skip<Wrap.ReadOnlyList<int>, int>(wrapped, skipTake)
                .Take(takeCount)
                .Where(predicate)
                .ForEach((item, index) => result.Add((item, index)));

            // Assert
            _ = result.Must()
                .BeEnumerableOf<(int, int)>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorMultiple), MemberType = typeof(TestData))]
        public void ForEach_ActionAt_Selector_With_ValidData_Must_Succeed(int[] source, int skipTake, int takeCount, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var result = new List<(string, int)>();
            var expected = new List<(string, int)>();
            System.Linq.EnumerableEx.ForEach(
                System.Linq.Enumerable.Select(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(source, skipTake), takeCount), selector.AsFunc()), (item, index) => expected.Add((item, index)));

            // Act
            ReadOnlyList
                .Skip<Wrap.ReadOnlyList<int>, int>(wrapped, skipTake)
                .Take(takeCount)
                .Select(selector)
                .ForEach((item, index) => result.Add((item, index)));

            // Assert
            _ = result.Must()
                .BeEnumerableOf<(string, int)>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorAtMultiple), MemberType = typeof(TestData))]
        public void ForEach_ActionAt_SelectorAt_With_ValidData_Must_Succeed(int[] source, int skipTake, int takeCount, SelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var result = new List<(string, int)>();
            var expected = new List<(string, int)>();
            System.Linq.EnumerableEx.ForEach(
                System.Linq.Enumerable.Select(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(source, skipTake), takeCount), selector.AsFunc()), (item, index) => expected.Add((item, index)));

            // Act
            ReadOnlyList
                .Skip<Wrap.ReadOnlyList<int>, int>(wrapped, skipTake)
                .Take(takeCount)
                .Select(selector)
                .ForEach((item, index) => result.Add((item, index)));

            // Assert
            _ = result.Must()
                .BeEnumerableOf<(string, int)>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void ForEach_ActionAt_Predicate_Selector_With_ValidData_Must_Succeed(int[] source, int skipTake, int takeCount, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var result = new List<(string, int)>();
            var expected = new List<(string, int)>();
            System.Linq.EnumerableEx.ForEach(
                System.Linq.Enumerable.Select(
                    System.Linq.Enumerable.Where(
                        System.Linq.Enumerable.Take(
                            System.Linq.Enumerable.Skip(source, skipTake), takeCount), predicate.AsFunc()), selector.AsFunc()), (item, index) => expected.Add((item, index)));

            // Act
            ReadOnlyList
                .Skip<Wrap.ReadOnlyList<int>, int>(wrapped, skipTake)
                .Take(takeCount)
                .Where(predicate)
                .Select(selector)
                .ForEach((item, index) => result.Add((item, index)));

            // Assert
            _ = result.Must()
                .BeEnumerableOf<(string, int)>()
                .BeEqualTo(expected);
        }
    }
}