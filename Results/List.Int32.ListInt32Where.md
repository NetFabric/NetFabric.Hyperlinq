## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|              ForLoop | .NET 5 | .NET 5.0 |  1000 |    865.1 ns |   4.26 ns |   3.56 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  3,468.1 ns |  10.42 ns |   8.14 ns |  4.01 |    0.02 |       - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  8,808.4 ns |  21.38 ns |  18.95 ns | 10.18 |    0.05 |  0.0305 |     - |     - |      72 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  4,561.3 ns |  20.57 ns |  18.24 ns |  5.27 |    0.02 |  2.0523 |     - |     - |   4,304 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  9,416.3 ns |  48.41 ns |  45.28 ns | 10.88 |    0.06 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 60,639.8 ns | 331.56 ns | 276.87 ns | 70.10 |    0.42 | 14.7705 |     - |     - |  31,069 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 15,455.5 ns |  99.91 ns |  83.43 ns | 17.87 |    0.11 |  0.2747 |     - |     - |     608 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  5,648.8 ns |  16.57 ns |  13.83 ns |  6.53 |    0.03 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  1,597.5 ns |  31.63 ns |  29.59 ns |  1.84 |    0.03 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  5,483.6 ns |  17.62 ns |  15.62 ns |  6.34 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  2,052.7 ns |  13.31 ns |  11.80 ns |  2.37 |    0.01 |       - |     - |     - |         - |
|                      |        |          |       |             |           |           |       |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |    976.9 ns |   7.69 ns |   6.82 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  1,735.5 ns |   7.20 ns |   6.38 ns |  1.78 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  7,409.0 ns |  31.14 ns |  26.01 ns |  7.58 |    0.06 |  0.0305 |     - |     - |      72 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  4,180.0 ns |  82.01 ns | 100.72 ns |  4.29 |    0.12 |  2.0523 |     - |     - |   4,304 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 10,792.6 ns |  40.08 ns |  33.47 ns | 11.04 |    0.09 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 65,185.4 ns | 612.68 ns | 543.13 ns | 66.73 |    0.57 | 14.5264 |     - |     - |  30,627 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 14,101.3 ns |  41.36 ns |  36.67 ns | 14.44 |    0.11 |  0.2899 |     - |     - |     608 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  3,747.4 ns |  14.70 ns |  13.03 ns |  3.84 |    0.03 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1,483.2 ns |  14.08 ns |  13.17 ns |  1.52 |    0.02 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  3,977.2 ns |  16.33 ns |  14.48 ns |  4.07 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  2,057.5 ns |   9.16 ns |   8.57 ns |  2.11 |    0.02 |       - |     - |     - |         - |
