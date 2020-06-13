using System;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.ToArray
{
    public class ReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ToArray_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ToArray(source);

            // Act
            var result = ReadOnlyListExtensions
                .ToArray<Wrap.ValueReadOnlyList<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ToArray_With_ValidData_Collections_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueCollection(source);
            var expected = 
                System.Linq.Enumerable.ToArray(source);

            // Act
            var result = ReadOnlyListExtensions
                .ToArray<Wrap.ValueCollection<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void ToArray_Skip_Take_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ToArray(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(source, skipCount), takeCount));

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
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
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => _ = ReadOnlyListExtensions
                .Where<Wrap.ValueReadOnlyList<int>, int>(wrapped, predicate)
                .ToArray();

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void ToArray_With_Predicate_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ToArray(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            // Act
            var result = ReadOnlyListExtensions
                .Where<Wrap.ValueReadOnlyList<int>, int>(wrapped, predicate)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void ToArray_Skip_Take_Predicate_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ToArray(
                    System.Linq.Enumerable.Where(
                        System.Linq.Enumerable.Take(
                            System.Linq.Enumerable.Skip(source, skipCount), takeCount), predicate.AsFunc()));

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
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
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var predicate = (PredicateAt<int>)null;

            // Act
            Action action = () => _ = ReadOnlyListExtensions
                .Where<Wrap.ValueReadOnlyList<int>, int>(wrapped, predicate)
                .ToArray();

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void ToArray_With_PredicateAt_Must_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ToArray(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            // Act
            var result = ReadOnlyListExtensions
                .Where<Wrap.ValueReadOnlyList<int>, int>(wrapped, predicate)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtMultiple), MemberType = typeof(TestData))]
        public void ToArray_Skip_Take_PredicateAt_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ToArray(
                    System.Linq.Enumerable.Where(
                        System.Linq.Enumerable.Take(
                            System.Linq.Enumerable.Skip(source, skipCount), takeCount), predicate.AsFunc()));

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
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
                .Select<Wrap.ValueReadOnlyList<int>, int, string>(wrapped, selector)
                .ToArray();

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "selector");
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void ToArray_With_Selector_Must_Succeed(int[] source, NullableSelector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ToArray(
                    System.Linq.Enumerable.Select(source, selector.AsFunc()));

            // Act
            var result = ReadOnlyListExtensions
                .Select<Wrap.ValueReadOnlyList<int>, int, string>(wrapped, selector)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorMultiple), MemberType = typeof(TestData))]
        public void ToArray_Skip_Take_Selector_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, NullableSelector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ToArray(
                    System.Linq.Enumerable.Select(
                        System.Linq.Enumerable.Take(
                            System.Linq.Enumerable.Skip(source, skipCount), takeCount), selector.AsFunc()));

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
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
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var selector = (NullableSelectorAt<int, string>)null;

            // Act
            Action action = () => _ = ReadOnlyListExtensions
                .Select<Wrap.ValueReadOnlyList<int>, int, string>(wrapped, selector)
                .ToArray();

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "selector");
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void ToArray_With_SelectorAt_Must_Succeed(int[] source, NullableSelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ToArray(
                    System.Linq.Enumerable.Select(source, selector.AsFunc()));

            // Act
            var result = ReadOnlyListExtensions
                .Select<Wrap.ValueReadOnlyList<int>, int, string>(wrapped, selector)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorAtMultiple), MemberType = typeof(TestData))]
        public void ToArray_Skip_Take_SelectorAt_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, NullableSelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ToArray(
                    System.Linq.Enumerable.Select(
                        System.Linq.Enumerable.Take(
                            System.Linq.Enumerable.Skip(source, skipCount), takeCount), selector.AsFunc()));

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Select(selector)
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
        public void ToArray_Predicate_Selector_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate, NullableSelector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ToArray(
                    System.Linq.Enumerable.Select(
                        System.Linq.Enumerable.Where(source, predicate.AsFunc()), selector.AsFunc()));

            // Act
            var result = ReadOnlyListExtensions
                .Where<Wrap.ValueReadOnlyList<int>, int>(wrapped, predicate)
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
            var expected = 
                System.Linq.Enumerable.ToArray(
                    System.Linq.Enumerable.Select(
                        System.Linq.Enumerable.Where(
                            System.Linq.Enumerable.Take(
                                System.Linq.Enumerable.Skip(source, skipCount), takeCount), predicate.AsFunc()), selector.AsFunc()));

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
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