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

BenchmarkDotNet=v0.13.0, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |        Mean |    Error |   StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|---------:|---------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    346.9 ns |  0.58 ns |  0.52 ns |       baseline |         |  0.4244 |     - |     - |     888 B |
|              ForeachLoop |   100 |    335.2 ns |  0.80 ns |  0.71 ns |   1.04x faster |   0.00x |  0.4244 |     - |     - |     888 B |
|                     Linq |   100 |    583.9 ns |  1.66 ns |  1.38 ns |   1.68x slower |   0.00x |  0.4015 |     - |     - |     840 B |
|               LinqFaster |   100 |    533.7 ns |  1.93 ns |  1.81 ns |   1.54x slower |   0.00x |  0.4244 |     - |     - |     888 B |
|             LinqFasterer |   100 |    448.8 ns |  1.39 ns |  1.23 ns |   1.29x slower |   0.00x |  0.4320 |     - |     - |     904 B |
|                   LinqAF |   100 |    663.1 ns |  0.91 ns |  0.85 ns |   1.91x slower |   0.00x |  0.4091 |     - |     - |     856 B |
|            LinqOptimizer |   100 | 53,389.7 ns | 68.40 ns | 57.12 ns | 153.92x slower |   0.26x | 15.0757 |     - |     - |  31,572 B |
|                 SpanLinq |   100 |    600.1 ns |  1.04 ns |  0.93 ns |   1.73x slower |   0.00x |  0.4244 |     - |     - |     888 B |
|                  Streams |   100 |  1,036.3 ns |  2.60 ns |  2.30 ns |   2.99x slower |   0.01x |  0.6695 |     - |     - |   1,400 B |
|               StructLinq |   100 |    661.3 ns |  1.31 ns |  1.23 ns |   1.91x slower |   0.00x |  0.1602 |     - |     - |     336 B |
| StructLinq_ValueDelegate |   100 |    329.9 ns |  1.04 ns |  0.97 ns |   1.05x faster |   0.00x |  0.1144 |     - |     - |     240 B |
|                Hyperlinq |   100 |    640.9 ns |  0.76 ns |  0.71 ns |   1.85x slower |   0.00x |  0.1144 |     - |     - |     240 B |
|  Hyperlinq_ValueDelegate |   100 |    440.7 ns |  0.20 ns |  0.17 ns |   1.27x slower |   0.00x |  0.1144 |     - |     - |     240 B |
