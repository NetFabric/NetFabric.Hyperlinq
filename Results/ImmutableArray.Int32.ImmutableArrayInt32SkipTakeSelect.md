## ImmutableArray.Int32.ImmutableArrayInt32SkipTakeSelect

### Source
[ImmutableArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32SkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [1.0.0](https://www.nuget.org/packages/SpanLinq/1.0.0)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1538-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Skip | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | 1000 |   100 |     84.63 ns |   0.635 ns |   0.530 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                     Linq | 1000 |   100 |  1,127.17 ns |   7.068 ns |   5.902 ns |  13.32 |    0.12 |  0.0839 |     - |     - |     176 B |
|             LinqFasterer | 1000 |   100 |    787.63 ns |   8.682 ns |   8.122 ns |   9.32 |    0.12 |  2.5444 |     - |     - |   5,328 B |
|            LinqOptimizer | 1000 |   100 | 61,084.55 ns | 470.418 ns | 392.820 ns | 721.79 |    6.98 | 15.6250 |     - |     - |  32,723 B |
|                  Streams | 1000 |   100 |  9,049.46 ns |  47.078 ns |  41.733 ns | 106.90 |    0.84 |  0.4425 |     - |     - |     936 B |
|               StructLinq | 1000 |   100 |    277.39 ns |   1.569 ns |   1.391 ns |   3.28 |    0.02 |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    175.72 ns |   0.573 ns |   0.536 ns |   2.08 |    0.01 |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |    253.51 ns |   2.195 ns |   1.833 ns |   3.00 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    221.89 ns |   1.631 ns |   1.526 ns |   2.62 |    0.03 |       - |     - |     - |         - |
