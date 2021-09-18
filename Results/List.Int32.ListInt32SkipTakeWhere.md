## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
|                   Method | Skip | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |----- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop | 1000 |   100 |    101.9 ns |   0.24 ns |   0.23 ns |       baseline |         |       - |         - |
|                     Linq | 1000 |   100 |    589.5 ns |   4.75 ns |   4.21 ns |   5.79x slower |   0.04x |  0.0725 |     152 B |
|               LinqFaster | 1000 |   100 |    990.8 ns |   6.77 ns |   5.65 ns |   9.72x slower |   0.06x |  0.7458 |   1,560 B |
|             LinqFasterer | 1000 |   100 |    777.0 ns |   3.76 ns |   3.52 ns |   7.63x slower |   0.03x |  2.4424 |   5,112 B |
|                   LinqAF | 1000 |   100 |  4,178.5 ns |  13.00 ns |  12.16 ns |  41.02x slower |   0.14x |       - |         - |
|            LinqOptimizer | 1000 |   100 | 66,282.1 ns | 279.29 ns | 247.58 ns | 650.62x slower |   2.92x | 15.6250 |  32,741 B |
|                 SpanLinq | 1000 |   100 |    247.7 ns |   0.30 ns |   0.23 ns |   2.43x slower |   0.01x |       - |         - |
|                  Streams | 1000 |   100 |  6,933.7 ns |  19.41 ns |  18.16 ns |  68.07x slower |   0.29x |  0.4425 |     936 B |
|               StructLinq | 1000 |   100 |    326.6 ns |   4.82 ns |   4.51 ns |   3.21x slower |   0.05x |  0.0458 |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    181.6 ns |   0.51 ns |   0.48 ns |   1.78x slower |   0.01x |       - |         - |
|                Hyperlinq | 1000 |   100 |    314.8 ns |   4.64 ns |   4.11 ns |   3.09x slower |   0.04x |       - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    238.0 ns |   0.45 ns |   0.43 ns |   2.34x slower |   0.01x |       - |         - |
