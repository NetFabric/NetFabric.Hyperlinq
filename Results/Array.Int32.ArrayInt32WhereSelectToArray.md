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

BenchmarkDotNet=v0.13.0, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    262.4 ns |   0.37 ns |   0.31 ns |       baseline |         |  0.4244 |     - |     - |     888 B |
|              ForeachLoop |   100 |    260.7 ns |   0.72 ns |   0.68 ns |   1.01x faster |   0.00x |  0.4244 |     - |     - |     888 B |
|                     Linq |   100 |    506.9 ns |   0.69 ns |   0.61 ns |   1.93x slower |   0.00x |  0.3786 |     - |     - |     792 B |
|               LinqFaster |   100 |    372.6 ns |   0.32 ns |   0.28 ns |   1.42x slower |   0.00x |  0.3171 |     - |     - |     664 B |
|             LinqFasterer |   100 |    546.8 ns |   0.52 ns |   0.43 ns |   2.08x slower |   0.00x |  0.3977 |     - |     - |     832 B |
|                   LinqAF |   100 |    623.0 ns |   1.95 ns |   1.53 ns |   2.37x slower |   0.01x |  0.4091 |     - |     - |     856 B |
|            LinqOptimizer |   100 | 47,436.9 ns | 131.93 ns | 110.17 ns | 180.77x slower |   0.46x | 14.5264 |     - |     - |  30,496 B |
|                 SpanLinq |   100 |    539.5 ns |   3.12 ns |   2.61 ns |   2.06x slower |   0.01x |  0.4244 |     - |     - |     888 B |
|                  Streams |   100 |    995.8 ns |   3.20 ns |   2.68 ns |   3.79x slower |   0.01x |  0.6695 |     - |     - |   1,400 B |
|               StructLinq |   100 |    631.1 ns |   1.34 ns |   1.26 ns |   2.40x slower |   0.01x |  0.1602 |     - |     - |     336 B |
| StructLinq_ValueDelegate |   100 |    372.6 ns |   0.68 ns |   0.60 ns |   1.42x slower |   0.00x |  0.1144 |     - |     - |     240 B |
|                Hyperlinq |   100 |    638.7 ns |   0.82 ns |   0.77 ns |   2.43x slower |   0.01x |  0.1144 |     - |     - |     240 B |
|  Hyperlinq_ValueDelegate |   100 |    454.2 ns |   5.47 ns |   5.12 ns |   1.74x slower |   0.00x |  0.1144 |     - |     - |     240 B |
