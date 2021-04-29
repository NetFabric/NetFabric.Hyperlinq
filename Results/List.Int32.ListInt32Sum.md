## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |     85.79 ns |   0.302 ns |   0.268 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |    141.16 ns |   0.675 ns |   0.598 ns |   1.65 |    0.01 |      - |     - |     - |         - |
|                     Linq |   100 |    660.01 ns |   2.047 ns |   1.815 ns |   7.69 |    0.03 | 0.0191 |     - |     - |      40 B |
|               LinqFaster |   100 |     85.92 ns |   0.381 ns |   0.356 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|             LinqFasterer |   100 |     98.58 ns |   1.032 ns |   0.862 ns |   1.15 |    0.01 | 0.2027 |     - |     - |     424 B |
|                   LinqAF |   100 |    439.67 ns |   8.478 ns |  13.930 ns |   5.20 |    0.24 |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 25,376.00 ns | 327.474 ns | 273.455 ns | 295.73 |    3.19 | 8.0566 |     - |     - |  17,017 B |
|                  Streams |   100 |    261.01 ns |   1.363 ns |   1.275 ns |   3.04 |    0.02 | 0.0992 |     - |     - |     208 B |
|               StructLinq |   100 |     84.22 ns |   0.442 ns |   0.413 ns |   0.98 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |     62.59 ns |   0.311 ns |   0.243 ns |   0.73 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq |   100 |     22.79 ns |   0.108 ns |   0.096 ns |   0.27 |    0.00 |      - |     - |     - |         - |
