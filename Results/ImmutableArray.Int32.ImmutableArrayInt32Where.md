## ImmutableArray.Int32.ImmutableArrayInt32Where

### Source
[ImmutableArrayInt32Where.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Where.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |         Mean |      Error |     StdDev |       Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |-------------:|-----------:|-----------:|-------------:|-------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     65.96 ns |   0.122 ns |   0.095 ns |     65.95 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     62.21 ns |   0.152 ns |   0.135 ns |     62.19 ns |   0.94 |    0.00 |       - |     - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    499.09 ns |   2.612 ns |   2.182 ns |    498.88 ns |   7.57 |    0.03 |  0.0229 |     - |     - |      48 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 48,728.32 ns | 357.564 ns | 546.038 ns | 48,628.17 ns | 736.70 |    3.81 | 14.0381 |     - |     - |  29,733 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,994.02 ns |  10.390 ns |   9.210 ns |  1,994.52 ns |  30.24 |    0.13 |  0.2899 |     - |     - |     608 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    618.87 ns |   1.585 ns |   1.482 ns |    618.36 ns |   9.38 |    0.02 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    346.74 ns |   1.279 ns |   1.133 ns |    346.63 ns |   5.26 |    0.02 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    300.37 ns |   3.142 ns |   2.939 ns |    299.70 ns |   4.55 |    0.04 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    201.96 ns |   0.472 ns |   0.369 ns |    201.87 ns |   3.06 |    0.01 |       - |     - |     - |         - |
|                      |        |                                                                        |          |       |              |            |            |              |        |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     66.76 ns |   0.251 ns |   0.234 ns |     66.71 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     69.03 ns |   0.227 ns |   0.212 ns |     69.00 ns |   1.03 |    0.00 |       - |     - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    428.56 ns |   3.258 ns |   2.721 ns |    427.80 ns |   6.42 |    0.05 |  0.0229 |     - |     - |      48 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 42,767.99 ns | 197.751 ns | 165.131 ns | 42,838.56 ns | 640.71 |    3.28 | 13.9771 |     - |     - |  29,291 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,748.04 ns |  18.205 ns |  17.029 ns |  1,751.21 ns |  26.19 |    0.30 |  0.2899 |     - |     - |     608 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    296.42 ns |   5.739 ns |   5.088 ns |    296.19 ns |   4.44 |    0.07 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    182.46 ns |   0.373 ns |   0.331 ns |    182.45 ns |   2.73 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    253.82 ns |   2.256 ns |   2.110 ns |    253.17 ns |   3.80 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    207.44 ns |   4.199 ns |   7.131 ns |    203.45 ns |   3.16 |    0.13 |       - |     - |     - |         - |
