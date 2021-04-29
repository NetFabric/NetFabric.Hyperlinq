## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|                   Method | Skip | Count |        Mean |     Error |    StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |------------:|----------:|----------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | 1000 |   100 |    589.0 ns |   5.29 ns |   4.69 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|                     Linq | 1000 |   100 |  1,486.7 ns |  18.14 ns |  16.97 ns |   2.53 |    0.03 |  0.1526 |     - |     - |     320 B |
|               LinqFaster | 1000 |   100 |  3,440.8 ns |  34.39 ns |  32.17 ns |   5.84 |    0.06 | 10.0250 |     - |     - |  21,000 B |
|             LinqFasterer | 1000 |   100 |  6,493.1 ns |  79.68 ns |  74.54 ns |  11.03 |    0.16 | 37.0331 |     - |     - |  80,168 B |
|                   LinqAF | 1000 |   100 | 11,810.3 ns | 231.90 ns | 284.79 ns |  20.07 |    0.58 |       - |     - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 66,726.2 ns | 409.33 ns | 382.89 ns | 113.21 |    1.12 | 73.9746 |     - |     - | 159,000 B |
|                  Streams | 1000 |   100 | 10,361.8 ns |  52.72 ns |  49.32 ns |  17.59 |    0.16 |  0.5493 |     - |     - |   1,176 B |
|               StructLinq | 1000 |   100 |    691.3 ns |   4.38 ns |   3.42 ns |   1.17 |    0.01 |  0.0572 |     - |     - |     120 B |
| StructLinq_ValueDelegate | 1000 |   100 |    592.6 ns |   5.20 ns |   4.86 ns |   1.01 |    0.01 |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |  1,110.7 ns |   7.37 ns |   6.53 ns |   1.89 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    827.0 ns |   4.30 ns |   4.02 ns |   1.40 |    0.01 |       - |     - |     - |         - |
