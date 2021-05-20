## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|                   Method | Count |        Mean |       Error |      StdDev |      Median |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|------------:|------------:|------------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    254.6 ns |     1.59 ns |     1.41 ns |    254.5 ns |       baseline |         |  0.4244 |     - |     - |     888 B |
|              ForeachLoop |   100 |    250.3 ns |     2.96 ns |     2.62 ns |    249.6 ns |   1.02x faster |   0.01x |  0.4244 |     - |     - |     888 B |
|                     Linq |   100 |    571.6 ns |     4.02 ns |     3.35 ns |    570.9 ns |   2.25x slower |   0.02x |  0.3786 |     - |     - |     792 B |
|               LinqFaster |   100 |    399.3 ns |     4.47 ns |     4.18 ns |    398.9 ns |   1.57x slower |   0.02x |  0.3171 |     - |     - |     664 B |
|             LinqFasterer |   100 |    540.5 ns |     4.05 ns |     3.59 ns |    540.7 ns |   2.12x slower |   0.02x |  0.3977 |     - |     - |     832 B |
|                   LinqAF |   100 |    663.0 ns |     5.20 ns |     4.35 ns |    663.8 ns |   2.60x slower |   0.02x |  0.4091 |     - |     - |     856 B |
|            LinqOptimizer |   100 | 51,260.0 ns | 1,575.40 ns | 4,645.11 ns | 48,363.0 ns | 213.33x slower |  15.00x | 14.5264 |     - |     - |  30,496 B |
|                 SpanLinq |   100 |    640.9 ns |    11.80 ns |    10.46 ns |    639.7 ns |   2.52x slower |   0.05x |  0.4244 |     - |     - |     888 B |
|                  Streams |   100 |  1,159.4 ns |    23.11 ns |    54.92 ns |  1,154.3 ns |   4.48x slower |   0.18x |  0.6695 |     - |     - |   1,400 B |
|               StructLinq |   100 |    569.4 ns |     6.46 ns |     5.72 ns |    568.9 ns |   2.24x slower |   0.02x |  0.1602 |     - |     - |     336 B |
| StructLinq_ValueDelegate |   100 |    323.9 ns |     3.29 ns |     2.91 ns |    323.3 ns |   1.27x slower |   0.01x |  0.1144 |     - |     - |     240 B |
|                Hyperlinq |   100 |    618.8 ns |    12.32 ns |    16.87 ns |    618.2 ns |   2.42x slower |   0.09x |  0.1144 |     - |     - |     240 B |
|  Hyperlinq_ValueDelegate |   100 |    360.7 ns |     3.95 ns |     3.69 ns |    359.5 ns |   1.42x slower |   0.02x |  0.1144 |     - |     - |     240 B |
