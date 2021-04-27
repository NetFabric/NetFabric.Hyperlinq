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
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|      Method |    Job |                                                   EnvironmentVariables |  Runtime | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------- |----------------------------------------------------------------------- |--------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 293.80 ns | 1.663 ns | 1.298 ns |  1.00 |    0.00 | 0.5660 |     - |     - |   1,184 B |
| ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 766.37 ns | 4.739 ns | 4.201 ns |  2.61 |    0.02 | 0.5922 |     - |     - |   1,240 B |
|        Linq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 207.56 ns | 0.596 ns | 0.498 ns |  0.71 |    0.00 | 0.2370 |     - |     - |     496 B |
|  LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 115.63 ns | 0.837 ns | 0.822 ns |  0.39 |    0.00 | 0.4206 |     - |     - |     880 B |
|      LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 345.47 ns | 1.535 ns | 1.436 ns |  1.18 |    0.01 | 0.2179 |     - |     - |     456 B |
|  StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  87.55 ns | 0.370 ns | 0.346 ns |  0.30 |    0.00 | 0.2180 |     - |     - |     456 B |
|   Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  51.21 ns | 0.173 ns | 0.144 ns |  0.17 |    0.00 | 0.2180 |     - |     - |     456 B |
|             |        |                                                                        |          |       |       |           |          |          |       |         |        |       |       |           |
|     ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 289.79 ns | 1.291 ns | 1.145 ns |  1.00 |    0.00 | 0.5660 |     - |     - |   1,184 B |
| ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 513.08 ns | 5.272 ns | 4.932 ns |  1.77 |    0.02 | 0.5922 |     - |     - |   1,240 B |
|        Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 183.78 ns | 1.153 ns | 0.963 ns |  0.63 |    0.00 | 0.2370 |     - |     - |     496 B |
|  LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 122.91 ns | 0.940 ns | 0.734 ns |  0.42 |    0.00 | 0.4206 |     - |     - |     880 B |
|      LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 262.20 ns | 3.803 ns | 3.175 ns |  0.91 |    0.01 | 0.2179 |     - |     - |     456 B |
|  StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  87.54 ns | 1.152 ns | 0.962 ns |  0.30 |    0.00 | 0.2180 |     - |     - |     456 B |
|   Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  52.49 ns | 0.528 ns | 0.494 ns |  0.18 |    0.00 | 0.2180 |     - |     - |     456 B |
