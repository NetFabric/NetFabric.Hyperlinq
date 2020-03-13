using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.ElementAtOrDefault
{
    public class ValueReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ElementAtOrDefault_With_ValidData_Must_Succeed(int[] source)
        {
            for (var index = -1; index <= source.Length; index++)
            {
                // Arrange
                var wrapped = Wrap.AsValueReadOnlyCollection(source);
                var expected = 
                    System.Linq.Enumerable.ElementAtOrDefault(source, index);

                // Act
                var result = ValueReadOnlyCollection
                    .ElementAtOrDefault<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped, index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(expected);
            }
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void ElementAtOrDefault_Selector_With_ValidData_Must_Succeed(int[] source, Selector<int, string> selector)
        {
            for (var index = -1; index <= source.Length; index++)
            {
                // Arrange
                var wrapped = Wrap.AsValueReadOnlyCollection(source);
                var expected = 
                    System.Linq.Enumerable.ElementAtOrDefault(
                        System.Linq.Enumerable.Select(source, selector.AsFunc()), index);

                // Act
                var result = ValueReadOnlyCollection
                    .Select<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                    .ElementAtOrDefault(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(expected);
            }
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void ElementAtOrDefault_SelectorAt_With_ValidData_Must_Succeed(int[] source, SelectorAt<int, string> selector)
        {
            for (var index = -1; index <= source.Length; index++)
            {
                // Arrange
                var wrapped = Wrap.AsValueReadOnlyCollection(source);
                var expected = 
                    System.Linq.Enumerable.ElementAtOrDefault(
                        System.Linq.Enumerable.Select(source, selector.AsFunc()), index);

                // Act
                var result = ValueReadOnlyCollection
                    .Select<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                    .ElementAtOrDefault(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(expected);
            }
        }
    }
}