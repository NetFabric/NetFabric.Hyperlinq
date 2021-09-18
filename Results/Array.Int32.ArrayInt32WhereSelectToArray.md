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
- NetFabric.Hyperlinq: [3.0.0-beta46](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta46)
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
|                  ForLoop |   100 |    259.9 ns |   0.62 ns |   0.48 ns |       baseline |         |  0.4244 |     888 B |
|              ForeachLoop |   100 |    260.1 ns |   0.65 ns |   0.54 ns |   1.00x slower |   0.00x |  0.4244 |     888 B |
|                     Linq |   100 |    504.4 ns |   0.63 ns |   0.53 ns |   1.94x slower |   0.00x |  0.3786 |     792 B |
|               LinqFaster |   100 |    383.1 ns |   0.67 ns |   0.63 ns |   1.47x slower |   0.00x |  0.3171 |     664 B |
|             LinqFasterer |   100 |    517.6 ns |   1.45 ns |   1.28 ns |   1.99x slower |   0.01x |  0.3977 |     832 B |
|                   LinqAF |   100 |  6,697.1 ns | 123.32 ns | 275.81 ns |  25.83x slower |   1.12x |       - |   1,528 B |
|            LinqOptimizer |   100 | 47,431.3 ns | 172.25 ns | 143.84 ns | 182.53x slower |   0.59x | 14.5264 |  30,496 B |
|                 SpanLinq |   100 |    561.4 ns |   1.05 ns |   0.93 ns |   2.16x slower |   0.01x |  0.4244 |     888 B |
|                  Streams |   100 |    989.8 ns |   1.16 ns |   1.09 ns |   3.81x slower |   0.01x |  0.6695 |   1,400 B |
|               StructLinq |   100 |    638.2 ns |   1.79 ns |   1.68 ns |   2.46x slower |   0.01x |  0.1602 |     336 B |
| StructLinq_ValueDelegate |   100 |    377.1 ns |   0.69 ns |   0.61 ns |   1.45x slower |   0.00x |  0.1144 |     240 B |
|                Hyperlinq |   100 |    582.1 ns |   0.79 ns |   0.70 ns |   2.24x slower |   0.01x |  0.1144 |     240 B |
|  Hyperlinq_ValueDelegate |   100 |    362.7 ns |   7.27 ns |   8.65 ns |   1.40x slower |   0.04x |  0.1144 |     240 B |
