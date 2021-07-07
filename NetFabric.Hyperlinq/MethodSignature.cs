using Microsoft.CodeAnalysis;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    readonly struct MethodSignature
        : IEquatable<MethodSignature>
    {
        public MethodSignature(string name, string receiverType, params string[] parameters)
            => (Name, ReceiverType, Parameters) = (name, receiverType, ImmutableArray.Create(parameters));

        string Name { get; }
        string ReceiverType { get; }
        ImmutableArray<string> Parameters { get; }

        public bool Equals(MethodSignature other)
            => Name == other.Name && ReceiverType == other.ReceiverType && Parameters.SequenceEqual(other.Parameters);

        public override bool Equals(object other) 
            => other is MethodSignature signature && Equals(signature);

        public override int GetHashCode()
        {
            unchecked
            {
                const int hashingBase = (int)2166136261;
                const int hashingMultiplier = 16777619;

                var hash = hashingBase;
                hash = (hash * hashingMultiplier) ^ Name.GetHashCode();
                hash = (hash * hashingMultiplier) ^ ReceiverType.GetHashCode();
                // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
                foreach(var parameter in Parameters)
                    hash = (hash * hashingMultiplier) ^ parameter.GetHashCode();
                return hash;
            }
        }
    }
}
