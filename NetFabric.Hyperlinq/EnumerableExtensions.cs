using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace NetFabric.Hyperlinq
{
    static partial class Enumerable
    {
        internal static class GetEnumerator<TEnumerable, TEnumerator, TSource>
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            public static Func<TEnumerable, TEnumerator> Invoke { get; } = Create();

            public static Func<TEnumerable, TEnumerator> Create()
            {
                var enumerableType = typeof(TEnumerable);
                var getEnumerator = GetEnumeratorMethod(enumerableType);
                if (getEnumerator is null)
                    throw new Exception($"'{enumerableType.FullName}': type used in a foreach statement must be implicitly convertible to 'System.Collections.IEnumerable'");
                var enumeratorType = getEnumerator.ReturnType;
                if (!typeof(TEnumerator).IsAssignableFrom(enumeratorType))
                    throw new Exception($"'{enumerableType.FullName}': type is not convertible implicitly to '{typeof(TEnumerable).FullName}'");

                var enumerable = Expression.Parameter(enumerableType, "enumerable");

                var body = Expression.Call(enumerable, getEnumerator);

                return Expression.Lambda<Func<TEnumerable, TEnumerator>>(body, enumerable).Compile();        
            }

            static MethodInfo GetEnumeratorMethod(Type enumerableType)
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
        }
    }
}