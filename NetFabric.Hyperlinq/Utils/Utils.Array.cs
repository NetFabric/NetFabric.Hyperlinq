using System;
using System.Diagnostics.CodeAnalysis;

namespace NetFabric.Hyperlinq
{
    // Based on https://github.com/dotnet/runtime/blob/4359ebfc9943608b34f411366b1e544ac45702b7/src/libraries/Common/src/System/Collections/Generic/EnumerableHelpers.cs

    static partial class Utils
    {
        public static T[] ToArrayAllocate<T>()
        {
            const int DefaultCapacity = 4;

            return new T[DefaultCapacity];
        }

        public static void ToArrayResize<T>(ref T[] array, int count)
        {
            const int MaxArrayLength = 0x7FEFFFFF;

            var newLength = count << 1;
            if ((uint)newLength > MaxArrayLength)
                newLength = MaxArrayLength <= count 
                    ? count + 1 
                    : MaxArrayLength;

            System.Array.Resize(ref array, newLength);
        }
    }
}