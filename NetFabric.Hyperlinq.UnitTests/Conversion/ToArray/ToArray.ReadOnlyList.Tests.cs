using System;
using System.Linq;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.ToArray
{
    public class ReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void ToArray_Skip_Take_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skipCount)
                .Take(takeCount)
                .ToArray();

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ValueReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Fact]
        public void ToArray_Predicate_With_Null_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap
                .AsReadOnlyList(source);
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => _ = ReadOnlyListExtensions
                .Where(wrapped, predicate)
                .ToArray();

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void ToArray_Skip_Take_Predicate_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skipCount)
                .Take(takeCount)
                .Where(predicate.AsFunc())
                .ToArray();

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ValueReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Where(predicate)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Fact]
        public void ToArray_PredicateAt_With_Null_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap
                .AsValueReadOnlyList(source);
            var predicate = (PredicateAt<int>)null;

            // Act
            Action action = () => _ = ReadOnlyListExtensions
                .Where(wrapped, predicate)
                .ToArray();

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtMultiple), MemberType = typeof(TestData))]
        public void ToArray_Skip_Take_PredicateAt_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skipCount)
                .Take(takeCount)
                .Where(predicate.AsFunc())
                .ToArray();

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ValueReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Where(predicate)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Fact]
        public void ToArray_Selector_With_Null_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var selector = (NullableSelector<int, string>)null;

            // Act
            Action action = () => _ = ReadOnlyListExtensions
                .Select(wrapped, selector)
                .ToArray();

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "selector");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorMultiple), MemberType = typeof(TestData))]
        public void ToArray_Skip_Take_Selector_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, NullableSelector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skipCount)
                .Take(takeCount)
                .Select(selector.AsFunc())
                .ToArray();

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Select(selector)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<string>()
                .BeEqualTo(expected);
        }

        [Fact]
        public void ToArray_SelectorAt_With_Null_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap
                .AsReadOnlyList(source);
            var selector = (NullableSelectorAt<int, string>)null;

            // Act
            Action action = () => _ = ReadOnlyListExtensions
                .Select(wrapped, selector)
                .ToArray();

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "selector");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorAtMultiple), MemberType = typeof(TestData))]
        public void ToArray_Skip_Take_SelectorAt_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, NullableSelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skipCount)
                .Take(takeCount)
                .Select(selector.AsFunc())
                .ToArray();

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ValueReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Select(selector)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void ToArray_Skip_Take_Predicate_Selector_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, Predicate<int> predicate, NullableSelector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skipCount)
                .Take(takeCount)
                .Where(predicate.AsFunc())
                .Select(selector.AsFunc())
                .ToArray();

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ValueReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Where(predicate)
                .Select(selector)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<string>()
                .BeEqualTo(expected);
        }
    }
}