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
        public static TestCollectionAsValueEnumerable AsValueEnumerable(this TestCollection source) => new(source);

        public readonly struct TestCollectionAsValueEnumerable: IValueReadOnlyCollection<int, TestCollection.Enumerator>, ICollection<int>
        {
            readonly TestCollection source;

            public TestCollectionAsValueEnumerable(TestCollection source) => this.source = source;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TestCollection.Enumerator GetEnumerator() => source.GetEnumerator();

            IEnumerator<int> IEnumerable<int>.GetEnumerator() => source.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();

            public int Count => source.Count;

            public bool IsReadOnly => true;

            void ICollection<int>.Add(int item) => throw new NotSupportedException();

            bool ICollection<int>.Remove(int item) => throw new NotSupportedException();

            void ICollection<int>.Clear() => throw new NotSupportedException();

            public bool Contains(int item) => source.Contains(item);

            public void CopyTo(int[] array, int arrayIndex) => source.CopyTo(array, arrayIndex);
        }
    }
}
