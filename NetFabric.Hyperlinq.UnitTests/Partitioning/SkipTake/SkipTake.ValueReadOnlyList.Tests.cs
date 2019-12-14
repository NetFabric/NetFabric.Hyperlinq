using NetFabric.Assertive;
using System;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SkipTakeValueReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void SkipTake_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Take(
                    System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount);

            // Act
            var result = ValueReadOnlyList
                .SkipTake<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount, takeCount);

            // Assert
            result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTake_Take), MemberType = typeof(TestData))]
        public void SkipTake_Take_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount0, int takeCount1)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Take(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount0), takeCount1);

            // Act
            var result = ValueReadOnlyList
                .SkipTake<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount, takeCount0)
                .Take(takeCount1);

            // Assert
            result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void SkipTake_Any_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Any(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount));

            // Act
            var result = ValueReadOnlyList
                .SkipTake<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount, takeCount)
                .Any();

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void SkipTake_AnyPredicate_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Any(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount), _ => true);

            // Act
            var result = ValueReadOnlyList
                .SkipTake<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount, takeCount)
                .Any(_ => true);

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void SkipTake_Select_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Select(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount), item => item.ToString());

            // Act
            var result = ValueReadOnlyList
                .SkipTake<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount, takeCount)
                .Select(item => item.ToString());

            // Assert
            result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void SkipTake_SelectIndex_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Select(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount), (item, index) => (item + index).ToString());

            // Act
            var result = ValueReadOnlyList
                .SkipTake<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount, takeCount)
                .Select((item, index) => (item + index).ToString());

            // Assert
            result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void SkipTake_Count_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Count(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount));

            // Act
            var result = ValueReadOnlyList
                .SkipTake<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount, takeCount)
                .Count();

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        public void SkipTake_First_With_Empty_Should_Throw(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);

            // Act
            Action action = () => ValueReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .First();

            // Assert
            action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void SkipTake_First_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.First(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount));

            // Act
            var result = ValueReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .First();

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        public void SkipTake_FirstPredicate_With_Empty_Should_Throw(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);

            // Act
            Action action = () => ValueReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .First(_ => true);

            // Assert
            action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void SkipTake_FirstPredicate_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.First(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount), _ => true);

            // Act
            var result = ValueReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .First(_ => true);

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void SkipTake_FirstOrDefault_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.FirstOrDefault(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount));

            // Act
            var result = ValueReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .FirstOrDefault();

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void SkipTake_FirstOrDefaultPredicate_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.FirstOrDefault(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount), _ => true);

            // Act
            var result = ValueReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .FirstOrDefault(_ => true);

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        public void SkipTake_Single_With_Empty_Should_Throw(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);

            // Act
            Action action = () => ValueReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Single();

            // Assert
            action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        public void SkipTake_Single_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Single(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount));

            // Act
            var result = ValueReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Single();

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        public void SkipTake_SinglePredicate_With_Empty_Should_Throw(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);

            // Act
            Action action = () => ValueReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Single(_ => true);

            // Assert
            action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        public void SkipTake_SinglePredicate_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Single(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount), _ => true);

            // Act
            var result = ValueReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Single(_ => true);

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        public void SkipTake_SingleOrDefault_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = System.Linq.Enumerable.SingleOrDefault(
                System.Linq.Enumerable.Take(
                    System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount));

            // Act
            var result = ValueReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .SingleOrDefault();

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        public void SkipTake_SingleOrDefaultPredicate_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected =
                System.Linq.Enumerable.SingleOrDefault(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount), _ => true);

            // Act
            var result = ValueReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .SingleOrDefault(_ => true);

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void SkipTake_ToArray_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ToArray(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount));

            // Act
            var result = ValueReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .ToArray();

            // Assert
            result.Must().BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void SkipTake_ToList_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount));

            // Act
            var result = ValueReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .ToList();

            // Assert
            result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void SkipTake_ToDictionary_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ToDictionary(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount), item => item);

            // Act
            var result = ValueReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .ToDictionary(item => item);

            // Assert
            result.Must()
                .BeOfType<Dictionary<int, int>>()
                .BeEnumerableOf<KeyValuePair<int, int>>()
                .BeEqualTo(expected, false);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void SkipTake_ForEach_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 0;
            MoreLinq.Extensions.ForEachExtension.ForEach(
                System.Linq.Enumerable.Take(
                    System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount), (item, index) => expected += item);

            // Act
            var result = 0;
            ValueReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .ForEach((item, index) => result += item);

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void SkipTake_ForEachIndex_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 0;
            MoreLinq.Extensions.ForEachExtension.ForEach(
                System.Linq.Enumerable.Take(
                    System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount), (item, index) => expected += item + index);

            // Act
            var result = 0;
            ValueReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .ForEach((item, index) => result += item + index);

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }
    }
}