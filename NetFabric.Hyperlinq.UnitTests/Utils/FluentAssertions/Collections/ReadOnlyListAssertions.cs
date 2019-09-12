﻿using FluentAssertions.Common;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System;
using System.Collections.Generic;

namespace FluentAssertions.Collections
{
    public class ReadOnlyListAssertions<T> : ReferenceTypeAssertions<IReadOnlyList<T>, ReadOnlyListAssertions<T>>
    {
        internal ReadOnlyListAssertions(IReadOnlyList<T> subject)
        {
            Subject = subject;
        }

        protected override string Identifier => "Hyperlinq.ReadOnlyListAssertions";

        public AndConstraint<ReadOnlyListAssertions<T>> BeEnumerable(IEnumerable<T> expected, string because = "", params object[] becauseArgs)
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
                GenericEnumerableAssertions<T>.AssertEquality(Subject, expected, because, becauseArgs);
                ReadOnlyCollectionAssertions<T>.AssertCountIsCorrect(Subject, because, becauseArgs);
                AssertEquality(Subject, expected, because, becauseArgs);
            }

            return new AndConstraint<ReadOnlyListAssertions<T>>(this);
        }

        static void AssertEquality(IReadOnlyList<T> subject, IEnumerable<T> expected, string because = "", params object[] becauseArgs)
            => Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:collection} to be equal to {0}{reason}, ", expected)
                .Given(() => subject)
                .AssertListsHaveSameItems(expected, (a, e) => a.IndexOfFirstDifferenceWith(e));
    }
}
