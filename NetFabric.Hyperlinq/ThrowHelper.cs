using System;

namespace NetFabric.Hyperlinq
{
    static class ThrowHelper
    {
        public static void ThrowArgumentNullException(string paramName)
            => throw new ArgumentNullException(paramName);

        public static void ThrowArgumentOutOfRangeException(string paramName)
            => throw new ArgumentOutOfRangeException(paramName);

        public static void ThrowIndexOutOfRangeException()
            => throw new IndexOutOfRangeException();

        public static T ThrowEmptySequence<T>()
            => throw new InvalidOperationException(Resource.EmptySequence);

        public static T ThrowNotSingleSequence<T>()
            => throw new InvalidOperationException(Resource.NotSingleSequence);
    }
}
