using Mono.Cecil;
using Mono.Collections.Generic;
using System;

readonly struct InterfaceImplementationKey : IEquatable<InterfaceImplementationKey>
{
    public InterfaceImplementationKey(InterfaceImplementation interfaceImplementation)
    {
        Value = interfaceImplementation;
    }

    public readonly InterfaceImplementation Value { get; }

    public readonly bool Equals(InterfaceImplementationKey other)
        => Value.InterfaceType.FullName.Equals(other.Value.InterfaceType.FullName);

    public readonly override bool Equals(object obj)
        => obj is TypeDefinitionKey key && Equals(key);

    public readonly override int GetHashCode()
    {
        unchecked
        {
            const int HashingBase = (int)2166136261;
            const int HashingMultiplier = 16777619;

            var hash = HashingBase;
            hash = (hash * HashingMultiplier) ^ Value?.InterfaceType.FullName.GetHashCode() ?? 0;
            return hash;
        }
    }
}

readonly struct TypeDefinitionKey : IEquatable<TypeDefinitionKey>
{
    public TypeDefinitionKey(TypeDefinition typeDefinition)
    {
        Value = typeDefinition;
    }

    public readonly TypeDefinition Value { get; }

    public readonly bool Equals(TypeDefinitionKey other)
        => Value.FullName.Equals(other.Value.FullName);

    public readonly override bool Equals(object obj)
        => obj is TypeDefinitionKey key && Equals(key);

    public readonly override int GetHashCode()
    {
        unchecked
        {
            const int HashingBase = (int)2166136261;
            const int HashingMultiplier = 16777619;

            var hash = HashingBase;
            hash = (hash * HashingMultiplier) ^ Value?.FullName.GetHashCode() ?? 0;
            return hash;
        }
    }
}

readonly struct MethodDefinitionKey : IEquatable<MethodDefinitionKey>
{
    public MethodDefinitionKey(MethodDefinition methodDefinition)
    {
        Value = methodDefinition;
    }

    public readonly MethodDefinition Value { get; }

    public readonly bool Equals(MethodDefinitionKey other)
        => Value.Name == other.Value.Name &&
            Value.HasParameters == other.Value.HasParameters &&
            Equals(Value.Parameters, other.Value.Parameters);

    public readonly override bool Equals(object obj)
        => obj is MethodDefinitionKey key && Equals(key);

    public readonly override int GetHashCode()
    {
        unchecked
        {
            const int HashingBase = (int)2166136261;
            const int HashingMultiplier = 16777619;

            var hash = HashingBase;
            hash = (hash * HashingMultiplier) ^ Value?.Name.GetHashCode() ?? 0;
            if (Value.HasParameters)
            {
                foreach (var parameter in Value.Parameters)
                {
                    hash = (hash * HashingMultiplier) ^ parameter.ParameterType.FullName.GetHashCode();
                }
            }
            return hash;
        }
    }

    static bool Equals(Collection<ParameterDefinition> left, Collection<ParameterDefinition> right)
    {
        if (left.Count != right.Count)
            return false;

        var count = left.Count;
        for (var index = 0; index < count; index++)
        {
            var leftParameter = left[index];
            var rightParameter = right[index];

            if (leftParameter.ParameterType.FullName != rightParameter.ParameterType.FullName)
                return false;
        }

        return true;
    }
}

readonly struct MethodInfo
{
    public MethodInfo(TypeReference type, MethodDefinition method)
    {
        Type = type;
        Method = method;
    }

    public TypeReference Type { get; }

    public MethodDefinition Method { get; }
}

struct MethodAssignmentInfo
{
    public MethodAssignmentInfo(InterfaceImplementation interf)
    {
        Interface = interf;
    }

    public InterfaceImplementation Interface { get; set; }
}
