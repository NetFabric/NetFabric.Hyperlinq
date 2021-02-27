## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta41](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta41)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **7.856 ns** |  **0.0271 ns** |  **0.0253 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     7.031 ns |  0.0550 ns |  0.0515 ns |  0.90 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    91.819 ns |  0.5450 ns |  0.4831 ns | 11.69 |    0.07 | 0.0497 |     - |     - |     104 B |
|           LinqFaster |    10 |    51.859 ns |  0.2308 ns |  0.1928 ns |  6.60 |    0.03 | 0.0459 |     - |     - |      96 B |
|               LinqAF |    10 |    65.032 ns |  0.2788 ns |  0.2472 ns |  8.28 |    0.04 |      - |     - |     - |         - |
|           StructLinq |    10 |    61.732 ns |  0.3962 ns |  0.3512 ns |  7.86 |    0.05 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    51.356 ns |  0.1105 ns |  0.0923 ns |  6.53 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    52.956 ns |  0.6163 ns |  0.5147 ns |  6.74 |    0.07 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    48.834 ns |  0.1925 ns |  0.1706 ns |  6.22 |    0.03 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **797.354 ns** |  **6.2979 ns** |  **5.2590 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 1,133.286 ns | 15.3780 ns | 14.3846 ns |  1.42 |    0.02 |      - |     - |     - |         - |
|                 Linq |  1000 | 7,883.629 ns | 88.9401 ns | 78.8430 ns |  9.89 |    0.08 | 0.0458 |     - |     - |     104 B |
|           LinqFaster |  1000 | 5,482.728 ns | 19.7564 ns | 17.5135 ns |  6.88 |    0.04 | 2.8915 |     - |     - |   6,064 B |
|               LinqAF |  1000 | 6,857.059 ns | 33.8293 ns | 28.2490 ns |  8.60 |    0.08 |      - |     - |     - |         - |
|           StructLinq |  1000 | 5,459.628 ns | 23.5893 ns | 20.9113 ns |  6.85 |    0.05 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 1,604.030 ns | 20.9814 ns | 19.6260 ns |  2.01 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 5,678.595 ns | 36.5295 ns | 32.3824 ns |  7.12 |    0.07 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 1,996.651 ns |  8.8661 ns |  6.9220 ns |  2.50 |    0.02 |      - |     - |     - |         - |
