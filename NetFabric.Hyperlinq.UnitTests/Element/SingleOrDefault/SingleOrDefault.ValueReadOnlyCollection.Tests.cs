using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.SingleOrDefault
{
    public class ValueReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        public void SingleOrDefault_With_Empty_Or_Single_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyCollection(source);
            var expected =
                System.Linq.Enumerable.SingleOrDefault(source);

            // Act
            var result = ValueReadOnlyCollection
                .SingleOrDefault<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void SingleOrDefault_With_Multiple_Must_Throw(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyCollection(source);

            // Act
            Action action = () => _ = ValueReadOnlyCollection
                .SingleOrDefault<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        public void SingleOrDefault_Selector_With_Empty_Or_Single_Must_Succeed(int[] source, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyCollection(source);
            var expected =
                System.Linq.Enumerable.SingleOrDefault(
                    System.Linq.Enumerable.Select(source, selector.AsFunc()));

            // Act
            var result = ValueReadOnlyCollection
                .Select<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                .SingleOrDefault();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void SingleOrDefault_Selector_With_Multiple_Must_Throw(int[] source, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyCollection(source);

            // Act
            Action action = () => _ = ValueReadOnlyCollection
                .Select<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                .SingleOrDefault();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        public void SingleOrDefault_SelectorAt_With_Empty_Or_Single_Must_Succeed(int[] source, SelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyCollection(source);
            var expected =
                System.Linq.Enumerable.SingleOrDefault(
                    System.Linq.Enumerable.Select(source, selector.AsFunc()));

            // Act
            var result = ValueReadOnlyCollection
                .Select<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                .SingleOrDefault();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void SingleOrDefault_SelectorAt_With_Multiple_Must_Throw(int[] source, SelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyCollection(source);

            // Act
            Action action = () => _ = ValueReadOnlyCollection
                .Select<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                .SingleOrDefault();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }
    }
}