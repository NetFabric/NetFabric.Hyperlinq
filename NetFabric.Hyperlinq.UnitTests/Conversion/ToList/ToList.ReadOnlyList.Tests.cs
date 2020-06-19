using System;
using System.Collections.Generic;
using System.Linq;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.ToList
{
    public class ReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void ToList_Skip_Take_With_ReadOnlyList_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skipCount)
                .Take(takeCount)
                .ToList();

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .ToList();

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void ToList_Skip_Take_With_List_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsList(source);
            var expected = Enumerable
                .Skip(source, skipCount)
                .Take(takeCount)
                .ToList();

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .ToList();

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Fact]
        public void ToList_Predicate_With_Null_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap.AsReadOnlyList(source);
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => _ = ReadOnlyListExtensions
                .Where(wrapped, predicate)
                .ToList();

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void ToList_Skip_Take_Predicate_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skipCount)
                .Take(takeCount)
                .Where(predicate.AsFunc())
                .ToList();

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Where(predicate)
                .ToList();

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Fact]
        public void ToList_PredicateAt_With_Null_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap.AsReadOnlyList(source);
            var predicate = (PredicateAt<int>)null;

            // Act
            Action action = () => _ = ReadOnlyListExtensions
                .Where(wrapped, predicate)
                .ToList();

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtMultiple), MemberType = typeof(TestData))]
        public void ToList_Skip_Take_PredicateAt_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skipCount)
                .Take(takeCount)
                .Where(predicate.AsFunc())
                .ToList();

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Where(predicate)
                .ToList();

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Fact]
        public void ToList_Selector_With_Null_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap.AsReadOnlyList(source);
            var selector = (NullableSelector<int, string>)null;

            // Act
            Action action = () => _ = ReadOnlyListExtensions
                .Select(wrapped, selector)
                .ToList();

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "selector");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorMultiple), MemberType = typeof(TestData))]
        public void ToList_Skip_Take_Selector_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, NullableSelector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skipCount)
                .Take(takeCount)
                .Select(selector.AsFunc())
                .ToList();

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Select(selector)
                .ToList();

            // Assert
            _ = result.Must()
                .BeOfType<List<string>>()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }

        [Fact]
        public void ToList_SelectorAt_With_Null_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap.AsReadOnlyList(source);
            var selector = (NullableSelectorAt<int, string>)null;

            // Act
            Action action = () => _ = ReadOnlyListExtensions
                .Select(wrapped, selector)
                .ToList();

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "selector");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorAtMultiple), MemberType = typeof(TestData))]
        public void ToList_Skip_Take_SelectorAt_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, NullableSelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skipCount)
                .Take(takeCount)
                .Select(selector.AsFunc())
                .ToList();

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Select(selector)
                .ToList();

            // Assert
            _ = result.Must()
                .BeOfType<List<string>>()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void ToList_Skip_Take_Predicate_Selector_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, Predicate<int> predicate, NullableSelector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skipCount)
                .Take(takeCount)
                .Where(predicate.AsFunc())
                .Select(selector.AsFunc())
                .ToArray();

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Where(predicate)
                .Select(selector)
                .ToList();

            // Assert
            _ = result.Must()
                .BeOfType<List<string>>()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }
    }
}