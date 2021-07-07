using Microsoft.CodeAnalysis;
using NetFabric.CodeAnalysis;
using System;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    sealed class CompilationContext
    {
        public Compilation Compilation { get; }
        public string GeneratedCodeAttribute { get; }
        public INamedTypeSymbol GeneratorIgnoreAttribute { get; }
        public INamedTypeSymbol GeneratorBindingsAttribute { get; }
        public INamedTypeSymbol GeneratorMappingAttribute { get; }

        public CompilationContext(Compilation compilation)
        {
            Compilation = compilation;

            var generatorAssembly = GetType().Assembly;
            var generatorAssemblyName = generatorAssembly.GetName().Name;
            var generatorAssemblyVersion = AttributeExtensions.GetCustomAttribute<System.Reflection.AssemblyInformationalVersionAttribute>(generatorAssembly)?.InformationalVersion ?? string.Empty;
            GeneratedCodeAttribute = $"[GeneratedCode(\"{generatorAssemblyName}\", \"{generatorAssemblyVersion}\")]";

            GeneratorIgnoreAttribute = compilation.GetTypeByMetadataName(typeof(GeneratorIgnoreAttribute).FullName) 
                ?? throw new Exception("GeneratorIgnoreAttribute symbol not found!");
            GeneratorBindingsAttribute = compilation.GetTypeByMetadataName(typeof(GeneratorBindingsAttribute).FullName)
                ?? throw new Exception("GeneratorBindingsAttribute symbol not found!");
            GeneratorMappingAttribute = compilation.GetTypeByMetadataName(typeof(GeneratorMappingAttribute).FullName)
                ?? throw new Exception("GeneratorMappingAttribute symbol not found!");
        }
    }
}
