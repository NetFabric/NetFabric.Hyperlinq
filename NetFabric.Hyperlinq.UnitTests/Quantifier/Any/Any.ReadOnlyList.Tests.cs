using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Quantifier.Any
{
    public class ReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void Any_With_ValidData_Must_Succeed(int[] source, int skip, int take)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skip)
                .Take(take)
                .Any();

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ValueReadOnlyListWrapper<int>, int>(wrapped, skip)
                .Take(take)
                .Any();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
        
        [Fact]
        public void Any_Predicate_With_Null_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => _ = ReadOnlyListExtensions
                .Where<Wrap.ValueReadOnlyListWrapper<int>, int>(wrapped, predicate)
                .Any();

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void Any_Predicate_With_ValidData_Must_Succeed(int[] source, int skip, int take, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skip)
                .Take(take)
                .Where(predicate.AsFunc())
                .Any();

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ValueReadOnlyListWrapper<int>, int>(wrapped, skip)
                .Take(take)
                .Any(predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
        
        [Fact]
        public void Any_PredicateAt_With_Null_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var predicate = (PredicateAt<int>)null;

            // Act
            Action action = () => _ = ReadOnlyListExtensions
                .Where<Wrap.ValueReadOnlyListWrapper<int>, int>(wrapped, predicate)
                .Any();

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtMultiple), MemberType = typeof(TestData))]
        public void Any_PredicateAt_With_ValidData_Must_Succeed(int[] source, int skip, int take, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skip)
                .Take(take)
                .Where(predicate.AsFunc())
                .Any();

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ValueReadOnlyListWrapper<int>, int>(wrapped, skip)
                .Take(take)
                .Where(predicate)
                .Any();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}