using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source) =>
            FirstOrDefault<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TResult FirstOrDefault<TEnumerable, TEnumerator, TSource, TResult>(
            this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source)
                where TEnumerable : IEnumerable<TSource>
                where TEnumerator : IEnumerator<TSource> =>
                    FirstOrDefault<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator, TResult>(source);

        public static TSource FirstOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();

            using (var enumerator = (TEnumerator)source.GetEnumerator())
            {
                if(!enumerator.MoveNext())
                    return default;

                return enumerator.Current;
            }

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }

        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) =>
            FirstOrDefault<IEnumerable<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TResult FirstOrDefault<TEnumerable, TEnumerator, TSource, TResult>(
            this SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult> source,
            Func<TResult, bool> predicate)
                where TEnumerable : IEnumerable<TSource>
                where TEnumerator : IEnumerator<TSource> =>
                    FirstOrDefault<SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>, SelectEnumerable<TEnumerable, TEnumerator, TSource, TResult>.Enumerator, TResult>(source, predicate);

        public static TSource FirstOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
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
                return default;
            }

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }
    }
}
