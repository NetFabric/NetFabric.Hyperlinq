using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static class GenericsOperator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Add<T>(T a, T b)
            where T : struct
        {
            if (typeof(T) == typeof(byte))
                return (T)(object)((byte)(object)a + (byte)(object)b);

            if (typeof(T) == typeof(sbyte))
                return (T)(object)((sbyte)(object)a + (sbyte)(object)b);

            if (typeof(T) == typeof(ushort))
                return (T)(object)((ushort)(object)a + (ushort)(object)b);

            if (typeof(T) == typeof(short))
                return (T)(object)((short)(object)a + (short)(object)b);

            if (typeof(T) == typeof(uint))
                return (T)(object)((uint)(object)a + (uint)(object)b);

            if (typeof(T) == typeof(int))
                return (T)(object)((int)(object)a + (int)(object)b);

            if (typeof(T) == typeof(ulong))
                return (T)(object)((ulong)(object)a + (ulong)(object)b);

            if (typeof(T) == typeof(long))
                return (T)(object)((long)(object)a + (long)(object)b);

            if (typeof(T) == typeof(float))
                return (T)(object)((float)(object)a + (float)(object)b);

            if (typeof(T) == typeof(double))
                return (T)(object)((double)(object)a + (double)(object)b);

            return Throw.NotSupportedException<T>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSum Sum<TSource, TSum>(TSource a, TSum b)
        {
            if (typeof(TSource) == typeof(int?) && typeof(TSum) == typeof(int))
                return (TSum)(object)((int)(object)((int?)(object)a).GetValueOrDefault() + (int)(object)b);

            if (typeof(TSource) == typeof(int) && typeof(TSum) == typeof(int))
                return (TSum)(object)((int)(object)a + (int)(object)b);

            if (typeof(TSource) == typeof(long?) && typeof(TSum) == typeof(long))
                return (TSum)(object)((long)(object)((long?)(object)a).GetValueOrDefault() + (long)(object)b);

            if (typeof(TSource) == typeof(long) && typeof(TSum) == typeof(long))
                return (TSum)(object)((long)(object)a + (long)(object)b);

            if (typeof(TSource) == typeof(float?) && typeof(TSum) == typeof(float))
                return (TSum)(object)((float)(object)((float?)(object)a).GetValueOrDefault() + (float)(object)b);

            if (typeof(TSource) == typeof(float) && typeof(TSum) == typeof(float))
                return (TSum)(object)((float)(object)a + (float)(object)b);

            if (typeof(TSource) == typeof(double?) && typeof(TSum) == typeof(double))
                return (TSum)(object)((double)(object)((double?)(object)a).GetValueOrDefault() + (double)(object)b);

            if (typeof(TSource) == typeof(double) && typeof(TSum) == typeof(double))
                return (TSum)(object)((double)(object)a + (double)(object)b);

            if (typeof(TSource) == typeof(decimal?) && typeof(TSum) == typeof(decimal))
                return (TSum)(object)((decimal)(object)((decimal?)(object)a).GetValueOrDefault() + (decimal)(object)b);

            if (typeof(TSource) == typeof(decimal) && typeof(TSum) == typeof(decimal))
                return (TSum)(object)((decimal)(object)a + (decimal)(object)b);

            return Throw.NotSupportedException<TSum>();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals<T>(T a, T b)
            where T : struct
        {
            if (typeof(T) == typeof(byte))
                return (byte)(object)a == (byte)(object)b;

            if (typeof(T) == typeof(sbyte))
                return (sbyte)(object)a == (sbyte)(object)b;

            if (typeof(T) == typeof(ushort))
                return (ushort)(object)a == (ushort)(object)b;

            if (typeof(T) == typeof(short))
                return (short)(object)a == (short)(object)b;

            if (typeof(T) == typeof(uint))
                return (uint)(object)a == (uint)(object)b;

            if (typeof(T) == typeof(int))
                return (int)(object)a == (int)(object)b;

            if (typeof(T) == typeof(ulong))
                return (ulong)(object)a == (ulong)(object)b;

            if (typeof(T) == typeof(long))
                return (long)(object)a == (long)(object)b;

            if (typeof(T) == typeof(float))
                return (float)(object)a == (float)(object)b;

            if (typeof(T) == typeof(double))
                return (double)(object)a == (double)(object)b;

            return Throw.NotSupportedException<bool>();
        }
    }
}
