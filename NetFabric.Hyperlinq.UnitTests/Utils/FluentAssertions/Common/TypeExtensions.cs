using System;
using System.Reflection;

namespace FluentAssertions.Common
{
    static class TypeExtensions
    {
        public static bool HasPublicGetEnumerator(this Type type, out MethodInfo getEnumerator)
        {
            getEnumerator = type.GetPublicMethodGetEnumerator();
            return getEnumerator is object && getEnumerator.ReturnType.IsEnumerator();
        }
    
        public static bool IsEnumerable(this Type type)
        {
            var getEnumerator = type.GetMethodGetEnumerator();
            return getEnumerator is object && getEnumerator.ReturnType.IsEnumerator();
        }

        public static bool IsEnumerator(this Type type)
            => type.GetPropertyCurrent() is object && type.GetMethodMoveNext() is object;

        public static PropertyInfo GetPropertyCurrent(this Type type)
        {
            var method = type.GetPublicPropertyCurrent();
            if (method is object)
                return method;

            foreach (var @interface in type.GetInterfaces())
            {
                method = @interface.GetPublicPropertyCurrent();
                if (method is object)
                    return method;
            }

            return null;
        }

        public static MethodInfo GetMethodGetEnumerator(this Type type)
        {
            var method = type.GetPublicMethodGetEnumerator();
            if (method is object)
                return method;

            foreach (var @interface in type.GetInterfaces())
            {
                method = @interface.GetPublicMethodGetEnumerator();
                if (method is object)
                    return method;
            }

            return null;
        }

        public static MethodInfo GetMethodMoveNext(this Type type)
        {
            var method = type.GetPublicMethodMoveNext();
            if (method is object)
                return method;

            foreach (var @interface in type.GetInterfaces())
            {
                method = @interface.GetPublicMethodMoveNext();
                if (method is object)
                    return method;
            }

            return null;
        }

        public static MethodInfo GetMethodReset(this Type type)
        {
            var method = type.GetPublicMethodReset();
            if (method is object)
                return method;

            foreach (var @interface in type.GetInterfaces())
            {
                method = @interface.GetPublicMethodReset();
                if (method is object)
                    return method;
            }

            return null;
        }

        public static MethodInfo GetMethodDispose(this Type type)
        {
            var method = type.GetPublicMethodDispose();
            if (method is object)
                return method;

            foreach (var @interface in type.GetInterfaces())
            {
                method = @interface.GetPublicMethodDispose();
                if (method is object)
                    return method;
            }

            return null;
        }

        static PropertyInfo GetPublicPropertyCurrent(this Type type)
            => type.GetProperty("Current", BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance);

        static MethodInfo GetPublicMethodGetEnumerator(this Type type)
            => type.GetMethod("GetEnumerator", BindingFlags.Public | BindingFlags.Instance);

        static MethodInfo GetPublicMethodMoveNext(this Type type)
            => type.GetMethod("MoveNext", BindingFlags.Public | BindingFlags.Instance);

        static MethodInfo GetPublicMethodReset(this Type type)
            => type.GetMethod("Reset", BindingFlags.Public | BindingFlags.Instance);

        static MethodInfo GetPublicMethodDispose(this Type type)
            => type.GetMethod("Dispose", BindingFlags.Public | BindingFlags.Instance);
    }
}
