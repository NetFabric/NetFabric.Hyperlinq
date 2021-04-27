## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

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
|          Method |    Job |                                                   EnvironmentVariables |  Runtime | Start | Count |      Mean |    Error |   StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------- |----------------------------------------------------------------------- |--------- |------ |------ |----------:|---------:|---------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|         ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  33.72 ns | 0.125 ns | 0.111 ns |  33.70 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|     ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 504.32 ns | 8.256 ns | 6.894 ns | 500.84 ns | 14.96 |    0.22 | 0.0267 |     - |     - |      56 B |
|            Linq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 449.32 ns | 3.131 ns | 2.615 ns | 449.71 ns | 13.33 |    0.09 | 0.0191 |     - |     - |      40 B |
|      LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 128.09 ns | 2.400 ns | 2.128 ns | 128.90 ns |  3.80 |    0.07 | 0.2027 |     - |     - |     424 B |
| LinqFaster_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 100.68 ns | 1.027 ns | 0.910 ns | 100.57 ns |  2.99 |    0.03 | 0.2027 |     - |     - |     424 B |
|          LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 199.56 ns | 0.288 ns | 0.241 ns | 199.53 ns |  5.92 |    0.02 |      - |     - |     - |         - |
|      StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  34.23 ns | 0.065 ns | 0.054 ns |  34.23 ns |  1.02 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  60.42 ns | 0.353 ns | 0.313 ns |  60.45 ns |  1.79 |    0.01 |      - |     - |     - |         - |
|                 |        |                                                                        |          |       |       |           |          |          |           |       |         |        |       |       |           |
|         ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  37.16 ns | 0.087 ns | 0.078 ns |  37.15 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|     ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 311.70 ns | 1.451 ns | 1.287 ns | 311.43 ns |  8.39 |    0.04 | 0.0267 |     - |     - |      56 B |
|            Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 255.31 ns | 1.076 ns | 0.899 ns | 255.25 ns |  6.87 |    0.03 | 0.0191 |     - |     - |      40 B |
|      LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 140.96 ns | 0.528 ns | 0.494 ns | 140.94 ns |  3.79 |    0.01 | 0.2027 |     - |     - |     424 B |
| LinqFaster_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 101.72 ns | 1.666 ns | 1.558 ns | 101.57 ns |  2.74 |    0.04 | 0.2027 |     - |     - |     424 B |
|          LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 165.49 ns | 0.166 ns | 0.155 ns | 165.47 ns |  4.45 |    0.01 |      - |     - |     - |         - |
|      StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  36.37 ns | 0.075 ns | 0.067 ns |  36.37 ns |  0.98 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  42.11 ns | 0.899 ns | 1.575 ns |  41.06 ns |  1.19 |    0.02 |      - |     - |     - |         - |
