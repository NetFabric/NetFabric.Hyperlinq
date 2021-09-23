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

        public static AsValueEnumerable_TestListWithExplicitInterfaces_TestValueType_<TestListWithExplicitInterfaces<TestValueType>> AsValueEnumerable(this TestListWithExplicitInterfaces<TestValueType> source)
            => new(source, source);

        public readonly struct AsValueEnumerable_TestListWithExplicitInterfaces_TestValueType_<TEnumerable>
            : IValueReadOnlyList<TestValueType, ValueEnumerator<TestValueType>>, IList<TestValueType>
            where TEnumerable : IList<TestValueType>
        {
            readonly TestListWithExplicitInterfaces<TestValueType> source;
            readonly TEnumerable source2;

            internal AsValueEnumerable_TestListWithExplicitInterfaces_TestValueType_(TestListWithExplicitInterfaces<TestValueType> source, TEnumerable source2)
                => (this.source, this.source2) = (source, source2);

            // Implement IValueEnumerable<TestValueType, ValueEnumerator<TestValueType>>

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ValueEnumerator<TestValueType> GetEnumerator() => new(source2.GetEnumerator());

            IEnumerator<TestValueType> IEnumerable<TestValueType>.GetEnumerator() => source2.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => source2.GetEnumerator();

            // Implement ICollection<TestValueType>

            public int Count => source2.Count;

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
            public bool Contains(TestValueType item) => source2.Contains(item);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TestValueType[] array, int arrayIndex) => source2.CopyTo(array, arrayIndex);

            // Implement IList<TestValueType>

            public TestValueType this[int index] => source2[index];

            TestValueType IList<TestValueType>.this[int index]
            {
                get => source2[index];
                set => throw new NotSupportedException();
            }

            void IList<TestValueType>.Insert(int index, TestValueType item) => throw new NotSupportedException();

            void IList<TestValueType>.RemoveAt(int index) => throw new NotSupportedException();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int IndexOf(TestValueType item) => source2.IndexOf(item);
        }
    }
}
