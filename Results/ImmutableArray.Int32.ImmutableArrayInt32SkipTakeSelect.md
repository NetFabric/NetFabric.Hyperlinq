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
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.0, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Skip | Count |         Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |-------------:|----------:|----------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | 1000 |   100 |     74.34 ns |  0.052 ns |  0.049 ns |       baseline |         |       - |     - |     - |         - |
|                     Linq | 1000 |   100 |    467.04 ns |  0.287 ns |  0.268 ns |   6.28x slower |   0.01x |  0.0839 |     - |     - |     176 B |
|             LinqFasterer | 1000 |   100 |    827.68 ns |  2.429 ns |  2.028 ns |  11.13x slower |   0.03x |  2.5444 |     - |     - |   5,328 B |
|            LinqOptimizer | 1000 |   100 | 56,541.38 ns | 55.113 ns | 43.029 ns | 760.57x slower |   0.87x | 15.6250 |     - |     - |  32,723 B |
|                  Streams | 1000 |   100 |  7,400.66 ns |  6.482 ns |  5.746 ns |  99.55x slower |   0.10x |  0.4425 |     - |     - |     936 B |
|               StructLinq | 1000 |   100 |    276.20 ns |  0.281 ns |  0.249 ns |   3.72x slower |   0.00x |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    173.37 ns |  0.088 ns |  0.074 ns |   2.33x slower |   0.00x |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |    226.27 ns |  1.716 ns |  1.339 ns |   3.04x slower |   0.02x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    222.59 ns |  0.282 ns |  0.235 ns |   2.99x slower |   0.00x |       - |     - |     - |         - |
