using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.ElementAtOrDefault
{
    public class MemoryTests
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
                var expected = 
                    System.Linq.Enumerable.ElementAtOrDefault(source, index);

                // Act
                var result = Array
                    .ElementAtOrDefault<int>(source.AsMemory(), index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(expected);
            }
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void ElementAtOrDefault_Predicate_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            for (var index = -1; index <= expected.Count; index++)
            {
                // Act
                var result = Array
                    .Where<int>(source.AsMemory(), predicate)
                    .ElementAtOrDefault(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(System.Linq.Enumerable.ElementAtOrDefault(expected, index));
            }
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void ElementAtOrDefault_PredicateAt_With_ValidData_Must_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            for (var index = -1; index <= expected.Count; index++)
            {
                // Act
                var result = Array
                    .Where<int>(source.AsMemory(), predicate)
                    .ElementAtOrDefault(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(System.Linq.Enumerable.ElementAtOrDefault(expected, index));
            }
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void ElementAtOrDefault_Selector_With_ValidData_Must_Succeed(int[] source, Selector<int, string> selector)
        {
            for (var index = -1; index <= source.Length; index++)
            {
                // Arrange
                var expected = 
                    System.Linq.Enumerable.ElementAtOrDefault(
                        System.Linq.Enumerable.Select(source, selector.AsFunc()), index);

                // Act
                var result = Array
                    .Select<int, string>(source.AsMemory(), selector)
                    .ElementAtOrDefault(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(expected);
            }
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void ElementAtOrDefault_SelectorAt_With_ValidData_Must_Succeed(int[] source, SelectorAt<int, string> selector)
        {
            for (var index = -1; index <= source.Length; index++)
            {
                // Arrange
                var expected = 
                    System.Linq.Enumerable.ElementAtOrDefault(
                        System.Linq.Enumerable.Select(source, selector.AsFunc()), index);

                // Act
                var result = Array
                    .Select<int, string>(source.AsMemory(), selector)
                    .ElementAtOrDefault(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(expected);
            }
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void ElementAtOrDefault_Predicate_Selector_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(
                        System.Linq.Enumerable.Where(source, predicate.AsFunc()), selector.AsFunc()));

            for (var index = -1; index <= expected.Count; index++)
            {
                // Act
                var result = Array
                    .Where<int>(source.AsMemory(), predicate)
                    .Select(selector)
                    .ElementAtOrDefault(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(System.Linq.Enumerable.ElementAtOrDefault(expected, index));
            }
        }
    }
}