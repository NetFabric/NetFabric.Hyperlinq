using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace NetFabric.Hyperlinq.UnitTests
{
    // [DebuggerNonUserCode]
    class ValueReadOnlyCollectionAssertions<TEnumerable, TEnumerator, TSource>
        where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
        where TEnumerator : struct, IValueEnumerator<TSource>
    {
        public ValueReadOnlyCollectionAssertions(TEnumerable value)
        {
            Subject = value;
        }

        public TEnumerable Subject { get; private set; }

        public AndConstraint<ValueReadOnlyCollectionAssertions<TEnumerable, TEnumerator, TSource>> Generate(IReadOnlyCollection<TSource> expected, string because = "", params object[] becauseArgs)
        {
            AssertSubjectEquality(expected, (s, e) => s.IsSameOrEqualTo(e), because, becauseArgs);

            return new AndConstraint<ValueReadOnlyCollectionAssertions<TEnumerable, TEnumerator, TSource>>(this);
        }

        protected void AssertSubjectEquality(IReadOnlyCollection<TSource> expectation, 
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
            {
                assertion.FailWith("Expected {context:collection} to be equal to {0}{reason}, but found <null>.", expectation);
            }

            if (Subject.Count != expectation.Count)
            {
                assertion.FailWith("Expected to be equal to {0}, but found {1}, when using Count.", expectation.Count, Subject.Count);
            }

            var index = Subject.IndexOfFirstDifferenceWith<TEnumerator, TSource, TSource>(expectation, equalityComparison);
            if(index >= 0)
                assertion.FailWith("Expected {context:collection} to be equal to {0}{reason}, but {0} differs at index {1}, when using TryMoveNext(out value).", expectation, index);

            index = Subject.IndexOfFirstDifferenceWith<TEnumerator, TSource, TSource>(expectation);
            if(index >= 0)
                assertion.FailWith("Expected {context:collection} to be equal to {0}{reason}, but enumerable {0} differs at index {1}, when using TryMoveNext().", expectation, index);
        }
    }
}