using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static class Scalar
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue Add<TNullableValue, TValue>(TNullableValue a, TValue b)
            where TValue : struct
        {
            if (typeof(TNullableValue) == typeof(int?) && typeof(TValue) == typeof(int))
                return (TValue)(object)(((int?)(object?)a).GetValueOrDefault() + (int)(object)b);

            if (typeof(TNullableValue) == typeof(int) && typeof(TValue) == typeof(int))
                return (TValue)(object)((int)(object)a! + (int)(object)b);

            if (typeof(TNullableValue) == typeof(uint?) && typeof(TValue) == typeof(uint))
                return (TValue)(object)(((uint?)(object?)a).GetValueOrDefault() + (uint)(object)b);

            if (typeof(TNullableValue) == typeof(uint) && typeof(TValue) == typeof(uint))
                return (TValue)(object)((uint)(object)a! + (uint)(object)b);
            
            if (typeof(TNullableValue) == typeof(nint?) && typeof(TValue) == typeof(nint))
                return (TValue)(object)(((nint?)(object?)a).GetValueOrDefault() + (nint)(object)b);

            if (typeof(TNullableValue) == typeof(nint) && typeof(TValue) == typeof(nint))
                return (TValue)(object)((nint)(object)a! + (nint)(object)b);

            if (typeof(TNullableValue) == typeof(nuint?) && typeof(TValue) == typeof(nuint))
                return (TValue)(object)(((nuint?)(object?)a).GetValueOrDefault() + (nuint)(object)b);

            if (typeof(TNullableValue) == typeof(nuint) && typeof(TValue) == typeof(nuint))
                return (TValue)(object)((nuint)(object)a! + (nuint)(object)b);

            if (typeof(TNullableValue) == typeof(long?) && typeof(TValue) == typeof(long))
                return (TValue)(object)(((long?)(object?)a).GetValueOrDefault() + (long)(object)b);

            if (typeof(TNullableValue) == typeof(long) && typeof(TValue) == typeof(long))
                return (TValue)(object)((long)(object)a! + (long)(object)b);

            if (typeof(TNullableValue) == typeof(float?) && typeof(TValue) == typeof(float))
                return (TValue)(object)(((float?)(object?)a).GetValueOrDefault() + (float)(object)b);

            if (typeof(TNullableValue) == typeof(float) && typeof(TValue) == typeof(float))
                return (TValue)(object)((float)(object)a! + (float)(object)b);

            if (typeof(TNullableValue) == typeof(double?) && typeof(TValue) == typeof(double))
                return (TValue)(object)(((double?)(object?)a).GetValueOrDefault() + (double)(object)b);

            if (typeof(TNullableValue) == typeof(double) && typeof(TValue) == typeof(double))
                return (TValue)(object)((double)(object)a! + (double)(object)b);

            if (typeof(TNullableValue) == typeof(decimal?) && typeof(TValue) == typeof(decimal))
                return (TValue)(object)(((decimal?)(object?)a).GetValueOrDefault() + (decimal)(object)b);

            if (typeof(TNullableValue) == typeof(decimal) && typeof(TValue) == typeof(decimal))
                return (TValue)(object)((decimal)(object)a! + (decimal)(object)b);

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

            if (typeof(TValue) == typeof(short))
                return (short)(object)a == (short)(object)b;

            if (typeof(TValue) == typeof(ushort))
                return (ushort)(object)a == (ushort)(object)b;

            if (typeof(TValue) == typeof(int))
                return (int)(object)a == (int)(object)b;

            if (typeof(TValue) == typeof(uint))
                return (uint)(object)a == (uint)(object)b;

            if (typeof(TValue) == typeof(long))
                return (long)(object)a == (long)(object)b;

            if (typeof(TValue) == typeof(ulong))
                return (ulong)(object)a == (ulong)(object)b;

            if (typeof(TValue) == typeof(float))
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                return (float)(object)a == (float)(object)b;

            if (typeof(TValue) == typeof(double))
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                return (double)(object)a == (double)(object)b;

            if (typeof(TValue) == typeof(decimal))
                return (decimal)(object)a == (decimal)(object)b;

            return Throw.NotSupportedException<bool>();
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue GetValueOrDefault<TValue, TPredicate>(TPredicate predicate, TValue value)
            where TPredicate : struct, IFunction<TValue, bool>
        {
            if (typeof(TValue) == typeof(int?))
                return (TValue)(object)(predicate.Invoke(value).AsByte() * ((int?)(object?)value).GetValueOrDefault());

            if (typeof(TValue) == typeof(int))
                return (TValue)(object)(predicate.Invoke(value).AsByte() * (int)(object)value!);

            if (typeof(TValue) == typeof(uint?))
                return (TValue)(object)(predicate.Invoke(value).AsByte() * ((uint?)(object?)value).GetValueOrDefault());

            if (typeof(TValue) == typeof(uint))
                return (TValue)(object)(predicate.Invoke(value).AsByte() * (uint)(object)value!);

            if (typeof(TValue) == typeof(nint?))
                return (TValue)(object)(predicate.Invoke(value).AsByte() * ((nint?)(object?)value).GetValueOrDefault());

            if (typeof(TValue) == typeof(nint))
                return (TValue)(object)(predicate.Invoke(value).AsByte() * (nint)(object)value!);

            if (typeof(TValue) == typeof(nuint?))
                return (TValue)(object)(predicate.Invoke(value).AsByte() * ((nuint?)(object?)value).GetValueOrDefault());

            if (typeof(TValue) == typeof(nuint))
                return (TValue)(object)(predicate.Invoke(value).AsByte() * (nuint)(object)value!);

            if (typeof(TValue) == typeof(long?))
                return (TValue)(object)(predicate.Invoke(value).AsByte() * ((long?)(object?)value).GetValueOrDefault());

            if (typeof(TValue) == typeof(long))
                return (TValue)(object)(predicate.Invoke(value).AsByte() * (long)(object)value!);

            if (typeof(TValue) == typeof(ulong?))
                return (TValue)(object)(predicate.Invoke(value).AsByte() * ((ulong?)(object?)value).GetValueOrDefault());

            if (typeof(TValue) == typeof(ulong))
                return (TValue)(object)(predicate.Invoke(value).AsByte() * (ulong)(object)value!);

            if (typeof(TValue) == typeof(float?))
                return (TValue)(object)(predicate.Invoke(value).AsByte() * ((float?)(object?)value).GetValueOrDefault());

            if (typeof(TValue) == typeof(float))
                return (TValue)(object)(predicate.Invoke(value).AsByte() * (float)(object)value!);

            if (typeof(TValue) == typeof(double?))
                return (TValue)(object)(predicate.Invoke(value).AsByte() * ((double?)(object?)value).GetValueOrDefault());

            if (typeof(TValue) == typeof(double))
                return (TValue)(object)(predicate.Invoke(value).AsByte() * (double)(object)value!);

            if (typeof(TValue) == typeof(decimal?))
                return (TValue)(object)(predicate.Invoke(value).AsByte() * ((decimal?)(object?)value).GetValueOrDefault());

            if (typeof(TValue) == typeof(decimal))
                return (TValue)(object)(predicate.Invoke(value).AsByte() * (decimal)(object)value!);

            return Throw.NotSupportedException<TValue>();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue GetValueOrDefault<TValue, TPredicate>(TPredicate predicate, TValue value, int index)
            where TPredicate : struct, IFunction<TValue, int, bool>
        {
            if (typeof(TValue) == typeof(int?))
                return (TValue)(object)(predicate.Invoke(value, index).AsByte() * ((int?)(object?)value).GetValueOrDefault());

            if (typeof(TValue) == typeof(int))
                return (TValue)(object)(predicate.Invoke(value, index).AsByte() * (int)(object)value!);

            if (typeof(TValue) == typeof(uint?))
                return (TValue)(object)(predicate.Invoke(value, index).AsByte() * ((uint?)(object?)value).GetValueOrDefault());

            if (typeof(TValue) == typeof(uint))
                return (TValue)(object)(predicate.Invoke(value, index).AsByte() * (uint)(object)value!);

            if (typeof(TValue) == typeof(nint?))
                return (TValue)(object)(predicate.Invoke(value, index).AsByte() * ((nint?)(object?)value).GetValueOrDefault());

            if (typeof(TValue) == typeof(nint))
                return (TValue)(object)(predicate.Invoke(value, index).AsByte() * (nint)(object)value!);

            if (typeof(TValue) == typeof(nuint?))
                return (TValue)(object)(predicate.Invoke(value, index).AsByte() * ((nuint?)(object?)value).GetValueOrDefault());

            if (typeof(TValue) == typeof(nuint))
                return (TValue)(object)(predicate.Invoke(value, index).AsByte() * (nuint)(object)value!);

            if (typeof(TValue) == typeof(long?))
                return (TValue)(object)(predicate.Invoke(value, index).AsByte() * ((long?)(object?)value).GetValueOrDefault());

            if (typeof(TValue) == typeof(long))
                return (TValue)(object)(predicate.Invoke(value, index).AsByte() * (long)(object)value!);

            if (typeof(TValue) == typeof(ulong?))
                return (TValue)(object)(predicate.Invoke(value, index).AsByte() * ((ulong?)(object?)value).GetValueOrDefault());

            if (typeof(TValue) == typeof(ulong))
                return (TValue)(object)(predicate.Invoke(value, index).AsByte() * (ulong)(object)value!);

            if (typeof(TValue) == typeof(float?))
                return (TValue)(object)(predicate.Invoke(value, index).AsByte() * ((float?)(object?)value).GetValueOrDefault());

            if (typeof(TValue) == typeof(float))
                return (TValue)(object)(predicate.Invoke(value, index).AsByte() * (float)(object)value!);

            if (typeof(TValue) == typeof(double?))
                return (TValue)(object)(predicate.Invoke(value, index).AsByte() * ((double?)(object?)value).GetValueOrDefault());

            if (typeof(TValue) == typeof(double))
                return (TValue)(object)(predicate.Invoke(value, index).AsByte() * (double)(object)value!);

            if (typeof(TValue) == typeof(decimal?))
                return (TValue)(object)(predicate.Invoke(value, index).AsByte() * ((decimal?)(object?)value).GetValueOrDefault());

            if (typeof(TValue) == typeof(decimal))
                return (TValue)(object)(predicate.Invoke(value, index).AsByte() * (decimal)(object)value!);

            return Throw.NotSupportedException<TValue>();
        }
    }
}
