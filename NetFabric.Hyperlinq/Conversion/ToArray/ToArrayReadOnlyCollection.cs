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
            using (var enumerator = (TEnumerator)source.GetEnumerator())
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
                var elementType = typeof(TSource);
                var enumerableType = typeof(TEnumerable);

                var getEnumeratorMethod = enumerableType.GetMethod("GetEnumerator");
                var enumeratorType = getEnumeratorMethod.ReturnType;

                var enumerableParameter = Expression.Parameter(enumerableType, "enumerable");
                var enumeratorVariable = Expression.Variable(enumeratorType, "enumerator");
                var countVariable = Expression.Variable(typeof(int), "count");
                var arrayVariable = Expression.Variable(typeof(TSource[]), "array");
                var indexVariable = Expression.Variable(typeof(int), "index");
                var breakLabel = Expression.Label("LoopBreak");

                Expression loop = Expression.Loop(
                    Expression.IfThenElse(
                        Expression.Call(enumeratorVariable, typeof(IEnumerator).GetMethod("MoveNext")),
                        Expression.Block(new[] { enumeratorVariable, indexVariable },
                            Expression.Assign(Expression.ArrayIndex(arrayVariable, indexVariable), Expression.Property(enumeratorVariable, "Current")),
                            Expression.Assign(indexVariable, Expression.Increment(indexVariable))),
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
                    Expression.Assign(countVariable, Expression.Property(enumerableParameter, "Count")),
                    Expression.Assign(arrayVariable, Expression.NewArrayBounds(elementType, countVariable)),
                    Expression.Assign(indexVariable, Expression.Constant(0)),
                    Expression.Assign(enumeratorVariable, Expression.Call(enumerableParameter, getEnumeratorMethod)),
                    loop,
                    arrayVariable);

                return Expression.Lambda<Func<TEnumerable, TSource[]>>(body, enumerableParameter).Compile();        
            }
        }
    }
}
