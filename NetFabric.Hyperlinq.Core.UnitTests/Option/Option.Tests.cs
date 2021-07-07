using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Aggregation.Count
{
    public class OptionTests
    {
        [Fact]
        public void Option_With_None_Must_Succeed()
        {
            // Arrange
            Option<string> source = Option.None;

            // Act
            var isSome = source.IsSome;
            var isNone = source.IsNone;
            var (hasValue, _) = source;

            // Assert
            _ = isSome.Must().BeFalse();
            _ = isNone.Must().BeTrue();
            _ = hasValue.Must().BeFalse();
        }

        [Theory]
        [MemberData(nameof(TestData.OptionSome), MemberType = typeof(TestData))]
        public void Option_With_Some_Must_Succeed(string? expected)
        {
            // Arrange
            var option = Option.Some(expected);

            // Act
            var isSome = option.IsSome;
            var isNone = option.IsNone;
            var (hasValue, result) = option;

            // Assert
            _ = isSome.Must().BeTrue();
            _ = isNone.Must().BeFalse();
            _ = hasValue.Must().BeTrue();
            _ = result.Must().BeEqualTo(expected);
        }

        [Fact]
        public void Option_MatchFunc_With_None_Must_Call_None()
        {
            // Arrange
            Option<string> option = Option.None;

            // Act
            var result = option.Match(
                _ => -1,
                () => 1);

            // Assert
            _ = result.Must().BeEqualTo(1);
        }

        [Theory]
        [MemberData(nameof(TestData.OptionSome), MemberType = typeof(TestData))]
        public void Option_MatchFunc_With_Some_Must_Call_Some(string? expected)
        {
            // Arrange
            var option = Option.Some(expected);

            // Act
            var result = option.Match(
                value => value,
                () => "<NONE>");

            // Assert
            _ = result.Must().BeEqualTo(expected);
        }

        [Fact]
        public void Option_MatchAction_With_None_Must_Call_None()
        {
            // Arrange
            Option<string> option = Option.None;
            var result = 0;

            // Act
            option.Match(
                _ => result = -1,
                () => result = 1);

            // Assert
            _ = result.Must().BeEqualTo(1);
        }

        [Theory]
        [MemberData(nameof(TestData.OptionSome), MemberType = typeof(TestData))]
        public void Option_MatchActionWith_Some_Must_Call_Some(string? expected)
        {
            // Arrange
            var option = Option.Some(expected);
            var result = 0;

            // Act
            option.Match(
                _ => result = 1,
                () => result = -1);

            // Assert
            _ = result.Must().BeEqualTo(1);
        }

        [Fact]
        public void Option_Count_With_None_Must_Return_0()
        {
            // Arrange
            Option<string> option = Option.None;

            // Act
            var result = option.Count();

            // Assert
            _ = result.Must().BeEqualTo(0);
        }

        [Theory]
        [MemberData(nameof(TestData.OptionSome), MemberType = typeof(TestData))]
        public void Option_Count_With_Some_Must_Return_1(string? value)
        {
            // Arrange
            var option = Option.Some(value);

            // Act
            var result = option.Count();

            // Assert
            _ = result.Must().BeEqualTo(1);
        }

        [Fact]
        public void Option_Any_With_None_Must_Return_False()
        {
            // Arrange
            Option<string> option = Option.None;

            // Act
            var result = option.Any();

            // Assert
            _ = result.Must().BeFalse();
        }

        [Theory]
        [MemberData(nameof(TestData.OptionSome), MemberType = typeof(TestData))]
        public void Option_Any_With_Some_Must_Return_True(string? value)
        {
            // Arrange
            var option = Option.Some(value);

            // Act
            var result = option.Any();

            // Assert
            _ = result.Must().BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.OptionNoneSelectMany), MemberType = typeof(TestData))]
        public void Option_SelectMany_With_None_Must_Succeed(int[] expected)
        {
            // Arrange
            Option<string> option = Option.None;

            // Act
            var result = option.SelectMany<ArrayExtensions.ArraySegmentValueEnumerable<int>, ArrayExtensions.ArraySegmentValueEnumerable<int>.DisposableEnumerator, int>(value => expected.AsValueEnumerable());

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEmpty();
        }

        [Theory]
        [MemberData(nameof(TestData.OptionSomeSelectMany), MemberType = typeof(TestData))]
        public void Option_SelectMany_With_Some_Must_Succeed(string? value, int[] expected)
        {
            // Arrange
            var option = Option.Some(value);

            // Act
            var result = option.SelectMany<ArrayExtensions.ArraySegmentValueEnumerable<int>, ArrayExtensions.ArraySegmentValueEnumerable<int>.DisposableEnumerator, int>(value => expected.AsValueEnumerable());

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}