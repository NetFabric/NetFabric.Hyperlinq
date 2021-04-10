## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|               Method | Count |          Mean |      Error |      StdDev |        Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |--------------:|-----------:|------------:|--------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |      **8.517 ns** |  **0.0513 ns** |   **0.0480 ns** |      **8.524 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     14.199 ns |  0.0569 ns |   0.0533 ns |     14.187 ns |  1.67 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |     76.670 ns |  1.0146 ns |   0.8994 ns |     76.504 ns |  9.01 |    0.12 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |     27.384 ns |  0.3219 ns |   0.3011 ns |     27.324 ns |  3.22 |    0.04 |      - |     - |     - |         - |
|               LinqAF |    10 |     87.059 ns |  1.7292 ns |   2.8892 ns |     86.696 ns | 10.22 |    0.30 |      - |     - |     - |         - |
|           StructLinq |    10 |     52.913 ns |  1.0836 ns |   2.3785 ns |     51.337 ns |  6.18 |    0.26 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |     44.554 ns |  0.1521 ns |   0.1423 ns |     44.547 ns |  5.23 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     62.445 ns |  1.2729 ns |   1.9818 ns |     62.810 ns |  7.24 |    0.29 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     46.245 ns |  0.9176 ns |   0.8584 ns |     46.242 ns |  5.43 |    0.10 |      - |     - |     - |         - |
|                      |       |               |            |             |               |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |    **960.970 ns** | **17.9093 ns** |  **17.5893 ns** |    **965.164 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  1,889.728 ns | 24.6750 ns |  23.0810 ns |  1,895.847 ns |  1.97 |    0.05 |      - |     - |     - |         - |
|                 Linq |  1000 | 11,595.957 ns | 54.1983 ns |  48.0453 ns | 11,586.617 ns | 12.07 |    0.25 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 |  4,241.788 ns | 42.0375 ns |  39.3219 ns |  4,243.353 ns |  4.42 |    0.09 |      - |     - |     - |         - |
|               LinqAF |  1000 | 11,460.435 ns | 95.6999 ns |  84.8354 ns | 11,469.996 ns | 11.93 |    0.26 |      - |     - |     - |         - |
|           StructLinq |  1000 |  5,164.987 ns | 52.4696 ns |  49.0801 ns |  5,164.324 ns |  5.38 |    0.13 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |  2,018.110 ns | 21.8049 ns |  18.2081 ns |  2,017.085 ns |  2.10 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |  4,756.819 ns | 94.3340 ns | 188.3952 ns |  4,788.179 ns |  5.00 |    0.18 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  3,479.483 ns | 14.9273 ns |  12.4650 ns |  3,480.227 ns |  3.62 |    0.08 |      - |     - |     - |         - |
