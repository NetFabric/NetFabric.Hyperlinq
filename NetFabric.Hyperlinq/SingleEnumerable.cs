using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static TSource Single<TSource>(this IEnumerable<TSource> source) =>
            Single<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TResult Single<TEnumerable, TEnumerator, TSource, TResult>(
            this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source)
                where TEnumerable : IEnumerable<TSource>
                where TEnumerator : IEnumerator<TSource> =>
                    Single<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator, TResult>(source);

        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();

            using (var enumerator = (TEnumerator)source.GetEnumerator())
            {
                if(!enumerator.MoveNext())
                    ThrowEmptySequence();

                return enumerator.Current;
            }

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowEmptySequence() => throw new InvalidOperationException(Resource.EmptySequence);
            void ThrowNotSingleSequence() => throw new InvalidOperationException(Resource.NotSingleSequence);
        }

        public static TSource Single<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) =>
            Single<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TResult Single<TEnumerable, TEnumerator, TSource, TResult>(
            this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source,
            Func<TResult, bool> predicate)
                where TEnumerable : IEnumerable<TSource>
                where TEnumerator : IEnumerator<TSource> =>
                    Single<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator, TResult>(source, predicate);

        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();

            using (var enumerator = (TEnumerator)source.GetEnumerator())
            {
                while(enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    if(predicate(current))
                        return current;
                }
                ThrowEmptySequence();
                return default;
            }

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowEmptySequence() => throw new InvalidOperationException(Resource.EmptySequence);
            void ThrowNotSingleSequence() => throw new InvalidOperationException(Resource.NotSingleSequence);
        }
    }
}
