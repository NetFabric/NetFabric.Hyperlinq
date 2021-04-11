## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |      Job |  Runtime | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |     **21.41 ns** |   **0.114 ns** |   **0.106 ns** |     **21.40 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |     51.92 ns |   0.383 ns |   0.340 ns |     51.89 ns |  2.43 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |    140.69 ns |   2.818 ns |   4.551 ns |    137.85 ns |  6.74 |    0.22 | 0.0458 |     - |     - |      96 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |    10 |     41.40 ns |   0.146 ns |   0.129 ns |     41.41 ns |  1.93 |    0.01 |      - |     - |     - |         - |
|               LinqAF | .NET 5.0 | .NET 5.0 |    10 |    152.14 ns |   2.944 ns |   3.023 ns |    152.65 ns |  7.10 |    0.15 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |     38.45 ns |   0.305 ns |   0.270 ns |     38.44 ns |  1.80 |    0.02 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |     20.55 ns |   0.058 ns |   0.054 ns |     20.54 ns |  0.96 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |     73.93 ns |   0.306 ns |   0.271 ns |     73.86 ns |  3.45 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |     50.65 ns |   0.176 ns |   0.147 ns |     50.71 ns |  2.37 |    0.01 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |              |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |    10 |     21.33 ns |   0.118 ns |   0.104 ns |     21.32 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |     50.67 ns |   0.429 ns |   0.380 ns |     50.83 ns |  2.38 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |    132.57 ns |   2.535 ns |   2.247 ns |    131.30 ns |  6.22 |    0.12 | 0.0458 |     - |     - |      96 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |    10 |     44.07 ns |   0.146 ns |   0.130 ns |     44.10 ns |  2.07 |    0.01 |      - |     - |     - |         - |
|               LinqAF | .NET 6.0 | .NET 6.0 |    10 |    150.95 ns |   2.840 ns |   3.156 ns |    151.73 ns |  7.08 |    0.15 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |     35.03 ns |   0.290 ns |   0.242 ns |     35.00 ns |  1.64 |    0.02 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     20.91 ns |   0.091 ns |   0.081 ns |     20.88 ns |  0.98 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |     67.72 ns |   0.447 ns |   0.418 ns |     67.64 ns |  3.18 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     52.12 ns |   0.097 ns |   0.081 ns |     52.14 ns |  2.44 |    0.01 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |              |       |         |        |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** |  **2,636.56 ns** |   **6.159 ns** |   **5.761 ns** |  **2,636.04 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 |  4,624.45 ns |  38.465 ns |  34.098 ns |  4,632.17 ns |  1.75 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 |  8,908.72 ns | 166.688 ns | 155.920 ns |  8,865.02 ns |  3.38 |    0.06 | 0.0458 |     - |     - |      96 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |  1000 |  4,522.73 ns |  17.204 ns |  14.366 ns |  4,519.34 ns |  1.72 |    0.01 |      - |     - |     - |         - |
|               LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 10,446.04 ns | 236.785 ns | 632.027 ns | 10,307.98 ns |  3.96 |    0.15 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 |  2,720.54 ns | 208.535 ns | 614.869 ns |  2,474.03 ns |  1.19 |    0.23 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |    738.89 ns |   3.208 ns |   3.001 ns |    737.75 ns |  0.28 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 |  5,128.48 ns |  18.645 ns |  15.569 ns |  5,126.72 ns |  1.95 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |  3,775.42 ns |  16.344 ns |  15.288 ns |  3,778.92 ns |  1.43 |    0.01 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |              |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |  1000 |  2,515.09 ns |   6.288 ns |   4.909 ns |  2,514.21 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 |  4,589.41 ns |  53.873 ns |  50.393 ns |  4,603.47 ns |  1.82 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 |  9,601.32 ns |  41.391 ns |  38.717 ns |  9,607.23 ns |  3.82 |    0.02 | 0.0458 |     - |     - |      96 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |  1000 |  4,906.93 ns |  13.248 ns |  12.392 ns |  4,908.02 ns |  1.95 |    0.01 |      - |     - |     - |         - |
|               LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 10,125.08 ns | 202.471 ns | 440.156 ns | 10,227.82 ns |  3.97 |    0.18 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 |  2,343.98 ns |  12.076 ns |  10.705 ns |  2,339.35 ns |  0.93 |    0.00 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |    808.44 ns |   3.664 ns |   3.248 ns |    808.06 ns |  0.32 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 |  4,978.61 ns |  13.434 ns |  10.489 ns |  4,981.65 ns |  1.98 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |  3,715.52 ns |   8.337 ns |   7.390 ns |  3,716.35 ns |  1.48 |    0.00 |      - |     - |     - |         - |
