using NetFabric.Assertive;
using System;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public abstract partial class ValueEnumerableTestsBase<TEnumerable, TSkipEnumerable, TTakeEnumerable>
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void MustHaveCount(int[] source)
        {
            // Arrange
            var wrapped = createInstance(source);
            var expected = source
                .Count();

            var sourceParameter = Expression.Parameter(typeof(TEnumerable), "source");
            var expression = ExpressionBuilder.OperationCall<TEnumerable>("Count", sourceParameter);
            var func = Expression.Lambda<Func<TEnumerable, int>>(expression, sourceParameter).Compile();
            
            // Act
            var result = func(wrapped);
            
            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}