using FluentAssertions.Common;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System;
using System.Collections.Generic;

namespace FluentAssertions.Collections
{
    public class GenericEnumerableAssertions<T> : ReferenceTypeAssertions<IEnumerable<T>, GenericEnumerableAssertions<T>>
    {
        internal GenericEnumerableAssertions(IEnumerable<T> subject)
        {
            Subject = subject;
        }

        protected override string Identifier => "Hyperlinq.GenericEnumerableAssertions";

        public AndConstraint<GenericEnumerableAssertions<T>> BeEnumerable(IEnumerable<T> expected, string because = "", params object[] becauseArgs)
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
                NonGenericEnumerableAssertions.AssertEquality(Subject, expected, because, becauseArgs);
                AssertEquality(Subject, expected, because, becauseArgs);
            }

            return new AndConstraint<GenericEnumerableAssertions<T>>(this);
        }

        internal static void AssertEquality(IEnumerable<T> subject, IEnumerable<T> expectation, string because = "", params object[] becauseArgs)
            => Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:collection} to be equal to {0}{reason}, ", expectation)
                .Given(() => subject)
                .AssertGenericEnumerablesHaveSameItems(expectation, (a, e) => a.IndexOfFirstDifferenceWith(e));

    }
}
