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
|                   Method | Skip | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |----- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop | 1000 |   100 |     68.70 ns |   0.073 ns |   0.068 ns |       baseline |         |       - |         - |
|                     Linq | 1000 |   100 |    779.93 ns |   5.488 ns |   5.133 ns |  11.35x slower |   0.08x |  0.0725 |     152 B |
|               LinqFaster | 1000 |   100 |    348.38 ns |   3.290 ns |   2.916 ns |   5.07x slower |   0.04x |  0.6080 |   1,272 B |
|             LinqFasterer | 1000 |   100 |    452.76 ns |   1.711 ns |   1.429 ns |   6.59x slower |   0.02x |  0.4206 |     880 B |
|                   LinqAF | 1000 |   100 |  2,577.76 ns |   4.165 ns |   3.252 ns |  37.52x slower |   0.07x |       - |         - |
|            LinqOptimizer | 1000 |   100 | 44,594.39 ns | 155.655 ns | 145.600 ns | 649.09x slower |   2.36x | 14.8926 |  31,181 B |
|                 SpanLinq | 1000 |   100 |    279.24 ns |   0.271 ns |   0.240 ns |   4.06x slower |   0.01x |       - |         - |
|                  Streams | 1000 |   100 |  6,373.86 ns |   7.272 ns |   6.072 ns |  92.78x slower |   0.12x |  0.4349 |     912 B |
|               StructLinq | 1000 |   100 |    279.75 ns |   1.187 ns |   1.052 ns |   4.07x slower |   0.01x |  0.0458 |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    176.49 ns |   0.191 ns |   0.169 ns |   2.57x slower |   0.00x |       - |         - |
|                Hyperlinq | 1000 |   100 |    229.85 ns |   0.113 ns |   0.106 ns |   3.35x slower |   0.00x |       - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    224.70 ns |   0.237 ns |   0.222 ns |   3.27x slower |   0.00x |       - |         - |
