using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Quantifier.All
{
    public class ReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void All_With_ValidData_Must_Succeed(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.All(wrapped, predicate);

            // Act
            var result = ReadOnlyListExtensions
                .All<Wrap.ValueReadOnlyListWrapper<int>, int>(wrapped, predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void All_Skip_Take_Predicate_With_ValidData_Must_Succeed(int[] source, int skip, int take, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.All(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(source, skip), take), predicate);

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ValueReadOnlyListWrapper<int>, int>(wrapped, skip)
                .Take(take)
                .All(predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void All_PredicateAt_With_ValidData_Must_Succeed(int[] source, Func<int, int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Count(
                    System.Linq.Enumerable.Where(source, predicate)) == source.Length;

            // Act
            var result = ReadOnlyListExtensions
                .All<Wrap.ValueReadOnlyListWrapper<int>, int>(wrapped, predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtMultiple), MemberType = typeof(TestData))]
        public void All_Skip_Take_PredicateAt_With_ValidData_Must_Succeed(int[] source, int skip, int take, Func<int, int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var count = 
                System.Linq.Enumerable.Count(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(source, skip), take));
            var expected = 
                System.Linq.Enumerable.Count(
                    System.Linq.Enumerable.Where(
                        System.Linq.Enumerable.Take(
                            System.Linq.Enumerable.Skip(source, skip), take), predicate)) == count;

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ValueReadOnlyListWrapper<int>, int>(wrapped, skip)
                .Take(take)
                .All(predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}