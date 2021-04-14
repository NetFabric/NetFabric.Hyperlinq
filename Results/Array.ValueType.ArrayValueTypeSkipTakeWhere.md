## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|               Method |    Job |  Runtime | Skip | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |    Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |----- |------ |----------:|----------:|----------:|----------:|------:|--------:|---------:|--------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |  5.183 μs | 0.0999 μs | 0.0885 μs |  5.144 μs |  1.00 |    0.00 |        - |       - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |  5.332 μs | 0.0227 μs | 0.0177 μs |  5.331 μs |  1.03 |    0.02 |   0.0153 |       - |     - |      32 B |
|                 Linq | .NET 5 | .NET 5.0 | 1000 |  1000 | 20.965 μs | 0.0669 μs | 0.0593 μs | 20.969 μs |  4.05 |    0.07 |   0.1526 |       - |     - |     320 B |
|           LinqFaster | .NET 5 | .NET 5.0 | 1000 |  1000 | 24.846 μs | 0.5605 μs | 1.6527 μs | 23.826 μs |  4.77 |    0.30 | 105.2551 |       - |     - | 223,520 B |
|               LinqAF | .NET 5 | .NET 5.0 | 1000 |  1000 | 30.873 μs | 0.6038 μs | 0.6953 μs | 30.977 μs |  5.96 |    0.12 |        - |       - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |  1000 | 95.279 μs | 1.2054 μs | 1.1275 μs | 95.320 μs | 18.40 |    0.44 |  68.1152 | 22.7051 |     - | 186,402 B |
|              Streams | .NET 5 | .NET 5.0 | 1000 |  1000 | 30.243 μs | 0.1242 μs | 0.1037 μs | 30.242 μs |  5.83 |    0.11 |   0.5493 |       - |     - |   1,152 B |
|           StructLinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  8.952 μs | 0.0731 μs | 0.0571 μs |  8.932 μs |  1.73 |    0.03 |   0.0458 |       - |     - |      96 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  6.866 μs | 0.0137 μs | 0.0114 μs |  6.870 μs |  1.32 |    0.02 |        - |       - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 | 1000 |  1000 | 12.221 μs | 0.0644 μs | 0.0538 μs | 12.238 μs |  2.36 |    0.04 |        - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  8.505 μs | 0.0893 μs | 0.0792 μs |  8.520 μs |  1.64 |    0.03 |        - |       - |     - |         - |
|                      |        |          |      |       |           |           |           |           |       |         |          |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  5.032 μs | 0.0213 μs | 0.0189 μs |  5.027 μs |  1.00 |    0.00 |        - |       - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  4.839 μs | 0.0145 μs | 0.0136 μs |  4.835 μs |  0.96 |    0.01 |   0.0153 |       - |     - |      32 B |
|                 Linq | .NET 6 | .NET 6.0 | 1000 |  1000 | 19.722 μs | 0.0674 μs | 0.0598 μs | 19.728 μs |  3.92 |    0.02 |   0.1526 |       - |     - |     320 B |
|           LinqFaster | .NET 6 | .NET 6.0 | 1000 |  1000 | 23.992 μs | 0.2160 μs | 0.1915 μs | 24.003 μs |  4.77 |    0.04 | 105.2551 |       - |     - | 223,520 B |
|               LinqAF | .NET 6 | .NET 6.0 | 1000 |  1000 | 31.155 μs | 0.5891 μs | 0.6049 μs | 31.237 μs |  6.21 |    0.12 |        - |       - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |  1000 | 72.152 μs | 0.4690 μs | 0.4158 μs | 72.061 μs | 14.34 |    0.11 |  68.1152 | 22.7051 |     - | 186,153 B |
|              Streams | .NET 6 | .NET 6.0 | 1000 |  1000 | 28.011 μs | 0.4466 μs | 0.4178 μs | 27.825 μs |  5.56 |    0.09 |   0.5493 |       - |     - |   1,152 B |
|           StructLinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  7.956 μs | 0.0378 μs | 0.0354 μs |  7.959 μs |  1.58 |    0.01 |   0.0458 |       - |     - |      96 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  5.834 μs | 0.0166 μs | 0.0147 μs |  5.831 μs |  1.16 |    0.01 |        - |       - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 | 1000 |  1000 | 12.514 μs | 0.0884 μs | 0.0827 μs | 12.540 μs |  2.49 |    0.02 |        - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  9.668 μs | 0.0339 μs | 0.0317 μs |  9.669 μs |  1.92 |    0.01 |        - |       - |     - |         - |
