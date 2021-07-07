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

        [GeneratedCode("NetFabric.Hyperlinq", "0.0.0")]
        [DebuggerNonUserCode]
        [ExcludeFromCodeCoverage]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is not intended to be used directly by user code")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsValueEnumerable_TestCollection_TestValueType_<TestCollection<TestValueType>> AsValueEnumerable(this TestCollection<TestValueType> source)
            => new(source, source);

        public readonly struct AsValueEnumerable_TestCollection_TestValueType_<TEnumerable>
            : IValueReadOnlyCollection<TestValueType, TestCollection<TestValueType>.Enumerator>, ICollection<TestValueType>
            where TEnumerable : ICollection<TestValueType>
        {
            readonly TestCollection<TestValueType> source;
            readonly TEnumerable source2;

            internal AsValueEnumerable_TestCollection_TestValueType_(TestCollection<TestValueType> source, TEnumerable source2)
                => (this.source, this.source2) = (source, source2);

            // Implement IValueEnumerable<TestValueType, TestCollection<TestValueType>.Enumerator>

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TestCollection<TestValueType>.Enumerator GetEnumerator() => source.GetEnumerator();

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
        }
    }
}
