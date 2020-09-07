using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static class BooleanExtensions
    {
        // Based on https://twitter.com/rameel_b/status/1302632990737080321
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte AsByte(this bool value)
            => Unsafe.As<bool, byte>(ref value);
    }
}
