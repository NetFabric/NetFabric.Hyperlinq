using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Wrap
    {
        public static FunctionIn<T, TResult> AsFunctionIn<T, TResult>(Func<T, TResult> source)
            => (in T arg) => source(arg);

        public static FunctionIn<T1, T2, TResult> AsFunctionIn<T1, T2, TResult>(Func<T1, T2, TResult> source)
            => (in T1 arg1, T2 arg2) => source(arg1, arg2);

    }
}