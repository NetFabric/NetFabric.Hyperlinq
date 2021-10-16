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
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |    265.9 ns |   0.27 ns |   0.22 ns |       baseline |         |  0.4244 |     888 B |
|              ForeachLoop |   100 |    264.2 ns |   0.85 ns |   0.71 ns |   1.01x faster |   0.00x |  0.4244 |     888 B |
|                     Linq |   100 |    531.7 ns |   1.24 ns |   1.10 ns |   2.00x slower |   0.00x |  0.3786 |     792 B |
|               LinqFaster |   100 |    352.5 ns |   0.86 ns |   0.72 ns |   1.33x slower |   0.00x |  0.3171 |     664 B |
|             LinqFasterer |   100 |    515.9 ns |   1.35 ns |   1.26 ns |   1.94x slower |   0.00x |  0.3977 |     832 B |
|                   LinqAF |   100 |    635.4 ns |   1.61 ns |   1.35 ns |   2.39x slower |   0.00x |  0.4091 |     856 B |
|            LinqOptimizer |   100 | 47,969.3 ns | 120.77 ns | 112.97 ns | 180.41x slower |   0.51x | 14.5264 |  30,496 B |
|                 SpanLinq |   100 |    538.7 ns |   1.07 ns |   1.00 ns |   2.03x slower |   0.00x |  0.4244 |     888 B |
|                  Streams |   100 |    982.7 ns |   4.92 ns |   4.36 ns |   3.70x slower |   0.02x |  0.6695 |   1,400 B |
|               StructLinq |   100 |    596.9 ns |   0.83 ns |   0.74 ns |   2.25x slower |   0.00x |  0.1602 |     336 B |
| StructLinq_ValueDelegate |   100 |    365.8 ns |   1.00 ns |   0.84 ns |   1.38x slower |   0.00x |  0.1144 |     240 B |
|                Hyperlinq |   100 |    599.2 ns |   1.33 ns |   1.18 ns |   2.25x slower |   0.00x |  0.1144 |     240 B |
|  Hyperlinq_ValueDelegate |   100 |    363.0 ns |   3.61 ns |   3.01 ns |   1.37x slower |   0.01x |  0.1144 |     240 B |
