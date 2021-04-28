using NetFabric.Assertive;
using System;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public abstract partial class ValueEnumerableTests<
        TEnumerable,
        TWhereEnumerable,
        TWhereAtEnumerable>
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
                .BeEqualTo(expected);
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
                .BeEqualTo(expected);
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
                .BeEqualTo(expected);
        }

    }
    
    public abstract partial class ValueEnumerableTests<
        TEnumerable,
        TSkipEnumerable,
        TTakeEnumerable,
        TWhereEnumerable,
        TWhereAtEnumerable>
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
                .BeOfType<TSkipEnumerable>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
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
                .BeOfType<TTakeEnumerable>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}
