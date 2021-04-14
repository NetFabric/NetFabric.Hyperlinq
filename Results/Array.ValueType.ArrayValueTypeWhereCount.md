## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|               Method |    Job |  Runtime | Count |        Mean |       Error |      StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |------------:|------------:|------------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 |  1000 |    951.0 ns |     7.77 ns |     6.49 ns |    950.3 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  1,812.7 ns |     7.18 ns |     6.37 ns |  1,811.3 ns |  1.91 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 11,910.7 ns |    42.99 ns |    33.56 ns | 11,920.1 ns | 12.53 |    0.11 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  4,066.5 ns |    51.27 ns |    47.96 ns |  4,046.8 ns |  4.27 |    0.04 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 12,390.2 ns |   181.30 ns |   169.59 ns | 12,340.1 ns | 13.04 |    0.18 |      - |     - |     - |         - |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  4,662.1 ns |    17.04 ns |    15.94 ns |  4,661.5 ns |  4.90 |    0.04 | 0.0305 |     - |     - |      64 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 34,288.7 ns |   243.48 ns |   227.75 ns | 34,294.6 ns | 36.09 |    0.34 | 9.2163 |     - |     - |  19,273 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 |  8,107.7 ns |    77.36 ns |    72.36 ns |  8,109.1 ns |  8.53 |    0.08 | 0.1678 |     - |     - |     360 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  2,174.4 ns |    37.83 ns |    33.53 ns |  2,179.8 ns |  2.29 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  4,432.0 ns |    86.62 ns |   126.97 ns |  4,422.9 ns |  4.65 |    0.17 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  3,857.2 ns |    54.97 ns |    51.42 ns |  3,858.7 ns |  4.06 |    0.07 |      - |     - |     - |         - |
|                      |        |          |       |             |             |             |             |       |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |    913.2 ns |     7.29 ns |     6.82 ns |    910.9 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  1,847.5 ns |     3.00 ns |     2.51 ns |  1,847.7 ns |  2.02 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  8,092.9 ns |    41.21 ns |    38.55 ns |  8,102.9 ns |  8.86 |    0.07 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  3,922.6 ns |    22.74 ns |    21.28 ns |  3,924.6 ns |  4.30 |    0.04 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  8,333.0 ns |   165.58 ns |   209.41 ns |  8,385.2 ns |  9.07 |    0.26 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  5,604.8 ns |    29.08 ns |    25.78 ns |  5,597.7 ns |  6.14 |    0.05 | 0.0305 |     - |     - |      64 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 34,694.0 ns | 1,031.56 ns | 3,041.57 ns | 32,755.7 ns | 36.40 |    1.85 | 9.1553 |     - |     - |  19,217 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  8,174.3 ns |    75.25 ns |    66.70 ns |  8,162.5 ns |  8.96 |    0.11 | 0.1678 |     - |     - |     360 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1,728.4 ns |    29.67 ns |    23.16 ns |  1,735.8 ns |  1.89 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  4,614.0 ns |    90.52 ns |   148.73 ns |  4,608.2 ns |  5.06 |    0.13 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  3,533.3 ns |    23.81 ns |    18.59 ns |  3,535.7 ns |  3.87 |    0.04 |      - |     - |     - |         - |
