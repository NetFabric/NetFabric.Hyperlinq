using NetFabric.Assertive;
using System;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public abstract partial class ValueEnumerableTestsBase<TEnumerable>
    {
        [Theory]
        [MemberData(nameof(TestData.Skip_Skip), MemberType = typeof(TestData))]
        public void SkipSkipMustSucceed(int[] source, int count1, int count2)
        {
            // Arrange
            var wrapped = createInstance(source);
            var expected = source
                .Skip(count1)
                .Skip(count2);

            var sourceParameter = Expression.Parameter(typeof(TEnumerable), "source");
            var count1Parameter = Expression.Parameter(typeof(int), "count1");
            var count2Parameter = Expression.Parameter(typeof(int), "count2");
            var expression = SkipExpression<TEnumerable>(SkipExpression<TEnumerable>(sourceParameter, count1Parameter), count2Parameter);
            var func = Expression.Lambda<Func<TEnumerable, int, int, TEnumerable>>(expression, sourceParameter, count1Parameter, count2Parameter).Compile();
            
            // Act
            var result = func(wrapped, count1, count2);
            
            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefStructs: false);
        }
        
        [Theory]
        [MemberData(nameof(TestData.Take_Take), MemberType = typeof(TestData))]
        public void TakeTakeMustSucceed(int[] source, int count1, int count2)
        {
            // Arrange
            var wrapped = createInstance(source);
            var expected = source
                .Take(count1)
                .Take(count2);

            var sourceParameter = Expression.Parameter(typeof(TEnumerable), "source");
            var count1Parameter = Expression.Parameter(typeof(int), "count1");
            var count2Parameter = Expression.Parameter(typeof(int), "count2");
            var expression = TakeExpression<TEnumerable>(TakeExpression<TEnumerable>(sourceParameter, count1Parameter), count2Parameter);
            var func = Expression.Lambda<Func<TEnumerable, int, int, TEnumerable>>(expression, sourceParameter, count1Parameter, count2Parameter).Compile();
            
            // Act
            var result = func(wrapped, count1, count2);
            
            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefStructs: false);
        }

                
        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void SkipTakeMustSucceed(int[] source, int count1, int count2)
        {
            // Arrange
            var wrapped = createInstance(source);
            var expected = source
                .Skip(count1)
                .Take(count2);

            var sourceParameter = Expression.Parameter(typeof(TEnumerable), "source");
            var count1Parameter = Expression.Parameter(typeof(int), "count1");
            var count2Parameter = Expression.Parameter(typeof(int), "count2");
            var expression = TakeExpression<TEnumerable>(SkipExpression<TEnumerable>(sourceParameter, count1Parameter), count2Parameter);
            var func = Expression.Lambda<Func<TEnumerable, int, int, TEnumerable>>(expression, sourceParameter, count1Parameter, count2Parameter).Compile();
            
            // Act
            var result = func(wrapped, count1, count2);
            
            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefStructs: false);
        }

    }
}