using System.Numerics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static class VectorExtensions
    {
        public static T Sum<T>(this Vector<T> vector)
            where T : struct
        {
            ref var item = ref Unsafe.As<Vector<T>, T>(ref Unsafe.AsRef(in vector));
            var sum = default(T);
            for (var index = 0; index < Vector<T>.Count; index++)
                sum = Scalar.Add(Unsafe.Add(ref item, index), sum);
            return sum;
        }
    }
}