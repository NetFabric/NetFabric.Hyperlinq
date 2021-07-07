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
        public static TestEnumerableWithValueTypeEnumeratorAsValueEnumerable AsValueEnumerable(this TestEnumerableWithValueTypeEnumerator source) => new(source);

        public readonly struct TestEnumerableWithValueTypeEnumeratorAsValueEnumerable: IValueEnumerable<int, TestEnumerableWithValueTypeEnumerator.Enumerator>
        {
            readonly TestEnumerableWithValueTypeEnumerator source;

            public TestEnumerableWithValueTypeEnumeratorAsValueEnumerable(TestEnumerableWithValueTypeEnumerator source) => this.source = source;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TestEnumerableWithValueTypeEnumerator.Enumerator GetEnumerator() => source.GetEnumerator();

            IEnumerator<int> IEnumerable<int>.GetEnumerator() => source.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();
        }
    }
}
