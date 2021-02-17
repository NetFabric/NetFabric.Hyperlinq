## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta38](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta38)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |          Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |--------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |     **0** |     **0.1982 ns** |  **0.0048 ns** |  **0.0042 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |     0.5105 ns |  0.0104 ns |  0.0092 ns |   2.58 |    0.08 |      - |     - |     - |         - |
|                 Linq |     0 |     7.5875 ns |  0.0493 ns |  0.0437 ns |  38.29 |    0.89 |      - |     - |     - |         - |
|           LinqFaster |     0 |     1.8798 ns |  0.0134 ns |  0.0119 ns |   9.49 |    0.21 |      - |     - |     - |         - |
|               LinqAF |     0 |    12.0051 ns |  0.0299 ns |  0.0265 ns |  60.58 |    1.35 |      - |     - |     - |         - |
|           StructLinq |     0 |    28.1058 ns |  0.1516 ns |  0.1418 ns | 141.89 |    3.13 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |     0 |    17.2449 ns |  0.0486 ns |  0.0455 ns |  86.99 |    1.87 |      - |     - |     - |         - |
|            Hyperlinq |     0 |    11.7199 ns |  0.0277 ns |  0.0246 ns |  59.14 |    1.24 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |     9.3418 ns |  0.0188 ns |  0.0176 ns |  47.15 |    1.05 |      - |     - |     - |         - |
|                      |       |               |            |            |        |         |        |       |       |           |
|              **ForLoop** |    **10** |     **6.9277 ns** |  **0.0313 ns** |  **0.0277 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     6.6863 ns |  0.0460 ns |  0.0430 ns |   0.96 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    68.9035 ns |  0.2597 ns |  0.2430 ns |   9.94 |    0.05 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |    21.6965 ns |  0.0653 ns |  0.0579 ns |   3.13 |    0.01 |      - |     - |     - |         - |
|               LinqAF |    10 |    36.0883 ns |  0.3981 ns |  0.3324 ns |   5.21 |    0.05 |      - |     - |     - |         - |
|           StructLinq |    10 |    48.3521 ns |  0.2237 ns |  0.1983 ns |   6.98 |    0.04 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    21.8650 ns |  0.0569 ns |  0.0505 ns |   3.16 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    24.7464 ns |  0.1503 ns |  0.1332 ns |   3.57 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    14.8160 ns |  0.0399 ns |  0.0373 ns |   2.14 |    0.01 |      - |     - |     - |         - |
|                      |       |               |            |            |        |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **794.2848 ns** |  **2.9695 ns** |  **2.6324 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   728.4335 ns |  3.2081 ns |  2.8439 ns |   0.92 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 9,017.7725 ns | 24.0587 ns | 20.0901 ns |  11.35 |    0.05 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 | 2,698.5375 ns | 14.8150 ns | 12.3712 ns |   3.40 |    0.02 |      - |     - |     - |         - |
|               LinqAF |  1000 | 3,796.1799 ns | 11.9606 ns |  9.9877 ns |   4.78 |    0.03 |      - |     - |     - |         - |
|           StructLinq |  1000 | 3,198.7878 ns | 17.7943 ns | 16.6448 ns |   4.03 |    0.03 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |   799.1520 ns |  3.6673 ns |  3.2510 ns |   1.01 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 1,816.3151 ns |  5.5238 ns |  4.8967 ns |   2.29 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |   645.5019 ns |  2.4618 ns |  2.3028 ns |   0.81 |    0.00 |      - |     - |     - |         - |
