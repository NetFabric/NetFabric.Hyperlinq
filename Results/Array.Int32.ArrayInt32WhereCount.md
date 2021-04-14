## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|              ForLoop | .NET 5 | .NET 5.0 |  1000 |  2,832.3 ns |    10.90 ns |    10.20 ns |  2,829.8 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  2,821.5 ns |     6.45 ns |     5.72 ns |  2,821.3 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 10,002.6 ns |    37.52 ns |    35.10 ns | 10,008.6 ns |  3.53 |    0.02 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  3,035.8 ns |    18.74 ns |    16.61 ns |  3,038.5 ns |  1.07 |    0.01 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  3,759.8 ns |    20.21 ns |    17.91 ns |  3,758.2 ns |  1.33 |    0.01 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 36,690.4 ns | 1,031.11 ns | 3,040.25 ns | 34,835.5 ns | 12.61 |    0.74 | 9.1553 |     - |     - |  19,155 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 |  5,833.6 ns |    29.16 ns |    24.35 ns |  5,839.1 ns |  2.06 |    0.01 | 0.1678 |     - |     - |     360 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  3,354.3 ns |    12.58 ns |    10.51 ns |  3,348.2 ns |  1.18 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |    708.9 ns |     2.74 ns |     2.43 ns |    709.1 ns |  0.25 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  1,848.1 ns |     4.39 ns |     3.89 ns |  1,847.7 ns |  0.65 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |    648.9 ns |     3.06 ns |     2.55 ns |    648.9 ns |  0.23 |    0.00 |      - |     - |     - |         - |
|                      |        |          |       |             |             |             |             |       |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |    735.0 ns |     2.83 ns |     2.65 ns |    735.5 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |    738.3 ns |     2.86 ns |     2.54 ns |    737.9 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  4,724.2 ns |    34.70 ns |    28.98 ns |  4,726.0 ns |  6.43 |    0.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  2,844.3 ns |    12.80 ns |    11.97 ns |  2,845.3 ns |  3.87 |    0.02 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  3,561.3 ns |    15.63 ns |    13.86 ns |  3,561.8 ns |  4.84 |    0.02 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 34,824.7 ns | 1,065.85 ns | 3,109.14 ns | 32,888.9 ns | 45.84 |    2.08 | 9.0942 |     - |     - |  19,098 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  6,123.9 ns |    49.91 ns |    41.67 ns |  6,114.4 ns |  8.33 |    0.07 | 0.1678 |     - |     - |     360 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  3,333.0 ns |    11.41 ns |     9.53 ns |  3,334.5 ns |  4.54 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |    815.1 ns |     3.44 ns |     3.22 ns |    814.5 ns |  1.11 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  1,854.3 ns |     9.68 ns |     8.08 ns |  1,855.2 ns |  2.52 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |    713.1 ns |     3.33 ns |     3.12 ns |    713.8 ns |  0.97 |    0.01 |      - |     - |     - |         - |
