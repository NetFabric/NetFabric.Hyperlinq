using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static RepeatEnumerable<TSource> Repeat<TSource>(TSource value, long count)
        {
            if (count < 0) ThrowHelper.ThrowArgumentOutOfRangeException(nameof(count));

            return new RepeatEnumerable<TSource>(value, count);
        }

        public readonly struct RepeatEnumerable<TSource>
            : IValueReadOnlyList<TSource, RepeatEnumerable<TSource>.Enumerator>
        {
            internal readonly TSource value;
            internal readonly long count;

            internal RepeatEnumerable(TSource value, long count)
            {
                this.value = value;
                this.count = count;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public long Count => count;

            public TSource this[long index]
            {
                get
                {
                    if (index < 0 || index >= count) ThrowHelper.ThrowIndexOutOfRangeException();

                    return value;
                }
            }

            public struct Enumerator
                : IValueEnumerator<TSource>
            {
                readonly TSource value;
                long counter;

                internal Enumerator(in RepeatEnumerable<TSource> enumerable)
                {
                    value = enumerable.value;
                    counter = enumerable.count;
                }

                public TSource Current
                    => value;

                public bool MoveNext()
                    => counter-- > 0;

                public void Dispose() { }
            }

            public RepeatEnumerable<TSource> Skip(long count)
            {
                (_, var takeCount) = Utils.Skip(this.count, count);
                return Repeat(value, takeCount);
            }

            public RepeatEnumerable<TSource> Take(long count)
                => Repeat(value, Utils.Take(this.count, count));

            public bool All(Func<TSource, long, bool> predicate)
                => ValueReadOnlyList.All<RepeatEnumerable<TSource>, Enumerator, TSource>(this, predicate);

            public bool Any()
                => count != 0;

            public bool Any(Func<TSource, long, bool> predicate)
                => ValueReadOnlyList.Any<RepeatEnumerable<TSource>, Enumerator, TSource>(this, predicate);

            public bool Contains(TSource value)
                => count != 0 && this.value.Equals(value);

            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => count != 0 && comparer.Equals(this.value, value);

            public ValueReadOnlyList.SelectEnumerable<RepeatEnumerable<TSource>, Enumerator, TSource, TResult> Select<TResult>(Func<TSource, long, TResult> selector) 
                => ValueReadOnlyList.Select<RepeatEnumerable<TSource>, Enumerator, TSource, TResult>(this, selector);

            public ValueReadOnlyList.SelectManyEnumerable<RepeatEnumerable<TSource>, Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSubEnumerable, TSubEnumerator, TResult>(Func<TSource, TSubEnumerable> selector) 
                where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
                where TSubEnumerator : struct, IValueEnumerator<TResult>
                => ValueReadOnlyList.SelectMany<RepeatEnumerable<TSource>, Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(this, selector);

            public ValueReadOnlyList.WhereEnumerable<RepeatEnumerable<TSource>, Enumerator, TSource> Where(Func<TSource, long, bool> predicate) 
                => ValueReadOnlyList.Where<RepeatEnumerable<TSource>, Enumerator, TSource>(this, predicate);

            public TSource First()
                => (count > 0) ? value : ThrowHelper.ThrowEmptySequence<TSource>();
            public TSource First(Func<TSource, long, bool> predicate) 
                => ValueReadOnlyList.First<RepeatEnumerable<TSource>, Enumerator, TSource>(this, predicate);

            public TSource FirstOrDefault()
                => (count > 0) ? value : default;
            public TSource FirstOrDefault(Func<TSource, long, bool> predicate) 
                => ValueReadOnlyList.FirstOrDefault<RepeatEnumerable<TSource>, Enumerator, TSource>(this, predicate);

            public TSource Single()
                => (count == 0) ? ThrowHelper.ThrowEmptySequence<TSource>() : ((count == 1) ? value : ThrowHelper.ThrowNotSingleSequence<TSource>());
            public TSource Single(Func<TSource, long, bool> predicate) 
                => ValueReadOnlyList.Single<RepeatEnumerable<TSource>, Enumerator, TSource>(this, predicate);

            public TSource SingleOrDefault()
                => (count == 0) ? default : ((count == 1) ? value : ThrowHelper.ThrowNotSingleSequence<TSource>());
            public TSource SingleOrDefault(Func<TSource, long, bool> predicate) 
                => ValueReadOnlyList.SingleOrDefault<RepeatEnumerable<TSource>, Enumerator, TSource>(this, predicate);

            public IReadOnlyList<TSource> AsEnumerable()
                => ValueReadOnlyList.AsEnumerable<RepeatEnumerable<TSource>, Enumerator, TSource>(this);

            public RepeatEnumerable<TSource> AsValueEnumerable()
                => this;

            public TSource[] ToArray()
            {
                var array = new TSource[count];
                if (value is object)
                {
#if NETCORE    
                    System.Array.Fill<TSource>(array, value);
#else                
                    for (var index = 0; index < count; index++)
                        array[index] = value;
#endif
                }
                return array;
            }

            public List<TSource> ToList()
                => new List<TSource>(new ToListCollection(this));

            class ToListCollection
                : ICollection<TSource>
            {
                readonly TSource value;
                readonly long count;

                public ToListCollection(in RepeatEnumerable<TSource> source)
                {
                    this.value = source.value;
                    this.count = source.count;
                }

                public int Count => (int)count;

                public bool IsReadOnly => true;

                public void CopyTo(TSource[] array, int _)
                {
                    if (value == null)
                        return;
                        
                    for(int index = 0; index < count; index++)
                        array[index] = value;
                }

                IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => throw new NotSupportedException();
                IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
                void ICollection<TSource>.Add(TSource item) => throw new NotSupportedException();
                bool ICollection<TSource>.Remove(TSource item) => throw new NotSupportedException();
                void ICollection<TSource>.Clear() => throw new NotSupportedException();
                bool ICollection<TSource>.Contains(TSource item) => throw new NotSupportedException();
            }
        }

        public static long Count<TSource>(this RepeatEnumerable<TSource> source)
            => source.Count;

        public static long Count<TSource>(this RepeatEnumerable<TSource> source, Func<TSource, long, bool> predicate)
            => ValueReadOnlyList.Count<RepeatEnumerable<TSource>, RepeatEnumerable<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource? FirstOrNull<TSource>(this RepeatEnumerable<TSource> source)
            where TSource : struct
            => (source.count > 0) ? source.value : (TSource?)null;

        public static TSource? FirstOrNull<TSource>(this RepeatEnumerable<TSource> source, Func<TSource, long, bool> predicate)
            where TSource : struct
            => ValueReadOnlyList.FirstOrNull<RepeatEnumerable<TSource>, RepeatEnumerable<TSource>.Enumerator, TSource>(source, predicate);

        public static TSource? SingleOrNull<TSource>(this RepeatEnumerable<TSource> source)
            where TSource : struct
            => (source.count == 0) ? null : ((source.count == 1) ? source.value : ThrowHelper.ThrowNotSingleSequence<TSource?>());

        public static TSource? SingleOrNull<TSource>(this RepeatEnumerable<TSource> source, Func<TSource, long, bool> predicate)
            where TSource : struct
            => ValueReadOnlyList.SingleOrNull<RepeatEnumerable<TSource>, RepeatEnumerable<TSource>.Enumerator, TSource>(source, predicate);
    }
}

