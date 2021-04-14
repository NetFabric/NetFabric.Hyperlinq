## ImmutableArray.Int32.ImmutableArrayInt32Select

### Source
[ImmutableArrayInt32Select.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Select.cs)

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
|                      Method |    Job |  Runtime | Count |        Mean |     Error |    StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |--------- |------ |------------:|----------:|----------:|-------:|--------:|--------:|------:|------:|----------:|
|                     ForLoop | .NET 5 | .NET 5.0 |  1000 |    536.7 ns |   1.72 ns |   1.60 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 5 | .NET 5.0 |  1000 |    622.2 ns |   5.06 ns |   4.73 ns |   1.16 |    0.01 |       - |     - |     - |         - |
|                        Linq | .NET 5 | .NET 5.0 |  1000 |  6,152.7 ns |  40.10 ns |  33.48 ns |  11.47 |    0.08 |  0.0229 |     - |     - |      48 B |
|               LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 64,454.5 ns | 837.00 ns | 782.93 ns | 120.10 |    1.61 | 15.6250 |     - |     - |  32,723 B |
|                     Streams | .NET 5 | .NET 5.0 |  1000 | 18,650.3 ns | 207.12 ns | 183.61 ns |  34.75 |    0.34 |  0.2747 |     - |     - |     608 B |
|                  StructLinq | .NET 5 | .NET 5.0 |  1000 |  2,916.6 ns |  15.90 ns |  14.10 ns |   5.43 |    0.03 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  1,943.6 ns |   9.01 ns |   7.53 ns |   3.62 |    0.02 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 |  1000 |  2,107.6 ns |   9.12 ns |   8.08 ns |   3.93 |    0.02 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 5 | .NET 5.0 |  1000 |  1,710.3 ns |  15.27 ns |  14.29 ns |   3.19 |    0.03 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 |  1000 |  2,114.7 ns |   6.75 ns |   5.99 ns |   3.94 |    0.02 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 5 | .NET 5.0 |  1000 |  1,574.5 ns |   6.40 ns |   5.35 ns |   2.93 |    0.01 |       - |     - |     - |         - |
|                             |        |          |       |             |           |           |        |         |         |       |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 |  1000 |    546.2 ns |   4.25 ns |   3.98 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 |  1000 |    617.4 ns |   2.14 ns |   1.67 ns |   1.13 |    0.01 |       - |     - |     - |         - |
|                        Linq | .NET 6 | .NET 6.0 |  1000 |  4,788.8 ns |  31.43 ns |  24.54 ns |   8.75 |    0.08 |  0.0229 |     - |     - |      48 B |
|               LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 55,230.4 ns | 310.12 ns | 274.91 ns | 101.09 |    0.84 | 15.3809 |     - |     - |  32,282 B |
|                     Streams | .NET 6 | .NET 6.0 |  1000 | 14,024.0 ns | 123.94 ns | 109.87 ns |  25.67 |    0.20 |  0.2899 |     - |     - |     608 B |
|                  StructLinq | .NET 6 | .NET 6.0 |  1000 |  2,153.9 ns |  21.08 ns |  17.61 ns |   3.94 |    0.02 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1,564.8 ns |   5.30 ns |   4.14 ns |   2.86 |    0.02 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 |  1000 |  1,860.0 ns |   6.02 ns |   5.63 ns |   3.41 |    0.03 |       - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 6 | .NET 6.0 |  1000 |  1,624.2 ns |   3.31 ns |   2.93 ns |   2.97 |    0.03 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 |  1000 |  2,129.6 ns |   7.74 ns |   6.86 ns |   3.90 |    0.03 |       - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 6 | .NET 6.0 |  1000 |    813.5 ns |   7.03 ns |   6.57 ns |   1.49 |    0.01 |       - |     - |     - |         - |
