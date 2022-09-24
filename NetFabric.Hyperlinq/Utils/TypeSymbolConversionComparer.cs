using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    public class TypeSymbolConversionComparer 
        : IEqualityComparer<ITypeSymbol>
    {
        readonly Compilation compilation;

        public TypeSymbolConversionComparer(Compilation compilation)
            => this.compilation = compilation;

        public bool Equals(ITypeSymbol x, ITypeSymbol y)
            => (x is INamedTypeSymbol { IsGenericType: true }  
                   && y is INamedTypeSymbol { IsGenericType: true }
                   && compilation.ClassifyConversion(x.OriginalDefinition, y.OriginalDefinition).Exists)
               || compilation.ClassifyConversion(x, y).Exists;

        public int GetHashCode(ITypeSymbol obj) 
            => SymbolEqualityComparer.Default.GetHashCode(obj);
    }
}