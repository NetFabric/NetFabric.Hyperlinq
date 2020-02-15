using System;
using System.Collections.Generic;
using System.Diagnostics;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class AllValueReadOnlyCollectionTests
    {
        [Fact]
        public void All_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(new int[0]);
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => _ = ValueReadOnlyCollection
                .All<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void All_With_ValidData_Should_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var expected = 
                System.Linq.Enumerable.All(wrapped, predicate.AsFunc());

            // Act
            var result = ValueReadOnlyCollection
                .All<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Fact]
        public void All_PredicateAt_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var predicate = (PredicateAt<int>)null;

            // Act
            Action action = () => _ = ValueReadOnlyCollection
                .All<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void All_PredicateAt_With_ValidData_Should_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var expected = 
                System.Linq.Enumerable.Count(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc())) == source.Length;

            // Act
            var result = ValueReadOnlyCollection
                .All<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}