using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace NetFabric.Hyperlinq
{
    static partial class Dynamic
    {
        public static class GetEnumerator<TEnumerable, TEnumerator, TSource>
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            public static Func<TEnumerable, TEnumerator> Invoke { get; } = Create();

            public static Func<TEnumerable, TEnumerator> Create()
            {
                var enumerableType = typeof(TEnumerable);
                var getEnumerator = enumerableType.GetEnumeratorMethod<TSource>();
                var enumeratorType = getEnumerator.ReturnType;
                if (!typeof(TEnumerator).IsAssignableFrom(enumeratorType))
                    throw new Exception($"'{enumerableType.FullName}': type must be implicitly convertible to '{typeof(TEnumerable).FullName}'");

                var enumerable = Expression.Parameter(enumerableType, "enumerable");
                var body = Expression.Call(enumerable, getEnumerator);
                return Expression.Lambda<Func<TEnumerable, TEnumerator>>(body, enumerable).Compile();        
            }
        }

        public static MethodInfo GetEnumeratorMethod<TSource>(this Type enumerableType)
        {
            const string MethodName = "GetEnumerator";

            var getEnumerator = enumerableType.GetMethod(MethodName);
            if (!(getEnumerator is null))
                return getEnumerator;

            var enumerableSourceType = typeof(IEnumerable<>).MakeGenericType(typeof(TSource));
            if (enumerableSourceType.IsAssignableFrom(enumerableType))
                return enumerableSourceType.GetMethod(MethodName);

            if (typeof(IEnumerable).IsAssignableFrom(enumerableType))
                return typeof(IEnumerable).GetMethod(MethodName);

            throw new Exception($"'{enumerableType.FullName}': type must be implicitly convertible to 'System.Collections.IEnumerable'");
        } 

        public static Func<IEnumerable<TSource>, TResult> GetEnumerableHandler<TSource, TResult>(string name, Type enumerableType)
        {
            var enumerableParameter = Expression.Parameter(typeof(IEnumerable<>).MakeGenericType(typeof(TSource)), "source");

            var source = Expression.Convert(enumerableParameter, enumerableType);
            var method = GetMethod<TSource>(name, enumerableType);

            var body = Expression.Call(method, source);
            return Expression.Lambda<Func<IEnumerable<TSource>, TResult>>(body, enumerableParameter).Compile();        
        }

        public static Func<IEnumerable<TSource>, TArg, TResult> GetEnumerableHandler<TSource, TArg, TResult>(string name, Type enumerableType)
        {
            var enumerableParameter = Expression.Parameter(typeof(IEnumerable<>).MakeGenericType(typeof(TSource)), "source");
            var argParameter = Expression.Parameter(typeof(TArg), "arg");

            var source = Expression.Convert(enumerableParameter, enumerableType);
            var method = GetMethod<TSource>(name, enumerableType, typeof(TArg));
            
            var body = Expression.Call(method, source, argParameter);
            return Expression.Lambda<Func<IEnumerable<TSource>, TArg, TResult>>(body, enumerableParameter, argParameter).Compile();        
        }

        public static Func<IEnumerable<TSource>, TArg0, TArg1, TResult> GetEnumerableHandler<TSource, TArg0, TArg1, TResult>(string name, Type enumerableType)
        {
            var enumerableParameter = Expression.Parameter(typeof(IEnumerable<>).MakeGenericType(typeof(TSource)), "source");
            var arg0Parameter = Expression.Parameter(typeof(TArg0), "arg0");
            var arg1Parameter = Expression.Parameter(typeof(TArg1), "arg1");

            var source = Expression.Convert(enumerableParameter, enumerableType);
            var method = GetMethod<TSource>(name, enumerableType, typeof(TArg0), typeof(TArg1));

            var body = Expression.Call(method, source, arg0Parameter, arg1Parameter);
            return Expression.Lambda<Func<IEnumerable<TSource>, TArg0, TArg1, TResult>>(body, enumerableParameter, arg0Parameter, arg1Parameter).Compile();        
        }

        static MethodInfo GetMethod<TSource>(string name, Type enumerableType, params Type[] types)
        {
            var elementType = typeof(TSource);

            // TSource[]
            if (typeof(TSource[]).IsAssignableFrom(enumerableType)) 
            {
                var method = GetMethod(typeof(ArrayExtensions), name, typeof(TSource[]), types);
                
                if (!(method is null))
                    return method.MakeGenericMethod(new[] { elementType });
            }

            var getEnumerator = enumerableType.GetEnumeratorMethod<TSource>();
            var enumeratorType = getEnumerator.ReturnType;

            // IReadOnlyList<TSource>
            var type = typeof(IReadOnlyList<>).MakeGenericType(elementType);
            if (type.IsAssignableFrom(enumerableType)) 
            {
                var method = GetMethod(typeof(ReadOnlyList), name, type, types);
                
                if (!(method is null))
                    return method.MakeGenericMethod(new[] { enumerableType, enumeratorType, elementType });
            }      
            
            // IReadOnlyCollection<TSource>
            type = typeof(IReadOnlyCollection<>).MakeGenericType(elementType);
            if (type.IsAssignableFrom(enumerableType)) 
            {
                var method = GetMethod(typeof(ReadOnlyCollection), name, type, types);
                
                if (!(method is null))
                    return method.MakeGenericMethod(new[] { enumerableType, enumeratorType, elementType });
            }

            // IEnumerable<TSource>
            type = typeof(IEnumerable<>).MakeGenericType(elementType);
            if (enumerableType.IsAssignableFrom(enumerableType)) 
            {
                var method = GetMethod(typeof(Enumerable), name, type, types);
                
                if (!(method is null))
                    return method.MakeGenericMethod(new[] { enumerableType, enumeratorType, elementType });
            }

            throw new Exception($"No method '{name}' handler was found for type '{enumerableType}'");
        }

        static MethodInfo GetMethod(Type type, string name, Type collectionType, params Type[] parameters)
        {
            return type.GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Where(method => 
                    method.Name == name && 
                    method.GetParameters().Length == 1 + parameters.Length)
                .FirstOrDefault();
        }
    }
}