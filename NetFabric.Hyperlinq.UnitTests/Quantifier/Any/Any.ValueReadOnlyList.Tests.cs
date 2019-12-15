using System;
using System.Collections.Generic;
using System.Diagnostics;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class AnyValueReadOnlyListTests
    {
        [Fact]
        public void Any_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(new int[0]);
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => ValueReadOnlyList
                .Any<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

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
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Any(wrapped, predicate.AsFunc());

            // Act
            var result = ValueReadOnlyList
                .Any<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }
    }
}