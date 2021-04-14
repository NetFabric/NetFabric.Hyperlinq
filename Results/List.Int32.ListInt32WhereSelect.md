## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|               Method |    Job |  Runtime | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 |  1000 |  1,454.5 ns |  10.64 ns |   8.88 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  3,353.3 ns |  20.78 ns |  18.42 ns |  2.31 |    0.02 |       - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  9,872.9 ns |  35.84 ns |  33.52 ns |  6.79 |    0.04 |  0.0610 |     - |     - |     152 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  5,874.3 ns |  25.14 ns |  23.52 ns |  4.04 |    0.02 |  2.0523 |     - |     - |   4,304 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 11,070.8 ns |  51.34 ns |  45.51 ns |  7.61 |    0.06 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 67,328.8 ns | 510.76 ns | 452.78 ns | 46.29 |    0.48 | 15.7471 |     - |     - |  33,071 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 16,766.4 ns |  50.18 ns |  44.48 ns | 11.53 |    0.09 |  0.3357 |     - |     - |     760 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  5,295.9 ns |  30.47 ns |  25.44 ns |  3.64 |    0.03 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  1,762.2 ns |  21.36 ns |  18.94 ns |  1.21 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  5,568.3 ns |  22.33 ns |  18.65 ns |  3.83 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  2,119.3 ns |  13.86 ns |  12.97 ns |  1.46 |    0.01 |       - |     - |     - |         - |
|                      |        |          |       |             |           |           |       |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |  1,376.4 ns |  22.40 ns |  19.86 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |    836.0 ns |   6.27 ns |   5.24 ns |  0.61 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  9,097.2 ns |  14.72 ns |  12.29 ns |  6.62 |    0.10 |  0.0610 |     - |     - |     152 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  5,166.9 ns |  17.14 ns |  15.19 ns |  3.75 |    0.05 |  2.0523 |     - |     - |   4,304 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 11,531.7 ns |  62.49 ns |  58.45 ns |  8.38 |    0.12 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 62,026.3 ns | 383.59 ns | 358.81 ns | 45.10 |    0.74 | 15.5029 |     - |     - |  32,620 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 14,968.7 ns | 193.26 ns | 171.32 ns | 10.88 |    0.13 |  0.3510 |     - |     - |     760 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  5,755.2 ns |  35.49 ns |  33.20 ns |  4.18 |    0.07 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  5,610.5 ns |  12.60 ns |  11.17 ns |  4.08 |    0.06 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  4,887.9 ns |  19.77 ns |  16.51 ns |  3.56 |    0.05 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  2,060.0 ns |  15.36 ns |  12.83 ns |  1.50 |    0.02 |       - |     - |     - |         - |
