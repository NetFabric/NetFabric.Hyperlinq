## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|                   Method | Skip | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 |  Gen 1 | Allocated |
|------------------------- |----- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|-------:|----------:|
|                  ForLoop | 1000 |   100 |    533.9 ns |   6.67 ns |   5.57 ns |       baseline |         |       - |      - |         - |
|                     Linq | 1000 |   100 |  1,287.1 ns |   5.32 ns |   4.97 ns |   2.41x slower |   0.03x |  0.1526 |      - |     320 B |
|               LinqFaster | 1000 |   100 |  3,678.3 ns |  19.02 ns |  16.86 ns |   6.89x slower |   0.08x | 10.0327 |      - |  21,000 B |
|             LinqFasterer | 1000 |   100 |  7,326.2 ns |  70.60 ns |  58.96 ns |  13.72x slower |   0.13x | 37.0331 |      - |  80,168 B |
|                   LinqAF | 1000 |   100 |  8,370.0 ns |  35.54 ns |  33.24 ns |  15.67x slower |   0.17x |       - |      - |         - |
|            LinqOptimizer | 1000 |   100 | 74,156.0 ns | 425.15 ns | 355.02 ns | 138.91x slower |   1.27x | 73.9746 | 0.2441 | 158,856 B |
|                 SpanLinq | 1000 |   100 |    754.4 ns |   2.04 ns |   1.91 ns |   1.41x slower |   0.01x |       - |      - |         - |
|                  Streams | 1000 |   100 | 10,326.7 ns |  56.58 ns |  52.93 ns |  19.35x slower |   0.23x |  0.5493 |      - |   1,176 B |
|               StructLinq | 1000 |   100 |    645.0 ns |   2.10 ns |   1.75 ns |   1.21x slower |   0.01x |  0.0572 |      - |     120 B |
| StructLinq_ValueDelegate | 1000 |   100 |    566.2 ns |   1.51 ns |   1.34 ns |   1.06x slower |   0.01x |       - |      - |         - |
|                Hyperlinq | 1000 |   100 |  1,057.7 ns |   7.37 ns |   6.53 ns |   1.98x slower |   0.02x |       - |      - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    794.4 ns |   1.85 ns |   1.73 ns |   1.49x slower |   0.02x |       - |      - |         - |
