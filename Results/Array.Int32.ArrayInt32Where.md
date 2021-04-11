## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|               Method |      Job |  Runtime | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |     **6.836 ns** |  **0.0594 ns** |  **0.0526 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |     6.800 ns |  0.0450 ns |  0.0399 ns |  0.99 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |    62.289 ns |  0.3183 ns |  0.2822 ns |  9.11 |    0.08 | 0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |    10 |    42.333 ns |  0.8621 ns |  0.8467 ns |  6.18 |    0.14 | 0.0459 |     - |     - |      96 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |    10 |    49.486 ns |  0.1408 ns |  0.1317 ns |  7.24 |    0.06 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |    41.032 ns |  0.3447 ns |  0.3225 ns |  6.00 |    0.07 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    36.254 ns |  0.1615 ns |  0.1349 ns |  5.30 |    0.04 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    44.913 ns |  0.3843 ns |  0.3595 ns |  6.58 |    0.06 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    39.801 ns |  0.0846 ns |  0.0750 ns |  5.82 |    0.05 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |    10 |     7.500 ns |  0.0137 ns |  0.0107 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |     7.647 ns |  0.0282 ns |  0.0236 ns |  1.02 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |    52.412 ns |  0.5704 ns |  0.4453 ns |  6.99 |    0.06 | 0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |    10 |    39.846 ns |  0.3556 ns |  0.5431 ns |  5.34 |    0.11 | 0.0459 |     - |     - |      96 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |    10 |    49.330 ns |  0.1667 ns |  0.1477 ns |  6.57 |    0.02 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |    43.891 ns |  0.8987 ns |  1.1686 ns |  5.78 |    0.20 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    36.507 ns |  0.0981 ns |  0.0819 ns |  4.87 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    44.288 ns |  0.1063 ns |  0.0888 ns |  5.91 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    39.745 ns |  0.2408 ns |  0.2135 ns |  5.30 |    0.03 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** |   **627.946 ns** |  **5.9171 ns** |  **5.5348 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 |   624.609 ns |  3.0983 ns |  2.8981 ns |  0.99 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 | 6,125.480 ns | 38.3770 ns | 35.8979 ns |  9.76 |    0.11 | 0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |  1000 | 4,030.066 ns | 15.4942 ns | 12.0969 ns |  6.40 |    0.05 | 2.8915 |     - |     - |   6,064 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 6,372.823 ns | 19.6813 ns | 17.4470 ns | 10.14 |    0.08 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 6,053.075 ns | 10.5733 ns |  9.3730 ns |  9.63 |    0.08 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 1,804.258 ns |  8.2137 ns |  7.2812 ns |  2.87 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 5,627.457 ns | 10.8519 ns |  9.6200 ns |  8.96 |    0.07 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 2,059.658 ns |  8.5562 ns |  7.1448 ns |  3.27 |    0.03 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |  1000 |   736.933 ns |  3.1536 ns |  2.7956 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 |   736.721 ns |  2.0261 ns |  1.7961 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 | 6,129.361 ns | 32.3541 ns | 30.2641 ns |  8.32 |    0.04 | 0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |  1000 | 3,787.966 ns | 20.1534 ns | 18.8515 ns |  5.14 |    0.03 | 2.8915 |     - |     - |   6,064 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 6,848.059 ns | 10.5476 ns |  9.3502 ns |  9.29 |    0.04 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 6,035.980 ns | 14.6400 ns | 13.6943 ns |  8.19 |    0.04 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 1,612.430 ns |  5.2556 ns |  4.3886 ns |  2.19 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 5,112.163 ns | 16.9130 ns | 14.9930 ns |  6.94 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 2,056.699 ns | 16.3598 ns | 13.6612 ns |  2.79 |    0.02 |      - |     - |     - |         - |
