using System;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static ref readonly TSource First<TSource>(this TSource[] source) 
        {
            if (source == null) ThrowSourceNull();
            if (source.Length == 0) ThrowEmptySequence();

            return ref source[0];

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowEmptySequence() => throw new InvalidOperationException(Resource.EmptySequence);
        }

        public static ref readonly TSource First<TSource>(this TSource[] source, Func<TSource, bool> predicate) 
        {
            if (source == null) ThrowSourceNull();

            for (var index = 0; index < source.Length; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            ThrowEmptySequence();
            return ref source[0];

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowEmptySequence() => throw new InvalidOperationException(Resource.EmptySequence);
        }
    }
}
