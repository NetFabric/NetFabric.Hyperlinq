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
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |     72.66 ns |   0.132 ns |   0.124 ns |       baseline |         |      - |         - |
|              ForeachLoop |   100 |    131.51 ns |   0.104 ns |   0.097 ns |   1.81x slower |   0.00x |      - |         - |
|                     Linq |   100 |    559.88 ns |   0.937 ns |   0.830 ns |   7.70x slower |   0.01x | 0.0153 |      32 B |
|               LinqFaster |   100 |    356.81 ns |   3.488 ns |   3.092 ns |   4.91x slower |   0.04x |      - |         - |
|             LinqFasterer |   100 |    243.92 ns |   0.238 ns |   0.223 ns |   3.36x slower |   0.01x |      - |         - |
|                   LinqAF |   100 |    703.30 ns |   0.898 ns |   0.796 ns |   9.68x slower |   0.02x |      - |         - |
|            LinqOptimizer |   100 | 30,827.78 ns | 145.901 ns | 121.834 ns | 424.20x slower |   1.52x | 9.0332 |  18,930 B |
|                  Streams |   100 |    649.37 ns |   1.186 ns |   1.051 ns |   8.94x slower |   0.02x | 0.1717 |     360 B |
|               StructLinq |   100 |    242.15 ns |   0.455 ns |   0.426 ns |   3.33x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |     85.22 ns |   0.050 ns |   0.041 ns |   1.17x slower |   0.00x |      - |         - |
|                Hyperlinq |   100 |    532.61 ns |   0.567 ns |   0.530 ns |   7.33x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |   100 |    283.59 ns |   3.936 ns |   3.682 ns |   3.90x slower |   0.05x |      - |         - |
