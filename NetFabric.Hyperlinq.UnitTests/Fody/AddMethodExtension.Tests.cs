using NetFabric.Assertive;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class FodyAddMethodExtensionTests
    {
        [Fact]
        public void AddMethodExtension_Should_Succeed()
        {
            // ValueEnumerable.RangeEnumerable has a Count property so the Count() operation has to be an extension method

            // Arrange
            var expected = System.Linq.Enumerable.Count(System.Linq.Enumerable.Range(0, 100), item => true);

            // Act
            var result = ValueEnumerable.Range(0, 100)
                .Count(item => true);

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }
    }
}