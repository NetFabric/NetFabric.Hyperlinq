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
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |     72.99 ns |   0.392 ns |   0.348 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |     73.42 ns |   0.318 ns |   0.298 ns |   1.01x slower |   0.00x |       - |         - |
|                     Linq |   100 |    343.00 ns |   0.844 ns |   0.790 ns |   4.70x slower |   0.02x |  0.0229 |      48 B |
|               LinqFaster |   100 |    330.12 ns |   1.053 ns |   0.985 ns |   4.52x slower |   0.02x |  0.3171 |     664 B |
|             LinqFasterer |   100 |    501.35 ns |   1.501 ns |   1.331 ns |   6.87x slower |   0.04x |  0.2136 |     448 B |
|                   LinqAF |   100 |    490.51 ns |   3.274 ns |   3.063 ns |   6.72x slower |   0.04x |       - |         - |
|            LinqOptimizer |   100 | 40,234.14 ns | 213.818 ns | 200.006 ns | 551.40x slower |   3.60x | 13.2446 |  27,702 B |
|                 SpanLinq |   100 |    342.78 ns |   0.364 ns |   0.322 ns |   4.70x slower |   0.02x |       - |         - |
|                  Streams |   100 |  1,228.96 ns |   2.415 ns |   2.259 ns |  16.84x slower |   0.09x |  0.2785 |     584 B |
|               StructLinq |   100 |    323.64 ns |   5.161 ns |   4.828 ns |   4.43x slower |   0.07x |  0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |    216.34 ns |   2.148 ns |   2.010 ns |   2.97x slower |   0.04x |       - |         - |
|                Hyperlinq |   100 |    323.43 ns |   3.792 ns |   3.547 ns |   4.43x slower |   0.06x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    222.11 ns |   0.383 ns |   0.339 ns |   3.04x slower |   0.01x |       - |         - |
