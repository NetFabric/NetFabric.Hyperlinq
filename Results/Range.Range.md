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
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT


```
|          Method |    Job |                                                   EnvironmentVariables |  Runtime | Start | Count |      Mean |    Error |   StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------- |----------------------------------------------------------------------- |--------- |------ |------ |----------:|---------:|---------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|         ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  34.00 ns | 0.155 ns | 0.145 ns |  34.00 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|     ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 451.51 ns | 2.888 ns | 2.560 ns | 451.60 ns | 13.28 |    0.09 | 0.0267 |     - |     - |      56 B |
|            Linq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 454.99 ns | 3.617 ns | 3.206 ns | 455.75 ns | 13.39 |    0.10 | 0.0191 |     - |     - |      40 B |
|      LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 127.61 ns | 2.588 ns | 2.876 ns | 126.06 ns |  3.75 |    0.09 | 0.2027 |     - |     - |     424 B |
| LinqFaster_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 102.57 ns | 1.266 ns | 1.122 ns | 102.72 ns |  3.02 |    0.03 | 0.2027 |     - |     - |     424 B |
|          LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 200.87 ns | 0.898 ns | 0.796 ns | 201.04 ns |  5.91 |    0.04 |      - |     - |     - |         - |
|      StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  34.31 ns | 0.213 ns | 0.189 ns |  34.30 ns |  1.01 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  44.08 ns | 0.183 ns | 0.162 ns |  44.04 ns |  1.30 |    0.01 |      - |     - |     - |         - |
|                 |        |                                                                        |          |       |       |           |          |          |           |       |         |        |       |       |           |
|         ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  36.98 ns | 0.155 ns | 0.145 ns |  36.95 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|     ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 316.21 ns | 1.330 ns | 1.244 ns | 316.39 ns |  8.55 |    0.05 | 0.0267 |     - |     - |      56 B |
|            Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 258.98 ns | 1.100 ns | 0.975 ns | 259.06 ns |  7.00 |    0.04 | 0.0191 |     - |     - |      40 B |
|      LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 130.70 ns | 2.570 ns | 2.524 ns | 131.02 ns |  3.53 |    0.07 | 0.2027 |     - |     - |     424 B |
| LinqFaster_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 110.67 ns | 0.671 ns | 0.627 ns | 110.73 ns |  2.99 |    0.02 | 0.2027 |     - |     - |     424 B |
|          LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 164.88 ns | 0.394 ns | 0.369 ns | 164.73 ns |  4.46 |    0.02 |      - |     - |     - |         - |
|      StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  32.99 ns | 0.119 ns | 0.229 ns |  32.96 ns |  0.89 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  42.00 ns | 0.893 ns | 1.467 ns |  40.93 ns |  1.18 |    0.02 |      - |     - |     - |         - |
