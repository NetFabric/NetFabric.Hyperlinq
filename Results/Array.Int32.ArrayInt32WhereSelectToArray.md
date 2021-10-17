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
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |       Mean |   Error |  StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-----------:|--------:|--------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |   264.8 ns | 2.26 ns | 2.00 ns |     baseline |         | 0.4244 |     888 B |
|              ForeachLoop |   100 |   260.3 ns | 1.72 ns | 1.61 ns | 1.02x faster |   0.01x | 0.4244 |     888 B |
|                     Linq |   100 |   550.7 ns | 3.50 ns | 3.27 ns | 2.08x slower |   0.02x | 0.3786 |     792 B |
|               LinqFaster |   100 |   395.7 ns | 2.90 ns | 2.71 ns | 1.49x slower |   0.01x | 0.3171 |     664 B |
|             LinqFasterer |   100 |   495.2 ns | 2.27 ns | 2.01 ns | 1.87x slower |   0.02x | 0.3977 |     832 B |
|                   LinqAF |   100 |   618.7 ns | 2.47 ns | 2.19 ns | 2.34x slower |   0.02x | 0.4091 |     856 B |
|            LinqOptimizer |   100 | 1,428.3 ns | 8.71 ns | 8.15 ns | 5.39x slower |   0.05x | 4.1313 |   8,650 B |
|                 SpanLinq |   100 |   547.7 ns | 1.39 ns | 1.09 ns | 2.07x slower |   0.02x | 0.4244 |     888 B |
|                  Streams |   100 |   964.1 ns | 6.53 ns | 5.46 ns | 3.64x slower |   0.04x | 0.6695 |   1,400 B |
|               StructLinq |   100 |   603.9 ns | 4.15 ns | 3.46 ns | 2.28x slower |   0.02x | 0.1602 |     336 B |
| StructLinq_ValueDelegate |   100 |   363.5 ns | 1.76 ns | 1.56 ns | 1.37x slower |   0.01x | 0.1144 |     240 B |
|                Hyperlinq |   100 |   591.9 ns | 4.16 ns | 3.48 ns | 2.24x slower |   0.02x | 0.1144 |     240 B |
|  Hyperlinq_ValueDelegate |   100 |   375.4 ns | 1.75 ns | 1.46 ns | 1.42x slower |   0.01x | 0.1144 |     240 B |
