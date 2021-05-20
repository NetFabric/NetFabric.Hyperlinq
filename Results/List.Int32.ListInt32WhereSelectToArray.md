## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |      Median |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    293.9 ns |   2.21 ns |   1.84 ns |    294.2 ns |       baseline |         |  0.4244 |     - |     - |     888 B |
|              ForeachLoop |   100 |    334.8 ns |   6.78 ns |  17.39 ns |    325.8 ns |   1.13x slower |   0.05x |  0.4244 |     - |     - |     888 B |
|                     Linq |   100 |    621.7 ns |  12.07 ns |  16.12 ns |    624.7 ns |   2.10x slower |   0.07x |  0.4015 |     - |     - |     840 B |
|               LinqFaster |   100 |    487.3 ns |   3.87 ns |   3.43 ns |    487.4 ns |   1.66x slower |   0.01x |  0.4244 |     - |     - |     888 B |
|             LinqFasterer |   100 |    450.7 ns |   5.20 ns |   4.86 ns |    448.4 ns |   1.54x slower |   0.02x |  0.4320 |     - |     - |     904 B |
|                   LinqAF |   100 |  1,149.7 ns |  22.62 ns |  28.60 ns |  1,159.5 ns |   3.89x slower |   0.13x |  0.4082 |     - |     - |     856 B |
|            LinqOptimizer |   100 | 54,645.8 ns | 963.33 ns | 804.42 ns | 54,496.5 ns | 185.94x slower |   2.59x | 15.0146 |     - |     - |  31,651 B |
|                 SpanLinq |   100 |    632.5 ns |   9.00 ns |   8.42 ns |    630.6 ns |   2.15x slower |   0.03x |  0.4244 |     - |     - |     888 B |
|                  Streams |   100 |  1,050.4 ns |   6.63 ns |   5.88 ns |  1,048.8 ns |   3.57x slower |   0.03x |  0.6695 |     - |     - |   1,400 B |
|               StructLinq |   100 |    661.9 ns |   6.66 ns |   5.91 ns |    662.3 ns |   2.25x slower |   0.02x |  0.1602 |     - |     - |     336 B |
| StructLinq_ValueDelegate |   100 |    354.6 ns |   3.03 ns |   2.68 ns |    353.6 ns |   1.21x slower |   0.01x |  0.1144 |     - |     - |     240 B |
|                Hyperlinq |   100 |    653.0 ns |   5.05 ns |   4.73 ns |    654.3 ns |   2.22x slower |   0.02x |  0.1144 |     - |     - |     240 B |
|  Hyperlinq_ValueDelegate |   100 |    364.6 ns |   4.06 ns |   3.39 ns |    366.0 ns |   1.24x slower |   0.01x |  0.1144 |     - |     - |     240 B |
