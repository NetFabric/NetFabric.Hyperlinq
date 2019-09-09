using FluentAssertions.Common;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FluentAssertions.Collections
{
    public class EnumerableAssertions<T> : ReferenceTypeAssertions<IEnumerable<T>, EnumerableAssertions<T>>
    {
        internal EnumerableAssertions(IEnumerable<T> subject)
        {
            Subject = subject;
        }

        protected override string Identifier => "hyperlinq.enumerable";

        public AndConstraint<EnumerableAssertions<T>> BeExactlyAs(IEnumerable<T> expected, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(expected is object)
                .FailWith("Cannot compare collection with <null>.")
                .Then
                .WithExpectation("Expected {context:collection} to be equal to {0}{reason}, ", expected)
                .Given(() => Subject)
                .AssertEnumerablesHaveSameItems(expected, (a, e) => a.IndexOfFirstDifferenceWith(e))
                .Then
                .Given(enumerable => (IEnumerable)enumerable)
                .AssertNonGenericEnumerablesHaveSameItems(expected, (a, e) => a.IndexOfFirstDifferenceWith(e));

            return new AndConstraint<EnumerableAssertions<T>>(this);
        }

    }
}
