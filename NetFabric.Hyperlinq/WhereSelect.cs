using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static WhereSelectEnumerable<TSource, TResult> WhereSelect<TEnumerable, TSource, TResult>(this TEnumerable source, Func<TSource, ValueTuple<bool, TResult>> predicateSelector) 
            where TEnumerable : IEnumerable<TSource> 
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));

            if(predicateSelector == null)
                throw new ArgumentNullException(nameof(predicateSelector));

            return new WhereSelectEnumerable<TSource, TResult>(source, predicateSelector);
        }

        public static IndexWhereSelectEnumerable<TSource, TResult> WhereSelect<TEnumerable, TSource, TResult>(this TEnumerable source, Func<TSource, int, ValueTuple<bool, TResult>> predicateSelector) 
            where TEnumerable : IEnumerable<TSource> 
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));

            if(predicateSelector == null)
                throw new ArgumentNullException(nameof(predicateSelector));

            return new IndexWhereSelectEnumerable<TSource, TResult>(source, predicateSelector);
        }

        public readonly struct WhereSelectEnumerable<TSource, TResult> : IEnumerable<TResult>
        {
            readonly IEnumerable<TSource> source;
            readonly Func<TSource, ValueTuple<bool, TResult>> predicateSelector;

            internal WhereSelectEnumerable(IEnumerable<TSource> source, Func<TSource, ValueTuple<bool, TResult>> predicateSelector)
            {
                this.source = source;
                this.predicateSelector = predicateSelector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator : IEnumerator<TResult>
            {
                readonly IEnumerator<TSource> enumerator;
                readonly Func<TSource, ValueTuple<bool, TResult>> predicateSelector;
                TResult current;

                internal Enumerator(in WhereSelectEnumerable<TSource, TResult> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    predicateSelector = enumerable.predicateSelector;
                    current = default;
                }

                public TResult Current => current;
                object IEnumerator.Current => current;

                public bool MoveNext()
                {
                    bool valid;
                    TResult item;
                    while (enumerator.MoveNext())
                    {
                        (valid, item) = predicateSelector(enumerator.Current);
                        if (valid)
                        {
                            current = item;
                            return true;
                        }
                    }
                    return false;
                }

                public void Reset() => throw new NotSupportedException();

                public void Dispose() => enumerator.Dispose();
            }
        }

        public readonly struct IndexWhereSelectEnumerable<TSource, TResult> : IEnumerable<TResult>
        {
            readonly IEnumerable<TSource> source;
            readonly Func<TSource, int, ValueTuple<bool, TResult>> predicateSelector;

            internal IndexWhereSelectEnumerable(IEnumerable<TSource> source, Func<TSource, int, ValueTuple<bool, TResult>> predicateSelector)
            {
                this.source = source;
                this.predicateSelector = predicateSelector;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator : IEnumerator<TResult>
            {
                readonly IEnumerator<TSource> enumerator;
                readonly Func<TSource, int, ValueTuple<bool, TResult>> predicateSelector;
                TResult current;
                int index;

                internal Enumerator(in IndexWhereSelectEnumerable<TSource, TResult> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    predicateSelector = enumerable.predicateSelector;
                    current = default;
                    index = -1;
                }

                public TResult Current => current;
                object IEnumerator.Current => current;

                public bool MoveNext()
                {
                    bool valid;
                    TResult item;
                    while (enumerator.MoveNext())
                    {
                        index++;
                        (valid, item) = predicateSelector(enumerator.Current, index);
                        if (valid)
                        {
                            current = item;
                            return true;
                        }
                    }
                    return false;
                }

                public void Reset() => throw new NotSupportedException();

                public void Dispose() => enumerator.Dispose();
            }
        }
    }
}

