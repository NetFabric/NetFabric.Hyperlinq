using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public readonly struct Maybe<T> 
        : IEquatable<Maybe<T>>
    {
        public Maybe(T value)
        {
            HasValue = true;
            Value = value;
        }

        public readonly bool HasValue { get; }
        public readonly T Value { get; }

        [Pure]
        public static bool operator ==(Maybe<T> first, Maybe<T> second)
            => first.Equals(second);

        [Pure]
        public static bool operator !=(Maybe<T> first, Maybe<T> second)
            => !first.Equals(second);

        [Pure]
        public readonly bool Equals(Maybe<T> other) 
            => HasValue == other.HasValue && EqualityComparer<T>.Default.Equals(Value, other.Value);

        [Pure]
        public readonly override bool Equals(object other) 
            => other is Maybe<T> maybe && Equals(maybe);

        [Pure]
        public readonly override int GetHashCode() 
            => HasValue ? EqualityComparer<T>.Default.GetHashCode(Value) : 0;
    }
}
