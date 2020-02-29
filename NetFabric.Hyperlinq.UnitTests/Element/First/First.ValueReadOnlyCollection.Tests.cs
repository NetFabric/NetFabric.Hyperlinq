using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.First
{
    public class ValueReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        public void First_With_Empty_Should_Throw(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyCollection(source);

            // Act
            Action action = () => _ = ValueReadOnlyCollection
                .First<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void First_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyCollection(source);
            var expected = 
                System.Linq.Enumerable.First(source);

            // Act
            var result = ValueReadOnlyCollection
                .First<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}