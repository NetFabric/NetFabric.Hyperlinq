#nullable enable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class GeneratedExtensionMethods
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsValueEnumerable_TestEnumerableWithInterfacelessPublicEnumerator_TestValueType_ AsValueEnumerable(this TestEnumerableWithInterfacelessPublicEnumerator<TestValueType> source) => new(source);

        public readonly struct AsValueEnumerable_TestEnumerableWithInterfacelessPublicEnumerator_TestValueType_: IValueEnumerable<TestValueType, ValueEnumerator<TestValueType>>
        {
            readonly TestEnumerableWithInterfacelessPublicEnumerator<TestValueType> source;

            internal AsValueEnumerable_TestEnumerableWithInterfacelessPublicEnumerator_TestValueType_(TestEnumerableWithInterfacelessPublicEnumerator<TestValueType> source) => this.source = source;

            // Implement IValueEnumerable<TestValueType, ValueEnumerator<TestValueType>>

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TestEnumerableWithInterfacelessPublicEnumerator<TestValueType>.Enumerator GetEnumerator() => source.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            ValueEnumerator<TestValueType> IValueEnumerable<TestValueType, ValueEnumerator<TestValueType>>.GetEnumerator() => new(((IEnumerable<TestValueType>)source).GetEnumerator());

            IEnumerator<TestValueType> IEnumerable<TestValueType>.GetEnumerator() => ((IEnumerable<TestValueType>)source).GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<TestValueType>)source).GetEnumerator();
        }
    }
}
