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
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT


```
|          Method |    Job |                                                   EnvironmentVariables |  Runtime | Start | Count |      Mean |    Error |   StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------- |----------------------------------------------------------------------- |--------- |------ |------ |----------:|---------:|---------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|         ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 141.08 ns | 2.891 ns | 6.161 ns | 144.75 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|            Linq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  88.74 ns | 1.014 ns | 0.847 ns |  88.83 ns |  0.64 |    0.03 | 0.2218 |     - |     - |     464 B |
|      LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  81.58 ns | 1.272 ns | 1.190 ns |  81.76 ns |  0.59 |    0.03 | 0.2027 |     - |     - |     424 B |
| LinqFaster_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  41.85 ns | 0.899 ns | 2.445 ns |  40.62 ns |  0.30 |    0.02 | 0.2027 |     - |     - |     424 B |
|          LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 | 290.99 ns | 2.724 ns | 2.548 ns | 290.28 ns |  2.09 |    0.10 | 0.2027 |     - |     - |     424 B |
|      StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  85.83 ns | 1.345 ns | 1.193 ns |  85.60 ns |  0.62 |    0.02 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |     0 |   100 |  45.98 ns | 0.927 ns | 0.952 ns |  46.09 ns |  0.33 |    0.01 | 0.2027 |     - |     - |     424 B |
|                 |        |                                                                        |          |       |       |           |          |          |           |       |         |        |       |       |           |
|         ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  87.69 ns | 1.802 ns | 2.910 ns |  88.78 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|            Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  85.44 ns | 1.053 ns | 0.985 ns |  85.74 ns |  1.00 |    0.04 | 0.2218 |     - |     - |     464 B |
|      LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  77.15 ns | 1.602 ns | 2.397 ns |  77.20 ns |  0.88 |    0.04 | 0.2027 |     - |     - |     424 B |
| LinqFaster_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  41.19 ns | 0.884 ns | 0.827 ns |  41.27 ns |  0.48 |    0.02 | 0.2027 |     - |     - |     424 B |
|          LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 | 205.76 ns | 0.937 ns | 0.876 ns | 205.51 ns |  2.41 |    0.09 | 0.2027 |     - |     - |     424 B |
|      StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  85.04 ns | 1.786 ns | 3.994 ns |  83.02 ns |  1.00 |    0.03 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |     0 |   100 |  46.65 ns | 1.029 ns | 2.505 ns |  45.76 ns |  0.55 |    0.02 | 0.2027 |     - |     - |     424 B |
