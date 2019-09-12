﻿using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System;
using System.Collections.Generic;

namespace FluentAssertions.Collections
{
    public class ReadOnlyCollectionAssertions<T> : ReferenceTypeAssertions<IReadOnlyCollection<T>, ReadOnlyCollectionAssertions<T>>
    {
        internal ReadOnlyCollectionAssertions(IReadOnlyCollection<T> subject)
        {
            Subject = subject;
        }

        protected override string Identifier => "Hyperlinq.ReadOnlyCollectionAssertions";

        public AndConstraint<ReadOnlyCollectionAssertions<T>> BeEnumerable(IEnumerable<T> expected, string because = "", params object[] becauseArgs)
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
                AssertCountIsCorrect(Subject, because, becauseArgs);
            }
            
            return new AndConstraint<ReadOnlyCollectionAssertions<T>>(this);
        }

        internal static void AssertCountIsCorrect(IReadOnlyCollection<T> subject, string because = "", params object[] becauseArgs)
            => Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected 'Count' of {context:collection} to return its item count{reason}, ")
                .Given(() => subject)
                .AssertCollectionHasCountCorrect();
    }
}
