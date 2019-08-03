using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace NetFabric.Hyperlinq.UnitTests
{
    // [DebuggerNonUserCode]
    class ValueReadOnlyListAssertions<TEnumerable, TEnumerator, TSource>
        where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
        where TEnumerator : struct, IEnumerator<TSource>
    {
        public ValueReadOnlyListAssertions(TEnumerable value)
        {
            Subject = value;
        }

        public TEnumerable Subject { get; private set; }

        public AndConstraint<ValueReadOnlyListAssertions<TEnumerable, TEnumerator, TSource>> Generate(IReadOnlyList<TSource> expected, string because = "", params object[] becauseArgs)
        {
            AssertSubjectEquality(expected, (s, e) => s.IsSameOrEqualTo(e), because, becauseArgs);

            return new AndConstraint<ValueReadOnlyListAssertions<TEnumerable, TEnumerator, TSource>>(this);
        }

        protected void AssertSubjectEquality(IReadOnlyList<TSource> expectation, 
            Func<TSource, TSource, bool> equalityComparison,
            string because = "", params object[] becauseArgs)
       {
            var subjectIsNull = ReferenceEquals(Subject, null);
            var expectationIsNull = expectation is null;
            if (subjectIsNull && expectationIsNull)
                return;

            if (expectationIsNull)
                throw new ArgumentNullException(nameof(expectation), "Cannot compare collection with <null>.");

            var assertion = Execute.Assertion.BecauseOf(because, becauseArgs);
            if (subjectIsNull)
                assertion.FailWith("Expected {context:collection} to be equal to {0}{reason}, but found <null>.", expectation);

            if (Subject.Count != expectation.Count)
                assertion.FailWith("Expected to be equal to {0}, but found {1}, when using Count.", expectation.Count, Subject.Count);

            var index = ((IValueEnumerable<TSource, TEnumerator>)Subject).IndexOfFirstDifferenceWith<TEnumerator, TSource, TSource>(expectation, equalityComparison);
            if(index >= 0)
                assertion.FailWith("Expected {context:collection} to be equal to {0}{reason}, but {0} differs at index {1}.", expectation, index);

            index = Subject.IndexOfFirstDifferenceWith<TEnumerator, TSource, TSource>(expectation, equalityComparison);
            if(index >= 0)
                assertion.FailWith("Expected {context:collection} to be equal to {0}{reason}, but indexer {0} differs at index {1}, when using indexer.", expectation, index);
        }
    }
}