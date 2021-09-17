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
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1417) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.1.21458.32
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |    273.9 ns |   2.42 ns |   2.15 ns |       baseline |         |  0.4244 |     888 B |
|              ForeachLoop |   100 |    279.6 ns |   1.45 ns |   1.28 ns |   1.02x slower |   0.01x |  0.4244 |     888 B |
|                     Linq |   100 |    507.3 ns |   3.48 ns |   3.09 ns |   1.85x slower |   0.02x |  0.3786 |     792 B |
|               LinqFaster |   100 |    454.8 ns |   1.99 ns |   1.86 ns |   1.66x slower |   0.02x |  0.3171 |     664 B |
|             LinqFasterer |   100 |    512.9 ns |   0.74 ns |   0.58 ns |   1.88x slower |   0.01x |  0.3977 |     832 B |
|                   LinqAF |   100 |    620.7 ns |   1.33 ns |   1.04 ns |   2.27x slower |   0.02x |  0.4091 |     856 B |
|            LinqOptimizer |   100 | 47,977.7 ns | 271.75 ns | 254.19 ns | 175.21x slower |   1.95x | 14.5264 |  30,496 B |
|                 SpanLinq |   100 |    570.2 ns |   3.60 ns |   3.19 ns |   2.08x slower |   0.02x |  0.4244 |     888 B |
|                  Streams |   100 |    975.2 ns |   1.47 ns |   1.15 ns |   3.57x slower |   0.03x |  0.6695 |   1,400 B |
|               StructLinq |   100 |    631.2 ns |   2.41 ns |   2.13 ns |   2.30x slower |   0.02x |  0.1602 |     336 B |
| StructLinq_ValueDelegate |   100 |    361.3 ns |   0.53 ns |   0.41 ns |   1.32x slower |   0.01x |  0.1144 |     240 B |
|                Hyperlinq |   100 |    574.8 ns |   0.78 ns |   0.61 ns |   2.10x slower |   0.02x |  0.1144 |     240 B |
|  Hyperlinq_ValueDelegate |   100 |    369.8 ns |   2.11 ns |   1.98 ns |   1.35x slower |   0.01x |  0.1144 |     240 B |
