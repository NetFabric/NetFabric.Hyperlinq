## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta43](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta43)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                                Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |   **165.70 ns** |  **1.004 ns** |  **0.839 ns** |  **4.42** |    **0.03** | **0.0150** |     **-** |     **-** |      **32 B** |
|                       ValueLinq_Stack |    10 |   135.50 ns |  0.574 ns |  0.479 ns |  3.61 |    0.02 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Push |    10 |   355.85 ns |  1.195 ns |  1.059 ns |  9.49 |    0.06 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Pull |    10 |   263.73 ns |  1.166 ns |  1.033 ns |  7.03 |    0.04 | 0.0153 |     - |     - |      32 B |
|        ValueLinq_ValueLambda_Standard |    10 |   148.88 ns |  0.827 ns |  0.733 ns |  3.97 |    0.02 | 0.0153 |     - |     - |      32 B |
|           ValueLinq_ValueLambda_Stack |    10 |   112.04 ns |  0.275 ns |  0.243 ns |  2.99 |    0.01 | 0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |   285.14 ns |  1.686 ns |  1.408 ns |  7.60 |    0.05 | 0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |   260.76 ns |  1.393 ns |  1.303 ns |  6.95 |    0.03 | 0.0153 |     - |     - |      32 B |
|                               ForLoop |    10 |    37.50 ns |  0.172 ns |  0.152 ns |  1.00 |    0.00 | 0.0497 |     - |     - |     104 B |
|                           ForeachLoop |    10 |    37.63 ns |  0.160 ns |  0.142 ns |  1.00 |    0.00 | 0.0497 |     - |     - |     104 B |
|                                  Linq |    10 |   118.54 ns |  1.159 ns |  0.968 ns |  3.16 |    0.03 | 0.0842 |     - |     - |     176 B |
|                            LinqFaster |    10 |    44.58 ns |  0.165 ns |  0.146 ns |  1.19 |    0.01 | 0.0458 |     - |     - |      96 B |
|                                LinqAF |    10 |   105.69 ns |  0.324 ns |  0.271 ns |  2.82 |    0.02 | 0.0342 |     - |     - |      72 B |
|                            StructLinq |    10 |   133.42 ns |  0.490 ns |  0.458 ns |  3.56 |    0.02 | 0.0610 |     - |     - |     128 B |
|                  StructLinq_IFunction |    10 |    93.63 ns |  0.305 ns |  0.270 ns |  2.50 |    0.01 | 0.0153 |     - |     - |      32 B |
|                             Hyperlinq |    10 |   108.93 ns |  0.244 ns |  0.204 ns |  2.90 |    0.01 | 0.0153 |     - |     - |      32 B |
|                   Hyperlinq_IFunction |    10 |    92.51 ns |  1.927 ns |  1.803 ns |  2.47 |    0.05 | 0.0153 |     - |     - |      32 B |
|                                       |       |             |           |           |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **6,303.41 ns** | **32.309 ns** | **30.222 ns** |  **2.41** |    **0.02** | **1.9760** |     **-** |     **-** |   **4,144 B** |
|                       ValueLinq_Stack |  1000 | 7,125.29 ns | 38.747 ns | 34.348 ns |  2.73 |    0.02 | 1.9760 |     - |     - |   4,144 B |
|             ValueLinq_SharedPool_Push |  1000 | 5,678.53 ns | 37.973 ns | 35.520 ns |  2.18 |    0.02 | 0.9689 |     - |     - |   2,040 B |
|             ValueLinq_SharedPool_Pull |  1000 | 7,138.76 ns | 37.671 ns | 33.394 ns |  2.73 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 2,663.95 ns | 19.055 ns | 16.892 ns |  1.02 |    0.01 | 1.9798 |     - |     - |   4,144 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 2,659.98 ns | 32.024 ns | 29.955 ns |  1.02 |    0.01 | 1.9798 |     - |     - |   4,144 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 4,198.13 ns | 27.187 ns | 22.702 ns |  1.61 |    0.01 | 0.9689 |     - |     - |   2,040 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 2,931.90 ns | 19.480 ns | 16.267 ns |  1.12 |    0.01 | 0.9727 |     - |     - |   2,040 B |
|                               ForLoop |  1000 | 2,612.01 ns | 13.168 ns | 10.996 ns |  1.00 |    0.00 | 3.0289 |     - |     - |   6,344 B |
|                           ForeachLoop |  1000 | 2,793.79 ns | 27.657 ns | 25.871 ns |  1.07 |    0.01 | 3.0289 |     - |     - |   6,344 B |
|                                  Linq |  1000 | 5,485.80 ns | 19.161 ns | 16.985 ns |  2.10 |    0.01 | 2.1667 |     - |     - |   4,544 B |
|                            LinqFaster |  1000 | 6,055.79 ns | 17.378 ns | 15.405 ns |  2.32 |    0.01 | 2.8915 |     - |     - |   6,064 B |
|                                LinqAF |  1000 | 7,880.93 ns | 36.259 ns | 33.916 ns |  3.02 |    0.02 | 3.0060 |     - |     - |   6,312 B |
|                            StructLinq |  1000 | 5,960.69 ns | 20.334 ns | 18.025 ns |  2.28 |    0.01 | 1.0147 |     - |     - |   2,136 B |
|                  StructLinq_IFunction |  1000 | 2,956.87 ns | 18.561 ns | 16.454 ns |  1.13 |    0.01 | 0.9727 |     - |     - |   2,040 B |
|                             Hyperlinq |  1000 | 5,316.83 ns | 25.532 ns | 23.883 ns |  2.04 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|                   Hyperlinq_IFunction |  1000 | 3,641.37 ns | 12.373 ns | 10.969 ns |  1.39 |    0.01 | 0.9727 |     - |     - |   2,040 B |
