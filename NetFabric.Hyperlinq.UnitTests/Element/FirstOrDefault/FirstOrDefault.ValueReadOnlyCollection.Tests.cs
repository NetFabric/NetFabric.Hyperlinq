using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.FirstOrDefault
{
    public class ValueReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void FirstOrDefault_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyCollection(source);
            var expected =
                System.Linq.Enumerable.FirstOrDefault(source);

            // Act
            var result = ValueReadOnlyCollection
                .FirstOrDefault<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void FirstOrDefault_Selector_With_ValidData_Must_Succeed(int[] source, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyCollection(source);
            var expected =
                System.Linq.Enumerable.FirstOrDefault(
                    System.Linq.Enumerable.Select(source, selector.AsFunc()));

            // Act
            var result = ValueReadOnlyCollection
                .Select<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                .FirstOrDefault();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void FirstOrDefault_SelectorAt_With_ValidData_Must_Succeed(int[] source, SelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyCollection(source);
            var expected =
                System.Linq.Enumerable.FirstOrDefault(
                    System.Linq.Enumerable.Select(source, selector.AsFunc()));

            // Act
            var result = ValueReadOnlyCollection
                .Select<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                .FirstOrDefault();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}