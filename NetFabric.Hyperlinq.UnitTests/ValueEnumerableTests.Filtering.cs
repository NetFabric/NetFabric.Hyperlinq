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
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void MustHaveWhere(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = createInstance(source);
            var expected = source
                .Where(predicate);

            var sourceParameter = Expression.Parameter(typeof(TEnumerable), "source");
            var predicateParameter = Expression.Parameter(typeof(Func<int, bool>), "predicate");
            var expression = ExpressionBuilder.OperationCall<TEnumerable>(
                "Where", 
                sourceParameter,
                new[] { typeof(Func<int, bool>) },
                new[] { predicateParameter });
            var func = Expression.Lambda<Func<TEnumerable, Func<int, bool>, TWhereEnumerable>>(expression, sourceParameter, predicateParameter).Compile();

            // Act
            var result = func(wrapped, predicate);

            // Assert
            _ = result.Must()
                .BeOfType<TWhereEnumerable>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
        
        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void MustHaveWhereAt(int[] source, Func<int, int, bool> predicate)
        {
            // Arrange
            var wrapped = createInstance(source);
            var expected = source
                .Where(predicate);

            var sourceParameter = Expression.Parameter(typeof(TEnumerable), "source");
            var predicateParameter = Expression.Parameter(typeof(Func<int, int, bool>), "predicate");
            var expression = ExpressionBuilder.OperationCall<TEnumerable>(
                "Where", 
                sourceParameter,
                new[] { typeof(Func<int, int, bool>) },
                new[] { predicateParameter });
            var func = Expression.Lambda<Func<TEnumerable, Func<int, int, bool>, TWhereAtEnumerable>>(expression, sourceParameter, predicateParameter).Compile();

            // Act
            var result = func(wrapped, predicate);

            // Assert
            _ = result.Must()
                .BeOfType<TWhereAtEnumerable>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}