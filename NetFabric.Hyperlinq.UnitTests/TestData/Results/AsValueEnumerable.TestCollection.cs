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
    public static AsValueEnumerable_TestCollection_TestValueType_ AsValueEnumerable(this TestCollection<TestValueType> source)
        => new(source);

    public readonly struct AsValueEnumerable_TestCollection_TestValueType_
        : IValueReadOnlyCollection<TestValueType, TestCollection<TestValueType>.Enumerator>, ICollection<TestValueType>
    {
        readonly TestCollection<TestValueType> source;

        internal AsValueEnumerable_TestCollection_TestValueType_(TestCollection<TestValueType> source)
            => this.source = source;

        // Implement IValueEnumerable<TestValueType, TestCollection<TestValueType>.Enumerator>

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TestCollection<TestValueType>.Enumerator GetEnumerator() => source.GetEnumerator();

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
    }
}
