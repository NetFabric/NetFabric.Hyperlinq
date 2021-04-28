using NetFabric.Assertive;
using System;
using System.Linq.Expressions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public abstract class TestsBase<TEnumerable>
        where TEnumerable : struct
    {
        protected readonly Func<int[], TEnumerable> createInstance;

        protected TestsBase(Func<int[], TEnumerable> createInstance) 
            => this.createInstance = createInstance;

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void MustBeEnumerable(int[] source)
        {
            // Arrange
            
            // Act
            var result = createInstance(source);
            
            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(source);
            
            // TODO: test ref structs
        }
        
        protected static Expression SkipExpression<TType>(Expression source, Expression count) 
            => ExpressionBuilder.OperationCall<TType>("Skip", source, new[] { typeof(int) }, new[] { count });

        protected static Expression TakeExpression<TType>(Expression source, Expression count) 
            => ExpressionBuilder.OperationCall<TType>("Take", source, new[] { typeof(int) }, new[] { count });
        
    }
}