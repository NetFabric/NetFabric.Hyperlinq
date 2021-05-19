## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|                   Method | Count |        Mean |       Error |      StdDev |      Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|------------:|------------:|------------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    242.0 ns |     2.13 ns |     1.99 ns |    242.6 ns |   1.00 |    0.00 |  0.4244 |     - |     - |     888 B |
|              ForeachLoop |   100 |    242.1 ns |     1.56 ns |     1.38 ns |    241.8 ns |   1.00 |    0.01 |  0.4244 |     - |     - |     888 B |
|                     Linq |   100 |    541.1 ns |     3.32 ns |     3.10 ns |    540.8 ns |   2.24 |    0.02 |  0.3786 |     - |     - |     792 B |
|               LinqFaster |   100 |    376.2 ns |     2.36 ns |     1.97 ns |    376.4 ns |   1.56 |    0.02 |  0.3171 |     - |     - |     664 B |
|             LinqFasterer |   100 |    493.3 ns |     2.58 ns |     2.29 ns |    493.3 ns |   2.04 |    0.02 |  0.3977 |     - |     - |     832 B |
|                   LinqAF |   100 |    638.1 ns |     4.11 ns |     3.64 ns |    638.0 ns |   2.64 |    0.02 |  0.4091 |     - |     - |     856 B |
|            LinqOptimizer |   100 | 49,696.2 ns | 1,471.62 ns | 4,339.11 ns | 47,041.8 ns | 206.62 |   16.53 | 14.5264 |     - |     - |  30,496 B |
|                 SpanLinq |   100 |    597.7 ns |     3.92 ns |     3.47 ns |    596.6 ns |   2.47 |    0.03 |  0.4244 |     - |     - |     888 B |
|                  Streams |   100 |    968.6 ns |    19.35 ns |    44.06 ns |    943.1 ns |   4.04 |    0.19 |  0.6695 |     - |     - |   1,400 B |
|               StructLinq |   100 |    540.1 ns |     3.32 ns |     2.94 ns |    540.4 ns |   2.23 |    0.02 |  0.1602 |     - |     - |     336 B |
| StructLinq_ValueDelegate |   100 |    335.5 ns |     6.56 ns |     7.29 ns |    336.2 ns |   1.39 |    0.04 |  0.1144 |     - |     - |     240 B |
|                Hyperlinq |   100 |    623.7 ns |     3.52 ns |     3.30 ns |    623.2 ns |   2.58 |    0.02 |  0.1144 |     - |     - |     240 B |
|  Hyperlinq_ValueDelegate |   100 |    356.8 ns |     2.76 ns |     2.45 ns |    357.0 ns |   1.48 |    0.02 |  0.1144 |     - |     - |     240 B |
