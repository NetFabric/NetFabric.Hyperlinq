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

        public static AsValueEnumerable_TestReadOnlyCollection_TestValueType_<TestReadOnlyCollection<TestValueType>> AsValueEnumerable(this TestReadOnlyCollection<TestValueType> source)
            => new(source, source);

        public readonly struct AsValueEnumerable_TestReadOnlyCollection_TestValueType_<TEnumerable>
            : IValueReadOnlyCollection<TestValueType, TestReadOnlyCollection<TestValueType>.Enumerator>, ICollection<TestValueType>
            where TEnumerable : IReadOnlyCollection<TestValueType>
        {
            readonly TestReadOnlyCollection<TestValueType> source;
            readonly TEnumerable source2;

            internal AsValueEnumerable_TestReadOnlyCollection_TestValueType_(TestReadOnlyCollection<TestValueType> source, TEnumerable source2)
                => (this.source, this.source2) = (source, source2);

            // Implement IValueEnumerable<TestValueType, TestReadOnlyCollection<TestValueType>.Enumerator>

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TestReadOnlyCollection<TestValueType>.Enumerator GetEnumerator() => source.GetEnumerator();

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
        }
    }
}
