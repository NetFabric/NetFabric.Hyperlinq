using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class AllValueReadOnlyCollectionTests
    {
        [Fact]
        public void All_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(new int[0]);
            var predicate = (Func<int, bool>)null;

            // Act
            Action action = () => ValueReadOnlyCollection.All<Wrap.ValueReadOnlyCollection<int>, Wrap.ValueEnumerator<int>, int>(wrapped, predicate);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.All), MemberType = typeof(TestData))]
        public void All_With_ValidData_Should_Succeed(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var expected = System.Linq.Enumerable.All(wrapped, predicate);

            // Act
            var result = ValueReadOnlyCollection.All<Wrap.ValueReadOnlyCollection<int>, Wrap.ValueEnumerator<int>, int>(wrapped, predicate);

            // Assert
            result.Should().Be(expected);
        }
    }
}