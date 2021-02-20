## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|               Method | Count |          Mean |       Error |      StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |--------------:|------------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |      **7.606 ns** |   **0.0203 ns** |   **0.0169 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     13.866 ns |   0.0684 ns |   0.0607 ns |  1.82 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |     78.692 ns |   0.1040 ns |   0.0812 ns | 10.34 |    0.02 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |     26.936 ns |   0.0776 ns |   0.0688 ns |  3.54 |    0.01 |      - |     - |     - |         - |
|               LinqAF |    10 |     85.410 ns |   0.8540 ns |   0.7131 ns | 11.23 |    0.09 |      - |     - |     - |         - |
|           StructLinq |    10 |     47.858 ns |   0.1075 ns |   0.0898 ns |  6.29 |    0.02 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |     39.977 ns |   0.0837 ns |   0.0742 ns |  5.26 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     24.982 ns |   0.0551 ns |   0.0460 ns |  3.28 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     16.608 ns |   0.0413 ns |   0.0386 ns |  2.18 |    0.01 |      - |     - |     - |         - |
|                      |       |               |             |             |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |    **817.108 ns** |   **2.5061 ns** |   **2.3442 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  2,026.770 ns |   5.7896 ns |   4.8346 ns |  2.48 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 11,874.753 ns |  46.4034 ns |  36.2288 ns | 14.53 |    0.05 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 |  4,620.770 ns |   9.5450 ns |   8.9284 ns |  5.66 |    0.02 |      - |     - |     - |         - |
|               LinqAF |  1000 | 11,397.233 ns | 127.8790 ns | 113.3614 ns | 13.95 |    0.16 |      - |     - |     - |         - |
|           StructLinq |  1000 |  6,367.070 ns |  14.7573 ns |  13.8040 ns |  7.79 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |  1,680.320 ns |   4.7557 ns |   4.2158 ns |  2.06 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |  1,835.327 ns |   5.3488 ns |   5.0033 ns |  2.25 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |    999.181 ns |   2.5310 ns |   2.2437 ns |  1.22 |    0.00 |      - |     - |     - |         - |
