using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.Single
{
    public class ReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        public void Single_With_Empty_Must_Return_None(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);

            // Act
            var result = ReadOnlyListExtensions
                .Single<Wrap.ReadOnlyListWrapper<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        public void Single_With_Single_Must_Return_Some(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);
            var expected = Enumerable
                .Single(source);

            // Act
            var result = ReadOnlyListExtensions
                .Single<Wrap.ReadOnlyListWrapper<int>, int>(wrapped);

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected),
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Single_With_Multiple_Must_Return_None(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);

            // Act
            var result = ReadOnlyListExtensions
                .Single<Wrap.ReadOnlyListWrapper<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        public void Single_SkipTake_With_Empty_Must_Return_None(int[] source, int skip, int take)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skip)
                .Take(take)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        public void Single_SkipTake_With_Single_Must_Return_Some(int[] source, int skip, int take)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skip)
                .Take(take)
                .Single();

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skip)
                .Take(take)
                .Single();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected),
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void Single_SkipTake_With_Multiple_Must_Return_None(int[] source, int skip, int take)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skip)
                .Take(take)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateEmpty), MemberType = typeof(TestData))]
        public void Single_Predicate_With_Empty_Must_Return_None(int[] source, int skip, int take, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skip)
                .Take(take)
                .Where(predicate)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        public void Single_Predicate_With_Single_Must_Return_Some(int[] source, int skip, int take, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skip)
                .Take(take)
                .Single(predicate.AsFunc());

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skip)
                .Take(take)
                .Where(predicate)
                .Single();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected),
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void Single_Predicate_With_Multiple_Must_Return_None(int[] source, int skip, int take, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skip)
                .Take(take)
                .Where(predicate)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtEmpty), MemberType = typeof(TestData))]
        public void Single_PredicateAt_With_Empty_Must_Return_None(int[] source, int skip, int take, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skip)
                .Take(take)
                .Where(predicate)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtSingle), MemberType = typeof(TestData))]
        public void Single_PredicateAt_With_Single_Must_Return_Some(int[] source, int skip, int take, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skip)
                .Take(take)
                .Where(predicate.AsFunc())
                .Single();

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skip)
                .Take(take)
                .Where(predicate)
                .Single();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected),
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtMultiple), MemberType = typeof(TestData))]
        public void Single_PredicateAt_With_Multiple_Must_Return_None(int[] source, int skip, int take, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skip)
                .Take(take)
                .Where(predicate)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorEmpty), MemberType = typeof(TestData))]
        public void Single_Selector_With_Empty_Must_Return_None(int[] source, int skip, int take, NullableSelector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skip)
                .Take(take)
                .Select(selector)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorSingle), MemberType = typeof(TestData))]
        public void Single_Selector_With_Single_Must_Return_Some(int[] source, int skip, int take, NullableSelector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skip)
                .Take(take)
                .Select(selector.AsFunc())
                .Single();

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skip)
                .Take(take)
                .Select(selector)
                .Single();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected),
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorMultiple), MemberType = typeof(TestData))]
        public void Single_Selector_With_Multiple_Must_Return_None(int[] source, int skip, int take, NullableSelector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skip)
                .Take(take)
                .Select(selector)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorAtEmpty), MemberType = typeof(TestData))]
        public void Single_SelectorAt_With_Empty_Must_Return_None(int[] source, int skip, int take, NullableSelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skip)
                .Take(take)
                .Select(selector)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorAtSingle), MemberType = typeof(TestData))]
        public void Single_SelectorAt_With_Single_Must_Return_Some(int[] source, int skip, int take, NullableSelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skip)
                .Take(take)
                .Select(selector.AsFunc())
                .Single();

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skip)
                .Take(take)
                .Select(selector)
                .Single();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected),
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorAtMultiple), MemberType = typeof(TestData))]
        public void Single_SelectorAt_With_Multiple_Must_Return_None(int[] source, int skip, int take, NullableSelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skip)
                .Take(take)
                .Select(selector)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorEmpty), MemberType = typeof(TestData))]
        public void Single_Predicate_Selector_With_Empty_Must_Return_None(int[] source, int skip, int take, Predicate<int> predicate, NullableSelector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skip)
                .Take(take)
                .Where(predicate)
                .Select(selector)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorSingle), MemberType = typeof(TestData))]
        public void Single_Predicate_Selector_With_Single_Must_Return_Some(int[] source, int skip, int take, Predicate<int> predicate, NullableSelector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
               .AsReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skip)
                .Take(take)
                .Where(predicate.AsFunc())
                .Select(selector.AsFunc())
                .Single();

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skip)
                .Take(take)
                .Where(predicate)
                .Select(selector)
                .Single();

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected),
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void Single_Predicate_Selector_With_Multiple_Must_Return_None(int[] source, int skip, int take, Predicate<int> predicate, NullableSelector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skip)
                .Take(take)
                .Where(predicate)
                .Select(selector)
                .Single();

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }
    }
}