using Ben.Collections;
using Microsoft.CodeAnalysis;
using System;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    class TypeSymbolsCache
    {
        readonly Compilation compilation;
        readonly TypeDictionary<INamedTypeSymbol?> cacheByType = new();

        public TypeSymbolsCache(Compilation compilation)
            => this.compilation = compilation;

        public INamedTypeSymbol? this[Type type]
        {
            get
            {
                if (cacheByType.TryGetValue(type, out var symbol))
                    return symbol;

                symbol = compilation.GetTypeByMetadataName(type.FullName);
                cacheByType[type] = symbol;
                return symbol;
            }
        }
    }
}
