## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
|                      Method |    Job |  Runtime | Count |        Mean |       Error |      StdDev |      Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |--------- |------ |------------:|------------:|------------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|                     ForLoop | .NET 5 | .NET 5.0 |  1000 |    796.1 ns |     4.60 ns |     3.84 ns |    795.9 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  2,115.5 ns |    13.11 ns |    11.62 ns |  2,116.6 ns |  2.66 |    0.02 |       - |     - |     - |         - |
|                        Linq | .NET 5 | .NET 5.0 |  1000 |  7,949.5 ns |    35.83 ns |    29.92 ns |  7,956.5 ns |  9.99 |    0.06 |  0.0305 |     - |     - |      72 B |
|                  LinqFaster | .NET 5 | .NET 5.0 |  1000 |  3,658.0 ns |    59.49 ns |    55.64 ns |  3,670.9 ns |  4.60 |    0.06 |  1.9379 |     - |     - |   4,056 B |
|                      LinqAF | .NET 5 | .NET 5.0 |  1000 |  7,622.4 ns |    21.72 ns |    19.25 ns |  7,618.8 ns |  9.57 |    0.05 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 58,216.5 ns | 1,588.16 ns | 4,682.74 ns | 54,715.3 ns | 69.63 |    3.19 | 15.3809 |     - |     - |  32,257 B |
|                     Streams | .NET 5 | .NET 5.0 |  1000 | 14,610.1 ns |    70.65 ns |    59.00 ns | 14,614.1 ns | 18.35 |    0.09 |  0.2899 |     - |     - |     608 B |
|                  StructLinq | .NET 5 | .NET 5.0 |  1000 |  1,877.3 ns |     4.84 ns |     4.29 ns |  1,877.1 ns |  2.36 |    0.01 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  1,513.3 ns |     2.93 ns |     2.44 ns |  1,513.7 ns |  1.90 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 |  1000 |  2,135.5 ns |    16.81 ns |    14.90 ns |  2,132.4 ns |  2.68 |    0.02 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 5 | .NET 5.0 |  1000 |  1,676.9 ns |     3.26 ns |     2.72 ns |  1,676.7 ns |  2.11 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 |  1000 |  2,338.0 ns |    17.53 ns |    16.39 ns |  2,337.4 ns |  2.94 |    0.02 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 5 | .NET 5.0 |  1000 |  1,572.3 ns |     5.88 ns |     4.59 ns |  1,571.7 ns |  1.98 |    0.01 |       - |     - |     - |         - |
|                             |        |          |       |             |             |             |             |       |         |         |       |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 |  1000 |    794.3 ns |     3.28 ns |     3.07 ns |    794.4 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  1,312.6 ns |     4.85 ns |     4.30 ns |  1,312.3 ns |  1.65 |    0.01 |       - |     - |     - |         - |
|                        Linq | .NET 6 | .NET 6.0 |  1000 |  6,290.5 ns |    33.60 ns |    29.79 ns |  6,282.4 ns |  7.92 |    0.05 |  0.0305 |     - |     - |      72 B |
|                  LinqFaster | .NET 6 | .NET 6.0 |  1000 |  3,523.9 ns |    18.93 ns |    14.78 ns |  3,526.7 ns |  4.44 |    0.03 |  1.9379 |     - |     - |   4,056 B |
|                      LinqAF | .NET 6 | .NET 6.0 |  1000 |  7,655.0 ns |    25.33 ns |    21.15 ns |  7,659.9 ns |  9.64 |    0.04 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 49,259.1 ns |   513.20 ns |   951.26 ns | 48,938.8 ns | 61.90 |    1.35 | 15.1978 |     - |     - |  31,816 B |
|                     Streams | .NET 6 | .NET 6.0 |  1000 | 11,908.5 ns |    72.04 ns |    67.39 ns | 11,884.3 ns | 14.99 |    0.09 |  0.2899 |     - |     - |     608 B |
|                  StructLinq | .NET 6 | .NET 6.0 |  1000 |  1,873.6 ns |     7.70 ns |     6.83 ns |  1,872.3 ns |  2.36 |    0.01 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1,511.1 ns |     3.25 ns |     2.72 ns |  1,511.7 ns |  1.90 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 |  1000 |  2,126.9 ns |    12.38 ns |    10.34 ns |  2,125.0 ns |  2.68 |    0.02 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 6 | .NET 6.0 |  1000 |  1,703.3 ns |     3.52 ns |     3.29 ns |  1,702.9 ns |  2.14 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 |  1000 |  2,348.7 ns |     9.10 ns |     7.10 ns |  2,348.6 ns |  2.96 |    0.02 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 6 | .NET 6.0 |  1000 |  1,571.6 ns |     4.98 ns |     4.41 ns |  1,572.0 ns |  1.98 |    0.01 |       - |     - |     - |         - |
