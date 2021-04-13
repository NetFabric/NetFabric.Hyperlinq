## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|               Method |    Job |  Runtime | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|--------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |     **67.91 ns** |   **0.861 ns** |   **0.805 ns** |   **1.00** |    **0.00** |  **0.2218** |       **-** |     **-** |     **464 B** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |     80.80 ns |   1.256 ns |   0.981 ns |   1.19 |    0.02 |  0.2218 |       - |     - |     464 B |
|                 Linq | .NET 5 | .NET 5.0 |    10 |    155.10 ns |   0.725 ns |   0.678 ns |   2.28 |    0.03 |  0.3097 |       - |     - |     648 B |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |     92.10 ns |   0.811 ns |   0.759 ns |   1.36 |    0.03 |  0.3901 |       - |     - |     816 B |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |    238.29 ns |   4.641 ns |   4.341 ns |   3.51 |    0.07 |  0.2065 |       - |     - |     432 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 54,436.01 ns | 302.831 ns | 283.268 ns | 801.74 |   10.78 | 68.9087 | 17.1509 |     - | 154,145 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    489.45 ns |   8.650 ns |   8.091 ns |   7.21 |    0.15 |  0.4663 |       - |     - |     976 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |    151.42 ns |   0.625 ns |   0.585 ns |   2.23 |    0.03 |  0.1185 |       - |     - |     248 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |    115.73 ns |   0.686 ns |   0.608 ns |   1.71 |    0.02 |  0.0726 |       - |     - |     152 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |    153.99 ns |   1.463 ns |   1.368 ns |   2.27 |    0.03 |  0.0725 |       - |     - |     152 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |    134.46 ns |   1.903 ns |   1.780 ns |   1.98 |    0.02 |  0.0725 |       - |     - |     152 B |
|                      |        |          |       |              |            |            |        |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |     66.85 ns |   0.822 ns |   0.769 ns |   1.00 |    0.00 |  0.2218 |       - |     - |     464 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |     77.50 ns |   0.873 ns |   0.816 ns |   1.16 |    0.02 |  0.2218 |       - |     - |     464 B |
|                 Linq | .NET 6 | .NET 6.0 |    10 |    151.07 ns |   2.346 ns |   2.080 ns |   2.26 |    0.04 |  0.3097 |       - |     - |     648 B |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |     92.77 ns |   1.415 ns |   1.182 ns |   1.39 |    0.02 |  0.3901 |       - |     - |     816 B |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |    257.99 ns |   4.370 ns |   4.088 ns |   3.86 |    0.08 |  0.2065 |       - |     - |     432 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 50,813.95 ns | 443.992 ns | 415.311 ns | 760.17 |    8.25 | 69.2749 |  7.5073 |     - | 153,890 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    496.27 ns |   3.355 ns |   2.619 ns |   7.44 |    0.08 |  0.4654 |       - |     - |     976 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |    153.84 ns |   1.345 ns |   1.258 ns |   2.30 |    0.03 |  0.1185 |       - |     - |     248 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |    113.76 ns |   0.440 ns |   0.367 ns |   1.71 |    0.02 |  0.0726 |       - |     - |     152 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |    149.70 ns |   2.126 ns |   1.660 ns |   2.25 |    0.03 |  0.0725 |       - |     - |     152 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |    132.94 ns |   1.255 ns |   1.112 ns |   1.99 |    0.03 |  0.0725 |       - |     - |     152 B |
|                      |        |          |       |              |            |            |        |         |         |         |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** | **14,133.20 ns** |  **35.604 ns** |  **31.562 ns** |   **1.00** |    **0.00** | **15.5487** |  **7.7667** |     **-** |  **97,720 B** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 | 16,011.46 ns |  74.182 ns |  57.917 ns |   1.13 |    0.01 | 15.5640 |  7.7820 |     - |  97,720 B |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 16,756.62 ns | 203.368 ns | 180.281 ns |   1.19 |    0.01 | 10.4675 |  5.2185 |     - |  65,792 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 | 14,741.53 ns |  66.721 ns |  62.411 ns |   1.04 |    0.00 | 15.1520 |  7.5684 |     - |  96,240 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 27,017.36 ns | 452.976 ns | 465.173 ns |   1.91 |    0.03 | 46.5088 |       - |     - |  97,688 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 71,532.50 ns | 245.082 ns | 229.250 ns |   5.06 |    0.02 | 68.8477 | 17.2119 |     - | 186,210 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 64,669.52 ns | 203.865 ns | 190.696 ns |   4.58 |    0.02 | 15.6250 |  7.8125 |     - |  98,232 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 | 14,915.55 ns | 120.701 ns | 100.791 ns |   1.06 |    0.01 |  5.1270 |  2.5635 |     - |  32,312 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 11,087.44 ns |  34.257 ns |  32.044 ns |   0.78 |    0.00 |  5.0964 |  2.5482 |     - |  32,216 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 15,957.44 ns | 174.811 ns | 163.518 ns |   1.13 |    0.01 |  5.0964 |  2.5330 |     - |  32,216 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 11,593.97 ns |  93.790 ns |  78.319 ns |   0.82 |    0.01 |  5.0964 |  2.5482 |     - |  32,216 B |
|                      |        |          |       |              |            |            |        |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 | 14,533.50 ns |  46.426 ns |  43.427 ns |   1.00 |    0.00 | 15.5487 |  7.7667 |     - |  97,720 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 | 14,148.72 ns |  85.010 ns | 173.652 ns |   0.98 |    0.01 | 46.5088 |       - |     - |  97,720 B |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 16,640.28 ns | 199.214 ns | 186.345 ns |   1.14 |    0.01 | 10.4675 |  5.2185 |     - |  65,792 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 | 14,856.44 ns |  94.974 ns |  88.839 ns |   1.02 |    0.01 | 15.1520 |  7.5684 |     - |  96,240 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 30,535.41 ns | 523.062 ns | 436.780 ns |   2.10 |    0.03 | 46.5088 |       - |     - |  97,688 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 69,267.62 ns | 486.919 ns | 455.464 ns |   4.77 |    0.03 | 68.8477 | 17.2119 |     - | 185,953 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 64,114.36 ns | 204.641 ns | 191.422 ns |   4.41 |    0.02 | 15.6250 |  7.8125 |     - |  98,232 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 | 14,755.34 ns |  94.101 ns |  78.579 ns |   1.02 |    0.00 |  5.1270 |  2.5635 |     - |  32,312 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 10,583.70 ns |  58.751 ns |  54.956 ns |   0.73 |    0.01 |  5.0964 |  2.5482 |     - |  32,216 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 16,824.62 ns | 190.744 ns | 178.422 ns |   1.16 |    0.01 |  5.0964 |  2.5330 |     - |  32,216 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 12,655.93 ns |  46.031 ns |  38.438 ns |   0.87 |    0.00 |  5.0964 |  2.5482 |     - |  32,216 B |
