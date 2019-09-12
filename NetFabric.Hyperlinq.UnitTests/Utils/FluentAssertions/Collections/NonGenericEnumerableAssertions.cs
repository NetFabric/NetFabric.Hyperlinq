using FluentAssertions.Common;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System;
using System.Collections;

namespace FluentAssertions.Collections
{
    public class NonGenericEnumerableAssertions : ReferenceTypeAssertions<IEnumerable, NonGenericEnumerableAssertions>
    {
        internal NonGenericEnumerableAssertions(IEnumerable subject)
        {
            Subject = subject;
        }

        protected override string Identifier => "Hyperlinq.NonGenericEnumerableAssertions";

        public AndConstraint<NonGenericEnumerableAssertions> BeEnumerable(IEnumerable expected, string because = "", params object[] becauseArgs)
        {
            var subjectIsNull = Subject is null;
            var expectationIsNull = expected is null;
            if (!(subjectIsNull && expectationIsNull))
            {
                if (expectationIsNull)
                    throw new ArgumentNullException(nameof(expected), "Cannot compare collection with <null>.");

                if (subjectIsNull)
                {
                    Execute.Assertion
                        .BecauseOf(because, becauseArgs)
                        .FailWith("Expected {context:collection} to be equal to {0}{reason}, but found <null>.", expected);
                }

                ObjectAssertions.AssertIsEnumerable(Subject, because, becauseArgs);
                ObjectAssertions.AssertEquality(Subject, expected, because, becauseArgs);
                AssertEquality(Subject, expected, because, becauseArgs);
            }

            return new AndConstraint<NonGenericEnumerableAssertions>(this);
        }

        internal static void AssertEquality(IEnumerable subject, IEnumerable expectation, string because = "", params object[] becauseArgs)
            => Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:collection} to be equal to {0}{reason}, ", expectation)
                .Given(() => subject)
                .AssertNonGenericEnumerablesHaveSameItems(expectation, (a, e) => a.IndexOfFirstDifferenceWith(e));
    }
}
