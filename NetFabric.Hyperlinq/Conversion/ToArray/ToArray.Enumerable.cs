using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class EnumerableExtensions
    {
        
        static T[] ToArray<T>(IEnumerable<T> source)
        {
            switch (source)
            {
                case ICollection<T> collection:
                    var count = collection.Count;
                    if (count == 0)
                        return Array.Empty<T>();

                    var buffer = new T[count];
                    collection.CopyTo(buffer, 0);
                    return buffer;

                default:
                    var builder = new LargeArrayBuilder<T>(initialize: true);
                    builder.AddRange(source);
                    return builder.ToArray();
            }
        }
    }
}
