## List.Int32.ListInt32Contains

### Source
[ListInt32Contains.cs](../LinqBenchmarks/List/Int32/ListInt32Contains.cs)

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
|               Method |      Job |  Runtime | Count |         Mean |      Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |------ |-------------:|-----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |    **10.224 ns** |  **0.0331 ns** | **0.0294 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |    26.782 ns |  0.1351 ns | 0.1198 ns |  2.62 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |    11.094 ns |  0.0420 ns | 0.0373 ns |  1.09 |    0.01 |      - |     - |     - |         - |
|           LinqFaster | .NET 5.0 | .NET 5.0 |    10 |     7.775 ns |  0.0230 ns | 0.0215 ns |  0.76 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5.0 | .NET 5.0 |    10 |     7.811 ns |  0.0422 ns | 0.0395 ns |  0.76 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |    16.665 ns |  0.1415 ns | 0.1255 ns |  1.63 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |     9.857 ns |  0.0692 ns | 0.0578 ns |  0.96 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    14.008 ns |  0.1005 ns | 0.0891 ns |  1.37 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 5.0 | .NET 5.0 |    10 |    20.103 ns |  0.0951 ns | 0.0843 ns |  1.97 |    0.01 |      - |     - |     - |         - |
|                      |          |          |       |              |            |           |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |    10 |    10.209 ns |  0.0392 ns | 0.0348 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |    16.975 ns |  0.0923 ns | 0.0863 ns |  1.66 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |    12.072 ns |  0.0673 ns | 0.0630 ns |  1.18 |    0.01 |      - |     - |     - |         - |
|           LinqFaster | .NET 6.0 | .NET 6.0 |    10 |     7.939 ns |  0.0240 ns | 0.0213 ns |  0.78 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 6.0 | .NET 6.0 |    10 |     9.402 ns |  0.0522 ns | 0.0463 ns |  0.92 |    0.01 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |    18.189 ns |  0.1076 ns | 0.0954 ns |  1.78 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     8.786 ns |  0.0305 ns | 0.0255 ns |  0.86 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    13.698 ns |  0.1132 ns | 0.1059 ns |  1.34 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 6.0 | .NET 6.0 |    10 |    17.056 ns |  0.2205 ns | 0.2063 ns |  1.67 |    0.02 |      - |     - |     - |         - |
|                      |          |          |       |              |            |           |       |         |        |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** | **1,045.524 ns** |  **2.7009 ns** | **2.3943 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 | 2,370.376 ns | 10.8279 ns | 9.0418 ns |  2.27 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 |   244.858 ns |  1.6050 ns | 1.4228 ns |  0.23 |    0.00 |      - |     - |     - |         - |
|           LinqFaster | .NET 5.0 | .NET 5.0 |  1000 |   231.656 ns |  1.1697 ns | 1.0369 ns |  0.22 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5.0 | .NET 5.0 |  1000 |   231.420 ns |  0.9821 ns | 0.7668 ns |  0.22 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 |   542.818 ns |  3.9033 ns | 3.4602 ns |  0.52 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |   787.973 ns |  3.1016 ns | 2.7495 ns |  0.75 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 |   242.437 ns |  0.9481 ns | 0.7917 ns |  0.23 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 5.0 | .NET 5.0 |  1000 |   100.578 ns |  0.4432 ns | 0.3929 ns |  0.10 |    0.00 |      - |     - |     - |         - |
|                      |          |          |       |              |            |           |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |  1000 | 1,049.750 ns |  4.0222 ns | 3.3587 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 | 1,581.306 ns |  8.9703 ns | 7.9519 ns |  1.51 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 |   279.385 ns |  1.3501 ns | 1.1969 ns |  0.27 |    0.00 |      - |     - |     - |         - |
|           LinqFaster | .NET 6.0 | .NET 6.0 |  1000 |   273.566 ns |  0.8752 ns | 0.7758 ns |  0.26 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 6.0 | .NET 6.0 |  1000 |   272.258 ns |  0.7950 ns | 0.6207 ns |  0.26 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 |   572.549 ns |  1.5362 ns | 1.3618 ns |  0.55 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |   535.864 ns |  2.2169 ns | 1.9653 ns |  0.51 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 |   272.674 ns |  0.9761 ns | 0.8151 ns |  0.26 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 6.0 | .NET 6.0 |  1000 |   112.357 ns |  0.7968 ns | 0.7063 ns |  0.11 |    0.00 |      - |     - |     - |         - |
