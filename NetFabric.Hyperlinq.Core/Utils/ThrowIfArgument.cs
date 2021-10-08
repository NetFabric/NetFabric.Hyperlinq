using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static class ThrowIfArgument
    {
        // [DebuggerStepThrough]
        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // public static void Null<T>([DoesNotReturnIf()]T paramValue, /*[CallerArgumentExpression("paramValue")]*/ string paramName)
        // {
        //     if (paramValue is null)
        //         Throw.ArgumentNullException(paramName);
        // }

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void OutOfRange(int paramValue, int maxValue, /*[CallerArgumentExpression("paramValue")]*/ string paramName)
        {
            if ((uint)paramValue >= (uint)maxValue)
                Throw.ArgumentOutOfRangeException(paramName);
        }
    }
}