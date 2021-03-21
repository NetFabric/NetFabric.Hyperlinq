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
        [MemberData(nameof(TestData.ElementAt), MemberType = typeof(TestData))]
        public void MustHaveElementAt(int[] source, int index)
        {
            // Arrange
            var wrapped = createInstance(source);
            var expected = source
                .ElementAt(index);

            var sourceParameter = Expression.Parameter(typeof(TEnumerable), "source");
            var indexParameter = Expression.Parameter(typeof(int), "index");
            var expression = ExpressionBuilder.OperationCall<TEnumerable>(
                "ElementAt", 
                sourceParameter,
                new[] { typeof(int) },
                new[] { indexParameter });
            var func = Expression.Lambda<Func<TEnumerable, int, Option<int>>>(expression, sourceParameter, indexParameter).Compile();

            // Act
            var result = func(wrapped, index);

            // Assert
            _ = result.Must()
                .EvaluateTrue(option => option.IsSome && option.Value == expected);
        }
        
        [Theory]
        [MemberData(nameof(TestData.ElementAtOutOfRange), MemberType = typeof(TestData))]
        public void MustHaveElementAtOutOfRange(int[] source, int index)
        {
            // Arrange
            var wrapped = createInstance(source);

            var sourceParameter = Expression.Parameter(typeof(TEnumerable), "source");
            var indexParameter = Expression.Parameter(typeof(int), "index");
            var expression = ExpressionBuilder.OperationCall<TEnumerable>(
                "ElementAt", 
                sourceParameter,
                new[] { typeof(int) },
                new[] { indexParameter });
            var func = Expression.Lambda<Func<TEnumerable, int, Option<int>>>(expression, sourceParameter, indexParameter).Compile();

            // Act
            var result = func(wrapped, index);

            // Assert
            _ = result.Must()
                .EvaluateTrue(option => option.IsNone);
        }
    }
}