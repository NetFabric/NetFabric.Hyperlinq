using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> SkipTake<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int skipCount, int takeCount)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>(in source, skipCount, takeCount);

        public readonly partial struct SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueReadOnlyCollection<TSource, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            , ICollection<TSource>
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly int skipCount;

            internal SkipTakeEnumerable(in TEnumerable source, int skipCount, int takeCount)
            {
                this.source = source;
                (this.skipCount, Count) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            public readonly int Count { get; }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(in this);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);

            bool ICollection<TSource>.IsReadOnly  
                => true;

            void ICollection<TSource>.CopyTo(TSource[] array, int arrayIndex) 
            {
                if (Count == 0)
                    return;

                using var enumerator = source.GetEnumerator();

                // skip
                for (var counter = 0; counter < skipCount; counter++)
                {
                    if (!enumerator.MoveNext()) Throw.InvalidOperationException();
                }

                // take
                for (var counter = 0; counter < Count; counter++)
                {
                    if (!enumerator.MoveNext()) Throw.InvalidOperationException();

                    array[arrayIndex] = enumerator.Current;
                    arrayIndex++;
                }
            }

            void ICollection<TSource>.Add(TSource item) 
                => Throw.NotSupportedException();
            void ICollection<TSource>.Clear() 
                => Throw.NotSupportedException();
            bool ICollection<TSource>.Contains(TSource item)
                => ValueReadOnlyCollection.Contains<TEnumerable, TEnumerator, TSource>(source, item);
            bool ICollection<TSource>.Remove(TSource item) 
                => Throw.NotSupportedException<bool>();

            public struct Enumerator
                : IEnumerator<TSource>
            {
                [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
                TEnumerator enumerator; // do not make readonly
                EnumeratorState state;
                int skipCounter;
                int takeCounter;

                internal Enumerator(in SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    enumerator = enumerable.source.GetEnumerator();
                    skipCounter = enumerable.skipCount;
                    takeCounter = enumerable.Count;
                    state = takeCounter > 0 ? EnumeratorState.Uninitialized : EnumeratorState.Complete;
                }

                [MaybeNull]
                public readonly TSource Current
                    => enumerator.Current;
                readonly TSource IEnumerator<TSource>.Current 
                    => enumerator.Current;
                readonly object? IEnumerator.Current 
                    => enumerator.Current;

                public bool MoveNext()
                {
                    switch (state)
                    {
                        case EnumeratorState.Uninitialized:
                            while (skipCounter > 0)
                            {
                                if (enumerator.MoveNext())
                                {
                                    skipCounter--;
                                }
                                else
                                {
                                    state = EnumeratorState.Complete;
                                    goto case EnumeratorState.Complete;
                                }
                            }                
                            state = EnumeratorState.Enumerating;
                            goto case EnumeratorState.Enumerating;
                            
                        case EnumeratorState.Enumerating:
                            if (enumerator.MoveNext())
                            {
                                takeCounter--;
                                if (takeCounter == 0)
                                    state = EnumeratorState.Complete;

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

                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => Throw.NotSupportedException();

                public void Dispose() => enumerator.Dispose();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Take(int count)
                => ValueReadOnlyCollection.SkipTake<TEnumerable, TEnumerator, TSource>(source, skipCount, Math.Min(Count, count));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => source.Count;
    }
}