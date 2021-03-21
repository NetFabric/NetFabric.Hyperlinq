using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq.UnitTests
{
    public static partial class ExpressionEx
    {
        public static Expression ForEach<TSource>(Expression enumerable, Expression loopContent)
        {
            var enumerableType = enumerable.Type;
            var getEnumerator = enumerableType.GetMethod("GetEnumerator") 
                                ?? typeof(IEnumerable<>).MakeGenericType(typeof(TSource)).GetMethod("GetEnumerator");
            var enumeratorType = getEnumerator.ReturnType;
            var enumerator = Expression.Variable(enumeratorType, "enumerator");

            return Expression.Block(new[] { enumerator },
                Expression.Assign(enumerator, Expression.Call(enumerable, getEnumerator)),
                EnumerationLoop(enumerator, loopContent));
        }

        public static Expression ForEach<TSource>(Expression enumerable, ParameterExpression loopVar, Expression loopContent)
        {
            var enumerableType = enumerable.Type;
            var getEnumerator = enumerableType.GetMethod("GetEnumerator") 
                                ?? typeof(IEnumerable<>).MakeGenericType(typeof(TSource)).GetMethod("GetEnumerator");
            var enumeratorType = getEnumerator.ReturnType;
            var enumerator = Expression.Variable(enumeratorType, "enumerator");

            return Expression.Block(new[] { enumerator },
                Expression.Assign(enumerator, Expression.Call(enumerable, getEnumerator)),
                EnumerationLoop(enumerator,
                    Expression.Block(new[] { loopVar },
                        Expression.Assign(loopVar, Expression.Property(enumerator, "Current")),
                        loopContent)));
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
            return variable.Type switch
            {
                {IsValueType: true} => ValueTypeUsing(variable, content),
                
                _ => ReferenceTypeUsing(variable, content)
            };

            static Expression ValueTypeUsing(Expression variable, Expression content)
            {
#if NETCOREAPP2_1_OR_GREATER
                return variable.Type.GetCustomAttribute<IsByRefLikeAttribute>() switch
                {
                    null => ValueTypeUsing(variable, content),
                    
                    _ => ByRefLikeValueTypeUsing(variable, content)
                };
#else
                return ValueTypeUsing(variable, content);
#endif
                
                static Expression ValueTypeUsing(Expression variable, Expression content)
                    => typeof(IDisposable).IsAssignableFrom(variable.Type) switch
                    {
                        false => ThrowMustBeImplicitlyConvertibleToIDisposable<Expression>(variable),
                        
                        _ => Expression.TryFinally(
                            content,
                            Expression.Call(Expression.Convert(variable, typeof(IDisposable)), typeof(IDisposable).GetMethod("Dispose")!))
                    };

                static Expression ByRefLikeValueTypeUsing(Expression variable, Expression content)
                {
                    var disposeMethod = variable.Type.GetMethod("Dispose");
                    return disposeMethod switch
                    {
                        null => ThrowMustBeImplicitlyConvertibleToIDisposable<Expression>(variable),
                        
                        _ => Expression.TryFinally(
                            content,
                            Expression.Call(Expression.Convert(variable, typeof(IDisposable)), disposeMethod))
                    };
                }
            }

            static Expression ReferenceTypeUsing(Expression variable, Expression content)
                => typeof(IDisposable).IsAssignableFrom(variable.Type) switch
                {
                    false => ThrowMustBeImplicitlyConvertibleToIDisposable<Expression>(variable),
                    
                    _ => Expression.TryFinally(
                        content,
                        Expression.IfThen(
                            Expression.NotEqual(variable, Expression.Constant(null)),
                            Expression.Call(Expression.Convert(variable, typeof(IDisposable)), typeof(IDisposable).GetMethod("Dispose")!)))
                };

            static T ThrowMustBeImplicitlyConvertibleToIDisposable<T>(Expression variable)
                => throw new Exception($"'{variable.Type.FullName}': type used in a using statement must be implicitly convertible to 'System.IDisposable'");
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