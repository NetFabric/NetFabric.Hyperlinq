using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    static class NamespaceSymbolExtensions
    {
        public static IEnumerable<INamedTypeSymbol> GetAllTypes(this INamespaceSymbol namespaceSymbol)
            => namespaceSymbol.GetTypeMembers()
            .Concat(namespaceSymbol.GetNamespaceMembers().SelectMany(member => GetAllTypes(member)));
    }
}
