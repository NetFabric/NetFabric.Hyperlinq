using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();

#if EXPRESSION_TREES
            return ToArrayMethod<TEnumerable, TSource>.Invoke(source);
#else
            var count = source.Count;
            var array = new TSource[count];
            var index = 0;
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    array[index] = enumerator.Current;
                    index++;
                }
            }
            return array;
#endif

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }

        static class ToArrayMethod<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            public static Func<TEnumerable, TSource[]> Invoke { get; } = Create();

            public static Func<TEnumerable, TSource[]> Create()
            {
                var enumerableType = typeof(TEnumerable);

                var getEnumeratorMethod = enumerableType.GetMethod("GetEnumerator");
                var enumeratorType = getEnumeratorMethod.ReturnType;

                var enumerable = Expression.Parameter(enumerableType, "enumerable");
                var enumerator = Expression.Variable(enumeratorType, "enumerator");
                var count = Expression.Variable(typeof(int), "count");
                var array = Expression.Variable(typeof(TSource[]), "array");
                var index = Expression.Variable(typeof(int), "index");

                var body = Expression.Block(new[] { enumerator, count },
                    Expression.Assign(count, Expression.Constant(0)),
                    Expression.Assign(enumerator, Expression.Call(enumerable, getEnumeratorMethod)),
                    ExpressionEx.EnumerationLoop(enumerable, enumerator,
                        Expression.Block(new[] { enumerator, index },
                            Expression.Assign(Expression.ArrayIndex(array, index), Expression.Property(enumerator, "Current")),
                            Expression.Assign(index, Expression.Increment(index)))),
                    count);

                return Expression.Lambda<Func<TEnumerable, TSource[]>>(body, enumerable).Compile();        
            }
        }
    }
}
