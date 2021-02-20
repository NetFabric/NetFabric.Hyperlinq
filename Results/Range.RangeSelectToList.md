## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Start | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |     **0** |    **10** |   **103.06 ns** |  **0.259 ns** |  **0.229 ns** |  **1.62** |    **0.01** | **0.0459** |     **-** |     **-** |      **96 B** |
|                       ValueLinq_Stack |     0 |    10 |   115.55 ns |  0.385 ns |  0.321 ns |  1.82 |    0.01 | 0.0458 |     - |     - |      96 B |
|             ValueLinq_SharedPool_Push |     0 |    10 |   322.05 ns |  1.126 ns |  0.998 ns |  5.06 |    0.03 | 0.0458 |     - |     - |      96 B |
|             ValueLinq_SharedPool_Pull |     0 |    10 |   226.39 ns |  0.939 ns |  0.832 ns |  3.56 |    0.03 | 0.0458 |     - |     - |      96 B |
|        ValueLinq_ValueLambda_Standard |     0 |    10 |    99.21 ns |  0.233 ns |  0.207 ns |  1.56 |    0.01 | 0.0459 |     - |     - |      96 B |
|           ValueLinq_ValueLambda_Stack |     0 |    10 |   102.47 ns |  0.286 ns |  0.254 ns |  1.61 |    0.01 | 0.0459 |     - |     - |      96 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |    10 |   238.94 ns |  0.632 ns |  0.528 ns |  3.76 |    0.03 | 0.0458 |     - |     - |      96 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |    10 |   214.93 ns |  0.285 ns |  0.266 ns |  3.38 |    0.02 | 0.0458 |     - |     - |      96 B |
|                               ForLoop |     0 |    10 |    63.61 ns |  0.439 ns |  0.411 ns |  1.00 |    0.00 | 0.1032 |     - |     - |     216 B |
|                           ForeachLoop |     0 |    10 |   129.43 ns |  0.442 ns |  0.391 ns |  2.03 |    0.02 | 0.1299 |     - |     - |     272 B |
|                                  Linq |     0 |    10 |    75.67 ns |  0.203 ns |  0.180 ns |  1.19 |    0.01 | 0.0880 |     - |     - |     184 B |
|                            LinqFaster |     0 |    10 |    61.99 ns |  0.300 ns |  0.250 ns |  0.97 |    0.01 | 0.1070 |     - |     - |     224 B |
|                                LinqAF |     0 |    10 |   153.16 ns |  0.752 ns |  0.703 ns |  2.41 |    0.02 | 0.1032 |     - |     - |     216 B |
|                            StructLinq |     0 |    10 |    52.77 ns |  0.119 ns |  0.100 ns |  0.83 |    0.01 | 0.0726 |     - |     - |     152 B |
|                  StructLinq_IFunction |     0 |    10 |    37.26 ns |  0.102 ns |  0.090 ns |  0.59 |    0.00 | 0.0458 |     - |     - |      96 B |
|                             Hyperlinq |     0 |    10 |    47.93 ns |  0.393 ns |  0.328 ns |  0.75 |    0.00 | 0.0459 |     - |     - |      96 B |
|                   Hyperlinq_IFunction |     0 |    10 |    38.62 ns |  0.257 ns |  0.200 ns |  0.61 |    0.00 | 0.0458 |     - |     - |      96 B |
|                        Hyperlinq_SIMD |     0 |    10 |    52.12 ns |  0.152 ns |  0.142 ns |  0.82 |    0.01 | 0.0459 |     - |     - |      96 B |
|              Hyperlinq_IFunction_SIMD |     0 |    10 |    35.46 ns |  0.136 ns |  0.121 ns |  0.56 |    0.00 | 0.0459 |     - |     - |      96 B |
|                                       |       |       |             |           |           |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |     **0** |  **1000** | **2,883.52 ns** | **12.807 ns** | **11.353 ns** |  **1.36** |    **0.01** | **1.9379** |     **-** |     **-** |    **4056 B** |
|                       ValueLinq_Stack |     0 |  1000 | 3,665.86 ns | 11.063 ns |  9.807 ns |  1.72 |    0.01 | 3.9330 |     - |     - |    8232 B |
|             ValueLinq_SharedPool_Push |     0 |  1000 | 3,237.60 ns | 14.183 ns | 11.844 ns |  1.52 |    0.01 | 1.9379 |     - |     - |    4056 B |
|             ValueLinq_SharedPool_Pull |     0 |  1000 | 3,819.97 ns | 11.158 ns |  9.317 ns |  1.80 |    0.01 | 1.9379 |     - |     - |    4056 B |
|        ValueLinq_ValueLambda_Standard |     0 |  1000 | 2,174.97 ns |  7.602 ns |  7.111 ns |  1.02 |    0.00 | 1.9379 |     - |     - |    4056 B |
|           ValueLinq_ValueLambda_Stack |     0 |  1000 | 2,609.89 ns | 10.929 ns |  9.689 ns |  1.23 |    0.01 | 3.9330 |     - |     - |    8232 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |  1000 | 2,577.34 ns | 10.508 ns |  9.829 ns |  1.21 |    0.01 | 1.9379 |     - |     - |    4056 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |  1000 | 2,467.56 ns |  8.012 ns |  7.102 ns |  1.16 |    0.01 | 1.9379 |     - |     - |    4056 B |
|                               ForLoop |     0 |  1000 | 2,125.63 ns | 10.585 ns |  9.901 ns |  1.00 |    0.00 | 4.0207 |     - |     - |    8424 B |
|                           ForeachLoop |     0 |  1000 | 5,712.04 ns | 31.654 ns | 26.433 ns |  2.69 |    0.01 | 4.0436 |     - |     - |    8480 B |
|                                  Linq |     0 |  1000 | 2,975.91 ns | 12.898 ns | 10.770 ns |  1.40 |    0.01 | 1.9798 |     - |     - |    4144 B |
|                            LinqFaster |     0 |  1000 | 2,610.37 ns | 20.786 ns | 18.427 ns |  1.23 |    0.01 | 5.7793 |     - |     - |   12104 B |
|                                LinqAF |     0 |  1000 | 5,734.22 ns | 16.759 ns | 14.856 ns |  2.70 |    0.02 | 4.0207 |     - |     - |    8424 B |
|                            StructLinq |     0 |  1000 | 2,043.61 ns |  7.231 ns |  6.410 ns |  0.96 |    0.01 | 1.9646 |     - |     - |    4112 B |
|                  StructLinq_IFunction |     0 |  1000 |   733.15 ns |  5.305 ns |  4.703 ns |  0.34 |    0.00 | 1.9379 |     - |     - |    4056 B |
|                             Hyperlinq |     0 |  1000 | 2,346.94 ns | 12.651 ns | 11.834 ns |  1.10 |    0.01 | 1.9379 |     - |     - |    4056 B |
|                   Hyperlinq_IFunction |     0 |  1000 | 1,241.48 ns |  3.342 ns |  2.962 ns |  0.58 |    0.00 | 1.9379 |     - |     - |    4056 B |
|                        Hyperlinq_SIMD |     0 |  1000 |   544.34 ns |  1.056 ns |  0.936 ns |  0.26 |    0.00 | 1.9341 |     - |     - |    4056 B |
|              Hyperlinq_IFunction_SIMD |     0 |  1000 |   314.40 ns |  0.978 ns |  0.915 ns |  0.15 |    0.00 | 1.9341 |     - |     - |    4056 B |
