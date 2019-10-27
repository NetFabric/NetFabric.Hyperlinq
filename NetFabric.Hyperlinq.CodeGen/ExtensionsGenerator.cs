using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Uno.SourceGeneration;

namespace NetFabric.Hyperlinq.CodeGen
{
    public class ExtensionsGenerator : SourceGenerator
    {
		SourceGeneratorContext context;
		ISourceGeneratorLogger logger;
		INamedTypeSymbol genericsMappingAttributeSymbol;
		INamedTypeSymbol genericsTypeMappingAttributeSymbol;
		INamedTypeSymbol ignoreAttributeSymbol;

        readonly Dictionary<Type, List<IMethodSymbol>> extensionMethods = new Dictionary<Type, List<IMethodSymbol>>();
        //readonly Dictionary<Type, Dictionary<IMethodSymbol, MethodAssignmentInfo>> methodAssignments = new Dictionary<Type, Dictionary<IMethodSymbol, MethodAssignmentInfo>>();

        public override void Execute(SourceGeneratorContext context)
        {
            //Debugger.Launch(); // uncomment to debug code generator

            this.context = context;
            logger = context.GetLogger();

            var compilation = context.Compilation;
            genericsMappingAttributeSymbol = compilation.GetTypeByMetadataName("NetFabric.GenericsMappingAttribute");
            genericsTypeMappingAttributeSymbol = compilation.GetTypeByMetadataName("NetFabric.GenericsTypeMappingAttribute");
            ignoreAttributeSymbol = compilation.GetTypeByMetadataName("NetFabric.IgnoreAttribute");

            //var project = context.GetProjectInstance();

            CollectExtensionMethods();
        }

        void CollectExtensionMethods()
        {
            logger.Info("Collecting extension methods with interface constraints!");

            var typeSymbols = context.Compilation.SourceModule.GlobalNamespace.GetNamespaceTypes();
            foreach (var typeSymbol in typeSymbols
                .Where(type => type.IsPublic() && type.IsStatic))
            {
                logger.Warn($"* {typeSymbol.Name}");

                foreach (var method in typeSymbol.GetMembers().OfType<IMethodSymbol>()
                    .Where(method => method.IsPublic() && method.IsExtensionMethod))
                {
                    logger.Warn($"** {method.Name}");

                    //        //    var extensionType = method.Parameters[0].Type;
                    //        //    if (method.IsGenericMethod)
                    //        //    {
                    //        //        var generic = method.TypeParameters
                    //        //            .FirstOrDefault(parameter => 
                    //        //                parameter.Name == extensionType.Name &&
                    //        //                parameter.ConstraintTypes.Length != 0);

                    //        //        if (generic is object)
                    //        //        {
                    //        //            var constraintType = generic.ConstraintTypes[0].GetType();
                    //        //            if (constraintType.IsInterface)
                    //        //            {
                    //        //                if (!extensionMethods.TryGetValue(constraintType, out var list))
                    //        //                {
                    //        //                    list = new List<IMethodSymbol>();
                    //        //                    extensionMethods.Add(constraintType, list);
                    //        //                }
                    //        //                list.Add(method);

                    //        //                logger.Debug($"Extension Method - Constraint: {constraintType.FullName} Type: {typeSymbol.Name} Method: {method.Name}");
                    //        //            }
                    //        //        }
                    //        //    }
                }
            }
        }

    }
}
