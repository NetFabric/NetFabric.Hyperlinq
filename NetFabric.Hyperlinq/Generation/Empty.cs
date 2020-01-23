using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        [Pure]
        public static EmptyEnumerable<TSource> Empty<TSource>() =>
            EmptyEnumerable<TSource>.Instance;

        public partial class EmptyEnumerable<TSource>
            : IValueReadOnlyList<TSource, EmptyEnumerable<TSource>.DisposableEnumerator>
        {
            public static readonly EmptyEnumerable<TSource> Instance = new EmptyEnumerable<TSource>();

            private EmptyEnumerable() { }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator GetEnumerator() => new Enumerator();
            DisposableEnumerator IValueEnumerable<TSource, EmptyEnumerable<TSource>.DisposableEnumerator>.GetEnumerator() => new DisposableEnumerator();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new DisposableEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => new DisposableEnumerator();

            public int Count 
                => 0;

            public TSource this[int index] 
                => Throw.IndexOutOfRangeException<TSource>(); 

            public readonly struct Enumerator
            {
                [ExcludeFromCodeCoverage]
                [MaybeNull]                
                public readonly TSource Current
                    => default;

                public readonly bool MoveNext() 
                    => false;
            }

            public readonly struct DisposableEnumerator
                : IEnumerator<TSource>
            {
                [ExcludeFromCodeCoverage]
                [MaybeNull]
                public readonly TSource Current
                    => default;

                [ExcludeFromCodeCoverage]
                readonly object? IEnumerator.Current 
                    => default;

                public readonly bool MoveNext()
                    => false;

                public readonly void Reset() { }

                public readonly void Dispose() { }
            }
        }
    }
}

