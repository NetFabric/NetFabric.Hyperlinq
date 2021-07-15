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
        public static TestListAsValueEnumerable AsValueEnumerable(this TestList source) => new(source);

        public readonly struct TestListAsValueEnumerable: IValueReadOnlyList<int, TestList.Enumerator>, IList<int>
        {
            readonly TestList source;

            public TestListAsValueEnumerable(TestList source) => this.source = source;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TestList.Enumerator GetEnumerator() => source.GetEnumerator();

            IEnumerator<int> IEnumerable<int>.GetEnumerator() => source.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();

            public int Count => source.Count;

            public bool IsReadOnly => true;

            void ICollection<int>.Add(int item) => throw new NotSupportedException();

            bool ICollection<int>.Remove(int item) => throw new NotSupportedException();

            void ICollection<int>.Clear() => throw new NotSupportedException();

            public bool Contains(int item) => source.Contains(item);

            public void CopyTo(int[] array, int arrayIndex) => source.CopyTo(array, arrayIndex);

            public int this[int index] => source[index];

            int IList<int>.this[int index]
            {
                get => source[index];
                set => throw new NotSupportedException();
            }

            void IList<int>.Insert(int index, int item) => throw new NotSupportedException();

            void IList<int>.RemoveAt(int index) => throw new NotSupportedException();

            public int IndexOf(int item) => source.IndexOf(item);
        }
    }
}
