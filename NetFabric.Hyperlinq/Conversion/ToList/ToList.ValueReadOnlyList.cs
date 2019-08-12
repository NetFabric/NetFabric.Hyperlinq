using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyList
    {
        [Pure]
        public static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            switch (source)
            {
                case ICollection<TSource> collection:
                    return new List<TSource>(collection); // no need to allocate helper class

                default:
                    return new List<TSource>(new ToListCollection<TEnumerable, TEnumerator, TSource>(source, 0, source.Count));
            }
        }

        [Pure]
        static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new List<TSource>(new ToListCollection<TEnumerable, TEnumerator, TSource>(source, skipCount, takeCount));

        [Pure]
        static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
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
        static List<TSource> ToList<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate, int skipCount, int takeCount)
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
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
        sealed class ToListCollection<TEnumerable, TEnumerator, TSource>
            : ICollection<TSource>
            where TEnumerable : IValueReadOnlyList<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly int skipCount;
            readonly int takeCount;

            public ToListCollection(TEnumerable source, int skipCount, int takeCount)
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
