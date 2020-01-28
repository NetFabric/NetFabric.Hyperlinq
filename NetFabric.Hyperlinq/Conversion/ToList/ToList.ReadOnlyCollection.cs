using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        static List<T> ToList<T>(IReadOnlyCollection<T> source)
            => source switch
            {
                ICollection<T> collection => new List<T>(collection), // no need to allocate helper class

                _ => new List<T>(new ToListCollection<T>(source)),
            };

        // helper implementation of ICollection<> so that CopyTo() is used to convert to List<>
        [GeneratorIgnore]
        sealed class ToListCollection<TSource>
            : ToListCollectionBase<TSource>
        {
            readonly IReadOnlyCollection<TSource> source;

            public ToListCollection(IReadOnlyCollection<TSource> source)
                : base(source.Count) 
                => this.source = source;

            public override void CopyTo(TSource[] array, int _)
            {
                // List<T> constructor checks if Count is zero
                using var enumerator = source.GetEnumerator();
                checked
                {
                    for (var index = 0; enumerator.MoveNext(); index++)
                        array[index] = enumerator.Current;
                }
            }
        }
    }
}