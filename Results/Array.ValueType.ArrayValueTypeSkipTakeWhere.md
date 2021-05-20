## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|                   Method | Skip | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|--------:|------:|----------:|
|                  ForLoop | 1000 |   100 |    519.6 ns |   3.10 ns |   2.90 ns |       baseline |         |       - |       - |     - |         - |
|                     Linq | 1000 |   100 |  1,906.4 ns |  30.24 ns |  28.28 ns |   3.67x slower |   0.06x |  0.1526 |       - |     - |     320 B |
|               LinqFaster | 1000 |   100 |  2,319.1 ns |  31.39 ns |  29.37 ns |   4.46x slower |   0.06x | 10.7803 |       - |     - |  22,560 B |
|             LinqFasterer | 1000 |   100 |  1,861.0 ns |  34.65 ns |  47.43 ns |   3.58x slower |   0.11x |  4.6501 |       - |     - |   9,744 B |
|                   LinqAF | 1000 |   100 |  7,514.3 ns | 136.65 ns | 162.67 ns |  14.57x slower |   0.30x |       - |       - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 60,848.4 ns | 807.66 ns | 755.48 ns | 117.11x slower |   1.70x | 57.6782 | 19.2261 |     - | 157,949 B |
|                 SpanLinq | 1000 |   100 |    781.7 ns |   8.30 ns |   7.35 ns |   1.51x slower |   0.02x |       - |       - |     - |         - |
|                  Streams | 1000 |   100 |  8,555.3 ns | 137.85 ns | 135.38 ns |  16.47x slower |   0.32x |  0.5493 |       - |     - |   1,152 B |
|               StructLinq | 1000 |   100 |    715.5 ns |   4.43 ns |   3.93 ns |   1.38x slower |   0.01x |  0.0458 |       - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    604.8 ns |   2.69 ns |   2.25 ns |   1.16x slower |   0.01x |       - |       - |     - |         - |
|                Hyperlinq | 1000 |   100 |  1,131.3 ns |  10.85 ns |   9.62 ns |   2.18x slower |   0.03x |       - |       - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    836.4 ns |   7.20 ns |   6.74 ns |   1.61x slower |   0.02x |       - |       - |     - |         - |
