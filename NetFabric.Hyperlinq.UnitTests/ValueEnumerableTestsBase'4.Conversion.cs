using NetFabric.Assertive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public abstract partial class ValueEnumerableTestsBase<TEnumerable, TSkipEnumerable, TTakeEnumerable>
    {
        // [Fact]
        // public void MustHaveAsEnumerable()
        // {
        //     // Arrange
        //     
        //     // Act
        //     var sourceParameter = Expression.Parameter(typeof(TEnumerable), "source");
        //     _ = ExpressionBuilder.OperationCall<TEnumerable>("AsEnumerable", sourceParameter, out var methodInfo);
        //     
        //     // Assert
        //     _ = methodInfo.Must()
        //         .BeNotNull();
        //         // .EvaluateTrue(methodInfo => typeof(IEnumerable<int>).IsAssignableFrom(methodInfo!.ReturnType));
        // }

        [Fact]
        public void MustHaveAsValueEnumerable()
        {
            // Arrange

            // Act
            var sourceParameter = Expression.Parameter(typeof(TEnumerable), "source");
            _ = ExpressionBuilder.OperationCall<TEnumerable>("AsValueEnumerable", sourceParameter, out var methodInfo);

            // Assert
            _ = methodInfo.Must()
                .BeNotNull()
                .EvaluateTrue(methodInfo => methodInfo!.ReturnType.GetGenericTypeDefinition().Name == typeof(TEnumerable).Name);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void MustHaveToArray(int[] source)
        {
            // Arrange
            var wrapped = createInstance(source);
            var expected = source
                .ToArray();

            var sourceParameter = Expression.Parameter(typeof(TEnumerable), "source");
            var expression = ExpressionBuilder.OperationCall<TEnumerable>("ToArray", sourceParameter);
            var func = Expression.Lambda<Func<TEnumerable, int[]>>(expression, sourceParameter).Compile();

            // Act
            var result = func(wrapped);

            // Assert
            _ = result.Must()
                .BeOfType<int[]>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void MustHaveToDictionaryKeyComparer(int[] source)
        {
            // Arrange
            var wrapped = createInstance(source);
            var expected = source
                .ToDictionary(item => item * 3, null);

            var sourceParameter = Expression.Parameter(typeof(TEnumerable), "source");
            var keySelectorParameter = Expression.Parameter(typeof(Func<int, int>), "keySelector");
            var comparerParameter = Expression.Parameter(typeof(IEqualityComparer<int>), "comparer");
            var expression = ExpressionBuilder.OperationCall<TEnumerable>(
                "ToDictionary", 
                sourceParameter, 
                new[] { typeof(int) }, 
                new[] { typeof(Func<int, int>), typeof(IEqualityComparer<int>) }, 
                new[] { keySelectorParameter, comparerParameter });
            var func = Expression.Lambda<Func<TEnumerable, Func<int, int>, IEqualityComparer<int>?, Dictionary<int, int>>>(expression, sourceParameter, keySelectorParameter, comparerParameter).Compile();

            // Act
            var result = func(wrapped, item => item * 3, null);

            // Assert
            _ = result.Must()
                .BeOfType<Dictionary<int, int>>()
                .BeEnumerableOf<KeyValuePair<int, int>>();
                //.BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void MustHaveToDictionaryKeyValueComparer(int[] source)
        {
            // Arrange
            var wrapped = createInstance(source);
            var expected = source
                .ToDictionary(item => item * 3, item => item * 5);

            var sourceParameter = Expression.Parameter(typeof(TEnumerable), "source");
            var keySelectorParameter = Expression.Parameter(typeof(Func<int, int>), "keySelector");
            var valueSelectorParameter = Expression.Parameter(typeof(Func<int, int>), "valueSelector");
            var comparerParameter = Expression.Parameter(typeof(IEqualityComparer<int>), "comparer");
            var expression = ExpressionBuilder.OperationCall<TEnumerable>(
                "ToDictionary", 
                sourceParameter, 
                new[] { typeof(int), typeof(int) }, 
                new[] { typeof(Func<int, int>), typeof(Func<int, int>), typeof(IEqualityComparer<int>) }, 
                new[] { keySelectorParameter, valueSelectorParameter, comparerParameter });
            var func = Expression.Lambda<Func<TEnumerable, Func<int, int>, Func<int, int>, IEqualityComparer<int>?, Dictionary<int, int>>>(expression, sourceParameter, keySelectorParameter, valueSelectorParameter, comparerParameter).Compile();

            // Act
            var result = func(wrapped, item => item * 3, item => item * 5, null);

            // Assert
            _ = result.Must()
                .BeOfType<Dictionary<int, int>>()
                .BeEnumerableOf<KeyValuePair<int, int>>();
            //.BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void MustHaveToList(int[] source)
        {
            // Arrange
            var wrapped = createInstance(source);
            var expected = source
                .ToList();

            var sourceParameter = Expression.Parameter(typeof(TEnumerable), "source");
            var expression = ExpressionBuilder.OperationCall<TEnumerable>("ToList", sourceParameter);
            var func = Expression.Lambda<Func<TEnumerable, List<int>>>(expression, sourceParameter).Compile();

            // Act
            var result = func(wrapped);

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}