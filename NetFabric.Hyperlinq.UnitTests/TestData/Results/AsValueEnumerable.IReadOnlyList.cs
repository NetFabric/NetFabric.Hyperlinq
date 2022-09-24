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
    public static AsValueEnumerable_System_Collections_Generic_IReadOnlyList_TestValueType_ AsValueEnumerable(this System.Collections.Generic.IReadOnlyList<TestValueType> source)
        => new(source);

    public readonly struct AsValueEnumerable_System_Collections_Generic_IReadOnlyList_TestValueType_
        : IValueReadOnlyList<TestValueType, ValueEnumerator<TestValueType>>, IList<TestValueType>
    {
        readonly System.Collections.Generic.IReadOnlyList<TestValueType> source;

        internal AsValueEnumerable_System_Collections_Generic_IReadOnlyList_TestValueType_(System.Collections.Generic.IReadOnlyList<TestValueType> source)
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

        public bool Contains(TestValueType item)
        {
            if (Count is 0)
                return false;

            if (source is ICollection<TestValueType> collection)
                return collection.Contains(item);

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

            if (source is ICollection<TestValueType> collection)
            {
                collection.CopyTo(array, arrayIndex);
                return;
            }

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

        // Implement IList<TestValueType>

        public TestValueType this[int index] => source[index];

        TestValueType IList<TestValueType>.this[int index]
        {
            get => source[index];
            set => throw new NotSupportedException();
        }

        void IList<TestValueType>.Insert(int index, TestValueType item) => throw new NotSupportedException();

        void IList<TestValueType>.RemoveAt(int index) => throw new NotSupportedException();

        public int IndexOf(TestValueType item)
        {
            if (Count is not 0)
            {
                if (source is IList<TestValueType> list)
                    return list.IndexOf(item);

                checked
                {
                    var index = 0;
                    foreach (var current in source)
                    {
                        if (EqualityComparer<TestValueType>.Default.Equals(current, item))
                            return index;

                        index++;
                    }
                }
            }
            return -1;
        }
    }
}
