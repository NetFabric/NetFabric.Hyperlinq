using NetFabric.Assertive;
using System;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Other.ForEach
{
    public class ValueReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ForEach_Action_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var result = new List<int>();
            var expected = new List<int>();
            System.Linq.EnumerableEx.ForEach(source, item => expected.Add(item));

            // Act
            ValueReadOnlyCollection
                .ForEach<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped, item => result.Add(item));

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void ForEach_Action_Selector_With_ValidData_Must_Succeed(int[] source, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var result = new List<string>();
            var expected = new List<string>();
            System.Linq.EnumerableEx.ForEach(
                System.Linq.Enumerable.Select(source, selector.AsFunc()), item => expected.Add(item));

            // Act
            ValueReadOnlyCollection
                .Select<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                .ForEach(item => result.Add(item));

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void ForEach_Action_SelectorAt_With_ValidData_Must_Succeed(int[] source, SelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var result = new List<string>();
            var expected = new List<string>();
            System.Linq.EnumerableEx.ForEach(
                System.Linq.Enumerable.Select(source, selector.AsFunc()), item => expected.Add(item));

            // Act
            ValueReadOnlyCollection
                .Select<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                .ForEach(item => result.Add(item));

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }

        /////////////////////////////
        // ActionAt

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ForEach_ActionAt_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var result = new List<(int, int)>();
            var expected = new List<(int, int)>();
            System.Linq.EnumerableEx.ForEach(source, (item, index) => expected.Add((item, index)));

            // Act
            ValueReadOnlyCollection
                .ForEach<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped, (item, index) => result.Add((item, index)));

            // Assert
            _ = result.Must()
                .BeEnumerableOf<(int, int)>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void ForEach_ActionAt_Selector_With_ValidData_Must_Succeed(int[] source, Selector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var result = new List<(string, int)>();
            var expected = new List<(string, int)>();
            System.Linq.EnumerableEx.ForEach(
                System.Linq.Enumerable.Select(source, selector.AsFunc()), (item, index) => expected.Add((item, index)));

            // Act
            ValueReadOnlyCollection
                .Select<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                .ForEach((item, index) => result.Add((item, index)));

            // Assert
            _ = result.Must()
                .BeEnumerableOf<(string, int)>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void ForEach_ActionAt_SelectorAt_With_ValidData_Must_Succeed(int[] source, SelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var result = new List<(string, int)>();
            var expected = new List<(string, int)>();
            System.Linq.EnumerableEx.ForEach(
                System.Linq.Enumerable.Select(source, selector.AsFunc()), (item, index) => expected.Add((item, index)));

            // Act
            ValueReadOnlyCollection
                .Select<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                .ForEach((item, index) => result.Add((item, index)));

            // Assert
            _ = result.Must()
                .BeEnumerableOf<(string, int)>()
                .BeEqualTo(expected);
        }
    }
}