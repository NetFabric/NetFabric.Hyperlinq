using FluentAssertions.Common;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FluentAssertions.Collections
{
    public class ReadOnlyCollectionAssertions<T> : ReferenceTypeAssertions<IReadOnlyCollection<T>, ReadOnlyCollectionAssertions<T>>
    {
        internal ReadOnlyCollectionAssertions(IReadOnlyCollection<T> subject)
        {
            Subject = subject;
        }

        protected override string Identifier => "hyperlinq.readonlycollection";

        public AndConstraint<ReadOnlyCollectionAssertions<T>> BeExactlyAs(IEnumerable<T> expected, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(expected is object)
                .FailWith("Cannot compare collection with <null>.")
                .Then
                .WithExpectation("Expected Count property of {context:collection} to be correct{reason}, ", expected)
                .Given(() => Subject)
                .AssertCollectionHasCountCorrect();

            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:collection} to be equal to {0}{reason}, ", expected)
                .Given(() => (IEnumerable<T>)Subject)
                .AssertEnumerablesHaveSameItems(expected, (a, e) => a.IndexOfFirstDifferenceWith(e))
                .Then
                .Given(enumerable => (IEnumerable)enumerable)
                .AssertNonGenericEnumerablesHaveSameItems(expected, (a, e) => a.IndexOfFirstDifferenceWith(e));

            return new AndConstraint<ReadOnlyCollectionAssertions<T>>(this);
        }
    }
}
