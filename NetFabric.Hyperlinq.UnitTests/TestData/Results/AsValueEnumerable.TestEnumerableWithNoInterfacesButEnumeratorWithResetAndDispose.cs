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
    public static AsValueEnumerable_TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose_TestValueType_ AsValueEnumerable(this TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose<TestValueType> source)
        => new(source);

    public readonly struct AsValueEnumerable_TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose_TestValueType_
        : IValueEnumerable<TestValueType, AsValueEnumerable_TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose_TestValueType_.Enumerator>
    {
        readonly TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose<TestValueType> source;

        internal AsValueEnumerable_TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose_TestValueType_(TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose<TestValueType> source)
            => this.source = source;

        // Implement IValueEnumerable<TestValueType, AsValueEnumerable_TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose_TestValueType_.Enumerator>

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Enumerator GetEnumerator() => new(source.GetEnumerator());

        IEnumerator<TestValueType> IEnumerable<TestValueType>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public struct Enumerator : IEnumerator<TestValueType>
        {
            readonly TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose<TestValueType>.Enumerator source;

            internal Enumerator(TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose<TestValueType>.Enumerator source)
                => this.source = source;

            public TestValueType Current
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Current;
            }

            object? IEnumerator.Current => source.Current;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext() => source.MoveNext();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Reset() => source.Reset();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Dispose() => source.Dispose();
        }
    }
}
