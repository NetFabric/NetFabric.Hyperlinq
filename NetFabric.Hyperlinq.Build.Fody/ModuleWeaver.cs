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
    readonly Dictionary<TypeDefinitionKey, List<MethodInfo>> extensionMethods = new Dictionary<TypeDefinitionKey, List<MethodInfo>>();
    readonly Dictionary<TypeDefinitionKey, Dictionary<MethodDefinitionKey, MethodAssignmentInfo>> methodAssignments = new Dictionary<TypeDefinitionKey, Dictionary<MethodDefinitionKey, MethodAssignmentInfo>>();

    public override IEnumerable<string> GetAssembliesForScanning()
    {
        yield return "mscorlib";
        yield return "System.Runtime";
        yield return "System";
        yield return "netstandard";
        yield return "System.Diagnostics.Contracts.dll";
    }

    public override bool ShouldCleanReference
        => true;

    public override void Execute()
    {
        CollectExtensionMethods();
        AssignExtensionMethods();
        AddMethods();
    }

    void CollectExtensionMethods()
    {
        LogInfo("Collecting extension methods with interface constraints!");

        foreach (var type in ModuleDefinition.GetTypes()
            .Where(type => type.IsPublic && type.IsClass && type.IsSealed && type.IsAbstract)) // public static class
        {
            foreach (var method in type.Methods
                .Where(method => method.IsPublic && method.IsExtensionMethod()))
            {
                var extensionType = method.Parameters[0].ParameterType;
                var generic = method.GenericParameters.FirstOrDefault(genericParameter => genericParameter.Name == extensionType.Name);
                if (generic is object && generic.HasConstraints)
                {
                    var constraintType = generic.Constraints[0].ConstraintType.Resolve();
                    if (constraintType.IsInterface)
                    {
                        var key = new TypeDefinitionKey(constraintType);
                        if (!extensionMethods.TryGetValue(key, out var list))
                        {
                            list = new List<MethodInfo>();
                            extensionMethods.Add(key, list);
                        }
                        list.Add(new MethodInfo(type, method));

                        LogInfo($"Extension Method - Constraint: {constraintType.FullName} Type: {type.FullName} Method: {method.FullName}");
                    }
                }
            }
        }
    }

    void AssignExtensionMethods()
    {
        LogInfo("Assign methods that call the collected extension methods!");

        foreach (var type in ModuleDefinition.GetTypes()
            .Where(type => !type.IsInterface && type.HasInterfaces && !type.ShouldBeIgnored()))
        {
            var typeAssignments = new Dictionary<MethodDefinitionKey, MethodAssignmentInfo>();

            // assign the extension methods for each implemented interface
            foreach (var interf in type.Interfaces)
            {
                var resolvedInterfaceType = interf.InterfaceType.Resolve();

                // get the extension methods for this interface
                if (extensionMethods.TryGetValue(new TypeDefinitionKey(resolvedInterfaceType), out var interfaceMethods))
                {
                    foreach (var interfaceMethod in interfaceMethods)
                    {
                        // assign or update assigment
                        var methodKey = new MethodDefinitionKey(interfaceMethod.Method);
                        if (typeAssignments.TryGetValue(methodKey, out var assignment))
                        {
                            // check if this new interface implements the assigned interface
                            if (resolvedInterfaceType.Interfaces
                                .Select(interf => interf.InterfaceType.Resolve())
                                .Contains(assignment.Interface.InterfaceType.Resolve())) 
                            {
                                // replace the source of the assigned method
                                typeAssignments.Remove(methodKey);
                                typeAssignments.Add(methodKey, new MethodAssignmentInfo(interf));
                            }
                            else
                            {
                                // do nothing
                            }
                        }
                        else
                        {
                            typeAssignments.Add(methodKey, new MethodAssignmentInfo(interf));
                        }
                    }
                }
            }

            if (typeAssignments.Count != 0)
                methodAssignments.Add(new TypeDefinitionKey(type), typeAssignments);

            // remove the attributes so that the dependency can be removed
            //type.RemoveBuildAttributes();
        }
    }

    void AddMethods()
    {
        LogInfo("Adding methods that call the collected extension methods!");

        foreach (var typeDefinition in methodAssignments.Keys)
        {
            var assignments = methodAssignments[typeDefinition];

            var type = typeDefinition.Value;
            var genericsMapping = Utils.GenericsMapping(type);
            var genericsTypeMapping = Utils.GenericsTypeMapping(type, ModuleDefinition);

            // add all assigned extension methods
            foreach (var methodDefinition in assignments.Keys)
            {
                AddMethod(type, methodDefinition.Value, genericsMapping, genericsTypeMapping);
            }
        }
    }

    void AddMethod(TypeDefinition type, MethodDefinition method, IReadOnlyDictionary<string, string> genericsMapping, IReadOnlyDictionary<string, TypeReference> genericsTypeMapping)
    {
        // check if there is name clashing with a property
        var property = type.Properties.FirstOrDefault(prop => prop.Name == method.Name);
        if (property is null)
            AddMethodInstance(type, method, genericsMapping, genericsTypeMapping);
        else
            AddMethodExtension(type, method, genericsMapping, genericsTypeMapping);
    }

    void AddMethodInstance(TypeDefinition type, MethodDefinition method, IReadOnlyDictionary<string, string> genericsMapping, IReadOnlyDictionary<string, TypeReference> genericsTypeMapping)
    {
        // create the new method
        var newMethod = new MethodDefinition(method.Name, MethodAttributes.Public | MethodAttributes.HideBySig, method.ReturnType)
        {
            AggressiveInlining = true,
            CustomAttributes = {
                PureAttribute(),
                GeneratedCodeAttribute(),
            },
            DeclaringType = type,
        };

        // collect the generics parameters
        var genericsParameters = new List<GenericParameter>();
        // get generics parameters from the type
        if (type.HasGenericParameters) 
        {
            foreach (var parameter in type.GenericParameters)
                genericsParameters.Add(parameter);
        }
        // get the generics parameters from the method that are not from the type
        if (method.HasGenericParameters) 
        {
            foreach (var parameter in method.GenericParameters)
            {
                var parameterName = parameter.Name;
                if (genericsMapping.TryGetValue(parameterName, out var mappedParameterName))
                    parameterName = mappedParameterName;

                if (!(genericsTypeMapping.TryGetValue(parameterName, out var _) || genericsParameters.Any(p => p.Name == parameterName)))
                {
                    var newGenericParameter = new GenericParameter(parameterName, newMethod)
                    {
                        HasDefaultConstructorConstraint = parameter.HasDefaultConstructorConstraint,
                        HasNotNullableValueTypeConstraint = parameter.HasNotNullableValueTypeConstraint,
                        HasReferenceTypeConstraint = parameter.HasReferenceTypeConstraint,
                    };

                    genericsParameters.Add(newGenericParameter);
                    newMethod.GenericParameters.Add(newGenericParameter); // add to the new method
                }
            }
        }

        // resolve the return type
        newMethod.ReturnType = Utils.ResolveGenericType(method.ReturnType, genericsParameters, genericsMapping, genericsTypeMapping);

        // copy the method parameters (ignoring the first one)
        if (method.HasParameters)
        {
            foreach (var param in method.Parameters.Skip(1))
            {
                var paramType = Utils.ResolveGenericType(param.ParameterType, genericsParameters, genericsMapping, genericsTypeMapping);
                newMethod.Parameters.Add(new ParameterDefinition(param.Name, param.Attributes, paramType));
            }
        }

        // check if method already exists (optimizations may be manually added)
        if (type.Methods.Any(m => m.IsSame(newMethod)))
            return;

        // create the method body
        var objectType = type as TypeReference;
        if (type.HasGenericParameters)
            objectType = Utils.ResolveGenericType(type, genericsParameters, null, genericsTypeMapping);

        var calledMethod = method as MethodReference;
        if (method.HasGenericParameters)
        {
            var genericMethod = new GenericInstanceMethod(method);
            foreach (var parameter in method.GenericParameters)
            {
                var resolvedParameter = Utils.ResolveGenericType(parameter, genericsParameters, genericsMapping, genericsTypeMapping);
                genericMethod.GenericArguments.Add(resolvedParameter);
            }
            calledMethod = genericMethod;
        }

        var processor = newMethod.Body.GetILProcessor();
        processor.Emit(OpCodes.Ldarg_0);
        processor.Emit(OpCodes.Ldobj, objectType);
        for (var index = 0; index < newMethod.Parameters.Count; index++)
            Utils.LoadArg(processor, index + 1);
        processor.Emit(OpCodes.Call, calledMethod);
        processor.Emit(OpCodes.Ret);

        // add the new method to the type
        type.Methods.Add(newMethod);
        LogInfo($"Added instance method. Type: '{type.FullName}' Method: '{newMethod.FullName}'");
    }

    void AddMethodExtension(TypeDefinition type, MethodDefinition method, IReadOnlyDictionary<string, string> genericsMapping, IReadOnlyDictionary<string, TypeReference> genericsTypeMapping)
    {
        // create the extension method
        var newMethod = new MethodDefinition(method.Name, MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.Static, method.ReturnType)
        {
            AggressiveInlining = true,
            CustomAttributes = {
                PureAttribute(),
                GeneratedCodeAttribute(),
                ExtensionAttribute(),
            },
        };

        // collect the generics parameters
        var genericsParameters = new List<GenericParameter>();
        // get generics parameters from the type
        if (type.HasGenericParameters)
        {
            foreach (var parameter in type.GenericParameters)
            {
                var newGenericParameter = new GenericParameter(parameter.Name, newMethod)
                {
                    HasDefaultConstructorConstraint = parameter.HasDefaultConstructorConstraint,
                    HasNotNullableValueTypeConstraint = parameter.HasNotNullableValueTypeConstraint,
                    HasReferenceTypeConstraint = parameter.HasReferenceTypeConstraint,
                };

                genericsParameters.Add(newGenericParameter);
                newMethod.GenericParameters.Add(newGenericParameter);
            }
        }

        // resolve the return type
        newMethod.ReturnType = Utils.ResolveGenericType(method.ReturnType, genericsParameters, genericsMapping, genericsTypeMapping);

        // set the contraints for the new method and set the generic parameters for the type of first parameter
        // this can only be performed after all generic parameters for the new method are set
        var extensionType = type as TypeReference;
        if (type.HasGenericParameters)
        {
            var genericType = new GenericInstanceType(type);
            for (var index = 0; index < newMethod.GenericParameters.Count; index++)
            {
                var param = type.GenericParameters[index];
                var newParam = newMethod.GenericParameters[index];
                if (param.HasConstraints)
                {
                    foreach (var constraint in param.Constraints)
                    {
                        var constraintType = constraint.ConstraintType;
                        if (!constraintType.IsValueType)
                        {
                            var resolvedConstraint = new GenericParameterConstraint(Utils.ResolveGenericType(constraintType, newMethod));
                            newParam.Constraints.Add(resolvedConstraint);
                        }
                    }
                }

                genericType.GenericArguments.Add(newParam);
            }

            extensionType = genericType;
        }
        var calledMethod = method as MethodReference;
        if (method.HasGenericParameters)
        {
            var genericMethod = new GenericInstanceMethod(method);
            foreach (var parameter in method.GenericParameters)
            {
                if (genericsTypeMapping.TryGetValue(parameter.Name, out var parameterTypeMapped))
                {
                    var resolvedParameter = Utils.ResolveGenericType(parameterTypeMapped, genericsParameters, genericsMapping, genericsTypeMapping);
                    genericMethod.GenericArguments.Add(resolvedParameter);
                }
                else
                {
                    var resolvedParameter = Utils.ResolveGenericType(parameter, genericsParameters, genericsMapping, genericsTypeMapping);
                    genericMethod.GenericArguments.Add(resolvedParameter);
                }
            }
            calledMethod = genericMethod;
        }

        newMethod.Parameters.Add(new ParameterDefinition("source", ParameterAttributes.None, extensionType));

        // copy the parameters (ignoring the first one)
        if (method.HasParameters)
        {
            foreach (var param in method.Parameters.Skip(1))
            {
                var paramType = Utils.ResolveGenericType(param.ParameterType, genericsParameters, genericsMapping, genericsTypeMapping);
                newMethod.Parameters.Add(new ParameterDefinition(param.Name, param.Attributes, paramType));
            }
        }

        var declaringType = type.DeclaringType;

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

    static CustomAttribute pureAttribute;

    CustomAttribute PureAttribute()
        => LazyInitializer.EnsureInitialized(ref pureAttribute, () =>
        {
            var type = ModuleDefinition.ImportReference(FindType(typeof(System.Diagnostics.Contracts.PureAttribute).FullName));
            var constructor = type.Resolve().Methods.First(method =>
                method.IsConstructor &&
                !method.HasParameters);
            return new CustomAttribute(ModuleDefinition.ImportReference(constructor));
        });

    static CustomAttribute extensionAttribute;

    CustomAttribute ExtensionAttribute()
        => LazyInitializer.EnsureInitialized(ref extensionAttribute, () =>
        {
            var type = ModuleDefinition.ImportReference(FindType(typeof(System.Runtime.CompilerServices.ExtensionAttribute).FullName));
            var constructor = type.Resolve().Methods.First(method => 
                method.IsConstructor && 
                !method.HasParameters);
            return new CustomAttribute(ModuleDefinition.ImportReference(constructor));
        });

    static CustomAttribute generatedCodeAttribute;

    CustomAttribute GeneratedCodeAttribute()
        => LazyInitializer.EnsureInitialized(ref generatedCodeAttribute, () =>
        {
            var type = ModuleDefinition.ImportReference(FindType(typeof(System.CodeDom.Compiler.GeneratedCodeAttribute).FullName));
            var constructor = type.Resolve().Methods.First(method => 
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
