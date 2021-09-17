## ImmutableArray.Int32.ImmutableArrayInt32SkipTakeSelect

### Source
[ImmutableArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32SkipTakeSelect.cs)

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
|                  ForLoop | 1000 |   100 |     74.19 ns |   1.546 ns |   1.291 ns |       baseline |         |       - |         - |
|                     Linq | 1000 |   100 |    494.70 ns |   0.800 ns |   0.624 ns |   6.64x slower |   0.02x |  0.0839 |     176 B |
|             LinqFasterer | 1000 |   100 |    827.09 ns |   3.962 ns |   3.512 ns |  11.15x slower |   0.22x |  2.5444 |   5,328 B |
|            LinqOptimizer | 1000 |   100 | 56,547.01 ns | 269.157 ns | 238.601 ns | 762.00x slower |  13.94x | 15.6250 |  32,723 B |
|                  Streams | 1000 |   100 |  7,408.78 ns |  29.556 ns |  27.646 ns |  99.89x slower |   1.93x |  0.4425 |     936 B |
|               StructLinq | 1000 |   100 |    277.24 ns |   0.315 ns |   0.246 ns |   3.72x slower |   0.01x |  0.0458 |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    173.47 ns |   0.547 ns |   0.485 ns |   2.34x slower |   0.04x |       - |         - |
|                Hyperlinq | 1000 |   100 |    245.22 ns |   0.534 ns |   0.474 ns |   3.31x slower |   0.06x |       - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    221.64 ns |   0.367 ns |   0.306 ns |   2.99x slower |   0.06x |       - |         - |
