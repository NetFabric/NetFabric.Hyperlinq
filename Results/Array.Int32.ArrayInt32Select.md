## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [1.0.0](https://www.nuget.org/packages/SpanLinq/1.0.0)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1538-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |          Mean |         Error |        StdDev |    Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |--------------:|--------------:|--------------:|---------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |      58.56 ns |      0.247 ns |      0.231 ns |     1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |      58.42 ns |      0.125 ns |      0.104 ns |     1.00 |    0.00 |      - |     - |     - |         - |
|                     Linq |   100 |     473.80 ns |      2.337 ns |      1.952 ns |     8.10 |    0.04 | 0.0229 |     - |     - |      48 B |
|               LinqFaster |   100 |     240.40 ns |      1.312 ns |      1.096 ns |     4.11 |    0.02 | 0.2027 |     - |     - |     424 B |
|          LinqFaster_SIMD |   100 |     110.27 ns |      0.795 ns |      0.705 ns |     1.88 |    0.01 | 0.2027 |     - |     - |     424 B |
|             LinqFasterer |   100 |     384.83 ns |      4.339 ns |      3.388 ns |     6.57 |    0.05 | 0.2179 |     - |     - |     456 B |
|                   LinqAF |   100 |     471.40 ns |      3.380 ns |      2.823 ns |     8.06 |    0.06 |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 227,367.01 ns | 12,307.332 ns | 35,705.802 ns | 4,174.27 |  731.48 |      - |     - |     - |  28,056 B |
|                 SpanLinq |   100 |     252.95 ns |      1.391 ns |      1.233 ns |     4.32 |    0.03 |      - |     - |     - |         - |
|                  Streams |   100 |   1,315.09 ns |     10.093 ns |      7.880 ns |    22.47 |    0.16 | 0.2785 |     - |     - |     584 B |
|               StructLinq |   100 |     208.56 ns |      0.853 ns |      0.798 ns |     3.56 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |     176.99 ns |      1.054 ns |      0.823 ns |     3.02 |    0.02 |      - |     - |     - |         - |
|                Hyperlinq |   100 |     234.58 ns |      1.624 ns |      1.356 ns |     4.01 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |     199.17 ns |      0.400 ns |      0.374 ns |     3.40 |    0.02 |      - |     - |     - |         - |
