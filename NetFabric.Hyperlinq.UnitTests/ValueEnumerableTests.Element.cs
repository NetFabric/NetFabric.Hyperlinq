using NetFabric.Assertive;
using System;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public abstract partial class ValueEnumerableTests<
        TEnumerable,
        TSkipEnumerable,
        TTakeEnumerable,
        TWhereEnumerable,
        TWhereAtEnumerable>
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
                .BeOfType<Option<int>>()
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
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }
        
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        public void MustHaveFirstEmpty(int[] source)
        {
            // Arrange
            var wrapped = createInstance(source);

            var sourceParameter = Expression.Parameter(typeof(TEnumerable), "source");
            var expression = ExpressionBuilder.OperationCall<TEnumerable>(
                "First", 
                sourceParameter);
            var func = Expression.Lambda<Func<TEnumerable, Option<int>>>(expression, sourceParameter).Compile();

            // Act
            var result = func(wrapped);

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void MustHaveFirstNonEmpty(int[] source)
        {
            // Arrange
            var wrapped = createInstance(source);
            var expected = source
                .First();

            var sourceParameter = Expression.Parameter(typeof(TEnumerable), "source");
            var expression = ExpressionBuilder.OperationCall<TEnumerable>(
                "First",
                sourceParameter);
            var func = Expression.Lambda<Func<TEnumerable, Option<int>>>(expression, sourceParameter).Compile();

            // Act
            var result = func(wrapped);

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsSome && option.Value == expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        public void MustHaveSingleSingle(int[] source)
        {
            // Arrange
            var wrapped = createInstance(source);
            var expected = source
                .Single();

            var sourceParameter = Expression.Parameter(typeof(TEnumerable), "source");
            var expression = ExpressionBuilder.OperationCall<TEnumerable>(
                "Single", 
                sourceParameter);
            var func = Expression.Lambda<Func<TEnumerable, Option<int>>>(expression, sourceParameter).Compile();

            // Act
            var result = func(wrapped);

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsSome && option.Value == expected);
        }
        
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void MustHaveSingleNonSingle(int[] source)
        {
            // Arrange
            var wrapped = createInstance(source);

            var sourceParameter = Expression.Parameter(typeof(TEnumerable), "source");
            var expression = ExpressionBuilder.OperationCall<TEnumerable>(
                "Single", 
                sourceParameter);
            var func = Expression.Lambda<Func<TEnumerable, Option<int>>>(expression, sourceParameter).Compile();

            // Act
            var result = func(wrapped);

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }
    }
}