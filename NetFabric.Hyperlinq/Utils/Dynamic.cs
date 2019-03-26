using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace NetFabric.Hyperlinq
{
    static class Dynamic
    {
        public static class GetEnumerator<TEnumerable, TEnumerator, TSource>
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            public static Func<TEnumerable, TEnumerator> Invoke { get; } = Create();

            static Func<TEnumerable, TEnumerator> Create()
            {
                var enumerableType = typeof(TEnumerable);
                var getEnumerator = enumerableType.GetEnumeratorMethod<TSource>();
                if (getEnumerator is null || !typeof(TEnumerator).IsAssignableFrom(getEnumerator.ReturnType))
                    throw new Exception($"'{getEnumerator.ReturnType.FullName}': type must be implicitly convertible to '{typeof(TEnumerable).FullName}'");

                var enumerable = Expression.Parameter(enumerableType, "enumerable");
                var body = Expression.Call(enumerable, getEnumerator);
                return Expression.Lambda<Func<TEnumerable, TEnumerator>>(body, enumerable).Compile();        
            }
        }

        static MethodInfo GetEnumeratorMethod<TSource>(this Type enumerableType)
        {
            const string MethodName = "GetEnumerator";

            var method = enumerableType.GetMethod(MethodName, BindingFlags.Public | BindingFlags.Instance);
            if (!(method is null))
                return method;

            var type = typeof(IEnumerable<>).MakeGenericType(typeof(TSource));
            if (type.IsAssignableFrom(enumerableType))
                return type.GetMethod(MethodName);

            type = typeof(IEnumerable);
            if (type.IsAssignableFrom(enumerableType))
                return type.GetMethod(MethodName);

            return null;
        } 

        public static Func<TEnumerable, TResult> GetEnumerableHandler<TEnumerable, TSource, TResult>(string name, Type enumerableType)
            where TEnumerable : IEnumerable<TSource>
        {
            var enumerableParameter = Expression.Parameter(typeof(TEnumerable), "source");

            var source = Expression.Convert(enumerableParameter, enumerableType);
            var method = GetMethod<TSource>(name, enumerableType);

            var body = Expression.Call(method, source);
            return Expression.Lambda<Func<TEnumerable, TResult>>(body, enumerableParameter).Compile();        
        }

        public static Func<TEnumerable, TArg, TResult> GetEnumerableHandler<TEnumerable, TSource, TArg, TResult>(string name, Type enumerableType)
        {
            var enumerableParameter = Expression.Parameter(typeof(TEnumerable), "source");
            var argParameter = Expression.Parameter(typeof(TArg), "arg");

            var source = Expression.Convert(enumerableParameter, enumerableType);
            var method = GetMethod<TSource>(name, enumerableType, typeof(TArg));
            
            var body = Expression.Call(method, source, argParameter);
            return Expression.Lambda<Func<TEnumerable, TArg, TResult>>(body, enumerableParameter, argParameter).Compile();        
        }

        public static Func<TEnumerable, TArg0, TArg1, TResult> GetEnumerableHandler<TEnumerable, TSource, TArg0, TArg1, TResult>(string name, Type enumerableType)
        {
            var enumerableParameter = Expression.Parameter(typeof(TEnumerable), "source");
            var arg0Parameter = Expression.Parameter(typeof(TArg0), "arg0");
            var arg1Parameter = Expression.Parameter(typeof(TArg1), "arg1");

            var source = Expression.Convert(enumerableParameter, enumerableType);
            var method = GetMethod<TSource>(name, enumerableType, typeof(TArg0), typeof(TArg1));

            var body = Expression.Call(method, source, arg0Parameter, arg1Parameter);
            return Expression.Lambda<Func<TEnumerable, TArg0, TArg1, TResult>>(body, enumerableParameter, arg0Parameter, arg1Parameter).Compile();        
        }

        static MethodInfo GetMethod<TSource>(string name, Type enumerableType, params Type[] args)
        {
            var elementType = typeof(TSource);

            // TSource[]
            var type = typeof(TSource[]);
            if (type.IsAssignableFrom(enumerableType)) 
            {
                var method = GetMethod(typeof(Array), name, type, args);
                
                if (!(method is null))
                    return method.MakeGenericMethod(new[] { elementType });
            }
             
            // IReadOnlyList<TSource>
            type = typeof(IReadOnlyList<>).MakeGenericType(elementType);
            if (type.IsAssignableFrom(enumerableType)) 
            {
                var method = GetMethod(typeof(ReadOnlyList), name, type, args);
                
                if (!(method is null))
                    return method.MakeGenericMethod(new[] { enumerableType, elementType });
            }      

            var getEnumerator = enumerableType.GetEnumeratorMethod<TSource>();
            if (getEnumerator is null)
                throw new Exception($"'{enumerableType.FullName}': type must be implicitly convertible to 'System.Collections.IEnumerable'");
            var enumeratorType = getEnumerator.ReturnType;
            
            // IReadOnlyCollection<TSource>
            type = typeof(IReadOnlyCollection<>).MakeGenericType(elementType);
            if (type.IsAssignableFrom(enumerableType)) 
            {
                var method = GetMethod(typeof(ReadOnlyCollection), name, type, args);
                
                if (!(method is null))
                    return method.MakeGenericMethod(new[] { enumerableType, enumeratorType, elementType });
            }

            // IEnumerable<TSource>
            type = typeof(IEnumerable<>).MakeGenericType(elementType);
            if (enumerableType.IsAssignableFrom(enumerableType)) 
            {
                var method = GetMethod(typeof(Enumerable), name, type, args);
                
                if (!(method is null))
                    return method.MakeGenericMethod(new[] { enumerableType, enumeratorType, elementType });
            }

            throw new Exception($"No method '{name}' handler was found for type '{enumerableType}'");
        }

        static MethodInfo GetMethod(Type type, string name, Type collectionType, Type[] args)
        {
            return type.GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Where(method => 
                    method.Name == name && 
                    method.GetParameters().Length == 1 + args.Length)
                .FirstOrDefault();
        }
    }
}