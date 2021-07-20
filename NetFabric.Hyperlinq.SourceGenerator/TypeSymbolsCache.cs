using Ben.Collections;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    class TypeSymbolsCache
    {
        readonly Compilation compilation;
        readonly TypeDictionary<INamedTypeSymbol?> cacheByType = new();
        readonly Dictionary<string, INamedTypeSymbol?> cacheByName = new();

        public TypeSymbolsCache(Compilation compilation)
            => this.compilation = compilation;

        public INamedTypeSymbol? this[Type type]
        {
            get
            {
                if (cacheByType.TryGetValue(type, out var symbol))
                    return symbol;

                if (cacheByName.TryGetValue(type.FullName, out symbol))
                {
                    cacheByType[type] = symbol;
                }
                else
                {
                    symbol = compilation.GetTypeByMetadataName(type.FullName);
                    cacheByType[type] = symbol;
                }
                return symbol;
            }
        }

        public INamedTypeSymbol? this[string fullyQualifiedMetadataName]
        {
            get
            {
                if (cacheByName.TryGetValue(fullyQualifiedMetadataName, out var symbol))
                    return symbol;

                symbol = compilation.GetTypeByMetadataName(fullyQualifiedMetadataName);
                cacheByName[fullyQualifiedMetadataName] = symbol;
                return symbol;
            }
        }
    }
}
