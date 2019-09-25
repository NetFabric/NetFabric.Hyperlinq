using System;
using System.Collections;
using System.Reflection;
using System.Threading;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Primitives
{
    /// <summary>
    /// Contains a number of methods to assert that an <see cref="object"/> is in the expected state.
    /// </summary>
    public class ObjectAssertions2 : ReferenceTypeAssertions<object, ObjectAssertions2>
    {
        public ObjectAssertions2(object value) : base(value)
        {
        }

        /// <summary>
        /// Asserts that an object is enumerable using a foreach loop.
        /// </summary>
        /// <param name="because">
        /// A formatted phrase explaining why the assertion should be satisfied. If the phrase does not
        /// start with the word <i>because</i>, it is prepended to the message.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more values to use for filling in any <see cref="string.Format(string,object[])" /> compatible placeholders.
        /// </param>
        public AndWhichConstraint<ObjectAssertions2, IEnumerable> BeEnumerable(string because = "", params object[] becauseArgs)
        {
            AssertIsEnumerable(Subject, because, becauseArgs);

            return new AndWhichConstraint<ObjectAssertions2, IEnumerable>(this, new ObjectEnumerable(Subject));
        }

        public AndWhichConstraint<ObjectAssertions2, IEnumerable> BeEnumerable(IEnumerable expected, string because = "", params object[] becauseArgs)
            => BeEnumerable(expected, (a, e) => a.Equals(e), because, becauseArgs);

        public AndWhichConstraint<ObjectAssertions2, IEnumerable> BeEnumerable(IEnumerable expected, Func<object, object, bool> equalityComparison, string because = "", params object[] becauseArgs)
        {
            Guard.ThrowIfArgumentIsNull(equalityComparison, nameof(equalityComparison));

            bool subjectIsNull = Subject is null;
            bool expectationIsNull = expected is null;
            if (!(subjectIsNull && expectationIsNull))
            {
                Guard.ThrowIfArgumentIsNull(expected, nameof(expected), "Cannot compare collection with <null>.");

                if (subjectIsNull)
                {
                    Execute.Assertion
                        .BecauseOf(because, becauseArgs)
                        .FailWith("Expected {context:collection} to be equal to {0}{reason}, but found <null>.", expected);
                }

                AssertIsEnumerable(Subject, because, becauseArgs);

                var subjectType = Subject.GetType();

                // assert equality using the public GetEnumerator()
                if (subjectType.IsEnumerable())
                    AssertEquality(Subject, subjectType, expected, equalityComparison, because, becauseArgs);

                // assert equality using the GetEnumerator() of implemented enumerable interfaces
                foreach (var interfaceType in subjectType.GetInterfaces())
                {
                    if (interfaceType.IsEnumerable())
                        AssertEquality(Subject, interfaceType, expected, equalityComparison, because, becauseArgs);
               }
            }

            return new AndWhichConstraint<ObjectAssertions2, IEnumerable>(this, new ObjectEnumerable(Subject));
        }

        static void AssertIsEnumerable(object subject, string because = "", params object[] becauseArgs)
            => Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:collection} to be an enumerable{reason}, ")
                .ForCondition(subject is object)
                .FailWith("but found <null>.")
                .Then
                .Given<Type>(() => subject.GetType())
                .ForCondition(type => type.GetPublicOrExplicitParameterlessMethod("GetEnumerator") is object)
                .FailWith("but {0} is missing a valid 'GetEnumerator' method.", type => type.ToString())
                .Then
                .Given<Type>(type => type.GetPublicOrExplicitParameterlessMethod("GetEnumerator").ReturnType)
                .ForCondition(type => type.GetPublicOrExplicitProperty("Current") is object)
                .FailWith("but {0} is missing a valid 'Current' property.", type => type.ToString())
                .Then
                .ForCondition(type => type.GetPublicOrExplicitParameterlessMethod("MoveNext") is object)
                .FailWith("but {0} is missing a valid 'MoveNext' method.", type => type.ToString());

        static void AssertEquality(object subject, Type enumerableType, IEnumerable expectation, Func<object, object, bool> equalityComparison,
            string because = "", params object[] becauseArgs)
            => Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .WithExpectation("Expected {context:collection} to be equal to {0}{reason}, ", expectation)
                .Given(() => subject)
                .AssertForEachEnumerablesHaveSameItems(expectation, (a, e) => a.IndexOfFirstDifferenceWith(enumerableType, e, equalityComparison));

        internal class ObjectEnumerable : IEnumerable
        {
            readonly object items;
            MethodInfo methodGetEnumerator;

            public ObjectEnumerable(object items)
            {
                this.items = items;
            }

            public IEnumerator GetEnumerator() => new Enumerator(this);

            class Enumerator : IEnumerator, IDisposable
            {
                readonly object enumerator;
                readonly PropertyInfo propertyCurrent;
                readonly MethodInfo methodMoveNext;
                MethodInfo methodReset;
                MethodInfo methodDispose;
                bool methodResetInitialized;
                bool methodDisposeInitialized;
                object methodResetSync;
                object methodDisposeSync;

                public Enumerator(ObjectEnumerable enumerable)
                {
                    LazyInitializer.EnsureInitialized(ref enumerable.methodGetEnumerator,
                        () => enumerable.items.GetType().GetPublicOrExplicitParameterlessMethod("GetEnumerator"));
                    enumerator = enumerable.methodGetEnumerator.Invoke(enumerable.items, new object[0]);

                    var enumeratorType = enumerator.GetType();
                    propertyCurrent = enumeratorType.GetPublicOrExplicitProperty("Current");
                    methodMoveNext = enumeratorType.GetPublicOrExplicitParameterlessMethod("MoveNext");
                }

                public object Current => propertyCurrent.GetValue(enumerator);

                public bool MoveNext() => (bool)methodMoveNext.Invoke(enumerator, new object[0]);

                public void Reset()
                {
                    LazyInitializer.EnsureInitialized(ref methodReset, ref methodResetInitialized, ref methodResetSync,
                        () => enumerator.GetType().GetPublicOrExplicitParameterlessMethod("Reset"));
                    methodReset?.Invoke(enumerator, new object[0]);
                }

                public void Dispose()
                {
                    LazyInitializer.EnsureInitialized(ref methodDispose, ref methodDisposeInitialized, ref methodDisposeSync,
                        () => enumerator.GetType().GetPublicOrExplicitParameterlessMethod("Dispose"));
                    methodDispose?.Invoke(enumerator, new object[0]);
                }
            }
        }

        /// <summary>
        /// Returns the type of the subject the assertion applies on.
        /// </summary>
        protected override string Identifier => "object";
    }
}
