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
        public static TestEnumerableWithReferenceTypeEnumeratorAsValueEnumerable AsValueEnumerable(this TestEnumerableWithReferenceTypeEnumerator source) => new(source);

        public readonly struct TestEnumerableWithReferenceTypeEnumeratorAsValueEnumerable: IValueEnumerable<int, ValueEnumerator<int>>
        {
            readonly TestEnumerableWithReferenceTypeEnumerator source;

            public TestEnumerableWithReferenceTypeEnumeratorAsValueEnumerable(TestEnumerableWithReferenceTypeEnumerator source) => this.source = source;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerator<int> GetEnumerator() => new(source.GetEnumerator());

            IEnumerator<int> IEnumerable<int>.GetEnumerator() => source.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();
        }
    }
}
