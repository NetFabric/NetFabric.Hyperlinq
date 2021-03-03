using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static class GenericsOperator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue Add<TValue>(TValue a, TValue b)
            where TValue : struct
        {
            if (typeof(TValue) == typeof(byte))
                return (TValue)(object)((byte)(object)a + (byte)(object)b);

            if (typeof(TValue) == typeof(sbyte))
                return (TValue)(object)((sbyte)(object)a + (sbyte)(object)b);

            if (typeof(TValue) == typeof(ushort))
                return (TValue)(object)((ushort)(object)a + (ushort)(object)b);

            if (typeof(TValue) == typeof(short))
                return (TValue)(object)((short)(object)a + (short)(object)b);

            if (typeof(TValue) == typeof(uint))
                return (TValue)(object)((uint)(object)a + (uint)(object)b);

            if (typeof(TValue) == typeof(int))
                return (TValue)(object)((int)(object)a + (int)(object)b);

            if (typeof(TValue) == typeof(ulong))
                return (TValue)(object)((ulong)(object)a + (ulong)(object)b);

            if (typeof(TValue) == typeof(long))
                return (TValue)(object)((long)(object)a + (long)(object)b);

            if (typeof(TValue) == typeof(float))
                return (TValue)(object)((float)(object)a + (float)(object)b);

            if (typeof(TValue) == typeof(double))
                return (TValue)(object)((double)(object)a + (double)(object)b);

            return Throw.NotSupportedException<TValue>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue AddNullable<TNullableValue, TValue>(TNullableValue a, TValue b)
            where TValue : struct
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.

            if (typeof(TNullableValue) == typeof(int?) && typeof(TValue) == typeof(int))
                return (TValue)(object)(((int?)(object)a).GetValueOrDefault() + (int)(object)b);

            if (typeof(TNullableValue) == typeof(int) && typeof(TValue) == typeof(int))
                return (TValue)(object)((int)(object)a! + (int)(object)b);

            if (typeof(TNullableValue) == typeof(long?) && typeof(TValue) == typeof(long))
                return (TValue)(object)(((long?)(object)a).GetValueOrDefault() + (long)(object)b);

            if (typeof(TNullableValue) == typeof(long) && typeof(TValue) == typeof(long))
                return (TValue)(object)((long)(object)a! + (long)(object)b);

            if (typeof(TNullableValue) == typeof(float?) && typeof(TValue) == typeof(float))
                return (TValue)(object)(((float?)(object)a).GetValueOrDefault() + (float)(object)b);

            if (typeof(TNullableValue) == typeof(float) && typeof(TValue) == typeof(float))
                return (TValue)(object)((float)(object)a! + (float)(object)b);

            if (typeof(TNullableValue) == typeof(double?) && typeof(TValue) == typeof(double))
                return (TValue)(object)(((double?)(object)a).GetValueOrDefault() + (double)(object)b);

            if (typeof(TNullableValue) == typeof(double) && typeof(TValue) == typeof(double))
                return (TValue)(object)((double)(object)a! + (double)(object)b);

            if (typeof(TNullableValue) == typeof(decimal?) && typeof(TValue) == typeof(decimal))
                return (TValue)(object)(((decimal?)(object)a).GetValueOrDefault() + (decimal)(object)b);

            if (typeof(TNullableValue) == typeof(decimal) && typeof(TValue) == typeof(decimal))
                return (TValue)(object)((decimal)(object)a! + (decimal)(object)b);
                
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return Throw.NotSupportedException<TValue>();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals<TValue>(TValue a, TValue b)
            where TValue : struct
        {
            if (typeof(TValue) == typeof(byte))
                return (byte)(object)a == (byte)(object)b;

            if (typeof(TValue) == typeof(sbyte))
                return (sbyte)(object)a == (sbyte)(object)b;

            if (typeof(TValue) == typeof(ushort))
                return (ushort)(object)a == (ushort)(object)b;

            if (typeof(TValue) == typeof(short))
                return (short)(object)a == (short)(object)b;

            if (typeof(TValue) == typeof(uint))
                return (uint)(object)a == (uint)(object)b;

            if (typeof(TValue) == typeof(int))
                return (int)(object)a == (int)(object)b;

            if (typeof(TValue) == typeof(ulong))
                return (ulong)(object)a == (ulong)(object)b;

            if (typeof(TValue) == typeof(long))
                return (long)(object)a == (long)(object)b;

            if (typeof(TValue) == typeof(float))
                return (float)(object)a == (float)(object)b;

            if (typeof(TValue) == typeof(double))
                return (double)(object)a == (double)(object)b;

            return Throw.NotSupportedException<bool>();
        }
    }
}
