## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |       Median |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------------:|-------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |     44.61 ns |   0.195 ns |   0.163 ns |     44.64 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |     45.67 ns |   0.170 ns |   0.132 ns |     45.70 ns |   1.02 |    0.01 |      - |     - |     - |         - |
|                     Linq |   100 |    167.85 ns |   0.843 ns |   0.704 ns |    167.89 ns |   3.76 |    0.02 | 0.0153 |     - |     - |      32 B |
|               LinqFaster |   100 |     51.09 ns |   0.179 ns |   0.158 ns |     51.04 ns |   1.15 |    0.01 |      - |     - |     - |         - |
|          LinqFaster_SIMD |   100 |     11.87 ns |   0.108 ns |   0.095 ns |     11.86 ns |   0.27 |    0.00 |      - |     - |     - |         - |
|             LinqFasterer |   100 |     62.51 ns |   0.515 ns |   0.402 ns |     62.52 ns |   1.40 |    0.01 |      - |     - |     - |         - |
|                   LinqAF |   100 |    207.37 ns |   0.657 ns |   0.582 ns |    207.23 ns |   4.65 |    0.02 |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 20,163.76 ns | 125.998 ns | 105.214 ns | 20,158.52 ns | 452.05 |    2.93 | 7.6599 |     - |     - |  16,071 B |
|                  Streams |   100 |    253.91 ns |   2.440 ns |   1.905 ns |    253.47 ns |   5.69 |    0.05 | 0.0992 |     - |     - |     208 B |
|               StructLinq |   100 |     84.48 ns |   1.626 ns |   1.442 ns |     85.02 ns |   1.90 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |     64.47 ns |   0.190 ns |   0.169 ns |     64.43 ns |   1.44 |    0.01 |      - |     - |     - |         - |
|                Hyperlinq |   100 |     23.42 ns |   0.526 ns |   1.001 ns |     22.96 ns |   0.56 |    0.01 |      - |     - |     - |         - |
