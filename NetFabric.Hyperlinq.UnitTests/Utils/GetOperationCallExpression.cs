using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq.UnitTests
{
    static class ExpressionBuilder
    {
        public static Expression OperationCall<TEnumerable>(string name, Expression source)
            => OperationCall<TEnumerable>(name, source, out _, null, null, null);

        public static Expression OperationCall<TEnumerable>(string name, Expression source, Type[] genericTypeArguments)
            => OperationCall<TEnumerable>(name, source, out _, genericTypeArguments, null, null);

        public static Expression OperationCall<TEnumerable>(string name, Expression source, out MethodInfo methodInfo)
            => OperationCall<TEnumerable>(name, source, out methodInfo, null, null, null);

        public static Expression OperationCall<TEnumerable>(string name, Expression source, Type[] genericTypeArguments, out MethodInfo methodInfo)
            => OperationCall<TEnumerable>(name, source, out methodInfo, genericTypeArguments, null, null);

        public static Expression OperationCall<TEnumerable>(string name, Expression source, Type[] parameterTypes, Expression[] parameterExpressions)
            => OperationCall<TEnumerable>(name, source, out _, null, parameterTypes, parameterExpressions);

        public static Expression OperationCall<TEnumerable>(string name, Expression source, Type[] genericTypeArguments, Type[] parameterTypes, Expression[] parameterExpressions)
            => OperationCall<TEnumerable>(name, source, out _, genericTypeArguments, parameterTypes, parameterExpressions);

        public static Expression OperationCall<TEnumerable>(string name, Expression source, Type[] parameterTypes, Expression[] parameterExpressions, out MethodInfo methodInfo)
            => OperationCall<TEnumerable>(name, source, out methodInfo, null, parameterTypes, parameterExpressions);

        public static Expression OperationCall<TEnumerable>(string name, Expression source, Type[] genericTypeArguments, Type[] parameterTypes, Expression[] parameterExpressions, out MethodInfo methodInfo)
            => OperationCall<TEnumerable>(name, source, out methodInfo, genericTypeArguments, parameterTypes, parameterExpressions);

        static Expression OperationCall<TEnumerable>(string name, Expression source, out MethodInfo methodInfo, Type[]? genericTypeArguments, Type[]? parameterTypes, Expression[]? parameterExpressions)
        {
            // check for an instance method
            methodInfo = GetInstanceMethod<TEnumerable>(name, parameterTypes)!;
            if (methodInfo is not null)
            {
                if (methodInfo.IsGenericMethod)
                    methodInfo = methodInfo.MakeGenericMethod(genericTypeArguments 
                        ?? throw new ArgumentNullException(nameof(genericTypeArguments), $"{methodInfo.Name} is generic and requires type arguments!"));

                return Expression.Call(source, methodInfo, parameterExpressions);
            }

            // check for an extension method
            methodInfo = GetExtensionMethod<TEnumerable>(name, parameterTypes)
                ?? throw new Exception($"'Operation '{ name }' not found for { typeof(TEnumerable).FullName }.");

            if (methodInfo.IsGenericMethod)
                methodInfo = methodInfo.MakeGenericMethod(source.Type.GenericTypeArguments);

            IEnumerable<Expression> callArguments = new[] { source };
            if (parameterExpressions is { Length: not 0 })
                callArguments = callArguments.Concat(parameterExpressions);
            return Expression.Call(methodInfo, callArguments);
        }

        static MethodInfo? GetInstanceMethod<T>(string name, Type[]? parameterTypes = null) 
            => typeof(T).GetMethods()
                .FirstOrDefault(info =>
                    !info.IsStatic
                    && info.IsPublic
                    && info.Name == name
                    && info.GetCustomAttribute<ExtensionAttribute>() is null
                    && info.GetParameters()
                        .Select(info => info.ParameterType)
                        .SequenceEqual(parameterTypes ?? Enumerable.Empty<Type>(), new TypeNameComparer()));

        static MethodInfo? GetExtensionMethod<T>(string name, IReadOnlyCollection<Type>? parameterTypes = null)
        {
            var declaringType = typeof(T).DeclaringType!;
            var parameterCount = parameterTypes?.Count + 1 ?? 1;
            var genericTypeDefinition = typeof(T).GetGenericTypeDefinition();
            return declaringType.GetMethods()
                .FirstOrDefault(info =>
                    info.IsStatic
                    && info.IsPublic
                    && info.Name == name
                    && info.GetCustomAttribute<ExtensionAttribute>() is not null
                    && info.GetParameters().Length == parameterCount
                    && RemoveRef(info.GetParameters()[0].ParameterType.Name) == genericTypeDefinition.Name);
        }

        static string RemoveRef(string name)
            => name is { Length: 0 } || name[name.Length - 1] != '&'
                ? name
                : name.Substring(0, name.Length - 1);

        class TypeNameComparer
            : IEqualityComparer<Type>
        {
            public bool Equals(Type? x, Type? y)
                => x?.Name == y?.Name;

            public int GetHashCode(Type obj)
                => obj?.Name.GetHashCode() ?? 0;
        }

        class TypeDefinitionNameComparer
            : IEqualityComparer<Type>
        {
            public bool Equals(Type? x, Type? y)
                => GetName(x) == GetName(y);

            public int GetHashCode(Type obj)
                => GetName(obj)?.GetHashCode() ?? 0;

            static string? GetName(Type? type)
                => type switch
                {
                    null => null,
                    _ => type.IsGenericType
                        ? type.GetGenericTypeDefinition().Name
                        : type.Name
                };
        }
    }
}
