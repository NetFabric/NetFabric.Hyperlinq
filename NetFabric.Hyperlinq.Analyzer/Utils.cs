using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace NetFabric.Hyperlinq.Analyzer
{
    static class Utils
    {
        public static bool IsEnumerable(this ITypeSymbol typeSymbol)
        {
            var getEnumerator = typeSymbol.GetFirstPublicMethod("GetEnumerator");
            if (getEnumerator is null)
                return false;

            return getEnumerator.ReturnType.IsEnumerator();
        }

        public static bool IsEnumerableValueType(this ITypeSymbol typeSymbol)
        {
            var getEnumerator = typeSymbol.GetFirstPublicMethod("GetEnumerator");
            if (getEnumerator is null)
                return false;

            var returnType = getEnumerator.ReturnType;
            return returnType.IsValueType && returnType.IsEnumerator();
        }

        public static bool IsEnumerator(this ITypeSymbol typeSymbol) =>
            typeSymbol.HasPublicMethod("MoveNext") &&
            typeSymbol.HasPublicProperty("Current");

        static bool HasPublicMethod(this ITypeSymbol typeSymbol, string name)
        {
            while (!(typeSymbol is null))
            {
                foreach(var member in typeSymbol.GetMembers(name).OfType<IMethodSymbol>())
                {
                    if (member.DeclaredAccessibility == Accessibility.Public && member.Parameters.IsEmpty)
                        return true;
                }

                typeSymbol = typeSymbol.BaseType;
            }


            return false;
        }

        static bool HasPublicProperty(this ITypeSymbol typeSymbol, string name)
        {
            while (!(typeSymbol is null))
            {
                foreach (var member in typeSymbol.GetMembers(name).OfType<IPropertySymbol>())
                {
                    if (member.DeclaredAccessibility == Accessibility.Public)
                        return true;
                }

                typeSymbol = typeSymbol.BaseType;
            }

            return false;
        }

        static IMethodSymbol GetFirstPublicMethod(this ITypeSymbol typeSymbol, string name)
        {
            while (!(typeSymbol is null))
            {
                foreach (var member in typeSymbol.GetMembers(name).OfType<IMethodSymbol>())
                {
                    if (member.DeclaredAccessibility == Accessibility.Public)
                        return member;
                }

                typeSymbol = typeSymbol.BaseType;
            }

            return null;
        }

        public static bool BoxesEnumerator(this ITypeSymbol typeSymbol)
        {
            if(typeSymbol.TypeKind == TypeKind.Interface)
            {
                foreach (var i in typeSymbol.GetAllInterfaces())
                {
                    var getEnumerator = i.GetMembers("GetEnumerator").OfType<IMethodSymbol>().FirstOrDefault();
                    if (!(getEnumerator is null) && getEnumerator.Parameters.IsEmpty && getEnumerator.ReturnType.IsEnumeratorInterface())
                        return true;
                }

                return false;
            }
            else
            {
                var getEnumerator = typeSymbol.GetFirstPublicMethod("GetEnumerator");
                if (getEnumerator is null)
                    return false;

                var returnType = getEnumerator.ReturnType;
                return returnType.IsEnumeratorInterface();
            }
        }

        public static bool IsEnumerableInterface(this ITypeSymbol typeSymbol)
        {
            if (typeSymbol.TypeKind != TypeKind.Interface)
                return false;

            foreach (var i in typeSymbol.GetAllInterfaces())
            {
                var getEnumerator = typeSymbol.GetFirstPublicMethod("GetEnumerator");
                if (!(getEnumerator is null) && getEnumerator.ReturnType.IsEnumeratorInterface())
                    return true;
            }
            return false;

        }

        public static bool IsEnumeratorInterface(this ITypeSymbol typeSymbol)
        {
            if (typeSymbol.TypeKind != TypeKind.Interface)
                return false;

            var moveNext = false;
            var current = false;
            foreach(var i in typeSymbol.GetAllInterfaces())
            {
                if (!moveNext)
                    moveNext = i.GetMembers("MoveNext").OfType<IMethodSymbol>().Any();

                if (!current)
                    current = i.GetMembers("Current").OfType<IPropertySymbol>().Any();

                if (moveNext && current)
                    return true;
            }
            return false;
        }

        public static bool ImplementsInterface(this ITypeSymbol typeSymbol, SpecialType interfaceType)
            => typeSymbol.GetAllInterfaces().Select(value => value.OriginalDefinition.SpecialType).Contains(interfaceType);

        static IEnumerable<ITypeSymbol> GetAllInterfaces(this ITypeSymbol typeSymbol)
        {
            var set = new HashSet<ITypeSymbol>
            {
                typeSymbol
            };
            GetInterfacesRecursively(typeSymbol);
            return set;

            void GetInterfacesRecursively(ITypeSymbol current)
            {
                foreach (var i in current.Interfaces)
                {
                    if (set.Add(i))
                        i.GetAllInterfaces();
                }
            }
        }
    }
}
