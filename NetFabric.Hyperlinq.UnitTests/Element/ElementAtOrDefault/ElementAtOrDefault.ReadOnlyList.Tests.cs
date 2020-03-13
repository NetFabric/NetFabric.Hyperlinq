using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.ElementAtOrDefault
{
    public class ReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ElementAtOrDefault_With_ValidData_Must_Succeed(int[] source)
        {
            for (var index = -1; index <= source.Length; index++)
            {
                // Arrange
                var wrapped = Wrap.AsValueReadOnlyList(source);
                var expected = 
                    System.Linq.Enumerable.ElementAtOrDefault(source, index);

                // Act
                var result = ReadOnlyList
                    .ElementAtOrDefault<Wrap.ValueReadOnlyList<int>, int>(wrapped, index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(expected);
            }
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void ElementAtOrDefault_Skip_Take_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(source, skipCount), takeCount));

            for (var index = -1; index <= expected.Count; index++)
            {
                // Act
                var result = ReadOnlyList
                    .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
                    .Take(takeCount)
                    .ElementAtOrDefault(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(System.Linq.Enumerable.ElementAtOrDefault(expected, index));
            }
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void ElementAtOrDefault_Skip_Take_Predicate_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Where(
                        System.Linq.Enumerable.Take(
                            System.Linq.Enumerable.Skip(source, skipCount), takeCount), predicate.AsFunc()));

            for (var index = -1; index <= expected.Count; index++)
            {
                // Act
                var result = ReadOnlyList
                    .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
                    .Take(takeCount)
                    .Where(predicate)
                    .ElementAtOrDefault(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(System.Linq.Enumerable.ElementAtOrDefault(expected, index));
            }
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtMultiple), MemberType = typeof(TestData))]
        public void ElementAtOrDefault_Skip_Take_PredicateAt_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Where(
                        System.Linq.Enumerable.Take(
                            System.Linq.Enumerable.Skip(source, skipCount), takeCount), predicate.AsFunc()));

            for (var index = -1; index <= expected.Count; index++)
            {
                // Act
                var result = ReadOnlyList
                    .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
                    .Take(takeCount)
                    .Where(predicate)
                    .ElementAtOrDefault(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(System.Linq.Enumerable.ElementAtOrDefault(expected, index));
            }
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorMultiple), MemberType = typeof(TestData))]
        public void ElementAtOrDefault_Skip_Take_Selector_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(
                        System.Linq.Enumerable.Take(
                            System.Linq.Enumerable.Skip(source, skipCount), takeCount), selector.AsFunc()));

            for (var index = -1; index <= expected.Count; index++)
            {
                // Act
                var result = ReadOnlyList
                    .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
                    .Take(takeCount)
                    .Select(selector)
                    .ElementAtOrDefault(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(System.Linq.Enumerable.ElementAtOrDefault(expected, index));
            }
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorAtMultiple), MemberType = typeof(TestData))]
        public void ElementAtOrDefault_Skip_Take_SelectorAt_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, SelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(
                        System.Linq.Enumerable.Take(
                            System.Linq.Enumerable.Skip(source, skipCount), takeCount), selector.AsFunc()));

            for (var index = -1; index <= expected.Count; index++)
            {
                // Act
                var result = ReadOnlyList
                    .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
                    .Take(takeCount)
                    .Select(selector)
                    .ElementAtOrDefault(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(System.Linq.Enumerable.ElementAtOrDefault(expected, index));
            }
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void ElementAtOrDefault_Skip_Take_Predicate_Selector_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(
                        System.Linq.Enumerable.Where(
                            System.Linq.Enumerable.Take(
                                System.Linq.Enumerable.Skip(source, skipCount), takeCount), predicate.AsFunc()), selector.AsFunc()));

            for (var index = -1; index <= expected.Count; index++)
            {
                // Act
                var result = ReadOnlyList
                    .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
                    .Take(takeCount)
                    .Where(predicate)
                    .Select(selector)
                    .ElementAtOrDefault(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(System.Linq.Enumerable.ElementAtOrDefault(expected, index));
            }
        }
    }
}