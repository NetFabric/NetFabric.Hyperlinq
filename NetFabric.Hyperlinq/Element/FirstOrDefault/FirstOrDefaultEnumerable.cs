using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static TSource FirstOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

#if EXPRESSION_TREES
            return FirstOrDefaultMethod<TEnumerable, TSource>.Invoke(source);
#else
            using (var enumerator = (TEnumerator)source.GetEnumerator())
            {
                if(!enumerator.MoveNext())
                    return default;

                return enumerator.Current;
            }
#endif
        }

        internal static class FirstOrDefaultMethod<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            public static Func<TEnumerable, TSource> Invoke { get; } = Create();

            public static Func<TEnumerable, TSource> Create()
            {
                var elementType = typeof(TSource);
                var enumerable = Expression.Parameter(typeof(TEnumerable), "enumerable");

                var body = ExpressionEx.First<TEnumerable, TSource>(enumerable,
                    Expression.Default(elementType));

                return Expression.Lambda<Func<TEnumerable, TSource>>(body, enumerable).Compile();
            }
        }

        public static TSource FirstOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

#if EXPRESSION_TREES
            return FirstOrDefaultPredicateMethod<TEnumerable, TSource>.Invoke(source, predicate);
#else
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
#endif
        }

        internal static class FirstOrDefaultPredicateMethod<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            public static Func<TEnumerable, Func<TSource, bool>, TSource> Invoke { get; } = Create();

            public static Func<TEnumerable, Func<TSource, bool>, TSource> Create()
            {
                var elementType = typeof(TSource);
                var enumerable = Expression.Parameter(typeof(TEnumerable), "enumerable");
                var predicate = Expression.Parameter(typeof(Func<,>).MakeGenericType(elementType, typeof(bool)), "predicate");

                var body = ExpressionEx.First<TEnumerable, TSource>(enumerable, predicate,
                    Expression.Default(elementType));

                return Expression.Lambda<Func<TEnumerable, Func<TSource, bool>, TSource>>(body, enumerable, predicate).Compile();
            }
        }
    }
}
