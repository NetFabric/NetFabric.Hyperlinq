## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|               Method |    Job |  Runtime | Count |     Mean |    Error |    StdDev |   Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |---------:|---------:|----------:|---------:|------:|--------:|--------:|--------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 |  1000 | 15.22 μs | 0.133 μs |  0.118 μs | 15.18 μs |  1.00 |    0.00 | 15.5487 |  7.7667 |     - |     95 KB |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 | 16.74 μs | 0.199 μs |  0.187 μs | 16.68 μs |  1.10 |    0.01 | 15.5640 |  7.7820 |     - |     95 KB |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 17.34 μs | 0.542 μs |  1.408 μs | 16.81 μs |  1.26 |    0.08 | 31.2195 |       - |     - |     64 KB |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 | 15.58 μs | 0.212 μs |  0.188 μs | 15.55 μs |  1.02 |    0.02 | 15.1672 |  7.5684 |     - |     94 KB |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 32.21 μs | 0.469 μs |  0.416 μs | 32.32 μs |  2.12 |    0.03 | 46.5088 |       - |     - |     95 KB |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 75.03 μs | 0.777 μs |  0.688 μs | 74.92 μs |  4.93 |    0.06 | 68.8477 | 17.2119 |     - |    182 KB |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 67.93 μs | 0.911 μs |  0.807 μs | 67.71 μs |  4.46 |    0.05 | 15.6250 |  7.8125 |     - |     96 KB |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 | 15.80 μs | 0.181 μs |  0.152 μs | 15.74 μs |  1.04 |    0.01 |  5.1270 |  2.5635 |     - |     32 KB |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 11.10 μs | 0.172 μs |  0.247 μs | 11.06 μs |  0.73 |    0.02 | 15.1367 |       - |     - |     31 KB |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 16.58 μs | 0.270 μs |  0.253 μs | 16.51 μs |  1.09 |    0.02 |  5.0964 |  2.5330 |     - |     31 KB |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 11.91 μs | 0.085 μs |  0.079 μs | 11.88 μs |  0.78 |    0.01 |  5.1117 |  2.5482 |     - |     31 KB |
|                      |        |          |       |          |          |           |          |       |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 | 18.19 μs | 0.169 μs |  0.158 μs | 18.20 μs |  1.00 |    0.00 | 15.5640 |  7.7820 |     - |     95 KB |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 | 16.51 μs | 0.095 μs |  0.079 μs | 16.50 μs |  0.91 |    0.01 | 15.5640 |  7.7820 |     - |     95 KB |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 17.06 μs | 0.168 μs |  0.149 μs | 17.08 μs |  0.94 |    0.01 | 10.4675 |  5.2185 |     - |     64 KB |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 | 14.19 μs | 0.329 μs |  0.905 μs | 13.79 μs |  0.86 |    0.01 | 45.4407 |       - |     - |     94 KB |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 32.76 μs | 0.613 μs |  1.359 μs | 32.38 μs |  1.85 |    0.09 | 46.5088 |       - |     - |     95 KB |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 83.05 μs | 1.562 μs |  1.604 μs | 82.59 μs |  4.57 |    0.09 | 68.8477 | 17.2119 |     - |    182 KB |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 85.87 μs | 4.928 μs | 14.529 μs | 80.39 μs |  4.64 |    0.19 | 46.7529 |       - |     - |     96 KB |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 | 15.76 μs | 0.294 μs |  0.738 μs | 15.50 μs |  0.92 |    0.06 | 15.3809 |       - |     - |     32 KB |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 11.17 μs | 0.288 μs |  0.848 μs | 10.71 μs |  0.69 |    0.03 | 15.1367 |       - |     - |     31 KB |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 20.85 μs | 0.550 μs |  1.623 μs | 20.69 μs |  1.01 |    0.08 | 15.1367 |       - |     - |     31 KB |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 12.96 μs | 0.205 μs |  0.515 μs | 12.77 μs |  0.76 |    0.03 | 15.1367 |       - |     - |     31 KB |
