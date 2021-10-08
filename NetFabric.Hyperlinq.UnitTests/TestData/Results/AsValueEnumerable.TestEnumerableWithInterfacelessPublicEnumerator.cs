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
    public static AsValueEnumerable_TestEnumerableWithInterfacelessPublicEnumerator_TestValueType_ AsValueEnumerable(this TestEnumerableWithInterfacelessPublicEnumerator<TestValueType> source)
        => new(source);

    public readonly struct AsValueEnumerable_TestEnumerableWithInterfacelessPublicEnumerator_TestValueType_
        : IValueEnumerable<TestValueType, AsValueEnumerable_TestEnumerableWithInterfacelessPublicEnumerator_TestValueType_.Enumerator>
    {
        readonly TestEnumerableWithInterfacelessPublicEnumerator<TestValueType> source;

        internal AsValueEnumerable_TestEnumerableWithInterfacelessPublicEnumerator_TestValueType_(TestEnumerableWithInterfacelessPublicEnumerator<TestValueType> source)
            => this.source = source;

        // Implement IValueEnumerable<TestValueType, AsValueEnumerable_TestEnumerableWithInterfacelessPublicEnumerator_TestValueType_.Enumerator>

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Enumerator GetEnumerator() => new(source.GetEnumerator());

        IEnumerator<TestValueType> IEnumerable<TestValueType>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public struct Enumerator : IEnumerator<TestValueType>
        {
            readonly TestEnumerableWithInterfacelessPublicEnumerator<TestValueType>.Enumerator source;

            internal Enumerator(TestEnumerableWithInterfacelessPublicEnumerator<TestValueType>.Enumerator source)
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
