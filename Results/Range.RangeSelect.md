## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Start | Count |      Mean |    Error |   StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------ |----------:|---------:|---------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  44.11 ns | 0.131 ns | 0.116 ns |  44.13 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 512.38 ns | 3.153 ns | 2.949 ns | 511.62 ns | 11.62 |    0.07 | 0.0267 |     - |     - |      56 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 636.52 ns | 1.501 ns | 1.254 ns | 636.19 ns | 14.43 |    0.05 | 0.0420 |     - |     - |      88 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 342.70 ns | 1.980 ns | 1.755 ns | 342.82 ns |  7.77 |    0.04 | 0.4053 |     - |     - |     848 B |
|      LinqFaster_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 170.37 ns | 3.440 ns | 8.175 ns | 165.73 ns |  3.88 |    0.17 | 0.4053 |     - |     - |     848 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 454.66 ns | 0.592 ns | 0.525 ns | 454.64 ns | 10.31 |    0.03 |      - |     - |     - |         - |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 210.70 ns | 1.005 ns | 0.891 ns | 210.66 ns |  4.78 |    0.03 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 166.43 ns | 0.449 ns | 0.420 ns | 166.49 ns |  3.77 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 185.58 ns | 0.438 ns | 0.389 ns | 185.56 ns |  4.21 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 171.47 ns | 0.303 ns | 0.269 ns | 171.53 ns |  3.89 |    0.01 |      - |     - |     - |         - |
|                      |        |                                                                        |          |       |       |           |          |          |           |       |         |        |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  45.65 ns | 0.144 ns | 0.112 ns |  45.61 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 346.89 ns | 2.990 ns | 2.651 ns | 346.09 ns |  7.60 |    0.05 | 0.0267 |     - |     - |      56 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 469.74 ns | 2.088 ns | 1.851 ns | 469.14 ns | 10.29 |    0.04 | 0.0420 |     - |     - |      88 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 317.56 ns | 3.838 ns | 3.402 ns | 316.83 ns |  6.95 |    0.08 | 0.4053 |     - |     - |     848 B |
|      LinqFaster_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 165.32 ns | 1.621 ns | 1.266 ns | 165.31 ns |  3.62 |    0.03 | 0.4053 |     - |     - |     848 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 525.92 ns | 3.969 ns | 3.518 ns | 524.83 ns | 11.53 |    0.09 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 228.02 ns | 1.804 ns | 1.688 ns | 226.91 ns |  5.00 |    0.03 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 165.59 ns | 0.347 ns | 0.325 ns | 165.49 ns |  3.63 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 210.51 ns | 1.984 ns | 1.759 ns | 210.78 ns |  4.62 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 170.27 ns | 0.252 ns | 0.224 ns | 170.24 ns |  3.73 |    0.01 |      - |     - |     - |         - |
