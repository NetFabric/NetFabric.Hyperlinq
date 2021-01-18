using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class DictionaryBindings
    {
        public partial struct ValueWrapper<TKey, TValue>
        {
            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>, System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator, System.Collections.Generic.KeyValuePair<TKey, TValue>, TResult, NetFabric.Hyperlinq.FunctionWrapper<System.Collections.Generic.KeyValuePair<TKey, TValue>, TResult>> Select<TResult>(System.Func<System.Collections.Generic.KeyValuePair<TKey, TValue>, TResult> selector)
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Select<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>, System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator, System.Collections.Generic.KeyValuePair<TKey, TValue>, TResult>(this, selector);

            [GeneratedCode("NetFabric.Hyperlinq.SourceGenerator", "1.0.0")]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly NetFabric.Hyperlinq.ValueEnumerableExtensions.SelectEnumerable<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>, System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator, System.Collections.Generic.KeyValuePair<TKey, TValue>, TResult, TSelector> Select<TResult, TSelector>(TSelector selector = default)
            where TSelector : struct, NetFabric.Hyperlinq.IFunction<System.Collections.Generic.KeyValuePair<TKey, TValue>, TResult>
            => NetFabric.Hyperlinq.ValueEnumerableExtensions.Select<NetFabric.Hyperlinq.DictionaryBindings.ValueWrapper<TKey, TValue>, System.Collections.Generic.Dictionary<TKey, TValue>.Enumerator, System.Collections.Generic.KeyValuePair<TKey, TValue>, TResult, TSelector>(this, selector);

        }

    }
}
