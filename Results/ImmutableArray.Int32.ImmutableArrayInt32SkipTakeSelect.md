## ImmutableArray.Int32.ImmutableArrayInt32SkipTakeSelect

### Source
[ImmutableArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32SkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Skip | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | 1000 |   100 |     83.87 ns |   0.186 ns |   0.165 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop | 1000 |   100 |  1,859.06 ns |   7.101 ns |   6.295 ns |  22.17 |    0.06 |  0.0153 |     - |     - |      32 B |
|                     Linq | 1000 |   100 |  1,158.94 ns |  11.967 ns |  10.609 ns |  13.82 |    0.13 |  0.0839 |     - |     - |     176 B |
|            LinqOptimizer | 1000 |   100 | 50,178.41 ns | 564.995 ns | 554.901 ns | 596.60 |    4.00 | 15.5640 |     - |     - |  32,723 B |
|                  Streams | 1000 |   100 |  9,101.24 ns |  35.748 ns |  31.690 ns | 108.52 |    0.43 |  0.4425 |     - |     - |     936 B |
|               StructLinq | 1000 |   100 |    276.39 ns |   1.488 ns |   1.392 ns |   3.30 |    0.02 |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    167.09 ns |   0.705 ns |   0.660 ns |   1.99 |    0.01 |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |    239.36 ns |   1.200 ns |   1.122 ns |   2.85 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    203.54 ns |   0.616 ns |   0.576 ns |   2.43 |    0.01 |       - |     - |     - |         - |
