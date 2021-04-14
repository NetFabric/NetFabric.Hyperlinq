## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
|               Method |    Job |  Runtime | Count |     Mean |    Error |   StdDev |   Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |---------:|---------:|---------:|---------:|------:|--------:|--------:|--------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 |  1000 | 14.81 μs | 0.296 μs | 0.644 μs | 14.53 μs |  1.00 |    0.00 | 46.5088 |       - |     - |     95 KB |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 | 19.40 μs | 0.080 μs | 0.067 μs | 19.38 μs |  1.23 |    0.03 | 15.5640 |  7.7820 |     - |     95 KB |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 18.51 μs | 0.329 μs | 0.275 μs | 18.57 μs |  1.17 |    0.04 | 10.4675 |  5.2185 |     - |     64 KB |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 | 20.71 μs | 0.405 μs | 0.688 μs | 20.51 μs |  1.38 |    0.06 | 46.5088 |       - |     - |     95 KB |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 34.60 μs | 0.591 μs | 0.553 μs | 34.68 μs |  2.21 |    0.11 | 46.5088 |       - |     - |     95 KB |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 86.67 μs | 0.438 μs | 0.342 μs | 86.60 μs |  5.44 |    0.03 | 68.8477 | 17.2119 |     - |    183 KB |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 77.34 μs | 0.886 μs | 0.785 μs | 77.24 μs |  4.92 |    0.17 | 46.7529 |       - |     - |     96 KB |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 | 15.47 μs | 0.165 μs | 0.146 μs | 15.50 μs |  0.98 |    0.03 | 15.3809 |       - |     - |     32 KB |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 11.47 μs | 0.071 μs | 0.063 μs | 11.46 μs |  0.73 |    0.03 |  5.0964 |  2.5482 |     - |     31 KB |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 16.63 μs | 0.236 μs | 0.209 μs | 16.72 μs |  1.06 |    0.04 |  5.0964 |  2.5330 |     - |     31 KB |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 12.01 μs | 0.216 μs | 0.575 μs | 11.80 μs |  0.82 |    0.04 | 15.1367 |       - |     - |     31 KB |
|                      |        |          |       |          |          |          |          |       |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 | 15.47 μs | 0.467 μs | 1.308 μs | 14.74 μs |  1.00 |    0.00 | 46.5088 |       - |     - |     95 KB |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 | 20.21 μs | 0.396 μs | 0.580 μs | 20.29 μs |  1.19 |    0.07 | 46.5088 |       - |     - |     95 KB |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 18.75 μs | 0.260 μs | 0.243 μs | 18.77 μs |  1.09 |    0.07 | 10.4675 |  5.2185 |     - |     64 KB |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 | 22.50 μs | 0.448 μs | 0.614 μs | 22.68 μs |  1.32 |    0.08 | 46.5088 |       - |     - |     95 KB |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 35.22 μs | 0.693 μs | 1.078 μs | 35.18 μs |  2.07 |    0.13 | 46.5088 |       - |     - |     95 KB |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 82.40 μs | 0.841 μs | 0.787 μs | 82.52 μs |  4.78 |    0.28 | 68.8477 | 17.2119 |     - |    183 KB |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 65.68 μs | 0.476 μs | 0.445 μs | 65.61 μs |  3.81 |    0.23 | 46.8750 |       - |     - |     96 KB |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 | 15.76 μs | 0.397 μs | 1.171 μs | 15.12 μs |  1.03 |    0.07 | 15.3809 |       - |     - |     32 KB |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 11.07 μs | 0.188 μs | 0.147 μs | 11.03 μs |  0.63 |    0.04 |  5.0964 |  2.5482 |     - |     31 KB |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 20.20 μs | 0.332 μs | 0.294 μs | 20.33 μs |  1.17 |    0.08 |  5.0964 |  2.5330 |     - |     31 KB |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 17.97 μs | 0.060 μs | 0.050 μs | 17.96 μs |  1.03 |    0.06 |  5.0964 |  2.5330 |     - |     31 KB |
