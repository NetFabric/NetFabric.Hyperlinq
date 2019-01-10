using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            if(source is null)
                throw new ArgumentNullException(nameof(source));
                    
            return CountCache<IEnumerable<TSource>, TSource>.count(source);
        }

        public static int Count<TSource>(this IReadOnlyCollection<TSource> source)
        {
            if(source is null)
                throw new ArgumentNullException(nameof(source));
                    
            return source.Count;
        }

        public static int Count<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IEnumerable<TSource>
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));
                    
            return CountCache<TEnumerable, TSource>.count(source);
        } 

        static class CountCache<TEnumerable, TSource> 
            where TEnumerable : IEnumerable<TSource>
        {
            public static readonly Func<TEnumerable, int> count = CreateCount();

            static Func<TEnumerable, int> CreateCount()
            {
                if(typeof(ICollection).IsAssignableFrom(typeof(TEnumerable)))
                    return CountCollection;

                if(typeof(IReadOnlyCollection<>).MakeGenericType(typeof(TSource)).IsAssignableFrom(typeof(TEnumerable)))
                    return CountReadOnlyCollection;

                if(typeof(TEnumerable) == typeof(IEnumerable<TSource>))
                    return CountEnumerable;

                return CountCustom();
            }

            static int CountEnumerable(TEnumerable source)
            {
                if(source is ICollection collection)
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

            static int CountCollection(TEnumerable source) =>
                (source as ICollection).Count;

            static int CountReadOnlyCollection(TEnumerable source) =>
                (source as IReadOnlyCollection<TSource>).Count;
                
            static Func<TEnumerable, int> CountCustom()
            {
                var getEnumeratorMethod = typeof(TEnumerable).GetMethod("GetEnumerator");
                var enumeratorType = getEnumeratorMethod.ReturnType;

                var enumerableParameter = Expression.Parameter(typeof(TEnumerable), "source");
                var enumeratorVariable = Expression.Variable(enumeratorType, "enumerator");
                var counterVariable = Expression.Variable(typeof(int), "counter");
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
