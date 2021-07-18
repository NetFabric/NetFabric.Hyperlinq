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
        public static AsValueEnumerable_TestCollection_TestValueType_ AsValueEnumerable(this TestCollection<TestValueType> source) => new(source);

        public readonly struct AsValueEnumerable_TestCollection_TestValueType_: IValueReadOnlyCollection<TestValueType, TestCollection<TestValueType>.Enumerator>, ICollection<TestValueType>
        {
            readonly TestCollection<TestValueType> source;

            internal AsValueEnumerable_TestCollection_TestValueType_(TestCollection<TestValueType> source) => this.source = source;

            // Implement IValueEnumerable<TestValueType, TestCollection<TestValueType>.Enumerator>

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TestCollection<TestValueType>.Enumerator GetEnumerator() => source.GetEnumerator();

            IEnumerator<TestValueType> IEnumerable<TestValueType>.GetEnumerator() => source.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();

            // Implement ICollection<TestValueType>

            public int Count => source.Count;

            public bool IsReadOnly => true;

            void ICollection<TestValueType>.Add(TestValueType item) => throw new NotSupportedException();

            bool ICollection<TestValueType>.Remove(TestValueType item) => throw new NotSupportedException();

            void ICollection<TestValueType>.Clear() => throw new NotSupportedException();

            public void CopyTo(Span<TestValueType> span)
            {
                if (Count is 0) return;
                if (span.Length < Count) throw new ArgumentException("Destination span was not long enough.", nameof(span));

                var index = 0;
                foreach (var current in this)
                {
                    span[index] = current;
                    checked { index++; }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(TestValueType item) => source.Contains(item);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TestValueType[] array, int arrayIndex) => source.CopyTo(array, arrayIndex);
        }
    }
}
