using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static WhereEnumerable<TSource> Where<TSource>(this TSource[] source, Func<TSource, bool> predicate) 
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return new WhereEnumerable<TSource>(source, predicate, 0, source.Length);
        }

        static WhereEnumerable<TSource> Where<TSource>(this TSource[] source, Func<TSource, bool> predicate, int skipCount, int takeCount)
            => new WhereEnumerable<TSource>(source, predicate, skipCount, takeCount);

        [GenericsTypeMapping("TEnumerable", typeof(WhereEnumerable<>))]
        [GenericsTypeMapping("TEnumerator", typeof(WhereEnumerable<>.Enumerator))]
        public readonly struct WhereEnumerable<TSource>
            : IValueEnumerable<TSource, WhereEnumerable<TSource>.Enumerator>
        {
            readonly TSource[] source;
            readonly Func<TSource, bool> predicate;
            readonly int skipCount;
            readonly int takeCount;

            internal WhereEnumerable(TSource[] source, Func<TSource, bool> predicate, int skipCount, int takeCount)
            {
                this.source = source;
                this.predicate = predicate;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Length, skipCount, takeCount);
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator 
                : IEnumerator<TSource>
            {
                readonly TSource[] source;
                readonly Func<TSource, bool> predicate;
                readonly int end;
                int index;

                internal Enumerator(in WhereEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    end = enumerable.skipCount + enumerable.takeCount;
                    index = enumerable.skipCount - 1;
                }

                public ref TSource Current => ref source[index];
                TSource IEnumerator<TSource>.Current => source[index];
                object IEnumerator.Current => source[index];

                public bool MoveNext()
                {
                    while (++index < end)
                    {
                        if (predicate(source[index]))
                            return true;
                    }
                    return false;
                }

                void IEnumerator.Reset()
                    => throw new NotSupportedException();

                public void Dispose() { }
            }

            public int Count()
                => source.Count(predicate, skipCount, takeCount);

            public bool Any()
                => Array.Any<TSource>(source, predicate, skipCount, takeCount);

            public Array.WhereEnumerable<TSource> Where(Func<TSource, bool> predicate)
                => Array.Where<TSource>(source, Utils.Combine(this.predicate, predicate), skipCount, takeCount);

            public ref readonly TSource First()
                => ref Array.First<TSource>(source, predicate, skipCount, takeCount);
            public ref readonly TSource FirstOrDefault()
                => ref Array.FirstOrDefault<TSource>(source, predicate, skipCount, takeCount);

            public ref readonly TSource Single()
                => ref Array.Single<TSource>(source, predicate, skipCount, takeCount);
            public ref readonly TSource SingleOrDefault()
                => ref Array.SingleOrDefault<TSource>(source, predicate, skipCount, takeCount);

            public List<TSource> ToList()
                => Array.ToList<TSource>(source, predicate, skipCount, takeCount);
        }
    }
}

