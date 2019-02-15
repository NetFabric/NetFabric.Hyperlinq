using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static int Count<TEnumerable, TSource>(this TEnumerable source)
            where TEnumerable : IEnumerable<TSource>
        {
            if (source == null) ThrowSourceNull();

#if EXPRESSION_TREES
            return CountMethod<TEnumerable, TSource>.Invoke(source);
#else
            var count = 0;
            using(var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                    count++;
            }
            return count;
#endif

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }

        static class CountMethod<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            public static Func<TEnumerable, int> Invoke { get; } = Create();

            public static Func<TEnumerable, int> Create()
            {
                var enumerableType = typeof(TEnumerable);

                var getEnumeratorMethod = enumerableType.GetMethod("GetEnumerator");
                var enumeratorType = getEnumeratorMethod.ReturnType;

                var enumerableParameter = Expression.Parameter(enumerableType, "enumerable");
                var enumeratorVariable = Expression.Variable(enumeratorType, "enumerator");
                var countVariable = Expression.Variable(typeof(int), "count");
                var breakLabel = Expression.Label("LoopBreak");

                Expression loop = Expression.Loop(
                    Expression.IfThenElse(
                        Expression.Call(enumeratorVariable, typeof(IEnumerator).GetMethod("MoveNext")),
                        Expression.Assign(countVariable, Expression.Increment(countVariable)),
                        Expression.Break(breakLabel)),
                    breakLabel);

                var disposeMethod = enumeratorType.GetMethod("Dispose", BindingFlags.Public | BindingFlags.Instance, Type.DefaultBinder, Type.EmptyTypes, new ParameterModifier[] { });
                if (disposeMethod is null)
                {
                    if (typeof(IDisposable).IsAssignableFrom(enumeratorType))
                    {
                        loop = Expression.TryFinally(
                           loop,
                           Expression.Call(Expression.TypeAs(enumeratorVariable, typeof(IDisposable)), typeof(IDisposable).GetMethod("Dispose")));
                    }
                }
                else
                {
                    loop = Expression.TryFinally(
                       loop,
                       Expression.Call(enumeratorVariable, disposeMethod));
                }

                var body = Expression.Block(new[] { enumeratorVariable, countVariable },
                    Expression.Assign(countVariable, Expression.Constant(0)),
                    Expression.Assign(enumeratorVariable, Expression.Call(enumerableParameter, getEnumeratorMethod)),
                    loop,
                    countVariable);

                return Expression.Lambda<Func<TEnumerable, int>>(body, enumerableParameter).Compile();        
            }
        }

        public static int Count<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IEnumerable<TSource>
        {
            if (source == null) ThrowSourceNull();

#if EXPRESSION_TREES
            return CountMethod<TEnumerable, TSource>.Invoke(source);
#else
            var count = 0;
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (predicate(enumerator.Current))
                        count++;
                }
            }
            return count;
#endif

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }

        static class CountPredicateMethod<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            public static Func<TEnumerable, Func<TSource, bool>, int> Invoke { get; } = Create();

            public static Func<TEnumerable, Func<TSource, bool>, int> Create()
            {
                var elementType = typeof(TSource);
                var enumerableType = typeof(TEnumerable);

                var getEnumeratorMethod = enumerableType.GetMethod("GetEnumerator");
                var enumeratorType = getEnumeratorMethod.ReturnType;

                var enumerableParameter = Expression.Parameter(enumerableType, "enumerable");
                var predicateParameter = Expression.Parameter(typeof(Func<,>).MakeGenericType(elementType, typeof(bool)), "predicate");
                var enumeratorVariable = Expression.Variable(enumeratorType, "enumerator");
                var countVariable = Expression.Variable(typeof(int), "count");
                var breakLabel = Expression.Label("LoopBreak");

                Expression loop = Expression.Loop(
                    Expression.IfThenElse(
                        Expression.Call(enumeratorVariable, typeof(IEnumerator).GetMethod("MoveNext")),
                        Expression.IfThen(
                            Expression.Invoke(predicateParameter, Expression.Property(enumeratorVariable, "Current")),
                            Expression.Assign(countVariable, Expression.Increment(countVariable))),
                        Expression.Break(breakLabel)),
                    breakLabel);

                var disposeMethod = enumeratorType.GetMethod("Dispose", BindingFlags.Public | BindingFlags.Instance, Type.DefaultBinder, Type.EmptyTypes, new ParameterModifier[] { });
                if (disposeMethod is null)
                {
                    if (typeof(IDisposable).IsAssignableFrom(enumeratorType))
                    {
                        loop = Expression.TryFinally(
                           loop,
                           Expression.Call(Expression.TypeAs(enumeratorVariable, typeof(IDisposable)), typeof(IDisposable).GetMethod("Dispose")));
                    }
                }
                else
                {
                    loop = Expression.TryFinally(
                       loop,
                       Expression.Call(enumeratorVariable, disposeMethod));
                }

                var body = Expression.Block(new[] { enumeratorVariable, countVariable },
                    Expression.Assign(countVariable, Expression.Constant(0)),
                    Expression.Assign(enumeratorVariable, Expression.Call(enumerableParameter, getEnumeratorMethod)),
                    loop,
                    countVariable);

                return Expression.Lambda<Func<TEnumerable, Func<TSource, bool>, int>>(body, enumerableParameter).Compile();        
            }
        }

    }
}
