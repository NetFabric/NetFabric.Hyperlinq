using NetFabric.Assertive;
using System;
using System.Threading.Tasks;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class AllAsyncValueEnumerableTests
    {
        [Fact]
        public void AllAsync_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(new int[0]);
            var predicate = (AsyncPredicate<int>)null;

            // Act
            Action action = () => _ = AsyncValueEnumerable
                .AllAsync<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public async ValueTask AllAsync_With_ValidData_Should_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.All(source, predicate.AsFunc());

            // Act
            var result = await AsyncValueEnumerable
                .AllAsync<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync());

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Fact]
        public void AllAsync_PredicateAt_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var predicate = (AsyncPredicateAt<int>)null;

            // Act
            Action action = () => _ = AsyncValueEnumerable
                .AllAsync<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public async ValueTask AllAsync_PredicateAt_With_ValidData_Should_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.Count(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc())) == source.Length;

            // Act
            var result = await AsyncValueEnumerable
                .AllAsync<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, predicate.AsAsync());

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}