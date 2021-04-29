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
|                  ForLoop | 1000 |   100 |     85.28 ns |   0.330 ns |   0.276 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                     Linq | 1000 |   100 |  1,165.81 ns |   4.969 ns |   4.648 ns |  13.69 |    0.03 |  0.0839 |     - |     - |     176 B |
|             LinqFasterer | 1000 |   100 |    752.09 ns |   5.806 ns |   5.431 ns |   8.82 |    0.08 |  2.5444 |     - |     - |   5,328 B |
|            LinqOptimizer | 1000 |   100 | 51,412.47 ns | 174.058 ns | 145.346 ns | 602.85 |    2.29 | 15.6250 |     - |     - |  32,723 B |
|                  Streams | 1000 |   100 |  9,161.04 ns |  45.028 ns |  37.601 ns | 107.42 |    0.53 |  0.4425 |     - |     - |     936 B |
|               StructLinq | 1000 |   100 |    251.35 ns |   1.390 ns |   1.085 ns |   2.95 |    0.01 |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    170.65 ns |   0.496 ns |   0.387 ns |   2.00 |    0.01 |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |    258.61 ns |   1.509 ns |   1.412 ns |   3.03 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    207.05 ns |   0.544 ns |   0.455 ns |   2.43 |    0.01 |       - |     - |     - |         - |
