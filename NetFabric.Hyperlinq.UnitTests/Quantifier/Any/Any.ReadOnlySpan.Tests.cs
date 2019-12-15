using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class AnyReadOnlySpanTests
    {
        [Fact]
        public void Select_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => ReadOnlySpanExtensions
                .Any<int>(new int[0], predicate);

            // Assert
            action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.Any), MemberType = typeof(TestData))]
        public void Any_With_ValidData_Should_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Any(source, predicate.AsFunc());

            // Act
            var result = ReadOnlySpanExtensions
                .Any<int>(source, predicate);

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }
    }
}