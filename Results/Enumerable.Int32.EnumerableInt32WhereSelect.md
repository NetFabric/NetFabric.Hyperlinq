## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|               Method |    Job |  Runtime | Count |         Mean |      Error |     StdDev |    Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |-------------:|-----------:|-----------:|---------:|--------:|--------:|------:|------:|----------:|
|          **ForeachLoop** | **.NET 5** | **.NET 5.0** |    **10** |     **61.84 ns** |   **0.431 ns** |   **0.403 ns** |     **1.00** |    **0.00** |  **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5 | .NET 5.0 |    10 |    177.95 ns |   0.849 ns |   0.753 ns |     2.88 |    0.02 |  0.0763 |     - |     - |     160 B |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |    141.69 ns |   0.600 ns |   0.562 ns |     2.29 |    0.02 |  0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 51,025.99 ns | 234.307 ns | 182.932 ns |   823.72 |    5.20 | 14.8926 |     - |     - |  31,182 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    368.35 ns |   1.886 ns |   1.672 ns |     5.95 |    0.03 |  0.3557 |     - |     - |     744 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |    121.45 ns |   0.911 ns |   0.852 ns |     1.96 |    0.02 |  0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |     83.40 ns |   0.663 ns |   0.554 ns |     1.35 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |    100.97 ns |   0.336 ns |   0.315 ns |     1.63 |    0.01 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |     81.67 ns |   0.389 ns |   0.345 ns |     1.32 |    0.01 |  0.0191 |     - |     - |      40 B |
|                      |        |          |       |              |            |            |          |         |         |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |     37.59 ns |   0.515 ns |   0.482 ns |     1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | .NET 6.0 |    10 |    117.51 ns |   0.715 ns |   0.669 ns |     3.13 |    0.05 |  0.0763 |     - |     - |     160 B |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |     97.29 ns |   0.240 ns |   0.213 ns |     2.58 |    0.01 |  0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 46,518.04 ns | 254.578 ns | 225.676 ns | 1,233.71 |    8.12 | 14.6484 |     - |     - |  30,731 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    318.49 ns |   3.965 ns |   3.709 ns |     8.47 |    0.13 |  0.3557 |     - |     - |     744 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |     77.91 ns |   0.310 ns |   0.275 ns |     2.07 |    0.01 |  0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     58.63 ns |   0.442 ns |   0.345 ns |     1.55 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |     59.74 ns |   0.389 ns |   0.363 ns |     1.59 |    0.02 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |     59.25 ns |   0.354 ns |   0.314 ns |     1.57 |    0.01 |  0.0191 |     - |     - |      40 B |
|                      |        |          |       |              |            |            |          |         |         |       |       |           |
|          **ForeachLoop** | **.NET 5** | **.NET 5.0** |  **1000** |  **4,796.43 ns** |  **14.656 ns** |  **12.992 ns** |     **1.00** |    **0.00** |  **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  8,715.78 ns |  62.477 ns |  55.384 ns |     1.82 |    0.01 |  0.0763 |     - |     - |     160 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  7,798.04 ns |  40.077 ns |  37.488 ns |     1.63 |    0.01 |  0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 58,259.65 ns | 207.188 ns | 193.804 ns |    12.14 |    0.07 | 15.6860 |     - |     - |  33,159 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 14,936.61 ns |  86.233 ns |  72.009 ns |     3.11 |    0.01 |  0.3510 |     - |     - |     744 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  7,092.66 ns |  22.508 ns |  19.953 ns |     1.48 |    0.00 |  0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  5,428.97 ns |  17.000 ns |  15.902 ns |     1.13 |    0.00 |  0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  7,005.88 ns |  39.873 ns |  37.297 ns |     1.46 |    0.01 |  0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  5,465.15 ns |  22.663 ns |  20.090 ns |     1.14 |    0.00 |  0.0153 |     - |     - |      40 B |
|                      |        |          |       |              |            |            |          |         |         |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  2,343.96 ns |   8.619 ns |   7.198 ns |     1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  5,824.78 ns |  25.241 ns |  23.611 ns |     2.49 |    0.01 |  0.0763 |     - |     - |     160 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  5,241.47 ns |  24.504 ns |  22.921 ns |     2.24 |    0.01 |  0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 53,475.42 ns | 132.516 ns | 103.460 ns |    22.81 |    0.07 | 15.6250 |     - |     - |  32,708 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 11,481.80 ns |  44.950 ns |  42.046 ns |     4.90 |    0.02 |  0.3510 |     - |     - |     744 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  4,444.83 ns |  14.002 ns |  13.097 ns |     1.90 |    0.01 |  0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  2,883.75 ns |   7.730 ns |   7.231 ns |     1.23 |    0.00 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  4,808.85 ns |  20.931 ns |  19.579 ns |     2.05 |    0.01 |  0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  3,127.71 ns |   6.946 ns |   5.800 ns |     1.33 |    0.00 |  0.0191 |     - |     - |      40 B |
