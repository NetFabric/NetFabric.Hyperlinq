## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** | **1000** |    **10** |     **56.04 ns** |   **0.078 ns** |   **0.069 ns** |   **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  5,369.04 ns |  13.389 ns |  11.181 ns |  95.82 |    0.23 |  0.0458 |     - |     - |      96 B |
|                 Linq | 1000 |    10 |    247.11 ns |   1.037 ns |   0.866 ns |   4.41 |    0.02 |  0.1526 |     - |     - |     320 B |
|           LinqFaster | 1000 |    10 |    319.67 ns |   3.332 ns |   3.117 ns |   5.71 |    0.06 |  1.0710 |     - |     - |    2240 B |
|               LinqAF | 1000 |    10 |  7,949.45 ns | 153.386 ns | 229.581 ns | 140.24 |    3.91 |       - |     - |     - |         - |
|           StructLinq | 1000 |    10 |    123.37 ns |   0.530 ns |   0.470 ns |   2.20 |    0.01 |  0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |    10 |     97.76 ns |   0.116 ns |   0.103 ns |   1.74 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |     78.16 ns |   0.162 ns |   0.143 ns |   1.39 |    0.00 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |    106.21 ns |   0.199 ns |   0.176 ns |   1.90 |    0.00 |       - |     - |     - |         - |
|                      |      |       |              |            |            |        |         |         |       |       |           |
|              **ForLoop** | **1000** |  **1000** |  **5,512.57 ns** |  **10.126 ns** |   **8.976 ns** |   **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 |  7,522.63 ns |  15.617 ns |  13.844 ns |   1.36 |    0.00 |  0.0458 |     - |     - |      96 B |
|                 Linq | 1000 |  1000 | 19,984.80 ns |  80.277 ns |  67.035 ns |   3.63 |    0.01 |  0.1526 |     - |     - |     320 B |
|           LinqFaster | 1000 |  1000 | 32,800.71 ns | 408.263 ns | 381.889 ns |   5.94 |    0.06 | 90.8813 |     - |     - |  193616 B |
|               LinqAF | 1000 |  1000 | 37,315.71 ns | 734.821 ns | 754.607 ns |   6.77 |    0.14 |       - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  8,044.26 ns |  39.829 ns |  33.259 ns |   1.46 |    0.01 |  0.0458 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |  1000 |  5,130.07 ns |   7.288 ns |   5.690 ns |   0.93 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 |  6,755.53 ns |  14.991 ns |  13.289 ns |   1.23 |    0.00 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  5,025.55 ns |  20.132 ns |  18.831 ns |   0.91 |    0.00 |       - |     - |     - |         - |
