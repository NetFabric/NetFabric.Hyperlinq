## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|                   Method | Skip | Count |        Mean |     Error |    StdDev |  Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |------------:|----------:|----------:|-------:|--------:|--------:|--------:|------:|----------:|
|                  ForLoop | 1000 |   100 |    502.6 ns |   3.59 ns |   3.18 ns |   1.00 |    0.00 |       - |       - |     - |         - |
|                     Linq | 1000 |   100 |  1,820.5 ns |  11.18 ns |   9.91 ns |   3.62 |    0.03 |  0.1526 |       - |     - |     320 B |
|               LinqFaster | 1000 |   100 |  2,557.2 ns |  30.39 ns |  26.94 ns |   5.09 |    0.06 | 10.7803 |       - |     - |  22,560 B |
|             LinqFasterer | 1000 |   100 |  1,840.8 ns |  19.17 ns |  17.93 ns |   3.66 |    0.05 |  4.6501 |       - |     - |   9,744 B |
|                   LinqAF | 1000 |   100 |  8,173.7 ns | 162.69 ns | 152.18 ns |  16.23 |    0.33 |       - |       - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 56,914.6 ns | 495.57 ns | 439.31 ns | 113.25 |    0.64 | 57.6782 | 19.2261 |     - | 157,949 B |
|                 SpanLinq | 1000 |   100 |  1,332.5 ns |   4.52 ns |   3.78 ns |   2.65 |    0.01 |       - |       - |     - |         - |
|                  Streams | 1000 |   100 |  8,164.0 ns |  47.55 ns |  44.48 ns |  16.25 |    0.10 |  0.5493 |       - |     - |   1,152 B |
|               StructLinq | 1000 |   100 |    700.8 ns |   2.66 ns |   2.36 ns |   1.39 |    0.01 |  0.0458 |       - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    580.0 ns |   2.29 ns |   2.03 ns |   1.15 |    0.01 |       - |       - |     - |         - |
|                Hyperlinq | 1000 |   100 |  1,122.7 ns |   4.77 ns |   4.23 ns |   2.23 |    0.02 |       - |       - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    810.6 ns |   4.98 ns |   4.42 ns |   1.61 |    0.02 |       - |       - |     - |         - |
