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
        public static NetFabric.Hyperlinq.ValueReadOnlyCollectionExtensions.WhereEnumerable<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentValueEnumerable<TestValueType>, NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentValueEnumerable<TestValueType>.DisposableEnumerator, TestValueType, NetFabric.Hyperlinq.FunctionWrapper<TestValueType, bool>> Where(this NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentValueEnumerable<TestValueType> source, System.Func<TestValueType, bool> selector)
            => NetFabric.Hyperlinq.ValueReadOnlyListExtensions.Where<NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentValueEnumerable<TestValueType>, NetFabric.Hyperlinq.ArrayExtensions.ArraySegmentValueEnumerable<TestValueType>.DisposableEnumerator, TestValueType>(source, selector);
    }
}
