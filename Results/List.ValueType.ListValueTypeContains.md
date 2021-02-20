## List.ValueType.ListValueTypeContains

### Source
[ListValueTypeContains.cs](../LinqBenchmarks/List/ValueType/ListValueTypeContains.cs)

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
|               Method | Count |        Mean |      Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|-----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |    **56.65 ns** |   **0.113 ns** |   **0.105 ns** |    **56.63 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    92.38 ns |   1.859 ns |   3.206 ns |    90.81 ns |  1.65 |    0.06 |      - |     - |     - |         - |
|                 Linq |    10 |    29.53 ns |   0.060 ns |   0.056 ns |    29.54 ns |  0.52 |    0.00 |      - |     - |     - |         - |
|           LinqFaster |    10 |    28.08 ns |   0.039 ns |   0.032 ns |    28.08 ns |  0.50 |    0.00 |      - |     - |     - |         - |
|               LinqAF |    10 |    31.41 ns |   0.055 ns |   0.043 ns |    31.40 ns |  0.55 |    0.00 |      - |     - |     - |         - |
|           StructLinq |    10 |    55.72 ns |   0.129 ns |   0.121 ns |    55.72 ns |  0.98 |    0.00 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |    10 |    58.11 ns |   0.167 ns |   0.139 ns |    58.08 ns |  1.03 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    28.16 ns |   0.092 ns |   0.086 ns |    28.15 ns |  0.50 |    0.00 |      - |     - |     - |         - |
|                      |       |             |            |            |             |       |         |        |       |       |           |
|              **ForLoop** |  **1000** | **6,496.40 ns** |  **42.844 ns** |  **33.449 ns** | **6,485.06 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 8,092.96 ns | 161.094 ns | 298.598 ns | 8,018.65 ns |  1.24 |    0.05 |      - |     - |     - |         - |
|                 Linq |  1000 | 2,075.98 ns |   6.716 ns |   6.282 ns | 2,074.15 ns |  0.32 |    0.00 |      - |     - |     - |         - |
|           LinqFaster |  1000 | 2,075.72 ns |   8.392 ns |   7.850 ns | 2,073.50 ns |  0.32 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 | 2,079.49 ns |   8.159 ns |   6.370 ns | 2,080.74 ns |  0.32 |    0.00 |      - |     - |     - |         - |
|           StructLinq |  1000 | 4,116.97 ns |  12.154 ns |  11.369 ns | 4,112.99 ns |  0.63 |    0.00 | 0.0153 |     - |     - |      40 B |
| StructLinq_IFunction |  1000 | 4,126.14 ns |  13.871 ns |  12.975 ns | 4,121.50 ns |  0.63 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 2,075.08 ns |   6.241 ns |   5.532 ns | 2,074.38 ns |  0.32 |    0.00 |      - |     - |     - |         - |
