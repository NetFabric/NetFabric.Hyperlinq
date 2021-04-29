## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|                   Method | Skip | Count |        Mean |     Error |    StdDev |      Median |  Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |------------:|----------:|----------:|------------:|-------:|--------:|--------:|--------:|------:|----------:|
|                  ForLoop | 1000 |   100 |    513.7 ns |   4.09 ns |   3.82 ns |    513.6 ns |   1.00 |    0.00 |       - |       - |     - |         - |
|                     Linq | 1000 |   100 |  1,874.4 ns |  37.43 ns |  31.26 ns |  1,860.0 ns |   3.65 |    0.07 |  0.1526 |       - |     - |     320 B |
|               LinqFaster | 1000 |   100 |  2,296.9 ns |  42.55 ns |  39.80 ns |  2,286.2 ns |   4.47 |    0.07 | 10.7803 |       - |     - |  22,560 B |
|             LinqFasterer | 1000 |   100 |  1,958.7 ns |  41.48 ns | 122.30 ns |  1,902.2 ns |   4.02 |    0.20 |  4.6501 |       - |     - |   9,744 B |
|                   LinqAF | 1000 |   100 | 17,460.1 ns |  77.34 ns |  72.34 ns | 17,485.2 ns |  33.99 |    0.31 |       - |       - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 58,155.7 ns | 474.76 ns | 396.45 ns | 58,055.4 ns | 113.24 |    1.21 | 57.6782 | 19.2261 |     - | 157,949 B |
|                  Streams | 1000 |   100 |  8,885.2 ns | 177.08 ns | 181.85 ns |  8,933.3 ns |  17.26 |    0.43 |  0.5493 |       - |     - |   1,152 B |
|               StructLinq | 1000 |   100 |    702.1 ns |  11.58 ns |  10.83 ns |    703.4 ns |   1.37 |    0.02 |  0.0458 |       - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    571.8 ns |   3.18 ns |   2.97 ns |    571.4 ns |   1.11 |    0.01 |       - |       - |     - |         - |
|                Hyperlinq | 1000 |   100 |  1,126.1 ns |  13.47 ns |  12.60 ns |  1,126.0 ns |   2.19 |    0.03 |       - |       - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    842.1 ns |  12.90 ns |  12.06 ns |    838.3 ns |   1.64 |    0.03 |       - |       - |     - |         - |
