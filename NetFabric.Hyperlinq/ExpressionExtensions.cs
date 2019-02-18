using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace NetFabric.Hyperlinq
{
    static partial class ExpressionEx
    {
        const string NotEnumerableMessage = "type used in a foreach statement must be implicitly convertible to 'System.Collections.IEnumerable'";
        const string NotDisposableMessage = "type used in a using statement must be implicitly convertible to 'System.IDisposable'";

        public static Expression ForEach<TSource>(Expression enumerable, Expression loopContent)
        {
            var enumerableType = enumerable.Type;
            var getEnumerator = GetEnumerator<TSource>(enumerableType);
            if (getEnumerator is null)
                throw new ArgumentException($"'{enumerableType.FullName}': {NotEnumerableMessage}", nameof(enumerable));
            var enumeratorType = getEnumerator.ReturnType;
            var enumerator = Expression.Variable(enumeratorType, "enumerator");

            return Expression.Block(new[] { enumerator },
                Expression.Assign(enumerator, Expression.Call(enumerable, getEnumerator)),
                EnumerationLoop(enumerator, loopContent));
        }

        public static Expression ForEach<TSource>(Expression enumerable, ParameterExpression loopVar, Expression loopContent)
        {
            var enumerableType = enumerable.Type;
            var getEnumerator = GetEnumerator<TSource>(enumerableType);
            if (getEnumerator is null)
                throw new ArgumentException($"'{enumerableType.FullName}': {NotEnumerableMessage}", nameof(enumerable));
            var enumeratorType = getEnumerator.ReturnType;
            var enumerator = Expression.Variable(enumeratorType, "enumerator");

            return Expression.Block(new[] { enumerator },
                Expression.Assign(enumerator, Expression.Call(enumerable, getEnumerator)),
                EnumerationLoop(enumerator,
                    Expression.Block(new[] { loopVar },
                        Expression.Assign(loopVar, Expression.Property(enumerator, "Current")),
                        loopContent)));
        }

        static MethodInfo GetEnumerator<TSource>(Type enumerableType)
        {
            var getEnumerator = enumerableType.GetMethod("GetEnumerator");
            if (!(getEnumerator is null))
                return getEnumerator;

            var enumerableSourceType = typeof(IEnumerable<>).MakeGenericType(typeof(TSource));
            if (enumerableSourceType.IsAssignableFrom(enumerableType))
                return enumerableSourceType.GetMethod("GetEnumerator");

            if (typeof(IEnumerable).IsAssignableFrom(enumerableType))
                return typeof(IEnumerable).GetMethod("GetEnumerator");

            return null;
        }

        static Expression EnumerationLoop(ParameterExpression enumerator, Expression loopContent)
        {
            var loop = While(
                Expression.Call(enumerator, typeof(IEnumerator).GetMethod("MoveNext")),
                loopContent);

            var enumeratorType = enumerator.Type;
            if (typeof(IDisposable).IsAssignableFrom(enumeratorType))
                return Using(enumerator, loop);

            if (!enumeratorType.IsValueType)
            {
                var disposable = Expression.Variable(typeof(IDisposable), "disposable");
                return Expression.TryFinally(
                    loop,
                    Expression.Block(new[] { disposable },
                        Expression.Assign(disposable, Expression.TypeAs(enumerator, typeof(IDisposable))),
                        Expression.IfThen(
                            Expression.NotEqual(disposable, Expression.Constant(null)),
                            Expression.Call(disposable, typeof(IDisposable).GetMethod("Dispose")))));
            }

            return loop;
        }

        public static Expression Using(ParameterExpression variable, Expression content)
        {
            var variableType = variable.Type;

            if (!typeof(IDisposable).IsAssignableFrom(variableType))
                throw new Exception($"'{variableType.FullName}': {NotDisposableMessage}");

            var disposeMethod = typeof(IDisposable).GetMethod("Dispose");

            if (variableType.IsValueType)
            {
                return Expression.TryFinally(
                    content,
                    Expression.Call(Expression.Convert(variable, typeof(IDisposable)), disposeMethod));
            }

            if (variableType.IsInterface)
            {
                return Expression.TryFinally(
                    content,
                    Expression.IfThen(
                        Expression.NotEqual(variable, Expression.Constant(null)),
                        Expression.Call(variable, disposeMethod)));
            }

            return Expression.TryFinally(
                content,
                Expression.IfThen(
                    Expression.NotEqual(variable, Expression.Constant(null)),
                    Expression.Call(Expression.Convert(variable, typeof(IDisposable)), disposeMethod)));
        }

        public static Expression While(Expression loopCondition, Expression loopContent)
        {
            var breakLabel = Expression.Label();
            return Expression.Loop(
                Expression.IfThenElse(
                    loopCondition,
                    loopContent,
                    Expression.Break(breakLabel)),
                breakLabel);
        }
    }
}
