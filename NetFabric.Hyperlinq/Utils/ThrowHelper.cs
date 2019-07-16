using System;

namespace NetFabric.Hyperlinq
{
    static class ThrowHelper
    {
        public static void ThrowArgumentException(string message, string paramName)
            => throw new ArgumentException(message, paramName);

        public static void ThrowArgumentNullException(string paramName)
            => throw new ArgumentNullException(paramName);

        public static T ThrowArgumentNullException<T>(string paramName)
            => throw new ArgumentNullException(paramName);

        public static void ThrowArgumentOutOfRangeException(string paramName)
            => throw new ArgumentOutOfRangeException(paramName);

        public static T ThrowArgumentOutOfRangeException<T>(string paramName)
            => throw new ArgumentOutOfRangeException(paramName);

        public static void ThrowIndexOutOfRangeException()
            => throw new IndexOutOfRangeException();

        public static T ThrowIndexOutOfRangeException<T>()
            => throw new IndexOutOfRangeException();

        public static void ThrowEmptySequence()
            => throw new InvalidOperationException(Resource.EmptySequence);

        public static T ThrowEmptySequence<T>()
            => throw new InvalidOperationException(Resource.EmptySequence);

        public static ref readonly T ThrowEmptySequenceRef<T>()
            => throw new InvalidOperationException(Resource.EmptySequence);

        public static void ThrowNotSingleSequence()
            => throw new InvalidOperationException(Resource.NotSingleSequence);

        public static T ThrowNotSingleSequence<T>()
            => throw new InvalidOperationException(Resource.NotSingleSequence);

        public static ref readonly T ThrowNotSingleSequenceRef<T>()
            => throw new InvalidOperationException(Resource.NotSingleSequence);

        public static void ThrowInvalidOperationException()
            => throw new InvalidOperationException();

        public static T ThrowInvalidOperationException<T>()
            => throw new InvalidOperationException();

        public static void ThrowNotSupportedException()
            => throw new NotSupportedException();

        public static T ThrowNotSupportedException<T>()
            => throw new NotSupportedException();
    }
}
