## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                   Method | Skip | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |----- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop | 1000 |   100 |     68.88 ns |   0.285 ns |   0.266 ns |       baseline |         |       - |         - |
|                     Linq | 1000 |   100 |    784.86 ns |   2.900 ns |   2.712 ns |  11.39x slower |   0.06x |  0.0725 |     152 B |
|               LinqFaster | 1000 |   100 |    368.83 ns |   4.211 ns |   3.939 ns |   5.35x slower |   0.06x |  0.6080 |   1,272 B |
|             LinqFasterer | 1000 |   100 |    476.91 ns |   1.043 ns |   0.814 ns |   6.92x slower |   0.04x |  0.4206 |     880 B |
|                   LinqAF | 1000 |   100 |  2,612.21 ns |  24.878 ns |  23.271 ns |  37.92x slower |   0.46x |       - |         - |
|            LinqOptimizer | 1000 |   100 | 44,362.81 ns | 333.248 ns | 278.277 ns | 644.02x slower |   4.96x | 14.8926 |  31,181 B |
|                 SpanLinq | 1000 |   100 |    277.12 ns |   0.284 ns |   0.221 ns |   4.02x slower |   0.02x |       - |         - |
|                  Streams | 1000 |   100 |  6,377.52 ns |  20.332 ns |  19.018 ns |  92.58x slower |   0.49x |  0.4349 |     912 B |
|               StructLinq | 1000 |   100 |    255.79 ns |   0.459 ns |   0.358 ns |   3.71x slower |   0.01x |  0.0458 |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    176.75 ns |   0.374 ns |   0.350 ns |   2.57x slower |   0.01x |       - |         - |
|                Hyperlinq | 1000 |   100 |    228.14 ns |   0.572 ns |   0.535 ns |   3.31x slower |   0.02x |       - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    216.48 ns |   0.460 ns |   0.408 ns |   3.14x slower |   0.01x |       - |         - |
