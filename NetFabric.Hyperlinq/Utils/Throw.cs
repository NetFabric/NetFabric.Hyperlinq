using System;
using System.Diagnostics.CodeAnalysis;

namespace NetFabric.Hyperlinq
{
    [ExcludeFromCodeCoverage]
    static class Throw
    {
        [DoesNotReturn]
        public static void ArgumentArraySegmentNullException(string? paramName)
            => throw new ArgumentException(Resource.ArraySegmentNull, paramName);

        [DoesNotReturn]
        public static void ArgumentException(string? message, string? paramName)
            => throw new ArgumentException(message, paramName);

        [DoesNotReturn]
        public static void ArgumentNullException(string? paramName)
            => throw new ArgumentNullException(paramName);

        [DoesNotReturn]
        public static T ArgumentNullException<T>(string? paramName)
            => throw new ArgumentNullException(paramName);

        [DoesNotReturn]
        public static ref readonly T ArgumentNullExceptionRef<T>(string? paramName)
            => throw new ArgumentNullException(paramName);

        [DoesNotReturn]
        public static void ArgumentOutOfRangeException(string? paramName)
            => throw new ArgumentOutOfRangeException(paramName);

        [DoesNotReturn]
        public static T ArgumentOutOfRangeException<T>(string? paramName)
            => throw new ArgumentOutOfRangeException(paramName);

        [DoesNotReturn]
        public static ref readonly T ArgumentOutOfRangeExceptionRef<T>(string? paramName)
            => throw new ArgumentOutOfRangeException(paramName);

        [DoesNotReturn]
        public static void IndexOutOfRangeException()
            => throw new IndexOutOfRangeException();

        [DoesNotReturn]
        public static T IndexOutOfRangeException<T>()
            => throw new IndexOutOfRangeException();

        [DoesNotReturn]
        public static void EmptySequence()
            => throw new InvalidOperationException(Resource.EmptySequence);

        [DoesNotReturn]
        public static T EmptySequence<T>()
            => throw new InvalidOperationException(Resource.EmptySequence);

        [DoesNotReturn]
        public static ref readonly T EmptySequenceRef<T>()
            => throw new InvalidOperationException(Resource.EmptySequence);

        [DoesNotReturn]
        public static void NotSingleSequence()
            => throw new InvalidOperationException(Resource.NotSingleSequence);

        [DoesNotReturn]
        public static T NotSingleSequence<T>()
            => throw new InvalidOperationException(Resource.NotSingleSequence);

        [DoesNotReturn]
        public static ref readonly T NotSingleSequenceRef<T>()
            => throw new InvalidOperationException(Resource.NotSingleSequence);

        [DoesNotReturn]
        public static void InvalidOperationException()
            => throw new InvalidOperationException();

        [DoesNotReturn]
        public static void InvalidOperationException(string? message)
            => throw new InvalidOperationException(message);

        [DoesNotReturn]
        public static T InvalidOperationException<T>()
            => throw new InvalidOperationException();

        [DoesNotReturn]
        public static void NotSupportedException()
            => throw new NotSupportedException();

        [DoesNotReturn]
        public static T NotSupportedException<T>()
            => throw new NotSupportedException();

        [DoesNotReturn]
        public static void ObjectDisposedException(string? objectName)
            => throw new ObjectDisposedException(objectName);
    }
}
