using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        static readonly LockingConcurrentDictionary<Type, Func<IEnumerable, int>> handlers = 
            new LockingConcurrentDictionary<Type, Func<IEnumerable, int>>(type => CreateCount(type));

        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            if(source is null)
                ThrowSourceNull();
                    
            if(source is IReadOnlyCollection<TSource> readOnlyCollection)
                return readOnlyCollection.Count;

            if(source is ICollection collection)
                return collection.Count;

            return handlers.GetOrAdd(source.GetType())(source);

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }

        static Func<IEnumerable, int> CreateCount(Type enumerableType)
        {
            var enumeratorType = enumerableType
                .GetMethod("GetEnumerator", BindingFlags.Instance | BindingFlags.Public)
                .ReturnType;

            var enumerableParameter = Expression.Parameter(enumerableType, "source");
            var enumeratorVariable = Expression.Variable(enumeratorType, "enumerator");
            var counterVariable = Expression.Variable(typeof(int), "counter");
            var body = Expression.Block(new[] { enumeratorVariable, counterVariable },
                Expression.Assign(counterVariable, Expression.Constant(0)),
                Expression.Assign(enumeratorVariable, Expression.Call(enumerableParameter, "GetEnumerator", null)),
                ExpressionEx.Using(enumeratorVariable, 
                    ExpressionEx.While(        
                        Expression.Call(enumeratorVariable, typeof(IEnumerator).GetMethod("MoveNext")), 
                        Expression.Assign(counterVariable, Expression.Increment(counterVariable)))),
                counterVariable);

            return Expression.Lambda<Func<IEnumerable, int>>(body, enumerableParameter).Compile();
        }

        public static int Count<TSource>(this IReadOnlyCollection<TSource> source)
        {
            if(source is null)
                ThrowSourceNull();
                    
            return source.Count;

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        }

        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if(source == null)
                ThrowSourceNull();
                    
            return CountCache<TEnumerable, TEnumerator, TSource>.count(source);

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
        } 

        static class CountCache<TEnumerable, TEnumerator, TSource> 
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            public static readonly Func<TEnumerable, int> count = CreateCount();

            static Func<TEnumerable, int> CreateCount()
            {
                if(typeof(ICollection).IsAssignableFrom(typeof(TEnumerable)))
                    return CountCollection;

                if(typeof(IReadOnlyCollection<>).MakeGenericType(typeof(TSource)).IsAssignableFrom(typeof(TEnumerable)))
                    return CountReadOnlyCollection;

                return CountCustom();
            }

            static int CountCollection(TEnumerable source) =>
                (source as ICollection).Count;

            static int CountReadOnlyCollection(TEnumerable source) =>
                (source as IReadOnlyCollection<TSource>).Count;
                
            static Func<TEnumerable, int> CountCustom()
            {
                var enumerableParameter = Expression.Parameter(typeof(TEnumerable), "source");
                var enumeratorVariable = Expression.Variable(typeof(TEnumerator), "enumerator");
                var counterVariable = Expression.Variable(typeof(int), "counter");
                var body = Expression.Block(new[] { enumeratorVariable, counterVariable },
                    Expression.Assign(counterVariable, Expression.Constant(0)),
                    Expression.Assign(enumeratorVariable, Expression.Call(enumerableParameter, "GetEnumerator", null)),
                    ExpressionEx.Using(enumeratorVariable, 
                        ExpressionEx.While(        
                            Expression.Call(enumeratorVariable, typeof(IEnumerator).GetMethod("MoveNext")), 
                            Expression.Assign(counterVariable, Expression.Increment(counterVariable)))),
                    counterVariable);

                return Expression.Lambda<Func<TEnumerable, int>>(body, enumerableParameter).Compile();
            }
        }
    }
}
