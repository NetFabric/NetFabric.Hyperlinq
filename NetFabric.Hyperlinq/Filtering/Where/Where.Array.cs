using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static WhereEnumerable<TSource> Where<TSource>(this TSource[] source, Func<TSource, long, bool> predicate) 
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return new WhereEnumerable<TSource>(source, predicate);
        }

        [GenericsTypeMapping("TEnumerable", typeof(WhereEnumerable<>))]
        [GenericsTypeMapping("TEnumerator", typeof(WhereEnumerable<>.Enumerator))]
        public readonly struct WhereEnumerable<TSource>
            : IValueEnumerable<TSource, WhereEnumerable<TSource>.Enumerator>
        {
            internal readonly TSource[] source;
            internal readonly Func<TSource, long, bool> predicate;

            internal WhereEnumerable(TSource[] source, Func<TSource, long, bool> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public struct Enumerator 
                : IValueEnumerator<TSource>
            {
                readonly TSource[] source;
                readonly Func<TSource, long, bool> predicate;
                readonly int count;
                int index;

                internal Enumerator(in WhereEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    count = enumerable.source.Length;
                    index = -1;
                }

                public ref TSource Current => ref source[index];
                TSource IValueEnumerator<TSource>.Current => source[index];

                public bool MoveNext()
                {
                    while (++index < count)
                    {
                        if (predicate(source[index], index))
                            return true;
                    }
                    return false;
                }

                public void Dispose() { }
            }

            public long Count()
                => source.Count(predicate);

            public bool Any()
                => source.Any<TSource>(predicate);

            public Array.WhereEnumerable<TSource> Where(Func<TSource, long, bool> predicate)
                => Array.Where<TSource>(source, Utils.Combine(this.predicate, predicate));

            public ref TSource First()
                => ref Array.First<TSource>(source, predicate);
            public ref readonly TSource FirstOrDefault()
                => ref Array.FirstOrDefault<TSource>(source, predicate);

            public ref TSource Single()
                => ref Array.Single<TSource>(source, predicate);
            public ref readonly TSource SingleOrDefault()
                => ref Array.SingleOrDefault<TSource>(source, predicate);
        }
    }
}

