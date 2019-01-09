using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));
                
            if(source is ICollection<TSource> collection)
                return collection.Count;

            if(source is IReadOnlyCollection<TSource> readOnlyCollection)
                return readOnlyCollection.Count;

            var counter = 0;
            using(var enumerator = source.GetEnumerator())
            {
                while(enumerator.MoveNext())
                    counter++;
            }
            return counter;
        }  

        public static int Count<TEnumerable, TSource>(this TEnumerable source) where TEnumerable : IEnumerable<TSource>
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));
                
            if(source is ICollection<TSource> collection)
                return collection.Count;

            if(source is IReadOnlyCollection<TSource> readOnlyCollection)
                return readOnlyCollection.Count;

            if(typeof(TEnumerable) != typeof(IEnumerable<>))
                return CountCache<TEnumerable, TSource>.count(source);

            var counter = 0;
            using(var enumerator = source.GetEnumerator())
            {
                while(enumerator.MoveNext())
                    counter++;
            }
            return counter;
        }

        static class CountCache<TEnumerable, TSource> where TEnumerable : IEnumerable<TSource>
        {
            public static readonly Func<TEnumerable, int> count = GenerateCount();

            static Func<TEnumerable, int> GenerateCount()
            {
                var getEnumeratorMethod = typeof(TEnumerable).GetMethod("GetEnumerator");
                var enumeratorType = getEnumeratorMethod.ReturnType;

                var enumerableParameter = Expression.Parameter(typeof(TEnumerable));
                var enumeratorVariable = Expression.Variable(enumeratorType);
                var counterVariable = Expression.Variable(typeof(int));
                var body = Expression.Block(new[] { enumeratorVariable, counterVariable },
                    Expression.Assign(counterVariable, Expression.Constant(0)),
                    Expression.Assign(enumeratorVariable, Expression.Call(enumerableParameter, "GetEnumerator", null)),
                    ExpressionEx.Using(enumeratorVariable, 
                        ExpressionEx.While(        
                            Expression.Call(enumeratorVariable, "MoveNext", null), 
                            Expression.Assign(counterVariable, Expression.Increment(counterVariable)))),
                    counterVariable);

                return Expression.Lambda<Func<TEnumerable, int>>(body, enumerableParameter).Compile();
            }
        }
    }
}
