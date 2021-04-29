## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
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
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |     0 |   100 |  46.11 ns | 0.207 ns | 0.173 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |     0 |   100 | 339.97 ns | 2.209 ns | 1.845 ns |  7.37 |    0.05 | 0.0267 |     - |     - |      56 B |
|                     Linq |     0 |   100 | 428.64 ns | 0.603 ns | 0.471 ns |  9.29 |    0.03 | 0.0420 |     - |     - |      88 B |
|               LinqFaster |     0 |   100 | 317.02 ns | 3.048 ns | 2.702 ns |  6.87 |    0.07 | 0.4053 |     - |     - |     848 B |
|          LinqFaster_SIMD |     0 |   100 | 168.58 ns | 2.443 ns | 2.285 ns |  3.66 |    0.05 | 0.4053 |     - |     - |     848 B |
|                   LinqAF |     0 |   100 | 522.75 ns | 1.884 ns | 1.573 ns | 11.34 |    0.05 |      - |     - |     - |         - |
|               StructLinq |     0 |   100 | 207.87 ns | 1.198 ns | 1.001 ns |  4.51 |    0.03 | 0.0114 |     - |     - |      24 B |
| StructLinq_ValueDelegate |     0 |   100 | 165.42 ns | 0.939 ns | 0.878 ns |  3.59 |    0.01 |      - |     - |     - |         - |
|                Hyperlinq |     0 |   100 | 208.99 ns | 0.549 ns | 0.428 ns |  4.53 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |     0 |   100 | 171.51 ns | 0.446 ns | 0.417 ns |  3.72 |    0.01 |      - |     - |     - |         - |
