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
        public static TestEnumerableWithInterfacelessPublicEnumeratorAsValueEnumerable AsValueEnumerable(this TestEnumerableWithInterfacelessPublicEnumerator source) => new(source);

        public readonly struct TestEnumerableWithInterfacelessPublicEnumeratorAsValueEnumerable: IValueEnumerable<int, ValueEnumerator<int>>
        {
            readonly TestEnumerableWithInterfacelessPublicEnumerator source;

            public TestEnumerableWithInterfacelessPublicEnumeratorAsValueEnumerable(TestEnumerableWithInterfacelessPublicEnumerator source) => this.source = source;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TestEnumerableWithInterfacelessPublicEnumerator.Enumerator GetEnumerator() => source.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            ValueEnumerator<int> IValueEnumerable<int, ValueEnumerator<int>>.GetEnumerator() => new(((IEnumerable<int>)source).GetEnumerator());

            IEnumerator<int> IEnumerable<int>.GetEnumerator() => ((IEnumerable<int>)source).GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<int>)source).GetEnumerator();
        }
    }
}
