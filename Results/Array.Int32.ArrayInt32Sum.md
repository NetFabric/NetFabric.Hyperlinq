## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |         Mean |      Error |     StdDev |       Median |          Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------------:|---------------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |     46.56 ns |   0.355 ns |   0.332 ns |     46.49 ns |       baseline |         |      - |     - |     - |         - |
|              ForeachLoop |   100 |     47.28 ns |   0.311 ns |   0.276 ns |     47.28 ns |   1.02x slower |   0.01x |      - |     - |     - |         - |
|                     Linq |   100 |    175.15 ns |   3.491 ns |   3.429 ns |    175.58 ns |   3.77x slower |   0.08x | 0.0153 |     - |     - |      32 B |
|               LinqFaster |   100 |     53.19 ns |   0.272 ns |   0.241 ns |     53.19 ns |   1.14x slower |   0.01x |      - |     - |     - |         - |
|          LinqFaster_SIMD |   100 |     12.69 ns |   0.151 ns |   0.134 ns |     12.66 ns |   3.67x faster |   0.05x |      - |     - |     - |         - |
|             LinqFasterer |   100 |     64.86 ns |   0.376 ns |   0.314 ns |     64.81 ns |   1.39x slower |   0.01x |      - |     - |     - |         - |
|                   LinqAF |   100 |    215.87 ns |   1.162 ns |   1.087 ns |    215.83 ns |   4.64x slower |   0.04x |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 21,753.99 ns | 244.667 ns | 204.308 ns | 21,693.60 ns | 467.05x slower |   5.00x | 7.6599 |     - |     - |  16,071 B |
|                  Streams |   100 |    269.73 ns |   5.389 ns |  11.129 ns |    264.50 ns |   6.14x slower |   0.12x | 0.0992 |     - |     - |     208 B |
|               StructLinq |   100 |     84.92 ns |   0.433 ns |   0.384 ns |     84.92 ns |   1.82x slower |   0.01x | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |     66.98 ns |   0.319 ns |   0.283 ns |     67.07 ns |   1.44x slower |   0.01x |      - |     - |     - |         - |
|                Hyperlinq |   100 |     23.69 ns |   0.355 ns |   0.332 ns |     23.70 ns |   1.97x faster |   0.03x |      - |     - |     - |         - |
