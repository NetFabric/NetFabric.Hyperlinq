using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static long Count<TEnumerable, TSource>(this TEnumerable source) where TEnumerable : IEnumerable<TSource>
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));
                
            if (source is ICollection<TSource> collection)
                return collection.Count;

            if (source is IReadOnlyCollection<TSource> readOnlyCollection)
                return readOnlyCollection.Count;
                                
            return CountCache<TEnumerable, TSource>.count(source);
        }

        // var counter = 0L;
        // using(var enumerator = source.GetEnumerator())
        // {
        //     while (enumerator.MoveNext())
        //         counter++;
        // }
        // return counter;

        static class CountCache<TEnumerable, TSource> where TEnumerable : IEnumerable<TSource>
        {
            public static readonly Func<TEnumerable, long> count;

            static CountCache()
            {
                var enumerableType = typeof(TEnumerable);
                var enumerableParameter = Expression.Parameter(enumerableType);

                var getEnumeratorInfo = enumerableType.GetMethod("GetEnumerator");
                var enumeratorType = getEnumeratorInfo.ReturnType;
                var moveNext = enumeratorType.GetMethod("MoveNext");
                if(moveNext is null)
                    moveNext = typeof(IEnumerator).GetMethod("MoveNext");

                var enumeratorVariable = Expression.Variable(enumeratorType);
                var counterVariable = Expression.Variable(typeof(long));
                var breakLabel = Expression.Label();
                var body = Expression.Block(new[] { enumeratorVariable, counterVariable },
                    Expression.Assign(counterVariable, Expression.Constant(0L)),
                    Expression.Assign(enumeratorVariable, Expression.Call(enumerableParameter, getEnumeratorInfo)),
                    ExpressionEx.Using(enumeratorVariable, 
                        ExpressionEx.While(                   
                            Expression.Equal(
                                Expression.Call(enumeratorVariable, moveNext), 
                                Expression.Constant(true)),
                            Expression.Increment(counterVariable))),
                    counterVariable);

                count = Expression.Lambda<Func<TEnumerable, long>>(body, enumerableParameter).Compile();
            }
        }
    }
}
