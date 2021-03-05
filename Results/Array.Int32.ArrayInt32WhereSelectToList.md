## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                                Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |   **190.11 ns** |  **0.762 ns** |  **0.637 ns** |  **7.53** |    **0.04** | **0.0305** |     **-** |     **-** |      **64 B** |
|                       ValueLinq_Stack |    10 |   153.35 ns |  0.377 ns |  0.352 ns |  6.08 |    0.02 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push |    10 |   355.34 ns |  0.619 ns |  0.517 ns | 14.08 |    0.05 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull |    10 |   261.32 ns |  0.477 ns |  0.398 ns | 10.35 |    0.02 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard |    10 |   169.11 ns |  0.476 ns |  0.397 ns |  6.70 |    0.02 | 0.0305 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack |    10 |   134.66 ns |  1.196 ns |  0.998 ns |  5.34 |    0.05 | 0.0303 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |   286.47 ns |  0.775 ns |  0.687 ns | 11.35 |    0.04 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |   256.09 ns |  0.998 ns |  0.884 ns | 10.15 |    0.05 | 0.0305 |     - |     - |      64 B |
|                               ForLoop |    10 |    25.23 ns |  0.088 ns |  0.078 ns |  1.00 |    0.00 | 0.0344 |     - |     - |      72 B |
|                           ForeachLoop |    10 |    25.12 ns |  0.177 ns |  0.166 ns |  1.00 |    0.01 | 0.0344 |     - |     - |      72 B |
|                                  Linq |    10 |    90.45 ns |  0.227 ns |  0.201 ns |  3.58 |    0.01 | 0.0840 |     - |     - |     176 B |
|                            LinqFaster |    10 |    67.77 ns |  0.286 ns |  0.531 ns |  2.69 |    0.01 | 0.0764 |     - |     - |     160 B |
|                                LinqAF |    10 |    99.82 ns |  0.356 ns |  0.315 ns |  3.96 |    0.02 | 0.0342 |     - |     - |      72 B |
|                            StructLinq |    10 |   139.00 ns |  0.240 ns |  0.187 ns |  5.51 |    0.01 | 0.0763 |     - |     - |     160 B |
|                  StructLinq_IFunction |    10 |    98.57 ns |  0.209 ns |  0.174 ns |  3.91 |    0.02 | 0.0305 |     - |     - |      64 B |
|                             Hyperlinq |    10 |   110.98 ns |  0.259 ns |  0.216 ns |  4.40 |    0.02 | 0.0305 |     - |     - |      64 B |
|                   Hyperlinq_IFunction |    10 |    90.22 ns |  0.268 ns |  0.224 ns |  3.57 |    0.01 | 0.0305 |     - |     - |      64 B |
|                                       |       |             |           |           |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **5,226.36 ns** | **27.199 ns** | **25.442 ns** |  **1.64** |    **0.01** | **2.0523** |     **-** |     **-** |   **4,304 B** |
|                       ValueLinq_Stack |  1000 | 6,568.24 ns | 17.045 ns | 14.233 ns |  2.06 |    0.01 | 1.9913 |     - |     - |   4,176 B |
|             ValueLinq_SharedPool_Push |  1000 | 5,412.49 ns | 26.874 ns | 23.823 ns |  1.70 |    0.01 | 0.9842 |     - |     - |   2,072 B |
|             ValueLinq_SharedPool_Pull |  1000 | 7,337.54 ns | 16.458 ns | 15.394 ns |  2.30 |    0.01 | 0.9842 |     - |     - |   2,072 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 2,944.12 ns | 13.981 ns | 13.078 ns |  0.92 |    0.00 | 2.0561 |     - |     - |   4,304 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 2,927.67 ns | 18.695 ns | 17.487 ns |  0.92 |    0.01 | 1.9951 |     - |     - |   4,176 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 3,060.55 ns | 11.554 ns |  9.020 ns |  0.96 |    0.00 | 0.9880 |     - |     - |   2,072 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 2,697.05 ns | 17.527 ns | 16.394 ns |  0.85 |    0.01 | 0.9880 |     - |     - |   2,072 B |
|                               ForLoop |  1000 | 3,184.00 ns |  8.742 ns |  8.177 ns |  1.00 |    0.00 | 2.0561 |     - |     - |   4,304 B |
|                           ForeachLoop |  1000 | 3,183.96 ns | 12.690 ns | 11.249 ns |  1.00 |    0.01 | 2.0561 |     - |     - |   4,304 B |
|                                  Linq |  1000 | 4,798.76 ns | 15.650 ns | 13.873 ns |  1.51 |    0.01 | 2.1057 |     - |     - |   4,408 B |
|                            LinqFaster |  1000 | 4,814.82 ns | 16.825 ns | 14.049 ns |  1.51 |    0.01 | 3.8834 |     - |     - |   8,136 B |
|                                LinqAF |  1000 | 8,061.06 ns | 13.174 ns | 12.323 ns |  2.53 |    0.01 | 2.0447 |     - |     - |   4,304 B |
|                            StructLinq |  1000 | 5,769.37 ns | 16.835 ns | 14.058 ns |  1.81 |    0.01 | 1.0300 |     - |     - |   2,168 B |
|                  StructLinq_IFunction |  1000 | 4,280.26 ns |  9.370 ns |  8.306 ns |  1.34 |    0.00 | 0.9842 |     - |     - |   2,072 B |
|                             Hyperlinq |  1000 | 5,248.53 ns | 21.994 ns | 17.172 ns |  1.65 |    0.01 | 0.9842 |     - |     - |   2,072 B |
|                   Hyperlinq_IFunction |  1000 | 3,233.19 ns |  9.892 ns |  9.253 ns |  1.02 |    0.00 | 0.9880 |     - |     - |   2,072 B |
