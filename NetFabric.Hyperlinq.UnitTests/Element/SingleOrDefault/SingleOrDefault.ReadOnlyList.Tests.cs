using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.SingleOrDefault
{
    public class ReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        public void SingleOrDefault_With_Empty_Or_Single_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyList(source);
            var expected =
                System.Linq.Enumerable.SingleOrDefault(source);

            // Act
            var result = ReadOnlyList
                .SingleOrDefault<Wrap.ValueReadOnlyList<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void SingleOrDefault_With_Multiple_Must_Throw(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyList(source);

            // Act
            Action action = () => _ = ReadOnlyList
                .SingleOrDefault<Wrap.ValueReadOnlyList<int>, int>(wrapped);

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        public void SingleOrDefault_Skip_Take_With_Empty_Or_Single_Must_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyList(source);
            var expected =
                System.Linq.Enumerable.SingleOrDefault(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(source, skipCount), takeCount));

            // Act
            var result = ReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .SingleOrDefault();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void SingleOrDefault_Skip_Take_With_Multiple_Must_Throw(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyList(source);

            // Act
            Action action = () => _ = ReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .SingleOrDefault();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        public void SingleOrDefault_Skip_Take_Predicate_With_Empty_Or_Single_Must_Succeed(int[] source, int skipCount, int takeCount, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyList(source);
            var expected =
                System.Linq.Enumerable.SingleOrDefault(
                    System.Linq.Enumerable.Where(
                        System.Linq.Enumerable.Take(
                            System.Linq.Enumerable.Skip(source, skipCount), takeCount), predicate.AsFunc()));

            // Act
            var result = ReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Where(predicate)
                .SingleOrDefault();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void SingleOrDefault_Skip_Take_Predicate_With_Multiple_Must_Throw(int[] source, int skipCount, int takeCount, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyList(source);

            // Act
            Action action = () => _ = ReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Where(predicate)
                .SingleOrDefault();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtSingle), MemberType = typeof(TestData))]
        public void SingleOrDefault_Skip_Take_PredicateAt_With_Empty_Or_Single_Must_Succeed(int[] source, int skipCount, int takeCount, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyList(source);
            var expected =
                System.Linq.Enumerable.SingleOrDefault(
                    System.Linq.Enumerable.Where(
                        System.Linq.Enumerable.Take(
                            System.Linq.Enumerable.Skip(source, skipCount), takeCount), predicate.AsFunc()));

            // Act
            var result = ReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Where(predicate)
                .SingleOrDefault();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtMultiple), MemberType = typeof(TestData))]
        public void SingleOrDefault_Skip_Take_PredicateAt_With_Multiple_Must_Throw(int[] source, int skipCount, int takeCount, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyList(source);

            // Act
            Action action = () => _ = ReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Where(predicate)
                .SingleOrDefault();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorSingle), MemberType = typeof(TestData))]
        public void SingleOrDefault_Skip_Take_Selector_With_Empty_Or_Single_Must_Succeed(int[] source, int skipCount, int takeCount, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyList(source);
            var expected =
                System.Linq.Enumerable.SingleOrDefault(
                    System.Linq.Enumerable.Select(
                        System.Linq.Enumerable.Take(
                            System.Linq.Enumerable.Skip(source, skipCount), takeCount), selector.AsFunc()));

            // Act
            var result = ReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Select(selector)
                .SingleOrDefault();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorMultiple), MemberType = typeof(TestData))]
        public void SingleOrDefault_Skip_Take_Selector_With_Multiple_Must_Throw(int[] source, int skipCount, int takeCount, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyList(source);

            // Act
            Action action = () => _ = ReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Select(selector)
                .SingleOrDefault();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorAtSingle), MemberType = typeof(TestData))]
        public void SingleOrDefault_Skip_Take_SelectorAt_With_Empty_Or_Single_Must_Succeed(int[] source, int skipCount, int takeCount, SelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyList(source);
            var expected =
                System.Linq.Enumerable.SingleOrDefault(
                    System.Linq.Enumerable.Select(
                        System.Linq.Enumerable.Take(
                            System.Linq.Enumerable.Skip(source, skipCount), takeCount), selector.AsFunc()));

            // Act
            var result = ReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Select(selector)
                .SingleOrDefault();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorAtMultiple), MemberType = typeof(TestData))]
        public void SingleOrDefault_Skip_Take_SelectorAt_With_Multiple_Must_Throw(int[] source, int skipCount, int takeCount, SelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyList(source);

            // Act
            Action action = () => _ = ReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Select(selector)
                .SingleOrDefault();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorSingle), MemberType = typeof(TestData))]
        public void SingleOrDefault_Skip_Take_Predicate_Selector_With_Empty_Or_Single_Must_Succeed(int[] source, int skipCount, int takeCount, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyList(source);
            var expected =
                System.Linq.Enumerable.SingleOrDefault(
                    System.Linq.Enumerable.Select(
                        System.Linq.Enumerable.Where(
                            System.Linq.Enumerable.Take(
                                System.Linq.Enumerable.Skip(source, skipCount), takeCount), predicate.AsFunc()), selector.AsFunc()));

            // Act
            var result = ReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Where(predicate)
                .Select(selector)
                .SingleOrDefault();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void SingleOrDefault_Skip_Take_Predicate_Selector_With_Multiple_Must_Throw(int[] source, int skipCount, int takeCount, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyList(source);

            // Act
            Action action = () => _ = ReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Where(predicate)
                .Select(selector)
                .SingleOrDefault();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }
    }
}