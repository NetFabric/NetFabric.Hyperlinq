using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public readonly struct MaybeAt<T> 
        : IEquatable<MaybeAt<T>>
    {
        public MaybeAt(T value, int index)
        {
            HasValue = true;
            Value = value;
            Index = index;
        }

        public readonly bool HasValue { get; }
        public readonly T Value { get; }
        public readonly int Index { get; }

        [Pure]
        public static bool operator ==(MaybeAt<T> first, MaybeAt<T> second)
            => first.Equals(second);

        [Pure]
        public static bool operator !=(MaybeAt<T> first, MaybeAt<T> second)
            => !first.Equals(second);

        [Pure]
        public readonly bool Equals(MaybeAt<T> other) 
            => HasValue == other.HasValue 
            && EqualityComparer<T>.Default.Equals(Value, other.Value)
            && Index == other.Index;

        [Pure]
        public readonly override bool Equals(object other) 
            => other is MaybeAt<T> maybe && Equals(maybe);

        [Pure]
        public readonly override int GetHashCode()
#if NET461 || NETSTANDARD2_0
        {
            if (!HasValue)
                return 0;

            unchecked
            {
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                var hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (Value is null ? 0 : EqualityComparer<T>.Default.GetHashCode(Value));
                hash = (hash * HashingMultiplier) ^ Index.GetHashCode();
                return hash;
            }
        }
#else 
        => HasValue ? HashCode.Combine(Value, Index) : 0;
#endif
    }
}
