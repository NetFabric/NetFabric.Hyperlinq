## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|               Method |    Job |  Runtime | Skip | Count |        Mean |       Error |      StdDev |      Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |----- |------ |------------:|------------:|------------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |    941.4 ns |     5.55 ns |     4.63 ns |    941.5 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |  4,893.6 ns |    44.83 ns |    39.74 ns |  4,885.1 ns |  5.20 |    0.05 |  0.0153 |     - |     - |      32 B |
|                 Linq | .NET 5 | .NET 5.0 | 1000 |  1000 | 16,231.3 ns |    50.98 ns |    42.57 ns | 16,232.4 ns | 17.24 |    0.10 |  0.0610 |     - |     - |     152 B |
|           LinqFaster | .NET 5 | .NET 5.0 | 1000 |  1000 |  5,060.7 ns |   101.04 ns |   278.29 ns |  4,885.2 ns |  5.39 |    0.28 |  6.7215 |     - |     - |  14,064 B |
|               LinqAF | .NET 5 | .NET 5.0 | 1000 |  1000 | 14,574.0 ns |    67.99 ns |    63.60 ns | 14,554.7 ns | 15.48 |    0.10 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |  1000 | 66,371.0 ns |   637.96 ns |   596.75 ns | 66,327.8 ns | 70.49 |    0.74 | 16.1133 |     - |     - |  33,844 B |
|              Streams | .NET 5 | .NET 5.0 | 1000 |  1000 | 23,716.8 ns |   113.40 ns |    94.69 ns | 23,717.8 ns | 25.19 |    0.19 |  0.4272 |     - |     - |     912 B |
|           StructLinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  5,207.0 ns |    22.83 ns |    21.35 ns |  5,213.1 ns |  5.53 |    0.04 |  0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  1,752.4 ns |    12.40 ns |    11.60 ns |  1,751.3 ns |  1.86 |    0.02 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  4,207.4 ns |    22.18 ns |    19.67 ns |  4,215.0 ns |  4.47 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  2,110.5 ns |    10.29 ns |     9.62 ns |  2,110.1 ns |  2.24 |    0.01 |       - |     - |     - |         - |
|                      |        |          |      |       |             |             |             |             |       |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |    933.4 ns |     3.11 ns |     2.90 ns |    933.8 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  2,602.1 ns |    12.24 ns |    11.45 ns |  2,599.4 ns |  2.79 |    0.01 |  0.0153 |     - |     - |      32 B |
|                 Linq | .NET 6 | .NET 6.0 | 1000 |  1000 | 12,532.0 ns |    64.07 ns |    56.80 ns | 12,507.7 ns | 13.43 |    0.08 |  0.0610 |     - |     - |     152 B |
|           LinqFaster | .NET 6 | .NET 6.0 | 1000 |  1000 |  4,784.5 ns |    37.03 ns |    34.64 ns |  4,783.2 ns |  5.13 |    0.04 |  6.7215 |     - |     - |  14,064 B |
|               LinqAF | .NET 6 | .NET 6.0 | 1000 |  1000 | 14,471.8 ns |    39.20 ns |    34.75 ns | 14,484.3 ns | 15.50 |    0.07 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |  1000 | 52,417.8 ns | 1,489.87 ns | 4,392.92 ns | 49,371.4 ns | 58.48 |    4.19 | 16.0522 |     - |     - |  33,593 B |
|              Streams | .NET 6 | .NET 6.0 | 1000 |  1000 | 20,516.2 ns |    64.19 ns |    53.61 ns | 20,523.5 ns | 21.98 |    0.10 |  0.4272 |     - |     - |     912 B |
|           StructLinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  3,242.6 ns |    19.17 ns |    16.01 ns |  3,243.4 ns |  3.47 |    0.02 |  0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,536.0 ns |     6.95 ns |     6.16 ns |  1,536.0 ns |  1.65 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  6,855.5 ns |    22.77 ns |    19.01 ns |  6,851.1 ns |  7.34 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  5,141.3 ns |    20.38 ns |    17.02 ns |  5,147.2 ns |  5.51 |    0.03 |       - |     - |     - |         - |
