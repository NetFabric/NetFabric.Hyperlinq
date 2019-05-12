using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace NetFabric.Hyperlinq.UnitTests
{
    // [DebuggerNonUserCode]
    class ValueEnumerablerAssertions<TEnumerable, TEnumerator, TSource>
        where TEnumerable : IValueEnumerable<TSource, TEnumerator>
        where TEnumerator : struct, IValueEnumerator<TSource>
    {
        public ValueEnumerablerAssertions(TEnumerable value)
        {
            Subject = value;
        }

        public TEnumerable Subject { get; private set; }

        public AndConstraint<ValueEnumerablerAssertions<TEnumerable, TEnumerator, TSource>> Generate(IEnumerable<TSource> expected, string because = "", params object[] becauseArgs)
        {
            AssertSubjectEquality(expected, (s, e) => s.IsSameOrEqualTo(e), because, becauseArgs);

            return new AndConstraint<ValueEnumerablerAssertions<TEnumerable, TEnumerator, TSource>>(this);
        }

        protected void AssertSubjectEquality(IEnumerable<TSource> expectation, 
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

            var index = Subject.IndexOfFirstDifferenceWith<TEnumerator, TSource, TSource>(expectation, equalityComparison);
            if(index >= 0)
                assertion.FailWith("Expected {context:collection} to be equal to {0}{reason}, but {0} differs at index {1}.", expectation, index);
         }
    }
}