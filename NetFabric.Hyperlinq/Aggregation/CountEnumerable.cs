using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();

            return CountMethod<TEnumerable, TSource>.Invoke(source);

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }

        static class CountMethod<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            public static Func<TEnumerable, int> Invoke { get; } = Create();

            public static Func<TEnumerable, int> Create()
            {
                var enumerableType = typeof(TEnumerable);
                var getEnumerator = enumerableType.GetMethod("GetEnumerator");
                var enumeratorType = getEnumerator.ReturnType;

                var enumerableParameter = Expression.Parameter(enumerableType, "enumerable");
                var enumeratorVariable = Expression.Variable(enumeratorType, "enumerator");
                var countVariable = Expression.Variable(typeof(int), "count");
                var breakLabel = Expression.Label("LoopBreak");

                var body = Expression.Block(new[] { enumeratorVariable, countVariable },
                    Expression.Assign(countVariable, Expression.Constant(0)),
                    Expression.Assign(enumeratorVariable, Expression.Call(enumerableParameter, getEnumerator)),
                    Expression.TryFinally(
                        Expression.Loop(
                            Expression.IfThenElse(
                                Expression.Call(enumeratorVariable, enumeratorType.GetMethod("MoveNext")),
                                Expression.Assign(countVariable, Expression.Increment(countVariable)),
                                Expression.Break(breakLabel)),
                            breakLabel),
                        Expression.Call(enumeratorVariable, typeof(IDisposable).GetMethod("Dispose"))));

                return Expression.Lambda<Func<TEnumerable, int>>(body, enumerableParameter).Compile();        
            }
        }

        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();

            var count = 0;
            using (var enumerator = (TEnumerator)source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (predicate(enumerator.Current))
                        count++;
                }
            }
            return count;

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }
    }
}
