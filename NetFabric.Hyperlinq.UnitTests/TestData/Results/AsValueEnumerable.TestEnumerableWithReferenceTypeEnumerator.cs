#nullable enable

using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class GeneratedExtensionMethods
    {

        [GeneratedCode("NetFabric.Hyperlinq", "0.0.0")]
        [DebuggerNonUserCode]
        [ExcludeFromCodeCoverage]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is not intended to be used directly by user code")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsValueEnumerable_TestEnumerableWithReferenceTypeEnumerator_TestValueType_<TestEnumerableWithReferenceTypeEnumerator<TestValueType>> AsValueEnumerable(this TestEnumerableWithReferenceTypeEnumerator<TestValueType> source)
            => new(source, source);

        public readonly struct AsValueEnumerable_TestEnumerableWithReferenceTypeEnumerator_TestValueType_<TEnumerable>
            : IValueEnumerable<TestValueType, ValueEnumerator<TestValueType>>
            where TEnumerable : IEnumerable<TestValueType>
        {
            readonly TestEnumerableWithReferenceTypeEnumerator<TestValueType> source;
            readonly TEnumerable source2;

            internal AsValueEnumerable_TestEnumerableWithReferenceTypeEnumerator_TestValueType_(TestEnumerableWithReferenceTypeEnumerator<TestValueType> source, TEnumerable source2)
                => (this.source, this.source2) = (source, source2);

            // Implement IValueEnumerable<TestValueType, ValueEnumerator<TestValueType>>

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerator<TestValueType> GetEnumerator() => new(source.GetEnumerator());

            IEnumerator<TestValueType> IEnumerable<TestValueType>.GetEnumerator() => source2.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => source2.GetEnumerator();
        }
    }
}
