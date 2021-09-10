using NetFabric.Assertive;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.ElementAtAsync
{
    public class AsyncValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async void ElementAtAsync_With_OutOfRange_Must_Return_None(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var optionNegative = await wrapped.AsAsyncValueEnumerable()
                .ElementAtAsync(-1)
                .ConfigureAwait(false);
            var optionTooLarge = await wrapped.AsAsyncValueEnumerable()
                .ElementAtAsync(source.Length)
                .ConfigureAwait(false);

            // Assert
            _ = optionNegative.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
            _ = optionTooLarge.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async Task ElementAtAsync_With_ValidData_Must_Return_Some(int[] source)
        {
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            for (var index = 0; index < source.Length; index++)
            {
                // Arrange
                var expected = source
                    .ElementAt(index);

                // Act
                var result = await wrapped.AsAsyncValueEnumerable()
                    .ElementAtAsync(index)
                    .ConfigureAwait(false);

                // Assert
                _ = result.Match(
                    value => value.Must().BeEqualTo(expected),
                    () => throw new Exception());
            }
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public async void ElementAtAsync_Predicate_With_OutOfRange_Must_Return_None(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var optionNegative = await wrapped.AsAsyncValueEnumerable()
                .Where(predicate.AsAsync())
                .ElementAtAsync(-1)
                .ConfigureAwait(false);
            var optionTooLarge = await wrapped.AsAsyncValueEnumerable()
                .Where(predicate.AsAsync())
                .ElementAtAsync(source.Length)
                .ConfigureAwait(false);

            // Assert
            _ = optionNegative.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
            _ = optionTooLarge.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public async Task ElementAtAsync_Predicate_With_ValidData_Must_Return_Some(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = source
                .Where(predicate)
                .ToList();

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = await wrapped.AsAsyncValueEnumerable()
                    .Where(predicate.AsAsync())
                    .ElementAtAsync(index)
                    .ConfigureAwait(false);

                // Assert
                _ = result.Match(
                    value => value.Must().BeEqualTo(expected[index]),
                    () => throw new Exception());
            }
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public async void ElementAtAsync_PredicateAt_With_OutOfRange_Must_Return_None(int[] source, Func<int, int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var optionNegative = await wrapped.AsAsyncValueEnumerable()
                .Where(predicate.AsAsync())
                .ElementAtAsync(-1)
                .ConfigureAwait(false);
            var optionTooLarge = await wrapped.AsAsyncValueEnumerable()
                .Where(predicate.AsAsync())
                .ElementAtAsync(source.Length)
                .ConfigureAwait(false);

            // Assert
            _ = optionNegative.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
            _ = optionTooLarge.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public async Task ElementAtAsync_PredicateAt_With_ValidData_Must_Return_Some(int[] source, Func<int, int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = source
                .Where(predicate)
                .ToList();

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = await wrapped.AsAsyncValueEnumerable()
                    .Where(predicate.AsAsync())
                    .ElementAtAsync(index)
                    .ConfigureAwait(false);

                // Assert
                _ = result.Match(
                    value => value.Must().BeEqualTo(expected[index]),
                    () => throw new Exception());
            }
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public async void ElementAtAsync_Selector_With_OutOfRange_Must_Return_None(int[] source, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var optionNegative = await wrapped.AsAsyncValueEnumerable()
                .Select(selector.AsAsync())
                .ElementAtAsync(-1)
                .ConfigureAwait(false);
            var optionTooLarge = await wrapped.AsAsyncValueEnumerable()
                .Select(selector.AsAsync())
                .ElementAtAsync(source.Length)
                .ConfigureAwait(false);

            // Assert
            _ = optionNegative.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
            _ = optionTooLarge.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public async Task ElementAtAsync_Selector_With_ValidData_Must_Return_Some(int[] source, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = source
                .Select(selector)
                .ToList();

            for (var index = 0; index < source.Length; index++)
            {
                // Act
                var result = await wrapped.AsAsyncValueEnumerable()
                    .Select(selector.AsAsync())
                    .ElementAtAsync(index)
                    .ConfigureAwait(false);

                // Assert
                _ = result.Match(
                    value => value.Must().BeEqualTo(expected[index]),
                    () => throw new Exception());
            }
        }
        
        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public async void ElementAtAsync_SelectorAt_With_OutOfRange_Must_Return_None(int[] source, Func<int, int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var optionNegative = await wrapped.AsAsyncValueEnumerable()
                .Select(selector.AsAsync())
                .ElementAtAsync(-1)
                .ConfigureAwait(false);
            var optionTooLarge = await wrapped.AsAsyncValueEnumerable()
                .Select(selector.AsAsync())
                .ElementAtAsync(source.Length)
                .ConfigureAwait(false);

            // Assert
            _ = optionNegative.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
            _ = optionTooLarge.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public async Task ElementAtAsync_SelectorAt_With_ValidData_Must_Return_Some(int[] source, Func<int, int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = source
                .Select(selector)
                .ToList();

            for (var index = 0; index < source.Length; index++)
            {
                // Act
                var result = await wrapped.AsAsyncValueEnumerable()
                    .Select(selector.AsAsync())
                    .ElementAtAsync(index)
                    .ConfigureAwait(false);

                // Assert
                _ = result.Match(
                    value => value.Must().BeEqualTo(expected[index]),
                    () => throw new Exception());
            }
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public async void ElementAtAsync_Predicate_Selector_With_OutOfRange_Must_Return_None(int[] source, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var optionNegative = await wrapped.AsAsyncValueEnumerable()
                .Where(predicate.AsAsync())
                .Select(selector.AsAsync())
                .ElementAtAsync(-1)
                .ConfigureAwait(false);
            var optionTooLarge = await wrapped.AsAsyncValueEnumerable()
                .Where(predicate.AsAsync())
                .Select(selector.AsAsync())
                .ElementAtAsync(source.Length)
                .ConfigureAwait(false);

            // Assert
            _ = optionNegative.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
            _ = optionTooLarge.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public async Task ElementAtAsync_Predicate_Selector_With_ValidData_Must_Return_Some(int[] source, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = source
                .Where(predicate)
                .Select(selector)
                .ToList();

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = await wrapped.AsAsyncValueEnumerable()
                    .Where(predicate.AsAsync())
                    .Select(selector.AsAsync())
                    .ElementAtAsync(index)
                    .ConfigureAwait(false);

                // Assert
                _ = result.Match(
                    value => value.Must().BeEqualTo(expected[index]),
                    () => throw new Exception());
            }
        }
    }
}
