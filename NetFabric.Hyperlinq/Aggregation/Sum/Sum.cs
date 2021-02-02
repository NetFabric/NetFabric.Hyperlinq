using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    readonly struct AddInt32: IFunction<int, int, int>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(int arg1, int arg2)
        {
            checked 
            { 
                return arg1 + arg2; 
            }
        }
    }

    readonly struct AddNullableInt32: IFunction<int?, int, int>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(int? arg1, int arg2)
        {
            checked
            {
                return arg2 + arg1.GetValueOrDefault();
            }
        }
    }

    readonly struct AddInt64: IFunction<long, long, long>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long Invoke(long arg1, long arg2)
        {
            checked
            {
                return arg1 + arg2;
            }
        }
    }

    readonly struct AddNullableInt64: IFunction<long?, long, long>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long Invoke(long? arg1, long arg2)
        {
            checked
            {
                return arg2 + arg1.GetValueOrDefault();
            }
        }
    }

    readonly struct AddSingle: IFunction<float, float, float>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Invoke(float arg1, float arg2)
        {
            checked
            {
                return arg1 + arg2;
            }
        }
    }

    readonly struct AddNullableSingle: IFunction<float?, float, float>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Invoke(float? arg1, float arg2)
        {
            checked
            {
                return arg2 + arg1.GetValueOrDefault();
            }
        }
    }

    readonly struct AddDouble: IFunction<double, double, double>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Invoke(double arg1, double arg2)
        {
            checked
            {
                return arg1 + arg2;
            }
        }
    }

    readonly struct AddNullableDouble: IFunction<double?, double, double>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Invoke(double? arg1, double arg2)
        {
            checked
            {
                return arg2 + arg1.GetValueOrDefault();
            }
        }
    }

    readonly struct AddDecimal: IFunction<decimal, decimal, decimal>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal Invoke(decimal arg1, decimal arg2)
        {
            checked
            {
                return arg1 + arg2;
            }
        }
    }

    readonly struct AddNullableDecimal: IFunction<decimal?, decimal, decimal>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal Invoke(decimal? arg1, decimal arg2)
        {
            checked
            {
                return arg2 + arg1.GetValueOrDefault();
            }
        }
    }

}
