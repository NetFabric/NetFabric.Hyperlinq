using NetFabric.Assertive;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.FirstAsync
{
    public class AsyncValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        public async void FirstAsync_With_Empty_Must_Return_None(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var result = await wrapped.AsAsyncValueEnumerable()
                .FirstAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async Task FirstAsync_With_ValidData_Must_Return_Some(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = source
                .First();

            // Act
            var result = await wrapped.AsAsyncValueEnumerable()
                .FirstAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected), 
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        public async void FirstAsync_Predicate_With_Empty_Must_Return_None(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var result = await wrapped.AsAsyncValueEnumerable()
                .Where(predicate.AsAsync())
                .FirstAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public async Task FirstAsync_Predicate_With_ValidData_Must_Return_Some(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = source
                .First(predicate);

            // Act
            var result = await wrapped.AsAsyncValueEnumerable()
                .Where(predicate.AsAsync())
                .FirstAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected), 
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        public async void FirstAsync_PredicateAt_With_Empty_Must_Return_None(int[] source, Func<int, int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var result = await wrapped.AsAsyncValueEnumerable()
                .Where(predicate.AsAsync())
                .FirstAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public async Task FirstAsync_PredicateAt_With_ValidData_Must_Return_Some(int[] source, Func<int, int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = source
                .Where(predicate)
                .First();

            // Act
            var result = await wrapped.AsAsyncValueEnumerable()
                .Where(predicate.AsAsync())
                .FirstAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected), 
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        public async void FirstAsync_Selector_With_Empty_Must_Return_None(int[] source, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var result = await wrapped.AsAsyncValueEnumerable()
                .Select(selector.AsAsync())
                .FirstAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public async Task FirstAsync_Selector_With_ValidData_Must_Return_Some(int[] source, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = source
                .Select(selector)
                .First();

            // Act
            var result = await wrapped.AsAsyncValueEnumerable()
                .Select(selector.AsAsync())
                .FirstAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected), 
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        public async void FirstAsync_SelectorAt_With_Empty_Must_Return_None(int[] source, Func<int, int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var result = await wrapped.AsAsyncValueEnumerable()
                .Select(selector.AsAsync())
                .FirstAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public async Task FirstAsync_SelectorAt_With_ValidData_Must_Return_Some(int[] source, Func<int, int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = source
                .Select(selector)
                .First();

            // Act
            var result = await wrapped.AsAsyncValueEnumerable()
                .Select(selector.AsAsync())
                .FirstAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected), 
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        public async void FirstAsync_Predicate_Selector_With_Empty_Must_Return_None(int[] source, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var result = await wrapped.AsAsyncValueEnumerable()
                .Where(predicate.AsAsync())
                .Select(selector.AsAsync())
                .FirstAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public async Task FirstAsync_Predicate_Selector_With_ValidData_Must_Return_Some(int[] source, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = source
                .Where(predicate)
                .Select(selector)
                .First();

            // Act
            var result = await wrapped.AsAsyncValueEnumerable()
                .Where(predicate.AsAsync())
                .Select(selector.AsAsync())
                .FirstAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected), 
                () => throw new Exception());
        }
    }
}
