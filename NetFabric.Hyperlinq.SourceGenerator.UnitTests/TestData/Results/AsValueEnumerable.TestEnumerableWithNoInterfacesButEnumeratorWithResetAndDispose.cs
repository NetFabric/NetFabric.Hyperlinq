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
        public static TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDisposeAsValueEnumerable AsValueEnumerable(this TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose source) => new(source);

        public readonly struct TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDisposeAsValueEnumerable: IValueEnumerable<int, TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDisposeAsValueEnumerable.Enumerator>
        {
            readonly TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose source;

            public TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDisposeAsValueEnumerable(TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose source) => this.source = source;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose.Enumerator GetEnumerator() => source.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            Enumerator IValueEnumerable<int, Enumerator>.GetEnumerator() => new(source.GetEnumerator());

            IEnumerator<int> IEnumerable<int>.GetEnumerator() => new Enumerator(source.GetEnumerator());

            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(source.GetEnumerator());

            public struct Enumerator: IEnumerator<int>
            {
                readonly TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose.Enumerator source;

                public Enumerator(TestEnumerableWithNoInterfacesButEnumeratorWithResetAndDispose.Enumerator source) => this.source = source;

                public int Current => source.Current;

                object? IEnumerator.Current => source.Current;

                public bool MoveNext() => source.MoveNext();

                public void Reset() => source.Reset();

                public void Dispose() => source.Dispose();
            }
        }
    }
}
