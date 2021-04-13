## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT

EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  

```
|               Method |    Job |  Runtime | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|          **ForeachLoop** | **.NET 5** | **.NET 5.0** |    **10** |     **99.15 ns** |   **0.487 ns** |   **0.456 ns** |   **1.00** |    **0.00** |  **0.0802** |     **-** |     **-** |     **168 B** |
|                 Linq | .NET 5 | .NET 5.0 |    10 |    182.35 ns |   0.721 ns |   0.639 ns |   1.84 |    0.01 |  0.1376 |     - |     - |     288 B |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |    190.14 ns |   0.756 ns |   0.707 ns |   1.92 |    0.01 |  0.0801 |     - |     - |     168 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 52,971.81 ns | 209.505 ns | 185.720 ns | 534.42 |    3.57 | 15.3198 |     - |     - |  32,136 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    431.64 ns |   1.821 ns |   1.703 ns |   4.35 |    0.03 |  0.3405 |     - |     - |     712 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |    203.36 ns |   1.077 ns |   1.007 ns |   2.05 |    0.02 |  0.0994 |     - |     - |     208 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |    155.41 ns |   0.643 ns |   0.537 ns |   1.57 |    0.01 |  0.0572 |     - |     - |     120 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |    160.44 ns |   0.877 ns |   0.821 ns |   1.62 |    0.01 |  0.0572 |     - |     - |     120 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |    143.72 ns |   0.562 ns |   0.525 ns |   1.45 |    0.01 |  0.0572 |     - |     - |     120 B |
|                      |        |          |       |              |            |            |        |         |         |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |     75.35 ns |   0.939 ns |   0.832 ns |   1.00 |    0.00 |  0.0802 |     - |     - |     168 B |
|                 Linq | .NET 6 | .NET 6.0 |    10 |    134.91 ns |   1.087 ns |   1.017 ns |   1.79 |    0.03 |  0.1376 |     - |     - |     288 B |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |    162.81 ns |   0.762 ns |   0.675 ns |   2.16 |    0.03 |  0.0801 |     - |     - |     168 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 49,328.26 ns | 258.006 ns | 241.339 ns | 654.82 |    8.95 | 15.1367 |     - |     - |  31,692 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    381.71 ns |   3.018 ns |   2.675 ns |   5.07 |    0.08 |  0.3395 |     - |     - |     712 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |    182.31 ns |   0.613 ns |   0.573 ns |   2.42 |    0.03 |  0.0994 |     - |     - |     208 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |    130.46 ns |   0.511 ns |   0.478 ns |   1.73 |    0.02 |  0.0572 |     - |     - |     120 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |    140.41 ns |   0.828 ns |   0.774 ns |   1.87 |    0.02 |  0.0572 |     - |     - |     120 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |    120.02 ns |   0.394 ns |   0.350 ns |   1.59 |    0.02 |  0.0572 |     - |     - |     120 B |
|                      |        |          |       |              |            |            |        |         |         |       |       |           |
|          **ForeachLoop** | **.NET 5** | **.NET 5.0** |  **1000** |  **5,658.90 ns** |  **18.100 ns** |  **15.115 ns** |   **1.00** |    **0.00** |  **2.0752** |     **-** |     **-** |   **4,344 B** |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  7,578.82 ns |  46.426 ns |  36.246 ns |   1.34 |    0.01 |  2.1286 |     - |     - |   4,464 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  8,644.31 ns |  42.187 ns |  39.462 ns |   1.53 |    0.01 |  2.0752 |     - |     - |   4,344 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 58,444.96 ns | 221.458 ns | 207.152 ns |  10.33 |    0.05 | 17.2119 |     - |     - |  36,097 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 13,492.31 ns |  60.173 ns |  56.286 ns |   2.39 |    0.01 |  2.3346 |     - |     - |   4,888 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  7,972.02 ns |  13.826 ns |  10.794 ns |   1.41 |    0.00 |  1.0376 |     - |     - |   2,184 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  5,750.91 ns |  20.314 ns |  18.007 ns |   1.02 |    0.00 |  0.9995 |     - |     - |   2,096 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  7,437.82 ns |  24.035 ns |  22.483 ns |   1.31 |    0.01 |  0.9995 |     - |     - |   2,096 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  5,681.34 ns |  17.949 ns |  15.911 ns |   1.00 |    0.00 |  0.9995 |     - |     - |   2,096 B |
|                      |        |          |       |              |            |            |        |         |         |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  3,610.66 ns |  44.419 ns |  37.092 ns |   1.00 |    0.00 |  2.0752 |     - |     - |   4,344 B |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  5,173.07 ns |  17.994 ns |  24.022 ns |   1.43 |    0.02 |  2.1286 |     - |     - |   4,464 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  6,072.78 ns |  32.990 ns |  25.757 ns |   1.68 |    0.02 |  2.0752 |     - |     - |   4,344 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 55,981.12 ns | 157.436 ns | 139.563 ns |  15.51 |    0.18 | 17.0288 |     - |     - |  35,646 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 10,917.81 ns |  47.548 ns |  42.150 ns |   3.02 |    0.03 |  2.3346 |     - |     - |   4,888 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  5,600.22 ns |  20.728 ns |  17.309 ns |   1.55 |    0.02 |  1.0376 |     - |     - |   2,184 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  3,819.06 ns |  17.072 ns |  15.134 ns |   1.06 |    0.01 |  0.9995 |     - |     - |   2,096 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  6,085.56 ns |  28.079 ns |  26.265 ns |   1.69 |    0.02 |  0.9995 |     - |     - |   2,096 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  3,858.89 ns |  12.330 ns |  10.930 ns |   1.07 |    0.01 |  0.9995 |     - |     - |   2,096 B |
