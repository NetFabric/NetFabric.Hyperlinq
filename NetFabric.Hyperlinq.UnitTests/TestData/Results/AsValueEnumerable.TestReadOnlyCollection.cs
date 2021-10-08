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
    public static AsValueEnumerable_TestReadOnlyCollection_TestValueType_ AsValueEnumerable(this TestReadOnlyCollection<TestValueType> source)
        => new(source);

    public readonly struct AsValueEnumerable_TestReadOnlyCollection_TestValueType_
        : IValueReadOnlyCollection<TestValueType, TestReadOnlyCollection<TestValueType>.Enumerator>, ICollection<TestValueType>
    {
        readonly TestReadOnlyCollection<TestValueType> source;

        internal AsValueEnumerable_TestReadOnlyCollection_TestValueType_(TestReadOnlyCollection<TestValueType> source)
            => this.source = source;

        // Implement IValueEnumerable<TestValueType, TestReadOnlyCollection<TestValueType>.Enumerator>

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TestReadOnlyCollection<TestValueType>.Enumerator GetEnumerator() => source.GetEnumerator();

        IEnumerator<TestValueType> IEnumerable<TestValueType>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        // Implement ICollection<TestValueType>

        public int Count => source.Count;

        public bool IsReadOnly => true;

        void ICollection<TestValueType>.Add(TestValueType item) => throw new NotSupportedException();

        bool ICollection<TestValueType>.Remove(TestValueType item) => throw new NotSupportedException();

        void ICollection<TestValueType>.Clear() => throw new NotSupportedException();

        public bool Contains(TestValueType item)
        {
            if (Count is 0)
                return false;

            using var enumerator = GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (EqualityComparer<TestValueType>.Default.Equals(enumerator.Current, item))
                    return true;
            }
            return false;
        }

        public void CopyTo(TestValueType[] array, int arrayIndex)
        {
            if (Count is 0)
                return;

            if (array.Length - arrayIndex < Count)
                throw new ArgumentException("Destination array was not long enough. Check the destination index, length, and the array's lower bounds.", nameof(array));

            using var enumerator = GetEnumerator();
            if (arrayIndex is 0 && array.Length == Count)
            {
                for (var index = 0; index < array.Length && enumerator.MoveNext(); index++)
                    array[index] = enumerator.Current;
            }
            else
            {
                checked
                {
                    for (var index = arrayIndex; enumerator.MoveNext(); index++)
                        array[index] = enumerator.Current;
                }
            }
        }
    }
}
