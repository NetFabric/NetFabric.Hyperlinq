using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SelectIndexValueReadOnlyCollectionTests
    {
        [Fact]
        public void SelectIndex_With_NullSelector_Should_Throw()
        {
            // Arrange
            var collection = Wrap.AsValueReadOnlyCollection(new int[0]);
            var selector = (Func<int, string>)null;

            // Act
            Action action = () => ValueReadOnlyCollection.Select<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int, string>(collection, selector);

            // Assert
            action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "selector");
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void SelectIndex_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var expected = 
                System.Linq.Enumerable.Select(wrapped, (item, index) => (item + index).ToString());

            // Act
            var result = ValueReadOnlyCollection
                .Select<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int, string>(wrapped, (item, index) => (item + index).ToString());

            // Assert
            result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }
    }
}