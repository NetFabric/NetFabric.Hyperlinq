using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static TSource First<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IEnumerable<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

#if EXPRESSION_TREES
            return FirstMethod<TEnumerable, TSource>.Invoke(source);
#else
            using (var enumerator = source.GetEnumerator())
            {
                if(!enumerator.MoveNext())
                    ThrowEmptySequence();

                return enumerator.Current;
            }
#endif
        }

        static class FirstMethod<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            public static Func<TEnumerable, TSource> Invoke { get; } = Create();

            public static Func<TEnumerable, TSource> Create()
            {
                var enumerableType = typeof(TEnumerable);
                var enumerable = Expression.Parameter(enumerableType, "enumerable");
                var getEnumerator = enumerableType.GetMethod("GetEnumerator");
                var enumeratorType = getEnumerator.ReturnType;
                var enumerator = Expression.Variable(enumeratorType, "enumerator");

                var body = Expression.Block(new[] { enumerator },
                    Expression.Assign(enumerator, Expression.Call(enumerable, getEnumerator)),
                    ExpressionEx.EnumerationLoop(enumerator,
                        Expression.IfThen(
                            Expression.Not(Expression.Call(enumerator, typeof(IEnumerator).GetMethod("MoveNext"))),
                            Expression.Call(typeof(ThrowHelper), "ThrowEmptySequence", Type.EmptyTypes))));

                return Expression.Lambda<Func<TEnumerable, TSource>>(body, enumerable).Compile();
            }
        }

        public static TSource First<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            using (var enumerator = (TEnumerator)source.GetEnumerator())
            {
                while(enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    if (predicate(current))
                        return current;
                }
                ThrowHelper.ThrowEmptySequence();
                return default;
            }
        }
    }
}
