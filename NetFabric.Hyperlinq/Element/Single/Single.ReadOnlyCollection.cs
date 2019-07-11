using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            => TrySingle<TEnumerable, TEnumerator, TSource>(source).ThrowOnEmpty();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            => TrySingle<TEnumerable, TEnumerator, TSource>(source).DefaultOnEmpty();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            => TrySingle<TEnumerable, TEnumerator, TSource>(source, predicate).ThrowOnEmpty();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
            => TrySingle<TEnumerable, TEnumerator, TSource>(source, predicate).DefaultOnEmpty();

        public static (ElementResult Success, TSource Value) TrySingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            switch (source.Count)
            {
                case 0:
                    return (ElementResult.Empty, default);
                case 1:
                    using (var enumerator = (TEnumerator)source.GetEnumerator())
                    {
                        enumerator.MoveNext();
                        return (ElementResult.Success, enumerator.Current);
                    }  
                default:  
                    return (ElementResult.NotSingle, default);
            }
        }

        public static (ElementResult Success, TSource Value) TrySingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source.Count != 0)
            {
                using (var enumerator = (TEnumerator)source.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        if (predicate(enumerator.Current))
                        {
                            var value = enumerator.Current;
                            
                            // found first, keep going until end or find second
                            while (enumerator.MoveNext())
                            {
                                if (predicate(enumerator.Current))
                                    return (ElementResult.NotSingle, default);
                            }

                            return (ElementResult.Success, value);
                        }
                    }
                }   
            }   

            return (ElementResult.Empty, default);
        }

        public static (int Index, TSource Value) TrySingle<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate) 
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source.Count != 0)
            {
                using (var enumerator = (TEnumerator)source.GetEnumerator())
                {
                    checked
                    {
                        for (var index = 0; enumerator.MoveNext(); index++)
                        {
                            if (predicate(enumerator.Current, index))
                            {
                                var value = (index, enumerator.Current);

                                // found first, keep going until end or find second
                                for (index++; enumerator.MoveNext(); index++)
                                {
                                    if (predicate(enumerator.Current, index))
                                        return ((int)ElementResult.NotSingle, default);
                                }

                                return value;
                            }
                        }
                    }
                }   
            }   

            return ((int)ElementResult.Empty, default);
        }
    }
}