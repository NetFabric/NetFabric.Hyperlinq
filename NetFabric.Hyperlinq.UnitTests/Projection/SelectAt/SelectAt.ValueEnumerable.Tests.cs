using NetFabric.Assertive;
using System;
using System.Net.Security;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Projection.SelectAt
{
    public class ValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void Select_With_ValidData_Must_Succeed(int[] source, Func<int, int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.Select(wrapped, selector);

            // Act
            var result = ValueEnumerableExtensions
                .Select<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }
    }
}