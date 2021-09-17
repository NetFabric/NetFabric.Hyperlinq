## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
|                  ForLoop |   100 |     60.52 ns |   0.079 ns |   0.062 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |     62.91 ns |   0.523 ns |   0.489 ns |   1.04x slower |   0.01x |       - |         - |
|                     Linq |   100 |    419.04 ns |   2.148 ns |   1.794 ns |   6.92x slower |   0.03x |  0.0229 |      48 B |
|               LinqFaster |   100 |    290.52 ns |   1.342 ns |   1.190 ns |   4.80x slower |   0.02x |  0.2027 |     424 B |
|          LinqFaster_SIMD |   100 |    127.25 ns |   0.448 ns |   0.374 ns |   2.10x slower |   0.01x |  0.2027 |     424 B |
|             LinqFasterer |   100 |    385.56 ns |   1.716 ns |   1.605 ns |   6.37x slower |   0.02x |  0.2179 |     456 B |
|                   LinqAF |   100 |    307.95 ns |   2.272 ns |   2.125 ns |   5.09x slower |   0.03x |       - |         - |
|            LinqOptimizer |   100 | 34,218.24 ns | 344.086 ns | 321.858 ns | 563.42x slower |   3.59x | 13.0005 |  27,236 B |
|                 SpanLinq |   100 |    276.98 ns |   0.337 ns |   0.263 ns |   4.58x slower |   0.01x |       - |         - |
|                  Streams |   100 |  1,470.75 ns |   6.500 ns |   6.080 ns |  24.30x slower |   0.10x |  0.2785 |     584 B |
|               StructLinq |   100 |    224.73 ns |   0.718 ns |   0.672 ns |   3.71x slower |   0.01x |  0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |    179.23 ns |   1.522 ns |   1.424 ns |   2.96x slower |   0.03x |       - |         - |
|                Hyperlinq |   100 |    254.92 ns |   2.318 ns |   1.936 ns |   4.21x slower |   0.03x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    199.05 ns |   0.366 ns |   0.343 ns |   3.29x slower |   0.00x |       - |         - |
