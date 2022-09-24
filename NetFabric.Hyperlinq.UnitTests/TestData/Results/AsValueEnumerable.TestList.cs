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
    public static AsValueEnumerable_TestList_TestValueType_ AsValueEnumerable(this TestList<TestValueType> source)
        => new(source);

    public readonly struct AsValueEnumerable_TestList_TestValueType_
        : IValueReadOnlyList<TestValueType, TestList<TestValueType>.Enumerator>, IList<TestValueType>
    {
        readonly TestList<TestValueType> source;

        internal AsValueEnumerable_TestList_TestValueType_(TestList<TestValueType> source)
            => this.source = source;

        // Implement IValueEnumerable<TestValueType, TestList<TestValueType>.Enumerator>

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TestList<TestValueType>.Enumerator GetEnumerator() => source.GetEnumerator();

        IEnumerator<TestValueType> IEnumerable<TestValueType>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        // Implement ICollection<TestValueType>

        public int Count => source.Count;

        public bool IsReadOnly => true;

        void ICollection<TestValueType>.Add(TestValueType item) => throw new NotSupportedException();

        bool ICollection<TestValueType>.Remove(TestValueType item) => throw new NotSupportedException();

        void ICollection<TestValueType>.Clear() => throw new NotSupportedException();

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
