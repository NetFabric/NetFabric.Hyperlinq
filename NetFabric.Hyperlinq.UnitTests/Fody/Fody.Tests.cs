using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class FodyTests
    {
        [Fact]
        public void AddMethodInstance_Should_Succeed()
        {
            // ValueEnumerable.RangeEnumerable type doesn't have generic parameters

            // Arrange
            var expected = System.Linq.Enumerable.All(System.Linq.Enumerable.Range(0, 100), item => true);

            // Act
            var result = ValueEnumerable.Range(0, 100).All(item => true);

            // Assert
            result.Should()
                .Be(expected);
        }

        [Fact]
        public void AddMethodInstance_With_GenericParameter_Should_Succeed()
        {
            // AsValueEnumerable().Select<TResult>()

            // Arrange
            var expected = System.Linq.Enumerable.Select(System.Linq.Enumerable.Range(0, 100), item => item);

            // Act
            var result = System.Linq.Enumerable.Range(0, 100).AsValueEnumerable().Select(item => item);

            // Assert
            result.Should()
                .Equals(expected);
        }

        [Fact]
        public void AddMethodInstance_With_TypeGenerics_Should_Succeed()
        {
            // ValueReadOnly.WhereEnumerable has generic parameters

            // Arrange
            var expected = System.Linq.Enumerable.All(System.Linq.Enumerable.Where(System.Linq.Enumerable.Range(0, 100), item => true), item => true);

            // Act
            var result = ValueEnumerable.Range(0, 100).Where(item => true).All(item => true);

            // Assert
            result.Should()
                .Be(expected);
        }

        //[Fact]
        //public void AddMethodInstance_With_GenericParameter_Should_Succeed()
        //{
        //    // The combination of selectors require the second Select() to have a generic parameter

        //    // Arrange
        //    var expected = System.Linq.Enumerable.SelectMany(System.Linq.Enumerable.Select(System.Linq.Enumerable.Range(0, 10), item => item), item => ValueEnumerable.Range(0, 10));

        //    // Act
        //    var result = ValueEnumerable.Range(0, 10).Select(item => item).SelectMany(item => ValueEnumerable.Range(0, 10));

        //    // Assert
        //    result.Should()
        //        .Equals(expected);
        //}

        [Fact]
        public void AddMethodExtension_Should_Succeed()
        {
            // ValueEnumerable.RangeEnumerable has a Count property so the Count() operation has to be an extension method

            // Arrange
            var expected = System.Linq.Enumerable.Count(System.Linq.Enumerable.Range(0, 100), item => true);

            // Act
            var result = ValueEnumerable.Range(0, 100).Count(item => true);

            // Assert
            result.Should()
                .Be(expected);
        }
    }
}