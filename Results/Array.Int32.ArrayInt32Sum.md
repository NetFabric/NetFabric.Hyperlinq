## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |       Median |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------------:|-------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |     44.23 ns |   0.112 ns |   0.087 ns |     44.26 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |     44.62 ns |   0.358 ns |   0.317 ns |     44.51 ns |   1.01 |    0.01 |      - |     - |     - |         - |
|                     Linq |   100 |    172.57 ns |   0.832 ns |   0.695 ns |    172.49 ns |   3.90 |    0.02 | 0.0153 |     - |     - |      32 B |
|               LinqFaster |   100 |     50.33 ns |   0.347 ns |   0.308 ns |     50.24 ns |   1.14 |    0.01 |      - |     - |     - |         - |
|          LinqFaster_SIMD |   100 |     11.31 ns |   0.094 ns |   0.083 ns |     11.34 ns |   0.26 |    0.00 |      - |     - |     - |         - |
|             LinqFasterer |   100 |     62.85 ns |   0.479 ns |   0.425 ns |     62.74 ns |   1.42 |    0.01 |      - |     - |     - |         - |
|                   LinqAF |   100 |    207.43 ns |   0.646 ns |   0.604 ns |    207.37 ns |   4.69 |    0.02 |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 20,136.74 ns | 192.036 ns | 179.630 ns | 20,169.12 ns | 454.74 |    4.22 | 7.6599 |     - |     - |  16,071 B |
|                  Streams |   100 |    252.85 ns |   4.156 ns |   3.684 ns |    251.21 ns |   5.71 |    0.08 | 0.0992 |     - |     - |     208 B |
|               StructLinq |   100 |     85.85 ns |   0.973 ns |   0.862 ns |     85.91 ns |   1.95 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |     61.66 ns |   0.223 ns |   0.187 ns |     61.62 ns |   1.39 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq |   100 |     21.15 ns |   0.483 ns |   0.610 ns |     21.61 ns |   0.49 |    0.00 |      - |     - |     - |         - |
