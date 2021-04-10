## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |          Mean |       Error |     StdDev |        Median |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |--------------:|------------:|-----------:|--------------:|-------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **1000** |    **10** |      **8.265 ns** |   **0.0405 ns** |  **0.0338 ns** |      **8.254 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  3,530.739 ns |   9.8445 ns |  8.2206 ns |  3,531.491 ns | 427.18 |    2.20 | 0.0191 |     - |     - |      40 B |
|                 Linq | 1000 |    10 |    210.747 ns |   4.2216 ns |  7.5038 ns |    210.953 ns |  25.13 |    0.79 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |    10 |    134.142 ns |   0.9688 ns |  0.8588 ns |    134.265 ns |  16.22 |    0.11 | 0.1528 |     - |     - |     320 B |
|               LinqAF | 1000 |    10 |  4,311.585 ns |  17.3544 ns | 15.3842 ns |  4,313.007 ns | 521.59 |    3.42 |      - |     - |     - |         - |
|           StructLinq | 1000 |    10 |     88.622 ns |   0.5199 ns |  0.4341 ns |     88.617 ns |  10.72 |    0.08 | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |    10 |     40.157 ns |   0.1267 ns |  0.1123 ns |     40.200 ns |   4.86 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |     67.511 ns |   1.5155 ns |  4.3968 ns |     65.189 ns |   8.66 |    0.70 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |     61.493 ns |   0.3795 ns |  0.3364 ns |     61.410 ns |   7.44 |    0.06 |      - |     - |     - |         - |
|                      |      |       |               |             |            |               |        |         |        |       |       |           |
|              **ForLoop** | **1000** |  **1000** |  **1,399.736 ns** |  **17.6669 ns** | **15.6613 ns** |  **1,401.864 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 |  7,052.382 ns |  79.0784 ns | 73.9700 ns |  7,003.477 ns |   5.04 |    0.09 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |  1000 | 15,559.676 ns |  58.4729 ns | 51.8347 ns | 15,566.071 ns |  11.12 |    0.12 | 0.0610 |     - |     - |     152 B |
|           LinqFaster | 1000 |  1000 |  8,996.984 ns |  44.8768 ns | 37.4741 ns |  9,002.148 ns |   6.44 |    0.08 | 5.9204 |     - |     - |  12,416 B |
|               LinqAF | 1000 |  1000 | 20,542.777 ns | 112.0773 ns | 93.5896 ns | 20,512.018 ns |  14.70 |    0.21 |      - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  7,034.915 ns |  53.2321 ns | 49.7934 ns |  7,040.620 ns |   5.03 |    0.07 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |  1000 |  1,610.574 ns |  13.1202 ns | 12.2726 ns |  1,607.404 ns |   1.15 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 |  5,241.236 ns |  34.3184 ns | 32.1015 ns |  5,235.561 ns |   3.74 |    0.05 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  2,147.965 ns |  30.9601 ns | 25.8531 ns |  2,135.783 ns |   1.54 |    0.02 |      - |     - |     - |         - |
