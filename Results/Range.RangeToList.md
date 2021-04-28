## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|      Method |    Job |                                                   EnvironmentVariables |  Runtime | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------- |----------------------------------------------------------------------- |--------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 336.81 ns | 3.110 ns | 2.757 ns |  1.00 |    0.00 | 0.5660 |     - |     - |   1,184 B |
| ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 751.66 ns | 3.845 ns | 3.408 ns |  2.23 |    0.02 | 0.5922 |     - |     - |   1,240 B |
|        Linq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 230.40 ns | 3.166 ns | 2.644 ns |  0.68 |    0.01 | 0.2370 |     - |     - |     496 B |
|  LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 123.19 ns | 1.343 ns | 1.257 ns |  0.37 |    0.01 | 0.4206 |     - |     - |     880 B |
|      LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 350.98 ns | 1.687 ns | 1.578 ns |  1.04 |    0.01 | 0.2179 |     - |     - |     456 B |
|  StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 102.45 ns | 1.321 ns | 1.236 ns |  0.30 |    0.00 | 0.2180 |     - |     - |     456 B |
|   Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  53.98 ns | 0.642 ns | 0.536 ns |  0.16 |    0.00 | 0.2180 |     - |     - |     456 B |
|             |        |                                                                        |          |       |       |           |          |          |       |         |        |       |       |           |
|     ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 297.84 ns | 5.693 ns | 5.325 ns |  1.00 |    0.00 | 0.5660 |     - |     - |   1,184 B |
| ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 578.97 ns | 6.420 ns | 6.006 ns |  1.94 |    0.03 | 0.5922 |     - |     - |   1,240 B |
|        Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 190.79 ns | 2.427 ns | 2.151 ns |  0.64 |    0.02 | 0.2370 |     - |     - |     496 B |
|  LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 131.10 ns | 1.971 ns | 1.843 ns |  0.44 |    0.01 | 0.4206 |     - |     - |     880 B |
|      LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 277.86 ns | 5.524 ns | 8.435 ns |  0.92 |    0.04 | 0.2179 |     - |     - |     456 B |
|  StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  92.15 ns | 1.368 ns | 1.213 ns |  0.31 |    0.01 | 0.2180 |     - |     - |     456 B |
|   Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  59.16 ns | 1.265 ns | 2.345 ns |  0.19 |    0.01 | 0.2180 |     - |     - |     456 B |
