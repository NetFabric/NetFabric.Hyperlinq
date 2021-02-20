## List.ValueType.ListValueTypeSelectContains

### Source
[ListValueTypeSelectContains.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectContains.cs)

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
|               Method | Count |        Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |    **57.41 ns** |   **0.148 ns** |   **0.131 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    96.82 ns |   1.915 ns |   1.967 ns |  1.68 |    0.04 |      - |     - |     - |         - |
|                 Linq |    10 |    29.82 ns |   0.121 ns |   0.107 ns |  0.52 |    0.00 |      - |     - |     - |         - |
|           LinqFaster |    10 |    28.62 ns |   0.110 ns |   0.098 ns |  0.50 |    0.00 |      - |     - |     - |         - |
|               LinqAF |    10 |    30.40 ns |   0.103 ns |   0.092 ns |  0.53 |    0.00 |      - |     - |     - |         - |
|           StructLinq |    10 |    55.28 ns |   0.171 ns |   0.160 ns |  0.96 |    0.00 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |    10 |    58.10 ns |   0.126 ns |   0.098 ns |  1.01 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    26.26 ns |   0.047 ns |   0.042 ns |  0.46 |    0.00 |      - |     - |     - |         - |
|                      |       |             |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** | **6,119.45 ns** |  **10.721 ns** |   **8.370 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 7,915.73 ns | 157.331 ns | 287.688 ns |  1.31 |    0.04 |      - |     - |     - |         - |
|                 Linq |  1000 | 2,088.91 ns |   7.149 ns |   6.338 ns |  0.34 |    0.00 |      - |     - |     - |         - |
|           LinqFaster |  1000 | 2,086.17 ns |   5.876 ns |   5.209 ns |  0.34 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 | 2,264.66 ns |   9.094 ns |   7.594 ns |  0.37 |    0.00 |      - |     - |     - |         - |
|           StructLinq |  1000 | 4,175.80 ns |  13.686 ns |  10.685 ns |  0.68 |    0.00 | 0.0153 |     - |     - |      40 B |
| StructLinq_IFunction |  1000 | 4,092.29 ns |   9.329 ns |   7.790 ns |  0.67 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 2,086.34 ns |   3.331 ns |   2.953 ns |  0.34 |    0.00 |      - |     - |     - |         - |
