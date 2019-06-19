using Fody;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

public partial class ModuleWeaver
    : BaseModuleWeaver
{
    static readonly Lazy<string> assemblyName =
        new Lazy<string>(() => typeof(ModuleWeaver).Assembly.GetName().Name);
    static readonly Lazy<string> assemblyVersion =
        new Lazy<string>(() => typeof(ModuleWeaver).Assembly.GetCustomAttribute<System.Reflection.AssemblyFileVersionAttribute>()?.Version ?? string.Empty);

    readonly DictionarySet<string, MethodDefinition> methods = new DictionarySet<string, MethodDefinition>();

    public override IEnumerable<string> GetAssembliesForScanning()
        => Enumerable.Empty<string>();

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

        //foreach (var type in ModuleDefinition.GetTypes().Where(type => type.FullName == "NetFabric.Hyperlinq.Enumerable/SelectEnumerable`4"))
        //foreach (var type in ModuleDefinition.GetTypes().Where(type => type.FullName == "NetFabric.Hyperlinq.ValueReadOnlyList/SelectEnumerable`4"))
        //foreach (var type in ModuleDefinition.GetTypes())
        foreach (var type in ModuleDefinition.GetTypes().Where(type => 
            type.FullName == "NetFabric.Hyperlinq.Enumerable/SelectEnumerable`4" ||
            type.FullName == "NetFabric.Hyperlinq.ValueReadOnlyList/SelectEnumerable`4"))
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

/*
                // create the body
                var processor = newMethod.Body.GetILProcessor();
                processor.Emit(OpCodes.Ldarga_S, newMethod.Parameters[0]);
                processor.Emit(OpCodes.Constrained, extensionType);
                processor.Emit(OpCodes.Ret);
        */
        declaringType.Methods.Add(newMethod);
        LogInfo($"Added extension method. Type: '{type.FullName}' Method: '{newMethod.FullName}'");
    }

    CustomAttribute ExtensionAttribute()
        => new CustomAttribute(ModuleDefinition.ImportReference(typeof(ExtensionAttribute).GetConstructor(Type.EmptyTypes)));

    CustomAttribute GeneratedCodeAttribute()
        => new CustomAttribute(ModuleDefinition.ImportReference(typeof(System.CodeDom.Compiler.GeneratedCodeAttribute).GetConstructor(new[] { typeof(string), typeof(string) })))
        {
            ConstructorArguments =
                {
                    new CustomAttributeArgument(ModuleDefinition.TypeSystem.String, assemblyName.Value),
                    new CustomAttributeArgument(ModuleDefinition.TypeSystem.String, assemblyVersion.Value),
                },
        };
}
