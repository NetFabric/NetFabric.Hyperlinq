## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     67.36 ns |   0.196 ns |   0.183 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     67.19 ns |   0.188 ns |   0.176 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    683.68 ns |   3.952 ns |   3.300 ns |  10.15 |    0.06 |  0.0496 |     - |     - |     104 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    363.51 ns |   7.023 ns |   6.897 ns |   5.39 |    0.11 |  0.3171 |     - |     - |     664 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    484.09 ns |   3.504 ns |   3.106 ns |   7.19 |    0.05 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 49,935.64 ns | 487.636 ns | 456.135 ns | 741.35 |    6.27 | 14.2212 |     - |     - |  30,066 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,788.41 ns |   6.348 ns |   5.301 ns |  26.55 |    0.09 |  0.3510 |     - |     - |     736 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    397.17 ns |   1.631 ns |   1.446 ns |   5.90 |    0.03 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    181.72 ns |   0.462 ns |   0.432 ns |   2.70 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    504.21 ns |  10.007 ns |  15.579 ns |   7.51 |    0.22 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    213.61 ns |   0.419 ns |   0.392 ns |   3.17 |    0.01 |       - |     - |     - |         - |
|                      |        |                                                                        |          |       |              |            |            |        |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     66.88 ns |   0.286 ns |   0.268 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     66.91 ns |   0.180 ns |   0.168 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    560.44 ns |   3.932 ns |   3.678 ns |   8.38 |    0.06 |  0.0496 |     - |     - |     104 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    431.51 ns |   2.190 ns |   2.049 ns |   6.45 |    0.04 |  0.3171 |     - |     - |     664 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    464.26 ns |   2.009 ns |   1.678 ns |   6.94 |    0.03 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 44,898.91 ns | 512.252 ns | 479.161 ns | 671.39 |    8.40 | 14.2212 |     - |     - |  29,807 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,497.61 ns |   4.607 ns |   3.847 ns |  22.40 |    0.10 |  0.3510 |     - |     - |     736 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    374.14 ns |   3.872 ns |   3.432 ns |   5.59 |    0.05 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    187.84 ns |   0.897 ns |   0.839 ns |   2.81 |    0.02 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    367.69 ns |   1.031 ns |   0.914 ns |   5.50 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    212.97 ns |   0.455 ns |   0.403 ns |   3.18 |    0.02 |       - |     - |     - |         - |
