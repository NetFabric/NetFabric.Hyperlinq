using NetFabric.Assertive;
using System;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Partitioning.SkipTake
{
    public class ReadOnlyListTests
    {

        [Theory]
        [InlineData(1, -1)]
        [InlineData(1, 1)]
        [InlineData(3, -1)]
        [InlineData(3, 3)]
        public void SkipTake_Indexer_With_OutOfRange__Must_Throw(int takeCount, int index)
        {
            // Arrange
            var source = new int[] { 1, 2, 3, 4, 5 };
            var wrapped = Wrap.AsValueReadOnlyList(source);

            // Act
            Func<int> action = () => ReadOnlyList
                .SkipTake<Wrap.ValueReadOnlyList<int>, int>(wrapped, 0, takeCount)[index];

            // Assert
            _ = action.Must()
                .Throw<ArgumentOutOfRangeException>()
                .EvaluateTrue(exception => exception.ParamName == "index");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void SkipTake_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Take(
                    System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount);

            // Act
            var result = ReadOnlyList
                .SkipTake<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount, takeCount);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTake_Take), MemberType = typeof(TestData))]
        public void SkipTake_Take_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount0, int takeCount1)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Take(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount0), takeCount1);

            // Act
            var result = ReadOnlyList
                .SkipTake<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount, takeCount0)
                .Take(takeCount1);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void SkipTake_Select_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Select(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount), item => item.ToString());

            // Act
            var result = ReadOnlyList
                .SkipTake<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount, takeCount)
                .Select(item => item.ToString());

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void SkipTake_SelectIndex_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Select(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount), (item, index) => (item + index).ToString());

            // Act
            var result = ReadOnlyList
                .SkipTake<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount, takeCount)
                .Select((item, index) => (item + index).ToString());

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void SkipTake_ToArray_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ToArray(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount));

            // Act
            var result = ReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .ToArray();

            // Assert
            _ = result.Must().BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void SkipTake_ToList_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount));

            // Act
            var result = ReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .ToList();

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void SkipTake_ToDictionary_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ToDictionary(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount), item => item);

            // Act
            var result = ReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .ToDictionary(item => item);

            // Assert
            _ = result.Must()
                .BeOfType<Dictionary<int, int>>()
                .BeEnumerableOf<KeyValuePair<int, int>>()
                .BeEqualTo(expected, false);
        }
    }
}