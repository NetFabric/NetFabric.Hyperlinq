using FluentAssertions.Common;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System;
using System.Collections;

namespace FluentAssertions.Collections
{
    public class ObjectAssertions : ReferenceTypeAssertions<object, ObjectAssertions>
    {
        internal ObjectAssertions(object subject)
        {
            Subject = subject;
        }

        protected override string Identifier => "Hyperlinq.ObjectAssertions";

        public AndConstraint<ObjectAssertions> BeEnumerable(string because = "", params object[] becauseArgs)
        {
            if (Subject is null)
            {
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .FailWith("Expected {context:collection} to be not <null>{reason}.");
            }

            AssertIsEnumerable(Subject, because, becauseArgs);

            return new AndConstraint<ObjectAssertions>(this);
        }

        public AndConstraint<ObjectAssertions> BeEnumerable(IEnumerable expected, string because = "", params object[] becauseArgs)
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

                AssertIsEnumerable(Subject, because, becauseArgs);
                AssertEquality(Subject, expected, because, becauseArgs);
            }

            return new AndConstraint<ObjectAssertions>(this);
        }

        internal static void AssertIsEnumerable(object subject, string because = "", params object[] becauseArgs)
            => Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:collection} to be an enumerable{reason}, ")
                .Given<Type>(() => subject.GetType())
                .ForCondition(type => type.GetMethodGetEnumerator() is object)
                .FailWith("but {0} is missing a valid 'GetEnumerator' method.", type => type.ToString())
                .Then
                .Given<Type>(type => type.GetMethodGetEnumerator().ReturnType)
                .ForCondition(type => type.GetPropertyCurrent() is object)
                .FailWith("but {0} is missing a valid 'Current' property.", type => type.ToString())
                .Then
                .ForCondition(type => type.GetMethodMoveNext() is object)
                .FailWith("but {0} is missing a valid 'MoveNext' method.", type => type.ToString());

        internal static void AssertEquality(object subject, IEnumerable expectation, string because = "", params object[] becauseArgs)
            => Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:collection} to be equal to {0}{reason}, ", expectation)
                .Given(() => subject)
                .AssertForEachEnumerablesHaveSameItems(expectation, (a, e) => a.IndexOfFirstDifferenceWith(e));
    }
}
