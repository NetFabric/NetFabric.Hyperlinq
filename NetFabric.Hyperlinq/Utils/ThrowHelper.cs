using System;
using System.Diagnostics.CodeAnalysis;

namespace NetFabric.Hyperlinq
{
    static class ThrowHelper
    {
        [DoesNotReturn]
        public static void ThrowArgumentException(string message, string paramName)
            => throw new ArgumentException(message, paramName);

        [DoesNotReturn]
        public static void ThrowArgumentNullException(string paramName)
            => throw new ArgumentNullException(paramName);

        [DoesNotReturn]
        public static T ThrowArgumentNullException<T>(string paramName)
            => throw new ArgumentNullException(paramName);

        [DoesNotReturn]
        public static void ThrowArgumentOutOfRangeException(string paramName)
            => throw new ArgumentOutOfRangeException(paramName);

        [DoesNotReturn]
        public static T ThrowArgumentOutOfRangeException<T>(string paramName)
            => throw new ArgumentOutOfRangeException(paramName);

        [DoesNotReturn]
        public static void ThrowIndexOutOfRangeException()
            => throw new IndexOutOfRangeException();

        [DoesNotReturn]
        public static T ThrowIndexOutOfRangeException<T>()
            => throw new IndexOutOfRangeException();

        [DoesNotReturn]
        public static void ThrowEmptySequence()
            => throw new InvalidOperationException(Resource.EmptySequence);

        [DoesNotReturn]
        public static T ThrowEmptySequence<T>()
            => throw new InvalidOperationException(Resource.EmptySequence);

        [DoesNotReturn]
        public static ref readonly T ThrowEmptySequenceRef<T>()
            => throw new InvalidOperationException(Resource.EmptySequence);

        [DoesNotReturn]
        public static void ThrowNotSingleSequence()
            => throw new InvalidOperationException(Resource.NotSingleSequence);

        [DoesNotReturn]
        public static T ThrowNotSingleSequence<T>()
            => throw new InvalidOperationException(Resource.NotSingleSequence);

        [DoesNotReturn]
        public static ref readonly T ThrowNotSingleSequenceRef<T>()
            => throw new InvalidOperationException(Resource.NotSingleSequence);

        [DoesNotReturn]
        public static void ThrowInvalidOperationException()
            => throw new InvalidOperationException();

        [DoesNotReturn]
        public static T ThrowInvalidOperationException<T>()
            => throw new InvalidOperationException();

        [DoesNotReturn]
        public static void ThrowNotSupportedException()
            => throw new NotSupportedException();

        [DoesNotReturn]
        public static T ThrowNotSupportedException<T>()
            => throw new NotSupportedException();
    }
}
