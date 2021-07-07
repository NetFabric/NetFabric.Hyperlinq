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
        public static TestEnumerableWithNoInterfacesAsValueEnumerable AsValueEnumerable(this TestEnumerableWithNoInterfaces source) => new(source);

        public readonly struct TestEnumerableWithNoInterfacesAsValueEnumerable: IValueEnumerable<int, TestEnumerableWithNoInterfacesAsValueEnumerable.Enumerator>
        {
            readonly TestEnumerableWithNoInterfaces source;

            public TestEnumerableWithNoInterfacesAsValueEnumerable(TestEnumerableWithNoInterfaces source) => this.source = source;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TestEnumerableWithNoInterfaces.Enumerator GetEnumerator() => source.GetEnumerator();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            Enumerator IValueEnumerable<int, Enumerator>.GetEnumerator() => new(source.GetEnumerator());

            IEnumerator<int> IEnumerable<int>.GetEnumerator() => new Enumerator(source.GetEnumerator());

            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(source.GetEnumerator());

            public struct Enumerator: IEnumerator<int>
            {
                readonly TestEnumerableWithNoInterfaces.Enumerator source;

                public Enumerator(TestEnumerableWithNoInterfaces.Enumerator source) => this.source = source;

                public int Current => source.Current;

                object? IEnumerator.Current => source.Current;

                public bool MoveNext() => source.MoveNext();

                public void Reset() => throw new NotSupportedException();

                public void Dispose() { }
            }
        }
    }
}
