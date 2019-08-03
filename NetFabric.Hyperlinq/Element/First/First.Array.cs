using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static ref readonly TSource First<TSource>(this TSource[] source)
        {
            if (source.Length == 0) ThrowHelper.ThrowEmptySequence<TSource>();

            return ref source[0];
        }

        static ref readonly TSource First<TSource>(this TSource[] source, int skipCount, int takeCount)
        {
            if (takeCount == 0) ThrowHelper.ThrowEmptySequence<TSource>();

            return ref source[skipCount];
        }

        public static ref readonly TSource First<TSource>(this TSource[] source, Func<TSource, bool> predicate) 
            => ref First<TSource>(source, predicate, 0, source.Length);

        static ref readonly TSource First<TSource>(this TSource[] source, Func<TSource, bool> predicate, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            return ref ThrowHelper.ThrowEmptySequenceRef<TSource>();
        }

        public static ref readonly TSource First<TSource>(this TSource[] source, Func<TSource, int, bool> predicate)
            => ref First<TSource>(source, predicate, 0, source.Length);

        static ref readonly TSource First<TSource>(this TSource[] source, Func<TSource, int, bool> predicate, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index))
                    return ref source[index];
            }
            return ref ThrowHelper.ThrowEmptySequenceRef<TSource>();
        }

        public static ref readonly TSource First<TSource>(this TSource[] source, Func<TSource, int, bool> predicate, out int index) 
            => ref First<TSource>(source, predicate, out index, 0, source.Length);

        static ref readonly TSource First<TSource>(this TSource[] source, Func<TSource, int, bool> predicate, out int index, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index))
                    return ref source[index];
            }
            index = -1;
            return ref ThrowHelper.ThrowEmptySequenceRef<TSource>();
        }

        public static ref readonly TSource FirstOrDefault<TSource>(this TSource[] source)
        {
            if (source.Length == 0) return ref Default<TSource>.Value;

            return ref source[0];
        }

        static ref readonly TSource FirstOrDefault<TSource>(this TSource[] source, int skipCount, int takeCount)
        {
            if (takeCount == 0) return ref Default<TSource>.Value;

            return ref source[skipCount];
        }

        public static ref readonly TSource FirstOrDefault<TSource>(this TSource[] source, Func<TSource, bool> predicate) 
            => ref FirstOrDefault<TSource>(source, predicate, 0, source.Length);

        static ref readonly TSource FirstOrDefault<TSource>(this TSource[] source, Func<TSource, bool> predicate, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    return ref source[index];
            }
            return ref Default<TSource>.Value;
        }

        public static ref readonly TSource FirstOrDefault<TSource>(this TSource[] source, Func<TSource, int, bool> predicate)
            => ref FirstOrDefault<TSource>(source, predicate, 0, source.Length);

        static ref readonly TSource FirstOrDefault<TSource>(this TSource[] source, Func<TSource, int, bool> predicate, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index))
                    return ref source[index];
            }
            return ref Default<TSource>.Value;
        }

        public static ref readonly TSource FirstOrDefault<TSource>(this TSource[] source, Func<TSource, int, bool> predicate, out int index) 
            => ref FirstOrDefault<TSource>(source, predicate, out index, 0, source.Length);

        static ref readonly TSource FirstOrDefault<TSource>(this TSource[] source, Func<TSource, int, bool> predicate, out int index, int skipCount, int takeCount)
        {
            var end = skipCount + takeCount;
            for (index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index))
                    return ref source[index];
            }
            index = -1;
            return ref Default<TSource>.Value;
        }
    }
}
