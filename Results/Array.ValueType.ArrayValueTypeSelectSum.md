## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

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
|               Method | Count |         Mean |       Error |      StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|------------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **3.994 ns** |   **0.0162 ns** |   **0.0151 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    13.839 ns |   0.0630 ns |   0.0589 ns |  3.46 |    0.02 |      - |     - |     - |         - |
|                 Linq |    10 |    86.257 ns |   0.1999 ns |   0.1870 ns | 21.59 |    0.09 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |    31.576 ns |   0.0594 ns |   0.0555 ns |  7.91 |    0.03 |      - |     - |     - |         - |
|               LinqAF |    10 |    83.677 ns |   1.5732 ns |   1.4716 ns | 20.95 |    0.38 |      - |     - |     - |         - |
|           StructLinq |    10 |    29.349 ns |   0.0791 ns |   0.0740 ns |  7.35 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     7.509 ns |   0.0314 ns |   0.0263 ns |  1.88 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    26.831 ns |   0.1245 ns |   0.1165 ns |  6.72 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    15.932 ns |   0.0439 ns |   0.0410 ns |  3.99 |    0.01 |      - |     - |     - |         - |
|                      |       |              |             |             |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **611.004 ns** |   **1.7487 ns** |   **1.4603 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 2,012.363 ns |   5.6327 ns |   4.9932 ns |  3.29 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 6,501.175 ns |  10.9776 ns |  10.2684 ns | 10.64 |    0.03 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 | 3,521.847 ns |   3.2036 ns |   2.6751 ns |  5.76 |    0.01 |      - |     - |     - |         - |
|               LinqAF |  1000 | 7,404.890 ns | 145.8687 ns | 189.6706 ns | 12.02 |    0.32 |      - |     - |     - |         - |
|           StructLinq |  1000 | 1,929.109 ns |   5.6708 ns |   5.3045 ns |  3.16 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |   711.416 ns |   1.0885 ns |   0.9090 ns |  1.16 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 1,842.454 ns |   5.8729 ns |   5.4935 ns |  3.01 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |   600.153 ns |   3.0077 ns |   2.8134 ns |  0.98 |    0.00 |      - |     - |     - |         - |
