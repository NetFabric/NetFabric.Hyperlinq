using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        
        static T[] ToArray<T>(IReadOnlyCollection<T> source)
        {
            var array = new T[source.Count];
            if (source.Count != 0)
            {
                switch (source)
                {
                    case ICollection<T> collection:
                        collection.CopyTo(array, 0);
                        break;
                        
                    default:
                        {
                            using var enumerator = source.GetEnumerator();
                            checked
                            {
                                for (var index = 0; enumerator.MoveNext(); index++)
                                    array[index] = enumerator.Current;
                            }
                        }
                        break;
                }
            }
            return array;
        }
    }
}