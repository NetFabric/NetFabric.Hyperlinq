using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class AllSpanTests
    {
        [Fact]
        public void Select_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => SpanExtensions
                .All<int>(new int[0], predicate);

            // Assert
            action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.All), MemberType = typeof(TestData))]
        public void All_With_ValidData_Should_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.All(source, predicate.AsFunc());

            // Act
            var result = SpanExtensions
                .All<int>(source, predicate);

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }
    }
}