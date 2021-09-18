## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|                   Method | Skip | Count |        Mean |       Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |----- |------ |------------:|------------:|----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop | 1000 |   100 |    443.5 ns |     0.46 ns |   0.43 ns |       baseline |         |       - |         - |
|                     Linq | 1000 |   100 |  1,564.3 ns |     1.14 ns |   1.07 ns |   3.53x slower |   0.00x |  0.1526 |     320 B |
|               LinqFaster | 1000 |   100 |  2,436.9 ns |     9.13 ns |   7.63 ns |   5.49x slower |   0.02x | 10.7803 |  22,560 B |
|             LinqFasterer | 1000 |   100 |  1,861.0 ns |     3.68 ns |   3.44 ns |   4.20x slower |   0.01x |  4.6501 |   9,744 B |
|                   LinqAF | 1000 |   100 |  6,269.4 ns |    67.43 ns |  59.78 ns |  14.13x slower |   0.13x |       - |         - |
|            LinqOptimizer | 1000 |   100 | 63,812.8 ns | 1,041.80 ns | 974.50 ns | 143.87x slower |   2.23x | 73.9746 | 157,823 B |
|                 SpanLinq | 1000 |   100 |    752.0 ns |     5.19 ns |   4.60 ns |   1.70x slower |   0.01x |       - |         - |
|                  Streams | 1000 |   100 |  8,975.4 ns |     7.29 ns |   6.46 ns |  20.23x slower |   0.03x |  0.5493 |   1,152 B |
|               StructLinq | 1000 |   100 |    644.7 ns |     0.20 ns |   0.18 ns |   1.45x slower |   0.00x |  0.0458 |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    541.8 ns |     0.32 ns |   0.28 ns |   1.22x slower |   0.00x |       - |         - |
|                Hyperlinq | 1000 |   100 |    979.0 ns |     0.57 ns |   0.53 ns |   2.21x slower |   0.00x |       - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    867.5 ns |     1.10 ns |   0.97 ns |   1.96x slower |   0.00x |       - |         - |
