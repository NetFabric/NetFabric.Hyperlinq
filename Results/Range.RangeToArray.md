## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

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
|          Method |    Job |                                                   EnvironmentVariables |  Runtime | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------- |----------------------------------------------------------------------- |--------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|         ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 129.08 ns | 0.480 ns | 0.425 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|            Linq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  84.94 ns | 0.248 ns | 0.220 ns |  0.66 |    0.00 | 0.2218 |     - |     - |     464 B |
|      LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  77.88 ns | 1.552 ns | 1.211 ns |  0.60 |    0.01 | 0.2027 |     - |     - |     424 B |
| LinqFaster_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  36.62 ns | 0.448 ns | 0.419 ns |  0.28 |    0.00 | 0.2027 |     - |     - |     424 B |
|          LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 262.37 ns | 0.537 ns | 0.448 ns |  2.03 |    0.01 | 0.2027 |     - |     - |     424 B |
|      StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  81.53 ns | 0.417 ns | 0.369 ns |  0.63 |    0.00 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  42.66 ns | 0.353 ns | 0.330 ns |  0.33 |    0.00 | 0.2027 |     - |     - |     424 B |
|                 |        |                                                                        |          |       |       |           |          |          |       |         |        |       |       |           |
|         ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  79.41 ns | 0.566 ns | 0.529 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|            Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  80.90 ns | 1.089 ns | 0.910 ns |  1.02 |    0.01 | 0.2218 |     - |     - |     464 B |
|      LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  69.34 ns | 1.420 ns | 1.259 ns |  0.87 |    0.02 | 0.2027 |     - |     - |     424 B |
| LinqFaster_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  37.99 ns | 0.480 ns | 0.449 ns |  0.48 |    0.01 | 0.2027 |     - |     - |     424 B |
|          LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 202.34 ns | 0.481 ns | 0.402 ns |  2.55 |    0.02 | 0.2027 |     - |     - |     424 B |
|      StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  79.47 ns | 0.846 ns | 0.792 ns |  1.00 |    0.01 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  44.05 ns | 0.649 ns | 0.608 ns |  0.55 |    0.01 | 0.2027 |     - |     - |     424 B |
