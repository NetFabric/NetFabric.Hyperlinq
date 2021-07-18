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
        public static TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose_TestValueType__AsValueEnumerable AsValueEnumerable(this TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose<TestValueType> source) => new(source);

        public readonly struct TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose_TestValueType__AsValueEnumerable: IValueEnumerable<TestValueType, TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose_TestValueType__AsValueEnumerable.Enumerator>
        {
            readonly TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose<TestValueType> source;

            internal TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose_TestValueType__AsValueEnumerable(TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose<TestValueType> source) => this.source = source;

            // Implement IValueEnumerable<TestValueType, TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose_TestValueType__AsValueEnumerable.Enumerator>

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose<TestValueType>.Enumerator GetEnumerator() => source.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            Enumerator IValueEnumerable<TestValueType, Enumerator>.GetEnumerator() => new(source.GetEnumerator());

            IEnumerator<TestValueType> IEnumerable<TestValueType>.GetEnumerator() => new Enumerator(source.GetEnumerator());

            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(source.GetEnumerator());

            public struct Enumerator: IEnumerator<TestValueType>
            {
                readonly TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose<TestValueType>.Enumerator source;

                internal Enumerator(TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose<TestValueType>.Enumerator source) => this.source = source;

                public TestValueType Current => source.Current;

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
}
