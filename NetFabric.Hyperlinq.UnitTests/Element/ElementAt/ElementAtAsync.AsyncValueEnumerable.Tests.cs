using NetFabric.Assertive;
using System;
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
        public void ElementAtAsync_With_OutOfRange_Must_Throw(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);

            // Act
            Action actionLess = () => _ = AsyncValueEnumerable
                .ElementAtAsync<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, -1);
            Func<ValueTask> actionGreater = async () => _ = await AsyncValueEnumerable
                .ElementAtAsync<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, source.Length);

            // Assert
            _ = actionLess.Must()
                .Throw<ArgumentOutOfRangeException>();
            _ = actionGreater.Must()
                .Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async ValueTask ElementAtAsync_With_ValidData_Must_Succeed(int[] source)
        {
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            for (var index = 0; index < source.Length; index++)
            {
                // Arrange
                var expected = 
                    System.Linq.Enumerable.ElementAt(source, index);

                // Act
                var result = await AsyncValueEnumerable
                    .ElementAtAsync<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(expected);
            }
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void ElementAtAsync_Predicate_With_OutOfRange_Must_Throw(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);

            // Act
            Action actionLess = () => _ = AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .ElementAtAsync(-1);
            Func<ValueTask> actionGreater = async () => _ = await AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .ElementAtAsync(source.Length);

            // Assert
            _ = actionLess.Must()
                .Throw<ArgumentOutOfRangeException>();
            _ = actionGreater.Must()
                .Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public async ValueTask ElementAtAsync_Predicate_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = await AsyncValueEnumerable
                    .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                    .ElementAtAsync(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(expected[index]);
            }
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void ElementAtAsync_PredicateAt_With_OutOfRange_Must_Throw(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);

            // Act
            Action actionLess = () => _ = AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .ElementAtAsync(-1);
            Func<ValueTask> actionGreater = async () => _ = await AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .ElementAtAsync(source.Length);

            // Assert
            _ = actionLess.Must()
                .Throw<ArgumentOutOfRangeException>();
            _ = actionGreater.Must()
                .Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public async ValueTask ElementAtAsync_PredicateAt_With_ValidData_Must_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = await AsyncValueEnumerable
                    .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                    .ElementAtAsync(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(expected[index]);
            }
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void ElementAtAsync_Selector_With_OutOfRange_Must_Throw(int[] source, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);

            // Act
            Action actionLess = () => _ = AsyncValueEnumerable
                .Select<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int, string>(wrapped, selector.AsAsync())
                .ElementAtAsync(-1);
            Func<ValueTask> actionGreater = async () => _ = await AsyncValueEnumerable
                .Select<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int, string>(wrapped, selector.AsAsync())
                .ElementAtAsync(source.Length);

            // Assert
            _ = actionLess.Must()
                .Throw<ArgumentOutOfRangeException>();
            _ = actionGreater.Must()
                .Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public async ValueTask ElementAtAsync_Selector_With_ValidData_Must_Succeed(int[] source, Selector<int, string> selector)
        {
            for (var index = 0; index < source.Length; index++)
            {
                // Arrange
                var wrapped = Wrap.AsAsyncValueEnumerable(source);
                var expected = 
                    System.Linq.Enumerable.ElementAt(
                        System.Linq.Enumerable.Select(source, selector.AsFunc()), index);

                // Act
                var result = await AsyncValueEnumerable
                    .Select<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int, string>(wrapped, selector.AsAsync())
                    .ElementAtAsync(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(expected);
            }
        }
        
        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void ElementAtAsync_SelectorAt_With_OutOfRange_Must_Throw(int[] source, SelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);

            // Act
            Action actionLess = () => _ = AsyncValueEnumerable
                .Select<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int, string>(wrapped, selector.AsAsync())
                .ElementAtAsync(-1);
            Func<ValueTask> actionGreater = async () => _ = await AsyncValueEnumerable
                .Select<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int, string>(wrapped, selector.AsAsync())
                .ElementAtAsync(source.Length);

            // Assert
            _ = actionLess.Must()
                .Throw<ArgumentOutOfRangeException>();
            _ = actionGreater.Must()
                .Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public async ValueTask ElementAtAsync_SelectorAt_With_ValidData_Must_Succeed(int[] source, SelectorAt<int, string> selector)
        {
            for (var index = 0; index < source.Length; index++)
            {
                // Arrange
                var wrapped = Wrap.AsAsyncValueEnumerable(source);
                var expected = 
                    System.Linq.Enumerable.ElementAt(
                        System.Linq.Enumerable.Select(source, selector.AsFunc()), index);

                // Act
                var result = await AsyncValueEnumerable
                    .Select<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int, string>(wrapped, selector.AsAsync())
                    .ElementAtAsync(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(expected);
            }
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void ElementAtAsync_Predicate_Selector_With_OutOfRange_Must_Throw(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);

            // Act
            Action actionLess = () => _ = AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .Select(selector.AsAsync())
                .ElementAtAsync(-1);
            Func<ValueTask> actionGreater = async () => _ = await AsyncValueEnumerable
                .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .Select(selector.AsAsync())
                .ElementAtAsync(source.Length);

            // Assert
            _ = actionLess.Must()
                .Throw<ArgumentOutOfRangeException>();
            _ = actionGreater.Must()
                .Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public async ValueTask ElementAtAsync_Predicate_Selector_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Select(
                        System.Linq.Enumerable.Where(source, predicate.AsFunc()), selector.AsFunc()));

            for (var index = 0; index < expected.Count; index++)
            {
                // Act
                var result = await AsyncValueEnumerable
                    .Where<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                    .Select(selector.AsAsync())
                    .ElementAtAsync(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(expected[index]);
            }
        }
    }
}