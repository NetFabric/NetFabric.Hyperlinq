using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class FodyAddMethodInstanceTests
    {
        [Fact]
        public void AddMethodInstance_With_NoGenerics_Should_Succeed()
        {
            // ValueEnumerable.RangeEnumerable type and All() method don't have generic parameters

            // Arrange
            var expected = System.Linq.Enumerable.All(System.Linq.Enumerable.Range(0, 100), item => true);

            // Act
            var result = ValueEnumerable.Range(0, 100)
                .All(item => true);

            // Assert
            result.Should()
                .Be(expected);
        }

        [Fact]
        public void AddMethodInstance_With_GenericOnMethod_Should_Succeed()
        {
            // ValueEnumerable.RangeEnumerable type doesn't have generic parameters but the Select<TResult>() method does

            // Arrange
            var expected = System.Linq.Enumerable.Select(System.Linq.Enumerable.Range(0, 100), item => item);

            // Act
            var result = ValueEnumerable.Range(0, 100)
                .Select(item => item);

            // Assert
            result.Should()
                .Equals(expected);
        }

        [Fact]
        public void AddMethodInstance_With_GenericParamOnType_Should_Succeed()
        {
            // Enumerable.AsValueEnumerableEnumerable<TSource> type has one generic parameters but the All() method doesn't

            // Arrange
            var expected = System.Linq.Enumerable.All(System.Linq.Enumerable.Range(0, 100), item => true);

            // Act
            var result = System.Linq.Enumerable.Range(0, 100)
                .AsValueEnumerable()
                .All(item => true);

            // Assert
            result.Should()
                .Be(expected);
        }

        [Fact]
        public void AddMethodInstance_With_GenericParamOnTypeAndMethod_Should_Succeed()
        {
            // Enumerable.AsValueEnumerableEnumerable<TSource> type and Select<TResult>() method have one generic parameter

            // Arrange
            var expected = System.Linq.Enumerable.Select(System.Linq.Enumerable.Range(0, 100), item => item);

            // Act
            var result = System.Linq.Enumerable.Range(0, 100)
                .AsValueEnumerable()
                .Select(item => item);

            // Assert
            result.Should()
                .Equals(expected);
        }

        [Fact]
        public void AddMethodInstance_With_GenericParamsOnType_Should_Succeed()
        {
            // Enumerable.AsValueEnumerableEnumerable<TEnumerable, TEnumerator, TSource> type has one generic parameters but the All() method doesn't

            // Arrange
            var expected = System.Linq.Enumerable.All(System.Linq.Enumerable.ToList(System.Linq.Enumerable.Range(0, 100)), item => true);

            // Act
            var result = ReadOnlyList.AsValueEnumerable<List<int>, List<int>.Enumerator, int>(System.Linq.Enumerable.ToList(System.Linq.Enumerable.Range(0, 100)), enumerable => enumerable.GetEnumerator())
                .All(item => true);

            // Assert
            result.Should()
                .Be(expected);
        }

        [Fact]
        public void AddMethodInstance_With_GenericParamsOnTypeAndMethod_Should_Succeed()
        {
            // Enumerable.AsValueEnumerableEnumerable<TEnumerable, TEnumerator, TSource> type and Select<TResult>() method have one generic parameter

            // Arrange
            var expected = System.Linq.Enumerable.Select(System.Linq.Enumerable.ToList(System.Linq.Enumerable.Range(0, 100)), item => item);

            // Act
            var result = ReadOnlyList.AsValueEnumerable<List<int>, List<int>.Enumerator, int>(System.Linq.Enumerable.ToList(System.Linq.Enumerable.Range(0, 100)), enumerable => enumerable.GetEnumerator())
                .Select(item => item);

            // Assert
            result.Should()
                .Equals(expected);
        }
    }
}