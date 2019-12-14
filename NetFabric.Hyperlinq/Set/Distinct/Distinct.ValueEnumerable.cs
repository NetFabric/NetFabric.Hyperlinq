using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DistinctEnumerable<TEnumerable, TEnumerator, TSource> Distinct<TEnumerable, TEnumerator, TSource>(
            this TEnumerable source, 
            IEqualityComparer<TSource>? comparer = null)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new DistinctEnumerable<TEnumerable, TEnumerator, TSource>(source, comparer);

        public readonly struct DistinctEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueEnumerable<TSource, DistinctEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly IEqualityComparer<TSource>? comparer;

            internal DistinctEnumerable(TEnumerable source, IEqualityComparer<TSource>? comparer)
            {
                this.source = source;
                this.comparer = comparer;
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IEnumerator<TSource>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                readonly IEqualityComparer<TSource>? comparer;
                EnumeratorState state;
                HashSet<TSource>? set;

                internal Enumerator(in DistinctEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    comparer = enumerable.comparer;
                    state = EnumeratorState.Uninitialized;
                    set = null;
                }

                [MaybeNull]
                public readonly TSource Current
                {
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    get => enumerator.Current;
                }
                readonly object? IEnumerator.Current => enumerator.Current;

                public bool MoveNext()
                {
                    switch (state)
                    {
                        case EnumeratorState.Uninitialized:
                            if (!enumerator.MoveNext())
                            {
                                state = EnumeratorState.Complete;
                                goto case EnumeratorState.Complete;
                            }

                            set = new HashSet<TSource>(comparer)
                            {
                                enumerator.Current
                            };
                            state = EnumeratorState.Enumerating;
                            return true;

                        case EnumeratorState.Enumerating:
                            Debug.Assert(set is object);
                            while (enumerator.MoveNext())
                            {
                                if (set.Add(enumerator.Current))
                                    return true;
                            }

                            Dispose();
                            state = EnumeratorState.Complete;
                            goto case EnumeratorState.Complete;

                        case EnumeratorState.Complete:
                        default:
                            return false;
                    }
                }

                public readonly void Reset() => throw new NotSupportedException();

                public void Dispose()
                {
                    enumerator.Dispose();
                    set?.Clear();
                    set = null;
                }
            }

            // helper function for optimization of non-lazy operations
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly HashSet<TSource> FillSet() 
                => new HashSet<TSource>(source, comparer);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly int Count()
                => FillSet().Count;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly long LongCount()
                => FillSet().Count;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly bool Any()
                => FillSet().Count != 0;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TSource[] ToArray()
                => HashSetBindings.ToArray<TSource>(FillSet());

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly List<TSource> ToList()
                => HashSetBindings.ToList<TSource>(FillSet());
        }
    }
}

