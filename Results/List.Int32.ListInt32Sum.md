## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT

EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  

```
|               Method |    Job |  Runtime | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 |  1000 |    797.32 ns |   3.902 ns |   3.459 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  1,876.75 ns |   3.317 ns |   2.770 ns |  2.35 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  6,665.42 ns |  52.886 ns |  44.162 ns |  8.36 |    0.06 | 0.0153 |     - |     - |      40 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |    787.65 ns |   3.192 ns |   2.666 ns |  0.99 |    0.01 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  4,775.11 ns |  20.937 ns |  19.584 ns |  5.99 |    0.02 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 34,785.81 ns | 248.645 ns | 220.417 ns | 43.63 |    0.38 | 8.2397 |     - |     - |  17,289 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 |  2,068.69 ns |   9.425 ns |   8.816 ns |  2.59 |    0.02 | 0.0992 |     - |     - |     208 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |    687.71 ns |   2.584 ns |   2.017 ns |  0.86 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |    555.46 ns |   3.637 ns |   3.224 ns |  0.70 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |     89.59 ns |   1.113 ns |   0.987 ns |  0.11 |    0.00 |      - |     - |     - |         - |
|                      |        |          |       |              |            |            |       |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |    796.76 ns |   2.809 ns |   2.346 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  1,311.95 ns |   9.003 ns |   7.518 ns |  1.65 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  6,582.99 ns |  37.848 ns |  33.551 ns |  8.26 |    0.04 | 0.0153 |     - |     - |      40 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |    737.78 ns |   7.516 ns |   6.663 ns |  0.93 |    0.01 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  4,769.89 ns |  22.699 ns |  20.122 ns |  5.99 |    0.02 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 33,062.87 ns | 441.134 ns | 391.054 ns | 41.46 |    0.54 | 7.9956 |     - |     - |  17,046 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  1,432.57 ns |  13.517 ns |  11.983 ns |  1.80 |    0.02 | 0.0992 |     - |     - |     208 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |    690.49 ns |   2.323 ns |   2.173 ns |  0.87 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |    592.70 ns |   3.072 ns |   2.723 ns |  0.74 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |     88.35 ns |   1.116 ns |   0.932 ns |  0.11 |    0.00 |      - |     - |     - |         - |
