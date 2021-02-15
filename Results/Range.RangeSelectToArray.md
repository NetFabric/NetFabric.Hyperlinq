## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta36](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta36)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Start | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    ValueLinq_Standard |     0 |   100 | 280.86 ns |  1.625 ns |  1.441 ns |  3.14 |    0.03 | 0.2027 |     - |     - |     424 B |
|                       ValueLinq_Stack |     0 |   100 | 519.40 ns |  1.995 ns |  1.867 ns |  5.82 |    0.04 | 0.3166 |     - |     - |     664 B |
|             ValueLinq_SharedPool_Push |     0 |   100 | 586.81 ns |  6.414 ns |  6.000 ns |  6.57 |    0.08 | 0.2022 |     - |     - |     424 B |
|             ValueLinq_SharedPool_Pull |     0 |   100 | 616.49 ns |  3.286 ns |  3.074 ns |  6.91 |    0.07 | 0.2022 |     - |     - |     424 B |
|        ValueLinq_ValueLambda_Standard |     0 |   100 | 256.70 ns |  1.857 ns |  1.551 ns |  2.87 |    0.02 | 0.2027 |     - |     - |     424 B |
|           ValueLinq_ValueLambda_Stack |     0 |   100 | 380.08 ns |  1.558 ns |  1.458 ns |  4.26 |    0.04 | 0.3171 |     - |     - |     664 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   100 | 439.51 ns |  2.239 ns |  2.094 ns |  4.92 |    0.04 | 0.2027 |     - |     - |     424 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   100 | 470.63 ns |  1.835 ns |  1.717 ns |  5.27 |    0.04 | 0.2027 |     - |     - |     424 B |
|                               ForLoop |     0 |   100 |  89.28 ns |  0.718 ns |  0.672 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                  Linq |     0 |   100 | 254.91 ns |  1.433 ns |  1.340 ns |  2.86 |    0.03 | 0.2446 |     - |     - |     512 B |
|                            LinqFaster |     0 |   100 | 291.23 ns |  2.389 ns |  2.235 ns |  3.26 |    0.05 | 0.4053 |     - |     - |     848 B |
|                       LinqFaster_SIMD |     0 |   100 | 100.33 ns |  0.766 ns |  0.640 ns |  1.12 |    0.01 | 0.4054 |     - |     - |     848 B |
|                                LinqAF |     0 |   100 | 801.86 ns | 12.911 ns | 11.446 ns |  8.98 |    0.13 | 0.7534 |     - |     - |    1576 B |
|                            StructLinq |     0 |   100 | 237.10 ns |  1.245 ns |  1.164 ns |  2.66 |    0.02 | 0.2294 |     - |     - |     480 B |
|                  StructLinq_IFunction |     0 |   100 |  99.94 ns |  0.716 ns |  0.670 ns |  1.12 |    0.01 | 0.2027 |     - |     - |     424 B |
|                             Hyperlinq |     0 |   100 | 203.60 ns |  1.639 ns |  1.453 ns |  2.28 |    0.02 | 0.2027 |     - |     - |     424 B |
|                   Hyperlinq_IFunction |     0 |   100 | 144.61 ns |  0.869 ns |  0.771 ns |  1.62 |    0.01 | 0.2027 |     - |     - |     424 B |
|                        Hyperlinq_Pool |     0 |   100 | 286.29 ns |  1.107 ns |  0.981 ns |  3.21 |    0.03 | 0.0267 |     - |     - |      56 B |
|              Hyperlinq_Pool_IFunction |     0 |   100 | 148.24 ns |  1.235 ns |  1.031 ns |  1.66 |    0.02 | 0.0267 |     - |     - |      56 B |
|                        Hyperlinq_SIMD |     0 |   100 |  96.79 ns |  1.207 ns |  1.129 ns |  1.08 |    0.02 | 0.2027 |     - |     - |     424 B |
|              Hyperlinq_IFunction_SIMD |     0 |   100 |  65.03 ns |  0.600 ns |  0.532 ns |  0.73 |    0.01 | 0.2027 |     - |     - |     424 B |
|                   Hyperlinq_Pool_SIMD |     0 |   100 | 135.42 ns |  1.816 ns |  1.699 ns |  1.52 |    0.02 | 0.0267 |     - |     - |      56 B |
|         Hyperlinq_Pool_IFunction_SIMD |     0 |   100 |  93.16 ns |  0.340 ns |  0.318 ns |  1.04 |    0.01 | 0.0267 |     - |     - |      56 B |
