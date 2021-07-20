using System;
using System.Collections.Immutable;
using System.Linq;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    readonly struct MethodSignature
        : IEquatable<MethodSignature>
    {
        public MethodSignature(string name, params string[] parameters)
            => (Name, Parameters) = (name, ImmutableArray.Create(parameters));

        readonly string Name { get; }
        readonly ImmutableArray<string> Parameters { get; }

        public bool Equals(MethodSignature other)
            => Name == other.Name && Parameters.SequenceEqual(other.Parameters);

        public override bool Equals(object other) 
            => other is MethodSignature signature && Equals(signature);

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                var hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ Name.GetHashCode();
                foreach(var parameter in Parameters)
                    hash = (hash * HashingMultiplier) ^ parameter.GetHashCode();
                return hash;
            }
        }
    }
}
