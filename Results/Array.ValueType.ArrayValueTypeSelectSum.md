## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |     72.73 ns |   0.092 ns |   0.072 ns |       baseline |         |      - |         - |
|              ForeachLoop |   100 |    141.12 ns |   0.382 ns |   0.357 ns |   1.94x slower |   0.00x |      - |         - |
|                     Linq |   100 |    601.09 ns |   3.920 ns |   3.667 ns |   8.26x slower |   0.06x | 0.0153 |      32 B |
|               LinqFaster |   100 |    359.74 ns |   0.580 ns |   0.543 ns |   4.95x slower |   0.01x |      - |         - |
|             LinqFasterer |   100 |    261.99 ns |   1.252 ns |   1.045 ns |   3.60x slower |   0.01x |      - |         - |
|                   LinqAF |   100 |    701.36 ns |   0.797 ns |   0.622 ns |   9.64x slower |   0.01x |      - |         - |
|            LinqOptimizer |   100 | 30,589.73 ns | 188.016 ns | 175.870 ns | 420.62x slower |   2.51x | 9.0332 |  18,930 B |
|                  Streams |   100 |    612.77 ns |   0.857 ns |   0.669 ns |   8.43x slower |   0.01x | 0.1717 |     360 B |
|               StructLinq |   100 |    269.28 ns |   0.469 ns |   0.366 ns |   3.70x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |     83.92 ns |   0.078 ns |   0.061 ns |   1.15x slower |   0.00x |      - |         - |
|                Hyperlinq |   100 |    624.44 ns |   1.371 ns |   1.070 ns |   8.59x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |   100 |    311.75 ns |   0.421 ns |   0.374 ns |   4.29x slower |   0.01x |      - |         - |
