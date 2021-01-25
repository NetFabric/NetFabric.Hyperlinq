using System;
using System.Collections.Generic;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Projection.Select
{
    public class ValueReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void Select_With_ValidData_Must_Succeed(int[] source, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var expected = 
                System.Linq.Enumerable.Select(wrapped, selector);

            // Act
            var result = ValueReadOnlyCollectionExtensions
                .Select<Wrap.ValueReadOnlyCollectionWrapper<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }
    }
}