using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace NetFabric.Hyperlinq
{
    static partial class Dynamic
    {
        internal static class GetEnumerator<TEnumerable, TEnumerator, TSource>
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            public static Func<TEnumerable, TEnumerator> Invoke { get; } = Create();

            public static Func<TEnumerable, TEnumerator> Create()
            {
                var enumerableType = typeof(TEnumerable);
                var getEnumerator = enumerableType.GetEnumeratorMethod<TSource>();
                if (getEnumerator is null)
                    throw new Exception($"'{enumerableType.FullName}': type must be implicitly convertible to 'System.Collections.IEnumerable'");
                var enumeratorType = getEnumerator.ReturnType;
                if (!typeof(TEnumerator).IsAssignableFrom(enumeratorType))
                    throw new Exception($"'{enumerableType.FullName}': type must be implicitly convertible to '{typeof(TEnumerable).FullName}'");

                var enumerable = Expression.Parameter(enumerableType, "enumerable");
                var body = Expression.Call(enumerable, getEnumerator);
                return Expression.Lambda<Func<TEnumerable, TEnumerator>>(body, enumerable).Compile();        
            }
        }

        internal static MethodInfo GetEnumeratorMethod<TSource>(this Type enumerableType)
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

        internal static Func<IEnumerable<TSource>, TResult> GetEnumerableHandler<TSource, TResult>(string name, Type enumerableType)
        {
            var elementType = typeof(TSource);
            var getEnumerator = enumerableType.GetEnumeratorMethod<TSource>();
            var enumeratorType = getEnumerator.ReturnType;

            var enumerableParameter = Expression.Parameter(typeof(IEnumerable<>).MakeGenericType(elementType), "source");

            var source = Expression.Convert(enumerableParameter, enumerableType);

            Expression body;
            if (typeof(TSource[]).IsAssignableFrom(enumerableType)) // TSource[]
            {
                body = Expression.Call(typeof(ArrayExtensions), name, new Type[] { elementType }, source);
            }
            else if (typeof(IReadOnlyList<>).MakeGenericType(elementType).IsAssignableFrom(enumerableType)) // IReadOnlyList
            {
                body = Expression.Call(typeof(ReadOnlyList), name, new Type[] { enumerableType, enumeratorType, elementType }, source);
            }      
            else if (typeof(IReadOnlyCollection<>).MakeGenericType(elementType).IsAssignableFrom(enumerableType)) // IReadOnlyCollection
            {
                body = Expression.Call(typeof(ReadOnlyCollection), name, new Type[] { enumerableType, enumeratorType, elementType }, source);
            }
            else // IEnumerable
            {
                body = Expression.Call(typeof(Enumerable), name, new Type[] { enumerableType, enumeratorType, elementType }, source);
            }

            return Expression.Lambda<Func<IEnumerable<TSource>, TResult>>(body, enumerableParameter).Compile();        
        }

        internal static Func<IEnumerable<TSource>, Func<TSource, bool>, TResult> GetEnumerablePredicateHandler<TSource, TResult>(string name, Type enumerableType)
        {
            var elementType = typeof(TSource);
            var getEnumerator = enumerableType.GetEnumeratorMethod<TSource>();
            var enumeratorType = getEnumerator.ReturnType;

            var enumerableParameter = Expression.Parameter(typeof(IEnumerable<>).MakeGenericType(elementType), "source");
            var predicateParameter = Expression.Parameter(typeof(Func<,>).MakeGenericType(elementType, typeof(bool)), "predicate");

            var source = Expression.Convert(enumerableParameter, enumerableType);
            
            Expression body;
            if (typeof(TSource[]).IsAssignableFrom(enumerableType)) // TSource[]
            {
                body = Expression.Call(typeof(ArrayExtensions), name, new Type[] { elementType }, source, predicateParameter);
            }
            else if (typeof(IReadOnlyList<>).MakeGenericType(elementType).IsAssignableFrom(enumerableType)) // IReadOnlyList
            {
                body = Expression.Call(typeof(ReadOnlyList), name, new Type[] { enumerableType, enumeratorType, elementType }, source, predicateParameter);
            }      
            else if (typeof(IReadOnlyCollection<>).MakeGenericType(elementType).IsAssignableFrom(enumerableType)) // IReadOnlyCollection
            {
                body = Expression.Call(typeof(ReadOnlyCollection), name, new Type[] { enumerableType, enumeratorType, elementType }, source, predicateParameter);
            }
            else // IEnumerable
            {
                body = Expression.Call(typeof(Enumerable), name, new Type[] { enumerableType, enumeratorType, elementType }, source, predicateParameter);
            }

            return Expression.Lambda<Func<IEnumerable<TSource>, Func<TSource, bool>, TResult>>(body, enumerableParameter, predicateParameter).Compile();        
        }
    }
}