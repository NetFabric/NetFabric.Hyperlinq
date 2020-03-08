using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.ElementAt
{
    public class ValueReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ElementAt_With_OutOfRange_Must_Throw(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);

            // Act
            Action actionLess = () => _ = ValueReadOnlyCollection
                .ElementAt<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped, -1);
            Action actionGreater = () => _ = ValueReadOnlyCollection
                .ElementAt<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped, source.Length);

            // Assert
            _ = actionLess.Must()
                .Throw<ArgumentOutOfRangeException>();
            _ = actionGreater.Must()
                .Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ElementAt_With_ValidData_Must_Succeed(int[] source)
        {
            for (var index = 0; index < source.Length; index++)
            {
                // Arrange
                var wrapped = Wrap.AsValueReadOnlyCollection(source);
                var expected = 
                    System.Linq.Enumerable.ElementAt(source, index);

                // Act
                var result = ValueReadOnlyCollection
                    .ElementAt<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped, index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(expected);
            }
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void ElementAt_Selector_With_OutOfRange_Must_Throw(int[] source, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);

            // Act
            Action actionLess = () => _ = ValueReadOnlyCollection
                .Select<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                .ElementAt(-1);
            Action actionGreater = () => _ = ValueReadOnlyCollection
                .Select<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                .ElementAt(source.Length);

            // Assert
            _ = actionLess.Must()
                .Throw<ArgumentOutOfRangeException>();
            _ = actionGreater.Must()
                .Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void ElementAt_Selector_With_ValidData_Must_Succeed(int[] source, Selector<int, string> selector)
        {
            for (var index = 0; index < source.Length; index++)
            {
                // Arrange
                var wrapped = Wrap.AsValueReadOnlyCollection(source);
                var expected = 
                    System.Linq.Enumerable.ElementAt(
                        System.Linq.Enumerable.Select(source, selector.AsFunc()), index);

                // Act
                var result = ValueReadOnlyCollection
                    .Select<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                    .ElementAt(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(expected);
            }
        }
        
        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void ElementAt_SelectorAt_With_OutOfRange_Must_Throw(int[] source, SelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);

            // Act
            Action actionLess = () => _ = ValueReadOnlyCollection
                .Select<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                .ElementAt(-1);
            Action actionGreater = () => _ = ValueReadOnlyCollection
                .Select<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                .ElementAt(source.Length);

            // Assert
            _ = actionLess.Must()
                .Throw<ArgumentOutOfRangeException>();
            _ = actionGreater.Must()
                .Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void ElementAt_SelectorAt_With_ValidData_Must_Succeed(int[] source, SelectorAt<int, string> selector)
        {
            for (var index = 0; index < source.Length; index++)
            {
                // Arrange
                var wrapped = Wrap.AsValueReadOnlyCollection(source);
                var expected = 
                    System.Linq.Enumerable.ElementAt(
                        System.Linq.Enumerable.Select(source, selector.AsFunc()), index);

                // Act
                var result = ValueReadOnlyCollection
                    .Select<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                    .ElementAt(index);

                // Assert
                _ = result.Must()
                    .BeEqualTo(expected);
            }
        }
    }
}