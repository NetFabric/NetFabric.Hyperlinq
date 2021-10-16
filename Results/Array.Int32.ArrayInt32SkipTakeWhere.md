## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|                   Method | Skip | Count |         Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |----- |------ |-------------:|----------:|----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop | 1000 |   100 |     74.05 ns |  0.097 ns |  0.091 ns |       baseline |         |       - |         - |
|                     Linq | 1000 |   100 |  1,016.22 ns |  2.401 ns |  2.246 ns |  13.72x slower |   0.03x |  0.0725 |     152 B |
|               LinqFaster | 1000 |   100 |    420.56 ns |  1.333 ns |  1.247 ns |   5.68x slower |   0.02x |  0.7191 |   1,504 B |
|             LinqFasterer | 1000 |   100 |    474.36 ns |  1.248 ns |  1.107 ns |   6.41x slower |   0.02x |  0.3281 |     688 B |
|                   LinqAF | 1000 |   100 |  2,610.79 ns |  8.719 ns |  8.156 ns |  35.26x slower |   0.11x |       - |         - |
|            LinqOptimizer | 1000 |   100 | 49,739.71 ns | 96.765 ns | 85.779 ns | 671.64x slower |   1.35x | 15.0757 |  31,641 B |
|                 SpanLinq | 1000 |   100 |    246.75 ns |  0.544 ns |  0.455 ns |   3.33x slower |   0.01x |       - |         - |
|                  Streams | 1000 |   100 |  6,257.85 ns |  8.262 ns |  7.728 ns |  84.51x slower |   0.13x |  0.4349 |     912 B |
|               StructLinq | 1000 |   100 |    354.60 ns |  6.698 ns |  6.266 ns |   4.79x slower |   0.08x |  0.0458 |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    203.53 ns |  0.252 ns |  0.236 ns |   2.75x slower |   0.00x |       - |         - |
|                Hyperlinq | 1000 |   100 |    450.44 ns |  3.801 ns |  3.555 ns |   6.08x slower |   0.04x |       - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    238.58 ns |  0.610 ns |  0.570 ns |   3.22x slower |   0.01x |       - |         - |
