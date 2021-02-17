## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|              **ForLoop** |     **0** |     **0.2010 ns** |  **0.0039 ns** |  **0.0033 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |     0.4955 ns |  0.0085 ns |  0.0080 ns |   2.47 |    0.04 |      - |     - |     - |         - |
|                 Linq |     0 |    29.1876 ns |  0.1415 ns |  0.1324 ns | 145.28 |    2.64 |      - |     - |     - |         - |
|           LinqFaster |     0 |    10.2921 ns |  0.0492 ns |  0.0436 ns |  51.22 |    0.94 | 0.0115 |     - |     - |      24 B |
|               LinqAF |     0 |    29.2554 ns |  0.0559 ns |  0.0496 ns | 145.61 |    2.40 |      - |     - |     - |         - |
|           StructLinq |     0 |    32.6753 ns |  0.1037 ns |  0.0919 ns | 162.62 |    2.87 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |     0 |    34.5319 ns |  0.0602 ns |  0.0533 ns | 171.86 |    3.00 |      - |     - |     - |         - |
|            Hyperlinq |     0 |    25.8627 ns |  0.0509 ns |  0.0451 ns | 128.70 |    2.07 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |    23.6639 ns |  0.0501 ns |  0.0469 ns | 117.74 |    1.86 |      - |     - |     - |         - |
|                      |       |               |            |            |        |         |        |       |       |           |
|              **ForLoop** |    **10** |     **6.6555 ns** |  **0.0347 ns** |  **0.0308 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     6.6475 ns |  0.0341 ns |  0.0302 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |    10 |    85.6306 ns |  0.5804 ns |  0.5145 ns |  12.87 |    0.09 | 0.0497 |     - |     - |     104 B |
|           LinqFaster |    10 |    44.3703 ns |  0.1563 ns |  0.1305 ns |   6.67 |    0.03 | 0.0459 |     - |     - |      96 B |
|               LinqAF |    10 |    61.8701 ns |  0.3145 ns |  0.2788 ns |   9.30 |    0.04 |      - |     - |     - |         - |
|           StructLinq |    10 |    57.9666 ns |  0.1543 ns |  0.1288 ns |   8.72 |    0.04 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    50.1781 ns |  0.0897 ns |  0.0839 ns |   7.54 |    0.04 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    45.5631 ns |  0.1329 ns |  0.1110 ns |   6.85 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    40.7998 ns |  0.1060 ns |  0.0992 ns |   6.13 |    0.04 |      - |     - |     - |         - |
|                      |       |               |            |            |        |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **755.1278 ns** |  **4.5894 ns** |  **4.0684 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   784.1303 ns |  2.9013 ns |  2.7139 ns |   1.04 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 8,066.5333 ns | 22.8134 ns | 20.2235 ns |  10.68 |    0.06 | 0.0458 |     - |     - |     104 B |
|           LinqFaster |  1000 | 4,081.4235 ns | 26.5085 ns | 24.7960 ns |   5.40 |    0.04 | 2.8915 |     - |     - |    6064 B |
|               LinqAF |  1000 | 6,481.0751 ns | 15.2405 ns | 14.2560 ns |   8.58 |    0.05 |      - |     - |     - |         - |
|           StructLinq |  1000 | 5,253.9288 ns | 30.4421 ns | 26.9862 ns |   6.96 |    0.05 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 1,498.8454 ns |  6.2182 ns |  5.5123 ns |   1.98 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 5,163.2878 ns | 21.0436 ns | 17.5724 ns |   6.84 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 1,891.9937 ns |  4.1804 ns |  3.9104 ns |   2.51 |    0.01 |      - |     - |     - |         - |
