using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        public static int Count<TSource>(this EmptyReadOnlyList<TSource> _) => 0;
    }
}

