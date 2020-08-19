## ToArrayVsToListBenchmarks

### References:
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT


```
|                        Method | Count |         Mean |        Error |     StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------------ |------ |-------------:|-------------:|-----------:|------:|--------:|--------:|--------:|------:|----------:|
|      **Linq_Range_Where_ToArray** |     **1** |     **92.92 ns** |     **0.696 ns** |   **0.581 ns** |  **1.00** |    **0.00** |  **0.0801** |       **-** |     **-** |     **168 B** |
|       Linq_Range_Where_ToList |     1 |     65.85 ns |     0.825 ns |   0.731 ns |  0.71 |    0.01 |  0.0801 |       - |     - |     168 B |
| Hyperlinq_Range_Where_ToArray |     1 |     79.63 ns |     0.784 ns |   0.734 ns |  0.86 |    0.01 |  0.0153 |       - |     - |      32 B |
|  Hyperlinq_Range_Where_ToList |     1 |    112.57 ns |     0.644 ns |   0.602 ns |  1.21 |    0.01 |  0.0648 |       - |     - |     136 B |
|                               |       |              |              |            |       |         |         |         |       |           |
|      **Linq_Range_Where_ToArray** |    **10** |    **191.76 ns** |     **0.977 ns** |   **0.914 ns** |  **1.00** |    **0.00** |  **0.1488** |       **-** |     **-** |     **312 B** |
|       Linq_Range_Where_ToList |    10 |    158.65 ns |     1.004 ns |   0.939 ns |  0.83 |    0.01 |  0.1488 |       - |     - |     312 B |
| Hyperlinq_Range_Where_ToArray |    10 |    106.15 ns |     0.744 ns |   0.659 ns |  0.55 |    0.00 |  0.0305 |       - |     - |      64 B |
|  Hyperlinq_Range_Where_ToList |    10 |    132.27 ns |     1.349 ns |   1.196 ns |  0.69 |    0.01 |  0.0801 |       - |     - |     168 B |
|                               |       |              |              |            |       |         |         |         |       |           |
|      **Linq_Range_Where_ToArray** |   **100** |    **884.35 ns** |     **3.321 ns** |   **3.107 ns** |  **1.00** |    **0.00** |  **0.5960** |       **-** |     **-** |    **1248 B** |
|       Linq_Range_Where_ToList |   100 |    882.69 ns |     4.550 ns |   4.034 ns |  1.00 |    0.01 |  0.6113 |       - |     - |    1280 B |
| Hyperlinq_Range_Where_ToArray |   100 |    570.18 ns |     3.517 ns |   3.118 ns |  0.64 |    0.01 |  0.2022 |       - |     - |     424 B |
|  Hyperlinq_Range_Where_ToList |   100 |    600.16 ns |     2.954 ns |   2.619 ns |  0.68 |    0.00 |  0.2518 |       - |     - |     528 B |
|                               |       |              |              |            |       |         |         |         |       |           |
|      **Linq_Range_Where_ToArray** |  **1000** |  **6,819.08 ns** |    **51.028 ns** |  **47.732 ns** |  **1.00** |    **0.00** |  **4.0970** |       **-** |     **-** |    **8592 B** |
|       Linq_Range_Where_ToList |  1000 |  6,985.19 ns |    31.091 ns |  27.561 ns |  1.02 |    0.01 |  4.0665 |       - |     - |    8520 B |
| Hyperlinq_Range_Where_ToArray |  1000 |  3,592.58 ns |    15.836 ns |  12.364 ns |  0.53 |    0.00 |  1.9226 |       - |     - |    4024 B |
|  Hyperlinq_Range_Where_ToList |  1000 |  2,906.50 ns |    12.154 ns |  10.774 ns |  0.43 |    0.00 |  1.9722 |       - |     - |    4128 B |
|                               |       |              |              |            |       |         |         |         |       |           |
|      **Linq_Range_Where_ToArray** | **10000** | **70,044.93 ns** | **1,150.728 ns** | **960.910 ns** |  **1.00** |    **0.00** | **49.9268** |       **-** |     **-** |  **106280 B** |
|       Linq_Range_Where_ToList | 10000 | 71,702.71 ns |   364.969 ns | 341.392 ns |  1.02 |    0.02 | 58.7158 | 14.6484 |     - |  131496 B |
| Hyperlinq_Range_Where_ToArray | 10000 | 27,715.96 ns |   181.624 ns | 161.005 ns |  0.40 |    0.00 | 18.8599 |       - |     - |   40024 B |
|  Hyperlinq_Range_Where_ToList | 10000 | 27,944.93 ns |   106.217 ns |  88.696 ns |  0.40 |    0.00 | 18.8599 |       - |     - |   40128 B |
