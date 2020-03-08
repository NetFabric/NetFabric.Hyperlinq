using NetFabric.Assertive;
using System;
using System.Threading.Tasks;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.FirstAsync
{
    public class AsyncValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        public void FirstAsync_With_Empty_Must_Throw(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            Func<ValueTask> action = async () => _ = await AsyncValueEnumerable
                .FirstAsync<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped);

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async ValueTask FirstAsync_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected =
                System.Linq.Enumerable.First(source);

            // Act
            var result = await AsyncValueEnumerable
                .FirstAsync<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        public void FirstAsync_Predicate_With_Empty_Must_Throw(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            Func<ValueTask> action = async () => _ = await AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .FirstAsync();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public async ValueTask FirstAsync_Predicate_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected =
                System.Linq.Enumerable.First(source, predicate.AsFunc());

            // Act
            var result = await AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .FirstAsync();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        public void FirstAsync_PredicateAt_With_Empty_Must_Throw(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            Func<ValueTask> action = async () => _ = await AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .FirstAsync();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public async ValueTask FirstAsync_PredicateAt_With_ValidData_Must_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected =
                System.Linq.Enumerable.First(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            // Act
            var result = await AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .FirstAsync();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        public void FirstAsync_Selector_With_Empty_Must_Throw(int[] source, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            Func<ValueTask> action = async () => _ = await AsyncValueEnumerable
                .Select<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int, string>(wrapped, selector.AsAsync())
                .FirstAsync();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public async ValueTask FirstAsync_Selector_With_ValidData_Must_Succeed(int[] source, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected =
                System.Linq.Enumerable.First(
                    System.Linq.Enumerable.Select(source, selector.AsFunc()));

            // Act
            var result = await AsyncValueEnumerable
                .Select<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int, string>(wrapped, selector.AsAsync())
                .FirstAsync();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        public void FirstAsync_SelectorAt_With_Empty_Must_Throw(int[] source, SelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            Func<ValueTask> action = async () => _ = await AsyncValueEnumerable
                .Select<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int, string>(wrapped, selector.AsAsync())
                .FirstAsync();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public async ValueTask FirstAsync_SelectorAt_With_ValidData_Must_Succeed(int[] source, SelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected =
                System.Linq.Enumerable.First(
                    System.Linq.Enumerable.Select(source, selector.AsFunc()));

            // Act
            var result = await AsyncValueEnumerable
                .Select<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int, string>(wrapped, selector.AsAsync())
                .FirstAsync();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        public void FirstAsync_Predicate_Selector_With_Empty_Must_Throw(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);

            // Act
            Func<ValueTask> action = async () => _ = await AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .Select(selector.AsAsync())
                .FirstAsync();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public async ValueTask FirstAsync_Predicate_Selector_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsAsyncValueEnumerable(source);
            var expected =
                System.Linq.Enumerable.First(
                    System.Linq.Enumerable.Select(
                        System.Linq.Enumerable.Where(source, predicate.AsFunc()), selector.AsFunc()));

            // Act
            var result = await AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .Select(selector.AsAsync())
                .FirstAsync();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}