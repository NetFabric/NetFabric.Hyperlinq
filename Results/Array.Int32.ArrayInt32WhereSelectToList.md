## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|                   Method | Count |       Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |   233.3 ns |  2.11 ns |  1.87 ns |     baseline |         | 0.3095 |     648 B |
|              ForeachLoop |   100 |   236.9 ns |  3.54 ns |  2.96 ns | 1.02x slower |   0.01x | 0.3095 |     648 B |
|                     Linq |   100 |   525.0 ns |  1.15 ns |  0.90 ns | 2.25x slower |   0.02x | 0.3595 |     752 B |
|               LinqFaster |   100 |   424.2 ns |  1.58 ns |  1.48 ns | 1.82x slower |   0.02x | 0.4473 |     936 B |
|             LinqFasterer |   100 |   614.5 ns |  3.12 ns |  2.77 ns | 2.63x slower |   0.02x | 0.6113 |   1,280 B |
|                   LinqAF |   100 |   594.3 ns |  4.16 ns |  3.89 ns | 2.55x slower |   0.03x | 0.3090 |     648 B |
|            LinqOptimizer |   100 | 1,494.8 ns | 12.06 ns | 11.28 ns | 6.41x slower |   0.07x | 4.2629 |   8,922 B |
|                 SpanLinq |   100 |   535.0 ns |  3.52 ns |  3.12 ns | 2.29x slower |   0.02x | 0.3090 |     648 B |
|                  Streams |   100 | 1,342.1 ns |  6.72 ns |  6.28 ns | 5.75x slower |   0.05x | 0.5684 |   1,192 B |
|               StructLinq |   100 |   602.9 ns |  3.25 ns |  3.04 ns | 2.58x slower |   0.03x | 0.1755 |     368 B |
| StructLinq_ValueDelegate |   100 |   373.0 ns |  2.58 ns |  2.29 ns | 1.60x slower |   0.02x | 0.1297 |     272 B |
|                Hyperlinq |   100 |   621.2 ns |  6.63 ns |  5.88 ns | 2.66x slower |   0.03x | 0.1297 |     272 B |
|  Hyperlinq_ValueDelegate |   100 |   378.2 ns |  4.94 ns |  4.62 ns | 1.62x slower |   0.03x | 0.1297 |     272 B |
