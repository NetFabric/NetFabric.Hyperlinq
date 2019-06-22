using Fody;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public partial class ModuleWeaver
    : BaseModuleWeaver
{
    readonly DictionarySet<string, MethodDefinition> methods = new DictionarySet<string, MethodDefinition>();

    public override IEnumerable<string> GetAssembliesForScanning()
    {
        yield return "netstandard";
    }

    public override bool ShouldCleanReference
        => true;

    public override void Execute()
    {
        CollectMethods();
        AddMethods();
    }

    void CollectMethods()
    {
        LogInfo("Collecting extension methods with interface constraints!");

        foreach (var method in ModuleDefinition.GetTypes()
            .Where(type => type.IsPublic && type.IsClass && type.IsSealed && type.IsAbstract) // public static class
            .SelectMany(type => type.Methods)
            .Where(method => method.IsExtensionMethod()))
        {
            var extensionType = method.Parameters[0].ParameterType;

            var generic = method.GenericParameters.FirstOrDefault(genericParameter => genericParameter.HasConstraints && genericParameter.Name == extensionType.Name);
            if (generic is object)
            {
                var constraint = generic.Constraints[0];
                if (methods.TryAdd(constraint.Name, method))
                    LogInfo($"Constraint: {constraint.Name} Method: {method.FullName}");
            }
        }
    }

    void AddMethods()
    {
        LogInfo("Adding methods that call the collected extension methods!");

        foreach (var type in ModuleDefinition.GetTypes())
        //foreach (var type in ModuleDefinition.GetTypes().Where(type => 
        //    type.FullName == "NetFabric.Hyperlinq.Enumerable/SelectEnumerable`4" ||
        //    type.FullName == "NetFabric.Hyperlinq.ValueReadOnlyList/SelectEnumerable`4"))
        {
            if (!type.IsInterface && type.HasInterfaces && !type.ShouldBeIgnored())
            {
                // add the extension methods for each implemented interface
                foreach (var interf in type.Interfaces)
                    AddMethods(type, interf);
            }

            // remove the attributes so that the dependency can be removed
            type.RemoveBuildAttributes();
        }
    }

    void AddMethods(TypeDefinition type, InterfaceImplementation interf)
    {
        // get the extension methods for this interface
        if (methods.TryGetValue(interf.InterfaceType.Name, out var interfMethods))
        {
            var genericsMapping = Utils.GenericsMapping(type);
            var genericsTypeMapping = Utils.GenericsTypeMapping(type, ModuleDefinition);

            foreach (var method in interfMethods)
                AddMethod(type, interf, method, genericsMapping, genericsTypeMapping);
        }
    }

    void AddMethod(TypeDefinition type, InterfaceImplementation interf, MethodDefinition method, IReadOnlyDictionary<string, string> genericsMapping, IReadOnlyDictionary<string, TypeReference> genericsTypeMapping)
    {
        // check if there is name clashing with a property
        var property = type.Properties.FirstOrDefault(prop => prop.Name == method.Name);
        if (property is null)
            AddMethodInstance(type, method, genericsMapping, genericsTypeMapping);
        else
            AddMethodExtension(type, method, property, genericsMapping, genericsTypeMapping);
    }

    void AddMethodInstance(TypeDefinition type, MethodDefinition method, IReadOnlyDictionary<string, string> genericsMapping, IReadOnlyDictionary<string, TypeReference> genericsTypeMapping)
    {
        // create the new method
        var returnType = Utils.ResolveGenericType(method.ReturnType, type, genericsMapping, genericsTypeMapping);
        var newMethod = new MethodDefinition(method.Name, MethodAttributes.Public | MethodAttributes.HideBySig, returnType)
        {
            AggressiveInlining = true,
            CustomAttributes = {
                GeneratedCodeAttribute(),
            },
            DeclaringType = type,
        };

        // copy the parameters (ignoring the first one)
        if (method.HasParameters)
        {
            foreach (var param in method.Parameters.Skip(1))
            {
                var paramType = Utils.ResolveGenericType(param.ParameterType, type, genericsMapping, genericsTypeMapping);
                newMethod.Parameters.Add(new ParameterDefinition(param.Name, param.Attributes, paramType));
            }
        }

        // check if method already exists
        if (type.Methods.Any(m => m.IsSame(newMethod)))
            return;

        // set the generics arguments
        var genericType = new GenericInstanceType(type);
        var genericMethod = new GenericInstanceMethod(method);
        if (type.HasGenericParameters)
        {
            foreach (var parameter in type.GenericParameters)
            {
                genericType.GenericArguments.Add(parameter);
                genericMethod.GenericArguments.Add(Utils.ResolveGenericType(parameter, type, genericsMapping, genericsTypeMapping));
            }
        }

        // create the method body
        var processor = newMethod.Body.GetILProcessor();
        processor.Emit(OpCodes.Ldarg_0);
        processor.Emit(OpCodes.Ldobj, genericType);
        for (var index = 0; index < newMethod.Parameters.Count; index++)
            Utils.LoadArg(processor, index + 1);
        processor.Emit(OpCodes.Call, genericMethod);
        processor.Emit(OpCodes.Ret);

        // add the new method to the type
        type.Methods.Add(newMethod);
        LogInfo($"Added instance method. Type: '{type.FullName}' Method: '{newMethod.FullName}'");
    }

    void AddMethodExtension(TypeDefinition type, MethodDefinition method, PropertyDefinition property, IReadOnlyDictionary<string, string> genericsMapping, IReadOnlyDictionary<string, TypeReference> genericsTypeMapping)
    {
        var declaringType = type.DeclaringType;

        // create the extension method
        var returnType = Utils.ResolveGenericType(property.PropertyType, type, genericsMapping, genericsTypeMapping);
        var newMethod = new MethodDefinition(method.Name, MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.Static, returnType)
        {
            AggressiveInlining = true,
            CustomAttributes = {
                GeneratedCodeAttribute(),
                ExtensionAttribute(),
            },
        };

        var extensionType = new GenericInstanceType(type);
        var calledMethod = new GenericInstanceMethod(method);
        if (type.HasGenericParameters)
        {
            // set the generic parameters for the new method
            foreach (var param in type.GenericParameters)
            {
                var newParameter = new GenericParameter(param.Name, newMethod)
                {
                    HasDefaultConstructorConstraint = param.HasDefaultConstructorConstraint,
                    HasNotNullableValueTypeConstraint = param.HasNotNullableValueTypeConstraint,
                    HasReferenceTypeConstraint = param.HasReferenceTypeConstraint,
                };
                newMethod.GenericParameters.Add(newParameter);
            }

            // set the contraints for the new method and set the generic parameters for the type of first parameter
            // this can only be performed after all generic parameters for the new method are set
            for (var index = 0; index < newMethod.GenericParameters.Count; index++)
            {
                var param = type.GenericParameters[index];
                var newParam = newMethod.GenericParameters[index];
                if (param.HasConstraints)
                {
                    foreach (var constraint in param.Constraints)
                    {
                        switch (constraint.Name)
                        {
                            case "ValueType": // HasReferenceTypeConstraint is true
                                // ignore
                                break;
                            default:
                                newParam.Constraints.Add(Utils.ResolveGenericType(constraint, newMethod));
                                break;
                        }
                    }
                }

                extensionType.GenericArguments.Add(newParam);
                calledMethod.GenericArguments.Add(Utils.ResolveGenericType(param, type, genericsMapping, genericsTypeMapping));
            }
        }

        newMethod.Parameters.Add(new ParameterDefinition("source", ParameterAttributes.None, extensionType));

        // copy the parameters (ignoring the first one)
        if (method.HasParameters)
        {
            foreach (var param in method.Parameters.Skip(1))
            {
                var paramType = Utils.ResolveGenericType(param.ParameterType, newMethod, genericsMapping);
                newMethod.Parameters.Add(new ParameterDefinition(param.Name, param.Attributes, paramType));
            }
        }

        var u = declaringType.Methods.FirstOrDefault(m =>
             m.Name == method.Name &&
             m.IsExtensionMethod() &&
             m.Parameters[0].ParameterType.FullName == extensionType.FullName);

        // check if method already exists
        if (declaringType.Methods.Any(m => m.IsSame(newMethod))) // && m.IsExtensionMethod()))
            return;

        // create the body
        var processor = newMethod.Body.GetILProcessor();
        for (var index = 0; index < newMethod.Parameters.Count; index++)
            Utils.LoadArg(processor, index);
        processor.Emit(OpCodes.Call, calledMethod);
        processor.Emit(OpCodes.Ret);

        declaringType.Methods.Add(newMethod);
        LogInfo($"Added extension method. Type: '{type.FullName}' Method: '{newMethod.FullName}'");
    }

    static CustomAttribute extensionAttribute;

    CustomAttribute ExtensionAttribute()
        => LazyInitializer.EnsureInitialized(ref extensionAttribute, () =>
        {
            var type = FindType(typeof(System.Runtime.CompilerServices.ExtensionAttribute).FullName);
            var constructor = type.Methods.First(method => 
                method.IsConstructor && 
                !method.HasParameters);
            return new CustomAttribute(ModuleDefinition.ImportReference(constructor));
        });

    static CustomAttribute generatedCodeAttribute;

    CustomAttribute GeneratedCodeAttribute()
        => LazyInitializer.EnsureInitialized(ref generatedCodeAttribute, () =>
        {
            var type = FindType(typeof(System.CodeDom.Compiler.GeneratedCodeAttribute).FullName);
            var constructor = type.Methods.First(method => 
                method.IsConstructor && 
                method.Parameters.Count == 2 &&
                method.Parameters[0].ParameterType.FullName == "System.String" &&
                method.Parameters[1].ParameterType.FullName == "System.String");
            var assemblyName = GetType().Assembly.GetName().Name;
            var assemblyVersion = ((System.Reflection.AssemblyFileVersionAttribute)Attribute.GetCustomAttribute(GetType().Assembly, typeof(System.Reflection.AssemblyFileVersionAttribute), false))?.Version ?? string.Empty;
            return new CustomAttribute(ModuleDefinition.ImportReference(constructor))
                {
                    ConstructorArguments = {
                        new CustomAttributeArgument(ModuleDefinition.TypeSystem.String, assemblyName),
                        new CustomAttributeArgument(ModuleDefinition.TypeSystem.String, assemblyVersion),
                    }
                };
        });
}
