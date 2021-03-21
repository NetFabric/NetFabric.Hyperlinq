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
        [MemberData(nameof(TestData.SkipEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipMultiple), MemberType = typeof(TestData))]
        public void MustHaveSkip(int[] source, int count)
        {
            // Arrange
            var wrapped = createInstance(source);
            var expected = source
                .Skip(count);

            var sourceParameter = Expression.Parameter(typeof(TEnumerable), "source");
            var countParameter = Expression.Parameter(typeof(int), "count");
            var expression = SkipExpression<TEnumerable>(sourceParameter, countParameter);
            var func = Expression.Lambda<Func<TEnumerable, int, TSkipEnumerable>>(expression, sourceParameter, countParameter).Compile();
            
            // Act
            var result = func(wrapped, count);
            
            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefStructs: false);
        }
        
        [Theory]
        [MemberData(nameof(TestData.TakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.TakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.TakeMultiple), MemberType = typeof(TestData))]
        public void MustHaveTake(int[] source, int count)
        {
            // Arrange
            var wrapped = createInstance(source);
            var expected = source
                .Take(count);

            var sourceParameter = Expression.Parameter(typeof(TEnumerable), "source");
            var countParameter = Expression.Parameter(typeof(int), "count");
            var expression = TakeExpression<TEnumerable>(sourceParameter, countParameter);
            var func = Expression.Lambda<Func<TEnumerable, int, TTakeEnumerable>>(expression, sourceParameter, countParameter).Compile();
            
            // Act
            var result = func(wrapped, count);
            
            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefStructs: false);
        }
    }
}