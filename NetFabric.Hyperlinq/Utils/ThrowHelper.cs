using System;

namespace NetFabric.Hyperlinq
{
    static class ThrowHelper
    {
        public static void ThrowArgumentNullException(string paramName)
            => throw new ArgumentNullException(paramName);

        public static T ThrowArgumentNullException<T>(string paramName)
            => throw new ArgumentNullException(paramName);

        public static void ThrowArgumentOutOfRangeException(string paramName)
            => throw new ArgumentOutOfRangeException(paramName);

        public static T ThrowArgumentOutOfRangeException<T>(string paramName)
            => throw new ArgumentOutOfRangeException(paramName);

        public static void ThrowArgumentTooLargeException(long count)
            => throw new ArgumentOutOfRangeException($"Collection with count {count} exceeds allowed size.");

        public static T ThrowArgumentTooLargeException<T>(long count)
            => throw new ArgumentOutOfRangeException($"Collection with count {count} exceeds allowed size.");

        public static void ThrowArgumentTooLargeException(string paramName, long count)
            => throw new ArgumentOutOfRangeException(paramName, $"Collection with count {count} exceeds allowed size.");

        public static T ThrowArgumentTooLargeException<T>(string paramName, long count)
            => throw new ArgumentOutOfRangeException(paramName, $"Collection with count {count} exceeds allowed size.");

        public static void ThrowIndexOutOfRangeException()
            => throw new IndexOutOfRangeException();

        public static T ThrowIndexOutOfRangeException<T>()
            => throw new IndexOutOfRangeException();

        public static void ThrowEmptySequence()
            => throw new InvalidOperationException(Resource.EmptySequence);

        public static T ThrowEmptySequence<T>()
            => throw new InvalidOperationException(Resource.EmptySequence);

        public static void ThrowNotSingleSequence()
            => throw new InvalidOperationException(Resource.NotSingleSequence);

        public static T ThrowNotSingleSequence<T>()
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
