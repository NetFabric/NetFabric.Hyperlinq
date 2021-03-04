using NetFabric.Assertive;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.SingleAsync
{
    public class AsyncValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        public async void SingleAsync_With_Empty_Must_Return_None(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var result = await wrapped
                .SingleAsync<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        public async ValueTask SingleAsync_With_SingleAsync_Must_Return_Some(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Single(source);

            // Act
            var result = await wrapped
                .SingleAsync<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>()
                .ConfigureAwait(false);

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected), 
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async void SingleAsync_With_Multiple_Must_Return_None(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var result = await wrapped
                .SingleAsync<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
         }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        public async void SingleAsync_Predicate_With_Empty_Must_Return_None(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var result = await wrapped
                .Where<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(predicate.AsAsync())
                .SingleAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        public async ValueTask SingleAsync_Predicate_With_SingleAsync_Must_Return_Some(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Single(source, predicate);

            // Act
            var result = await wrapped
                .Where<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(predicate.AsAsync())
                .SingleAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected), 
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public async void SingleAsync_Predicate_With_Multiple_Must_Return_None(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var result = await wrapped
                .Where<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(predicate.AsAsync())
                .SingleAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
         }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        public async void SingleAsync_PredicateAt_With_Empty_Must_Return_None(int[] source, Func<int, int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var result = await wrapped
                .Where<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(predicate.AsAsync())
                .SingleAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        public async ValueTask SingleAsync_PredicateAt_With_SingleAsync_Must_Return_Some(int[] source, Func<int, int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Where(source, predicate)
                .Single();

            // Act
            var result = await wrapped
                .Where<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(predicate.AsAsync())
                .SingleAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected), 
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public async void SingleAsync_PredicateAt_With_Multiple_Must_Return_None(int[] source, Func<int, int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var result = await wrapped
                .Where<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(predicate.AsAsync())
                .SingleAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
         }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        public async void SingleAsync_Selector_With_Empty_Must_Return_None(int[] source, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var result = await wrapped
                .Select<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int, string>(selector.AsAsync())
                .SingleAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        public async ValueTask SingleAsync_Selector_With_SingleAsync_Must_Return_Some(int[] source, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Select(source, selector)
                .Single();

            // Act
            var result = await wrapped
                .Select<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int, string>(selector.AsAsync())
                .SingleAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected), 
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public async void SingleAsync_Selector_With_Multiple_Must_Return_None(int[] source, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var result = await wrapped
                .Select<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int, string>(selector.AsAsync())
                .SingleAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        public async void SingleAsync_SelectorAt_With_Empty_Must_Return_None(int[] source, Func<int, int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var result = await wrapped
                .Select<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int, string>(selector.AsAsync())
                .SingleAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        public async ValueTask SingleAsync_SelectorAt_With_SingleAsync_Must_Return_Some(int[] source, Func<int, int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Select(source, selector)
                .Single();

            // Act
            var result = await wrapped
                .Select<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int, string>(selector.AsAsync())
                .SingleAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected), 
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public async void SingleAsync_SelectorAt_With_Multiple_Must_Return_None(int[] source, Func<int, int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var result = await wrapped
                .Select<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int, string>(selector.AsAsync())
                .SingleAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
         }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        public async void SingleAsync_Predicate_Selector_With_Empty_Must_Return_None(int[] source, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var result = await AsyncValueEnumerableExtensions
                .Where<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .Select(selector.AsAsync())
                .SingleAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        public async ValueTask SingleAsync_Predicate_Selector_With_SingleAsync_Must_Return_Some(int[] source, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Where(source, predicate)
                .Select(selector)
                .Single();

            // Act
            var result = await AsyncValueEnumerableExtensions
                .Where<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .Select(selector.AsAsync())
                .SingleAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected), 
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public async void SingleAsync_Predicate_Selector_With_Multiple_Must_Return_None(int[] source, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            var result = await AsyncValueEnumerableExtensions
                .Where<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .Select(selector.AsAsync())
                .SingleAsync()
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeOfType<Option<string>>()
                .EvaluateTrue(option => option.IsNone);
         }
    }
}
