#nullable enable

using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq;

static partial class GeneratedExtensionMethods
{

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static AsValueEnumerable_TestListWithExplicitInterfaces_TestValueType_<TestListWithExplicitInterfaces<TestValueType>> AsValueEnumerable(this TestListWithExplicitInterfaces<TestValueType> source)
        => new(source);

    public readonly struct AsValueEnumerable_TestListWithExplicitInterfaces_TestValueType_<TEnumerable>
        : IValueReadOnlyList<TestValueType, ValueEnumerator<TestValueType>>, IList<TestValueType>
        where TEnumerable : IList<TestValueType>
    {
        readonly TEnumerable source;

        internal AsValueEnumerable_TestListWithExplicitInterfaces_TestValueType_(TEnumerable source)
            => this.source = source;

        // Implement IValueEnumerable<TestValueType, ValueEnumerator<TestValueType>>

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ValueEnumerator<TestValueType> GetEnumerator() => new(source.GetEnumerator());

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

        // Implement IList<TestValueType>

        public TestValueType this[int index] => source[index];

        TestValueType IList<TestValueType>.this[int index]
        {
            get => source[index];
            set => throw new NotSupportedException();
        }

        void IList<TestValueType>.Insert(int index, TestValueType item) => throw new NotSupportedException();

        void IList<TestValueType>.RemoveAt(int index) => throw new NotSupportedException();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int IndexOf(TestValueType item) => source.IndexOf(item);
    }
}
