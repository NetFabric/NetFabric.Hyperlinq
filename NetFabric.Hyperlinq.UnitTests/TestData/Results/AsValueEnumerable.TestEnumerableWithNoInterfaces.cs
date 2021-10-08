#nullable enable

using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq;

static partial class GeneratedExtensionMethods
{

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static AsValueEnumerable_TestEnumerableWithNoInterfaces_TestValueType_ AsValueEnumerable(this TestEnumerableWithNoInterfaces<TestValueType> source)
        => new(source);

    public readonly struct AsValueEnumerable_TestEnumerableWithNoInterfaces_TestValueType_
        : IValueEnumerable<TestValueType, AsValueEnumerable_TestEnumerableWithNoInterfaces_TestValueType_.Enumerator>
    {
        readonly TestEnumerableWithNoInterfaces<TestValueType> source;

        internal AsValueEnumerable_TestEnumerableWithNoInterfaces_TestValueType_(TestEnumerableWithNoInterfaces<TestValueType> source)
            => this.source = source;

        // Implement IValueEnumerable<TestValueType, AsValueEnumerable_TestEnumerableWithNoInterfaces_TestValueType_.Enumerator>

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Enumerator GetEnumerator() => new(source.GetEnumerator());

        IEnumerator<TestValueType> IEnumerable<TestValueType>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public struct Enumerator : IEnumerator<TestValueType>
        {
            readonly TestEnumerableWithNoInterfaces<TestValueType>.Enumerator source;

            internal Enumerator(TestEnumerableWithNoInterfaces<TestValueType>.Enumerator source)
                => this.source = source;

            public TestValueType Current
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Current;
            }

            object? IEnumerator.Current => source.Current;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext() => source.MoveNext();

            public void Reset() => throw new NotSupportedException();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Dispose() { }
        }
    }
}
