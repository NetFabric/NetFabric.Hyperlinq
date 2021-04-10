## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

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

Job=.NET 5.0  Runtime=.NET 5.0  

```
|          Method | Start | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------ |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|         **ForLoop** |     **0** |    **10** |     **3.247 ns** |  **0.0428 ns** |  **0.0380 ns** |     **3.241 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|     ForeachLoop |     0 |    10 |    72.403 ns |  1.4658 ns |  2.8934 ns |    70.819 ns | 23.32 |    0.58 | 0.0267 |     - |     - |      56 B |
|            Linq |     0 |    10 |    69.143 ns |  1.3883 ns |  1.5431 ns |    69.745 ns | 21.19 |    0.43 | 0.0191 |     - |     - |      40 B |
|      LinqFaster |     0 |    10 |    14.699 ns |  0.1543 ns |  0.2782 ns |    14.654 ns |  4.55 |    0.13 | 0.0306 |     - |     - |      64 B |
| LinqFaster_SIMD |     0 |    10 |    21.615 ns |  0.1798 ns |  0.1593 ns |    21.621 ns |  6.66 |    0.06 | 0.0306 |     - |     - |      64 B |
|          LinqAF |     0 |    10 |    31.830 ns |  0.2182 ns |  0.1934 ns |    31.839 ns |  9.80 |    0.10 |      - |     - |     - |         - |
|      StructLinq |     0 |    10 |     3.653 ns |  0.0756 ns |  0.0670 ns |     3.629 ns |  1.13 |    0.03 |      - |     - |     - |         - |
|       Hyperlinq |     0 |    10 |    12.053 ns |  0.1443 ns |  0.1349 ns |    11.999 ns |  3.71 |    0.03 |      - |     - |     - |         - |
|                 |       |       |              |            |            |              |       |         |        |       |       |           |
|         **ForLoop** |     **0** |  **1000** |   **279.818 ns** |  **2.0662 ns** |  **1.8316 ns** |   **279.697 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|     ForeachLoop |     0 |  1000 | 4,324.456 ns | 26.5983 ns | 23.5787 ns | 4,318.792 ns | 15.46 |    0.12 | 0.0229 |     - |     - |      56 B |
|            Linq |     0 |  1000 | 4,064.107 ns | 32.5775 ns | 28.8791 ns | 4,069.614 ns | 14.52 |    0.12 | 0.0153 |     - |     - |      40 B |
|      LinqFaster |     0 |  1000 | 1,356.085 ns | 27.4793 ns | 80.5921 ns | 1,305.569 ns |  4.71 |    0.19 | 1.9226 |     - |     - |   4,024 B |
| LinqFaster_SIMD |     0 |  1000 |   910.014 ns |  4.8470 ns |  4.0474 ns |   909.498 ns |  3.26 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|          LinqAF |     0 |  1000 | 1,889.403 ns |  9.7152 ns |  8.6123 ns | 1,888.436 ns |  6.75 |    0.04 |      - |     - |     - |         - |
|      StructLinq |     0 |  1000 |   276.201 ns |  1.8543 ns |  1.7345 ns |   276.196 ns |  0.99 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq |     0 |  1000 |   314.734 ns |  2.5476 ns |  2.3830 ns |   315.802 ns |  1.13 |    0.01 |      - |     - |     - |         - |
