using NetFabric.Assertive;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Bindings.System.Collections.Generic
{
    public class ListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Count_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var list = source.ToList();
            var expected = Enumerable
                .Count(source);

            // Act
            var result = ListBindings
                .Count(list);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipMultiple), MemberType = typeof(TestData))]
        public void Skip_With_ValidData_Must_Succeed(int[] source, int count)
        {
            // Arrange
            var list = source.ToList();
            var expected = Enumerable
                .Skip(source, count);

            // Act
            var result = ListBindings
                .Skip(list, count);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }


        [Theory]
        [MemberData(nameof(TestData.TakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.TakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.TakeMultiple), MemberType = typeof(TestData))]
        public void Take_With_ValidData_Must_Succeed(int[] source, int count)
        {
            // Arrange
            var list = source.ToList();
            var expected = Enumerable
                .Take(source, count);

            // Act
            var result = ListBindings
                .Take(list, count);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void All_Predicate_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var list = source.ToList();
            var expected = Enumerable
                .All(source, predicate.AsFunc());

            // Act
            var result = ListBindings
                .All(list, predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void All_PredicateAt_With_ValidData_Must_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var list = source.ToList();
            var expected = Enumerable
                .Where(source, predicate.AsFunc())
                .Count() == source.Length;

            // Act
            var result = ListBindings
                .All(list, predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Any_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var list = source.ToList();
            var expected = Enumerable
                .Any(source);

            // Act
            var result = ListBindings
                .Any(list);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void Any_Predicate_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var list = source.ToList();
            var expected = Enumerable
                .Any(source, predicate.AsFunc());

            // Act
            var result = ListBindings
                .Where(list, predicate)
                .Any();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void Any_PredicateAt_With_ValidData_Must_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var list = source.ToList();
            var expected = Enumerable
                .Where(source, predicate.AsFunc())
                .Count() != 0;

            // Act
            var result = ListBindings
                .Where(list, predicate)
                .Any();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Contains_With_Null_And_NotContains_Must_ReturnFalse(int[] source)
        {
            // Arrange
            var list = source.ToList();
            var value = int.MaxValue;

            // Act
            var result = ListBindings
                .Contains(list, value);

            // Assert
            _ = result.Must()
                .BeFalse();
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Contains_With_Null_And_Contains_Must_ReturnTrue(int[] source)
        {
            // Arrange
            var list = source.ToList();
            var value = source.Last();

            // Act
            var result = ListBindings
                .Contains(list, value);

            // Assert
            _ = result.Must()
                .BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void Select_Selector_With_ValidData_Must_Succeed(int[] source, NullableSelector<int, string> selector)
        {
            // Arrange
            var list = source.ToList();
            var expected = Enumerable
                .Select(source, selector.AsFunc());

            // Act
            var result = ListBindings
                .Select(list, selector);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected, testRefStructs: false);
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void Select_SelectorAt_With_ValidData_Must_Succeed(int[] source, NullableSelectorAt<int, string> selector)
        {
            // Arrange
            var list = source.ToList();
            var expected = Enumerable
                .Select(source, selector.AsFunc());

            // Act
            var result = ListBindings
                .Select(list, selector);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected, testRefStructs: false);
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void Where_Predicate_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var list = source.ToList();
            var expected = Enumerable
                .Where(source, predicate.AsFunc());

            // Act
            var result = ListBindings
                .Where(list, predicate);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefStructs: false);
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void Where_PredicateAt_With_ValidData_Must_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var list = source.ToList();
            var expected = Enumerable
                .Where(source, predicate.AsFunc());

            // Act
            var result = ListBindings
                .Where(list, predicate);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefStructs: false);
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void WhereRef_Predicate_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var list = source.ToList();
            var expected = Enumerable
                .Where(source, predicate.AsFunc());

            // Act
            var result = ListBindings
                .WhereRef(list, predicate);

            // Assert
#if NETCOREAPP3_1 || NET5_0
            //_ = result.Must()
            //    .BeEnumerableOf<int>()
            //    .BeEqualTo(expected, testRefStructs: false);
#else
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefStructs: false, testRefReturns: false);
#endif
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void WhereRef_PredicateAt_With_ValidData_Must_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var list = source.ToList();
            var expected = Enumerable
                .Where(source, predicate.AsFunc());

            // Act
            var result = ListBindings
                .WhereRef(list, predicate);

            // Assert
#if NETCOREAPP3_1 || NET5_0
            //_ = result.Must()
            //    .BeEnumerableOf<int>()
            //    .BeEqualTo(expected, testRefStructs: false);
#else
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefStructs: false, testRefReturns: false);
#endif
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ElementAt_With_OutOfRange_Must_Return_None(int[] source)
        {
            // Arrange
            var list = source.ToList();

            // Act
            var optionTooSmall = ListBindings
                .ElementAt(list, -1);
            var optionTooLarge = ListBindings
                .ElementAt(list, source.Length);

            // Assert
            _ = optionTooSmall.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
            _ = optionTooLarge.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ElementAt_With_ValidData_Must_Return_Some(int[] source)
        {
            // Arrange
            var list = source.ToList();
            for (var index = 0; index < source.Length; index++)
            {
                // Act
                var result = ListBindings
                    .ElementAt(list, index);

                // Assert
                _ = result.Match(
                    value => value.Must().BeEqualTo(source[index]),
                    () => throw new Exception());
            }
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        public void First_With_Empty_Must_Return_None(int[] source)
        {
            // Arrange
            var list = source.ToList();

            // Act
            var result = ListBindings
                .First(list);

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void First_With_ValidData_Must_Return_Some(int[] source)
        {
            // Arrange
            var list = source.ToList();
            var expected = Enumerable
                .First(source);

            // Act
            var result = ListBindings
                .First(list);

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected),
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        public void Single_With_Empty_Must_Return_None(int[] source)
        {
            // Arrange
            var list = source.ToList();

            // Act
            var result = ListBindings
                .Single(list);

            // Assert
            _ = result.Must()
                .BeOfType<Option<int>>()
                .EvaluateTrue(option => option.IsNone);
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        public void Single_With_Single_Must_Return_Some(int[] source)
        {
            // Arrange
            var list = source.ToList();
            var expected = Enumerable
                .Single(source);

            // Act
            var result = ListBindings
                .Single(list);

            // Assert
            _ = result.Match(
                value => value.Must().BeEqualTo(expected),
                () => throw new Exception());
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Distinct_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var list = source.ToList();
            var expected = Enumerable
                .Distinct(source);

            // Act
            var result = ListBindings
                .Distinct(list);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefStructs: false, testRefReturns: false);
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsEnumerable_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var list = source.ToList();

            // Act
            var result = ListBindings
                .AsEnumerable(list);

            // Assert
            _ = result.Must()
                .BeSameAs(list);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var list = source.ToList();

            // Act
            var result = ListBindings
                .AsValueEnumerable(list);

            // Assert
            _ = result.Must()
                .BeAssignableTo<IValueReadOnlyList<int, List<int>.Enumerator>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(source);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ToArray_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var list = source.ToList();

            // Act
            var result = ListBindings
                .ToArray(list);

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(source);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ToList_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var list = source.ToList();

            // Act
            var result = ListBindings
                .ToArray(list);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(source);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ToDictionary_KeySelector_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var list = source.ToList();
            var expected = Enumerable
                .ToDictionary(source, item => item);

            // Act
            var result = ListBindings
                .ToDictionary(list, item => item);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<KeyValuePair<int, int>>()
                .BeEqualTo(expected, testNonGeneric: false);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ToDictionary_KeySelector_ElementSelector_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var list = source.ToList();
            var expected = Enumerable
                .ToDictionary(source, item => item, item => item);

            // Act
            var result = ListBindings
                .ToDictionary(list, item => item, item => item);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<KeyValuePair<int, int>>()
                .BeEqualTo(expected, testNonGeneric: false);
        }
    }
}
