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

        public static AsValueEnumerable_TestEnumerableWithInterfacelessPublicEnumerator_TestValueType_<TestEnumerableWithInterfacelessPublicEnumerator<TestValueType>> AsValueEnumerable(this TestEnumerableWithInterfacelessPublicEnumerator<TestValueType> source)
            => new(source, source);

        public readonly struct AsValueEnumerable_TestEnumerableWithInterfacelessPublicEnumerator_TestValueType_<TEnumerable>
            : IValueEnumerable<TestValueType, AsValueEnumerable_TestEnumerableWithInterfacelessPublicEnumerator_TestValueType_<TEnumerable>.Enumerator>
            where TEnumerable : IEnumerable<TestValueType>
        {
            readonly TestEnumerableWithInterfacelessPublicEnumerator<TestValueType> source;
            readonly TEnumerable source2;

            internal AsValueEnumerable_TestEnumerableWithInterfacelessPublicEnumerator_TestValueType_(TestEnumerableWithInterfacelessPublicEnumerator<TestValueType> source, TEnumerable source2)
                => (this.source, this.source2) = (source, source2);

            // Implement IValueEnumerable<TestValueType, AsValueEnumerable_TestEnumerableWithInterfacelessPublicEnumerator_TestValueType_<TEnumerable>.Enumerator>

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator GetEnumerator() => new(source.GetEnumerator());

            IEnumerator<TestValueType> IEnumerable<TestValueType>.GetEnumerator() => new Enumerator(source.GetEnumerator());

            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(source.GetEnumerator());

            public struct Enumerator : IEnumerator<TestValueType>
            {
                readonly TestEnumerableWithInterfacelessPublicEnumerator<TestValueType>.Enumerator source;

                internal Enumerator(TestEnumerableWithInterfacelessPublicEnumerator<TestValueType>.Enumerator source)
                    => this.source = source;

                public TestValueType Current => source.Current;

                object? IEnumerator.Current => source.Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool MoveNext() => source.MoveNext();

                public void Reset() => throw new NotSupportedException();

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public void Dispose() { }
            }
        }
    }
}
