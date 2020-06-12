using System;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.ToArray
{
    public class ReadOnlyMemoryTests
    {
        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void ToArray_With_Predicate_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.ToArray(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            // Act
            var result = ArrayExtensions
                .Where<int>((ReadOnlyMemory<int>)source.AsMemory(), predicate)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void ToArray_With_PredicateAt_Must_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.ToArray(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            // Act
            var result = ArrayExtensions
                .Where<int>((ReadOnlyMemory<int>)source.AsMemory(), predicate)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void ToArray_With_Selector_Must_Succeed(int[] source, Selector<int, string> selector)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.ToArray(
                    System.Linq.Enumerable.Select(source, selector.AsFunc()));

            // Act
            var result = ArrayExtensions
                .Select<int, string>((ReadOnlyMemory<int>)source.AsMemory(), selector)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void ToArray_With_SelectorAt_Must_Succeed(int[] source, SelectorAt<int, string> selector)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.ToArray(
                    System.Linq.Enumerable.Select(source, selector.AsFunc()));

            // Act
            var result = ArrayExtensions
                .Select<int, string>((ReadOnlyMemory<int>)source.AsMemory(), selector)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void ToArray_With_Predicate_Selector_Must_Succeed(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.ToArray(
                    System.Linq.Enumerable.Select(
                        System.Linq.Enumerable.Where(source, predicate.AsFunc()), selector.AsFunc()));

            // Act
            var result = ArrayExtensions
                .Where<int>((ReadOnlyMemory<int>)source.AsMemory(), predicate)
                .Select(selector)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<string>()
                .BeEqualTo(expected);
        }
    }
}