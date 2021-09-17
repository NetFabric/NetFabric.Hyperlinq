## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |     72.76 ns |   0.358 ns |   0.334 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |     73.23 ns |   0.531 ns |   0.497 ns |   1.01x slower |   0.01x |       - |         - |
|                     Linq |   100 |    337.08 ns |   0.486 ns |   0.379 ns |   4.64x slower |   0.02x |  0.0229 |      48 B |
|               LinqFaster |   100 |    329.72 ns |   1.978 ns |   1.850 ns |   4.53x slower |   0.04x |  0.3171 |     664 B |
|             LinqFasterer |   100 |    497.25 ns |   0.727 ns |   0.568 ns |   6.84x slower |   0.03x |  0.2136 |     448 B |
|                   LinqAF |   100 |    502.49 ns |   7.832 ns |   7.326 ns |   6.91x slower |   0.11x |       - |         - |
|            LinqOptimizer |   100 | 41,446.86 ns | 337.437 ns | 281.775 ns | 570.25x slower |   4.62x | 13.2446 |  27,702 B |
|                 SpanLinq |   100 |    338.11 ns |   0.874 ns |   0.817 ns |   4.65x slower |   0.03x |       - |         - |
|                  Streams |   100 |  1,182.85 ns |   5.445 ns |   5.094 ns |  16.26x slower |   0.11x |  0.2785 |     584 B |
|               StructLinq |   100 |    325.44 ns |   3.849 ns |   3.601 ns |   4.47x slower |   0.05x |  0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |    217.82 ns |   0.588 ns |   0.550 ns |   2.99x slower |   0.02x |       - |         - |
|                Hyperlinq |   100 |    327.27 ns |   4.719 ns |   4.414 ns |   4.50x slower |   0.06x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    222.15 ns |   0.620 ns |   0.580 ns |   3.05x slower |   0.02x |       - |         - |
