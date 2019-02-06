using System;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static ref readonly TSource Single<TSource>(this TSource[] source) 
        {
            if (source == null) ThrowSourceNull();
            if (source.Length == 0) ThrowEmptySequence();
            if (source.Length > 1) ThrowNotSingleSequence();

            return ref source[0];

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowEmptySequence() => throw new InvalidOperationException(Resource.EmptySequence);
            void ThrowNotSingleSequence() => throw new InvalidOperationException(Resource.NotSingleSequence);
        }

        public static ref readonly TSource Single<TSource>(this TSource[] source, Func<TSource, bool> predicate) 
        {
            if (source == null) ThrowSourceNull();
            if (source.Length > 1) ThrowNotSingleSequence();

            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            ThrowEmptySequence();
            return ref source[0];

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowEmptySequence() => throw new InvalidOperationException(Resource.EmptySequence);
            void ThrowNotSingleSequence() => throw new InvalidOperationException(Resource.NotSingleSequence);
        }
    }
}
