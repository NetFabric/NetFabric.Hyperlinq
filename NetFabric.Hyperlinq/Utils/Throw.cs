using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    [ExcludeFromCodeCoverage]
    static class Throw
    {
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ArgumentArraySegmentNullException(string paramName)
            => throw new ArgumentException(paramName: paramName, message: Resource.ArraySegmentNull);

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ArgumentException(string paramName, string? message = default)
            => throw new ArgumentException(paramName: paramName, message: message);

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ArgumentNullException(string paramName, string? message = default)
            => throw new ArgumentNullException(paramName: paramName, message: message);

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static T ArgumentNullException<T>(string paramName, string? message = default)
            => throw new ArgumentNullException(paramName: paramName, message: message);

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ref readonly T ArgumentNullExceptionRef<T>(string paramName, string? message = default)
            => throw new ArgumentNullException(paramName: paramName, message: message);

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ArgumentOutOfRangeException(string paramName, string? message = default)
            => throw new ArgumentOutOfRangeException(paramName: paramName, message: message);

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static T ArgumentOutOfRangeException<T>(string paramName, string? message = default)
            => throw new ArgumentOutOfRangeException(paramName: paramName, message: message);

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ref readonly T ArgumentOutOfRangeExceptionRef<T>(string paramName, string? message = default)
            => throw new ArgumentOutOfRangeException(paramName: paramName, message: message);

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void EmptySequence()
            => throw new InvalidOperationException(Resource.EmptySequence);

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static T EmptySequence<T>()
            => throw new InvalidOperationException(Resource.EmptySequence);

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ref readonly T EmptySequenceRef<T>()
            => throw new InvalidOperationException(Resource.EmptySequence);

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void NotSingleSequence()
            => throw new InvalidOperationException(Resource.NotSingleSequence);

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static T NotSingleSequence<T>()
            => throw new InvalidOperationException(Resource.NotSingleSequence);

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ref readonly T NotSingleSequenceRef<T>()
            => throw new InvalidOperationException(Resource.NotSingleSequence);

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void InvalidOperationException(string? message = default)
            => throw new InvalidOperationException(message);

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static T InvalidOperationException<T>()
            => throw new InvalidOperationException();

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void NotSupportedException()
            => throw new NotSupportedException();

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static T NotSupportedException<T>()
            => throw new NotSupportedException();

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ObjectDisposedException(string objectName)
            => throw new ObjectDisposedException(objectName);
    }
}
