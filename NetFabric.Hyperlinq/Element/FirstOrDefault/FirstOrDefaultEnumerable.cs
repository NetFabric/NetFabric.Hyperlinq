using System;
using System.Collections;
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
                var enumerableType = typeof(TEnumerable);
                var enumerable = Expression.Parameter(enumerableType, "enumerable");
                var getEnumerator = enumerableType.GetMethod("GetEnumerator");
                if (getEnumerator is null)
                    getEnumerator = typeof(IEnumerable<>).MakeGenericType(elementType).GetMethod("GetEnumerator");
                var enumeratorType = getEnumerator.ReturnType;
                var enumerator = Expression.Variable(enumeratorType, "enumerator");
                var returnTarget = Expression.Label(elementType);

                var body = Expression.Block(elementType, new[] { enumerator },
                    Expression.Assign(enumerator, Expression.Call(enumerable, getEnumerator)),
                    ExpressionEx.Using(enumerator,
                        Expression.Block(new ParameterExpression[] { },
                            Expression.IfThen(
                                Expression.Not(Expression.Call(enumerator, typeof(IEnumerator).GetMethod("MoveNext"))),
                                Expression.Return(returnTarget, Expression.Default(elementType))),
                            Expression.Return(returnTarget, Expression.Property(enumerator, "Current")))),
                    Expression.Label(returnTarget, Expression.Default(elementType)));

                return Expression.Lambda<Func<TEnumerable, TSource>>(body, enumerable).Compile();
            }
        }

        public static TSource FirstOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

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
        }
    }
}
