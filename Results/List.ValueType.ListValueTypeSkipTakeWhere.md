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
|                   Method | Skip | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 |  Gen 1 | Allocated |
|------------------------- |----- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|-------:|----------:|
|                  ForLoop | 1000 |   100 |    530.4 ns |   1.86 ns |   1.55 ns |       baseline |         |       - |      - |         - |
|                     Linq | 1000 |   100 |  1,271.2 ns |   1.36 ns |   1.06 ns |   2.40x slower |   0.01x |  0.1526 |      - |     320 B |
|               LinqFaster | 1000 |   100 |  3,662.6 ns |  38.75 ns |  34.35 ns |   6.90x slower |   0.07x | 10.0327 |      - |  21,000 B |
|             LinqFasterer | 1000 |   100 |  7,127.0 ns |  66.31 ns |  62.03 ns |  13.42x slower |   0.13x | 37.0331 |      - |  80,168 B |
|                   LinqAF | 1000 |   100 |  8,501.4 ns | 123.68 ns | 109.64 ns |  16.02x slower |   0.21x |       - |      - |         - |
|            LinqOptimizer | 1000 |   100 | 75,281.6 ns | 581.20 ns | 515.22 ns | 141.94x slower |   1.18x | 73.9746 | 0.1221 | 158,855 B |
|                 SpanLinq | 1000 |   100 |    752.4 ns |   2.32 ns |   2.17 ns |   1.42x slower |   0.01x |       - |      - |         - |
|                  Streams | 1000 |   100 | 10,232.1 ns |  37.30 ns |  31.15 ns |  19.29x slower |   0.07x |  0.5493 |      - |   1,176 B |
|               StructLinq | 1000 |   100 |    641.3 ns |   2.05 ns |   1.91 ns |   1.21x slower |   0.01x |  0.0572 |      - |     120 B |
| StructLinq_ValueDelegate | 1000 |   100 |    563.9 ns |   0.55 ns |   0.43 ns |   1.06x slower |   0.00x |       - |      - |         - |
|                Hyperlinq | 1000 |   100 |  1,050.7 ns |   4.37 ns |   4.09 ns |   1.98x slower |   0.01x |       - |      - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    864.0 ns |   2.28 ns |   1.78 ns |   1.63x slower |   0.01x |       - |      - |         - |
