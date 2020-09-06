using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Quantifier.Any
{
    public class AsyncValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async ValueTask AnyAsync_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Any(source);

            // Act
            var result = await AsyncValueEnumerableExtensions
                .AnyAsync<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
        
        [Fact]
        public void AnyAsync_Predicate_With_Null_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var predicate = (AsyncPredicate<int>)null;

            // Act
            Action action = () => _ = 
                AsyncValueEnumerableExtensions
                    .Where<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate)
                    .AnyAsync();

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public async ValueTask AnyAsync_Predicate_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Any(source, predicate.AsFunc());

            // Act
            var result = await AsyncValueEnumerableExtensions
                .Where<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .AnyAsync();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
        
        [Fact]
        public void AnyAsync_PredicateAt_With_Null_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var predicate = (AsyncPredicateAt<int>)null;

            // Act
            Action action = () => _ = AsyncValueEnumerableExtensions
                .Where<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate)
                .AnyAsync();

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public async ValueTask AnyAsync_PredicateAt_With_ValidData_Must_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = Enumerable
                .Where(source, predicate.AsFunc())
                .Count() != 0;

            // Act
            var result = await AsyncValueEnumerableExtensions
                .Where<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync())
                .AnyAsync();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}