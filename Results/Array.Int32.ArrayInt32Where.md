## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|               Method |    Job |  Runtime | Count |        Mean |       Error |      StdDev |      Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |------------:|------------:|------------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 |  1000 |    803.7 ns |     4.70 ns |     4.39 ns |    803.5 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |    632.7 ns |     3.65 ns |     3.41 ns |    632.9 ns |  0.79 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  6,362.8 ns |    28.75 ns |    25.49 ns |  6,363.7 ns |  7.92 |    0.04 |  0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  3,949.5 ns |    78.59 ns |   179.00 ns |  3,933.3 ns |  5.08 |    0.14 |  2.8954 |     - |     - |   6,064 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  6,376.7 ns |    30.79 ns |    27.29 ns |  6,371.7 ns |  7.94 |    0.05 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 50,501.4 ns | 1,549.35 ns | 4,568.29 ns | 47,274.5 ns | 64.77 |    4.98 | 14.2822 |     - |     - |  29,930 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 15,009.7 ns |    44.09 ns |    36.82 ns | 15,012.8 ns | 18.68 |    0.11 |  0.2747 |     - |     - |     584 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  5,284.2 ns |    16.74 ns |    15.65 ns |  5,280.3 ns |  6.58 |    0.05 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  1,551.8 ns |    11.13 ns |     9.29 ns |  1,549.2 ns |  1.93 |    0.02 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  6,030.1 ns |    18.31 ns |    17.13 ns |  6,025.9 ns |  7.50 |    0.05 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  2,059.2 ns |     5.96 ns |     5.29 ns |  2,059.5 ns |  2.56 |    0.01 |       - |     - |     - |         - |
|                      |        |          |       |             |             |             |             |       |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |    740.9 ns |     4.96 ns |     4.39 ns |    740.3 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |    740.3 ns |     4.61 ns |     4.31 ns |    739.2 ns |  1.00 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  7,080.8 ns |    42.62 ns |    39.86 ns |  7,065.2 ns |  9.56 |    0.09 |  0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  3,820.9 ns |    23.49 ns |    20.82 ns |  3,817.1 ns |  5.16 |    0.04 |  2.8915 |     - |     - |   6,064 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  4,756.5 ns |    21.25 ns |    18.84 ns |  4,759.1 ns |  6.42 |    0.05 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 41,215.5 ns |   264.59 ns |   220.94 ns | 41,193.6 ns | 55.62 |    0.45 | 14.1602 |     - |     - |  29,679 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 13,111.0 ns |    36.42 ns |    30.41 ns | 13,118.5 ns | 17.69 |    0.12 |  0.2747 |     - |     - |     584 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  3,252.3 ns |    15.89 ns |    13.27 ns |  3,247.4 ns |  4.39 |    0.04 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1,771.3 ns |     5.24 ns |     4.38 ns |  1,771.2 ns |  2.39 |    0.02 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  3,695.0 ns |    25.22 ns |    23.59 ns |  3,687.0 ns |  4.99 |    0.05 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  2,041.6 ns |    35.16 ns |    29.36 ns |  2,034.4 ns |  2.76 |    0.05 |       - |     - |     - |         - |
