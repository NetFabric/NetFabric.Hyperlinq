using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        public static List<TSource> ToList<TSource>(this TSource[] source)
            => new List<TSource>(source);

        [Pure]
        static List<TSource> ToList<TSource>(this TSource[] source, int skipCount, int takeCount)
            => new List<TSource>(new ToListCollection<TSource>(source, skipCount, takeCount));

        [Pure]
        static List<TSource> ToList<TSource>(this TSource[] source, Func<TSource, bool> predicate, int skipCount, int takeCount)
        {
            var list = new List<TSource>();

            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index]))
                    list.Add(source[index]);
            }

            return list;
        }

        [Pure]
        static List<TSource> ToList<TSource>(this TSource[] source, Func<TSource, int, bool> predicate, int skipCount, int takeCount)
        {
            var list = new List<TSource>();

            var end = skipCount + takeCount;
            for (var index = skipCount; index < end; index++)
            {
                if (predicate(source[index], index))
                    list.Add(source[index]);
            }

            return list;
        }


        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        sealed class ToListCollection<TSource>
            : ICollection<TSource>
        {
            readonly TSource[] source;
            readonly int skipCount;
            readonly int takeCount;

            public ToListCollection(TSource[] source, int skipCount, int takeCount)
            {
                this.source = source;
                this.skipCount = skipCount;
                this.takeCount = takeCount;
            }

            public int Count => takeCount;

            public bool IsReadOnly => true;

            public void CopyTo(TSource[] array, int _)
            {
                for (var index = 0; index < takeCount; index++)
                    array[index] = source[index + skipCount];
            }

            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => throw new NotSupportedException();
            IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
            void ICollection<TSource>.Add(TSource item) => throw new NotSupportedException();
            bool ICollection<TSource>.Remove(TSource item) => throw new NotSupportedException();
            void ICollection<TSource>.Clear() => throw new NotSupportedException();
            bool ICollection<TSource>.Contains(TSource item) => throw new NotSupportedException();
        }
    }
}
