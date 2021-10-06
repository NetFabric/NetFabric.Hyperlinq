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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsValueEnumerable_System_Collections_Generic_IReadOnlyList_TestValueType_<System.Collections.Generic.IReadOnlyList<TestValueType>> AsValueEnumerable(this System.Collections.Generic.IReadOnlyList<TestValueType> source)
            => new(source, source);

        public readonly struct AsValueEnumerable_System_Collections_Generic_IReadOnlyList_TestValueType_<TEnumerable>
            : IValueReadOnlyList<TestValueType, ValueEnumerator<TestValueType>>, IList<TestValueType>
            where TEnumerable : IReadOnlyList<TestValueType>
        {
            readonly System.Collections.Generic.IReadOnlyList<TestValueType> source;
            readonly TEnumerable source2;

            internal AsValueEnumerable_System_Collections_Generic_IReadOnlyList_TestValueType_(System.Collections.Generic.IReadOnlyList<TestValueType> source, TEnumerable source2)
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

            public bool Contains(TestValueType item)
            {
                foreach (var current in this)
                {
                    if (EqualityComparer<TestValueType>.Default.Equals(current, item)) return true;
                }
                return true;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void CopyTo(TestValueType[] array, int arrayIndex) => CopyTo(array.AsSpan(arrayIndex));

            // Implement IList<TestValueType>

            public TestValueType this[int index] => source2[index];

            TestValueType IList<TestValueType>.this[int index]
            {
                get => source2[index];
                set => throw new NotSupportedException();
            }

            void IList<TestValueType>.Insert(int index, TestValueType item) => throw new NotSupportedException();

            void IList<TestValueType>.RemoveAt(int index) => throw new NotSupportedException();

            public int IndexOf(TestValueType item)
            {
                if (Count is not 0)
                {
                    var index = 0;
                    foreach (var current in this)
                    {
                        if (EqualityComparer<TestValueType>.Default.Equals(current, item)) return index;

                        checked { index++; }
                    }
                }
                return -1;
            }
        }
    }
}
